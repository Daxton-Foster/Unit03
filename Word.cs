using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03.Game 
{
    public class Word
    {
        static readonly string rootFolder = @"C:\Users\daxto\OneDrive\Desktop\VS Code\Repositiory Clone\cse210-student-articulate-csharp\Unit03\Game\";
        static readonly string WordPull = @"C:\Users\daxto\OneDrive\Desktop\VS Code\Repositiory Clone\cse210-student-articulate-csharp\Unit03\Game\WordPull.txt";  
        private string word = "asmoranomardicadaistinaculdacar";
        public List<string> hint = new List<string>();
        public Word()
        {
            //Random random = new Random();
            //location = random.Next(1001);
            // start with two so GetHint always works
            //distance.Add(0);
            //distance.Add(0);
        }
        public List<string> CreateHint()
        {
            char[] word = WordtoChar();
            foreach (char character in word)
            {
                hint.Add("_");
                //hint.Add(" ");
            }
            return hint;
        }
        public List<string> GetHint()
        {
            return hint;
        }
        public List<string> UpdateHint(string guess)
        {
            int iteration = 0;
            int i = 0;
            char[] word = WordtoChar();
            foreach (string letter in hint)
            {
                iteration = iteration + 1;
            }
            while (iteration - 1 >= i)
            {
                string point = word[i].ToString();
                if (guess == point)
                {
                    hint.RemoveAt(i);
                    hint.Insert(i,guess);
                }
                i = i + 1;
            }
            return hint;
        }
        public char[] WordtoChar()
        {
            if (word == "asmoranomardicadaistinaculdacar")
            {
                word = SelectWord();
            }  
            char[] wordArray = word.ToCharArray();
            return wordArray;
        }
        public bool Continue(bool win)
        {
            win = false;
            foreach (string letter in hint)
            {
                if (letter == "_")
                {
                    win = true;
                }
            }
            return win;
        }
        public string SelectWord()
        {
            string[] lines = File.ReadAllLines(WordPull);
            Random rand = new Random();
            return lines[rand.Next(lines.Length)];
        }
        
    }
}