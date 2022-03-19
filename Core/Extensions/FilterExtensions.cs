using ApplicationLogic.Filter;
using Core.Abrstractions.Filter;
using Core.Domain.PonudaAggregate;
using Core.Filter;
using Core.ListView.Ponuda;

namespace Core.Extensions
{
    public static class FilterExtensions
    {
        public static Filter<Ponuda> GetFilter(this SortProperty property)
        {
            return property switch
            {
                SortProperty.Status => new OrderByStatus(),
                SortProperty.DatumPristizanja => new OrderByDate(),
                _ => new OrderByDate(),
            };
        }
    }
}
