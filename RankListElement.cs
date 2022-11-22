using System;

namespace Millionaire
{
    /// <summary>
    /// Stores the information of a user
    /// </summary>
    class RankListElement
    {
        /// <summary>
        /// Gets the username
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the score of the user
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets the date of the last game
        /// </summary>
        public DateTime Date { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="RankListElement"/> class
        /// </summary>
        /// <remarks><c>Constructor</c></remarks>
        /// <param name="name">username</param>
        /// <param name="score">score of the user</param>
        /// <param name="date">date of the game</param>
        public RankListElement(string name, int score, DateTime date)
        {
            Name = name;
            Score = score;
            Date = date;
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
            return $"{Name};{Score};{Date}";
        }
    }
}
