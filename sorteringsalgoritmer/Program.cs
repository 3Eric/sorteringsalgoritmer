using System;
using System.Diagnostics;
using System.Threading;

namespace sorteringsalgoritmer
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();
            Random r = new Random();
            Console.Write("How many numbers do you want to sort: ");
            int l = int.Parse(Console.ReadLine());
            int[] v = new int[l];
            for (int i = 0; i < l; i++)
            {
                v[i] = r.Next(100);
            }
            Console.Write("Bubble: ");
            string ba = Console.ReadLine();
            Console.Write("Selection: ");
            string sa = Console.ReadLine();
            Console.Write("Merge: ");
            string ma = Console.ReadLine();

            if (ba == "y" || ba == "j")
            {
                int[] vb = new int[l];
                Array.Copy(v, 0, vb, 0, vb.Length);

                sw.Start();
                Bubble(vb);
                sw.Stop();
                TimeSpan tsB = sw.Elapsed;
                Write("Bubble", tsB);
            }

            if (sa == "y" || sa == "j")
            {
                int[] vs = new int[l];
                Array.Copy(v, 0, vs, 0, vs.Length);

                sw.Restart();
                Selection(vs);
                sw.Stop();
                TimeSpan tsS = sw.Elapsed;
                Write("Selection", tsS);
            }

            if (ma == "y" || ma == "j")
            {
                int[] vm = new int[l];
                Array.Copy(v, 0, vm, 0, vm.Length);

                sw.Restart();
                MergeSort(vm, 0, vm.Length - 1);
                sw.Stop();
                TimeSpan tsM = sw.Elapsed;
                Write("Merge", tsM);
            }
        }

        static void MergeSort(int[] v, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(v, left, mid);
                MergeSort(v, mid + 1, right);

                Merge(v, left, mid, right);
            }
        }
        static void Merge(int[] v, int left, int mid, int right)
        {
            int[] leftv = new int[mid - left + 1];
            int[] rightv = new int[right - mid];


            Array.Copy(v, left, leftv, 0, mid - left + 1);
            Array.Copy(v, mid + 1, rightv, 0, right - mid);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftv.Length)
                {
                    v[k] = rightv[j];
                    j++;
                }
                else if (j == rightv.Length || leftv[i] <= rightv[j])
                {
                    v[k] = leftv[i];
                    i++;
                }
                else
                {
                    v[k] = rightv[j];
                    j++;
                }
            }
        }
        static void Selection(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
            {
                int jMin = i;
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[j] < v[jMin])
                    {
                        jMin = j;
                    }
                }
                if (jMin != i)
                {
                    Swap(ref v[jMin], ref v[i]);
                }
            }
        }
        static void Bubble(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                for (int j = 0; j < v.Length - 1; j++)
                {
                    if (v[j] > v[j + 1])
                    {
                        Swap(ref v[j], ref v[j + 1]);
                    }
                }
            }
        }
        static void Write(string s, TimeSpan ts)
        {
            string et = String.Format("{0:00}:{1:00}:{2:00}:{3:00}:", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("================");
            Console.WriteLine(s + " Time: " + et + " ms");
            Console.WriteLine("");
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
