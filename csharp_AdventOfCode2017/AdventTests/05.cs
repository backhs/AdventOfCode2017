using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace AdventTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PartOneExample()
        {
            var inputLines = new int[] { 0, 3, 0, 1, -3 }.ToList();
            Assert.AreEqual(5, DayFive.ComputePartOne(inputLines));
        }

        [TestMethod]
        public void PartOne()
        {
            var inputLines = File
                .ReadAllLines(@"..\..\input\05\part1.txt")
                .Select(s => int.Parse(s))
                .ToList();

            Assert.AreEqual(359348, DayFive.ComputePartOne(inputLines));
        }

        [TestMethod]
        public void PartTwoExample()
        {
            var inputLines = new int[] { 0, 3, 0, 1, -3 }.ToList();
            Assert.AreEqual(10, DayFive.ComputePartTwo(inputLines));
        }

        [TestMethod]
        public void PartTwo()
        {
            var inputLines = File
                .ReadAllLines(@"..\..\input\05\part1.txt")
                .Select(s => int.Parse(s))
                .ToList();

            Assert.AreEqual(27688760, DayFive.ComputePartTwo(inputLines));
        }
    }
}
