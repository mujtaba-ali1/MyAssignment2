using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal interface IFeedingBehavior
    {
        void Feed(Morg prey);
    }
    class Envenlope : IFeedingBehavior
    {
        public void Feed(Morg prey)
        {
            Console.WriteLine($"...Enveloping  {prey.name}!...");
        }
    }

    class Absorb : IFeedingBehavior
    {
        public void Feed(Morg prey)
        {
            Console.WriteLine($"...Squeezing {prey.name}!...");

        }
    }

}
