using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public struct GPSVal
    {
        private decimal _latitude;
        private decimal _longitude;
        private static double MAJOR_AXIS_RADIO = 6378137;

        public GPSVal(decimal latitude, decimal longitude) :this()
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public decimal Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
            }
        }

        public decimal Latitude
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

        public decimal DistanceTo(double latitude, double longitude)
        {

            //if (latitude > 90 && latitude < -90)
            //    throw new CoordenadaInvalidaExc("Coordenada Invalida");
           // if (longitude > 180 && longitude < -180)
            //    throw new CoordenadaInvalidaExc("Coordenada Invalida");
        
            double LatB = ToRadians(latitude);
            double LngB = ToRadians(longitude);
            double LatA = ToRadians((double)Latitude);
            double LngA = ToRadians((double)Longitude);

            return (decimal)(MAJOR_AXIS_RADIO
                    * Math.Acos((Math.Cos(LatA) * Math.Cos(LatB)
                            * Math.Cos(LngB - LngA) + Math.Sin(LatA)
                            * Math.Sin(LatB))));
        }

        public String ConvertLongitude(double coordinate)
        {
            coordinate = Math.Abs(coordinate);
            String cardinal;
            int deg = (int)Math.Floor(coordinate);
            float min = (float)((coordinate - deg) * 60);
            float sec = (float)((min - Math.Floor(min)) * 60);
            if (deg < 0)
                cardinal = "E";
            else if (deg > 0)
                cardinal = "W";
            else
                cardinal = "";
            return deg + "°" + ((int)min) + "'" + sec.ToString("0.########") + "\"" + cardinal;

        }

        public String ConvertLatitude(double coordinate)
        {
            coordinate = Math.Abs(coordinate);
            
            String cardinal;
            int deg = (int)Math.Floor(coordinate);
            float min = (float)((coordinate - deg) * 60);
            float sec = (float)((min - Math.Floor(min)) * 60);
            if (deg < 0)
                cardinal = "S";
            else if (deg > 0)
                cardinal = "N";
            else
                cardinal = "";
            return deg + "°" + ((int)min) + "'" + sec.ToString("0.########") + "\"" + cardinal;

        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("Latitude : ").Append(ConvertLatitude((double)Latitude)).AppendLine();
            sb.Append("Longitude: ").Append(ConvertLongitude((double)Longitude)).AppendLine();
          
        

            return sb.ToString();
        }




    }
}