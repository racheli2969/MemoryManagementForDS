﻿using System;

namespace MemoryManagementInDS
{
    class Program
    {
        const int ARRAY_LENGTH = 1000;



        static void Main()
        {
            showStructAndClassSemantics();
            StackOverflowExperiment();
            measureDifferentTypes();
        }

        //1
        private static void showStructAndClassSemantics()
        {
            PointClass pointClass = new PointClass();
            pointClass.x = 3;
            pointClass.y = 4;

            PointClass pointClass1 = pointClass;
            pointClass1.x = 5;
            pointClass1.y = 6;
            Console.WriteLine(pointClass.ToString());//will print (5, 6)

            PointStruct pointStruct = new PointStruct();
            pointStruct.x = 7;
            pointStruct.y = 8;
            ModifyPointStruct(pointStruct);
            Console.WriteLine(pointStruct.ToString());//will print (7, 8)
        }

        //change struct
        static void ModifyPointStruct(PointStruct p)
        {
            p.x += 10;
            p.y += 20;
            Console.WriteLine($"In ModifyPoint: p.x={p.x} p.y={p.y}");
        }

        static int RecursiveMethod(int depth, int localArraySize)
        {
            byte[] localArray = new byte[localArraySize];
            Console.WriteLine($"Current depth: {depth}");

            try
            {
                return RecursiveMethod(depth + 1, localArraySize);
            }
            catch (StackOverflowException)
            {
                return depth;
            }
        }

        //2
        static void StackOverflowExperiment()
        {
            int[] arraySizes = { 100, 1000, 10000 };

            foreach (int size in arraySizes)
            {
                Console.WriteLine($"\nExperiment with local array size: {size} bytes");
                try
                {
                    int maxDepth = RecursiveMethod(0, size);
                    Console.WriteLine($"Maximum recursion depth: {maxDepth}");
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Stack overflow occurred!");
                }
            }
        }


        //3
        static void MeasureObjectSize(Action allocationAction)
        {
            //save current memory
            long beforeAllocation = GC.GetAllocatedBytesForCurrentThread();
            //allocate
            allocationAction();
            //get memory after allocation
            long afterAllocation = GC.GetAllocatedBytesForCurrentThread();
            //calculate
            Console.WriteLine($"Memory allocated: {afterAllocation - beforeAllocation} bytes");
        }


        static void measureDifferentTypes()
        {
            Console.WriteLine("Measuring int array:");
            MeasureObjectSize(() =>
            {
                int[] intArray = new int[ARRAY_LENGTH];
            });
            Console.WriteLine("Measuring double array:");
            MeasureObjectSize(() =>
            {
                double[] doubleArray = new double[ARRAY_LENGTH];
            });
            Console.WriteLine("Measuring string array:");
            MeasureObjectSize(() =>
            {
                string[] stringArray = new string[ARRAY_LENGTH];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    stringArray[i] = "example";
                }
            });
            Console.WriteLine("Measuring struct array:");
            MeasureObjectSize(() =>
            {
                PointStruct[] structArray = new PointStruct[ARRAY_LENGTH];
            });
            Console.WriteLine("Measuring class array:");
            MeasureObjectSize(() =>
            {
                PointClass[] classArray = new PointClass[ARRAY_LENGTH];
                for (int i = 0; i < classArray.Length; i++)
                {
                    classArray[i] = new PointClass();
                }
            });
        }

        struct PointStruct
        {
            public int x;
            public double y;
            public override string ToString() => $"({x}, {y})\n";
        }

        class PointClass
        {
            public int x;
            public double y;

            public override string ToString() => $"({x}, {y})\n";
        }
    }

}
