using System.Collections.ObjectModel;
using AutoMapper;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;
using FunnyWaterDelivery.Database.Repository;

namespace FunnyWaterDelivery.App.Models.DbServices;

public class PartnerDbService : IPartnerDbService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryCreator<DbPartner, Guid> _repositoryCreator;

    public PartnerDbService(IMapper mapper, IRepositoryCreator<DbPartner, Guid> repositoryCreator)
    {
        _mapper = mapper;
        _repositoryCreator = repositoryCreator;
    }
    
    public DbPartner Create(PartnerRowViewModel partnerRowViewModel)
    {
        try
        {
            var partner = _mapper.Map<DbPartner>(partnerRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Insert(partner);
            return partner;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public DbPartner Update(PartnerRowViewModel partnerRowViewModel)
    {
        try
        {
            var partner = _mapper.Map<DbPartner>(partnerRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Update(partner);
            return partner;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(PartnerRowViewModel partnerRowViewModel)
    {
        try
        {
            var partner = _mapper.Map<DbPartner>(partnerRowViewModel);
            var repository = _repositoryCreator.CreateRepository();
            repository.Delete(partner);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public PartnerRowViewModel Read(Guid id)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<PartnerRowViewModel> ReadAll()
    {
        try
        {
            var repository = _repositoryCreator.CreateRepository();
            return new ObservableCollection<PartnerRowViewModel>(repository
                .Query
                .Select(e => _mapper.Map<PartnerRowViewModel>(e))
                .ToList());
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}