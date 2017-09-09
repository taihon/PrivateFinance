using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PrivateFinance.DataAccess;

namespace PrivateFinance.Web
{
    public class Mapping
    {
        public static void CreateMappings(IServiceCollection services)
        {
            var assemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load);
            assemblies = assemblies as Assembly[] ?? assemblies.ToArray();
            var types = assemblies.SelectMany(a => a.ExportedTypes).ToArray();
            var profiles = types
                .Where(t => typeof(IMappingProfile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                .Where(t => !t.GetTypeInfo().IsAbstract);
            Mapper.Initialize(config =>
                {
                    foreach (var profile in profiles)
                        config.AddProfiles(profile);
                });
        }
    }
}
