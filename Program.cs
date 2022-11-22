using System;

namespace Millionaire
{
    /// <summary>
    /// Manages the game functions
    /// </summary>
    /// <remarks><c>Startup Object</c></remarks>
    class Program
    {
        /// <summary>
        /// Creates and manages the main menu
        /// </summary>
        /// <remarks><c>Main method</c></remarks>
        static void Main()
        {
            RankList rankings = new RankList();
            ConsoleKeyInfo mainKey;

            rankings.Load();

            do
            {
                Display();

                do
                {
                    mainKey = Console.ReadKey(true);
                } while (mainKey.Key != ConsoleKey.N && mainKey.Key != ConsoleKey.R && mainKey.Key != ConsoleKey.T && mainKey.Key != ConsoleKey.Escape);

                if (mainKey.Key == ConsoleKey.N)
                {
                    NewGame(ref rankings);
                }
                else if (mainKey.Key == ConsoleKey.R)
                {
                    rankings.Display();

                    ConsoleKeyInfo rankListKey;
                    do
                    {
                        rankListKey = Console.ReadKey(true);
                    } while (rankListKey.Key != ConsoleKey.Escape);
                }
                else if (mainKey.Key == ConsoleKey.T)
                {
                    ResetConsole();
                    Console.BufferHeight = 500;

                    int[] t = Test.All();
                    Console.WriteLine($"HashCode success rate: {t[0]} / {t[3]}");
                    Console.WriteLine($"Equals success rate: {t[1]} / {t[2]}");
                    Console.ReadKey(true);

                    Test.QuestionListElement_Console();
                    Test.RankList_Console();

                    GC.Collect();
                }

            } while (mainKey.Key != ConsoleKey.Escape);

            rankings.Save();
        }

        /// <summary>
        /// <para>Creates a new game with the questions reloaded</para>
        /// <para>Adds user's information to the <paramref name="rankings"/></para>
        /// </summary>
        /// <param name="rankings"><see cref="RankList"/> which stores the user's information (may be modified)</param>
        static void NewGame(ref RankList rankings)
        {
            QuestionList questions = new QuestionList();
            QuestionList usedQuestions = new QuestionList();
            QuestionListElement element;
            ConsoleKeyInfo gameKey;
            QuestionMode mode;
            int[] votes = null;
            char[] incorrects = null;
            bool phone = false;
            int difficulty = 1;

            questions.Load();
            if (questions.IsEmpty) return;

            do
            {
                string text = "";
                element = questions.GetRandomByUsableDifficulty(difficulty) ?? usedQuestions.GetRandomByUsableDifficulty(difficulty);

                do
                {
                    mode = (QuestionMode)Enum.Parse(typeof(QuestionMode), text == "" ? "Default" : text.Substring(1));
                    element.Display(mode, ref votes, ref incorrects, phone);
                    gameKey = Console.ReadKey(true);

                    switch (gameKey.Key)
                    {
                        case ConsoleKey.P:
                            if (phone) break;
                            text += "_Phone";
                            phone = true;
                            break;

                        case ConsoleKey.H:
                            if (incorrects != null) break;
                            text += "_Half";
                            break;

                        case ConsoleKey.V:
                            if (votes != null) break;
                            text += "_Vote";
                            break;
                    }

                } while (!((gameKey.Key == ConsoleKey.A || gameKey.Key == ConsoleKey.B || gameKey.Key == ConsoleKey.C || gameKey.Key == ConsoleKey.D || gameKey.Key == ConsoleKey.S || gameKey.Key == ConsoleKey.Escape) &&
                           (incorrects == null || (char.ToUpper(gameKey.KeyChar) != incorrects[0] && char.ToUpper(gameKey.KeyChar) != incorrects[1]))));


                if (incorrects != null)
                {
                    incorrects[0] = (char)0;
                    incorrects[1] = (char)0;
                }

                if (gameKey.Key == ConsoleKey.Escape) return;
                if (gameKey.Key == ConsoleKey.S) element.Display(QuestionMode.Phone, ref votes, ref incorrects, phone);
                else element.Display(QuestionMode.Answer, ref votes, ref incorrects, phone);
                Console.ReadKey(true);

                difficulty++;
                usedQuestions.Add(element);
                questions.Remove(element);

            } while (difficulty <= 15 && element.CorrectAnswer(gameKey.Key) && gameKey.Key != ConsoleKey.S);


            int score = 0;
            if (gameKey.Key != ConsoleKey.S)
            {
                if (difficulty >= 15 && element.CorrectAnswer(gameKey.Key)) score = 15;
                else if (difficulty > 10) score = 10;
                else if (difficulty > 5) score = 5;
            }
            else
            {
                score = element.Difficulty - 1;
            }

            ResetConsole();
            Console.Write($"\n{CenterText(score > 0 ? $"Congratulation, you got {score} score" : $"Unfortunately, you got {score} score")}\n\n\n\tPlease type in your username: ");
            rankings.Add(new RankListElement(Console.ReadLine(), score, DateTime.Now));
        }

        /// <summary>
        /// Returns a string centered to the <see cref="Console"/>
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>centered <paramref name="text"/></returns>
        public static string CenterText(string text)
        {
            string temp = "";

            for (int i = text.Length / 2; i < Console.WindowWidth / 2; i++)
            {
                temp += " ";
            }

            return temp + text;
        }

        /// <summary>
        /// Returns a multiple line string centered to the <see cref="Console"/>
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>centered multiple line <paramref name="text"/></returns>
        public static string ComplexCenterText(string text)
        {
            string[] split = text.Split(' ');
            string temp = "";
            string ret = "";

            for (int i = 0; i < split.Length; i++)
            {
                if (temp.Length + split[i].Length > Console.WindowWidth * 0.8)
                {
                    ret += CenterText(temp) + "\n";
                    temp = "";
                }
                temp += split[i] + " ";
            }

            ret += CenterText(temp);
            return ret;
        }

        /// <summary>
        /// Modifies, then displays the Main menu to the <see cref="Console"/>
        /// </summary>
        public static void Display()
        {
            ResetConsole();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n{0}\n\n\n\n", CenterText("WHO WANTS TO BE A MILLIONAIRE"));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0}\n", CenterText("[N] New Game"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}\n\n\n", CenterText("[R] Rank List"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(CenterText("[Esc] Exit Game"));
        }

        /// <summary>
        /// Sets defalt settings of the <see cref="Console"/>
        /// </summary>
        public static void ResetConsole()
        {
            Console.Title = "Who Wants to Be a Millionaire";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WindowWidth = 100;
            Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
        }
    }
}
