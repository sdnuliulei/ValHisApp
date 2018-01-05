using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHIS
{
    public abstract class Module:IDependency
    {
        protected string msg;
        protected int next;

        public Module(string msg,int next)
        {
            this.msg = msg;
            this.next = next;
        }

        public abstract string Excute(string args,string tt);
    }
}
