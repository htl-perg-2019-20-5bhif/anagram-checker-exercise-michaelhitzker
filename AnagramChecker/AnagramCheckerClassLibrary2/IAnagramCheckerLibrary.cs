using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramCheckerClassLibrary
{
    public interface IAnagramCheckerLibrary
    {
        public Task<bool> CheckAnagram(string w1, string w2, string filename);

        public Task<string[]> GetKnownAnagrams(string word, string filename);

        public string[] GetPermutations(string word);
    }
}
