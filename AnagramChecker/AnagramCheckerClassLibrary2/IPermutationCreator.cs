
namespace AnagramCheckerClassLibrary
{
    interface IPermutationCreator
    {
        public string[] GetPermutations();

        public void doHeapPermutation(char[] a, int size, int n);
    }
}
