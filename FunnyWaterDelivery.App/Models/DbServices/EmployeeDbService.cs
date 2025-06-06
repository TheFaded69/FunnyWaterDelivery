﻿using System.Collections.ObjectModel;
using AutoMapper;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Common.Enums;
using FunnyWaterDelivery.Database.Models;
using FunnyWaterDelivery.Database.Repository;

namespace FunnyWaterDelivery.App.Models.DbServices;

public class EmployeeDbService : IEmployeeDbService
{
    public EmployeeDbService(IMapper mapper, IRepositoryCreator<DbEmployee, Guid> repositoryCreator)
    {
        _mapper = mapper;
        _repositoryCreator = repositoryCreator;
    }
    
    private readonly IMapper _mapper;
    private readonly IRepositoryCreator<DbEmployee, Guid> _repositoryCreator;

    public DbEmployee Create(EmployeeRowViewModel employeeRowViewModel)
    {
        try
        {
            var employee = _mapper.Map<DbEmployee>(employeeRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Insert(employee);
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public DbEmployee Update(EmployeeRowViewModel employeeRowViewModel)
    {
        try
        {
            var employee = _mapper.Map<DbEmployee>(employeeRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Update(employee);
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(EmployeeRowViewModel employeeRowViewModel)
    {
        try
        {
            var employee = _mapper.Map<DbEmployee>(employeeRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Delete(employee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public EmployeeRowViewModel Read(Guid id)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<EmployeeRowViewModel> ReadAll()
    {
        try
        {
            var repository = _repositoryCreator.CreateRepository();
            return new ObservableCollection<EmployeeRowViewModel>(repository
                .Query
                .Select(e => _mapper.Map<EmployeeRowViewModel>(e))
                .ToList());
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}