using System;
using System.Collections.Generic;

using Orm;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using System.Collections;


namespace MM
{

    public class AreaCliente
    {
        private Business.Cliente _cliente;



        public AreaCliente()
        {
            _cliente = new Business.Cliente();

        }
        public bool Login(string email, string password)
        {
            bool IsLoginValidated = false;


            UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();
            utilizadorCriteria.Email.Eq(email);
            utilizadorCriteria.Password.Eq(password);

            Utilizador ut = utilizadorCriteria.UniqueUtilizador();

            if (ut != null)
            {
                Cliente cliente = ut.Cliente;

                _cliente.Nome = cliente.Nome_cliente;
                _cliente.Password = ut.Password;
                _cliente.Email = ut.Email;
                _cliente.ListaPreferencias.OrdemRatingEstabelecimento = cliente.Ord_rat_est;
                _cliente.ListaPreferencias.OrdemRatingIguaria = cliente.Ord_rat_igu;
                _cliente.ListaPreferencias.OrdemDistancia = cliente.Ord_dist;
                _cliente.ListaPreferencias.OrdemPopularidadeIguaria = cliente.Ord_pop_igu;
                _cliente.ListaPreferencias.OrdemPopularidadeEstabelecimento = cliente.Ord_pop_est;


                IsLoginValidated = true;
            }


            return IsLoginValidated;
        }

        public void PublicarCritica(int idCliente, int idIguaria, int idEstabelecimento, string descricao, decimal ratingEstabelecimento, decimal ratingIguaria)
        {

            DateTime data = DateTime.Now;

            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                ClienteCriteria clienteCriteria = new ClienteCriteria(); Cliente cli = clienteCriteria.UniqueCliente();
                IguariaCriteria iguariaCriteria = new IguariaCriteria();
                iguariaCriteria.Id_iguaria.Eq(idIguaria);
                iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(idEstabelecimento);
                Iguaria ig = iguariaCriteria.UniqueIguaria();
                EstabelecimentoCriteria estabelecimentoCiteria = new EstabelecimentoCriteria();
                estabelecimentoCiteria.Id_estabelecimento.Eq(idEstabelecimento);
                Estabelecimento est = estabelecimentoCiteria.UniqueEstabelecimento();

                // NOTE : Um cliente só pode ter uma critica
                Cliente_critica_Iguaria cliente_critica_Iguaria = Cliente_critica_Iguaria.CreateCliente_critica_Iguaria();
                clienteCriteria.Id_cliente.Eq(idCliente);

                cliente_critica_Iguaria.Rating_igu = ratingIguaria;
                cliente_critica_Iguaria.Desc_critica = descricao;
                cliente_critica_Iguaria.Data_critica = data;
                cliente_critica_Iguaria.Cliente = cli;
                cliente_critica_Iguaria.Iguaria = ig;

                // NOTE : Rating de estabelecimento é opcional. No entanto, depois da critica ser realizada, estabelecimento já não pode ser avaliado
                if (ratingEstabelecimento != 0)
                {
                    Cliente_avalia_Estabelecimento cliente_avalia_Estabelecimento = Cliente_avalia_Estabelecimento.CreateCliente_avalia_Estabelecimento();
                    cliente_avalia_Estabelecimento.Cliente = cli;
                    cliente_avalia_Estabelecimento.Estabelecimento = est;
                    cliente_avalia_Estabelecimento.Data_avaliacao = DateTime.Now;
                    cliente_avalia_Estabelecimento.Rating_est = ratingEstabelecimento;
                    cliente_avalia_Estabelecimento.Save();
                }
                cliente_critica_Iguaria.Save();

                t.Commit();

            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }


        }

        public void RegistarCliente(string email, string password, string nome)
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                Utilizador utilizador = Utilizador.CreateUtilizador();
                utilizador.Email = email;
                utilizador.Password = password;
                utilizador.Tipo = 0;
                utilizador.Save();

                Cliente cliente = Cliente.CreateCliente();
                cliente.Nome_cliente = nome;
                cliente.Utilizador = utilizador;

                cliente.Save();

