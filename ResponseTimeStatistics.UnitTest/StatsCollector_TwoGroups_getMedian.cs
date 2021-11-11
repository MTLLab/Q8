using NUnit.Framework;

namespace ResponseTimeStatistics.UnitTest
{
    public class StatsCollector_TwoGroups_getMedian
    {

        private StatsCollector_TwoGroups statsCollector;

        [SetUp]
        public void Setup()
        {
            statsCollector = new StatsCollector_TwoGroups();
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
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            Assert.AreEqual(statsCollector.getMedian(), 3);
        }

        [Test]
        public void getMedian_MultipleInput_IgnoreNegative_ReturnTheMedian()
        {
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

        [Test]
        public void getMedian_MultipleInput_EvenNumber_ReturnTheMedian()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            statsCollector.pushValue(1);
            statsCollector.pushValue(48);
            statsCollector.pushValue(31);
            statsCollector.pushValue(2000);
            Assert.AreEqual(statsCollector.getMedian(), 20);
        }

        [Test]
        public void getMedian_TwoInput_EvenNumber_ReturnTheMedian()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(9);
            Assert.AreEqual(statsCollector.getMedian(), 6);
        }

        [Test]
        public void getMedian_MultipleSameValueInput_EvenNumber_ReturnTheMedian()
        {
            statsCollector.pushValue(3);
            statsCollector.pushValue(3);
            statsCollector.pushValue(6);
            statsCollector.pushValue(6);
            statsCollector.pushValue(12);
            statsCollector.pushValue(17);
            Assert.AreEqual(statsCollector.getMedian(), 6);
        }
    }
}