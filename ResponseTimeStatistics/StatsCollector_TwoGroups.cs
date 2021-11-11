using System;
using System.Collections.Generic;
using System.Text;

namespace ResponseTimeStatistics
{
    public class StatsCollector_TwoGroups
    {
        private List<int> smallerResponseTimes;
        private List<int> biggerResponseTimes;

        private double totalResponseTime;
        public StatsCollector_TwoGroups()
        {
            smallerResponseTimes = new List<int>();
            biggerResponseTimes = new List<int>();
            totalResponseTime = 0;
        }

        public void pushValue(int responseTimeMs)
        {
            if (responseTimeMs < 0 || responseTimeMs > 19000)
            {
                return;
            }

            if (smallerResponseTimes.Count > 0 && smallerResponseTimes[smallerResponseTimes.Count - 1] >= responseTimeMs)
            {
                AddNewNumber(smallerResponseTimes, responseTimeMs);
            }
            else
            {
                AddNewNumber(biggerResponseTimes, responseTimeMs);
            }


            if (smallerResponseTimes.Count - biggerResponseTimes.Count > 1)
            {
                AddNewNumber(biggerResponseTimes, smallerResponseTimes[smallerResponseTimes.Count - 1]);
                smallerResponseTimes.RemoveAt(smallerResponseTimes.Count - 1);
            }
            else if (smallerResponseTimes.Count - biggerResponseTimes.Count < -1)
            {
                AddNewNumber(smallerResponseTimes, biggerResponseTimes[0]);
                biggerResponseTimes.RemoveAt(0);
            }

            totalResponseTime += responseTimeMs;
        }

        public int getMedian()
        {
            if (smallerResponseTimes.Count - biggerResponseTimes.Count > 0)
            {
                return smallerResponseTimes[smallerResponseTimes.Count - 1];
            }
            else if (smallerResponseTimes.Count - biggerResponseTimes.Count < 0)
            {
                return biggerResponseTimes[0];
            }
            else if (smallerResponseTimes.Count > 0)
            {
                return (smallerResponseTimes[smallerResponseTimes.Count - 1] + biggerResponseTimes[0]) / 2;
            }
            else
            {
                return 0;
            }

        }

        public double getAverage()
        {
            double result = 0;

            int totalRecordNumber = smallerResponseTimes.Count + biggerResponseTimes.Count;

            if(totalRecordNumber > 0)
            {
                result = totalResponseTime / totalRecordNumber;
            }
            
            return result;
        }

        private void AddNewNumber(List<int> timeList, int newTime)
        {
            timeList.Add(newTime);

            int temp;
            int i = timeList.Count - 1;
            while(i > 0 && timeList[i] < timeList[i - 1])
            {
                temp = timeList[i];
                timeList[i] = timeList[i - 1];
                timeList[i - 1] = temp;
                i--;
            }
        }
    }
}