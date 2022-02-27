namespace Core.Extensions
{
    public static class ExtensionMethods
    {
        public static Task<T> EnsureExists<T>(this Task<T> entity)
        {
            if(entity.Result == null)
            {
                throw new ArgumentNullException($"{nameof(T)} has not been found");
            }

            return entity;
        }
        public static T EnsureExists<T>(this T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(T)} has not been found");
            }

            return entity;
        }
    }
}
