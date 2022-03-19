using System.Linq.Expressions;

namespace Core.Abrstractions.Filter
{
    public abstract class Filter<T>
    {
        public abstract Expression<Func<T, object>> ToExpression();

    }


}
