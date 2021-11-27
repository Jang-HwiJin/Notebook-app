using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{
    class TextualMessage : IPageable
    {
        protected PageData myData;
        protected string message;

        
        public virtual IPageable Input()
        {
            Console.WriteLine("Please type your name:");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please type the message title:");
            myData.title = Console.ReadLine();
            Console.WriteLine("Please type the message");
            message = Console.ReadLine();
            return this;
               
        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("/--------------- Message ---------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: " + myData.author);
            Console.WriteLine(" Message: \n \n" + message);
            Console.WriteLine("\\---------------------------------------/");
        }

        public PageData MyData {
            get {
                return myData;
            }
            set {
                myData = value;
            }
        }

    }
}
