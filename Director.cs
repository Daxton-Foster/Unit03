using System;
using System.Collections.Generic;

namespace Unit03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Word word = new Word();
        private bool isPlaying = true;
        private Jumper jumper = new Jumper();
        private TerminalService terminalService = new TerminalService();
        private string guess = "";
        private bool correct = true;
        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }
        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            //terminalService.WriteText(string.Join(' ',word.CreateHint()));
            word.CreateHint();
            jumper.CreateJumper();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }
        private void GetInputs()
        {
            terminalService.WriteText(string.Join(' ',word.GetHint()));
            jumper.PrintJumper();
            guess = terminalService.ReadText("\nGuess a letter [a-z]: ");
        }
        private void DoUpdates()
        {
            List<string> currenthint = new List<string>();
            foreach (string letter in word.hint)
            {
                currenthint.Add(letter);
            }
            word.UpdateHint(guess);
            int i = 0;
            correct = false;
            foreach (string letter in word.hint)
            {
                if (word.hint[i] != currenthint[i])
                {
                    correct = true;
                }
                i = i + 1;
            }
            if (correct == false)
            {
                jumper.FailedJump();
            }
        }
        private void DoOutputs()
        {
            isPlaying = jumper.DeadJump(isPlaying);
            if (isPlaying == true)
            {
                isPlaying = word.Continue(isPlaying);
            }
            if (isPlaying == false)
            {
                jumper.PrintJumper();
                terminalService.WriteText(string.Join(' ',word.GetHint()));
            }
        }
    }
}