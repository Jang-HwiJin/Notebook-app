using System;
using System.Collections.Generic;

namespace NotebookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook(); // Setting the commands
            NotebookLogger notebookLoger = new NotebookLogger(notebook);
            const string ExitProgramKeyword = "exit";

            // String for when input is incorrect command
            string commandPrompt = "Please enter " + notebook.show + ", " + notebook.delete + ", " + notebook._new + ", or " + notebook.log;
            
            Console.WriteLine(Notebook.Intromessage); // Output the intro message
            Console.WriteLine(commandPrompt);

            string input = "";

            do {
                input = Console.ReadLine(); // Read input from user
                string[] commands = input.Split(); // Split input into array of strings

                // try-catch block to see if user inputs correct command
                // in catch block, output the appropriate available commands
                try {
                    // Get the first command (show/new/delete)
                    // and pass the second command to the functions
                    notebook[commands[0]]((commands.Length > 1) ? commands[1] : "");
                } catch(KeyNotFoundException) {
                    if (input != ExitProgramKeyword) Console.WriteLine(commandPrompt);
                }
                Console.WriteLine();

            } while (input != "exit"); // Exit only when user types exit

            Console.WriteLine(Notebook.Outromessage); // Output the outro message
        }
    }
}
