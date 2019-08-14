using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LearnDataStructure.Lists;
using Xunit;
using Xunit.Abstractions;
using LearnDataStructure.Trees;
using Xunit.Sdk;

namespace UnitTest.DataStructure
{
   public class BinarySearchTreeTest
    {
        private readonly ITestOutputHelper output;

        public BinarySearchTreeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// 二叉查找树测试
        /// </summary>
        [Fact]
        public  void DoTest()
        {
            BinarySearchTree tree = new BinarySearchTree();

            /* Let us create following BST  
                50  
            / \  
            30 70  
            / \ / \  
            20 40 60 80 */
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);


            output.WriteLine("Inorder traversal of the given tree");
            tree.Inorder();

            output.WriteLine("\nDelete 20");
            tree.Delete(20);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.Inorder();

            output.WriteLine("\nDelete 30");
            tree.Delete(30);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.Inorder();

            output.WriteLine("\nDelete 50");
            tree.Delete(50);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.Inorder();
        }
    }
}
