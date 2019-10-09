using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnagramCheckerClassLibrary
{
    interface IDictionaryReader
    {
        public Task<List<string[]>> ReadAnagramsAsync(string filename);
    }
}
