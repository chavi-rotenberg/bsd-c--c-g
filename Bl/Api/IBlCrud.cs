﻿//בס"ד

using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlCrud<T>
    {
        List<T> Get();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

    }
}
