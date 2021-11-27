using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{
    class NotebookLogger
    {
        private Notebook trackedNoteBook;
        private bool logging = true;

        public NotebookLogger(Notebook trackedNotebook)
        {
            this.trackedNoteBook = trackedNotebook;

            Attach();
            trackedNoteBook.loggingToggled += ToggleLogging;
        }

        private void PrintAdded(string typeItemAdded)
        {
            Console.WriteLine(typeItemAdded + " was added to the notebook.");
        }

        private void PrintDeleted(string idOfDeleted)
        {
            if(idOfDeleted != "")
            {
                Console.WriteLine("Item " + idOfDeleted + " was deleted from the notebook.");
            } else {
                Console.WriteLine("Everything was deleted from the notebook.");
            }
        }

        private void IncorrectCommand(string messageToPrint)
        {
            Console.WriteLine("Incorrect Command: " + messageToPrint);
        }

        public void ToggleLogging(bool turnOn)
        {
            string output = "Logger already " + ((turnOn) ? "on" : "off") + ".";

            if(logging)
            {
                if(!turnOn)
                {
                    Detach();
                    logging = false;
                    output = "Logger turned off.";
                }
            } else {
                if(turnOn)
                {
                    Attach();
                    logging = true;
                    output = "Logger turned on.";
                }
            }

            Console.WriteLine(output);
        }
        
        private void Attach()
        {
            trackedNoteBook.ItemAdded += PrintAdded;
            trackedNoteBook.ItemRemoved += PrintDeleted;
            trackedNoteBook.InputBadCommand += IncorrectCommand;
        }

        private void Detach()
        {
            trackedNoteBook.ItemAdded -= PrintAdded;
            trackedNoteBook.ItemRemoved -= PrintDeleted;
            trackedNoteBook.InputBadCommand -= IncorrectCommand;
        }
    }
}


