﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main.Services.Interfaces
{
    internal interface IAsyncDataService
    {
        string GetResult(DateTime Time);
    }
}
