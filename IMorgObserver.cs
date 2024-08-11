using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal interface IMorgObserver
    {
        void ObservedMorgMoved(Morg observed);
        void ObservedMorgDied(Morg observed);


    }

    internal interface IMorgSubject
    {
        void RegisterObserver(IMorgObserver Observer);
        void UnregisterObserver(IMorgObserver Observer);
    }
}
