using System;
using System.Text;

namespace MemoryManagementInDS
{
    internal class Week2
    {
        private const string MESSAGE = "hh";

        //1
        public static void MeasureStructMemory()
        {
            Week1.MeasureObjectSize(() => new PointStruct());
            //Week1.MeasureObjectSize(() => new PointClass());
        }

        //2
        public static void MeasureStringMemory()
        {
            Week1.MeasureObjectSize(() => new string(MESSAGE.ToCharArray()));

            long before = GC.GetAllocatedBytesForCurrentThread();
            string s = new string(MESSAGE.ToCharArray());
            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");

            //Empty string prints: 12Bytes
            //Length 1: 36Bytes
        }

        //3
        public static void TestStringBuilderMemory()
        {
          

            Week1.MeasureObjectSize(() =>
            {  
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        sb.Append($"{i * j} ");
                    }
                }
            });
        }

        public static void TestRegularStringMemory()
        {   
            Week1.MeasureObjectSize(() =>
            {
                String s = "";

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        s += $"{i * j} ";
                    }
                }
            });
        }

        //4
        public static void TestObjectGeneration()
        {
            PointClass p = new PointClass();
            Console.WriteLine(GC.GetGeneration(p));
            GC.Collect(0);
            Console.WriteLine(GC.GetGeneration(p));
            GC.Collect(1);
            Console.WriteLine(GC.GetGeneration(p));
        }

    }
}
