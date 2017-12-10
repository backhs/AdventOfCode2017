using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventTests
{
    [TestClass]
    public class _05
    {
        public static List<int> NewInputListInstance => File
                .ReadAllLines(@"..\..\input\05\part1.txt")
                .Select(s => int.Parse(s))
                .ToList();
        public static List<int> NewExampleListInstance => new List<int>(new[] { 0, 3, 0, 1, -3 });

        [TestMethod]
        public void Day5Part1Example() => Assert.AreEqual(5, DayFive.ComputePartOne(NewExampleListInstance));

        [TestMethod]
        public void Day5Part1() => Assert.AreEqual(359348, DayFive.ComputePartOne(NewInputListInstance));

        [TestMethod]
        public void Day5Part2Example() => Assert.AreEqual(10, DayFive.ComputePartTwo(NewExampleListInstance));

        [TestMethod]
        public void Day5Part2() => Assert.AreEqual(27688760, DayFive.ComputePartTwo(NewInputListInstance));
    }
}
