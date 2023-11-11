﻿using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Interfaces
{
    public interface INewsRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
