﻿using backend.util;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.data.Infrastructure
{
    public static class ContextInitializer
    {
        public static void ConfigurationEntity(this ModelBuilder builder, Type dbContextType)
        {
            var assemblyList = ReflectionUtil.AssemblyList;

            assemblyList.ForEach(assembly =>
            {
                var entityTypeList = new List<Type>();
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof(EntityAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        if (dbContextType == ((EntityAttribute)attribute).DbContextType)
                        {
                            builder.Entity(type);
                            entityTypeList.Add(type);
                        }
                    }
                }

                builder.ApplyConfigurationsFromAssembly(assembly, type =>
                {
                    var findType = type.GetInterface(typeof(IEntityTypeConfiguration<>).Name)
                        ?.GetGenericArguments()?.FirstOrDefault();
                    if (findType != null && entityTypeList.Contains(findType))
                    {
                        return true;
                    }
                    return false;
                });
            });
        }
    }
}
