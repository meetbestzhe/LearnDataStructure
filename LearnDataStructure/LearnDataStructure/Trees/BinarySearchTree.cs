//C# program to demonstrate delete
//operation in binary search trees

//https://www.youtube.com/watch?v=gcULXE7ViZw
//https://www.geeksforgeeks.org/binary-search-tree-data-structure/
//https://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/   recursive way 
//https://www.geeksforgeeks.org/inorder-predecessor-successor-given-key-bst/   iterative  way
using System;
using System.ComponentModel.Design.Serialization;

namespace LearnDataStructure.Trees
{
    /// <summary>
    /// The left subtree of a node contains only nodes with keys lesser than the node’s key.
    /// The right subtree of a node contains only nodes with keys greater than the node’s key.
    /// The left and right subtree each must also be a binary search tree.
    /// There must be no duplicate nodes.
    /// </summary>
   public class BinarySearchTree
    {

        private Node pre;

        public Node Pre
        {
            get { return pre; }
            set { pre = value; }
        }
        private Node suc;

        public Node Suc
        {
            get { return suc; }
            set { suc = value; }
        }



        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        //this method mainly calls insertRec()
        public   void Insert(int key)
        {
            root = InsertRec(root, key);
        }

        //a recursive function to insert a new key in BST
        private   Node InsertRec(Node root, int key)
        {
            //if the tree is empty,retrun a new node
            if (root == null)
            {
                root =new Node(key);
                return root; 
            }

            //otherwise ,recur down the tree
            if (key<root.Key)
            {
                root.Left = InsertRec(root.Left, key);
            }
            if (key > root.Key)
            {
                root.Right = InsertRec(root.Right, key);
            }
            //return the (unchanged) node pointer
            return root;

            //自己刚开始时，尝试的写法，还是递归好用
            //while (root!=null)
            //{

            //    if (key<root.Key)
            //    {
            //        if (root.Left==null)
            //        {
            //            root.Left=new Node(key);
            //            return root;
            //        }

            //        root = this.root.Left;
            //    }
            //    else if (key > root.Key)
            //    {
            //        if (root.Right == null)
            //        {
            //            root.Right = new Node(key);
            //            return root;
            //        }

            //        root = root.Right;
            //    }
            //}

            return root;
        }
        
        //this method mainly calls DeleteRec
        public void Delete(int key)
        {
            root = DeleteRec(root, key);
        }
        //A recursive function to delete key in BST
        private  Node DeleteRec(Node root, int key)
        {
            //Base Case: If the tree is empty and
            //No value in this tree at last;
            if (root==null)
            {
                return root;
            }

            //Otherwise,recur down the tree
            if (key<root.Key)
            {
                root.Left = DeleteRec(root.Left, key);
            }
            else if (key > root.Key)
            {
                root.Right = DeleteRec(root.Right, key);
            }
            else  //find the Node to delete
            {
                //Case1:Node has no children
                if (root.Left==null &&root.Right==null)
                {
                    root = null;
                }
                //Case2:Node has one children
                else if (root.Left==null) //
                {
                    return root.Right; 
                }
                else if (root.Right==null)
                {
                    return root.Left;
                }
                //case 3 :Node has two children
                else
                {
                    root.Key = MinValue(root.Right);
                    //this will change to situation Case1 or Case2
                    root.Right = DeleteRec(root.Right, root.Key);
                }
               
            }

            return root;
        }

        //this method mainly calls SearchRec
        public  Node Search(int key)
        {
            return SearchRec(root, key);
        }
        //A resursive function to search key in BST
        private  Node SearchRec(Node root, int key)
        {
            if (root == null|| root.Key == key)
            {
                return root;
            }
            if (root.Key < key)
            {
                return SearchRec(root.Right, key);
            }
            else if (root.Key>key)
            {
                return SearchRec(root.Left, key);
            }

            return root;

        }

