using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class FactoryWorkerTests
    {
        [Test]
        public void Do()
        {
            IRobot robot = new Robot();
            Assert.NotNull(robot);

            Assert.NotNull(OperatorStore.Instance);
            Assert.NotNull(OperatorStore.Instance.Operators);
            foreach (var item in OperatorStore.Instance.Operators)
            {
                Assert.That(item.Do(robot));
            }
        }
    }
}
