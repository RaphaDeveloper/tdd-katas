using ChristmasLights;
using NUnit.Framework.Internal;

namespace ChristmasLightsTests
{
    public class GridTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Be_Possible_To_Instantiate_A_Grid()
        {
            var grid = new Grid();

            grid.Should().NotBeNull();
        }

        [Test]
        public void All_Lights_Should_Start_Off()
        {
            var grid = new Grid();

            grid.LightIsOn(0, 0).Should().BeFalse();
            grid.LightIsOn(0, 1).Should().BeFalse();
            grid.LightIsOn(0, 2).Should().BeFalse();

            grid.LightIsOn(1, 0).Should().BeFalse();
            grid.LightIsOn(1, 1).Should().BeFalse();
            grid.LightIsOn(1, 2).Should().BeFalse();

            grid.LightIsOn(2, 0).Should().BeFalse();
            grid.LightIsOn(2, 1).Should().BeFalse();
            grid.LightIsOn(2, 2).Should().BeFalse();
        }

        #region Turn On

        [Test]
        public void Should_Be_Possible_To_Turn_On_A_Light()
        {
            var grid = new Grid();

            grid.TurnOn(0, 0);

            grid.LightIsOn(0, 0).Should().BeTrue();
        }

        [Test]
        public void Should_Be_Possible_To_Turn_On_All_Lights_At_Once()
        {
            var grid = new Grid();

            grid.TurnOn(0, 0, 2, 2);

            grid.LightIsOn(0, 0).Should().BeTrue();
            grid.LightIsOn(0, 1).Should().BeTrue();
            grid.LightIsOn(0, 2).Should().BeTrue();

            grid.LightIsOn(1, 0).Should().BeTrue();
            grid.LightIsOn(1, 1).Should().BeTrue();
            grid.LightIsOn(1, 2).Should().BeTrue();

            grid.LightIsOn(2, 0).Should().BeTrue();
            grid.LightIsOn(2, 1).Should().BeTrue();
            grid.LightIsOn(2, 2).Should().BeTrue();
        }

        [Test]
        public void Should_Be_Possible_To_Turn_On_Many_Lights_At_Once()
        {
            var grid = new Grid();

            grid.TurnOn(0, 1, 2, 1);

            grid.LightIsOn(0, 0).Should().BeFalse();
            grid.LightIsOn(0, 1).Should().BeTrue();
            grid.LightIsOn(0, 2).Should().BeFalse();

            grid.LightIsOn(1, 0).Should().BeFalse();
            grid.LightIsOn(1, 1).Should().BeTrue();
            grid.LightIsOn(1, 2).Should().BeFalse();

            grid.LightIsOn(2, 0).Should().BeFalse();
            grid.LightIsOn(2, 1).Should().BeTrue();
            grid.LightIsOn(2, 2).Should().BeFalse();
        }

        #endregion

        #region Turn Off

        [Test]
        public void Should_Be_Possible_To_Turn_Off_A_Light()
        {
            var grid = new Grid();
            grid.TurnOn(0, 0);

            grid.TurnOff(0, 0);

            grid.LightIsOn(0, 0).Should().BeFalse();
        }

        [Test]
        public void Should_Be_Possible_To_Turn_Off_All_Lights_At_Once()
        {
            Grid grid = new Grid();
            grid.TurnOn(0, 0, 2, 2);


            grid.TurnOff(0, 0, 2, 2);
            
            
            grid.LightIsOn(0, 0).Should().BeFalse();
            grid.LightIsOn(0, 1).Should().BeFalse();
            grid.LightIsOn(0, 2).Should().BeFalse();

            grid.LightIsOn(1, 0).Should().BeFalse();
            grid.LightIsOn(1, 1).Should().BeFalse();
            grid.LightIsOn(1, 2).Should().BeFalse();

            grid.LightIsOn(2, 0).Should().BeFalse();
            grid.LightIsOn(2, 1).Should().BeFalse();
            grid.LightIsOn(2, 2).Should().BeFalse();
        }

        [Test]
        public void Should_Be_Possible_To_Turn_Off_Many_Lights_At_Once()
        {
            Grid grid = new Grid();
            grid.TurnOn(0, 0, 2, 2);


            grid.TurnOff(0, 1, 2, 1);


            grid.LightIsOn(0, 0).Should().BeTrue();
            grid.LightIsOn(0, 1).Should().BeFalse();
            grid.LightIsOn(0, 2).Should().BeTrue();

            grid.LightIsOn(1, 0).Should().BeTrue();
            grid.LightIsOn(1, 1).Should().BeFalse();
            grid.LightIsOn(1, 2).Should().BeTrue();

            grid.LightIsOn(2, 0).Should().BeTrue();
            grid.LightIsOn(2, 1).Should().BeFalse();
            grid.LightIsOn(2, 2).Should().BeTrue();
        }

        #endregion

        #region Toggle

        [Test]
        public void When_Toggle_A_Light_Which_Was_Off_The_Light_Should_Be_On()
        {
            var grid = new Grid();

            grid.Toggle(0, 0);

            grid.LightIsOn(0, 0).Should().BeTrue();
        }

        [Test]
        public void When_Toggle_A_Light_Which_Was_On_The_Light_Should_Be_Off()
        {
            var grid = new Grid();
            grid.TurnOn(0, 0);

            grid.Toggle(0, 0);

            grid.LightIsOn(0, 0).Should().BeFalse();
        }

        [Test]
        public void Should_Be_Possible_To_Toggle_All_Lights_At_Once()
        {
            Grid grid = new Grid();

            
            grid.Toggle(0, 0, 2, 2);


            grid.LightIsOn(0, 0).Should().BeTrue();
            grid.LightIsOn(0, 1).Should().BeTrue();
            grid.LightIsOn(0, 2).Should().BeTrue();

            grid.LightIsOn(1, 0).Should().BeTrue();
            grid.LightIsOn(1, 1).Should().BeTrue();
            grid.LightIsOn(1, 2).Should().BeTrue();

            grid.LightIsOn(2, 0).Should().BeTrue();
            grid.LightIsOn(2, 1).Should().BeTrue();
            grid.LightIsOn(2, 2).Should().BeTrue();
        }

        [Test]
        public void Should_Be_Possible_To_Toggle_Many_Lights_At_Once()
        {
            Grid grid = new Grid();


            grid.Toggle(0, 1, 2, 1);


            grid.LightIsOn(0, 0).Should().BeFalse();
            grid.LightIsOn(0, 1).Should().BeTrue();
            grid.LightIsOn(0, 2).Should().BeFalse();

            grid.LightIsOn(1, 0).Should().BeFalse();
            grid.LightIsOn(1, 1).Should().BeTrue();
            grid.LightIsOn(1, 2).Should().BeFalse();

            grid.LightIsOn(2, 0).Should().BeFalse();
            grid.LightIsOn(2, 1).Should().BeTrue();
            grid.LightIsOn(2, 2).Should().BeFalse();
        }

        #endregion
    }
}