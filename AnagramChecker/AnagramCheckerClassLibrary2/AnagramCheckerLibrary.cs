using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerClassLibrary
{
    public class AnagramCheckerLibrary : IAnagramCheckerLibrary
    {
        private readonly IDictionaryReader reader;

        public AnagramCheckerLibrary()
        {
            this.reader = new DictionaryReader();
        }
        public async Task<bool> CheckAnagram(string w1, string w2, string filename)
        {
            var anagrams = await reader.ReadAnagramsAsync(filename);
            return FindAnagramsInList(w1, w2, anagrams);
        }

        public async Task<string[]> GetKnownAnagrams(string word, string filename)
        {
            var anagrams = await reader.ReadAnagramsAsync(filename);
            return FindKnownAnagramsInList(word, anagrams);
        }

        public string[] GetPermutations(string word)
        {
            PermutationCreator creator = new PermutationCreator();
            creator.doHeapPermutation(word.ToCharArray(), word.Length, word.Length);
            return creator.GetPermutations();
        }


        private static bool FindAnagramsInList(string w1, string w2, List<string[]> anagrams)
        {
            foreach (var anagramList in anagrams)
            {
                if (anagramList.Contains(w1) && anagramList.Contains(w2))
                {
                    return true;
                }
            }
            return false;
        }

        private static string[] FindKnownAnagramsInList(string word, List<string[]> anagrams)
        {
            foreach (var anagramList in anagrams)
            {
                if (anagramList.Contains(word))
                {
                    return anagramList.Where(anagram => !anagram.Equals(word)).ToArray();
                }
            }
            return Array.Empty<string>();
        }
    }
}
