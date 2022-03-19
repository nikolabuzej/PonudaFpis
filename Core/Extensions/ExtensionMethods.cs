namespace Core.Extensions
{
    public static class ExtensionMethods
    {
        public static async Task<T> EnsureExists<T>(this Task<T> entity) where T : class
        {
            return (await entity).EnsureExists();
        }
        public static T EnsureExists<T>(this T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{typeof(T).Name} has not been found");
            }

            return entity;
        }
    }
}
