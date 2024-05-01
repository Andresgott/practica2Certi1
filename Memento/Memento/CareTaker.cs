using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class CareTaker
    {
        private List<MementoClass> _guardados = new List<MementoClass>();

        public void addMemento(MementoClass m) 
        {
            _guardados.Add(m);
        }

        public void removeMemento(int indice) 
        {
            if (indice > _guardados.Count)
                Console.WriteLine($"El indice {indice} no existe en el arreglo");
            else
                _guardados.RemoveAt(indice);
        }

        public MementoClass obtenerMemento(int indice) 
        {
            Console.WriteLine("MEMENTO RESTAURADO");
            return _guardados[indice];
        }

        public void cantidadMementos() 
        {
            if (_guardados.Count == 0)
                Console.WriteLine("No se tienen mementos guardados");
            else 
            {
                Console.WriteLine($"Se tienen {_guardados.Count} mementos registrados");
                for(int i = 0; i < _guardados.Count;i++) 
                {
                    Console.WriteLine($"Detalles Memento {i}:\n - Vidas: {_guardados[i].Life}\n - Arma: {_guardados[i].Weapon}");
                }
            }
               
        }

    }
}
