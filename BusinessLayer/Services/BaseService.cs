﻿using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BaseService<TDomain, TKey> : IBaseService<TDomain, TKey> where TDomain : class 
    {
        
    }
}
