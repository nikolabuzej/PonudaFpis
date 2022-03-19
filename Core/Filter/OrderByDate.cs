using Core.Abrstractions.Filter;
using Core.Domain.PonudaAggregate;
using System.Linq.Expressions;

namespace Core.Filter
{
    public class OrderByDate : Filter<Ponuda>
    {
        public override Expression<Func<Ponuda, object>> ToExpression()
        {
            return p => p.DatumPristizanja;
        }
    }
}
