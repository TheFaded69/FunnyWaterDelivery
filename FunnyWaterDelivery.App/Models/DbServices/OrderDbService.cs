using System.Collections.ObjectModel;
using AutoMapper;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;
using FunnyWaterDelivery.Database.Repository;

namespace FunnyWaterDelivery.App.Models.DbServices;

public class OrderDbService : IOrderDbService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryCreator<DbOrder, Guid> _repositoryCreator;

    public OrderDbService(IMapper mapper, IRepositoryCreator<DbOrder, Guid> repositoryCreator)
    {
        _mapper = mapper;
        _repositoryCreator = repositoryCreator;
    }
    
    public DbOrder Create(OrderRowViewModel orderRowViewModel)
    {
        try
        {
            var order = _mapper.Map<DbOrder>(orderRowViewModel);
            //todo хз почему маппер создает объекты хоть и гуиды null, нужно разбираться
            order.Employee = null;
            order.Partner = null;   
            var repository = _repositoryCreator.CreateRepository();
            repository.Insert(order);
            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public DbOrder Update(OrderRowViewModel orderRowViewModel)
    {
        try
        {
            var order = _mapper.Map<DbOrder>(orderRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Update(order);
            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(OrderRowViewModel orderRowViewModel)
    {
        try
        {
            var order = _mapper.Map<DbOrder>(orderRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Delete(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public OrderRowViewModel Read(Guid id)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<OrderRowViewModel> ReadAll()
    {
        try
        {
            var repository = _repositoryCreator.CreateRepository();
            return new ObservableCollection<OrderRowViewModel>(repository
                .Query
                .Select(e => _mapper.Map<OrderRowViewModel>(e))
                .ToList());
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}