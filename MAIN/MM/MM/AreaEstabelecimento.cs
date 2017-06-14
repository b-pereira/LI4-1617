using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        _estabelecimento.IguariasMap.Add(i.Id_iguaria,new Business.Iguaria(i.Nome_iguaria,i.Visual_iguaria,
                                                                                           i.Rating_medio_iguaria,i.Fotografia,
                                                                                           i.Preco,i.Id_iguaria,es.Id_estabelecimento));
                    }
                    foreach (HorarioEstabelecimento h in es.horarioEstabelecimento.ToArray())
                    {
                        _estabelecimento.Horarios.Add(new Business.Horario(h.Dia,h.Hora_abertura.TimeOfDay,h.Hora_fecho.TimeOfDay));
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

        public void RegistarEstabelecimento()
        {
            throw new System.NotImplementedException();
        }

        public void AtualizarEstabelecimento()
        {
            throw new System.NotImplementedException();
        }

        public void RegistarEmenta()
        {
            throw new System.NotImplementedException();
        }

        public void EditarEmenta()
        {
            throw new System.NotImplementedException();
        }

        public void ApagarConta()
        {
            throw new System.NotImplementedException();
        }
    }
}