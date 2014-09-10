using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Domain.Mapper
{
    public abstract class BaseMapper
    {
        protected readonly DbModelBuilder _builder;

        protected BaseMapper(DbModelBuilder builder)
        {
            this._builder = builder;
        }

        public abstract void RegisterMapping();
    }
}
