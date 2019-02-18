using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    public delegate void EventHandler(string message, bool upgrated = false, bool turnedOn = false, bool broken = false);

    public class Boss
    {
        public event EventHandler Upgrade;
        public event EventHandler TurnOn;

        public void ToUpgrate()
        {
            Upgrade?.Invoke("Upgrading.", true);
        }

        public void ToTurnOn(int voltage)
        {
            if (voltage < 100)
                TurnOn?.Invoke("Turning on.", turnedOn: true);
            else
                TurnOn?.Invoke("Broken.", broken: true);
        }

    }
}
