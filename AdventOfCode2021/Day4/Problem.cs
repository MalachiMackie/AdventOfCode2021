namespace AdventOfCode2021.Day4;

public class BingoBoard
{
    public (int num, bool matched)[][] Values { get; } = {
        new (int, bool)[5],
        new (int, bool)[5],
        new (int, bool)[5],
        new (int, bool)[5],
        new (int, bool)[5]
    };

    private int _lastPlayedNum = 0;

    public int GetScore()
    {
        var unmatchedSum = 0;

        for (var column = 0; column < 5; column++)
        {
            for (var row = 0; row < 5; row++)
            {
                if (!Values[column][row].matched)
                {
                    unmatchedSum += Values[column][row].num;
                }
            }
        }

        return unmatchedSum * _lastPlayedNum;
    }

    public bool IsComplete()
    {
        var matchedColumns = new List<int>[]
        {
            new (),
            new (),
            new (),
            new (),
            new ()
        };
        var matchedRows = new List<int>[]
        {
            new (),
            new (),
            new (),
            new (),
            new ()
        };

        for (var column = 0; column < 5; column++)
        {
            for (var row = 0; row < 5; row++)
            {
                if (!Values[column][row].matched) continue;
                
                matchedColumns[column].Add(Values[column][row].num);
                matchedRows[row].Add(Values[column][row].num);
            }
        }

        return matchedColumns.Concat(matchedRows).Any(list => list.Count == 5);
    }

    public void CheckNum(int num)
    {
        _lastPlayedNum = num;
        for (var column = 0; column < 5; column++)
        {
            for (var row = 0; row < 5; row++)
            {
                if (Values[column][row].num == num)
                {
                    Values[column][row].matched = true;
                }
            }
        }
    }
}

public static class Problem
{
    public static (IEnumerable<int> bingoNumbers, IEnumerable<BingoBoard> bingoBoards)
        ParseInput(IEnumerable<string> inputLines)
    {
        var arr = inputLines.ToArray();
        var nums = arr[0].Split(",");
        var bingoNumbers = nums.Select(int.Parse);

        var bingoBoards = new List<BingoBoard>();
        
        var currentBoard = new BingoBoard();
        var currentRow = 0;
        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i].Length <= 1)
            {
                if (currentRow != 5)
                {
                    throw new InvalidOperationException("Unexpected end of board");
                }
                bingoBoards.Add(currentBoard);
                currentRow = 0;
                currentBoard = new BingoBoard();
                continue;
            }

            var lineNumbers = arr[i].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (lineNumbers.Length != 5)
            {
                throw new InvalidOperationException("Expected 5 numbers in a bingo board line");
            }
            for (var j = 0; j < lineNumbers.Length; j++)
            {
                currentBoard.Values[currentRow][j] = (int.Parse(lineNumbers[j]), false);
            }

            currentRow++;
        }

        if (currentRow == 5)
        {
            bingoBoards.Add(currentBoard);
        }

        return (bingoNumbers, bingoBoards);
    }
    
    private static async Task<(IEnumerable<int> bingoNumbers, IEnumerable<BingoBoard> bingoBoards)> GetInput()
    {
        var inputLines = await File.ReadAllLinesAsync("Day4/input.txt");
        return ParseInput(inputLines);
    }
    
    
    public static async Task<int> SolvePart1(IEnumerable<int>? bingoNumbers = null, IEnumerable<BingoBoard>? bingoBoards = null)
    {
        if (bingoNumbers is null || bingoBoards is null)
        {
            (bingoNumbers, bingoBoards) = await GetInput();
        }

        var boardsArray = bingoBoards as BingoBoard[] ?? bingoBoards.ToArray();
        foreach (var bingoNumber in bingoNumbers)
        {
            foreach (var board in boardsArray)
            {
                board.CheckNum(bingoNumber);
                if (board.IsComplete())
                {
                    return board.GetScore();
                }
            }
        }

        throw new InvalidOperationException("Nobody won");
    }
    
    public static async Task<int> SolvePart2(IEnumerable<int>? bingoNumbers = null, IEnumerable<BingoBoard>? bingoBoards = null)
    {
        if (bingoNumbers is null || bingoBoards is null)
        {
            (bingoNumbers, bingoBoards) = await GetInput();
        }

        var uncompletedBoards = bingoBoards.ToList();
        foreach (var bingoNumber in bingoNumbers)
        {
            foreach (var board in uncompletedBoards.ToList())
            {
                board.CheckNum(bingoNumber);
                if (board.IsComplete())
                {
                    if (uncompletedBoards.Count == 1)
                    {
                        return board.GetScore();
                    }

                    uncompletedBoards.Remove(board);
                }
            }
        }

        throw new InvalidOperationException("Nobody won");
    }
}