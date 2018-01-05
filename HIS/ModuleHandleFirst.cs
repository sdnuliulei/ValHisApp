using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHIS;

namespace HIS
{
    public class ModuleHandleFirst:Module
    {
        public ModuleHandleFirst(string msg,int next):base(msg,next)
        {
        }

        public override string Excute(string args,string tt)
        {
            return this.msg+":"+this.next+":"+tt;
        }
    }
}
