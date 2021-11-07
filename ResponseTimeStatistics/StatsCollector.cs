using System;

namespace ResponseTimeStatistics
{
    public class StatsCollector
    {

        /*
         * I put two assumptions here based on the exam info:
         * 1. All response time will be recorded as an integer with unit ms. 
         *    Which means we don't have any float number like 1.5 ms. 
         *    If we do need to handle float ms situation, we can put number into the bucket which equal to its roundup value.
         * 2. Since service will timeout if response time is longer than 19000ms, 
         *    the max number we could get from the data set should be 19000.
         *    
         * So instead of building a long list with billion items, which potential could 
         * cause memory outage issue plus performance issue, we use a bucket here 
         * to host how many times each response time happened. We will face a maximum of 19000 types of response time here. 
         */
        private double[] responseTimes = new double[19000];
        
        /*If we face more than 20,000 request per second, int is not enough to host the total number value.
         *This variable here is mainly for performance reason. We could dynamiclly calculate the total number.
         */
        private double totalRecordNumber;
        public StatsCollector()
        {
        }

        public void pushValue(int responseTimeMs)
        {
            if(responseTimeMs>=0 && responseTimeMs <= 19000)
            {
                responseTimes[responseTimeMs]++;
                totalRecordNumber++;
            }
        }

        public int getMedian()
        {
            double medianPosition = totalRecordNumber / 2;
            int index = 0;
            double currentPosition = responseTimes[index];

            while(currentPosition < medianPosition)
            {
                index++;
                currentPosition += responseTimes[index];
            }
            return index;
        }

        public double getAverage()
        {
            double result = 0;

            if (totalRecordNumber != 0)
            {
                double totalNumber = 0;
                for (int i = 0; i < responseTimes.Length; i++)
                {
                    totalNumber += responseTimes[i] * i;
                }
                result = totalNumber / totalRecordNumber;
            }

            return result;
        }
    }
}
