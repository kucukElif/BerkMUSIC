using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
   public interface IPhotoService
    {
        List<Photo> GetActive();
        void Add(Photo entity);
        void Update(Photo entity);
        void Remove(Guid id);
        Photo GetById(Guid id);
    }
}
