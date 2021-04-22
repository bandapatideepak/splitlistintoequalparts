using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class SplitList
    {
        public static IEnumerable<IEnumerable<T>> SplitSequentially<T>(int chunkParts, List<T> inputList)
        {
            List<int> Splits = split(inputList.Count, chunkParts);
            var skipNumber = 0;
            List<List<T>> list = new List<List<T>>();
            foreach (var count in Splits)
            {
                var internalList = inputList.Skip(skipNumber).Take(count).ToList();
                list.Add(internalList);
                skipNumber += count;
            }
            return list;
        }
        static List<int> split(int x, int n)
        {
            List<int> list = new List<int>();

            if (x % n == 0)
            {
                for (int i = 0; i < n; i++)
                    list.Add(x / n);
            }
            else
            {

                // upto n-(x % n) the values 
                // will be x / n 
                // after that the values 
                // will be x / n + 1 
                int zp = n - (x % n);
                int pp = x / n;
                for (int i = 0; i < n; i++)
                {

                    if (i >= zp)
                        list.Add((pp + 1));
                    else
                        list.Add(pp);
                }
            }
            return list;
        }
    }
}
