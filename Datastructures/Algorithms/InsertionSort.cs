using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Datastructures
{
    public class InsertionSort
    {
        public static string[] SortFiles(string[] oldArray)
        {
            string[] array = oldArray;
            bool flag;
            for (int i = 1; i < array.Length; i++)
            {
                string valF = array[i];
                long val = new System.IO.FileInfo(array[i]).Length;
                flag = false;

                for(int j = i - 1; i >= 0 && flag != true;)
                {
                    if (val < new System.IO.FileInfo(array[j]).Length)
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = valF;
                    }
                    else 
                    {
                        flag = true;
                    }
                }
            }
            return array;
        }
    }
    
}
