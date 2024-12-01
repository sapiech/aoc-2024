namespace AoC.Day01
{
    internal static class DistanceMeter
    {
        public async static Task<int> Meter()
        {
            var lists = await ReadLists();

            lists.Left.Sort();
            lists.Right.Sort();

            var result = 0;

            for (var i = 0; i < lists.Left.Count; i++)
            {
                result += Math.Abs(lists.Left[i] - lists.Right[i]);
            }

            return result;
        }

        public async static Task<int> MeterSimilarityScore()
        {
            var lists = await ReadLists();

            var frequency = lists.Right.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            var result = 0;

            foreach (var item in lists.Left)
            {
                if (frequency.TryGetValue(item, out var count))
                {
                    result += item * count;
                }
            }

            return result;
        }

        private static async Task<Lists> ReadLists()
        {
            var lists = new Lists();

            foreach (var line in await File.ReadAllLinesAsync("Day01/input.txt"))
            {
                var splitted = line.Split("   ");
                lists.Left.Add(int.Parse(splitted[0]));
                lists.Right.Add(int.Parse(splitted[1]));
            }

            return lists;
        }
    }

    record Lists
    {
        public List<int> Left { get; } = [];
        public List<int> Right { get; } = [];
    }
}