                t.Commit();

            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }


        }

        public void AtualizarCliente(string password, string nome)
        {


            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {

                ClienteCriteria clienteCriteria = new ClienteCriteria();

                clienteCriteria.Id_cliente.Eq(_cliente.IdCliente);
                Cliente cliente = clienteCriteria.UniqueCliente();

                cliente.Nome_cliente = nome;


                UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();

                utilizadorCriteria.Email.Eq(cliente.Utilizador.Email);

                Utilizador utilizador = utilizadorCriteria.UniqueUtilizador();
                utilizador.Password = password;

                _cliente.Nome = cliente.Nome_cliente;
                _cliente.Password = utilizador.Password;

                utilizador.Save();
                cliente.Save();
                t.Commit();
            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public Dictionary<int, Business.Iguaria> ConsultarHistorico()
        {
            Dictionary<int, Business.Iguaria> tmp = new Dictionary<int, Business.Iguaria>();
            try
            {

                SelecaoIguariaCriteria selecaoIguariaCriteria = new SelecaoIguariaCriteria();
                selecaoIguariaCriteria.Cliente_Cliente.Eq(_cliente.IdCliente);
                selecaoIguariaCriteria.Data_hora_visualizacao.Order(false);
                selecaoIguariaCriteria.SetMaxResults(5);

                SelecaoIguaria[] si = SelecaoIguaria.ListSelecaoIguariaByCriteria(selecaoIguariaCriteria);
                IguariaCriteria iguariaCriteria;

                Iguaria[] igs = new Iguaria[si.Length];

                for (int i = 0; i < si.Length; i++)
                {
                    iguariaCriteria = new IguariaCriteria();
                    iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(si[i].Cliente_Estabelecimento);
                    iguariaCriteria.Id_iguaria.Eq(si[i].Cliente_Iguaria);
                    igs[i] = iguariaCriteria.UniqueIguaria();
                    tmp[igs[i].Id_iguaria] = new Business.Iguaria(igs[i].Nome_iguaria, igs[i].Visual_iguaria, igs[i].Rating_medio_iguaria, igs[i].Fotografia, igs[i].Preco, igs[i].Id_iguaria, igs[i].Estabelecimento_id_estabelecimento);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                Console.ReadLine();
            }

            return tmp;
        }

        public Business.Estabelecimento EscolherIguaria(int idIguaria, int idEstabelecimento)
        {
            Business.Estabelecimento estabelecimento = null;
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                ClienteCriteria clienteCriteria = new ClienteCriteria();
                clienteCriteria.Id_cliente.Eq(_cliente.IdCliente);

                Cliente cli = clienteCriteria.UniqueCliente();

                IguariaCriteria iguariaCriteria = new IguariaCriteria();
                iguariaCriteria.Id_iguaria.Eq(idIguaria);
                iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(idEstabelecimento);

                Iguaria ig = iguariaCriteria.UniqueIguaria();

                EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();
                estabelecimentoCriteria.Id_estabelecimento.Eq(idEstabelecimento);

                Estabelecimento est = estabelecimentoCriteria.UniqueEstabelecimento();

                Utilizador ut = est.Utilizador;

                Cliente_seleciona_EstabelecimentoCriteria cliente_seleciona_EstabelecimentoCriteria = new Cliente_seleciona_EstabelecimentoCriteria();
                cliente_seleciona_EstabelecimentoCriteria.Cliente_id_cliente.Eq(_cliente.IdCliente);
                cliente_seleciona_EstabelecimentoCriteria.Estabelecimento_id_estabelecimento.Eq(idEstabelecimento);

                Cliente_seleciona_Estabelecimento cse = cliente_seleciona_EstabelecimentoCriteria.UniqueCliente_seleciona_Estabelecimento();

                if (cse == null)
                {
                    cse = Cliente_seleciona_Estabelecimento.CreateCliente_seleciona_Estabelecimento();

                    cse.Cliente = cli;
                    cse.Estabelecimento = est;
                    cse.Save();
                }
                Cliente_seleciona_iguariaCriteria cliente_seleciona_iguariaCriteria = new Cliente_seleciona_iguariaCriteria();
                cliente_seleciona_iguariaCriteria.Cliente_id_cliente.Eq(_cliente.IdCliente);
                cliente_seleciona_iguariaCriteria.Iguaria_Estabelecimento.Eq(idEstabelecimento);
                cliente_seleciona_iguariaCriteria.Iguaria_id_iguaria.Eq(idIguaria);

                Cliente_seleciona_iguaria csi = cliente_seleciona_iguariaCriteria.UniqueCliente_seleciona_iguaria();

                if (csi == null)
                {
                    csi = Cliente_seleciona_iguaria.CreateCliente_seleciona_iguaria();

                    csi.Cliente = cli;
                    csi.Iguaria = ig; csi.Save();
                }



                SelecaoEstabelecimento se = SelecaoEstabelecimento.CreateSelecaoEstabelecimento();
                if (se.Id_selecao == 0)
                {
                    SelecaoEstabelecimentoCriteria stemp = new SelecaoEstabelecimentoCriteria();
                    se.Id_selecao = ((int)stemp.SetProjection(Projections.Max(SelecaoEstabelecimento.PROP_ID_SELECAO)).UniqueResult()) + 1;


                }

                se.Estabelecimento = cse;
                se.Data_hora_selecao = DateTime.Now;

                se.Save();



                SelecaoIguaria si = SelecaoIguaria.CreateSelecaoIguaria(); si.Cliente = csi;
                si.Data_hora_visualizacao = DateTime.Now;

                if (si.Id_visualizacao == 0)
                {
                    SelecaoIguariaCriteria stemp = new SelecaoIguariaCriteria();
                    si.Id_visualizacao = ((int)stemp.SetProjection(Projections.Max(SelecaoIguaria.PROP_ID_VISUALIZACAO)).UniqueResult()) + 1;
                }

                si.Save();



                SelecaoEstabelecimentoCriteria selecaoEstabelecimentoCriteria = new SelecaoEstabelecimentoCriteria();
                selecaoEstabelecimentoCriteria.Estabelecimento_Estabelecimento.Eq(est.Id_estabelecimento);

                int vis_est = (int)selecaoEstabelecimentoCriteria.SetProjection(Projections.RowCount()).UniqueResult();

                est.Visual_estabelecimento = vis_est;

                SelecaoIguariaCriteria selecaoIguariaCriteria = new SelecaoIguariaCriteria();
                selecaoIguariaCriteria.Cliente_Iguaria.Eq(idIguaria);
                int vis_ig = (int)selecaoIguariaCriteria.SetProjection(Projections.RowCount()).UniqueResult();

                ig.Visual_iguaria = vis_ig;
                HorarioEstabelecimentoCriteria horarioEstabelecimentoCriteria = new HorarioEstabelecimentoCriteria();

                HorarioEstabelecimento[] hor = est.horarioEstabelecimento.ToArray();
                Categoria cat = est.Categoria1;
                Cliente_avalia_EstabelecimentoCriteria cliente_avalia_EstabelecimentoCriteria = new Cliente_avalia_EstabelecimentoCriteria();

                cliente_avalia_EstabelecimentoCriteria.Estabelecimento_id_estabelecimento.Eq(idEstabelecimento);
                cliente_avalia_EstabelecimentoCriteria.SetProjection(Projections.Avg(Cliente_avalia_Estabelecimento.PROP_RATING_EST)); decimal rating = Convert.ToDecimal(cliente_avalia_EstabelecimentoCriteria.UniqueResult());

                est.Rating_medio_estabelecimento = rating;
                Cliente_critica_IguariaCriteria cliente_critica_IguariaCriteria = new Cliente_critica_IguariaCriteria();

                cliente_critica_IguariaCriteria.Iguaria_Estabelecimento.Eq(idEstabelecimento);
                cliente_critica_IguariaCriteria.Iguaria_id_iguaria.Eq(idIguaria);
                cliente_critica_IguariaCriteria.Data_critica.Order(false);
                cliente_critica_IguariaCriteria.SetMaxResults(5);

                Cliente_critica_Iguaria[] crits = Cliente_critica_Iguaria.ListCliente_critica_IguariaByCriteria(cliente_critica_IguariaCriteria);

                List<Business.Horario> _horarios = new List<Business.Horario>();
               


                foreach (var item in hor)
                {
                    _horarios.Add(new Business.Horario(item.Dia, new TimeSpan(item.Hora_abertura.Hour, item.Hora_abertura.Minute, item.Hora_abertura.Second), new TimeSpan(item.Hora_fecho.Hour, item.Hora_fecho.Minute, item.Hora_fecho.Second)));
                }

                estabelecimento = new Business.Estabelecimento(ut.Email, ut.Password, est.Desc_ambiente, est.Nome_estabelecimento, est.Telefone, _horarios, new Business.Endereco(est.Cod_postal, est.Latitude, est.Localidade, est.Longitude, est.Numero, est.Rua), cat.Id_categoria);

                



                List<Business.Critica> _criticas = new List<Business.Critica>();
                foreach (var item in crits)
                {
                    _criticas.Add(new Business.Critica(item.Desc_critica, item.Data_critica, item.Rating_igu));
                }



                Business.Iguaria iguaria = 
                
                estabelecimento.IguariasMap[ig.Id_iguaria] = new Business.Iguaria(ig.Nome_iguaria, ig.Visual_iguaria, ig.Rating_medio_iguaria, ig.Fotografia, ig.Preco, ig.Id_iguaria, ig.Estabelecimento_id_estabelecimento, _criticas);

                


                ig.Save();
                est.Save();

                t.Commit();
            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }

            return estabelecimento;

        }

        public List<Business.Iguaria> GerarPedido(string pedido)
        {

            List<Business.Iguaria> iguarias = new List<Business.Iguaria>();

            try
            {

                ClienteCriteria cliC = new ClienteCriteria();
                cliC.Id_cliente.Eq(_cliente.IdCliente);

                Cliente cli = cliC.UniqueCliente();


                IguariaCriteria iguariaCriteria = new IguariaCriteria();
                iguariaCriteria.Nome_iguaria.Like("%" + pedido + "%");




                if (cli.Ord_rat_est == 1)
                {
                    iguariaCriteria.CreateEstabelecimentoCriteria().Rating_medio_estabelecimento.Order(true);
                }
                else if (cli.Ord_rat_est == 2)
                {
                    iguariaCriteria.CreateEstabelecimentoCriteria().Rating_medio_estabelecimento.Order(false);
                }

                if (cli.Ord_pop_est == 1)
                {
                    iguariaCriteria.CreateEstabelecimentoCriteria().Visual_estabelecimento.Order(true);
                }
                else if (cli.Ord_pop_est == 2)
                {
                    iguariaCriteria.CreateEstabelecimentoCriteria().Visual_estabelecimento.Order(false);
                }

                if (cli.Ord_rat_igu == 1)
                {
                    iguariaCriteria.Rating_medio_iguaria.Order(true);
                }
                else if (cli.Ord_rat_igu == 2)
                {
                    iguariaCriteria.Rating_medio_iguaria.Order(false);
                }

                if (cli.Ord_pop_igu == 1)
                {
                    iguariaCriteria.Visual_iguaria.Order(true);
                }
                else if (cli.Ord_pop_igu == 2)
                {
                    iguariaCriteria.Visual_iguaria.Order(false);
                }


                iguariaCriteria.SetMaxResults(5);



                Iguaria[] igs = Iguaria.ListIguariaByCriteria(iguariaCriteria);



                foreach (var item in igs)
                {
                    iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(igs[i].Estabelecimento_id_estabelecimento);


                    iguarias.Add(new Business.Iguaria(item.Nome_iguaria, item.Visual_iguaria, item.Rating_medio_iguaria, item.Fotografia, item.Preco, item.Id_iguaria, item.Estabelecimento_id_estabelecimento));
                }
               

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                Console.ReadLine();
            }

            return iguarias;
        }

        public void PublicarFacebook()
        {
            throw new System.NotImplementedException();
        }

        public void PublicarTwiiter()
        {
            throw new System.NotImplementedException();
        }

        public void ConsultarPreferencias()
        {
            try
            {

                ClienteCriteria clienteCriteria = new ClienteCriteria();

                clienteCriteria.Id_cliente.Eq(_cliente.IdCliente);

                Cliente cli = clienteCriteria.UniqueCliente();


                _cliente.ListaPreferencias.OrdemRatingIguaria = cli.Ord_rat_igu;
                _cliente.ListaPreferencias.OrdemRatingEstabelecimento = cli.Ord_rat_est;
                _cliente.ListaPreferencias.OrdemDistancia = cli.Ord_dist;
                _cliente.ListaPreferencias.OrdemPopularidadeIguaria = cli.Ord_pop_igu;
                _cliente.ListaPreferencias.OrdemPopularidadeIguaria = cli.Ord_rat_est;

               

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void EditarPreferencias(byte _ordem_rating_iguaria, byte _ordem_rating_estabelecimento, byte _ordem_distancia, byte _ordem_popularidade_iguaria, byte _ordem_popularidade_estabelecimento)
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                ClienteCriteria clienteCriteria = new ClienteCriteria();

                clienteCriteria.Id_cliente.Eq(_cliente.IdCliente);

                Cliente cli = clienteCriteria.UniqueCliente();


                cli.Ord_rat_igu = _ordem_rating_iguaria;
                cli.Ord_rat_est = _ordem_rating_estabelecimento;
                cli.Ord_dist = _ordem_distancia;
                cli.Ord_pop_igu = _ordem_popularidade_iguaria;
                cli.Ord_pop_est = _ordem_popularidade_estabelecimento;

              

                cli.Save();
                t.Commit();
            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        /**
         * TODO: Lista de preferencias
         */
        public List<List<string>> ListarTendencias()
        {
            List<List<string>> tendencias = new List<List<string>>();
            List<string> ratingIguarias = new List<string>();
            List<string> popIguarias = new List<string>();
            List<string> ratingEstabelecimento = new List<string>();
            List<string> popEstabelecimento = new List<string>();
            

            try
            {
                /**
                 * Seleciona 5 últimas iguarias
                 *
                 */

                EstabelecimentoCriteria estabelecimentoCriteriaTopRating = new EstabelecimentoCriteria();
                estabelecimentoCriteriaTopRating.Rating_medio_estabelecimento.Order(false);
                estabelecimentoCriteriaTopRating.SetMaxResults(5);

                EstabelecimentoCriteria estabelecimentoCriteriaTop = new EstabelecimentoCriteria();
                estabelecimentoCriteriaTop.Visual_estabelecimento.Order(false);
                estabelecimentoCriteriaTop.SetMaxResults(5);

                IguariaCriteria iguariaCriteriaTopRating = new IguariaCriteria();
                iguariaCriteriaTopRating.Rating_medio_iguaria.Order(false);
                iguariaCriteriaTopRating.SetMaxResults(5);

                IguariaCriteria iguariaCriteriaTop = new IguariaCriteria();
                iguariaCriteriaTop.Visual_iguaria.Order(false);
                iguariaCriteriaTop.SetMaxResults(5);

                Iguaria[] ratingIgu = Iguaria.ListIguariaByCriteria(iguariaCriteriaTopRating);
                Iguaria[] popIgu = Iguaria.ListIguariaByCriteria(iguariaCriteriaTop);

                Estabelecimento[] ratingEst = Estabelecimento.ListEstabelecimentoByCriteria(estabelecimentoCriteriaTopRating);
                Estabelecimento[] popEst = Estabelecimento.ListEstabelecimentoByCriteria(estabelecimentoCriteriaTop);

                /**
                 * NOTE: Cada lista de tendências está separada porque podem ter tamanhos diferentes conforme existência
                 *
                 */


                foreach (var item in ratingIgu)
                {
                    ratingIguarias.Add(item.Nome_iguaria);
                }


                foreach (var item in popIgu)
                {
                    popIguarias.Add(item.Nome_iguaria);
                }

                foreach (var item in ratingEst)
                {
                    ratingEstabelecimento.Add(item.Nome_estabelecimento);
                }

                foreach (var item in popEst)
                {
                    popEstabelecimento.Add(item.Nome_estabelecimento);
                }

                tendencias.Add(ratingIguarias);
                tendencias.Add(popIguarias);
                tendencias.Add(ratingEstabelecimento);
                tendencias.Add(popEstabelecimento);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                Console.ReadLine();


            }

            return tendencias;

        }

        public void ApagarConta()
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {

                ClienteCriteria clienteCriteria = new ClienteCriteria();
                clienteCriteria.Equals(_cliente.IdCliente);

                Cliente cli = clienteCriteria.UniqueCliente();

                cli.DeleteAndDissociate();
            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }
    }
}
