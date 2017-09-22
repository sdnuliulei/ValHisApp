using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHIS;
using VHApp.AOP;
using Autofac.Extras.DynamicProxy;

namespace VHApp.Manager
{
    [Intercept(typeof(CallLogger))]
    public class CardManager
    {
        private ICard card;

        public CardManager(ICard card)
        {
            this.card = card;
        }

        public virtual bool Create()
        {
            return card.Create();
        }
    }
}
