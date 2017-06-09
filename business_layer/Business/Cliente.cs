using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Cliente : Utilizador
    {
        private int _id_cliente;
        private string _nome;
        private Preferencias _preferencias;

        public Cliente()
        {
            throw new System.Exception("Not implemented");
        }

        public Cliente(string _email, string _password, byte _tipo, string _nome, Preferencias _preferencias) : base(_email, _password, _tipo)
        {
            _id_cliente = 0;
            _nome = Nome;
            _preferencias = ListaPreferencias;
        }

        public Cliente(string _email, string _password, byte _tipo, int _id_cliente, string _nome, Preferencias _preferencias) : base(_email, _password, _tipo)
        {
            _id_cliente = IdCliente;
            _nome = Nome;
            _preferencias = ListaPreferencias;
        }

        public Cliente(string _email, string _password, byte _tipo, string _nome) : base(_email, _password, _tipo)
        {
            _id_cliente = IdCliente;
            _nome = Nome;
        }

        public Cliente(Cliente _other) : base(_other)
        {
            _id_cliente = _other.IdCliente;
            _nome = _other.Nome;
            _preferencias = _other.ListaPreferencias;
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

        public Preferencias ListaPreferencias
        {
            get { return _preferencias.Clone(); }
            set
            {
                _preferencias = value.Clone();
            }
        }

       

        public int IdCliente
        {
            get { return _id_cliente; }
            set
            {
                _id_cliente = value;
            }
        }

        public Cliente Clone()
        {
            return new Cliente(this);
        }
    }
}