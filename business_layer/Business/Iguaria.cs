using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Iguaria
    {
        private string _nome;
        private int _visualizacoes;
        private float _rating_medio;
        private byte[] _fotografia;
        private decimal _preco;
        private int _id_iguaria;
        private int _id_estabelecimento;
        private List<Critica> _criticas;

        public Iguaria()
        {
            throw new System.Exception("Not implemented");
        }


        public Iguaria(string _nome, int _visualizacoes, float _rating_medio, byte[] _fotografia, decimal _preco, int _id_iguaria, int _id_estabelecimento, List<Critica> _criticas)
        {
            this._nome = Nome;
            this._visualizacoes = VisualizacoesIguaria;
            this._rating_medio = RatingMedioIguaria;
            this._fotografia = Fotografia;
            this._preco = Preco;
            this._id_iguaria = IdIguaria;
            this._id_estabelecimento = IdEstabelecimento;
            this._criticas = ListaCriticas;
        }
        public Iguaria(Iguaria _other)
        {
            this._nome = _other.Nome;
            this._visualizacoes = _other.VisualizacoesIguaria;
            this._rating_medio = _other.RatingMedioIguaria;
            this._fotografia = _other.Fotografia;
            this._preco = _other.Preco;
            this._id_iguaria = _other.IdIguaria;
            this._id_estabelecimento = _other.IdEstabelecimento;
            this._criticas = _other.ListaCriticas;
        }

        public string Nome
        {
            get
            {

                return _nome;
            }
            set
            {
            }
        }

        public int VisualizacoesIguaria
        {
            get
            {

                return _visualizacoes;
            }
            set
            {
            }
        }

        public float RatingMedioIguaria
        {
            get
            {

                return _rating_medio;
            }
            set
            {
                _rating_medio = value;
            }
        }



        public decimal Preco
        {
            get
            {

                return _preco;
            }
            set
            {
            }
        }


        public byte[] Fotografia {



            get {

                byte[] tmp = new byte[_fotografia.Length];
                for (int i = 0; i < _fotografia.Length; i++)
                {
                    tmp[i] = _fotografia[i];
                }


                return tmp;


            }




            set {
                Array.Clear(_fotografia, 0, _fotografia.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    _fotografia[i] = value[i];
                }

                




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

        public int IdIguaria
        {
            get
            {

                return _id_iguaria;
            }
            set
            {
                _id_iguaria = value;
            }
        }

        public List<Critica> ListaCriticas
        {
            get {

                List<Critica> tmp = new List<Critica>();

                foreach (Critica c in _criticas)
                {
                    tmp.Add(c.Clone());
                }


               return tmp; 
        }
        
            set
            {
                _criticas.Clear();
                foreach (Critica c in value)
                {
                    _criticas.Add(c.Clone());
                }
                
            }
        }

        public Iguaria Clone()
        {
            return new Iguaria(this);
        }
    }
}