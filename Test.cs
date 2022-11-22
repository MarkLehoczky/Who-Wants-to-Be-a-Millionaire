using System;
using System.IO;

namespace Millionaire
{
    /// <summary>
    /// Manages the Test cases
    /// </summary>
    /// <remarks>static class</remarks>
    static class Test
    {
        /// <summary>
        /// Runs and displays all <see langword="non"/>-<see cref="Console"/> tests
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] All()
        {
            int[] successful = new int[4];

            SuccessAdd(ref successful, QuestionList_IO());
            //Console.ReadKey(true);
            Console.WriteLine();
            //Console.Clear();

            SuccessAdd(ref successful, RankList_IO());
            //Console.ReadKey(true);
            Console.WriteLine();
            //Console.Clear();

            SuccessAdd(ref successful, QuestionList_Methods());
            //Console.ReadKey(true);
            Console.WriteLine();
            //Console.Clear();

            SuccessAdd(ref successful, RankList_Methods());
            //Console.ReadKey(true);
            Console.WriteLine();
            //Console.Clear();

            SuccessAdd(ref successful, QuestionListElement_Methods());
            //Console.ReadKey(true);
            Console.WriteLine();
            //Console.Clear();

            SuccessAdd(ref successful, RankListElement_Methods());
            Console.WriteLine();
            //Console.Clear();

            return successful;
        }

        /// <summary>
        /// Tests multiple file <see langword="Input-Output"/> of the <see cref="QuestionList"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] QuestionList_IO()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("QuestionList file IO tests")}\n\n");

            QuestionList expected = new QuestionList();
            QuestionList actual = new QuestionList();
            actual.Load("./Tests/Questions/One question.csv");
            expected.Add(new QuestionListElement(1, "How many bits are there in a byte?", "4", "2", "8", "10", 'C'));
            SuccessAdd(ref successful, Display("Standard input", expected, actual));

            expected = new QuestionList();
            actual = new QuestionList();
            actual.Load("./Tests/Questions/Empty file.csv");
            SuccessAdd(ref successful, Display("Empty file", expected, actual));

            expected = new QuestionList();
            actual = new QuestionList();
            actual.Load("./Tests/Questions/Incorrect format.csv");
            expected.Add(new QuestionListElement(1, "How many bits are there in a byte?", "4", "2", "8", "10", 'C'));
            expected.Add(new QuestionListElement(2, "What does WWW stand for?", "World Wide Web", "World Wander Web", "World Waive Web", "World Wrestling Web", 'A'));
            expected.Add(new QuestionListElement(4, "What sort of animal is Tux, the official mascot of the Linux operating system?", "Penguin", "Lion", "Turtle", "Dolphin", 'A'));
            SuccessAdd(ref successful, Display("Incorrect format", expected, actual));

            expected = new QuestionList();
            actual = new QuestionList();
            actual.Load("./Tests/Questions/One question.csv");
            actual.Save("./Tests/Questions/temp.csv");
            expected.Load("./Tests/Questions/temp.csv");
            SuccessAdd(ref successful, Display("Save QuestionList", expected, actual));

            File.Delete("./Tests/Questions/temp.csv");

