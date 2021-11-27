using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{
    class MessageList : TextualMessage
    {
        private enum BulletType { Dashed, Numbered, Star }
        private BulletType bulletType;

        // Define later
        public override IPageable Input()
        {
            // Getting what bullet type user wants
            Console.WriteLine("Please type your name:");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please type the message title:");
            myData.title = Console.ReadLine();
            Console.WriteLine("What type of bullet points would you like to use?");
            Console.WriteLine("Please enter dashed, numbered, or star");

            bool goodInput = false;
            while (!goodInput)
            {
                goodInput = true;
                switch (Console.ReadLine()) // Loops until user chooses appropriate bullet type
                {
                    case "dashed":
                        bulletType = BulletType.Dashed;
                        break;
                    case "numbered":
                        bulletType = BulletType.Numbered;
                        break;
                    case "star":
                        bulletType = BulletType.Star;
                        break;
                    default:
                        Console.WriteLine("Please enter dashed, numbered, or star");
                        goodInput = false;
                        break;

                }
            }

            Console.WriteLine("Start typing your list. Every time you press enter a new item will be created.");
            Console.WriteLine("Press enter with a blank list item to end your list input.");
            //write list
            bool finishedList = false;
            int i = 1;
            while (!finishedList)
            {
                string input = Console.ReadLine();

                // If user enters nothing, list is finished
                if (input == "")
                {
                    finishedList = true;
                } else
                {
                    switch (bulletType) // Switch statement for selecting bullet type
                    {
                        case BulletType.Dashed:
                            message += "- " + input + " \n";
                            break;
                        case BulletType.Numbered:
                            message += i + ". " + input + " \n";
                            i += 1;
                            break;
                        case BulletType.Star:
                            message += "* " + input + " \n";
                            break;
                    }
                }
            }

            return this;
        }

    }
}
