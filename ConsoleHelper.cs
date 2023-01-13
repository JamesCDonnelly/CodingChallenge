// Copied and modified from stack overflow

namespace CodingChallenge
{
    internal partial class Program
    {
        public class ConsoleHelper
        {
            public static int MultipleChoice(bool canCancel, int spacing, params string[] options)
            {
                (int startX, int startY) = Console.GetCursorPosition();
                const int optionsPerLine = 5;
                int spacingPerLine = spacing;
                int currentSelection = 0;

                ConsoleKey key;

                Console.CursorVisible = false;

                do
                {
                    //Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                        if (i == currentSelection) { Console.ForegroundColor = ConsoleColor.Yellow; }
                        else { Console.ForegroundColor = ConsoleColor.White; }

                        Console.Write($"[{options[i]}]");
                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (currentSelection % optionsPerLine > 0)
                                    currentSelection--;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                    currentSelection++;
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                if (currentSelection >= optionsPerLine)
                                    currentSelection -= optionsPerLine;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (currentSelection + optionsPerLine < options.Length)
                                    currentSelection += optionsPerLine;
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                if (canCancel)
                                    return -1;
                                break;
                            }
                    }
                } while (key != ConsoleKey.Enter);

                Console.CursorVisible = true;
                return currentSelection;
            }
        }
    }
}