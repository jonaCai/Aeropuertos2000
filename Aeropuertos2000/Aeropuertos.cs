using System;

namespace Aeropuertos2000
{
    internal class Aeropuertos
    {
        private string codigo { get; set; }
        public static string[] Lista_aeropuertos= new string [30];
        public static int count=0;


        static public void agregar_nuevo()
        {
            string code;
            code = Validadores.ValtextoTresLetras("Ingrese el codigo del aeropuerto:  ");
            Aeropuertos aeropuerto = new Aeropuertos(code);
            
        }

        public Aeropuertos(string Code)
        {
            Codigo = Code;
            this[count] = Code;
            count += 1;
        }
        public string this[int index]
        {

            get { return Lista_aeropuertos[index]; }
            set { Lista_aeropuertos[index] = value; }
        }
          
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
    }
}