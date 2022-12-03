// Copied and modified from stack overflow

namespace CodingChallenge
{
    internal partial class Program
    {
        public class ConsoleHelper
        {
            public static int MultipleChoice(bool canCancel, bool variableSpacing, int spacing, params string[] options)
            {
                (int startX, int startY) = Console.GetCursorPosition();
                //const int startY = 8;
                const int optionsPerLine = 5;
                 int spacingPerLine = spacing;
                //int variableSpacingPerLine = (options.OrderByDescending(s => s.Length).First()).Length; //added

                int currentSelection = 0;

                //int spacingChoice;
                //if (variableSpacing) { spacingChoice = variableSpacingPerLine; }
                //else { spacingChoice = spacingPerLine; }

                ConsoleKey key;

                Console.CursorVisible = false;

                do
                {
                    //Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                        if (i == currentSelection)
                        { 
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            //Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }

                        Console.Write($"[{options[i]}]");

                        //Console.ResetColor();
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