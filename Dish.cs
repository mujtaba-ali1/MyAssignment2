using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Dish
    {
        public
        const float WIDTH = 50;
        public
        const float HEIGHT = 50;
        public List<Morg> morgs;

        public Dish()
        {
            morgs = new List<Morg>();
        }

        public void AddMorg()
        {
            Random r = new Random();
            morgs.Add(new TypeAMorg("Frank", RandomVector(r), RandomUnitVector(r)));
            morgs.Add(new TypeBMorg("Wade", RandomVector(r), RandomUnitVector(r)));
            morgs.Add(new TypeCMorg("Alice", RandomVector(r), RandomUnitVector(r)));
            morgs.Add(new TypeCMorg("Clarice", RandomVector(r), RandomUnitVector(r)));

        }

        private Vector2 RandomVector(Random r)
        {
            return new Vector2(((float)r.NextDouble() * WIDTH), (float)r.NextDouble() * HEIGHT);
        }

        private Vector2 RandomUnitVector(Random r)
        {
            Vector2 uv = RandomVector(r);
            return Vector2.Normalize(uv);
        }

        public List<Morg> GetMorgs()
        {

            return morgs;
        }

        public IEnumerable<Morg> Morgs
        {
            get
            {
                return morgs;
            }
        }

    }
}