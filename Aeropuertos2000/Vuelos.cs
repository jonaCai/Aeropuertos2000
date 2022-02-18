using System;

namespace Aeropuertos2000
{
    internal class Vuelos
    {
        private int codigo_vuelo { get; set; } 
        //dado que podemos tener dos vuelos con mismo origen y destino.
        //entonces tengo que asignar un codigo a una reserva hasta que se acabe y luego el otro.
        private string codigo_origen { get; set; }

        private string codigo_destino { get; set; }

        private bool disponible { get; set; }

        private int capacidad_max { get; set; }

        private int capacidad_reservada { get; set; }

        public static string[,] reg_vuelos= new string[30,6];
        public static int count=0;

        public static void ingresar_disponibles()
        {            
            string codigo_o;
            string codigo_d;
            int capacidad;
            bool flag= false;
            do
            {
                codigo_o = Validadores.ValtextoTresLetras("Ingrese el codigo del vuelo de origen: ");
                codigo_d = Validadores.ValtextoTresLetras("Ingrese el codigo del vuelo de destino: ");

                if (Validadores.ValidarCodigo(codigo_o))
                {
                    if (Validadores.ValidarCodigo(codigo_d))
                    {
                        flag = true;
                        capacidad= Validadores.validarint("Ingrese la capacidad total del vuelo de origen: ");
                        Vuelos vuelo_nuevo = new Vuelos(codigo_o, codigo_d, capacidad);
                        Console.WriteLine("Vuelo ingresado con exito.");

                    }else { Console.WriteLine("El codigo de destino no pertenece a ningun aeropuerto existente"); }
                }else { Console.WriteLine("El codigo de origen no pertenece a ningun aeropuerto existente"); }

            } while (flag == false);

            
        }

        public Vuelos(string code_o, string code_d, int capacidad)
        {
            disponible = true;
            Codigo_vuelo = count;
            Codigo_origen = code_o;
            Codigo_destino = code_d;
            Capacidad_max = capacidad;
            Capacidad_reservada = 0;
            reg_vuelos[count, 5] = codigo_vuelo.ToString();
            reg_vuelos[count, 0] = code_o;
            reg_vuelos[count, 1] = code_d;
            reg_vuelos[count, 2] = capacidad.ToString();
            reg_vuelos[count, 3] = Capacidad_reservada.ToString();
            reg_vuelos[count, 4] = disponible.ToString();
            
            count += 1;
        }

       
        public static bool exist_vuelo(string code_o, string code_d)
        {
            bool flag=false;
            int capacidad_disponible=0;
            for (int a = 0; a < count; ++a)
            {
                if (reg_vuelos[a, 0] == code_o && reg_vuelos[a, 1] == code_d)
                {
                    capacidad_disponible = int.Parse(reg_vuelos[a, 2]) - int.Parse(reg_vuelos[a, 3]);
                    Console.WriteLine($"N° vuelo: {reg_vuelos[a,5]}, Capacidad disponible: {capacidad_disponible}, Disponibilidad: {reg_vuelos[a,4]}.");
                    flag = true;
                }
            }

            return flag;
        }
        public static bool exist_num_vuelo(string num_vuelo)
        {
            bool flag = false;
            for (int a = 0; a < count; ++a)
            {
                if (reg_vuelos[a, 5] == num_vuelo)
                {
                    flag = true;
                }
            }

            return flag;
        }
        public static bool capacidad_ok(string num_vuelo,int sumcapacidad)
        {
            bool flag=false;
            int a = int.Parse(num_vuelo);
            if ((sumcapacidad + int.Parse(reg_vuelos[a, 3])) <= (int.Parse(reg_vuelos[a, 2])))
            {
                flag = true;
                
            }
            

            return flag;
        }

        public static void modificar_capacidad_reservada(string num_vuelo, int sumcapacidad)
        {
            int a = int.Parse(num_vuelo);
            reg_vuelos[a, 3] = (int.Parse(reg_vuelos[a, 3]) + sumcapacidad).ToString();

            if ((reg_vuelos[a, 3]) == (reg_vuelos[a, 2]))
            {
                reg_vuelos[a, 4] = "false";
            }


        }
        public int Codigo_vuelo
        {
            get { return codigo_vuelo; }
            set { codigo_vuelo = value; }
        }
        public string Codigo_origen
        {
            get { return codigo_origen; }
            set { codigo_origen = value; }
        }
        public string Codigo_destino
        {
            get { return codigo_destino; }
            set { codigo_destino = value; }
        }
        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public int Capacidad_max
        {
            get { return capacidad_max; }
            set { capacidad_max = value; }
        }
        public int Capacidad_reservada
        {
            get { return capacidad_reservada; }
            set { capacidad_reservada = value; }
        }
    }
}