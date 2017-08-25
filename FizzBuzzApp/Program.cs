using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzBuzzLibrary;

namespace FizzBuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MapList mapList = new MapList();
            mapList.Add(3, "Fuzz");
            mapList.Add(5, "Buzz");

            foreach (string s in NumberList.GetNameNumberList(20, mapList))
                Console.WriteLine(s);
        }
    }
}
