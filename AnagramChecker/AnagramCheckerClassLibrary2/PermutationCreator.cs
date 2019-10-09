using System;
using System.Collections.Generic;

namespace AnagramCheckerClassLibrary
{
    class PermutationCreator : IPermutationCreator
    {
        private List<string> Permutations { get; set; }

        public PermutationCreator()
        {
            Permutations = new List<string>();
        }

        public string[] GetPermutations()
        {
            return Permutations.ToArray();
        }

        public void doHeapPermutation(char[] a, int size, int n)
        {
            if (size == 1)
            {
                Permutations.Add(new string(a));
            }

            for (int i = 0; i < size; i++)
            {
                doHeapPermutation(a, size - 1, n);

                // if size is odd, swap first and last 
                // element 
                if (size % 2 == 1)
                {
                    char temp = a[0];
                    a[0] = a[size - 1];
                    a[size - 1] = temp;
                }

                // If size is even, swap ith and last 
                // element 
                else
                {
                    char temp = a[i];
                    a[i] = a[size - 1];
                    a[size - 1] = temp;
                }
            }
        }
    }
}
