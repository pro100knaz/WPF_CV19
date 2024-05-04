using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Interfaces;

namespace CV19Main.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);

        void Update(int id, T item);
        bool Remove(T item);

    }
}
