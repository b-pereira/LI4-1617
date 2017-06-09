using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Critica
    {
        private string _descricao;
        private DateTime _data;
        private float _rating;

        public Critica()
        {
            throw new System.NotImplementedException();
        }

        public Critica(string _descricao, DateTime _data, float _rating)
        {
            _descricao = DescricaoCritica;
            _data = DataCritica;
            _rating = RatingIguaria;
        }
        public Critica(Critica _other)
        {
            _descricao = _other.DescricaoCritica;
            _data = _other.DataCritica;
            _rating = _other.RatingIguaria;
        }

        public string DescricaoCritica
        {
            get
            {

                return _descricao;
            }
            set
            {

                _descricao = value;
            }
        }

        public DateTime DataCritica
        {
            get
            {

                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public float RatingIguaria
        {
            get
            {

                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        public Critica Clone()
        {
            return new Critica(this);
        }
    }
}