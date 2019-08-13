using System;
using System.Collections.Generic;
using System.Text;
using LearnDataStructure.HashTable;
using LearnDataStructure.Lists;
using Xunit;

namespace UnitTest.DataStructure
{
    public static class HashTableTest
    {
        [Fact]
        public static void Dotest()
        {
            HashTableDefine<string, int> hashTable = new HashTableDefine<string, int>();
            hashTable.Add("this", 1);
            hashTable.Add("coder", 2);
            hashTable.Add("this", 4);
            hashTable.Add("hi", 5);
            hashTable.Remove("coder");
            int a = 1;

        }

        [Fact]
        public static void Dotest2()
        {
            LruByHashTableAndDoubleLink<int> hashTable = new LruByHashTableAndDoubleLink<int>(10);
            hashTable.Look(1);
            hashTable.Look(2);
            hashTable.Look(3);
            hashTable.Look(4);
            hashTable.Look(5);
            hashTable.Look(2);
            LearnDataStructure.HashTable.Node<int> head = hashTable.head;

            int a = 1;

        }
    }
}
