using NUnit.Framework;
using System;
namespace SingletonPattern
{
    [TestFixture]
    public class MySingletonClassTest
    {
        [Test]
        public void TestSingleton()
        {
            var firstObject = MySingletonClass.Instance;
            var secondobject = MySingletonClass.Instance;
            Assert.AreSame(firstObject, secondobject); //pointing to same item on the heap
            firstObject.Dispose();
            secondobject.Dispose();
        }
    }

}
