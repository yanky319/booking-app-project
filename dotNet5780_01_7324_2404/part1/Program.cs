//dotNet_5780_01_part1
//yaakov taber 319187324
//moshe helfgot 206262404
//In this program we fill two arrays with random values 
//and the third array in the subtraction result between them 
//and then print the contents of the arrays aligned
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int[] A = new int[20];
            int[] B = new int[20];
            int[] C = new int[20];
            for (int i = 0; i < 20; i++)    //Inserting the values into arrays
            {
                A[i] = r.Next(18, 122);
                B[i] = r.Next(18, 122);
                C[i] = Math.Abs(A[i] - B[i]);
            }
                                //Aligned printing of the arrays
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", A[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", B[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-3} ", C[i]);
            }
            Console.WriteLine();

        }
    }
}
