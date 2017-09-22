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
        public bool Check(string CardNo)
        {
            Console.WriteLine("校验卡号：" + CardNo);
            return true;
        }

        public bool Create()
        {
            Console.WriteLine("创建卡");
            return true;
        }
    }
}
