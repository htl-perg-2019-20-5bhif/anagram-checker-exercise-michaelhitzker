using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramCheckerClassLibrary
{
    class DictionaryReader : IDictionaryReader
    {
        public async Task<List<string[]>> ReadAnagramsAsync(string filename)
        {
            List<string[]> anagrams = new List<string[]>();
            var fileContent = await System.IO.File.ReadAllTextAsync(filename);
            var anagramLines = fileContent.Split("\n");

            foreach (var anagramLine in anagramLines)
            {
                var anagramWords = anagramLine.Split(" ");
                anagrams.Add(anagramWords);
            }

            return anagrams;
        }
    }
}
