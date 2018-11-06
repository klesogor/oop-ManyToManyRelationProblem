using EntityTestScaffolding.Repositories;
using EntityTestScaffolding.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Relations
{
    //IM RETARDED I DON'T KNOW WHAT PROXY IS PLS END MY PHP SUFFERING
    public class ManyToMany<M, O> where M : Entity where O : Entity
    {
        private IRepository<ManyToManyElement<M, O>> _repo;

        public ManyToMany()
        {
            _repo = InMemoryRepository<ManyToManyElement<M, O>>.GetInstance();
        }

        public IEnumerable<O> GetRelated(M m)
        {
            Func<ManyToManyElement<M, O>, bool> validator = (ManyToManyElement<M, O> element) => element.GetMId == m.id;

            var spec = new GenericSpecification<ManyToManyElement<M, O>>(validator);
            var relatedIds = _repo.GetBySpecification(spec).GroupBy(x => x.GetOId).Select(grp => grp.First().GetOId);

            Func<O, bool> relatedValidator = (O o) => relatedIds.Contains(o.id);
            var relatedSpec = new GenericSpecification<O>(relatedValidator);

            var tempRepo = InMemoryRepository<O>.GetInstance();

            return InMemoryRepository<O>.GetInstance().GetBySpecification(relatedSpec);
        }

        public IEnumerable<M> GetRelated(O o)
        {
            Func<ManyToManyElement<M, O>, bool> validator = (ManyToManyElement<M, O> element) => element.GetOId == o.id;
            var spec = new GenericSpecification<ManyToManyElement<M, O>>(validator);
            var relatedIds = _repo.GetBySpecification(spec).GroupBy(x => x.GetMId).Select(grp => grp.First().GetMId);

            Func<M, bool> relatedValidator = (M m) => relatedIds.Contains(m.id);
            var relatedSpec = new GenericSpecification<M>(relatedValidator);

            return InMemoryRepository<M>.GetInstance().GetBySpecification(relatedSpec);
        }

        public void Attach(O o, IEnumerable<M> mList)
        {
            foreach (var m in mList)
            {
                _repo.Save(new ManyToManyElement<M, O>(m, o));
            }
        }

        public void Attach(M m, IEnumerable<O> oList)
        {
            foreach (var o in oList)
            {
                _repo.Save(new ManyToManyElement<M, O>(m, o));
            }
        }

        public void Detach(M m)
        {
            Func<ManyToManyElement<M, O>, bool> validator = (ManyToManyElement<M, O> element) => element.GetMId == m.id;
            foreach (var related in _repo.GetBySpecification(new GenericSpecification<ManyToManyElement<M, O>>(validator)).ToList())
            {
                _repo.Delete(related);
            }
        }

        public void Detach(O o)
        {
            Func<ManyToManyElement<M, O>, bool> validator = (ManyToManyElement<M, O> element) => element.GetOId == o.id;
            foreach (var related in _repo.GetBySpecification(new GenericSpecification<ManyToManyElement<M, O>>(validator)).ToList())
            {
                _repo.Delete(related);
            }
        }
    }
}
