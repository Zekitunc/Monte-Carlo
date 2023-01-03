using System;
using System.Collections.Generic;

namespace Monte_Carlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter tasks in the following format: c1,c2...");
            Console.WriteLine("where cx is cost");
            Console.WriteLine("Type END to finish entering tasks");

            int countOfTasks = 1;
            List<int[]> Plan = new List<int[]>();

            while(true)
            {
                Console.Write("Task #{0}: ", countOfTasks);
                string inp = Console.ReadLine();
                if (inp == "END")
                    break;
                else
                {
                    int[] task = new int[3];
                    string var = "";
                    int count = 0;
                    for(int i =0;i<inp.Length;i++)
                    {                        
                        if (inp[i] !=',')
                        {
                            var += inp[i];
                        }
                        if(inp[i]==',' || i==inp.Length-1)
                        {
                            task[count] =Convert.ToInt32(var);
                            count++;
                            var = "";
                        }
                    }
                    Plan.Add(task);
                }
                countOfTasks++;
            }

            Console.WriteLine("After probing 10000 random plans, the result are:");
            Console.WriteLine("Minimum = {0} days", Helper.FindMin(Plan));
            Console.WriteLine("Maximum = {0} days", Helper.FindMax(Plan));
            Console.WriteLine("Average = {0} days", MonteCarlo.Simulate(Plan));

            float[] percenteges = new float[10];
            percenteges = Helper.CounterSimulate(Plan);
            int tenPercent = (Helper.FindMax(Plan) - Helper.FindMin(Plan)) / 10;
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan),percenteges[0]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+tenPercent, percenteges[1]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+2 * tenPercent, percenteges[2]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+3 * tenPercent, percenteges[3]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+4 * tenPercent, percenteges[4]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+5 * tenPercent, percenteges[5]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+6* tenPercent, percenteges[6]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+7 * tenPercent, percenteges[7]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+8* tenPercent, percenteges[8]);
            Console.WriteLine("{0} days : {1}%", Helper.FindMin(Plan)+9 * tenPercent, percenteges[9]);
        }
    }
}
