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
        //这就是单例模式啊，兄弟
        private readonly ITestOutputHelper output;

        public BinarySearchTreeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// 二叉查找树测试
        /// </summary>
        [Fact]
        public  void DoTest1()
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
          
            LearnDataStructure.Trees.Node a = tree.Search(70);

            output.WriteLine("Inorder traversal of the given tree");
            tree.PrintInorder();

            output.WriteLine("\nDelete 20");
            tree.Delete(20);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.PrintInorder();

            output.WriteLine("\nDelete 30");
            tree.Delete(30);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.PrintInorder();

            output.WriteLine("\nDelete 50");
            tree.Delete(50);
            output.WriteLine("Inorder traversal of the modified tree");
            tree.PrintInorder();

        }

        /// <summary>
        /// 查找一个节点的前序节点和后续节点
        /// </summary>
        [Fact]
        public void DoTest2()
        {
            BinarySearchTree tree = new BinarySearchTree();

              /* Let us create following BST  
               50  
               /   \  
              30    70  
              / \  /  \  
             20 40 60  80 */
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);
       
            tree.FindPreSuc(65);
            if (tree.Pre!=null)
            {
                output.WriteLine("Predecessor is "+ tree.Pre.Key.ToString());
            }
            else 
            {
               output.WriteLine("No Predecessor");
            }

            if (tree.Suc!=null)
            {
                output.WriteLine("Successor is "+tree.Suc.Key.ToString());
            }
            else
            {
                output.WriteLine("No Successor");
            }
            output.WriteLine("");
        }


        /// <summary>
        /// 尝试写了一个递归的程序
        /// </summary>
        [Fact]
        public void DoTest3()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int footnumber= tree.GetFootSteps(9);
            Assert.Equal(footnumber, 149);
            output.WriteLine(footnumber.ToString()); 

        }

    }
}
