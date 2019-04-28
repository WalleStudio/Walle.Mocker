using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Main
{
    class Class1
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void test()
        {
            int i = 1
            ;
            switch (i)
            {
                case 1:
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
