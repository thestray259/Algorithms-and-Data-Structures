using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Labs; 

namespace Tests
{
    class IsomorphTests
    {
        [Test]
        public void GetNameTest()
        {
            string name = Isomorphics.GetName("oajeoifjaod <John Doe> aopjefpadijfadijf");
            Assert.AreEqual("John Doe", name); 
        }
    }
}
