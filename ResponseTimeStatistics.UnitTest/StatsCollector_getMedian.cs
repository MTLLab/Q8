using NUnit.Framework;

namespace ResponseTimeStatistics.UnitTest
{
    public class StatsCollector_getMedian
    {

        private StatsCollector statsCollector;

        [SetUp]
        public void Setup()
        {
            statsCollector = new StatsCollector();
        }

        [Test]
        public void getMedian_ZeroInput_ReturnZero()
        {
            Assert.AreEqual(statsCollector.getMedian(), 0);
        }

        [Test]
        public void getMedian_OneInput_ReturnTheExistOne()
        {
            statsCollector.pushValue(25);
            Assert.AreEqual(statsCollector.getMedian(), 25);
        }

        [Test]
        public void getMedian_MultipleInput_ReturnTheMedian()
        {
            //1, 3, 9, 31, 48, 2000, 14567
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(2000);
            Assert.AreEqual(statsCollector.getMedian(), 31);
        }

        [Test]
        public void getMedian_MultipleTheSameInput_ReturnTheMedian()
        {
            //1, 3, 9, 31, 48, 2000, 14567
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            Assert.AreEqual(statsCollector.getMedian(), 3);
        }

        [Test]
        public void getMedian_MultipleInput_IgnoreNegative_ReturnTheMedian()
        {
            //-12323, 1, 3, 9, 31, 48, 2000, 14567
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(2000);
            statsCollector.pushValue(-12323);
            Assert.AreEqual(statsCollector.getMedian(), 31);
        }

        [Test]
        public void getMedian_MultipleInput_IgnoreBiggerThan19000_ReturnTheMedian()
        {
            //1, 3, 9, 31, 48, 2000, 14567, 19001
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(14567);
            statsCollector.pushValue(31);
            statsCollector.pushValue(2000);
            statsCollector.pushValue(19001);
            Assert.AreEqual(statsCollector.getMedian(), 31);
        }
    }
}