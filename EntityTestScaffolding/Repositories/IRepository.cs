using EntityTestScaffolding.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetBySpecification(ISpecification<T> specification);

        T GetById(Guid guid);

        void Save(T entity);

        void Delete(T entity);
    }
}
