﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestScaffolding
{
    public class Entity
    {
        public readonly Guid id;

        public Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
