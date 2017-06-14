using System;
using System.Collections.Generic;

using Orm;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using System.Collections;

public class AreaCliente
{
    private int IdClienteGobal; public AreaCliente(int cliente_id)
    {
        IdClienteGobal = cliente_id;

    }
    public void Login(string email, string password)
    {
        try
        {


            UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();
            utilizadorCriteria.Email.Eq(email);
            utilizadorCriteria.Password.Eq(password);

            Utilizador ut = utilizadorCriteria.UniqueUtilizador();

            if (ut == null)
            {

                Console.WriteLine("Email/Password errados!");
                return;
            }

            ut.Cliente.ToString();

            Console.WriteLine(" Cliente {0}", ut.Cliente.ToString());

        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            Console.ReadLine();
        }
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
        ;

        PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
        try
        {

            ClienteCriteria clienteCriteria = new ClienteCriteria();

            clienteCriteria.Id_cliente.Eq(IdClienteGobal);
            Cliente cliente = clienteCriteria.UniqueCliente();

            cliente.Nome_cliente = nome;


            UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();

            utilizadorCriteria.Email.Eq(cliente.Utilizador.Email);

            Utilizador utilizador = utilizadorCriteria.UniqueUtilizador();
            utilizador.Password = password;
            Console.WriteLine("Cliente -> {0}", cliente.ToString());
            Console.WriteLine("Cliente -> {0}", utilizador.ToString());

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

    public void ConsultarHistorico()
    {
        try
        {

            SelecaoIguariaCriteria selecaoIguariaCriteria = new SelecaoIguariaCriteria();
            selecaoIguariaCriteria.Cliente_Cliente.Eq(IdClienteGobal);
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
                Console.WriteLine("Histórico Iguaria {0} -> {1}", i, igs[i].ToString());
            }
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            Console.ReadLine();
        }
    }

    public void EscolherIguaria(int idIguaria, int idEstabelecimento)
    {

        PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
        try
        {
            ClienteCriteria clienteCriteria = new ClienteCriteria();
            clienteCriteria.Id_cliente.Eq(IdClienteGobal);

            Cliente cli = clienteCriteria.UniqueCliente();

            IguariaCriteria iguariaCriteria = new IguariaCriteria();
            iguariaCriteria.Id_iguaria.Eq(idIguaria);
            iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(idEstabelecimento);

            Iguaria ig = iguariaCriteria.UniqueIguaria();

            EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();
            estabelecimentoCriteria.Id_estabelecimento.Eq(idEstabelecimento);

            Estabelecimento est = estabelecimentoCriteria.UniqueEstabelecimento();


            Cliente_seleciona_EstabelecimentoCriteria cliente_seleciona_EstabelecimentoCriteria = new Cliente_seleciona_EstabelecimentoCriteria();
            cliente_seleciona_EstabelecimentoCriteria.Cliente_id_cliente.Eq(IdClienteGobal);
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
            cliente_seleciona_iguariaCriteria.Cliente_id_cliente.Eq(IdClienteGobal);
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

            Cliente_critica_Iguaria[] crits = Cliente_critica_Iguaria.ListCliente_critica_IguariaByCriteria(cliente_critica_IguariaCriteria); Console.WriteLine("Iguaria -> {0}", ig.ToString());
            Console.WriteLine("Estabelecimento -> {0}", est.ToString());
            Console.WriteLine("Categoria -> {0}", cat.ToString());
            Console.WriteLine("Horário {0} -> ", hor.ToString());

            for (int i = 0; i < crits.Length; i++)
            {
                Console.WriteLine("Critica {0} -> ", crits[i].Desc_critica);
            }
            ig.Save();
            est.Save(); t.Commit();
        }
        catch (Exception e)
        {
            t.RollBack();
            Console.WriteLine(e);
            Console.ReadLine();
        }        // NOTE : contrutor vazio não está implementado: há uma exceção se se usar

    }

    public void GerarPedido(string pedido)
    {
        try
        {

            ClienteCriteria cliC = new ClienteCriteria();
            cliC.Id_cliente.Eq(IdClienteGobal);

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


            for (int i = 0; i < igs.Length; i++)
            {


                iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(igs[i].Estabelecimento_id_estabelecimento);
                Console.WriteLine(" Iguaria {0} {1}", i, igs[i].Nome_iguaria);
            }



            Console.ReadLine();

        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            Console.ReadLine();
        }
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

            clienteCriteria.Id_cliente.Eq(IdClienteGobal);

            Cliente cli = clienteCriteria.UniqueCliente();
            byte _ordem_rating_iguaria = cli.Ord_rat_igu;
            byte _ordem_rating_estabelecimento = cli.Ord_rat_est;
            byte _ordem_distancia = cli.Ord_dist;
            byte _ordem_popularidade_iguaria = cli.Ord_pop_igu;
            byte _ordem_popularidade_estabelecimento = cli.Ord_rat_est;

            Console.WriteLine("Cliente {0} \n Prefs: {1} {2} {3} {4} {5}", cli.ToString(), _ordem_rating_iguaria, _ordem_rating_estabelecimento, _ordem_distancia, _ordem_popularidade_iguaria, _ordem_popularidade_iguaria);

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

            clienteCriteria.Id_cliente.Eq(IdClienteGobal);

            Cliente cli = clienteCriteria.UniqueCliente();

            cli.Ord_rat_igu = _ordem_rating_iguaria;
            cli.Ord_rat_est = _ordem_rating_estabelecimento;
            cli.Ord_dist = _ordem_distancia;
            cli.Ord_pop_igu = _ordem_popularidade_iguaria;
            cli.Ord_pop_est = _ordem_popularidade_estabelecimento;

            Console.WriteLine("Cliente {0}", cli.ToString());

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
    public void ListarTendencias()
    {

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

            Console.WriteLine(" ######### Igu. top rating ######### ");
            for (int i = 0; i < ratingIgu.Length; i++)
            {
                Console.WriteLine(" {0} ", ratingIgu[i].Nome_iguaria);
            }
            Console.WriteLine(" ######### Igu. mais pop #########   ");
            for (int i = 0; i < popIgu.Length; i++)
            {
                Console.WriteLine(" {0} ", popIgu[i].Nome_iguaria);
            }
            Console.WriteLine(" ######### Est. top rating ######### ");
            for (int i = 0; i < ratingEst.Length; i++)
            {
                Console.WriteLine(" {0} ", ratingEst[i].Nome_estabelecimento);
            }
            Console.WriteLine(" ######### Est. mais pop #########   ");
            for (int i = 0; i < popEst.Length; i++)
            {
                Console.WriteLine(" {0} ", popEst[i].Nome_estabelecimento);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            Console.ReadLine();


        }

    }

    public void ApagarConta()
    {
        PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
        try
        {

            ClienteCriteria clienteCriteria = new ClienteCriteria();
            clienteCriteria.Equals(IdClienteGobal);

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
