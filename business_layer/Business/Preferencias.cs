using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Preferencias
    {
        private byte _ordem_rating_iguaria;
        private byte _ordem_rating_estabelecimento;
        private byte _ordem_distancia;
        private byte _ordem_popularidade_iguaria;
        private byte _ordem_popularidade_estabelecimento;

        public Preferencias(byte _ordem_rating_iguaria, byte _ordem_rating_estabelecimento, byte _ordem_distancia, byte _ordem_popularidade_iguaria, byte _ordem_popularidade_estabelecimento)
        {
            _ordem_rating_iguaria = OrdemRatingIguaria;
            _ordem_rating_estabelecimento = OrdemRatingEstabelecimento;
            _ordem_distancia = OrdemDistancia;
            _ordem_popularidade_iguaria = OrdemPopularidadeIguaria;
            _ordem_popularidade_estabelecimento = OrdemPopularidadeEstabelecimento;
        }
        public Preferencias()
        {
            _ordem_rating_iguaria = 0;
            _ordem_rating_estabelecimento = 0;
            _ordem_distancia = 0;
            _ordem_popularidade_iguaria = 0;
            _ordem_popularidade_estabelecimento = 0;
        }
        public Preferencias(Preferencias _other)
        {
            _ordem_rating_iguaria = _other.OrdemRatingIguaria;
            _ordem_rating_estabelecimento = _other.OrdemRatingEstabelecimento;
            _ordem_distancia = _other.OrdemDistancia;
            _ordem_popularidade_iguaria = _other.OrdemPopularidadeIguaria;
            _ordem_popularidade_estabelecimento = _other.OrdemPopularidadeEstabelecimento;
        }

        public byte OrdemRatingIguaria
        {
            get
            {
                return _ordem_rating_iguaria;
            }
            set
            {
                _ordem_rating_iguaria = value;
            }
        }

        public byte OrdemRatingEstabelecimento
        {
            get
            {
                return _ordem_rating_estabelecimento;
            }
            set
            {
                _ordem_rating_estabelecimento = value;
            }
        }

        public byte OrdemDistancia
        {
            get
            {
                return _ordem_distancia;
            }
            set
            {
                _ordem_distancia = value;
            }
        }

        public byte OrdemPopularidadeIguaria
        {
            get
            {
                return _ordem_popularidade_iguaria;
            }
            set
            {
                _ordem_popularidade_iguaria = value;
            }
        }

        public byte OrdemPopularidadeEstabelecimento
        {
            get
            {
                return _ordem_popularidade_estabelecimento;
            }
            set
            {
                _ordem_popularidade_estabelecimento = value;
            }
        }

        public Preferencias Clone()
        {
            return new Preferencias(this);
        }
    }
}