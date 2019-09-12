using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
    public class FakeHeater : IHeater
    {
        public int TurnOnCount { get; private set; }

        public int TurnOffCount { get; private set; }

        public void TurnOn()
        {
            TurnOnCount++;
        }

        public void TurnOff()
        {
            TurnOffCount++;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
