using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryCoding.Models.GenericRepository {
    interface IRepository<Table> {
        void create(Table _entity);
        IEnumerable<Table> getAll();
        Table getById(int id);
        void update(Table _entity);
        void delete(int id);
    }
}