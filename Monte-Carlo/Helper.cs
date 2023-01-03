using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo
{
    class Helper
    {
        public static int FindMax(List<int[]> Plan)
        {
            int total = 0;
            foreach (int[] task in Plan)
            {
                total += task[2];
            }
            return total;
        }
        public static int FindMin(List<int[]> Plan)
        {
            int total = 0;
            foreach (int[] task in Plan)
            {
                total += task[0];
            }
            return total;
        }
        public static float[] CounterSimulate(List<int[]> Plan) //we will find average with simulate
        {
            Randomnumber randomizerPlan = new Randomnumber();
            int iterations = 10000;
            float[] Percenteges = new float[10];
            int min = Helper.FindMin(Plan);
            int max = Helper.FindMax(Plan);
            int percent10 = (max - min) / 10;
            int percent010=0, percent1020 = 0, percent2030 = 0, percent3040 = 0, percent4050 = 0, percent5060 = 0, percent6070 = 0, percent7080 = 0, percent8090 = 0, percent90100 = 0;

            for (int i = 0; i < iterations; i++)
            {
                long randomPlanCost = 0;
                foreach (int[] task in Plan)
                {
                    randomPlanCost += randomizerPlan.Next(task[0], task[2]);
                }
                if (min<= randomPlanCost && randomPlanCost < min + percent10)
                    percent010 += 1;
                else if (min + percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 2)
                    percent1020 += 1;
                else if (min + 2 * percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 3)
                    percent2030 += 1;
                else if (min + 3*percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 4)
                    percent3040 += 1;
                else if (min + 4 * percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 5)
                    percent4050 += 1;
                else if (min + 5*percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 6)
                    percent5060 += 1;
                else if (min + 6 * percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 7)
                    percent6070 += 1;
                else if (min + 7 * percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 8)
                    percent7080 += 1;
                else if (min + 8* percent10 <= randomPlanCost && randomPlanCost < min + percent10 * 9)
                    percent8090 += 1;
                else if (min + 9* percent10 <= randomPlanCost && randomPlanCost <= min + percent10 * 10)
                    percent90100 += 1;
            }
            Percenteges[0] = percent010/ 100;
            Percenteges[1] = percent1020 / 100;
            Percenteges[2] = percent2030 / 100;
            Percenteges[3] = percent3040 / 100;
            Percenteges[4] = percent4050 / 100;
            Percenteges[5] = percent5060 / 100;
            Percenteges[6] = percent6070 / 100;
            Percenteges[7] = percent7080 / 100;
            Percenteges[8] = percent8090 / 100;
            Percenteges[9] = percent90100 / 100;

            return Percenteges;
        }
    }
}
