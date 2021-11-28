using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpentTKGame;

namespace UnitTestGame
{
    /// <summary>
    /// ����� ������������
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// ������������ ��������� ���� �������
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            PlayerProperities playerProperities = new PlayerProperities()
            {
                MinAngle = 10,
                MaxAngle = 30
            };
            playerProperities = new AngleDecorator(playerProperities);
            Assert.AreEqual(playerProperities.MinAngle, 0);
            Assert.AreEqual(playerProperities.MaxAngle, 89);
        }
        /// <summary>
        /// ������������ ������������� ���� �����
        /// </summary>
        [TestMethod]
        public void MyTestMethod2()
        {
            PlayerProperities playerProperities = new PlayerProperities()
            {
                MinForce = 10,
                MaxForce = 30
            };
            playerProperities = new ForceDecorator(playerProperities);
            Assert.AreEqual(playerProperities.MinForce, 5);
            Assert.AreEqual(playerProperities.MaxForce, 20);
        }
        /// <summary>
        /// ������������ ������������� ��������
        /// </summary>
        [TestMethod]
        public void MyTestMethod3()
        {
            PlayerProperities playerProperities = new PlayerProperities()
            {
                Speed = 7
            };
            playerProperities = new SpeedDecorator(playerProperities);
            Assert.AreEqual(playerProperities.Speed, 9);
        }
    }
}
