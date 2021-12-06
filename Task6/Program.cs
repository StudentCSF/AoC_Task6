using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task6(256, 6, 8);
        }

        static void Task6(int days, int stateOfReborn, int stateOfNewBorn)
        {
            long[] prodToTime = new long[days + 1];
            int sor = stateOfReborn + 1;
            int sonb = stateOfNewBorn + 1;
            int d = sor;
            for (; d <= sonb; d++)
            {
                prodToTime[d] = 1;
            }
            for (; d <= days; d++)
            {
                prodToTime[d] = 1 + prodToTime[d - sor] + prodToTime[d - sonb];
            }
            int maxPotentialInitState = stateOfReborn - 1;
            long[] productivity = new long[maxPotentialInitState];
            int i1 = days - 2;
            int i2 = i1 - (stateOfNewBorn - stateOfReborn);
            for (int i = 0; i < maxPotentialInitState; i++)
            {
                productivity[i] = 1 + prodToTime[i1 - i] + prodToTime[i2 - i];
            }
            string[] src = Console.ReadLine().Split(",");
            int[] initDaysCount = new int[maxPotentialInitState];
            foreach (string s in src)
            {
                initDaysCount[Convert.ToInt32(s) - 1]++;
            }
            long res = 0;
            for (int i = 0; i < maxPotentialInitState; i++)
            {
                res += initDaysCount[i] * (productivity[i] + 1);
            }
            Console.WriteLine(res);
        }
    }
}
