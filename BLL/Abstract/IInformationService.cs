using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
  public  interface IInformationService
    {
        Information GetById(Guid id);
        void Add(Information entity);
        void Remove(Guid id);
        List<Information> GetActive();
        void Update(Information entity);
    }
}
