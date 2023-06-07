global using System.Linq.Expressions;

global using IntegratedProtection.Core.CentralSecurity;
global using IntegratedProtection.Core.CivilRegistry;
global using IntegratedProtection.Core.Traffic;
global using IntegratedProtection.Infrastructure.Configurations.CentralSecurityConfigurations;
global using IntegratedProtection.Infrastructure.Configurations.CivilRegistryConfigurations;
global using IntegratedProtection.Infrastructure.Configurations.TrafficConfigurations;
global using IntegratedProtection.Infrastructure.Context;
global using IntegratedProtection.Infrastructure.Helpers;
global using IntegratedProtection.Infrastructure.IRepositories;
global using IntegratedProtection.Infrastructure.Repositories;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;


namespace IntegratedProtection.Infrastructure;


