using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_Lab2
{
    public enum ColorNode{
        RED,
        BLACK   
    }
    class RBTree
    {
        private RBTree Parent
        {
            get; set;
        }
        private RBTree Left
        {
            get; set;
        }
        private RBTree Right
        {
            get; set;
        }
        public int Value
        {
            get; set;
        }
        private ColorNode _color;
        private Queue<RBTree> _queuePrint = new Queue<RBTree>();
        public RBTree(int value, RBTree parent = null)
        {
            Value = value;
            Parent = parent;
        }

        public void Add(int value)
        {
            if (value < Value)
            {
                if (Left == null)
                {
                    Left = new RBTree(value, this);
                }
                else
                {
                    Left.Add(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new RBTree(value, this);
                }
                else
                {
                    Right.Add(value);
                }
            }
        }

        private RBTree Search (int value)
        {
            if (this == null)
                return null;
            if (value < Value)
                return Left?.Search(value)??null;
            if (value > Value)
                return Right?.Search(value)??null;
            if (Value == value)
                return this;
            return null;
        }


        private void Remove (RBTree tree)
        {
            if (tree == null)
                return;

            //Корень
            if(tree.Parent == null)
            {
                if (tree.Left != null)
                {
                    tree.Value = tree.Left.Value;
                    Remove(tree.Left);
                }
                else if (tree.Right != null)
                {
                    tree.Value = tree.Right.Value;
                    Remove(tree.Right);
                }
                else
                    ;//TODO: удаление последнего элемента
                return;
            }
            //Лист
            if (tree.Left == null && tree.Right == null)
            {
                if (tree.Parent.Left == tree)
                    tree.Parent.Left = null;
                else
                    tree.Parent.Right = null;
            }

            //Узел с левым поддеревом
            if (tree.Left != null && tree.Right == null)
            {
                tree.Left.Parent = tree.Parent;
                if (tree.Parent.Left == tree)
                    tree.Parent.Left = tree.Left;
                else
                    tree.Parent.Right = tree.Left;
            }

            ///Узел с правым поддеревом
            if (tree.Left == null && tree.Right != null)
            {
                tree.Right.Parent = tree.Parent;
                if (tree.Parent.Left == tree)
                    tree.Parent.Left = tree.Right;
                else
                    tree.Parent.Right = tree.Right;
            }

            ///Узел с правым и левым поддеревом
            if (tree.Left != null && tree.Right != null)
            {
                RBTree current = tree.Right;
                while (current.Left != null)
                    current = current.Left;

                tree.Value = current.Value;
                Remove(current);
            }



        }

        public void Remove(int value)
        {
            RBTree tree = Search(value);
            Remove(tree);
        }


        private void Print (RBTree tree)
        {
            if (tree.Left!=null)
                Print(tree.Left);
            Console.Write(tree.Value + " ");
            if (tree.Right != null)
                Print(tree.Right);
        }

        //public void Print()
        //{
        //    int pow = 0;
        //    int count = 0;
        //    _queuePrint.Enqueue(this);
        //    Console.WriteLine();
        //    while (_queuePrint.Count!=0)
        //    {
        //        count++;
        //        RBTree tree = _queuePrint.Dequeue();
        //        if (tree != null)
        //        {
        //            //if (tree.Left != null)
        //            _queuePrint.Enqueue(tree.Left);
        //            //if (tree.Right != null)
        //            _queuePrint.Enqueue(tree.Right);
        //        }
        //        string value = tree?.Value.ToString()??"[]";
        //        Console.Write(value + " ");
        //        if (count == Math.Pow(2, pow))
        //        {
        //            Console.WriteLine();
        //            pow++;
        //        }
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}

        public void Print()
        {
            Console.WriteLine();
            Print(this);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
