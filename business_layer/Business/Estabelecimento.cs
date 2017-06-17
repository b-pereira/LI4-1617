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
        
        private int _id_categoria;
     

        public Estabelecimento()
         : base()
        {
            Ambiente = "";
            Nome ="";
            RatingMedio = 0;
            Telefone = 0;
            TotalVisualizacoes = 0;
            _horarios = new List<Horario>();
            _iguarias = new Dictionary<int, Iguaria>();
            Endereco = new Endereco();
            IdEstabelecimento = _id_estabelecimento;
            IdCategoria = _id_categoria;
        }

        public Estabelecimento(string _email, string _password, string _ambiente, string _nome,  int _telefone,  List<Horario> _horarios, Endereco _endereco, int _id_estabelecimento, int _id_categoria)
           : base(_email, _password, 1)
        {

            Ambiente = _ambiente;
            Nome = _nome;
            RatingMedio = 0;
            Telefone = _telefone;
            TotalVisualizacoes = 0;
            Horarios = _horarios;
            _iguarias = new Dictionary<int, Iguaria>();
            Endereco = _endereco;
            IdEstabelecimento = _id_estabelecimento;
            IdCategoria = _id_categoria;

        }

        public Estabelecimento(string _email, string _password, string _ambiente, string _nome, decimal _ratingMedio, int _telefone, 
            int _totalVisualizacoes, 
            List<Horario> _horarios,  
            Endereco _endereco, 
            int _id_estabelecimento, 
            int _id_categoria)
            : base(_email, _password, 1)
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
            IdCategoria = _id_categoria;
           
        }
      

        public Estabelecimento(string _email, string _password, string _ambiente, string _nome, int telefone, List<Horario> horarios, Endereco endereco, int categoria) 
            : base(_email, _password, 1)
        {
            IdEstabelecimento = 0;
            Ambiente = _ambiente;
            Nome = _nome;
            RatingMedio = 0;
            Telefone = _telefone;
            TotalVisualizacoes = 0;
            Horarios = _horarios;
            _iguarias = new Dictionary<int, Iguaria>();
            Endereco = _endereco;
            IdEstabelecimento = _id_estabelecimento;
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
               

                return _horarios; 
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

                
               
                return _iguarias;
            } 
            set
            {
               
                _iguarias.Clear();
                foreach (KeyValuePair<int, Iguaria> entry in value)
                {
                    _iguarias.Add(entry.Key, entry.Value.Clone());
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

        public int IdCategoria
        {
            get
            {
                return _id_categoria;
            }
            set
            {
                _id_categoria = value;
            }
        }

       
    }
}