using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class MementoClass
    {
        private int life;
        private string weapon;

        public MementoClass(int life, string weapon)
        {
            this.life = life;
            this.weapon = weapon;
        }

        public int Life { get { return life; } }
        public string Weapon { get {  return weapon; } }
    }
}
