﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP.LSP_Violation
{
    public class Administrator : User
    {
        public override double GetPrivilegesInPercent(double privileges)
        {
            return privileges * 100;
        }
    }
}
