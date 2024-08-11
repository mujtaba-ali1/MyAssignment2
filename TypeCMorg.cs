using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Assignment1
{
    internal class TypeCMorg : Morg
    {
        public TypeCMorg(string name, Vector2 initalLocation, Vector2 initalDirection)
            : base("C", name, initalLocation, initalDirection)
        {
            movement = new Paddle();
            feeding = new Envenlope();

            AddPreyType("A");
            AddPreyType("B");
        }
    }
}
