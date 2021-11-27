using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{
    class Notebook
    {
        public const string Intromessage = "Welcome to your Notebook App program v1";
        public const string Outromessage = "Thanks for using Notebook App program v1";

        List<IPageable> pages = new List<IPageable>();

        public delegate void SimpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);
        public event SimpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        public event BooleanFunction loggingToggled;

        private Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();
        public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

        public SimpleFunction this[string command]
        {
            get { return commandLineArgs[command];  }
        }

        public Notebook()
        {
            commandLineArgs.Add(show, Show);
            commandLineArgs.Add(_new, New);
            commandLineArgs.Add(delete, Delete);
            commandLineArgs.Add(log, Log);
        }

        /// <summary>
        /// Creates a new notebook with uinput keywords for commands instead of deault ones
        /// </summary>
        /// <param name="commandLineKeywords">index 0 = show, 1 = new, 2 = delete. </param>
        public Notebook(params string[] commandLineKeywords) : this() { 
            for (int i = 0; i < commandLineKeywords.Length; ++i)
            {
                // If nothing is inputted, jump to the next iteration
                if ( commandLineKeywords[i] == "")
                {
                    continue;
                }

                switch(i)
                {
                    // show
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeywords[i], Show);
                        break;
                    // new
                    case 1:
                        commandLineArgs.Remove(_new);
                        commandLineArgs.Add(_new = commandLineKeywords[i], New);
                        break;
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                        break;

                }
            }
        }

        /// <summary>
        /// Runs when the input is new
        /// </summary>
        /// <param name="command"></param>
        private void New(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("message     create new message page");
                    Console.WriteLine("list        create new list page");
                    Console.WriteLine("image       create new image page");
                    break;
                case "message":
                    pages.Add(new TextualMessage().Input()); // Adding the inputs to the pages
                    
                    if (ItemAdded != null)
                    {
                        ItemAdded("Textual Message");
                    }
                    break;
                case "list":
                    pages.Add(new MessageList().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Message List");
                    }
                    break;
                case "image":
                    pages.Add(new Image().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Image");
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("Did not enter message, list, or image. Please try again.");
                    }
                    break;
            }

        }

        /// <summary>
        /// Runs when the input is show
        /// </summary>
        /// <param name="command"></param>
        private void Show(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Show commands:");
                    Console.WriteLine("pages         lists all created pages");
                    Console.WriteLine("id of page    display that page");
                    break;
                case "pages":
                    Console.WriteLine("/--------------- Pages ---------------\\");
                    for(int i = 0; i < pages.Count; ++i)
                    {
                        Console.WriteLine("ID: " + i + " " + pages[i].MyData.title);
                    }
                    break;
                default:
                    int number;
                    if(int.TryParse(command, out number)) // If input is show #, then it will run the program
                    {
                        Console.WriteLine("Showing page " + number);

                        if(number < pages.Count) // Checking to see if page is valid
                        {
                            pages[number].Output(); // Output if available
                        }
                        else
                        {
                            if (InputBadCommand != null)
                            {
                                InputBadCommand("The inputted number was outside of the range of pages. Please try another page.");
                            }
                        }
                    } else {
                        if(InputBadCommand != null)
                        {
                            InputBadCommand("Did not enter a valid page or number. Please try again.");
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Runs when the input is delete
        /// </summary>
        /// <param name="command"></param>
        private void Delete(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Delete commands:");
                    Console.WriteLine("all         delete all created pages");
                    Console.WriteLine("id of page  delete that page");
                    break;
                case "all":
                    pages.Clear(); // Removes all the pages in the list pages

                    if (ItemRemoved != null)
                    {
                        ItemRemoved("");
                    }
                    break;
                default:
                    int number;
                    if (int.TryParse(command, out number)) // If input is delete #, then it will run the program
                    {

                        if (number < pages.Count) // If desired page to be deleted exists, then delete
                        {
                            pages.RemoveAt(number);
                            if (ItemRemoved != null)
                            {
                                ItemRemoved(number + "");
                            }
                        } else {
                            if(InputBadCommand != null)
                            {
                                InputBadCommand("The inputted number was outside of the range of available pages. Please try again.");
                            }
                        }
                    } else
                    {
                        if(InputBadCommand != null)
                        {
                            InputBadCommand("No input detected or the number provided was outside of the available range of pages. Please try again.");
                        }
                    }
                    break;
            }
        }

        private void Log(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Logger commands:");
                    Console.WriteLine("on          turn logger on");
                    Console.WriteLine("off         turn logger off");
                    break;
                case "on":
                    if(loggingToggled != null)
                    {
                        loggingToggled(true);
                    }
                    break;
                case "off":
                    if (loggingToggled != null)
                    {
                        loggingToggled(false);
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("Please enter on or off after inputting the log command.");
                    }
                    break;
            }
        }

    }
}
