using System;

namespace Millionaire
{
    /// <summary>
    /// <para>Stores the information about the question and the answers</para>
    /// <para>Inspects whether the answer is correct</para>
    /// <para>Displays the question and answer options to the <see cref="Console"/></para>
    /// </summary>
    class QuestionListElement
    {
        /// <summary>
        /// Gets the difficulty level of the question
        /// </summary>
        public int Difficulty { get; private set; }

        /// <summary>
        /// Gets the question
        /// </summary>
        public string Question { get; private set; }

        /// <summary>
        /// Gets all answers in an array
        /// </summary>
        public string[] Answers { get { return new string[] { A, B, C, D }; } }

        /// <summary>
        /// Gets the answer <c>A</c>
        /// </summary>
        public string A { get; private set; }

        /// <summary>
        /// Gets the answer <c>B</c>
        /// </summary>
        public string B { get; private set; }

        /// <summary>
        /// Gets the answer <c>C</c>
        /// </summary>
        public string C { get; private set; }

        /// <summary>
        /// Gets the answer <c>D</c>
        /// </summary>
        public string D { get; private set; }

        /// <summary>
        /// Gets the correct answer's character
        /// </summary>
        public char Correct { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionListElement"/> class
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        /// <param name="difficulty">difficulty of the question</param>
        /// <param name="question">question</param>
        /// <param name="a">answer <c>A</c></param>
        /// <param name="b">answer <c>B</c></param>
        /// <param name="c">answer <c>C</c></param>
        /// <param name="d">answer <c>D</c></param>
        /// <param name="correct">correct answer's character</param>
        public QuestionListElement(int difficulty, string question, string a, string b, string c, string d, char correct)
        {
            Difficulty = difficulty;
            Question = question;
            A = a;
            B = b;
            C = c;
            D = d;
            Correct = char.ToUpper(correct);
        }



        /// <summary>
        /// Returns whether the <paramref name="answer"/> is correct
        /// </summary>
        /// <param name="answer">answer</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="answer"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="answer"/> is not correct</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool CorrectAnswer(char answer)
        {
            return char.ToUpper(Correct).Equals(obj: char.ToUpper(answer));
        }

        /// <summary>
        /// Returns whether the <paramref name="answer"/> is correct
        /// </summary>
        /// <param name="answer">answer</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="answer"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="answer"/> is not correct</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool CorrectAnswer(ConsoleKey answer)
        {
            return char.ToUpper(Correct).Equals(obj: char.ToUpper((char)answer));
        }

        /// <summary>
        /// Returns whether the <paramref name="answer"/> is correct
        /// </summary>
        /// <param name="answer">answer</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="answer"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="answer"/> is not correct</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool CorrectAnswer(ConsoleKeyInfo answer)
        {
            return char.ToUpper(Correct).Equals(obj: char.ToUpper(answer.KeyChar));
        }

        /// <summary>
        /// Modifies, then displays the question and answers to the <see cref="Console"/>
        /// </summary>
        /// <param name="mode">specifies the selected helping tools</param>
        /// <param name="votes">gets and sets the vote's count (may be modified)</param>
        /// <param name="incorrects">gets and sets the halfing's characters (may be modified)</param>
        /// <param name="phone">gets whether the phone helping tool was used</param>
        public void Display(QuestionMode mode, ref int[] votes, ref char[] incorrects, bool phone)
        {
            ConsoleColor[] color = new ConsoleColor[4];
            string[] text = new string[4];

            for (int i = 0; i < 4; i++)
            {
                color[i] = ConsoleColor.Yellow;
                text[i] = $"[{(char)('A' + i)}] {Answers[i]}";
            }


            switch (mode)
            {
                case QuestionMode.Vote:
                    Vote(ref votes, ref text);
                    break;

                case QuestionMode.Half:
                    Half(ref incorrects, ref color);
                    break;

                case QuestionMode.Phone:
                    Phone(ref color);
                    break;

                case QuestionMode.Vote_Half:
                    Vote(ref votes, ref text);
                    Half(ref incorrects, ref color);
                    break;

                case QuestionMode.Vote_Phone:
                    Vote(ref votes, ref text);
                    Phone(ref color);
                    break;

                case QuestionMode.Half_Vote:
                    Half(ref incorrects, ref color);
                    HalfVote(ref votes, ref incorrects, ref text);
                    break;

                case QuestionMode.Half_Phone:
                    Half(ref incorrects, ref color);
                    Phone(ref color);
                    break;

                case QuestionMode.Phone_Vote:
                    Phone(ref color);
                    PhoneVote(ref votes, ref text);
                    break;

                case QuestionMode.Phone_Half:
                    Phone(ref color);
                    Half(ref incorrects, ref color);
                    break;

                case QuestionMode.Vote_Half_Phone:
                    Vote(ref votes, ref text);
                    Half(ref incorrects, ref color);
                    Phone(ref color);
                    break;

                case QuestionMode.Vote_Phone_Half:
                    Vote(ref votes, ref text);
                    Phone(ref color);
                    Half(ref incorrects, ref color);
                    break;

                case QuestionMode.Half_Vote_Phone:
                    Half(ref incorrects, ref color);
                    HalfVote(ref votes, ref incorrects, ref text);
                    Phone(ref color);
                    break;

                case QuestionMode.Half_Phone_Vote:
                    Half(ref incorrects, ref color);
                    Phone(ref color);
                    PhoneVote(ref votes, ref text);
                    break;

                case QuestionMode.Phone_Vote_Half:
                    Phone(ref color);
                    PhoneVote(ref votes, ref text);
                    Half(ref incorrects, ref color);
                    break;

                case QuestionMode.Phone_Half_Vote:
                    Phone(ref color);
                    Half(ref incorrects, ref color);
                    PhoneVote(ref votes, ref text);
                    break;

                case QuestionMode.Answer:
                    Answer(ref text, ref color);
                    break;

                default: break;
            }

            Program.ResetConsole();

            string lines = "";
            lines += $"\n{Program.ComplexCenterText($"{Difficulty}. {Question}")}\n\n\n\n";
            for (int i = 0; i < 4; i++)
                lines += $"{Program.ComplexCenterText(text[i])}\n\n";
            lines += $"\n\n{Program.CenterText("[S] Stop game    [V] Audience vote    [H] Half the answers    [P] Phone call").Substring(0, Program.CenterText("[S] Stop game    [V] Audience vote    [H] Half the answers    [P] Phone call").IndexOf('e') + 1)}    ";
            lines += $"\n\n{Program.CenterText("[Esc] Return to Menu")}\n";

            int lineNumbers = 0;
            for (int i = 0; i < lines.Length; i++)
                if (lines[i] == '\n') lineNumbers++;

            Console.BufferHeight = (lineNumbers) > Console.WindowHeight ? lineNumbers : Console.WindowHeight;


            Console.WriteLine($"\n{Program.ComplexCenterText($"{Difficulty}. {Question}")}\n\n\n");

            for (int i = 0; i < 4; i++)
            {
                Console.ForegroundColor = color[i];
                Console.WriteLine($"{Program.ComplexCenterText(text[i])}\n");
            }

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n{0}    ", Program.CenterText("[S] Stop game    [V] Audience vote    [H] Half the answers    [P] Phone call").Substring(0, Program.CenterText("[S] Stop game    [V] Audience vote    [H] Half the answers    [P] Phone call").IndexOf('e') + 1));

            if (votes != null) Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[V] Audience vote    ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            if (incorrects != null) Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[H] Half the answers    ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            if (phone) Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[P] Phone call");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"\n\n{Program.CenterText("[Esc] Return to Menu")}");
        }

        /// <summary>
        /// Sets the vote results and texts for the <see cref="QuestionMode.Vote"/>
        /// </summary>
        /// <param name="votes">vote results (may be modified)</param>
        /// <param name="text">texts (may be modified)</param>
        private void Vote(ref int[] votes, ref string[] text)
        {
            Random rnd = new Random();

            if (votes != null)
            {
                for (int i = 0; i < 4; i++) text[i] += $"    ( {Math.Round((votes[i] / 0.15))}% )";
                return;
            }

            votes = new int[4];

            for (int i = 0; i <= 15 - Difficulty; i++)
                votes[Correct - 'A']++;

            for (int i = 1; i < Difficulty; i++)
                votes[rnd.Next('A', 'D' + 1) - 'A']++;

            for (int i = 0; i < 4; i++)
                text[i] += $"    ( {(int)(votes[i] / 0.15)}% )";
        }
        /// <summary>
        /// Sets the incorrect answers and textcolors for the <see cref="QuestionMode.Half"/>
        /// </summary>
        /// <param name="incorrects">incorrect answers (may be modified)</param>
        /// <param name="color">textcolors (may be modified)</param>
        private void Half(ref char[] incorrects, ref ConsoleColor[] color)
        {
            Random rnd = new Random();

            if (incorrects != null)
            {
                color[incorrects[0] - 'A'] = ConsoleColor.Red;
                color[incorrects[1] - 'A'] = ConsoleColor.Red;
                return;
            }

            int fail = 0; // Fail safe, for potentially infinte loop
            incorrects = new char[2];

            do
            {
                incorrects[0] = (char)rnd.Next('A', 'D' + 1);
                incorrects[1] = (char)rnd.Next('A', 'D' + 1);
            } while (incorrects[0] == Correct || incorrects[1] == Correct || incorrects[0] == incorrects[1] && fail++ < 100);

            if (fail >= 100)
            {
                fail = 0;
                for (char i = 'A'; i <= 'D'; i++)
                {
                    if (fail < 2 && i != Correct)
                    {
                        incorrects[fail++] = i;
                    }
                }
            }

            color[incorrects[0] - 'A'] = ConsoleColor.Red;
            color[incorrects[1] - 'A'] = ConsoleColor.Red;
        }
        /// <summary>
        /// Sets the textcolors for the<see cref="QuestionMode.Phone"/>
        /// </summary>
        /// <param name="color">textcolors (may be modified)</param>
        private void Phone(ref ConsoleColor[] color)
        {
            color[Correct - 'A'] = ConsoleColor.DarkGreen;
        }
        /// <summary>
        /// Sets the vote results, incorrect answers and texts for the <see cref="QuestionMode.Vote"/> after <see cref="QuestionMode.Half"/>
        /// </summary>
        /// <param name="votes">vote results (may be modified)</param>
        /// <param name="incorrects">incorrect answers (may be modified)</param>
        /// <param name="text">texts (may be modified)</param>
        private void HalfVote(ref int[] votes, ref char[] incorrects, ref string[] text)
        {
            Random rnd = new Random();

            if (votes != null)
            {
                for (int i = 0; i < 4; i++) text[i] += $"    ( {(int)(votes[i] / 0.15)}% )";
                return;
            }

            char incorrect = 'A';
            votes = new int[4];

            for (int i = 0; i <= 15 - Difficulty; i++)
                votes[Correct - 'A']++;

            for (char i = 'A'; i <= 'D'; i++)
                if (i != Correct && i != incorrects[0] && i != incorrects[1])
                    incorrect = i;

            for (int i = 1; i < Difficulty; i++)
                if (rnd.Next(0, 2) == 0) votes[Correct - 'A']++;
                else votes[incorrect - 'A']++;

            for (int i = 0; i < 4; i++)
                text[i] += $"    ( {Math.Round((votes[i] / 0.15))}% )";
        }
        /// <summary>
        /// Sets the vote results and texts for the <see cref="QuestionMode.Vote"/> after <see cref="QuestionMode.Phone"/>
        /// </summary>
        /// <param name="votes">vote results (may be modified)</param>
        /// <param name="text">texts (may be modified)</param>
        private void PhoneVote(ref int[] votes, ref string[] text)
        {
            if (votes != null)
            {
                for (int i = 0; i < 4; i++) text[i] += $"    ( {(int)(votes[i] / 0.15)}% )";
                return;
            }

            votes = new int[4];

            for (int i = 0; i < 15; i++)
                votes[Correct - 'A']++;

            for (int i = 0; i < 4; i++)
                text[i] += $"    ( {Math.Round((votes[i] / 0.15))}% )";
        }
        /// <summary>
        /// Sets the texts and textcolors for the <see cref="QuestionMode.Answer"/>
        /// </summary>
        /// <param name="text">texts (may be modified)</param>
        /// <param name="color">textcolors (may be modified)</param>
        private void Answer(ref string[] text, ref ConsoleColor[] color)
        {
            for (int i = 0; i < 4; i++)
            {
                color[i] = ConsoleColor.DarkRed;
                text[i] = $"[{(char)('A' + i)}] {Answers[i]}";
            }

            color[Correct - 'A'] = ConsoleColor.Green;
        }



        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            if (obj.GetHashCode() != this.GetHashCode()) return false;
            if (obj.ToString() != this.ToString()) return false;

            return true;
        }

        public override int GetHashCode()
        {
            // String folding hash function
            // SOURCE: https://opendsa-server.cs.vt.edu/ODSA/Books/Everything/html/HashFuncExamp.html#string-folding

            string temp = ToString();
            long hash = 0;
            long multiplier = 1;

            for (int i = 0; i < temp.Length; i++)
            {
                multiplier = i % 4 == 0 ? 1 : multiplier * 256;
                hash += temp[i] * multiplier;
            }
            return (int)(Math.Abs(hash) % int.MaxValue);
        }

        public override string ToString()
        {
            return $"{Difficulty};{Question};{A};{B};{C};{D};{Correct}";
        }
    }
}
