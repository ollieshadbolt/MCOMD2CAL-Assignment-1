using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BF
    {
        public static List<int> FindAll(String pattern, String source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, m = x.Length, n = y.Length;
            long loops = -1;
            List<int> result = new List<int>();

            //ArrayList TEMP = new ArrayList();
            //List<int> result = (int)(TEMP.ToArray());
            //List<int> result = new List<int>();// = new List<int>(new System.Collections.ArrayList.ToArray(typeof(int)));
            //arrayList.Cast<int>().ToList();
            //List<int> newList = new List<int>(arrayList.ToArray(typeof(int)));

            /* Searching */
            for (j = 0; j <= n - m; ++j)
            {
                for (i = 0; i < m && x[i] == y[i + j]; ++i)
                { loops++; }
                if (i >= m)
                    result.Add(j);
            }

            return result;
        }

    }
}
