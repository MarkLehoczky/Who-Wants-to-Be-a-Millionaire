using System;
using System.IO;
using System.Text;

namespace Millionaire
{
    /// <summary>
    /// Creates, Reads, and Deletes all <see cref="QuestionListElement"/> in a dinamically changing array
    /// </summary>
    class QuestionList
    {
        /// <summary>
        /// Gets whether the <see cref="QuestionList"/> is empty
        /// </summary>
        /// <value>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <see cref="QuestionList"/> is empty</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <see cref="QuestionList"/> is not empty</description>
        ///     </item>
        ///   </list>
        /// </value>
        public bool IsEmpty { get { return Length == 0; } }

        /// <summary>
        /// Gets the <paramref langword="Length"/> of the <see cref="QuestionList"/>
        /// </summary>
        /// <value>Number of elements in the <see cref="QuestionList"/></value>
        public int Length { get { return questions.Length; } }

        /// <summary>
        /// Stores every <see cref="QuestionListElement"/> in an array
        /// </summary>
        private QuestionListElement[] questions;

        /// <summary>
        /// <see langword="static"/> <see cref="Random"/> variable
        /// </summary>
        private static readonly Random rnd;



        /// <summary>
        /// Initializes the <see langword="static"/> members of the <see cref="QuestionList"/> class
        /// </summary>
        static QuestionList()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Initializes a new <see langword="empty"/> instance of the <see cref="QuestionList"/> class
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        public QuestionList()
        {
            questions = new QuestionListElement[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionList"/> class with one <paramref name="element"/>
        /// </summary>
        /// <param name="element">new element</param>
        /// <remarks><c>Constructor</c></remarks>
        public QuestionList(QuestionListElement element)
        {
            questions = new QuestionListElement[1];
            questions[0] = element;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionList"/> class with multiple <paramref name="elements"/>
        /// </summary>
        /// <param name="elements">new elements</param>
        /// <remarks><c>Constructor</c></remarks>
        public QuestionList(QuestionListElement[] elements)
        {
            questions = new QuestionListElement[elements.Length];

            for (int i = 0; i < elements.Length; i++)
                questions[i] = elements[i];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionList"/> class with an existing <see cref="QuestionList"/>
        /// </summary>
        /// <param name="elements">new elements from a <see cref="QuestionList"/></param>
        /// <remarks><c>Constructor</c></remarks>
        public QuestionList(QuestionList elements)
        {
            this.questions = elements.questions;
        }



        /// <summary>
        /// Adds a new <paramref name="element"/> to the end of the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="element">new element</param>
        /// <returns><see langword="index"/> of the new <paramref name="element"/></returns>
        public int Add(QuestionListElement element)
        {
            QuestionListElement[] temp = new QuestionListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = questions[i];

            questions = new QuestionListElement[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
                questions[i] = temp[i];

            questions[questions.Length - 1] = element;

            return IndexOf(element) ?? -1;
        }

        /// <summary>
        /// Adds multiple new <paramref name="elements"/> to the end of the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="elements">new elements</param>
        /// <returns><see langword="index"/> of the first new element</returns>
        public int Add(QuestionListElement[] elements)
        {
            QuestionListElement[] temp = new QuestionListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = questions[i];

            questions = new QuestionListElement[temp.Length + elements.Length];
            for (int i = 0; i < temp.Length; i++)
                questions[i] = temp[i];

            int counter = 0;
            for (int i = temp.Length; i < (temp.Length + elements.Length); i++)
                questions[i] = elements[counter++];

            return IndexOf(elements[0]) ?? -1;
        }

        /// <summary>
        /// Adds multiple new <paramref name="elements"/> from an existing <see cref="QuestionList"/> to the end of the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="elements">new elements from a <see cref="QuestionList"/></param>
        /// <returns><see langword="index"/> of the first new element</returns>
        public int Add(QuestionList elements)
        {
            QuestionListElement[] temp = new QuestionListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = questions[i];

            questions = new QuestionListElement[temp.Length + elements.Length];
            for (int i = 0; i < temp.Length; i++)
                questions[i] = temp[i];

            int counter = 0;
            for (int i = temp.Length; i < (temp.Length + elements.Length); i++)
                questions[i] = elements.Get(counter++);

            return IndexOf(elements.Get(0)) ?? -1;
        }

        /// <summary>
        /// Removes all elements from the <see cref="QuestionList"/>
        /// </summary>
        public void Clear()
        {
            questions = new QuestionListElement[0];
        }

        /// <summary>
        /// Determines whether an <paramref name="element"/> is in the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="element">foundable element</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="element"/> is found</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="element"/> is not found</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool Contains(QuestionListElement element)
        {
            int i = 0;
            while (i < Length && !element.Equals(questions[i])) i++;

            if (i < Length) return true;
            else return false;
        }

        /// <summary>
        /// Gets the element at the <paramref name="index"/>
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see cref="QuestionListElement"/></term>
        ///       <description>the <paramref name="index"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <paramref name="index"/> is incorrect</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public QuestionListElement Get(int index)
        {
            if (index < 0 || index >= Length) return null;
            else return questions[index];
        }

        /// <summary>
        /// Gets the elements with the <paramref name="difficulty"/>
        /// </summary>
        /// <param name="difficulty">difficulty</param>
        /// <returns>elements with the <paramref name="difficulty"/></returns>
        public QuestionList GetAllByDifficulty(int difficulty)
        {
            QuestionList temp = new QuestionList();

            for (int i = 0; i < Length; i++)
                if (questions[i].Difficulty == difficulty)
                    temp.Add(questions[i]);

            return temp;
        }

        /// <summary>
        /// Gets a randomly selected element with the <paramref name="difficulty"/>
        /// </summary>
        /// <param name="difficulty">difficulty</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see cref="QuestionListElement"/></term>
        ///       <description><see langword="random"/> element with the <paramref name="difficulty"/></description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <paramref name="difficulty"/> is invalid</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public QuestionListElement GetRandomByDifficulty(int difficulty)
        {
            if (GetAllByDifficulty(difficulty).IsEmpty) return null;
            else return GetAllByDifficulty(difficulty).Get(rnd.Next(GetAllByDifficulty(difficulty).Length));
        }

        /// <summary>
        /// Gets a randomly selected element with the first usable <paramref name="difficulty"/> (may not be the same difficulty as the specified one)
        /// </summary>
        /// <param name="difficulty">base difficulty</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see cref="QuestionListElement"/></term>
        ///       <description><see langword="random"/> element with the first usable <paramref name="difficulty"/> (may not be the same difficulty as the specified one)</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <see cref="QuestionList"/> is <see langword="empty"/></description>
        ///     </item>
        ///   </list>
        /// </returns>
        public QuestionListElement GetRandomByUsableDifficulty(int difficulty)
        {
            if (IsEmpty) return null;
            else return GetAllByDifficulty(GetUsableDifficulty(difficulty) ?? 0).Get(rnd.Next(GetAllByDifficulty(GetUsableDifficulty(difficulty) ?? 0).Length));
        }

        /// <summary>
        /// <para>Gets the first usable <paramref name="difficulty"/></para>
        /// <para>If the base <paramref name="difficulty"/> is not found, then is searches for the closest usable <paramref name="difficulty"/> starting with the lower value</para>
        /// </summary>
        /// <remarks><c>Recursive method</c></remarks>
        /// <param name="difficulty">base difficulty</param>
        /// <param name="modify">difficulty's modifier (default = 0)</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see cref="int"/></term>
        ///       <description>first available <paramref name="difficulty"/> of the <see cref="QuestionList"/></description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <see cref="QuestionList"/> is <see langword="empty"/></description>
        ///     </item>
        ///   </list>
        /// </returns>
        public int? GetUsableDifficulty(int difficulty, int modify = 0)
        {
            if (GetAllByDifficulty(difficulty + modify).IsEmpty)
                if (IsEmpty || (difficulty - modify < 1 && difficulty + modify > 15 || difficulty - modify > 15 && difficulty + modify < 1)) return null;
                else if (modify >= 0) return GetUsableDifficulty(difficulty, (modify + 1) * -1);
                else return GetUsableDifficulty(difficulty, modify * -1);

            return difficulty + modify;
        }

        /// <summary>
        /// Returns the <see langword="index"/> of the first occurrence of the <paramref name="element"/> in the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="element">foundable element</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see langword="index"/></term>
        ///       <description>the <see langword="index"/> of the first occurrence of the <paramref name="element"/></description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <paramref name="element"/> is not found</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public int? IndexOf(QuestionListElement element)
        {
            int i = 0;
            while (i < Length && !element.Equals(questions[i])) i++;

            if (i < Length) return i;
            else return null;
        }

        /// <summary>
        /// Loads the elements from a <paramref name="file"/>
        /// </summary>
        /// <param name="file">file (default = "./Questions.csv")</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="file"/> exists</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="file"/> does not exist</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool Load(string file = "./Questions.csv")
        {
            if (!File.Exists(file)) return false;

            StreamReader sr = new StreamReader(file, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(';');

                if (temp.Length == 7 && int.TryParse(temp[0], out int difficulty) && char.TryParse(temp[6], out char correct))
                {
                    if ((difficulty <= 15 && difficulty >= 1) && (correct == 'A' || correct == 'B' || correct == 'C' || correct == 'D'))
                    {
                        Add(new QuestionListElement(difficulty, temp[1], temp[2], temp[3], temp[4], temp[5], correct));
                    }
                }
            }

            sr.Close();

            return true;
        }

        /// <summary>
        /// Removes the first occurrence of an <paramref name="element"/> from the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="element"/> is found</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="element"/> is not found</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool Remove(QuestionListElement element)
        {
            if (!Contains(element)) return false;

            QuestionListElement[] temp = new QuestionListElement[Length - 1];
            int counter = 0;
            bool found = false;

            for (int i = 0; i < Length; i++)
                if (found || !element.Equals(questions[i]))
                    temp[counter++] = questions[i];
                else
                    found = true;

            questions = temp;
            return true;
        }

        /// <summary>
        /// Removes the element at the <paramref name="index"/> of the <see cref="QuestionList"/>
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="index"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="index"/> is incorrect</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length) return false;

            QuestionListElement[] temp = new QuestionListElement[Length - 1];
            int counter = 0;

            for (int i = 0; i < Length; i++)
                if (i != index)
                    temp[counter++] = questions[i];

            questions = temp;

            return true;
        }

        /// <summary>
        /// Saves all elements to a <paramref name="file"/>
        /// </summary>
        /// <param name="file">file (default = "./Questions.csv")</param>
        public void Save(string file = "./Questions.csv")
        {
            StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8);

            for (int i = 0; i < Length; i++)
                sw.WriteLine($"{questions[i].Difficulty};{questions[i].Question};{questions[i].A};{questions[i].B};{questions[i].C};{questions[i].D};{questions[i].Correct}");

            sw.Close();
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
            string temp = "";

            foreach (var item in questions)
                temp += item.ToString() + '\n';

            return temp;
        }
    }
}
