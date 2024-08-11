using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class TypeAMorg : Morg
    {
        public TypeAMorg(string name, Vector2 initalLocation, Vector2 initalDirection)
          : base("A", name, initalLocation, initalDirection)
        {
            movement = new Paddle();
            feeding = new Absorb();
            AddPreyType("B");
            AddPreyType("C");
        }
    }
}
