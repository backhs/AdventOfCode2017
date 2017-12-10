using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTests
{
    [TestClass]
    public class _07
    {
        public static List<string> NewInputListInstance => File
                .ReadAllLines(@"..\..\input\07\part1.txt")
                .ToList();
        public static List<string> NewExampleListInstance => File
                .ReadAllLines(@"..\..\input\07\part1.example.txt")
                .ToList();

        [TestMethod]
        public void Day7Part1Example() => Assert.AreEqual("tknk", DaySeven.ComputePartOne(NewExampleListInstance));

        [TestMethod]
        public void Day7Part1() => Assert.AreEqual("mkxke", DaySeven.ComputePartOne(NewInputListInstance));

        [TestMethod]
        public void Day7Part2Example() => Assert.AreEqual(60, DaySeven.ComputePartTwo(NewExampleListInstance));

        [TestMethod]
        public void Day7Part2() => Assert.AreEqual(268, DaySeven.ComputePartTwo(NewInputListInstance));
    }
}
