using NUnit.Framework;

namespace ResponseTimeStatistics.UnitTest
{
    public class StatsCollector_Buckets_getAverage
    {

        private StatsCollector_Buckets statsCollector;

        [SetUp]
        public void Setup()
        {
            statsCollector = new StatsCollector_Buckets();
        }

        [Test]
        public void getAverage_ZeroInput_ReturnZero()
        {
            Assert.AreEqual(statsCollector.getAverage(), 0);
        }

        [Test]
        public void getAverage_OneInput_ReturnTheExistOne()
        {
            statsCollector.pushValue(25);
            Assert.AreEqual(statsCollector.getAverage(), 25);
        }

        [Test]
        public void getAverage_MultipleInput_ReturnTheAverage()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(1994);
            Assert.AreEqual(statsCollector.getAverage(), 2379);
        }

        [Test]
        public void getAverage_MultipleTheSameInput_ReturnTheAverage()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            Assert.AreEqual(statsCollector.getAverage(), 3);
        }

        [Test]
        public void getAverage_MultipleInput_IgnoreNegative_ReturnTheAverage()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(1994);
            statsCollector.pushValue(-12323);
            Assert.AreEqual(statsCollector.getAverage(), 2379);
        }

        [Test]
        public void getAverage_MultipleInput_IgnoreBiggerThan19000_ReturnTheAverage()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(1994);
            statsCollector.pushValue(19001);
            Assert.AreEqual(statsCollector.getAverage(), 2379);
        }
    }
}