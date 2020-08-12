using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
  public  interface IPriceService
    {
        List<Price> GetActive();
        void Add(Price entity);
        void Update(Price entity);
        void Remove(Guid id);
        Price GetById(Guid id);

    }
}
