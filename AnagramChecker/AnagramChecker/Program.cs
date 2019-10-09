using System;

namespace AnagramChecker
{
    class Program
    {
        static readonly AnagramCheckerClassLibrary.AnagramCheckerLibrary lib = new AnagramCheckerClassLibrary.AnagramCheckerLibrary();

        static int Main(string[] args)
        {
            if (checkForErrors(args))
            {
                printError();
                return 1;
            }

            if (args[0].Equals("check"))
            {
                handleCheck(args[1], args[2]);
            }
            else if (args[0].Equals("getKnown"))
            {
                handleGetKnown(args[1]);
            }
            else if (args[0].Equals("getPermutations"))
            {
                handleGetPermutations(args[1]);
            }
            return 0;
        }

        static void handleGetPermutations(string w)
        {
            string[] permutations = lib.GetPermutations(w);

            Console.WriteLine();
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        async static void handleCheck(string w1, string w2)
        {
            bool areAnagrams = await lib.CheckAnagram(w1, w2, "anagrams.txt");
            if (areAnagrams)
            {
                Console.WriteLine("\"{0}\" and \"{1}\" are anagrams", w1, w2);
            }
            else
            {
                Console.WriteLine("\"{0}\" and \"{1}\" are no anagrams", w1, w2);
            }
        }

        async static void handleGetKnown(string w)
        {
            string[] anagrams = await lib.GetKnownAnagrams(w, "anagrams.txt");
            if (anagrams.Length <= 0)
            {
                Console.WriteLine("\nNo known anagrams found");
                return;
            }
            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram);
            }
        }

        static bool checkForErrors(string[] args)
        {
            if (args.Length <= 1)
            {
                return true;
            }
            if (!args[0].Equals("check") && !args[0].Equals("getKnown") && !args[0].Equals("getPermutations"))
            {

                return true;
            }

            if ((args[0].Equals("getKnown") || args[0].Equals("getPermutations")) && args.Length != 2)
            {
                return true;
            }

            if (args[0].Equals("check") && args.Length != 3)
            {
                return true;
            }
            return false;
        }

        static void printError()
        {
            Console.WriteLine("\nUsage: ");
            Console.WriteLine("AnagramChecker check <w1> <w2>");
            Console.WriteLine("AnagramChecker getKnown <w>");
            Console.WriteLine("AnagramChecker getPermutations <w>");
        }
    }
}
