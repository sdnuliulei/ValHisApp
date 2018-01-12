using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHIS;

namespace HIS
{
    public class Card : ICard
    {
        public virtual bool Check(string CardNo)
        {
            Console.WriteLine("校验卡号：" + CardNo);
            return true;
        }

        public virtual bool Create()
        {
            Console.WriteLine("创建卡");
            return true;
        }
    }

    public class TestAA
    {
        string text { set; get; }

        internal string Test()
        {
            return "";
        }
    }

    public class TestBB:TestAA
    {
        public TestBB()
        {
            
        }

        internal void TestAB()
        {
            
        }
    }
}
