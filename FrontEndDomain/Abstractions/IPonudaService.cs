using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDomain.Abstractions
{
    public interface IPonudaService
    {
        public Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1,int pageSize = 1);
    }
}
