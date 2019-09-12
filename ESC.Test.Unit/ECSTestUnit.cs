using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NUnit.Framework;

namespace ESC.Test.Unit
{
    public class ECSTestUnit
    {
        public FakeHeater heater = new FakeHeater();
        public FakeTempSensor temp = new FakeTempSensor();
        private ECS.Legacy.ECS uut;

        [SetUp]
        public void Setup()
        {
            uut = new ECS.Legacy.ECS(45, heater, temp);
        }

        [Test]
        public void Temp_Equal_To_30()
        {
            temp.Temp = 30;
            Assert.That(uut.GetCurTemp().Equals(30));
        }

        [Test]
        public void Regulate_Below_Threshold_TurnOn_Called_Once()
        {
            temp.Temp = 15;
            uut.Regulate();
            Assert.That(heater.TurnOnCount.Equals(1));
        }

        [Test]
        public void Regulate_Above_Threshold_TurnOff_Called_Once()
        {
            temp.Temp = 46;
            uut.Regulate();
            Assert.That(heater.TurnOffCount.Equals(1));
        }
    }
}
