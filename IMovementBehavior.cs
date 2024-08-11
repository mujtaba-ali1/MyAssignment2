using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Assignment1
{
    internal interface IMovementBehavior
    {
        Vector2 Move(Vector2 currLocation, Vector2 currDirection);
    }

    class Ooze : IMovementBehavior
    {
        private float SPD = 0.3f;
        public Vector2 Move(Vector2 currLocation, Vector2 currDirection)
        {
            Vector2 newLocation = currLocation + SPD * currDirection;
            Console.WriteLine($"....Ozzing from ({currLocation.X}), {currLocation.Y} to ({newLocation.X}, {newLocation.Y})...");
            return newLocation;
        }

    }
    class Paddle : IMovementBehavior
    {
        private float SPD = 0.5f;
        public Vector2 Move(Vector2 currLocation, Vector2 currDirection)
        {
            Vector2 newLocation = currLocation + SPD * currDirection;
            Console.WriteLine($"....Paddling from ({currLocation.X}, {currLocation.Y}) to ({newLocation.X}, {newLocation.Y})...");
            return newLocation;
        }
    }
}

//    class Shuffle : IMovementBehavior
//    {
//    public Vector2 Move(Vector2 currLocation, Vector2 currDirection)
//        {
// Vector2 newLocation = currLocation + SPD * currDirection;

//            Console.WriteLine("...shuffling away!....");
//returun newLocation
//        }

//    }
//}
