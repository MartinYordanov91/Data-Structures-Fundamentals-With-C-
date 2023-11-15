namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree<int>(10,  new Tree<int>(20,   new Tree<int>(30),
                                                             new Tree<int>(31),
                                                             new Tree<int>(32)),

                                         new Tree<int>(21  , new Tree<int>(33),
                                                             new Tree<int>(34),
                                                             new Tree<int>(35)),

                                         new Tree<int>(22,   new Tree<int>(36),
                                                             new Tree<int>(37)));

            Console.WriteLine(string.Join(", ", tree.OrderBfs()));
            tree.Swap(20,37);
            Console.WriteLine(string.Join(", ", tree.OrderBfs()));
            
        }
    }
}
