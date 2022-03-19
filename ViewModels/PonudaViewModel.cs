﻿using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace ViewModels
{
    public class PonudaViewModel : BaseViewModel
    {
        private readonly IPonudaService _ponudaService;

        public PonudaViewModel(IPonudaService ponudaService)
        {
            _ponudaService = ponudaService;
        }

        private ListViewModel<Ponuda> _ponude = new();
        public ListViewModel<Ponuda> Ponude
        {
            get => _ponude;
            set => SetValue(ref _ponude, value);
        }
        public async Task OnInit()
        {
            var ponude = await this.VratiPonude(1, 2);

            Ponude = ponude;
        }
        public async Task NextPage()
        {
            Ponude = await this.VratiPonude(Ponude.Pagination.NextPage, Ponude.Pagination.PageSize);
        }
        public async Task PrevoiusPage()
        {
            Ponude = await this.VratiPonude(Ponude.Pagination.PreviousPage, Ponude.Pagination.PageSize);
        }
        public async Task LastPage()
        {
            Ponude = await this.VratiPonude(Ponude.Pagination.TotalPages, Ponude.Pagination.PageSize);
        }

        public async Task NavigateToPage(int pageNumber)
        {
            Ponude = await this.VratiPonude(pageNumber, Ponude.Pagination.PageSize);
        }
        public List<int> CreateSpread()
        {
            return Enumerable.Range(1, Ponude.Pagination.TotalPages).ToList();
        }
        public string GetPageStatus()
        {
            return $"{Ponude.Pagination.CurrentPage}/{Ponude.Pagination.TotalPages}";
        }
        public async Task PromeniSortProperty(SortProperty sortProperty)
        {
            Ponude.Pagination.SortProperty = sortProperty;
            Ponude = await this.VratiPonude(Ponude.Pagination.CurrentPage,
                                            Ponude.Pagination.PageSize,
                                            Ponude.Pagination.SortProperty,
                                            Ponude.Pagination.SortOrder);
        }
        public async Task PromeniSortOrder(SortOrder sortOrder)
        {
            Ponude.Pagination.SortOrder = sortOrder;
            Ponude = await this.VratiPonude(Ponude.Pagination.CurrentPage,
                                            Ponude.Pagination.PageSize,
                                            Ponude.Pagination.SortProperty,
                                            Ponude.Pagination.SortOrder);
        }
        public async Task PromeniPageSize(int pageSize)
        {
            Ponude.Pagination.PageSize = pageSize;
            Ponude = await this.VratiPonude(Ponude.Pagination.CurrentPage,
                                            Ponude.Pagination.PageSize,
                                            Ponude.Pagination.SortProperty,
                                            Ponude.Pagination.SortOrder);
        }
        private async Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber,
                                                             int pageSize,
                                                             SortProperty sortProperty = SortProperty.DatumPristizanja,
                                                             SortOrder sortOrder = SortOrder.desc)
        {
            ListViewModel<Ponuda> ponude = await _ponudaService.VratiPonude(pageNumber, pageSize, sortProperty, sortOrder);

            return ponude;
        }

    }
}
