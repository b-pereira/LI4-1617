﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Iguaria
    {
        private string _nome;
        private int _visualizacoes;
        private decimal _rating_medio;
        private byte[] _fotografia;
        private decimal _preco;
        private int _id_iguaria;
        private int _id_estabelecimento;
        private List<Critica> _criticas;
        private IguariaStatus _crud_status;
       

        public Iguaria()
        {
            throw new System.Exception("Not implemented");
        }


        public Iguaria(string _nome, byte[] _fotografia, decimal _preco, int _id_iguaria, int _id_estabelecimento, IguariaStatus _status)
        {
            this._nome = _nome;
            this._visualizacoes = 0;
            this._rating_medio = 0;
            this._fotografia = _fotografia;
            this._preco = _preco;
            this._id_iguaria = _id_iguaria;
            this._id_estabelecimento = _id_estabelecimento;
            this._criticas = null;
            this._crud_status = _status;
        }


        public Iguaria(string _nome, int _visualizacoes, decimal _rating_medio, byte[] _fotografia, decimal _preco, int _id_iguaria, int _id_estabelecimento)
        {
            this._nome = _nome;
            this._visualizacoes = _visualizacoes;
            this._rating_medio = _rating_medio;
            this._fotografia = _fotografia;
            this._preco = _preco;
            this._id_iguaria = _id_iguaria;
            this._id_estabelecimento = _id_estabelecimento;
            this._criticas = null;
            this._crud_status = IguariaStatus.Default;
        }

        public Iguaria(string _nome, int _visualizacoes, decimal _rating_medio, byte[] _fotografia, decimal _preco, int _id_iguaria, int _id_estabelecimento, List<Critica> _criticas)
        {
            this._nome = _nome;
            this._visualizacoes = _visualizacoes;
            this._rating_medio = _rating_medio;
            this._fotografia = _fotografia;
            this._preco = _preco;
            this._id_iguaria = _id_iguaria;
            this._id_estabelecimento = _id_estabelecimento;
            this._criticas = _criticas;
            this._crud_status = IguariaStatus.Default;
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
            this._crud_status = _other.CrudStatus;
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

        public decimal RatingMedioIguaria
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

        public IguariaStatus CrudStatus
        {
            get
            {

                return _crud_status;

            }
            
            
            set
            {
                _crud_status = value;
            }
        }

        public Iguaria Clone()
        {
            return new Iguaria(this);
        }
    }
}