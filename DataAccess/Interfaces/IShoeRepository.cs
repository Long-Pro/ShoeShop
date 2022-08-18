﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        IEnumerable<Shoe> GetAllWithJoin();
        Shoe GetByIdWithJoin(int id);
    }
}