using Core.Abrstractions.Filter;
using Core.Domain.PonudaAggregate;
using System.Linq.Expressions;

namespace ApplicationLogic.Filter
{
    public class OrderByStatus : Filter<Ponuda>
    {
        public override Expression<Func<Ponuda, object>> ToExpression()
        {
            return p => p.Status;
        }
    }
}
