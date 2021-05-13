using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoBolos.Dominio
{
    class Juego
    {

        private Jugador jugador1;
        private Jugador jugador2;

        //Se crea la lista de los lanzamientos
        private List<int[]> Lanzamientos = new List<int[]>();


        //Se crea el juego y se le envían los jugadores
        public Juego(String nombreJugador1, String nombreJugador2)
        {
            this.jugador1 = new Jugador(nombreJugador1);
            this.jugador2 = new Jugador(nombreJugador2);
        }

        public Jugador verJugador1()
        {
            return this.jugador1;
        }
        public Jugador verJugador2()
        {
            return this.jugador2;
        }

        //El método lanzar es el encargado del comportamiento del juego
        public void Lanzar()
        {
            int turno = 1;
            //Se repite los 10 turnos 
            while (!(turno > 10))
            {
                //Generamos un número random, entre 0 y 11, de esta manera incluimos el numero 10
                //Este random está encargado del puntaje que saca cada jugador en un lanzamiento
                Random generador = new Random();
                int PinosTirados = generador.Next(0, 11);
                //Envíamos los lanazamientso al jugador, enviamos el primer lanzamiento como pinos tirados y el segundo una resta entre 11 y pinos tirados para los puntos restantes 
                jugador1.agregarPunto(PinosTirados, generador.Next(0,11 - PinosTirados));

                //Generamos un random para el segundo jugador y se repite el proceso
                PinosTirados = generador.Next(0, 11);
                jugador2.agregarPunto(PinosTirados, generador.Next(0,11 - PinosTirados));
                turno++;
            }

        }

        //Sumatoria se encarga de la suma de puntos según las reglas del juego
        //Si un jugador saca 10 puntos en el primer lanzamiento,a la puntuacion de este turno se le suma lo que saque en el siguiente turno 
        public int[] sumatoriaPuntos(Jugador jugador)
        {
            int[] puntaje = new int[10];
            int PuntajeActual = 0;
            for(int i = 0; i < jugador.obtenerLanzamientos().Count; i+=2)
            {
                if(i < 16 && jugador.obtenerLanzamientos()[i] == 10 && jugador.obtenerLanzamientos()[i+2] == 10)
                {
                    PuntajeActual = jugador.obtenerLanzamientos()[i] + jugador.obtenerLanzamientos()[i + 2] + jugador.obtenerLanzamientos()[i + 4];   
                }
                else if(i < 15 && jugador.obtenerLanzamientos()[i] == 10 && jugador.obtenerLanzamientos()[i+2] != 10) 
                {
                    PuntajeActual = jugador.obtenerLanzamientos()[i] + jugador.obtenerLanzamientos()[i + 2] + jugador.obtenerLanzamientos()[i + 3];
                }
                else if(i > 11&& i < 8 &&jugador.obtenerLanzamientos()[i] == 10 && jugador.obtenerNombre()[i+2] == 10)
                {
                    PuntajeActual = jugador.obtenerLanzamientos()[i] + jugador.obtenerLanzamientos()[i + 2];
                }
                else if (i > 15 && i < 19 && jugador.obtenerLanzamientos()[i] == 10)
                {
                    PuntajeActual = jugador.obtenerLanzamientos()[i];
                }
                else
                {
                    PuntajeActual = jugador.obtenerLanzamientos()[i] + jugador.obtenerLanzamientos()[i + 1];
                }
                puntaje[i/2] = PuntajeActual; 

            }
            return puntaje;
        }
    }
}
