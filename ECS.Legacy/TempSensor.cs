using System;

namespace ECS.Legacy
{
    internal class TempSensor : ITempSensor
    {
        readonly Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}