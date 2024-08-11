using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class TypeBMorg : Morg
    {
        public TypeBMorg(string name, Vector2 initalLocation, Vector2 initalDirection)
            : base("B", name, initalLocation, initalDirection)
        {
            movement = new Ooze();
            feeding = new Envenlope();

            AddPreyType("A");

        }
    }
}
