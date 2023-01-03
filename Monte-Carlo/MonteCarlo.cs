using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo
{
    class MonteCarlo
    {
        public static long Simulate(List<int[]> Plan) //we will find average with simulate
        {
            Randomnumber randomizerPlan = new Randomnumber();
            long totalCostOfRandomPlans = 0;
            long iterations = 1000;
            for(int i =0;i<iterations;i++)
            {
                long randomPlanCost = 0;
                foreach (int[] task in Plan)
                {
                    randomPlanCost += randomizerPlan.Next(task[0], task[2]);
                }
                totalCostOfRandomPlans += randomPlanCost;
            }
            return totalCostOfRandomPlans/iterations;
        }
    }
}