            return successful;
        }

        /// <summary>
        /// Tests multiple file <see langword="Input-Output"/> of the <see cref="RankList"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] RankList_IO()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("RankList file IO tests")}\n\n");

            RankList expected = new RankList();
            RankList actual = new RankList();
            actual.Load("./Tests/Ranking/Few elements.csv");
            expected.Add(new RankListElement("Fifteen", 15, DateTime.Parse("11/01/2022 00:00:00")));
            expected.Add(new RankListElement("Thirteen", 13, DateTime.Parse("11/01/2022 00:00:00")));
            expected.Add(new RankListElement("Thirteen", 13, DateTime.Parse("11/01/2022 00:00:00")));
            expected.Add(new RankListElement("Eleven", 11, DateTime.Parse("11/01/2022 00:00:00")));
            expected.Add(new RankListElement("Zero", 0, DateTime.Parse("11/01/2022 00:00:00")));
            SuccessAdd(ref successful, Display("Standard input", expected, actual));

            expected = new RankList();
            actual = new RankList();
            actual.Load("./Tests/Ranking/Empty file.csv");
            SuccessAdd(ref successful, Display("Empty file", expected, actual));

            expected = new RankList();
            actual = new RankList();
            actual.Load("./Tests/Ranking/Incorrect format.csv");
            expected.Add(new RankListElement("Fifteen", 15, DateTime.Parse("11/01/2022 00:00:00")));
            expected.Add(new RankListElement("Zero", 0, DateTime.Parse("11/01/2022 00:00:00")));
            SuccessAdd(ref successful, Display("Incorrect format", expected, actual));

            expected = new RankList();
            actual = new RankList();
            actual.Load("./Tests/Ranking/Few elements.csv");
            actual.Save("./Tests/Ranking/temp.csv");
            expected.Load("./Tests/Ranking/temp.csv");
            SuccessAdd(ref successful, Display("Save RankList", expected, actual));

            File.Delete("./Tests/Ranking/temp.csv");

            return successful;
        }

        /// <summary>
        /// Tests multiple methods of the <see cref="QuestionList"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] QuestionList_Methods()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("QuestionList method tests")}\n\n");

            QuestionListElement correct = new QuestionListElement(1, "Test", "incorrect", "correct", "incorrect", "incorrect", 'B');
            QuestionListElement incorrect = new QuestionListElement(1, "Test", "correct", "incorrect", "incorrect", "incorrect", 'A');

            QuestionListElement[] temp = new QuestionListElement[3];
            temp[0] = new QuestionListElement(1, "Tests", "incorrect", "correct", "incorrect", "incorrect", 'B');
            temp[1] = new QuestionListElement(2, "Tests", "incorrect", "correct", "incorrect", "incorrect", 'B');
            temp[2] = new QuestionListElement(3, "Tests", "incorrect", "correct", "incorrect", "incorrect", 'B');



            QuestionList actual;
            QuestionList expected;

            actual = new QuestionList();
            SuccessAdd(ref successful, Display("QuestionList()", 0, actual, true));

            actual = new QuestionList(correct);
            SuccessAdd(ref successful, Display("QuestionList(QuestionListElement)", 892247138, actual, true));

            actual = new QuestionList(temp);
            SuccessAdd(ref successful, Display("QuestionList(QuestionListElement[])", 1058880236, actual, true));

            expected = new QuestionList(actual);
            SuccessAdd(ref successful, Display("QuestionList(QuestionList)", actual, expected));


            expected = new QuestionList(correct);
            actual = new QuestionList();
            actual.Add(correct);
            SuccessAdd(ref successful, Display("QuestionList.Add(QuestionListElement)", expected, actual));

            expected = new QuestionList(new QuestionListElement[] { correct, temp[0], temp[1], temp[2] });
            actual.Add(temp);
            SuccessAdd(ref successful, Display("QuestionList.Add(QuestionListElement[])", expected, actual));

            expected = new QuestionList(new QuestionListElement[] { correct, temp[0], temp[1], temp[2], temp[0], temp[1], temp[2] });
            actual.Add(new QuestionList(temp));
            SuccessAdd(ref successful, Display("QuestionList.Add(QuestionList)", expected, actual));

            expected = new QuestionList();
            actual.Clear();
            SuccessAdd(ref successful, Display("QuestionList.Clear()", expected, actual));

            actual.Add(correct);
            actual.Add(temp);
            SuccessAdd(ref successful, Display("QuestionList.Contains(QuestionListElement)", true, actual.Contains(correct)));
            SuccessAdd(ref successful, Display("QuestionList.Contains(QuestionListElement)", false, actual.Contains(incorrect)));

            SuccessAdd(ref successful, Display("QuestionList.Get(int)", correct, actual.Get(0)));
            SuccessAdd(ref successful, Display("QuestionList.Get(int)", null, actual.Get(10)));

            expected = new QuestionList(new QuestionListElement[] { correct, temp[0] });
            SuccessAdd(ref successful, Display("QuestionList.GetAllByDifficulty(int)", expected, actual.GetAllByDifficulty(1)));
            expected = new QuestionList();
            SuccessAdd(ref successful, Display("QuestionList.GetAllByDifficulty(int)", expected, actual.GetAllByDifficulty(5)));
            actual.Clear();

            expected = new QuestionList(correct);
            actual.Add(correct);
            SuccessAdd(ref successful, Display("QuestionList.GetRandomByDifficulty(int)", expected.Get(0), actual.GetRandomByDifficulty(1)));
            SuccessAdd(ref successful, Display("QuestionList.GetRandomByDifficulty(int)", null, actual.GetRandomByDifficulty(5)));
            actual.Add(temp);

            SuccessAdd(ref successful, Display("QuestionList.IndexOf(QuestionListElement)", 2, actual.IndexOf(temp[1])));
            SuccessAdd(ref successful, Display("QuestionList.IndexOf(QuestionListElement)", null, actual.IndexOf(incorrect)));

            expected = new QuestionList(new QuestionListElement[] { correct, temp[0], temp[2] });
            actual.Remove(temp[1]);
            SuccessAdd(ref successful, Display("QuestionList.Remove(QuestionListElement)", expected, actual));
            actual.Remove(incorrect);
            SuccessAdd(ref successful, Display("QuestionList.Remove(QuestionListElement)", expected, actual));

            expected = new QuestionList(new QuestionListElement[] { temp[0], temp[2] });
            actual.RemoveAt(0);
            SuccessAdd(ref successful, Display("QuestionList.RemoveAt(int)", expected, actual));
            actual.RemoveAt(5);
            SuccessAdd(ref successful, Display("QuestionList.RemoveAt(int)", expected, actual));

            return successful;
        }

        /// <summary>
        /// Tests multiple methods of the <see cref="RankList"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] RankList_Methods()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("RankList method tests")}\n\n");

            RankListElement correct = new RankListElement("Test", 1, new DateTime(2022, 11, 01, 00, 00, 00));
            RankListElement incorrect = new RankListElement("Wrong", 1, new DateTime(2022, 11, 01, 00, 00, 00));

            RankListElement[] temp = new RankListElement[3];
            temp[0] = new RankListElement("Tests", 1, new DateTime(2022, 11, 01, 00, 00, 00));
            temp[1] = new RankListElement("Tests", 2, new DateTime(2022, 11, 01, 00, 00, 00));
            temp[2] = new RankListElement("Tests", 3, new DateTime(2022, 11, 01, 00, 00, 00));



            RankList actual;
            RankList expected;

            actual = new RankList();
            SuccessAdd(ref successful, Display("RankList()", 0, actual, true));

            actual = new RankList(correct);
            SuccessAdd(ref successful, Display("RankList(RankListElement)", 1903976564, actual, true));

            actual = new RankList(temp);
            SuccessAdd(ref successful, Display("RankList(RankListElement[])", 1185968574, actual, true));

            expected = new RankList(actual);
            SuccessAdd(ref successful, Display("RankList(RankList)", actual, expected));


            expected = new RankList(correct);
            actual = new RankList();
            actual.Add(correct);
            SuccessAdd(ref successful, Display("RankList.Add(RankListElement)", expected, actual));

            expected = new RankList(new RankListElement[] { correct, temp[0], temp[1], temp[2] });
            actual.Add(temp);
            SuccessAdd(ref successful, Display("RankList.Add(RankListElement[])", expected, actual));

            expected = new RankList(new RankListElement[] { correct, temp[0], temp[1], temp[2], temp[0], temp[1], temp[2] });
            actual.Add(new RankList(temp));
            SuccessAdd(ref successful, Display("RankList.Add(RankList)", expected, actual));

            expected = new RankList();
            actual.Clear();
            SuccessAdd(ref successful, Display("RankList.Clear()", expected, actual));

            actual.Add(correct);
            actual.Add(temp);
            SuccessAdd(ref successful, Display("RankList.Contains(RankListElement)", true, actual.Contains(correct)));
            SuccessAdd(ref successful, Display("RankList.Contains(RankListElement)", false, actual.Contains(incorrect)));

            SuccessAdd(ref successful, Display("RankList.Get(int)", correct, actual.Get(0)));
            SuccessAdd(ref successful, Display("RankList.Get(int)", null, actual.Get(10)));

            actual.Clear();

            actual.Add(correct);
            actual.Add(temp);

            SuccessAdd(ref successful, Display("RankList.IndexOf(RankListElement)", 2, actual.IndexOf(temp[1])));
            SuccessAdd(ref successful, Display("RankList.IndexOf(RankListElement)", null, actual.IndexOf(incorrect)));

            expected = new RankList(new RankListElement[] { correct, temp[0], temp[2] });
            actual.Remove(temp[1]);
            SuccessAdd(ref successful, Display("RankList.Remove(RankListElement)", expected, actual));
            actual.Remove(incorrect);
            SuccessAdd(ref successful, Display("RankList.Remove(RankListElement)", expected, actual));

            expected = new RankList(new RankListElement[] { temp[0], temp[2] });
            actual.RemoveAt(0);
            SuccessAdd(ref successful, Display("RankList.RemoveAt(int)", expected, actual));
            actual.RemoveAt(5);
            SuccessAdd(ref successful, Display("RankList.RemoveAt(int)", expected, actual));

            expected = new RankList(new RankListElement[] { temp[2], temp[0], correct });
            actual.Add(correct);
            actual.Sort();
            SuccessAdd(ref successful, Display("RankList.Sort()", expected, actual));

            expected = new RankList(new RankListElement[] { temp[2], temp[0], correct });
            actual.Update(incorrect, incorrect);
            SuccessAdd(ref successful, Display("RankList.Update(RankListElement,RankListElement)", expected, actual));

            expected = new RankList(new RankListElement[] { temp[2], temp[0], incorrect });
            actual.Update(correct, incorrect);
            SuccessAdd(ref successful, Display("RankList.Update(RankListElement,RankListElement)", expected, actual));

            expected = new RankList(new RankListElement[] { incorrect, temp[0], incorrect });
            actual.UpdateAt(0, incorrect);
            SuccessAdd(ref successful, Display("RankList.UpdateAt(int,RankListElement)", expected, actual));

            expected = new RankList(new RankListElement[] { incorrect, temp[0], incorrect });
            actual.UpdateAt(5, correct);
            SuccessAdd(ref successful, Display("RankList.UpdateAt(int,RankListElement)", expected, actual));

            return successful;
        }

        /// <summary>
        /// Tests multiple methods of the <see cref="QuestionListElement"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] QuestionListElement_Methods()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("QuestionListElement method tests")}\n\n");

            QuestionListElement actual = new QuestionListElement(1, "Test", "incorrect", "correct", "incorrect", "incorrect", 'B');
            SuccessAdd(ref successful, Display("QuestionListElement(int,string,string,string,string,string,char)", 891591778, actual, true));

            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(char)", true, actual.CorrectAnswer('B')));
            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(ConsoleKey)", true, actual.CorrectAnswer(ConsoleKey.B)));
            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(ConsoleKeyInfo)", true, actual.CorrectAnswer(new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false))));

            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(char)", false, actual.CorrectAnswer('A')));
            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(ConsoleKey)", false, actual.CorrectAnswer(ConsoleKey.A)));
            SuccessAdd(ref successful, Display("QuestionListElement.CorrectAnswer(ConsoleKeyInfo)", false, actual.CorrectAnswer(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false))));

            return successful;
        }

        /// <summary>
        /// Tests multiple methods of the <see cref="RankListElement"/>
        /// </summary>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public static int[] RankListElement_Methods()
        {
            int[] successful = new int[4];

            Console.WriteLine($"\n{Program.CenterText("RankListElement method tests")}\n\n");

            RankListElement actual = new RankListElement("Test", 1, new DateTime(2022, 11, 01, 00, 00, 00));
            SuccessAdd(ref successful, Display("RankListElement(string,int,DateTime)", 1903974004, actual, true));

            return successful;
        }

        /// <summary>
        /// Displays the different versions of the <see cref="QuestionListElement"/> to the <see cref="Console"/>
        /// </summary>
        public static void QuestionListElement_Console()
        {
            char[] c = null;
            int[] v = null;

            QuestionList questions = new QuestionList();

            questions.Load("./Tests/Questions/Really long elements.csv");

            for (int i = 0; i < questions.Length; i++)
            {
                c = null; v = null;
                questions.Get(i).Display(QuestionMode.Default, ref v, ref c, false);
                Console.ReadKey(true);
            }

            questions.Clear();
            questions.Load("./Tests/Questions/One of each.csv");

            for (int i = 0; i < questions.Length; i++)
            {
                c = null; v = null;
                questions.Get(i).Display((QuestionMode)i, ref v, ref c, questions.Get(i).Question.Contains("Phone"));
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Displays the different versions of the <see cref="RankList"/> to the <see cref="Console"/>
        /// </summary>
        public static void RankList_Console()
        {
            RankList rankings = new RankList();

            rankings.Load("./Tests/Ranking/Few elements.csv");
            rankings.Display();
            Console.ReadKey(true);
            rankings.Clear();

            rankings.Load("./Tests/Ranking/Few really long elements.csv");
            rankings.Display();
            Console.ReadKey(true);
            rankings.Clear();

            rankings.Load("./Tests/Ranking/Many elements.csv");
            rankings.Display();
            Console.ReadKey(true);
            rankings.Clear();

            rankings.Load("./Tests/Ranking/Many really long elements.csv");
            rankings.Display();
            Console.ReadKey(true);
        }

        /// <summary>
        /// Displays a test to the <see cref="Console"/>
        /// </summary>
        /// <param name="name">test name</param>
        /// <param name="expected">expected value</param>
        /// <param name="actual">actual value</param>
        /// <param name="hashcode">the <paramref name="expected"/> value is hashcode or not (default = false)</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="int[0]"/></c></term>
        ///       <description>number of successful <see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[1]"/></c></term>
        ///       <description>number of successful <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[2]"/></c></term>
        ///       <description>number of <see langword="non"/>-<see cref="Object.GetHashCode()"/> comparison</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="int[3]"/></c></term>
        ///       <description>number of <see cref="Object.Equals(object)"/> comparison</description>
        ///     </item>
        ///   </list>
        /// </returns>
        private static int[] Display(string name, Object expected, Object actual, bool hashcode = false)
        {
            expected = expected ?? 0;
            actual = actual ?? 0;

            int e = expected.GetHashCode();
            int a = actual.GetHashCode();

            ConsoleColor color = a.Equals(e) ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;

            Console.WriteLine(name);

            Console.Write("\tExpected.GetHashCode: ");
            Console.ForegroundColor = color;
            Console.WriteLine(e);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\tActual.GetHashCode:   ");
            Console.ForegroundColor = color;
            Console.WriteLine(a);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\tEquals: ");
            color = actual.Equals(expected) ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
            Console.ForegroundColor = hashcode ? ConsoleColor.DarkGray : color;
            Console.WriteLine(actual.Equals(expected));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            return new int[] { e == a ? 1 : 0, actual.Equals(expected) ? 1 : 0, hashcode ? 0 : 1, 1 };
        }

        /// <summary>
        /// Increases the <paramref name="successful"/> results
        /// </summary>
        /// <param name="successful">successful values (may be modified)</param>
        /// <param name="placeholder">increaser values</param>
        private static void SuccessAdd(ref int[] successful, int[] placeholder)
        {
            for (int i = 0; i < 4; i++)
            {
                successful[i] += placeholder[i];
            }
        }
    }
}
