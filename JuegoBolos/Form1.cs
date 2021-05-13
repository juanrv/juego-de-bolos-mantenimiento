using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoBolos.Dominio;

namespace JuegoBolos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Inicia el juego
        private void BtnJugar_Click(object sender, EventArgs e)
        {
            if(TextJugador1.Text.Trim().Equals("") || TextJugador2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Por favor ingrese el nombre de los jugadores");
            }
            else
            {
                Juego Juego = new Juego(TextJugador1.Text, TextJugador2.Text);
                Juego.Lanzar();
                LlenarTablas(Juego);
            }
        }

        //Llenamos las tablas que muestran el puntaje de los jugadores
        private void LlenarTablas(Juego Juego)
        {
            //Obtenemos el puntaje de cada jugador
            int[] PuntajeJugador1 = Juego.sumatoriaPuntos(Juego.verJugador1());
            int[] PuntajeJugador2 = Juego.sumatoriaPuntos(Juego.verJugador2());
            //Array que guarda el total de puntaje del jugador 1 y 2
            int[] TotalJugadores = new int[2];
            for (int i = 0; i <= 18; i+=2)
            {
                //Vamos haciendo la suma de los puntajes de cada jugador y lo guardamos en total
                TotalJugadores[0] += PuntajeJugador1[i / 2];
                TotalJugadores[1] += PuntajeJugador2[i / 2];
                TablaJugador1.Rows.Add((i/2)+1, 1, Juego.verJugador1().obtenerLanzamientos()[i], PuntajeJugador1[(i/2)]);
                TablaJugador1.Rows.Add((i/2)+1, 2, Juego.verJugador1().obtenerLanzamientos()[i+1], PuntajeJugador1[(i/2)]);
                TablaJugador2.Rows.Add((i/2) + 1, 1, Juego.verJugador2().obtenerLanzamientos()[i], PuntajeJugador2[(i/2)]);
                TablaJugador2.Rows.Add((i / 2) + 1, 2, Juego.verJugador2().obtenerLanzamientos()[i + 1], PuntajeJugador2[(i / 2)]);
                
            }
            TablaJugador1.Rows.Add("-", "-", "-", TotalJugadores[0]);
            TablaJugador2.Rows.Add("-", "-", "-", TotalJugadores[1]);

            if (TotalJugadores[0] > TotalJugadores[1])
            {
                MessageBox.Show("El jugador: " + Juego.verJugador1().obtenerNombre() + Environment.NewLine + "¡HA GANADO!");
            }
            else
            {
                MessageBox.Show("El jugador: " + Juego.verJugador2().obtenerNombre() + Environment.NewLine + "¡HA GANADO!");

            }

        }

        //Limpieza de tablas y reseteo de los datos 
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TablaJugador1.Rows.Clear();
            TablaJugador2.Rows.Clear();
            TextJugador1.Clear();
            TextJugador2.Clear();
        }
    }
}
