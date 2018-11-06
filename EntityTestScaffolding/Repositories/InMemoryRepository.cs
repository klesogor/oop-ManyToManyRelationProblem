using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTestScaffolding.Specification;

namespace EntityTestScaffolding.Repositories
{
    class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        public static IRepository<T> GetInstance()
        {
            if (_instance == null) {
                _instance = new InMemoryRepository<T>();
            }

            return _instance;
        }

        private static InMemoryRepository<T> _instance;

        private readonly List<T> _repo;

        private InMemoryRepository()
        {
            _repo = new List<T>();
        }

        public void Delete(T entity)
        {
            _repo.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repo;
        }

        public T GetById(Guid guid)
        {
            var spec = new ByIdSpecification(guid);
            return _repo.Where(x => spec.SatisfiedBy(x)).First();
        }

        public IEnumerable<T> GetBySpecification(ISpecification<T> specification)
        {
            return 
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
