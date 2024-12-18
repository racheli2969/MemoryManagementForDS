using System;

namespace MemoryManagementInDS.Week_4
{
    internal class Sort<T> where T : IComparable<T>
    {
        public static void SortTwo(ref T a, ref T b)
        {
            if (a.CompareTo(b) > 0)
            {
                T temp = a; a = b; b = temp;
            }
        }
    }
}
