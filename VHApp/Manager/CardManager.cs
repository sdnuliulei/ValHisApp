using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHIS;

namespace VHApp.Manager
{
    public class CardManager
    {
        private ICard card;

        private Module module;

        public CardManager(ICard card, Module module)
        {
            this.module = module;
            this.card = card;
        }

        public virtual string Create()
        {
            return module.Excute("12323","next");
        }
    }
}
