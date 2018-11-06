using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Specification
{
    public class GenericSpecification<T> : ISpecification<T>
    {
        private readonly Func<T,bool> cb;

        public GenericSpecification(Func<T,bool> callback)
        {
            cb = callback;
        }

        public bool SatisfiedBy(T item)
        {
            return cb(item);
        }
    }
}
