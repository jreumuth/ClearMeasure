using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FuzzBuzzLibrary
{
    [TestFixture]
    public class TestNumberList
    {
        [Test]
        public void TestFuzzBuzzList()
        {
            MapList mapList = new MapList();
            mapList.Add(3, "Fuzz");
            mapList.Add(5, "Buzz");

            string[] actualList = NumberList.GetNameNumberList(20, mapList).ToArray();
            string[] expectedList = {
                "1",
                "2",
                "Fuzz",
                "4",
                "Buzz",
                "Fuzz",
                "7",
                "8",
                "Fuzz",
                "Buzz",
                "11",
                "Fuzz",
                "13",
                "14",
                "FuzzBuzz",
                "16",
                "17",
                "Fuzz",
                "19",
                "Buzz",
            };

            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestFuzzBuzzWithLargeNumbersList()
        {
            MapList mapList = new MapList();
            mapList.Add(3, "Fuzz");
            mapList.Add(5, "Buzz");

            string[] actualList = NumberList.GetNameNumberList(1000020, mapList).Skip(1000000).ToArray();
            string[] expectedList = {
                "1000001",
                "Fuzz",
                "1000003",
                "1000004",
                "FuzzBuzz",
                "1000006",
                "1000007",
                "Fuzz",
                "1000009",
                "Buzz",
                "Fuzz",
                "1000012",
                "1000013",
                "Fuzz",
                "Buzz",
                "1000016",
                "Fuzz",
                "1000018",
                "1000019",
                "FuzzBuzz",
            };

            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestMap1List()
        {
            MapList mapList = new MapList();
            mapList.Add(1, "Foo");
            const int Count = 20;

            string[] actualList = NumberList.GetNameNumberList(20, mapList).ToArray();

            List<string> expectedList = new List<string>(Count);
            for (int i = 0; i < Count; ++i)
                expectedList.Add("Foo");

            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestNoMappingNumbersList()
        {
            const int Count = 102;

            string[] actualList = NumberList.GetNameNumberList(Count, new MapList()).ToArray();

            List<string> expectedList = new List<string>(Count);
            for (int i = 1; i <= Count; ++i)
                expectedList.Add(i.ToString());

            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestEmptyNumbersList()
        {
            string[] actualList = NumberList.GetNameNumberList(0, new MapList()).ToArray();
            string[] expectedList = { };
            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestSingleNumberList()
        {
            string[] actualList = NumberList.GetNameNumberList(1, new MapList()).ToArray();
            string[] expectedList = { "1" };
            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }

        [Test]
        public void TestComplexMappingList()
        {
            MapList mapList = new MapList();
            mapList.Add(2, "Two");
            mapList.Add(3, "Three");
            mapList.Add(4, "Four");
            mapList.Add(5, "Five");
            mapList.Add(6, "Six");
            mapList.Add(7, "Seven");
            mapList.Add(8, "Eight");
            mapList.Add(9, "Nine");
            mapList.Add(10, "Ten");
            mapList.Add(11, "Eleven");

            string[] actualList = NumberList.GetNameNumberList(35, mapList).ToArray();
            string[] expectedList = {
                "1",
                "Two",
                "Three",
                "TwoFour",
                "Five",
                "TwoThreeSix",
                "Seven",
                "TwoFourEight",
                "ThreeNine",
                "TwoFiveTen",
                "Eleven",
                "TwoThreeFourSix",
                "13",
                "TwoSeven",
                "ThreeFive",
                "TwoFourEight",
                "17",
                "TwoThreeSixNine",
                "19",
                "TwoFourFiveTen",
                "ThreeSeven",
                "TwoEleven",
                "23",
                "TwoThreeFourSixEight",
                "Five",
                "Two",
                "ThreeNine",
                "TwoFourSeven",
                "29",
                "TwoThreeFiveSixTen",
                "31",
                "TwoFourEight",
                "ThreeEleven",
                "Two",
                "FiveSeven",
            };

            Assert.That(expectedList, Is.EquivalentTo(actualList));
        }
    }
}
