using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lecture
{
    class Program0419_2
    {
        static void Main()
        {

            int[] a = { 1, 3, 5, 6 };
            int[] b = { 0, 1, 2, 4, 6 };

            Intersection(a, b);
            Union(a, b);

            Console.ReadKey();
        }

        static void Intersection(int[] a, int[] b)
        {
            int[] bigArray;
            int[] smallArray;
            if (a.Length > b.Length)
            {
                bigArray = a;
                smallArray = b;
            }
            else
            {
                bigArray = b;
                smallArray = a;
            }

            int[] interArray = new int[24];
            int count = 0;
            for (int i = 0; i < smallArray.Length; i++)
            {
                for (int j = 0; j < bigArray.Length; j++)
                {
                    if (smallArray[i] == bigArray[j])
                    {
                        interArray[count] = bigArray[j];
                        count++;
                    }
                }
            }

            Array.Resize(ref interArray, count);
            //Console.WriteLine(interArray.Length);

            string result = "";
            foreach (int ii in interArray)
            {
                result += ii.ToString() + ", ";
            }

            //Console.WriteLine(count.ToString());
            Console.WriteLine("Intersection : " + result.Trim().TrimEnd(','));
            

        }

        //int[] a = { 1, 3, 5, 6 };
        //int[] b = { 0, 1, 2, 4, 6 };

        static void Union(int[] a, int[] b)
        {
            int totalLength = a.Length + b.Length;
            int[] c = new int[totalLength];

            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }

            int count = 0;
            for (int i = 0; i < b.Length; i++)
            {
                bool IsExists = false;
                for (int j = 0; j < a.Length; j++)
                {
                    //Console.WriteLine(j.ToString());
                    if (b[i] == a[j])
                    {
                        IsExists = true;
                    }
                }

                if (IsExists == false)
                {                    
                    c[a.Length + count] = b[i];
                    count++;
                }
            }

            Array.Resize(ref c, a.Length + count);

            string result = "";
            foreach (int cc in c)
            {
                result += cc.ToString() + ", ";
            }

            Console.WriteLine("Union : " + result.Trim().TrimEnd(',').ToString());
        }

    }
}
