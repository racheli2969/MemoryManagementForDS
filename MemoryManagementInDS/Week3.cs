using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagementInDS
{
    internal class Week3
    {

        public static void ProcessArray(int[] array, Action<int> processor)
        {
            foreach (int item in array)
            {
                processor(item);
            }
        }


        public class MaxCalculator
        {
            private int _max = int.MinValue;

            // Saves the max value
            public void UpdateMax(int number)
            {
                if (number > _max)
                {
                    _max = number;
                }
            }

            //Returns the max value
            public int GetMax()
            {
                return _max;
            }
        }

    }
}
