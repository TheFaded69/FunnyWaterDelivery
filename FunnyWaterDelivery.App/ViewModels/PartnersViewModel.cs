using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FunnyWaterDelivery.App.Models.DbServices;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;

namespace FunnyWaterDelivery.App.ViewModels;

public partial class PartnersViewModel : ObservableObject
{
    private readonly IPartnerDbService _partnerDbService;
    private readonly IMapper _mapper;

    public PartnersViewModel(IPartnerDbService partnerDbService, IMapper mapper)
    {
        _partnerDbService = partnerDbService;
        _mapper = mapper;

        Partners = _partnerDbService.ReadAll();
    }
    
    [ObservableProperty]
    private ObservableCollection<PartnerRowViewModel> _partners = [];

    [ObservableProperty]
    private PartnerRowViewModel? _selectedPartner;
    
    [RelayCommand]
    private void AddPartner()
    {
        var partnerRowViewModel = new PartnerRowViewModel
        {
            Name = string.Empty,
            INn = string.Empty,
        };
        Partners.Add(_mapper.Map<PartnerRowViewModel>(_partnerDbService.Create(partnerRowViewModel)));
    }
    
    [RelayCommand]
    private void SaveChanges()
    {
        foreach (var partnerRowViewModel in Partners) _partnerDbService.Update(partnerRowViewModel);
    }
    
    [RelayCommand]
    private void DeletePartner()
    {
        _partnerDbService.Delete(SelectedPartner);
        Partners.Remove(SelectedPartner);
    }
}