using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class OriginatorJugador
    {
        private int vidas {  get; set; }
        private string arma {  get; set; }
        private int monedas {  get; set; }
        public OriginatorJugador(int vidas)
        {
            this.vidas = vidas;
            arma = "No tiene arma";
            monedas = 0;
        }

        public void quitarVidas() 
        {
            vidas -= 5;
        }

        public void agarrarArma(string arma) 
        {
            this.arma = arma; 
        }

        public void recogerMonedas() 
        {
            monedas+= 8;
        }

        public void detallesJugador()
        {
            Console.WriteLine($"DETALLES DEL JUGADOR:\n - Vidas: {vidas}\n - Arma: {arma}\n - Monedas: {monedas}");
        }

        /////////////////////////////////////METODOS DEL PATRON MEMENTO///////////////////////////////////////////
        
        public MementoClass guardarEstado() 
        {
            MementoClass obj = new MementoClass(vidas,arma);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("----------ESTADO GUARDADO----------");
            Console.WriteLine("-----------------------------------");

            return obj;
        }

        public void restaurarEstado(MementoClass memento) 
        {
            vidas = memento.Life;
            arma = memento.Weapon;
            monedas = 0;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("---------ESTADO RESTAURADO---------");
            Console.WriteLine("-----------------------------------");

        }

        

    }
}
