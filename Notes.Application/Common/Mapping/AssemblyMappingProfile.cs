using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mapping
{
    public class AssemblyMappingProfile 
    {
        // public AssemblyMappingProfile(Assembly assembly) =>
        //     ApplyMappingsFromAssembly(assembly);
        //
        // private void ApplyMappingsFromAssembly(Assembly assembly)
        // {
        //     var types = assembly.GetExportedTypes()
        //         .Where(type =>
        //             type.GetInterfaces()
        //                 .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
        //         .ToList();
        //     foreach (var type in types)
        //     {
        //         var instance = Activator.CreateInstance(type);
        //         var methodsInfo = type.GetMethod("Mapping");
        //         methodsInfo?.Invoke(instance, new object?[] {this}); 
        //     }
        // }
    }
}