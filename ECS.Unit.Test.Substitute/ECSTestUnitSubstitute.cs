using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit.Substitute
{
    public class ECSTestUnitSubstitute
    {

        public IHeater heater;
        public ITempSensor temp;
        private ECS.Legacy.ECS uut;

        [SetUp]
        public void Setup()
        {
            heater = NSubstitute.Substitute.For<IHeater>();
            temp = NSubstitute.Substitute.For<ITempSensor>();
            uut = new ECS.Legacy.ECS(45, heater, temp);
        }

        [Test]
        public void RunSelfTest_ReturnsFalse()
        {
            temp.RunSelfTest().Returns(false);
            heater.RunSelfTest().Returns(true);
            Assert.IsFalse(uut.RunSelfTest());
        }

        [Test]
        public void Temp_Equal_To_30()
        {
            temp.GetTemp().Returns(30);
            Assert.That(uut.GetCurTemp().Equals(30));
        }

        [Test]
        public void Regulate_Below_Threshold_TurnOn_Called_Once()
        {
            temp.GetTemp().Returns(15);
            uut.Regulate();
            heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_Above_Threshold_TurnOff_Called_Once()
        {
            temp.GetTemp().Returns(45);
            uut.Regulate();
            heater.Received(1).TurnOff();
        }
    }
}