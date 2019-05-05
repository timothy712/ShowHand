using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Please enter an integer");
            //int baseNum = Convert.ToInt32(Console.ReadLine());

            //string result = "";

            //for (int i = 1; i <= baseNum; i++)
            //{
            //    int remainder = (baseNum % i);
            //    if (remainder == 0)
            //    {
            //        result += i.ToString() + ", ";
            //    }
            //}

            //result = result.Trim().TrimEnd(',');

            //Console.WriteLine(baseNum.ToString() + "的因數為 : " + result);

            //Console.WriteLine("請再輸入一個整數");
            //int baseNum2 = Convert.ToInt32(Console.ReadLine());
            //bool IsPrime = true;

            //for (int j = 1; j <= baseNum2; j++)
            //{
            //    int remainder = (baseNum2 % j);
            //    if (remainder == 0)
            //    {
            //        if (j > 1 && j != baseNum2)
            //        {
            //            IsPrime = false;
            //            break;
            //        }
            //    }
            //}

            //if (IsPrime == true)
            //{
            //    Console.WriteLine(baseNum2.ToString() + "是質數。");
            //}
            //else
            //{
            //    Console.WriteLine(baseNum2.ToString() + "不是質數。");
            //}

            //Console.WriteLine();
            //Console.WriteLine("請再輸入一個整數");
            //int baseNum3 = Convert.ToInt32(Console.ReadLine());
            //int count = 0;

            //for (int k = 1; k <= baseNum3; k++)
            //{
            //    int remainder = (baseNum3 % k);
            //    if (remainder == 0)
            //    {
            //        count += 1;
            //    }
            //}

            //if (count > 2)
            //{
            //    Console.WriteLine(baseNum3.ToString() + "不是質數。");
            //}
            //else
            //{
            //    Console.WriteLine(baseNum3.ToString() + "是質數。");
            //}

            int firstNum, secondNum;
            Console.WriteLine("請輸入第一個整數");
            firstNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("請輸入第二個整數");
            secondNum = Convert.ToInt32(Console.ReadLine());

            int x, y;
            if (firstNum > secondNum)
            {
                x = firstNum;
                y = secondNum;
            }
            else
            {
                x = secondNum;
                y = firstNum;
            }

            int gcd = 0;
            for (int i = y; i >= 1; i--)
            {
                if ((y % i) == 0 && (x % i) == 0)
                {
                    gcd = i;
                    break;
                }
            }

            Console.WriteLine(firstNum.ToString() + "與" + secondNum.ToString() + "的最大公因數為" + gcd.ToString());

            List<int> list = new List<int>();

            for (int i = 1; i <= firstNum; i++)
            {
                int remainder = (firstNum % i);
                if (remainder == 0)
                {
                    list.Add(i);
                }
            }
            int[] arrayA = list.ToArray();

            list.Clear();
            for (int i = 1; i <= secondNum; i++)
            {
                int remainder = (secondNum % i);
                if (remainder == 0)
                {
                    list.Add(i);
                }
            }
            int[] arrayB = list.ToArray();

            int[] bigArray;
            int[] smallArray;

            if (arrayA.Length > arrayB.Length)
            {
                bigArray = arrayA;
                smallArray = arrayB;
            }
            else
            {
                bigArray = arrayB;
                smallArray = arrayA;
            }

            int result = 0;
            bool IsFound = false;
            for (int i = (smallArray.Length - 1); i >= 0;  i--)
            {
                for (int j = 0; j < (bigArray.Length - 1); j++)
                {
                    if (bigArray[j] == smallArray[i])
                    {
                        result = smallArray[i];
                        IsFound = true;
                        break;
                    }                   
                }
                if (IsFound == true)
                {
                    break;
                }
            }

            Console.WriteLine("GCD = " + result.ToString());

            int a = 3;
            int b = 4;

            int sum = Sum(a, b);
            Console.WriteLine(sum.ToString());

            Console.ReadKey();
        }

        public static int Sum(int a, int b)
        {
            return (a + b);
        }

    }
}
