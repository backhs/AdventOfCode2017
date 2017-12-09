using System.Collections.Generic;

namespace AdventOfCode2017
{
    public class DayFive
    {
        public static int ComputePartOne(List<int> input)
        {
            var stepCount = 0;
            var index = 0;

            while (true)
            {
                if (index < 0 || index >= input.Count)
                {
                    return stepCount;
                }

                stepCount++;
                var command = input[index];
                input[index] = command + 1;
                index += command;
            }
        }

        public static int ComputePartTwo(List<int> input)
        {
            var stepCount = 0;
            var index = 0;

            while (true)
            {
                if (index < 0 || index >= input.Count)
                {
                    return stepCount;
                }

                stepCount++;
                var command = input[index];
                input[index] = command >= 3 ? command - 1 : command + 1;
                index += command;
            }
        }
    }
}
