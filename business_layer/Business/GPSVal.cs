using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public struct GPSVal
    {
        private int _latitude;
        private int _longitude;
        private static double MAJOR_AXIS_RADIO = 6378137;

        public GPSVal(int latitude, int longitude) :this()
        {
            Longitude = longitude;
        }

        public int Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
            }
        }

        public int Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
            }
        }

        

        public double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public double DistanceTo(int latitude, int longitude)
        {

            //if (latitude > 90 && latitude < -90)
            //    throw new CoordenadaInvalidaExc("Coordenada Invalida");
           // if (longitude > 180 && longitude < -180)
            //    throw new CoordenadaInvalidaExc("Coordenada Invalida");
        
        double LatB = ToRadians(latitude);
            double LngB = ToRadians(longitude);
            double LatA = ToRadians(Latitude);
            double LngA = ToRadians(Longitude);

            return MAJOR_AXIS_RADIO
                    * Math.Acos((Math.Cos(LatA) * Math.Cos(LatB)
                            * Math.Cos(LngB - LngA) + Math.Sin(LatA)
                            * Math.Sin(LatB)));
        }




    }
}