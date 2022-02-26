namespace Core.Extensions
{
    public static class ExtensionMethods
    {
        public static T EnsureExists<T>(this T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(T)} has not been found");
            }

            return entity;
        }
    }
}
