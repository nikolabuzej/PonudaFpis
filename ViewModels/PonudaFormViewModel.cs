using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PonudaFormViewModel: BaseViewModel
    {
        private readonly IPonudaService _ponudaService;
        private Ponuda _ponuda = Ponuda.Default();
        public Ponuda Ponuda
        {
            get => _ponuda;
            set => SetValue(ref _ponuda, value);
        }
        public PonudaFormViewModel(IPonudaService ponudaService)
        {
            _ponudaService = ponudaService;
        }

        public async Task OnInit(Guid id)
        {
            var ponuda = await VratiPonudu(id);
            Ponuda = ponuda;
        }
        public async Task<Ponuda> VratiPonudu(Guid id)
        {
            var response = await _ponudaService.VratiPonudu(id);

            return response;
        }

       
    }
}
