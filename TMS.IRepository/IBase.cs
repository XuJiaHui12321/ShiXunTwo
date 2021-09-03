using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.IRepository
{
    public interface IBase<T>
    {
        List<T> Show();
        bool Add(T t);
        bool Delete(int Id);
        T Edit(int Id);
        bool Update(T t);
    }
}
