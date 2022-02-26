using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abrstractions
{
    public interface IUnitOfWork: IDisposable
    {
        public Task SaveChangesAsync();
    }
}
