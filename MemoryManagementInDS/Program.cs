using System;
using System.Collections.Generic;

namespace MemoryManagementInDS
{
    class Program
    {
        static void Main()
        {
            /*
            Week1.ShowStructAndClassSemantics();
            Week1.StackOverflowExperiment();
            Week1.MeasureDifferentTypes();
            */

            /* Week2.MeasureStructMemory();
             Week2.MeasureStringMemory();
             Week2.TestStringBuilderMemory();
             Week2.TestRegularStringMemory();
             Week2.TestObjectGeneration();*/


            /* int[] array = { 5, 3, 9, 1, 6 };
             Week3.MaxCalculator maxCalculator = new Week3.MaxCalculator();
             Action<int> maxDelegate = maxCalculator.UpdateMax; 
             Week3.ProcessArray(array, maxDelegate);
             Console.WriteLine($"Max of array: {maxCalculator.GetMax()}");*/

            //Week5
            List<Week5.Fraction> arr = new List<Week5.Fraction>();
            for(int i = 0; i < 12; i++)
            {
                arr.Add(new Week5.Fraction(i + 1, 12));
            }
            Week_4.OperationTable<Week5.Fraction> operationTable = new Week_4.OperationTable<Week5.Fraction>(arr, arr, (x,y)=>x+y);
            Console.WriteLine(operationTable.ToString());

        }

    }

}
