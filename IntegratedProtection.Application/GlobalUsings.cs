global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Net;
global using System.Reflection;

global using AutoMapper;

global using IntegratedProtection.Application.Bases;
global using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;
global using IntegratedProtection.Application.CentralSecurity.ViewModels;
global using IntegratedProtection.Application.CivilRegistry.ViewModels;
global using IntegratedProtection.Application.IHelpers;
global using IntegratedProtection.Application.IntegratedProtection.ViewModels;
global using IntegratedProtection.Application.Traffic.ViewModels;
global using IntegratedProtection.Core.CentralSecurity;
global using IntegratedProtection.Core.CivilRegistry;
global using IntegratedProtection.Core.Traffic;
global using IntegratedProtection.Infrastructure.Helpers;
global using IntegratedProtection.Infrastructure.IRepositories;

global using MediatR;

global using Microsoft.AspNetCore.Http;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;



namespace IntegratedProtection.Application;
