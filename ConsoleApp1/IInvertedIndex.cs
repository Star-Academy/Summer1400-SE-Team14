using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public interface IInvertedIndex
    {
        public List<string> deleteGivenFiles(List<string> answer, List<string> deleteFiles)
        {
            List<string> common = answer.Intersect(deleteFiles).ToList();

            answer.RemoveAll(x => common.Contains(x));
            return answer;
        }
    }
}