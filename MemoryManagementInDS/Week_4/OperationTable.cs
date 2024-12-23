using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryManagementInDS.Week_4
{
    public class OperationTable<T>
    {
        public delegate T Operation(T a, T b);

        Operation op;
        private T[,] results;

        public OperationTable(List<T> rowValues, List<T> colValues, Operation operation)
        {
            if (rowValues == null || colValues == null)
                throw new ArgumentNullException("Row and column values cannot be null.");

            if (rowValues.Count == 0 || colValues.Count == 0)
                throw new ArgumentException("Row and column values cannot be empty.");

            op = operation ?? throw new ArgumentNullException(nameof(operation));
            results = new T[colValues.Count + 1, rowValues.Count + 1];

            // Fill operation results
            for (int row = 1; row <= colValues.Count; row++)
            {
                for (int col = 1; col <= rowValues.Count; col++)
                {
                    results[row, col] = op(rowValues[col - 1], colValues[row - 1]);
                }
            }

            // Fill headers
            for (int i = 1; i <= colValues.Count; i++) results[i, 0] = colValues[i - 1];
            for (int i = 1; i <= rowValues.Count; i++) results[0, i] = rowValues[i - 1];
        }

        public T[,] Results => (T[,])results.Clone();

        public override string ToString()
        {
            if (results == null || results.Length == 0)
                return "OperationTable is empty.";

            // Determine the maximum width of any cell
            int maxWidth = 0;
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int col = 0; col < results.GetLength(1); col++)
                {
                    string cell = results[row, col]?.ToString() ?? "null";
                    maxWidth = Math.Max(maxWidth, cell.Length);
                }
            }

            // Build the table string
            var sb = new StringBuilder();
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int col = 0; col < results.GetLength(1); col++)
                {
                    string cell = results[row, col]?.ToString() ?? "null";
                    sb.Append(cell.PadLeft(maxWidth, ' '));

                    if (col < results.GetLength(1) - 1) // Add a comma between columns, but not at the end
                        sb.Append(", ");
                }
                sb.AppendLine(); // Move to the next line after each row
            }

            return sb.ToString();
        }
    }

}


