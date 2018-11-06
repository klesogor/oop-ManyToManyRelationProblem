using EntityTestScaffolding.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding.Relations
{
    public class ManyToManyElement<M,O> : Entity where M : Entity where O : Entity 
    {
        //I was really tired, so no more abstractions today, folks. I really should have
        //implemented many to one and one to one, but maybe i would do it later(never)

        public Guid GetMId { get; private set; }
        public Guid GetOId { get; private set; }

        public ManyToManyElement(M m, O o):base()
        {
            GetMId = m.id;
            GetOId = o.id;
        }
    }
}
