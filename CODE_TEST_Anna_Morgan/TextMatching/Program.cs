namespace TextMatching;

public class Program
{
    public static string? Text { get; set; }
    public static string? SubText { get; set; }

    public static void Main()
    {
        while (true)
        {
            GetInputs();
            var indexes = CheckForSubText();

            if (indexes.Count == 0)
            {
                Console.Write("No Matches");
            }
            else
            {
                foreach (var index in indexes.Reverse())
                {
                    Console.Write($"{index + 1}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public static void GetInputs()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Enter Text:");
        Text = Console.ReadLine();
        Console.WriteLine("Enter Subtext:");
        SubText = Console.ReadLine();
    }

    public static Stack<int> CheckForSubText()
    {
        Stack<int> startIndexes = new();

        if (Text is not null && SubText is not null)
        {
            var arrayText = Text.ToCharArrayCustom();
            var arraySubText = SubText.ToCharArrayCustom();

            if (arraySubText.Length > arrayText.Length)
            {
                return startIndexes;
            }

            List<char> tempList = new();

            for (int x = 0; x < arrayText.Length; x++)
            {
                if (tempList.SequenceEqual(arraySubText))
                {
                    tempList.Clear();
                }

                for (int y = tempList.Count; y < arraySubText.Length; y++)
                {
                    if (arrayText[x] == arraySubText[y])
                    {
                        if (y == 0)
                        {
                            startIndexes.Push(x);
                        }

                        tempList.Add(arraySubText[y]);

                        break;
                    }
                    else
                    {
                        if (y == arraySubText.Length - 1)
                        {
                            if (startIndexes.Count != 0 && startIndexes.Peek() == x - tempList.Count)
                            {
                                startIndexes.Pop();
                            }

                            tempList.Clear();

                            break;
                        }

                        if (x == 0)
                        {
                            break;
                        }
                    }
                }
            }
        }

        return startIndexes;
    }
}