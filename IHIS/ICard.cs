﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHIS
{
    public interface ICard:IDependency
    {
        bool Check(string CardNo);

        bool Create();
    }
}
