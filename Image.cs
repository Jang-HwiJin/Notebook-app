using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{
    class Image : IPageable
    {
        private PageData myData;
        private string asciiImage;

        public IPageable Input()
        {
            Console.WriteLine("Please type your name:");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please type the message title:");
            myData.title = Console.ReadLine();

            Console.WriteLine("Start typing your image. Press enter to create as many lines as you like.");
            Console.WriteLine("Press Ctrl+D then enter on a single line to stop creating your image.");
            bool finishedImage = false;
            
            // input[0] will be 4 in ascii for Ctrl+D, so once that is pressed and input is length 0, it will end
            while (!finishedImage)
            {
                string input = Console.ReadLine();
                // C# short circuits && so if first condition is false, it won't check the second condition
                if ((input.Length > 0) && (input[0] == 4))
                {
                    finishedImage = true;
                } else
                {
                    asciiImage += "\t" + input + "\n";
                }
            }
            return this;
        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("/--------------- Image ---------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: " + myData.author);
            Console.WriteLine();
            Console.WriteLine(asciiImage);
            Console.WriteLine("\\---------------------------------------/");
        }

        public PageData MyData
        {
            get
            {
                return myData; ;
            }
            set
            {
                myData = value; ;
            }

        }
    }
}
