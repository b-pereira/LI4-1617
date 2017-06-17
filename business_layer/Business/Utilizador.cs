using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Utilizador
    {
        private string _email;
        private string _password;
        private byte _tipo;

        public Utilizador()
        {
            this._email = "";
            this._password = "";
            this._tipo = 0;
        }

        public Utilizador(string _email, string _password, byte _tipo)
        {
            this._email = Email;
            this._password = Password;
            this._tipo = Tipo;
        }
        public Utilizador(Utilizador _other)
        {
            _email = _other.Email;
            _password = _other.Password;
            _tipo = _other.Tipo;
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;

            }
            set
            {
                _password = value;
            }
        }

        public byte Tipo
        {
            get
            {

                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }


    }
}