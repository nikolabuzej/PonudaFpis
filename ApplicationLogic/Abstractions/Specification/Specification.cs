﻿using System.Linq.Expressions;

namespace ApplicationLogic.Abstractions.Specification
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }
    }
}
