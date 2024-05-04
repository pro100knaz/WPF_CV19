using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Interfaces;
using CV19Main.Services.Interfaces;

namespace CV19Main.Services.Base
{
    abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private List<T> _Items = new List<T>();
        private int _LastId;

        protected RepositoryInMemory() { }
        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (_Items.Contains(item)) return;

            item.Id = ++_LastId;
            _Items.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _Items;
        }

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

            if (_Items.Contains(item)) return;


            var db_item = ((IRepository<T>)this).Get(id);
            if (db_item is null)
            {
                throw new InvalidOperationException("Редактируемого обьекта нет в репозитории");
            }
            Update(item, db_item);
        }


        public bool Remove(T item)
        {
            return _Items.Remove(item);
        }
        protected abstract void Update(T source, T Destination);
    }
}
