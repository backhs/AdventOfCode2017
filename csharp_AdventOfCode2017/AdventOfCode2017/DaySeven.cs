using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    class Node
    {
        public string Name { get; }
        public int Weight { get; }
        public IList<Node> NodesAbove { set; get; }
        public IList<string> NamesAbove { set; get; }
        public Node NodeBelow { get; set; }
        public int TowerWeight => Weight + NodesAbove.Select(n => n.TowerWeight).Sum();

        public Node(string name, int weight)
        {
            Name = name;
            Weight = weight;
            NodesAbove = new List<Node>();
            NamesAbove = new List<string>();
            NodeBelow = null;
        }

        public Node(string name, int weight, IList<Node> nodesAbove)
        {
            Name = name;
            Weight = weight;
            NodesAbove = nodesAbove;
            NamesAbove = new List<string>();
            NodeBelow = null;
        }

        public Node(string name, int weight, IList<string> namesAbove)
        {
            Name = name;
            Weight = weight;
            NodesAbove = new List<Node>();
            NamesAbove = namesAbove;
            NodeBelow = null;
        }
    }

    public class DaySeven
    {
        private static List<Node> ConvertTreeInput(List<string> inputList)
        {
            return inputList.Select(e => ConvertEntry(e)).ToList();

            Node ConvertEntry(string entry)
            {
                if (entry.Contains("->"))
                {
                    var parts = entry.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                    return GetNode(parts[0], parts[1]);
                }

                return GetNode(entry, null);

                Node GetNode(string part1, string part2)
                {
                    var split1 = part1.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var name = split1[0].Trim();
                    var weight = int.Parse(split1[1].TrimStart('(').TrimEnd(')').Trim());
                    var above = string.IsNullOrWhiteSpace(part2)
                        ? new List<string>()
                        : part2.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Trim())
                            .ToList();
                    return new Node(name, weight, above);
                }
            }
        }

        private static Node BuildTree(List<string> inputList)
        {
            var flatList = ConvertTreeInput(inputList);
            foreach (var node in flatList)
            {
                foreach (var name in node.NamesAbove)
                {
                    node.NodesAbove.Add(flatList.Single(n => n.Name == name));
                }
                foreach (var above in node.NodesAbove)
                {
                    above.NodeBelow = node;
                }
                while (node.NamesAbove.Count > 0)
                {
                    node.NamesAbove.RemoveAt(0);
                }
            }
            return flatList.Single(n => n.NodeBelow == null);
        }

        public static string ComputePartOne(List<string> inputList) => BuildTree(inputList).Name;

        public static int ComputePartTwo(List<string> inputList)
        {
            return Search(BuildTree(inputList));

            int Search(Node start)
            {
                var weightsAbove = start.NodesAbove
                    .GroupBy(n => n.TowerWeight)
                    .SingleOrDefault(a => a.Count() == 1);
                if (weightsAbove != null)
                {
                    return Search(weightsAbove.Single());
                }

                var shouldBeWeight = start.NodeBelow.NodesAbove
                        .First(n => n.TowerWeight != start.TowerWeight)
                        .TowerWeight;
                return shouldBeWeight > start.TowerWeight
                    ? start.Weight + (shouldBeWeight - start.TowerWeight)
                    : start.Weight - (start.TowerWeight - shouldBeWeight);
            }
        }
    }
}
