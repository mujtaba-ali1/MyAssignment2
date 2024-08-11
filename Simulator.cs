using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Simulator
    {
        readonly int RUN_TIME = 1000;

        List<Morg> morgs;
        readonly Dish d = new Dish();


        public Simulator()
        {

        }

        public void Initialize()
        {
            d.AddMorg();
            morgs = d.GetMorgs();
        }

        private class TestObserver : IMorgObserver
        {
            public void ObservedMorgDied(Morg observed)
            {
                Console.WriteLine($"Test: Morg {observed.name} died");
            }

            public void ObservedMorgMoved(Morg observed)
            {
                Console.WriteLine($"Test: Morg {observed.name} has moved!");
            }
        }
        public void Run()
        {

            for (int t = 0; t < RUN_TIME; t++)
            {
                foreach (Morg m in d.GetMorgs())
                {
                    if (m.isAlive)
                    {

                        //search for new prey
                        Console.WriteLine($"\nMorg {m.name}...");
                        m.FindPrey(d.GetMorgs().ToArray());
                        if (m.DistanceToPrey())

                        {
                            m.EatPrey();
                            return;
                        }

                        m.Move();
                    }

                }

            }
        }
       


    }
}
