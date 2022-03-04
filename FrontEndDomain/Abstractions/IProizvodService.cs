using FrontEnd.FrontEndDomain;
using FrontEndDomain.ListViewConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDomain.Abstractions
{
    public interface IProizvodService
    {
        public Task<ListViewModel<Proizvod>> VratiProizvode();
    }
}
