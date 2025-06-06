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

    public void AddEmployee(EmployeeRowViewModel employeeRowViewModel)
    {
        try
        {
            //var employee = _mapper.Map<DbEmployee>(employeeRowViewModel);
            var employee = new DbEmployee
            {
                ID = default,
                Deleted = false,
                CreateTime = default,
                UpdateTime = default,
                Name = "name",
                Surname = "surname",
                Patronymic = "patronymic",
                EmployeeType = EmployeeType.Worker,
                DateOfBirth = default
            };
            var repository = _repositoryCreator.CreateRepository();
            repository.Insert(employee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}