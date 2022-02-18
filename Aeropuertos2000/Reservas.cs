using System;

namespace Aeropuertos2000
{
    internal class Reservas
    {
        private int numero_reserva { get; set; }
        private string codigo_o { get; set; }
        private string codigo_d { get; set; }
        private string num_vuelo { get; set; }
        private int pasajeros_adultos { get; set; }
        private int pasajeros_menores  { get; set; }
        private int pasajeros_infantes { get; set; }
        private static string [,] matriz_reservas=new string[30,7];
        private static int count=0;
        public static void ingresar_reserva()
        {
            int num_res;
            string cod_o;
            string cod_d;
            int adultos;
            int menores;
            int infantes;
            int total_personas;
            string num_vuelo="";
           
                num_res = Validadores.ValidarCodigo("Ingrese el codigo de reserva: ", "El numero de reserva ingresado ya existe, ingrese otro.");
                cod_o = Validadores.ValtextoTresLetras("Ingrese el codigo de origen: ");
                cod_d = Validadores.ValtextoTresLetras("Ingrese el codigo de destino: ");
                adultos = Validadores.validarintpositivo("Ingrese el numero de adultos de la reserva: ","Debe haber por lo menos un adulto en la reserva.");
                menores = Validadores.validarint("Ingrese el numero de menores de la reserva: ");
                infantes = Validadores.validarint("Ingrese el numero de infantes de la reserva: ");
                total_personas = adultos + menores + infantes;
                Console.WriteLine("Procesando reserva...");
                Console.WriteLine("Vuelos disponibles: ");


            if (Vuelos.exist_vuelo(cod_o, cod_d))
            {
                num_vuelo = Validadores.Valtexto("Elija un numero de vuelo: ");
                if (Vuelos.exist_num_vuelo(num_vuelo))
                {
                    if (Vuelos.capacidad_ok(num_vuelo, total_personas))
                    {
                        Reservas nueva_reserva = new Reservas(num_res, cod_o, cod_d, adultos, menores, infantes, num_vuelo);

                    }
                    else { Console.WriteLine("Capacidad maxima de pasajeros por vuelo sobrepasada."); }

                }else { Console.WriteLine("N° de vuelo inexsistente."); }
                

            }else { Console.WriteLine("El vuelo con dicho origen y destino no existe."); }



                
                           

        }
        public Reservas(int num_res, string cod_o, string cod_d, int adultos, int menores, int infantes, string num_vuelo)
        {
            int sum_pasajeros;
            numero_reserva = num_res;
            Codigo_o = cod_o;
            Codigo_d = cod_d;
            pasajeros_adultos = adultos;
            pasajeros_infantes = infantes;
            pasajeros_menores = menores;
            this.num_vuelo = num_vuelo;
            //en ingresar_reserva ya tendria que haber chequeado el espacio disponible.
            //de igual manera voy a poner dicha restriccion aca tambien.

            sum_pasajeros = adultos + infantes + menores;
            
                Vuelos.modificar_capacidad_reservada(num_vuelo, sum_pasajeros);
                //agregamos a la matriz las reservas
                
                matriz_reservas[count, 0] = num_res.ToString();
                matriz_reservas[count, 1] = cod_o;
                matriz_reservas[count, 2] = cod_d;
                matriz_reservas[count, 3] = adultos.ToString();
                matriz_reservas[count, 4] = menores.ToString();
                matriz_reservas[count, 5] = infantes.ToString();
                matriz_reservas[count, 6] = num_vuelo;

            count += 1;
            

        }

        public static void Mostrar()
        {
            Console.WriteLine("Reservas asignadas: ");
            for (int a=0; a<count;++a)
            {
                Console.WriteLine($"Numero reserva: {matriz_reservas[a,0]}, Numero vuelo: {matriz_reservas[a,6]}, Codigo de origen: {matriz_reservas[a,1]}, Codigo de destino: {matriz_reservas[a,2]} .");

            }
        }
        public static bool exist_num_reserva(string num_res)
        {
            bool flag = false;
            for (int a = 0; a < count; ++a)
            {
                if (matriz_reservas[a,0] == num_res)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public int Numero_reserva
        {
            get { return numero_reserva; }
            set { numero_reserva = value; }
        }
        public string Codigo_o
        {
            get { return codigo_o; }
            set { codigo_o = value; }
        }
        public string Codigo_d
        {
            get { return codigo_d; }
            set { codigo_d = value; }
        }
        public int Pasajeros_adultos
        {
            get { return pasajeros_adultos; }
            set { pasajeros_adultos = value; }
        }
        public int Pasajeros_menores
        {
            get { return pasajeros_menores; }
            set { pasajeros_menores = value; }
        }
        public int Pasajeros_infantes
        {
            get { return pasajeros_infantes; }
            set { pasajeros_infantes = value; }
        }
    }
}