using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Morg : IMorgObserver, IMorgSubject
    {
        private const float MORG_SIZE = 1.0f;

        public IMovementBehavior movement;
        public IFeedingBehavior feeding;

        public string name;

        private Vector2 location; //(x,y)
        private Vector2 direction;
        private bool alive;
        private List<IMorgObserver> observers;

        private Morg prey;
        private HashSet<string> preyTypes;
        private string morgType;



        public Morg(string morgType, string name, Vector2 initalLocation, Vector2 initalDirection)
        {
            this.morgType = morgType;
            this.name = name;
            this.location = initalLocation;
            this.direction = initalDirection;
            this.alive = true;
            this.observers = new List<IMorgObserver>();
            this.prey = null;
            this.preyTypes = new HashSet<string>();

        }

        public void AddPreyType(string t)
        {
            preyTypes.Add(t);
        }

        public bool isAlive
        {
            get { return this.alive; }
        }

        public IMovementBehavior Movement
        {
            get { return movement; }
            set
            {
                movement = value;
            }
        }

        public void FindPrey(Morg[] PossiblePrey)
        {
            float minDist = float.MaxValue;
            if (prey == null)
            {

                foreach (Morg p in PossiblePrey)
                {
                    float dist = (p.location - location).Length();
                    if (p.isAlive && preyTypes.Contains(p.morgType) && dist < minDist)
                    {
                        minDist = dist;
                        prey = p;
                    }

                    else
                    {
                        Console.WriteLine("...No prey found..");
                    }

                }
                if (PossiblePrey[0] != this)
                {
                    prey = PossiblePrey[0];
                }
                else
                {
                    prey = PossiblePrey[1];
                }
                Console.WriteLine($"..Follwoing new prey {prey.name}...");
                prey.RegisterObserver(this);


            }
        }
        public void Move()
        {
            location = movement.Move(location, direction);
            //notify observers
            foreach (IMorgObserver observer in observers)
            {
                observer.ObservedMorgMoved(this);
            }
        }

        public IFeedingBehavior Feeding
        {
            get { return feeding; }
            set { feeding = value; }
        }


        public string Name
        {
            get { return name; }
        }

        public void ObservedMorgMoved(Morg observed)
        {
            //observors track
            direction = Vector2.Normalize(prey.location - location);
            Console.WriteLine($"..Predator {name} turned towards new prey {prey.name}...");


        }

        public void ObservedMorgDied(Morg observed)
        {
            Console.WriteLine($"...Predator {name} stopped following dead prey {prey.name}");
            //stop follwoing
            prey = null;
        }

        public void RegisterObserver(IMorgObserver Observer)
        {
            observers.Add(Observer);
        }

        public void UnregisterObserver(IMorgObserver Observer)
        {
            observers.Remove(Observer);
        }

        public bool DistanceToPrey()
        {
            if (prey == null)
            {
                throw new Exception("Cannot determine distance when one or more prey are null");
            }
            if (prey != null)
            {
                if ((prey.location - location).Length() <= MORG_SIZE)
                {
                    return true;
                }

            }

            return false;
        }

        public void EatPrey()
        {
            if (prey != null)
            {
                feeding.Feed(prey);

                //TO DO: prey dies
                prey.death();
            }
        }
        public void death()
        {
            Console.WriteLine($"...Predator {name} died...");
            alive = false;

            foreach (IMorgObserver observer in observers.ToArray())
            {
                observer.ObservedMorgDied(this);
            }

        }
    }
}
