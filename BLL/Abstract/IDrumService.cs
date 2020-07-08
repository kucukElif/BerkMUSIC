using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
  public  interface IDrumService
    {
        List<DrumLesson> GetActive();
        List<DrumLesson> GetDefault(Expression<Func<DrumLesson, bool>> exp);
        void Add(DrumLesson entity);
        void Update(DrumLesson entity);
        void Remove(Guid id);
        DrumLesson GetById(Guid id);
        void RemoveAll(Expression<Func<DrumLesson, bool>> exp);
        bool Any(Expression<Func<DrumLesson, bool>> exp);
    }
}
