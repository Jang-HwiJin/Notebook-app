using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookApp
{


    public struct PageData
    {
        public string title;
        public string author;
    }

    public interface IPageable
    {
        PageData MyData { get; set; }
        // How we are going to input our item
        IPageable Input();
        // How we output this item
        void Output();
    }
}
