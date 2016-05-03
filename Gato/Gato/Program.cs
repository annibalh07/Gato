﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gato
{
    class Program
    {
        /*Inicio Declaración de variables globales*/
        

        /*Inicio Declaración de variables globales*/
        static void Main(string[] args)
        {
            
            jugador jugador1 = new jugador();
            jugador jugador2 = new jugador();
           

            instrucciones();
            Console.WriteLine("Escriba el nombre del jugador 1");
            jugador1.nombre = Console.ReadLine();
            Console.WriteLine("Escriba el nombre del jugador 2");
            jugador2.nombre = Console.ReadLine();
            Random r = new Random(DateTime.Now.Millisecond);
            int n = r.Next(0, 10);

            if (n > 5)
            {
                jugador1.caracter = "X";
                jugador2.caracter = "O";
            }
            else
            {
                jugador1.caracter = "O";
                jugador2.caracter = "X";
            }
            Console.WriteLine("---ASIGNACION---");
            Console.WriteLine(jugador1.nombre + ":" + jugador1.caracter);
            Console.WriteLine(jugador2.nombre + ":" + jugador2.caracter);
            Console.WriteLine("¡Preparando la partida!.........");
            System.Threading.Thread.Sleep(2000);
            ipartida(jugador1.nombre, jugador1.caracter, jugador2.nombre, jugador2.caracter);
       
        }

        static void instrucciones()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al juego del gato. A continuación dos jugadores deben de colocar un símbolo en el tablero uno a la vez, el jugador que logre completar una linea de tres simbolos completos ganará el juego, en caso que ninguno lo logre se considerará empate. El juego asigna aleatoriamente el simbolo para cada jugador.");
            tablero();
        }

        static void tablero()
        {
            int[] posiciones = new int [9];
            for (int x=0; x<=8; x++)
            {
                posiciones[x] = x+1;
            }
            //Console.WriteLine("\nLas casillas disponibles están marcadas con un número");
            Console.WriteLine("\n     "+posiciones[0]+ " | "+ posiciones[1]+"  | "+ posiciones[2]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + posiciones[3] + " | " + posiciones[4] + "  | " + posiciones[5]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + posiciones[6] + " | " + posiciones[7] + "  | " + posiciones[8]);

        }

        static void ipartida(string n1, string c1, string n2, string c2)
        {
            Console.Clear();
            jugador j1 = new jugador();
            jugador j2 = new jugador();
            tablero mytablero = new tablero();
            j1.nombre = n1;
            j1.caracter = c1;
            j2.nombre = n2;
            j2.caracter = c2;

            string spotition;
            string var="";
            int var2 = 0;
            int ipotition;
            int njugador = 1;
            bool ganador = true;

            
            while (ganador)
            {
                Console.Clear();
                formateador(mytablero.position);

                if (njugador == 1)
                {
                    
                    Console.Write(j1.nombre +  " selecciona una posición");
                    spotition = Console.ReadLine();
                    try
                    {
                        ipotition = Convert.ToInt16(spotition);
                        ipotition = ipotition - 1;
                        if(ipotition < 0 || ipotition > 8)
                        {
                            Console.WriteLine("La posicion no existe, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                        else if(String.IsNullOrEmpty(mytablero.position[ipotition])){
                            mytablero.position[ipotition] = j1.caracter;
                            var2 = var2 + 1;
                        }
                        else
                        {
                            Console.WriteLine("Posicion ocupada, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);
                           
                        }
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Posicion invalidad, turno perdido :(");
                    }                 
                   
                }
                if (njugador == 2)
                {

                    Console.Write(j2.nombre + " selecciona una posición");
                    spotition = Console.ReadLine();
                    try
                    {
                        ipotition = Convert.ToInt16(spotition);
                        ipotition = ipotition - 1;
                        if (ipotition < 0 || ipotition > 8)
                        {
                            Console.WriteLine("La posicion no existe, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                        else if (String.IsNullOrEmpty(mytablero.position[ipotition]))
                        {
                            mytablero.position[ipotition] = j2.caracter;
                            var2 = var2 + 1;
                        }
                        else
                        {
                            Console.WriteLine("Posicion ocupada, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Posicion invalidad, turno perdido :(");
                    }

                }

                var= validarganador(mytablero.position);
                if (var == "X")
                {
                    if (j1.caracter == "X")
                    {
                        Console.WriteLine("¡¡¡Felicidades "+ j1.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                    }
                    else
                    {
                        Console.WriteLine("¡¡¡Felicidades " + j2.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                    }
                    ganador = false;
                }

                if (var2 == 9)
                {
                    Console.WriteLine("Esta machaca fue empate!!!");
                    System.Threading.Thread.Sleep(6000);
                    ganador = false;
                }

                if (njugador == 1)
                {
                    njugador = 2;
                }
                else if (njugador == 2)
                {
                    njugador = 1;
                }
            }
           


        }


      static void formateador(string[] tab)
        {
            var nuevoTab = new string[tab.Length];
            tab.CopyTo(nuevoTab, 0);
            for (int i=0; i<=8; i++)
            {
                if (nuevoTab[i]== null)
                {
                    int x = i + 1;
                    nuevoTab[i]= Convert.ToString(x);
                }
            }
            Console.WriteLine("\n     " + nuevoTab[0] + " | " + nuevoTab[1] + "  | " + nuevoTab[2]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + nuevoTab[3] + " | " + nuevoTab[4] + "  | " + nuevoTab[5]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + nuevoTab[6] + " | " + nuevoTab[7] + "  | " + nuevoTab[8]);

            

        }


        static string validarganador(string[] array)
        {
            string ganador="";
            if(array[0]=="X" && array[1]=="X" && array[2]=="X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[1] == "O" && array[2] == "O")
            {
                ganador = "O";
            }
            else if (array[3] == "X" && array[4] == "X" && array[5] == "X")
            {
                ganador = "X";
            }
            else if (array[3] == "O" && array[4] == "O" && array[5] == "O")
            {
                ganador = "O";
            }
            else if (array[6] == "X" && array[7] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[6] == "O" && array[7] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[0] == "X" && array[3] == "X" && array[6] == "X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[3] == "O" && array[6] == "O")
            {
                ganador = "O|";
            }
            else if (array[1] == "X" && array[4] == "X" && array[7] == "X")
            {
                ganador = "X";
            }
            else if (array[1] == "O" && array[4] == "O" && array[7] == "O")
            {
                ganador = "O";
            }
            else if (array[2] == "X" && array[5] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[2] == "O" && array[5] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[0] == "X" && array[4] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[4] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[2] == "X" && array[4] == "X" && array[6] == "X")
            {
                ganador = "X";
            }
            else if (array[2] == "O" && array[4] == "O" && array[6] == "O")
            {
                ganador = "O";
            }
           
            
            return ganador;
        }
    }
}
