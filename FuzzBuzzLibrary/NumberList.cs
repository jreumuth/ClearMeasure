using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzBuzzLibrary
{
    public class MapList : List<Tuple<int, string>>
    {
        public void Add(int n, string s)
        {
            Add(new Tuple<int, string>(n, s));
        }
    }

    public static class NumberList
    {
        public static IEnumerable<string> GetNameNumberList(int upper, MapList mapList)
        {
            for (int i = 1; i <= upper; ++i)
            {
                string next = "";

                foreach (Tuple<int, string> map in mapList)
                    if ((i % map.Item1) == 0)
                        next += map.Item2;

                if (next.Length == 0)
                    next = i.ToString();

                yield return next;
            }
        }
    }
}
