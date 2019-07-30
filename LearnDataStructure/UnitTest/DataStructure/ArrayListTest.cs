using System.Runtime.InteropServices.ComTypes;
using LearnDataStructure.Lists;
using Xunit;
namespace UnitTest.DataStructure
{
  public static  class ArrayListTest
    {
        [Fact]
        public static void DoTest()
        {
            int index = 0;
            var arrayList = new ArrayListNew<long>();
            for (long i = 1; i < 1000000; i++)
            {
                arrayList.Add(i);
            }

            for (int i = 1000; i < 1100; i++)
            {
                arrayList.Remove(i);
            }

            for (int i = 100000; i < 100100; i++)
            {
                arrayList.Remove(i);
            }

            var allNumnberGretorThanNieHundk = arrayList.FindAll(item => item > 900000);
            Assert.True(allNumnberGretorThanNieHundk.Count>0,"Count check failed!");

            long nineHundk = arrayList.Find(item => item == 900000);
            var indexIfNineHundK = arrayList.FindIndex(item => item == nineHundk);
            Assert.True(indexIfNineHundK!=-1,"Wrong index!");
        }

        [Fact]
        public static void DoTest2()
        {
            int capacity = 4;
            LRUDoubleList<int> lru= new LRUDoubleList<int>(capacity);
            lru.Look(1);
            lru.Look(2);
            lru.Look(1);
            lru.Look(3);
            lru.Look(4);
            lru.Look(3);
            lru.Look(5);
            lru.Look(4);
            lru.Look(6);
        }

    
    }
}
