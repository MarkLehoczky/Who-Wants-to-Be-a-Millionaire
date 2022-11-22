using System;
using System.IO;
using System.Text;

namespace Millionaire
{
    /// <summary>
    /// Creates, Reads, Updates, and Deletes all <see cref="RankListElement"/> in a dinamically changing array
    /// </summary>
    class RankList
    {
        /// <summary>
        /// Gets whether the <see cref="RankList"/> is empty
        /// </summary>
        /// <value>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <see cref="RankList"/> is empty</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <see cref="RankList"/> is not empty</description>
        ///     </item>
        ///   </list>
        /// </value>
        public bool IsEmpty { get { return Length == 0; } }

        /// <summary>
        /// Gets the <paramref langword="Length"/> of the <see cref="RankList"/>
        /// </summary>
        /// <value>Number of elements in the <see cref="RankList"/></value>
        public int Length { get { return ranking.Length; } }

        /// <summary>
        /// Stores every <see cref="RankListElement"/> in an array
        /// </summary>
        private RankListElement[] ranking;



        /// <summary>
        /// Initializes a new <see langword="empty"/> instance of the <see cref="RankList"/> class
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        public RankList()
        {
            ranking = new RankListElement[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RankList"/> class with one <paramref name="element"/>
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        /// <param name="element">new element</param>
        public RankList(RankListElement element)
        {
            ranking = new RankListElement[1];
            ranking[0] = element;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RankList"/> class with multiple <paramref name="elements"/>
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        /// <param name="elements">new elements</param>
        public RankList(RankListElement[] elements)
        {
            ranking = new RankListElement[elements.Length];

            for (int i = 0; i < elements.Length; i++)
                ranking[i] = elements[i];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RankList"/> class with multiple <paramref name="elements"/>
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        /// <param name="elements">new elements from a <see cref="RankList"/></param>
        public RankList(RankList elements)
        {
            this.ranking = elements.ranking;
        }



        /// <summary>
        /// Adds a new <paramref name="element"/> to the end of the <see cref="RankList"/>
        /// </summary>
        /// <param name="element">new element</param>
        /// <returns><see langword="index"/> of the new <paramref name="element"/></returns>
        public int Add(RankListElement element)
        {
            RankListElement[] temp = new RankListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = ranking[i];

            ranking = new RankListElement[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
                ranking[i] = temp[i];

            ranking[ranking.Length - 1] = element;

            return IndexOf(element) ?? -1;
        }

        /// <summary>
        /// Adds multiple new <paramref name="elements"/> to the end of the <see cref="RankList"/>
        /// </summary>
        /// <param name="elements">new elements</param>
        /// <returns><see langword="index"/> of the first new element</returns>
        public int Add(RankListElement[] elements)
        {
            RankListElement[] temp = new RankListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = ranking[i];

            ranking = new RankListElement[temp.Length + elements.Length];
            for (int i = 0; i < temp.Length; i++)
                ranking[i] = temp[i];

            int counter = 0;
            for (int i = temp.Length; i < (temp.Length + elements.Length); i++)
                ranking[i] = elements[counter++];

            return IndexOf(elements[0]) ?? -1;
        }

        /// <summary>
        /// Adds multiple new <paramref name="elements"/> to the end of the <see cref="RankList"/>
        /// </summary>
        /// <param name="elements">new elements from a <see cref="RankList"/></param>
        /// <returns><see langword="index"/> of the first new element</returns>
        public int Add(RankList elements)
        {
            RankListElement[] temp = new RankListElement[Length];
            for (int i = 0; i < Length; i++)
                temp[i] = ranking[i];

            ranking = new RankListElement[temp.Length + elements.Length];
            for (int i = 0; i < temp.Length; i++)
                ranking[i] = temp[i];

            int counter = 0;
            for (int i = temp.Length; i < (temp.Length + elements.Length); i++)
                ranking[i] = elements.Get(counter++);

            return IndexOf(elements.Get(0)) ?? -1;
        }

        /// <summary>
        /// Removes all elements from the <see cref="RankList"/>
        /// </summary>
        public void Clear()
        {
            ranking = new RankListElement[0];
        }

        /// <summary>
        /// Determines whether an <paramref name="element"/> is in the <see cref="RankList"/>
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
        public bool Contains(RankListElement element)
        {
            int i = 0;
            while (i < Length && !element.Equals(ranking[i])) i++;

            if (i < Length) return true;
            else return false;
        }

        /// <summary>
        /// Modifies, then displays all elements to the <see cref="Console"/>
        /// </summary>
        public void Display()
        {
            int place = 1;
            Sort();

            Program.ResetConsole();
            Console.BufferHeight = (2 * Length + 6) > Console.WindowHeight ? 2 * Length + 6 : Console.WindowHeight;
            Console.Write("\n{0}\n\n", Program.CenterText("RANK LIST"));
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < Length; i++)
            {
                if (i > 0 && ranking[i - 1].Score > ranking[i].Score)
                {
                    if (place == 1) Console.ForegroundColor = ConsoleColor.Gray;
                    else if (place == 2) Console.ForegroundColor = ConsoleColor.Red;
                    else if (place == 3) Console.ForegroundColor = ConsoleColor.DarkGray;
                    place++;
                }

                string begin = " " + (ranking[i].Name.Length > 50 ? ranking[i].Name.Substring(0, 50) + "..." : ranking[i].Name) + " (" + ranking[i].Date.ToString() + ")";
                string end = "" + ranking[i].Score + "\n";

                for (int j = begin.Length + end.Length; j < Console.WindowWidth - (Console.BufferHeight > Console.WindowHeight ? 2 : 0); j++)
                {
                    begin += "_";
                }
                Console.WriteLine(begin + end);
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\n{0}", Program.CenterText("[Esc] Return to Menu"));
        }

        /// <summary>
        /// Gets the element at the <paramref name="index"/>
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><see cref="RankListElement"/></term>
        ///       <description>the <paramref name="index"/> is correct</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="null"/></c></term>
        ///       <description>the <paramref name="index"/> is incorrect</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public RankListElement Get(int index)
        {
            if (index < 0 || index >= Length) return null;
            else return ranking[index];
        }

        /// <summary>
        /// Returns the <see langword="index"/> of the first occurrence of the <paramref name="element"/> in the <see cref="RankList"/>
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
        public int? IndexOf(RankListElement element)
        {
            int i = 0;
            while (i < Length && !element.Equals(ranking[i])) i++;

            if (i < Length) return i;
            else return null;
        }

        /// <summary>
        /// Loads the elements from a <paramref name="file"/>
        /// </summary>
        /// <param name="file">file (default = "./Ranking.csv")</param>
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
        public bool Load(string file = "./Ranking.csv")
        {
            if (!File.Exists(file)) return false;

            StreamReader sr = new StreamReader(file, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(';');

                if (temp.Length == 3 && int.TryParse(temp[1], out int score) && DateTime.TryParse(temp[2], out DateTime date))
                {
                    Add(new RankListElement(temp[0], score, date));
                }
            }

            sr.Close();

            return true;
        }

        /// <summary>
        /// Removes the first occurrence of an <paramref name="element"/> from the <see cref="RankList"/>
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
        public bool Remove(RankListElement element)
        {
            if (!Contains(element)) return false;

            RankListElement[] temp = new RankListElement[Length - 1];
            int counter = 0;
            bool found = false;

            for (int i = 0; i < Length; i++)
                if (found || ranking[i] != element)
                    temp[counter++] = ranking[i];
                else
                    found = true;

            ranking = temp;
            return true;
        }

        /// <summary>
        /// Removes the element at the <paramref name="index"/> of the <see cref="RankList"/>
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

            RankListElement[] temp = new RankListElement[Length - 1];
            int counter = 0;

            for (int i = 0; i < Length; i++)
                if (i != index)
                    temp[counter++] = ranking[i];

            ranking = temp;

            return true;
        }

        /// <summary>
        /// Saves all elements to a <paramref name="file"/>
        /// </summary>
        /// <param name="file">file (default = "./Ranking.csv")</param>
        public void Save(string file = "./Ranking.csv")
        {
            StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8);

            Sort();
            for (int i = 0; i < Length; i++)
                sw.WriteLine($"{ranking[i].Name};{ranking[i].Score};{ranking[i].Date}");

            sw.Close();
        }

        /// <summary>
        /// <para>Sorts the elements in the entire <see cref="RankList"/></para>
        /// <para>Ordered by decreasing <see cref="RankListElement.Score"/> value</para> 
        /// </summary>
        /// <remarks>revised <see langword="Insertion sort"/> algorithm</remarks>
        public void Sort()
        {
            RankListElement temp;
            int j;
            for (int i = 1; i < Length; i++)
            {
                j = i - 1;
                temp = ranking[i];
                while (j >= 0 && ranking[j].Score < temp.Score)
                {
                    ranking[j + 1] = ranking[j];
                    j--;
                }
                ranking[j + 1] = temp;
            }
        }

        /// <summary>
        /// Updates the first occurrence of an <paramref name="oldElement"/> from the <see cref="RankList"/> with a <paramref name="newElement"/>
        /// </summary>
        /// <param name="oldElement">old element</param>
        /// <param name="newElement">new element</param>
        /// <returns>
        ///   <list type="table">
        ///     <item>
        ///       <term><c><see langword="true"/></c></term>
        ///       <description>the <paramref name="oldElement"/> is found</description>
        ///     </item>
        ///     <item>
        ///       <term><c><see langword="false"/></c></term>
        ///       <description>the <paramref name="oldElement"/> is not found</description>
        ///     </item>
        ///   </list>
        /// </returns>
        public bool Update(RankListElement oldElement, RankListElement newElement)
        {
            if (IndexOf(oldElement) == null) return false;
            int index = IndexOf(oldElement) ?? 0;

            ranking[index] = newElement;
            return true;
        }

        /// <summary>
        /// Updates the element at the <paramref name="index"/> from the <see cref="RankList"/> with a <paramref name="newElement"/>
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="newElement">new element</param>
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
        public bool UpdateAt(int index, RankListElement newElement)
        {
            if (index < 0 || index >= Length) return false;

            ranking[index] = newElement;
            return true;
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

            foreach (var item in ranking)
                temp += item.ToString() + '\n';

            return temp;
        }
    }
}
