using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Names
{
    public class SearchableNames
    {
        private void DoSomething()
        {
            double s = 0;
            List<int> t = new List<int>()
            {
                1,
                2,
                34,
                5,
                6,
                8
            };

            for (int i = 0; i < 34; i++)
            {
                s += (t[i] * 4) / 5;
            }
        }


        // To

        private void DoSomethingBetter()
        {
            const int WORK_DAYS_PER_WEEK = 5;
            const int NUMBER_OF_TASKS = 34;
            int realDaysPerIdealWeek = 4;
            int sum = 0;
            List<int> taskEstimates = new List<int>()
            {
                1,
                2,
                34,
                5,
                6,
                8
            };

            for (int i = 0; i < NUMBER_OF_TASKS; i++)
            {
                int realTaskDays = taskEstimates[i] * realDaysPerIdealWeek;
                int realTaskWeeks = realTaskDays / WORK_DAYS_PER_WEEK;
                sum += realTaskWeeks;
            }
        }
    }
}
