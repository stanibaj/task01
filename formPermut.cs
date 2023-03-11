using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task01
{
    public class formPermut
    {
        // altered code from
        // https://www.w3resource.com/csharp-exercises/recursion/csharp-recursion-exercise-11.php
        public List<int []> permutations = new List<int[]>();
        public List<char []> charPermutations = new List<char[]>();

        private int randomPermIndex = -1;

        public char[]  randomCharPermutation;
        public void swapTwoNumber (ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void swapTwoChars (ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        
        public void prnPermut (int []list, int k, int m)
        {
            int i;
            if (k == m)
            { 
                permutations.Add(list);
            }
            else
                for (i = k; i <= m; i++)
                {
                    swapTwoNumber (ref list [k], ref list [i]);
                    prnPermut (list, k+1, m);
                    swapTwoNumber (ref list [k], ref list [i]);
                }
        }

        public void prnPermut (char []list, int k, int m)
        {
            if (randomPermIndex != -1 && charPermutations.Count > randomPermIndex)
            {
                randomCharPermutation = charPermutations.ElementAt(randomPermIndex);
                return;
            }
            int i;
            if (k == m)
            { 
                charPermutations.Add(list.ToArray());
            }
            else
                for (i = k; i <= m; i++)
                {
                    swapTwoChars (ref list [k], ref list [i]);
                    prnPermut (list, k+1, m);
                    swapTwoChars (ref list [k], ref list [i]);
                }
        }
        public void FindRandomPermutation(char []list, int listSize){
            var random = new Random();
            // double fact = Factorial(listSize);
            // randomPermIndex = random.Next(fact); // restrict for testing purposes
            randomPermIndex = random.Next(2000000,3500000);
            Console.WriteLine("Random index {0}",randomPermIndex);
            prnPermut(list, 0, listSize-1);
        }

        private double Factorial(int value)
        {
            double fact = 1;
            for (int i = 2; i < value; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}