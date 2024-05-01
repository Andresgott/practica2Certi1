using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CareTaker miCareTaker = new CareTaker();

            OriginatorJugador miJugador = new OriginatorJugador(30);
            miJugador.detallesJugador();

            Console.WriteLine("JUGANDO...");
            miJugador.quitarVidas();
            miJugador.quitarVidas();
            miJugador.recogerMonedas();
            miJugador.agarrarArma("Espada");
            miJugador.detallesJugador();

            miCareTaker.addMemento(miJugador.guardarEstado());
            miCareTaker.cantidadMementos();

            miJugador.quitarVidas();
            miJugador.recogerMonedas();
            miJugador.agarrarArma("Lanza");
            miJugador.quitarVidas();
            miJugador.detallesJugador();

            miCareTaker.addMemento(miJugador.guardarEstado());
            miCareTaker.cantidadMementos();

            miJugador.quitarVidas();
            miJugador.recogerMonedas();
            miJugador.detallesJugador();

            miCareTaker.addMemento(miJugador.guardarEstado());
            miCareTaker.cantidadMementos();

            miJugador.restaurarEstado(miCareTaker.obtenerMemento(2));
            miJugador.detallesJugador();

        }
    }
}
