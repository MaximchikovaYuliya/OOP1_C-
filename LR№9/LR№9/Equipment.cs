using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    class Equipment
    {
        public bool Upgrated { set; get; }
        public bool TurnedOn { set; get; }
        public bool Broken { set; get; }

        public void OnUpgrate(string message, bool upgrated, bool turnedOn, bool broken)
        {
            Console.WriteLine("-----------Equipment------------");
            Upgrated = upgrated;
            TurnedOn = turnedOn;
            Broken = broken;
            Console.WriteLine(message);
        }

        public void OnTurnOn(string message, bool upgrated, bool turnedOn, bool broken)
        {
            Console.WriteLine("------------Equipment-----------");
            Upgrated = upgrated;
            TurnedOn = turnedOn;
            Broken = broken;
            Console.WriteLine(message);
        }

    }
}
