using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Estabelecimento : Utilizador
    {
        private string _ambiente;
        private string _nome;
        private decimal _ratingMedio;
        private int _telefone;
        private int _totalVisualizacoes;
        private List<Horario> _horarios;
        private Dictionary<int, Iguaria> _iguarias;
        private Endereco _endereco;
        private int _id_estabelecimento;

        public Estabelecimento()
        {
            throw new System.Exception("Not implemented");
        }


        public Estabelecimento(string _email, string _password, byte _tipo, string _ambiente, string _nome, decimal _ratingMedio, int _telefone, int _totalVisualizacoes, List<Horario> _horarios,  Endereco _endereco, int _id_estabelecimento)
            : base(_email, _password, _tipo)
        {

            Ambiente = _ambiente;
            Nome = _nome;
            RatingMedio = _ratingMedio;
            Telefone = _telefone;
            TotalVisualizacoes = _totalVisualizacoes;
            Horarios = _horarios;
            _iguarias = new Dictionary<int, Iguaria>();
            Endereco = _endereco;
            IdEstabelecimento = _id_estabelecimento;
           
        }
        public Estabelecimento(Estabelecimento _other) : base(_other)
        {
            _ambiente = _other.Ambiente;
            _nome = _other.Nome;
            _ratingMedio = _other.RatingMedio;
            _telefone = _other.Telefone;
            _totalVisualizacoes = _other.TotalVisualizacoes;
            _horarios = _other.Horarios;
            _iguarias = _other.IguariasMap;
            _endereco = _other.Endereco;
            _id_estabelecimento = _other.IdEstabelecimento;

        }





        public string Nome
        {
            get
            {

                return _nome;
            }
            set
            {
                _nome = value;
            }
        }


        public string Ambiente
        {
            get
            {

                return _ambiente;
            }
            set
            {
                _ambiente = value;
            }
        }

        public decimal RatingMedio
        {
            get
            {

                return _ratingMedio;
            }
            set
            {
                _ratingMedio = value;
            }
        }

        public int Telefone
        {
            get
            {

                return _telefone;
            }
            set
            {
                _telefone = value;
            }
        }

        public int TotalVisualizacoes
        {
            get
            {

                return _totalVisualizacoes;
            }
            set
            {
                _totalVisualizacoes = value;
            }
        }

      

        public List<Horario> Horarios {

            get
            {
                List<Horario> tmp = new List<Horario>();

                foreach(Horario h in _horarios)
                {

                    tmp.Add(h.Clone());

                }


                return tmp; 
            }
            



           

            set
            {
                _horarios.Clear();
                foreach (Horario h in value)
                {

                    _horarios.Add(h.Clone());


                }
                
            }

        }

        public Dictionary<int, Iguaria> IguariasMap
        {
            get {

                Dictionary<int, Iguaria> tmp = new Dictionary<int, Iguaria>();



                foreach (KeyValuePair<int, Iguaria> entry in _iguarias)
                {
                    tmp.Add(entry.Key, entry.Value);
                }



                return tmp;


            } 
            set
            {

                foreach (KeyValuePair<int, Iguaria> entry in value)
                {
                    _iguarias.Add(entry.Key, entry.Value);
                }

               
            }
        }

        public Endereco Endereco
        {
            get
            {
                return _endereco.Clone();
            }
            set
            {
                _endereco = value.Clone();
            }
        }

        public int IdEstabelecimento
        {
            get
            {
                return _id_estabelecimento;
            }
            set
            {
                _id_estabelecimento = value;
            }
        }

        public Estabelecimento Clone()
        {
            return new Estabelecimento(this);
        }
    }
}