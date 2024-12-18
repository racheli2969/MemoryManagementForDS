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

        public OperationTable(List<T> _row_values, List<T> _col_values, Operation _op)
        {
            op = _op;
            // rows and columns changein calculation
            results = new T[ _col_values.Count, _row_values.Count ];

            for (int row = 0; row < _col_values.Count; row++)
            {
                for (int col = 0; col < _row_values.Count; col++)
                {
                    results[row, col] = op(_row_values[col], _col_values[row]);
                }
            }
        }

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


