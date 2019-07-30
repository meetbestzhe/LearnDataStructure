using System;
using System.Collections.Generic;
using System.Text;
using LearnDataStructure.HashTable;
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
    }
}
