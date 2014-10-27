using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Mapper.CreateMap<OledbConnection, IOledbConnectionBO>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<DataObject, IDataObjectBO>()
                   .IgnoreAllNonExisting();

            Mapper.CreateMap<ColumnDefinition, IColumnDefinitionBO>()
              .IgnoreAllNonExisting();

            Mapper.CreateMap<OleDbDataObject, IOleDbDataObjectBO>()
                  .IgnoreAllNonExisting();


            //Mapper.CreateMap<OleDbDataObject, OleDbDataObjectBO>()
            //     .IgnoreAllNonExisting();
           

        }
    }
}
