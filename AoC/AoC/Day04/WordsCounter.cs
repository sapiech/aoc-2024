
namespace AoC.Day04
{
    internal static class WordsCounter
    {
        public static async Task<int> CountXMas()
        {
            var lines = await File.ReadAllLinesAsync(@"Day04/input.txt");
            char[][] chars = lines.Select(x => x.ToCharArray()).ToArray();
            var count = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                var line = chars[i];

                for (int j = 0; j < line.Length; j++)
                {
                    var c = line[j];

                    if (c == 'A')
                    {
                        if (CheckMas(i, j, chars))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static bool CheckMas(int y, int x, char[][] chars)
        {
            var result = false;
            if (y == 0 || y == chars.Length - 1 || x == 0 || x == chars.Length - 1)
            {
                return false;
            }

            try
            {
                if (chars[y + (int)Y.Top][x + (int)X.Left] == 'M')
                {
                    if (chars[y + (int)Y.Bottom][x + (int)X.Right] == 'S')
                    {
                        if (chars[y + (int)Y.Top][x + (int)X.Right] == 'M')
                        {
                            if (chars[y + (int)Y.Bottom][x + (int)X.Left] == 'S')
                            {
                                result = true;
                            }
                        }
                        else if (chars[y + (int)Y.Top][x + (int)X.Right] == 'S')
                        {
                            if (chars[y + (int)Y.Bottom][x + (int)X.Left] == 'M')
                            {
                                result = true;
                            }
                        }
                    }
                }
                else if (chars[y + (int)Y.Top][x + (int)X.Left] == 'S')
                {
                    if (chars[y + (int)Y.Bottom][x + (int)X.Right] == 'M')
                    {
                        if (chars[y + (int)Y.Top][x + (int)X.Right] == 'M')
                        {
                            if (chars[y + (int)Y.Bottom][x + (int)X.Left] == 'S')
                            {
                                result = true;
                            }
                        }
                        else if (chars[y + (int)Y.Top][x + (int)X.Right] == 'S')
                        {
                            if (chars[y + (int)Y.Bottom][x + (int)X.Left] == 'M')
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                // do nothing
            }

            return result;
        }

        public static async Task<int> CountWords()
        {
            var lines = await File.ReadAllLinesAsync(@"Day04/input.txt");

            char[][] chars = lines.Select(x => x.ToCharArray()).ToArray();
            var count = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                var line = chars[i];

                for (int j = 0; j < line.Length; j++)
                {
                    var c = line[j];

                    if (c == 'X')
                    {
                        foreach (var result in CheckIfMIsAround(i, j, chars))
                        {
                            if (result.IsMatch)
                            {
                                var mi = i + (int)result.Move.Y;
                                var mj = j + (int)result.Move.X;
                                try
                                {
                                    if (chars[mi + (int)result.Move.Y][mj + (int)result.Move.X] == 'A')
                                    {
                                        var ai = mi + (int)result.Move.Y;
                                        var aj = mj + (int)result.Move.X;

                                        if (chars[ai + (int)result.Move.Y][aj + (int)result.Move.X] == 'S')
                                        {
                                            count++;
                                        }
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    // do nothing
                                }
                            }
                        }
                        
                    }
                }
            }

            return count;

        }

        private static List<Result> CheckIfMIsAround(int y, int x, char[][] chars)
        {
            var moves = new List<Move>()
            {
                new Move(X.Left, Y.Top),
                new Move(X.None, Y.Top),
                new Move(X.Right, Y.Top),
                new Move(X.Left, Y.None),
                new Move(X.Right, Y.None),
                new Move(X.Left, Y.Bottom),
                new Move(X.None, Y.Bottom),
                new Move(X.Right, Y.Bottom),
            };

            var results = new List<Result>();

            for (int m = 0; m < moves.Count; m++)
            {
                var move = moves[m];

                try
                {
                    if (chars[y + (int)move.Y][x + (int)move.X] == 'M')
                    {
                        var result = new Result();
                        result.Move = move;
                        result.IsMatch = true;

                        results.Add(result);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // do nothing
                }
            }

            return results;
        }
    }
}
