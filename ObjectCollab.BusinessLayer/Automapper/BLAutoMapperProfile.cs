using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.Domain;


namespace ObjectCollab.BusinessLayer.Automapper
{
    class BLAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DataObject, IDataObjectBO>()
                   .IgnoreAllNonExisting();

            Mapper.CreateMap<OleDbDataObject, IOleDbDataObjectBO>()
                  .IgnoreAllNonExisting();
        }
    }
}
