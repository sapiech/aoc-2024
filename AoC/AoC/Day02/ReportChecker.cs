namespace AoC.Day02
{
    internal static class ReportChecker
    {
        public static async Task<int> CheckReports(bool problemDampener)
        {
            int safeRecordsCount = 0;

            await foreach (var line in File.ReadLinesAsync(@"Day02/input.txt"))
            {
                var level = line.Split(' ').Select(x => int.Parse(x)).ToList();
                if (problemDampener)
                {
                    if (IsReportSafeWithProblemDampener(level))
                    {
                        safeRecordsCount++;
                    }
                }
                else 
                {
                    if (IsReportSafe(level))
                    {
                        safeRecordsCount++;
                    }
                }
            }

            return safeRecordsCount;
        }

        private static bool IsReportSafeWithProblemDampener(List<int> level)
        {
            if (!IsReportSafe(level))
            {
                for (int i = 0; i < level.Count; i++)
                {
                    var workingCopy = new List<int>(level);
                    workingCopy.RemoveAt(i);

                    if (IsReportSafe(workingCopy))
                    {
                        return true;
                    }
                }
            }
            else 
            { 
                return true; 
            }

            return false;
        }

        private static bool IsReportSafe(List<int> levels)
        {
            bool? isIncreasing = null;

            for (int i = 0; i < levels.Count - 1; i++)
            {
                int diff = levels[i + 1] - levels[i];

                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                if (isIncreasing is null)
                {
                    isIncreasing = diff > 0;
                }
                else if ((isIncreasing.Value && diff < 0) || (!isIncreasing.Value && diff > 0))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
