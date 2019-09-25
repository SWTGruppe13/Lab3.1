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
        public void Main()
        {

        }

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

        //[Test]
        //public void Temp_Equal_To_30()
        //{
        //    temp.Temp = 30;
        //    Assert.That(uut.GetCurTemp().Equals(30));
        //}

        //[Test]
        //public void Regulate_Below_Threshold_TurnOn_Called_Once()
        //{
        //    temp.Temp = 15;
        //    uut.Regulate();
        //    Assert.That(heater.TurnOnCount.Equals(1));
        //}

        //[Test]
        //public void Regulate_Above_Threshold_TurnOff_Called_Once()
        //{
        //    temp.Temp = 46;
        //    uut.Regulate();
        //    Assert.That(heater.TurnOffCount.Equals(1));
        //}
    }
}