        //get left and left ... min value
       private int MinValue(Node root)
        {
            int minv = root.Key;
            while (root.Left!=null)
            {
                minv = root.Left.Key;
                root = root.Left;
            }

            return minv;
        }

        public void FindPreSuc(int key)
        {
            FindPreSucRec(root, key);
        }

        //A utility function to Find Predecessor and Successor
        private void FindPreSucRec(Node root, int key)
        {
            //Base Case
            if (root ==null)
            {
                return;
            }
            //if key is present at root
            if (root.Key == key)
            {
                //the maximum value in left subtree is predecessor
                if (root.Left !=null)
                {
                    Node temp = root.Left;
                    while (temp.Right!=null)
                    {
                        temp = temp.Right;
                    }

                    Pre = temp;
                }
                //the minimum value in right subtree is successor
                if (root.Right!=null)
                {
                    Node temp = root.Right;
                    while (temp.Left != null)
                    {
                        temp = temp.Left;
                    }
                    Suc = temp;
                }

                return;
            }

            //if key is smaller than root's key ,go to left subtree
            if (key < root.Key)
            {
                suc = root;
                FindPreSucRec(root.Left,key);
            }
            else
            {
                pre = root;
                FindPreSucRec(root.Right,key);
            }

            //at last we don't need return ，because no need for return and it is at last
        }



        void PrintPostorderRec(Node root)
        {
            if (root==null)
            {
                return;
            }
            //first recur on left subtree
            PrintPostorderRec(root.Left);
            //then recur ont right subtree
            PrintPostorderRec(root.Right);
            //now deal with the node
            Console.WriteLine(root.Key+"");
        }

        void PrintInorderRec(Node root)
        {
            if (root==null)
            {
                return;
            }
            //first recur on left child
            PrintInorderRec(root.Left);
            //then print the data of node
            Console.WriteLine(root.Key+" ");
            //now recur on right child
            PrintInorderRec(root.Right);
        }

        void PrintPreorderRec(Node root)
        {
            if (root==null)
            {
                return;
            }
            Console.WriteLine(root.Key+" ");
            //then recur on left subtree
            PrintPreorderRec(root.Left);
            //now recur on right subtree
            PrintPreorderRec(root.Right);
        }

        //wrappers over above recursive functions
        public void PrintPostorder() { PrintPostorderRec(root);}
        public void PrintInorder() { PrintInorderRec(root); }
        public void PrintPreorder() {PrintPreorderRec(root); }

        //function to print level order traversal of tree
        public void PrintLevelOrder()
        {
            int h = Height(root);
            for (int i = 1; i <=h; i++)
            {
                PrintGivenLevel(root, i);
            }
        }

        //Compute the height of a tree
        public int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
        
            //compute height of each subtree
            int lheight = Height(root.Left);
            int rheight = Height(root.Right);
            //use the larger one
            if (lheight>rheight)
            {
                return lheight + 1;
            }
            else
            {
                return rheight + 1;
            }
        }

        //Print nodes at the given level
        public virtual void PrintGivenLevel(Node root, int level)
        {
            if (root==null)
            {
                return;
            }
          
            if (level==1)
            {
                Console.WriteLine(root.Key + " ");
            }
            else if (level>1)
            {
                PrintGivenLevel(root.Left,level-1);
                PrintGivenLevel(root.Right,level-1 );
            }
        }


        public int GetFootSteps(int layer)
        {
            if (layer==0)
            {
                return 0;
            }
            if (layer==1)
            {
                return 1;
            }

            if (layer==2)
            {
                return 2;
            }

            if (layer==3)
            {
                return 4;
            }

            return GetFootSteps(layer - 1) +GetFootSteps(layer-2)+GetFootSteps(layer-3);
        }
    }

    public  class Node
    {
        private int key;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }


        private Node left;

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        private Node right;

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }

        //Root of Bst
        public Node(int key)
        {
            this.Key = key;
        }


    }
}
