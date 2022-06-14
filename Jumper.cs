using System;
using System.Collections.Generic;

namespace Unit03.Game
{
    // TODO: Implement the Seeker class as follows...

    // 1) Add the class declaration. Use the following class comment.
    public class Jumper
    {

        public TerminalService terminalService = new TerminalService();
        private Word word = new Word();
        public List<string> jumper = new List<string>();

        /// <summary>
        /// <para>The person looking for the Hider.</para>
        /// <para>
        /// The responsibility of a Seeker is to keep track of its location.
        /// </para>
        /// </summary>

        public Jumper()
        {
        }
        /// <summary>
        /// Constructs the List of the jumper
        /// </summary>
        /// <returns>
       public void CreateJumper()
       {
           jumper.Add(@" ___ ");
           jumper.Add(@"/___\");
           jumper.Add(@"\   /");
           jumper.Add(@" \ / ");
           jumper.Add("  0  ");
           jumper.Add(@" /|\ ");
           jumper.Add(@" / \ ");
       }
        /// <summary>
        /// Prints the Jumper
        /// </summary>
        public void PrintJumper()
        {
            foreach (string line in jumper)
            {
                terminalService.WriteText(line);
            }
        }
        public void FailedJump()
        {
            jumper.RemoveAt(0);
        }
        public bool DeadJump(bool isPlaying)
        {
            if (jumper[0] == ("  0  "))
            {
                isPlaying = false;
                jumper[0] = ("  x  ");
            }
            return isPlaying;
        }

    }
}