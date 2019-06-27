using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class Son:Father
    {
        public override void Print()
        {
            //base.Print();
            Console.WriteLine("Son-Print");
        }

        public new void PrintNew()
        {
            //base.Print();
            Console.WriteLine("Son-Print");
        }
    }
}
