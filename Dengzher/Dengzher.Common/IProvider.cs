using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dengzher.Common
{
    public interface IProvider<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T t);
        void Update(int id, T @new);
        void Remove(int id);
    }
}
