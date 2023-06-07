global using System.Text.Json.Serialization;

global using IntegratedProtection.Application;
global using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;
global using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;
global using IntegratedProtection.Application.CentralSecurity.ViewModels;
global using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;
global using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;
global using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;
global using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;
global using IntegratedProtection.Application.CivilRegistry.ViewModels;
global using IntegratedProtection.Application.IHelpers;
global using IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;
global using IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;
global using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;
global using IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;
global using IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;
global using IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;
global using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;
global using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueries;
global using IntegratedProtection.Application.Traffic.ViewModels;
global using IntegratedProtection.Infrastructure;

global using MediatR;

global using Microsoft.AspNetCore.Mvc;

namespace IntegratedProtection.API;

