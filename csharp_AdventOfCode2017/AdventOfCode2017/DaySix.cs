using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    struct MaxBlockResult
    {
        public int Index { get; }
        public int Value { get; }

        public MaxBlockResult(int index, int value)
        {
            Index = index;
            Value = value;
        }
    }

    struct ComputationResult
    {
        public int CycleCount { get; }
        public int LoopSize { get; }

        public ComputationResult(int cycleCount, int loopSize)
        {
            CycleCount = cycleCount;
            LoopSize = loopSize;
        }
    }

    public class DaySix
    {
        private static string InputToCombo(List<int> list) => string.Join(", ", list);

        private static MaxBlockResult FindMaxBlockBankIndexAndMax(List<int> list)
        {
            var max = list.Max();
            return new MaxBlockResult(list.IndexOf(max), max);
        }

        private static int NextIndex(List<int> list, int currentIndex)
        {
            return currentIndex + 1 < list.Count
                    ? currentIndex + 1
                    : 0;
        }

        public static int ComputePartOne(List<int> inputList) => Compute(inputList).CycleCount;
        public static int ComputePartTwo(List<int> inputList) => Compute(inputList).LoopSize;

        private static ComputationResult Compute(List<int> inputList)
        {
            var stepCount = 0;
            var combo = InputToCombo(inputList);
            var uniqueCombinations = new List<string>(new[] { combo });
            var comboStack = new List<string>(new[] { combo });

            while (true)
            {
                stepCount++;
                var workingBlock = FindMaxBlockBankIndexAndMax(inputList);
                inputList[workingBlock.Index] = 0;
                var index = NextIndex(inputList, workingBlock.Index);
                for (var i = 0; i < workingBlock.Value; i++)
                {
                    inputList[index]++;
                    index = NextIndex(inputList, index);
                }
                var currentCombo = InputToCombo(inputList);
                if (uniqueCombinations.Contains(InputToCombo(inputList)))
                {
                    var lastSeen = comboStack.LastIndexOf(currentCombo);
                    return new ComputationResult(stepCount, stepCount - lastSeen);
                }

                comboStack.Add(currentCombo);
                uniqueCombinations.Add(currentCombo);
            }
        }        
    }
}
