using System.Collections.Generic;
using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTests
{
    [TestClass]
    public class _06
    {
        public static List<int> NewInputListInstance => new List<int>(new [] { 10, 3, 15, 10, 5, 15, 5, 15, 9, 2, 5, 8, 5, 2, 3, 6 });
        public static List<int> NewExampleListInstance => new List<int>(new[] { 0, 2, 7, 0 });

        [TestMethod]
        public void Day6Part1Example()
        {
            Assert.AreEqual(5, DaySix.ComputePartOne(NewExampleListInstance));
        }

        [TestMethod]
        public void Day6Part1()
        {
            Assert.AreEqual(14029, DaySix.ComputePartOne(NewInputListInstance));
        }

        [TestMethod]
        public void Day6Part2Example()
        {
            Assert.AreEqual(4, DaySix.ComputePartTwo(NewExampleListInstance));
        }

        [TestMethod]
        public void Day6Part2()
        {
            Assert.AreEqual(2765, DaySix.ComputePartTwo(NewInputListInstance));
        }
    }
}
