using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Specification
{
    public interface ISpecification<in T>
    {
        bool SatisfiedBy(T item);
    }
}
