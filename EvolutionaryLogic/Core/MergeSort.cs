using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationLogics
{
    public class MergeSort<T>
    {
        public void Sort(List<IDNA<T>> input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                Sort(input, low, middle);
                Sort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        public void Sort(List<IDNA<T>> input)
        {
            Sort(input, 0, input.Count - 1);
        }

        private void Merge(List<IDNA<T>> input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            IDNA<T>[] tmp = new IDNA<T>[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left].GetFitnesss() < input[right].GetFitnesss())
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            while (left <= middle)
            {
                tmp[tmpIndex] = input[left];
                left = left + 1;
                tmpIndex = tmpIndex + 1;
            }

            while (right <= high)
            {
                tmp[tmpIndex] = input[right];
                right = right + 1;
                tmpIndex = tmpIndex + 1;
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

        public string PrintArray(List<IDNA<T>> input)
        {
            string result = String.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                result = result + input[i] + " ";
            }
            if (input.Count == 0)
            {
                result = "Array is empty.";
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
