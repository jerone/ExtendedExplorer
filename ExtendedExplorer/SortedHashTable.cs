using System;
using System.Collections;

namespace ExtendedExplorer {

    /* A collection used by the chartDrawing, .NET does not have like this one.
     * The specs:ExtendedExplorer
     * - Contains key-value pair (.NET Hashtable cannot be sorted)
     * - The values can be sorted (.NET SortedList only sorts the key)
     */
    public class SortedHashTable {
        public string[] Keys { get { return keys; } }
        public long[] Values { get { return values; } }
        public long TotalValue { get { return totalValue; } }
        public int Length { get { return keys.Length; } }
        public bool IsGrouped { get { return isGrouped; } }

        private long totalValue = 0;
        private string[] keys;
        private long[] values;
        private bool isSortedDesc;
        private bool isGrouped;

        public SortedHashTable(IDictionary pData) {
            keys = new string[pData.Count];
            values = new long[pData.Count];
            pData.Keys.CopyTo(keys, 0);
            pData.Values.CopyTo(values, 0);
            for(int i = 0; i < values.Length; i++)
                totalValue += values[i];
            isSortedDesc = false;
            isGrouped = false;
        }

        public void sortValuesDesc() {
            Array.Sort(values, keys, new DescendingComparer());
            isSortedDesc = true;
        }

        public void groupValues(int pCountMinimum, int pPercentMinimum) {
            if(!isSortedDesc)
                sortValuesDesc();

            bool boolStop = false;
            long sum = 0;
            int i = 0;
            while(i < keys.Length && !boolStop) {
                if(i < pCountMinimum) {
                    sum += values[i];
                }
                else {
                    sum += values[i];
                    float percent = values[i] * 100 / (float)totalValue;
                    if(percent < pPercentMinimum) {
                        long[] arTemp1 = new long[i + 1];
                        string[] arTemp2 = new string[i + 1];

                        Array.Copy(values, arTemp1, i + 1);
                        Array.Copy(keys, arTemp2, i + 1);
                        values = arTemp1;
                        keys = arTemp2;
                        values[i] = totalValue - sum;
                        keys[i] = "Others";
                        boolStop = true;
                        isGrouped = true;
                    }
                }
                i++;
            }
        }
    }

    class DescendingComparer : IComparer {
        public int Compare(Object x, Object y) {
            return Decimal.Compare((long)y, (long)x);
        }
    }
}