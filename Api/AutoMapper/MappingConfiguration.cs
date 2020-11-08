using CrudReportGenerate.AutoMapper;
using AutoMapper;
using System.Collections.Generic;
using Stridely.ARTool.API.AutoMapper.Profiles;

namespace CrudReportGenerate.AutoMapper
{
    /// <summary>
    /// This class is used for register mapping profiles.
    /// </summary>
    public static class MappingConfiguration
    {
        public static IMapper RegisterProfiles()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                c => c.AddProfiles(new List<Profile>
                {
                    new CatalogProfile(),

                }));

            IMapper mapper = mapperConfiguration.CreateMapper();

            return mapper;
        }
    }
}