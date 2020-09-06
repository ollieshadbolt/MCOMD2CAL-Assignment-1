using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class HP
    {
        private static void PreBmBc(char[] x, int[] bmBc)
        {
            int i, m = x.Length;

            for (i = 0; i < bmBc.Length; ++i)
                bmBc[i] = m;
            for (i = 0; i < m - 1; ++i)
                bmBc[x[i]] = m - i - 1;
        }

        private static int arrayCmp(char[] a, int aIdx, char[] b, int bIdx,
                int length)
        {
            int i = 0;

            for (i = 0; i < length && aIdx + i < a.Length && bIdx + i < b.Length; i++)
            {
                if (a[aIdx + i] == b[bIdx + i])
                    ;
                else if (a[aIdx + i] > b[bIdx + i])
                    return 1;
                else
                    return 2;
            }

            if (i < length)
                if (a.Length - aIdx == b.Length - bIdx)
                    return 0;
                else if (a.Length - aIdx > b.Length - bIdx)
                    return 1;
                else
                    return 2;
            else
                return 0;
        }

        public static List<int> FindAll(String pattern, String source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int j, m = x.Length, n = y.Length;
            List<int> result = new List<int>(); ;

            char c;

            int[] bmBc = new int[65536];

            /* Preprocessing */
            PreBmBc(x, bmBc);

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                c = y[j + m - 1];
                if (x[m - 1] == c && arrayCmp(x, 0, y, j, (m - 1)) == 0)
                    result.Add(j);
                j += bmBc[c];
            }

            return result;
        }

        public static HP Compile(String pattern)
        {
            char[] x = pattern.ToCharArray();
            int m = x.Length;

            int[] bmBc = new int[65536];

            PreBmBc(x, bmBc);

            HP hp = new HP();
            hp.x = x;
            hp.bmBc = bmBc;
            hp.m = m;

            return hp;

        }

        public List<int> FindAll(String source)
        {
            char[] y = source.ToCharArray();
            int j, n = y.Length;
            char c;
            List<int> result = new List<int>();

            j = 0;
            while (j <= n - m)
            {
                c = y[j + m - 1];
                if (x[m - 1] == c && arrayCmp(x, 0, y, j, (m - 1)) == 0)
                    result.Add(j);
                j += bmBc[c];
            }

            return result;
        }

        private char[] x;
        private int m;
        private int[] bmBc;
    }
}
