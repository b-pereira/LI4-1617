using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Horario
    {
        private Dias _dia;
        private TimeSpan _hora_abertura;
        private TimeSpan _hora_fecho;

        public Horario()
        {
            throw new System.Exception("Not implemented");
        }

        public Horario(byte _dia, TimeSpan _hora_abertura, TimeSpan _hora_fecho)
        {
           Dia = (Dias) _dia;
           HoraAbertura = _hora_abertura;
           HoraFecho =_hora_fecho;
        }
        public Horario(Horario _other)
        {
            this._dia = _other.Dia;
            this._hora_abertura = _other.HoraAbertura;
            this._hora_fecho = _other.HoraAbertura;
        }

        public Dias Dia
        {
            get
            {
                return _dia;
            }
            set
            {
                _dia = value;
            }
        }

        public TimeSpan HoraAbertura
        {
            get
            {
                return _hora_abertura;
            }
            set
            {
                _hora_abertura = value;
            }
        }

        public TimeSpan HoraFecho
        {
            get
            {
                return _hora_fecho;
            }
            set
            {
                _hora_fecho = value;
            }
        }

        public Horario Clone()
        {
            return new Horario(this);
        }
    }
}