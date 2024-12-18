using MemoryManagementInDS.Week_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace UnitTestProjectForOOPCourse
{
    [TestClass]
    public class OperationTableTest
    {
        [TestMethod]
        public void TestOperationClass()
        {
            List<int> row_values1 = new List<int>(); for (int i = 1; i <= 10; i++) { row_values1.Add(i); }
            List<int> col_values1 = new List<int>(); for (int i = 1; i <= 10; i++) { col_values1.Add(i); }
            OperationTable<int> t11 = new OperationTable<int>(row_values1, col_values1, (x, y) => x * y);
            Console.WriteLine(t11.ToString());

            List<double> row_values = new List<double>(); for (int i = 1; i <= 4; i++) { row_values.Add(1 / (double)i); }
            List<double> col_values = new List<double>(); for (int i = 1; i < 5; i++) { col_values.Add(1 / (double)i); }
            OperationTable<double> t1 = new OperationTable<double>(row_values, col_values, (x, y) => x + y);
            Console.WriteLine(t1.ToString());

            OperationTable<double> t31 = new OperationTable<double>(new List<double> { 1, 2, 3 }, new List<double> { 2, 2 }, (x, y) => x + y);
            Console.WriteLine(t31.ToString());
        }


        [TestMethod]
        public void TestMultiplicationTable()
        {
            // Arrange
            var rowValues = GenerateSequence(1, 10);
            var colValues = GenerateSequence(1, 10);
            var operation = new OperationTable<int>(rowValues, colValues, (x, y) => x * y);

            // Act
            string result = operation.ToString();

            // Assert (for demonstration; update as needed)
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestAdditionTableWithFractions()
        {
            // Arrange
            var rowValues = GenerateFractionSequence(1, 4);
            var colValues = GenerateFractionSequence(1, 4);
            var operation = new OperationTable<double>(rowValues, colValues, (x, y) => x + y);

            // Act
            string result = operation.ToString();

            // Assert (for demonstration; update as needed)
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestSmallAdditionTable()
        {
            // Arrange
            var rowValues = new List<double> { 1, 2, 3 };
            var colValues = new List<double> { 2, 2 };
            var operation = new OperationTable<double>(rowValues, colValues, (x, y) => x + y);

            // Act
            string result = operation.ToString();

            // Assert (for demonstration; update as needed)
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        // Helper methods
        private List<int> GenerateSequence(int start, int end)
        {
            var list = new List<int>();
            for (int i = start; i <= end; i++) list.Add(i);
            return list;
        }

        private List<double> GenerateFractionSequence(int start, int end)
        {
            var list = new List<double>();
            for (int i = start; i <= end; i++) list.Add(1.0 / i);
            return list;
        }
    }
}
