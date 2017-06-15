using Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace MM
{
    public class AreaEstabelecimento
    {
        private Business.Estabelecimento _estabelecimento;

        public string user { get { return _estabelecimento.Nome; } }

        public bool Login(string email, string password)
        {
            bool IsLoginValidated = false;


            UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();
            utilizadorCriteria.Email.Eq(email);
            utilizadorCriteria.Password.Eq(password);

            Utilizador ut = utilizadorCriteria.UniqueUtilizador();

            if (ut != null)
            {
                Estabelecimento es = ut.Estabelecimento;
                if (es != null)
                {
                    _estabelecimento.Email = ut.Email;
                    _estabelecimento.Password = ut.Password;
                    _estabelecimento.Tipo = ut.Tipo;
                    _estabelecimento.Ambiente = es.Desc_ambiente;
                    _estabelecimento.Endereco = new Business.Endereco(es.Cod_postal, es.Latitude, es.Localidade,
                                                                      es.Longitude, es.Numero, es.Rua);
                    _estabelecimento.IdEstabelecimento = es.Id_estabelecimento;
                    _estabelecimento.Horarios = new List<Business.Horario>();
                    _estabelecimento.IguariasMap = new Dictionary<int, Business.Iguaria>();
                    foreach (Iguaria i in es.iguaria.ToArray())
                    {
                        _estabelecimento.IguariasMap.Add(i.Id_iguaria, new Business.Iguaria(i.Nome_iguaria, i.Visual_iguaria,
                                                                                           i.Rating_medio_iguaria, i.Fotografia,
                                                                                           i.Preco, i.Id_iguaria, es.Id_estabelecimento));
                    }
                    foreach (HorarioEstabelecimento h in es.horarioEstabelecimento.ToArray())
                    {
                        _estabelecimento.Horarios.Add(new Business.Horario(h.Dia, h.Hora_abertura.TimeOfDay, h.Hora_fecho.TimeOfDay));
                    }
                    _estabelecimento.Nome = es.Nome_estabelecimento;
                    _estabelecimento.RatingMedio = es.Rating_medio_estabelecimento;
                    _estabelecimento.Telefone = es.Telefone;
                    _estabelecimento.TotalVisualizacoes = es.Visual_estabelecimento;
                    IsLoginValidated = true;
                }
            }

            return IsLoginValidated;
        }

        /**
         * 
         * Categorias têm que ser adicionadas por nós e apresentadas ao estabelecimento como opção
         * 
         */
        public void RegistarEstabelecimento(string _email, string _password, string _ambiente, string _nome, int _telefone, List<Business.Horario> _horarios, Business.Endereco _endereco, int _id_categoria)
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                Utilizador utilizador = Utilizador.CreateUtilizador();
                utilizador.Email = _email;
                utilizador.Password = _password;
                utilizador.Tipo = 1;
                utilizador.Save();


                /**
                 * Rating medio e visualizações têm valor por defeito
                 */
                Estabelecimento estabelecimento = Estabelecimento.CreateEstabelecimento();
                estabelecimento.Nome_estabelecimento = _nome;
                estabelecimento.Desc_ambiente = _ambiente;
                estabelecimento.Telefone = _telefone;
                estabelecimento.Latitude = _endereco.Latitude;
                estabelecimento.Longitude = _endereco.Longitude;
                estabelecimento.Rua = _endereco.Rua;
                estabelecimento.Numero = _endereco.Numero;
                estabelecimento.Localidade = _endereco.Localidade;
                estabelecimento.Cod_postal = _endereco.CodPostal;
                estabelecimento.Utilizador = utilizador;

                estabelecimento.Save();


                int i = 1;
                foreach (var item in _horarios)
                {
                    HorarioEstabelecimento horarioEstabelecimento = HorarioEstabelecimento.CreateHorarioEstabelecimento();
                    horarioEstabelecimento.Id_horario = i;
                    horarioEstabelecimento.Dia = (byte)item.Dia;
                    horarioEstabelecimento.Hora_abertura = new DateTime(0, 0, 0, item.HoraAbertura.Hours, item.HoraAbertura.Minutes, item.HoraAbertura.Seconds);
                    horarioEstabelecimento.Hora_abertura = new DateTime(0, 0, 0, item.HoraFecho.Hours, item.HoraFecho.Minutes, item.HoraFecho.Seconds);
                    horarioEstabelecimento.Estabelecimento = estabelecimento;
                    horarioEstabelecimento.Save();
                }



                CategoriaCriteria categoriaCriteria = new CategoriaCriteria();
                categoriaCriteria.Id_categoria.Eq(_id_categoria);

                Categoria categoria = categoriaCriteria.UniqueCategoria();

                estabelecimento.Categoria1 = categoria;

                categoria.Save();





                t.Commit();

            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void AtualizarEstabelecimento(string _password, string _ambiente, string _nome, int _telefone, List<Business.Horario> _horarios, Business.Endereco _endereco, int _id_categoria)
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {

                EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();

                estabelecimentoCriteria.Id_estabelecimento.Eq(_estabelecimento.IdEstabelecimento);
                Estabelecimento estabelecimento = estabelecimentoCriteria.UniqueEstabelecimento();

                estabelecimento.Nome_estabelecimento = _nome;
                estabelecimento.Desc_ambiente = _ambiente;
                estabelecimento.Telefone = _telefone;
                estabelecimento.Latitude = _endereco.Latitude;
                estabelecimento.Longitude = _endereco.Longitude;
                estabelecimento.Rua = _endereco.Rua;
                estabelecimento.Numero = _endereco.Numero;
                estabelecimento.Localidade = _endereco.Localidade;
                estabelecimento.Cod_postal = _endereco.CodPostal;



                UtilizadorCriteria utilizadorCriteria = new UtilizadorCriteria();

                utilizadorCriteria.Email.Eq(estabelecimento.Utilizador.Email);

                Utilizador utilizador = utilizadorCriteria.UniqueUtilizador();
                utilizador.Password = _password;



                utilizador.Password = _password;
                utilizador.Save();
                estabelecimento.Save();


                HorarioEstabelecimentoCriteria horarioEstabelecimentoCriteria = new HorarioEstabelecimentoCriteria();
                horarioEstabelecimentoCriteria.Estabelecimento_id_estabelecimento.Eq(estabelecimento.Id_estabelecimento);

                HorarioEstabelecimento[] horarioEstabelecimento = HorarioEstabelecimento.ListHorarioEstabelecimentoByCriteria(horarioEstabelecimentoCriteria);

                for (int i = 0; i < horarioEstabelecimento.Length; i++)
                {

                    horarioEstabelecimento[i].Dia = (byte)_horarios[i].Dia;
                    horarioEstabelecimento[i].Hora_abertura = new DateTime(0, 0, 0, _horarios[i].HoraAbertura.Hours, _horarios[i].HoraAbertura.Minutes, _horarios[i].HoraAbertura.Seconds);
                    horarioEstabelecimento[i].Hora_abertura = new DateTime(0, 0, 0, _horarios[i].HoraFecho.Hours, _horarios[i].HoraFecho.Minutes, _horarios[i].HoraFecho.Seconds);
                    horarioEstabelecimento[i].Save();
                }






                CategoriaCriteria categoriaCriteria = new CategoriaCriteria();
                categoriaCriteria.Id_categoria.Eq(_id_categoria);

                Categoria categoria = categoriaCriteria.UniqueCategoria();

                estabelecimento.Categoria1 = categoria;

                categoria.Save();





                t.Commit();

            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void RegistarEditarEmenta(Dictionary<int, Business.Iguaria> _iguarias)
        {

            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();

                estabelecimentoCriteria.Id_estabelecimento.Eq(_estabelecimento.IdEstabelecimento);
                Estabelecimento estabelecimento = estabelecimentoCriteria.UniqueEstabelecimento();

                IguariaCriteria itemp = new IguariaCriteria();
                itemp.Estabelecimento_id_estabelecimento.Eq(estabelecimento.Id_estabelecimento);

                int max_id = ((int)itemp.SetProjection(Projections.Max(Iguaria.PROP_ID_IGUARIA)).UniqueResult());




                foreach (KeyValuePair<int, Business.Iguaria> entry in _iguarias)
                    max_id = CRUDIguaria(estabelecimento, max_id, entry);

            }
            catch (Exception e)
            {
                t.RollBack();
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public void CarregarEmenta()
        {

            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {
                EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();

                estabelecimentoCriteria.Id_estabelecimento.Eq(_estabelecimento.IdEstabelecimento);
                Estabelecimento estabelecimento = estabelecimentoCriteria.UniqueEstabelecimento();

                IguariaCriteria itemp = new IguariaCriteria();
                itemp.Estabelecimento_id_estabelecimento.Eq(estabelecimento.Id_estabelecimento);

                Iguaria[] list = Iguaria.ListIguariaByCriteria(itemp);




                for (int i = 0; i < list.Length; i++)
                {
                    if (_estabelecimento.IguariasMap.ContainsKey(list[i].Id_iguaria))
                    {
                        Business.Iguaria iguaria = _estabelecimento.IguariasMap[list[i].Id_iguaria];
                        iguaria.Nome = list[i].Nome_iguaria;
                        iguaria.VisualizacoesIguaria = list[i].Visual_iguaria;
                        iguaria.RatingMedioIguaria = list[i].Rating_medio_iguaria;
                        iguaria.Fotografia = list[i].Fotografia;
                        iguaria.Preco = list[i].Preco;

                    }
                    else
                    {
                        _estabelecimento.IguariasMap.Add(list[i].Id_iguaria, new Business.Iguaria(list[i].Nome_iguaria, list[i].Visual_iguaria, list[i].Rating_medio_iguaria, list[i].Fotografia, list[i].Preco, list[i].Id_iguaria, list[i].Estabelecimento_id_estabelecimento));
                    }
                }




              



            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }


        private int CRUDIguaria(Estabelecimento estabelecimento, int max_id, KeyValuePair<int, Business.Iguaria> entry)
        {
            {

                Iguaria iguaria = null;
                IguariaCriteria iguariaCriteria = null;


                switch (entry.Value.CrudStatus)
                {
                    case Business.IguariaStatus.Default:
                        break;
                    case Business.IguariaStatus.ToInsert:
                        iguaria = Iguaria.CreateIguaria();
                        max_id++;
                        iguaria.Id_iguaria = max_id;
                        iguaria.Nome_iguaria = entry.Value.Nome;
                        iguaria.Fotografia = entry.Value.Fotografia;
                        iguaria.Preco = entry.Value.Preco;
                        iguaria.Estabelecimento = estabelecimento;
                        iguaria.Save();

                        break;
                    case Business.IguariaStatus.ToUpdate:
                        iguariaCriteria = new IguariaCriteria();
                        iguariaCriteria.Id_iguaria.Eq(entry.Value.IdIguaria);
                        iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(entry.Value.IdEstabelecimento);

                        iguaria = iguariaCriteria.UniqueIguaria();

                        iguaria.Nome_iguaria = entry.Value.Nome;
                        iguaria.Fotografia = entry.Value.Fotografia;
                        iguaria.Preco = entry.Value.Preco;

                        iguaria.Save();

                        break;
                    case Business.IguariaStatus.ToDelete:
                        iguariaCriteria = new IguariaCriteria();
                        iguariaCriteria.Id_iguaria.Eq(entry.Value.IdIguaria);
                        iguariaCriteria.Estabelecimento_id_estabelecimento.Eq(entry.Value.IdEstabelecimento);

                        iguaria = iguariaCriteria.UniqueIguaria();
                        iguaria.DeleteAndDissociate();

                        break;

                    default:
                        break;
                }


            }

            return max_id;
        }

        public void ApagarConta()
        {
            PersistentTransaction t = BasedeDadosMMPersistentManager.Instance().GetSession().BeginTransaction();
            try
            {

                EstabelecimentoCriteria estabelecimentoCriteria = new EstabelecimentoCriteria();

                estabelecimentoCriteria.Id_estabelecimento.Eq(_estabelecimento.IdEstabelecimento);
                Estabelecimento estabelecimento = estabelecimentoCriteria.UniqueEstabelecimento();
                estabelecimento.DeleteAndDissociate();
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