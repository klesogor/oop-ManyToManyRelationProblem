using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Specification
{
    class ByIdSpecification : ISpecification<Entity>
    {
        private readonly Guid _id;

        public ByIdSpecification(Guid id)
        {
            _id = id;
        }
        public bool SatisfiedBy(Entity item)
        {
            return item.id == _id;
        }
    }
}
