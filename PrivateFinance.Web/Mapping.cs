using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using PrivateFinance.DataAccess;

namespace PrivateFinance.Web
{
    public class Mapping
    {
        public static void CreateMappings()
        {
            var all =
                Assembly
                    .GetEntryAssembly()
                    .GetReferencedAssemblies()
                    .Select(Assembly.Load)
                    .SelectMany(x => x.DefinedTypes)
                    .Where(t => typeof(IMappingProfile)
                        .GetTypeInfo()
                        .IsAssignableFrom(t.AsType()));
            foreach (var ti in all)
            {
                var type = ti.AsType();
                if (type.Equals(typeof(IMappingProfile)))
                {
                    Mapper.Initialize(config =>
                        {
                            config.AddProfiles(type);
                        });
                }
            }
        }
    }
}
