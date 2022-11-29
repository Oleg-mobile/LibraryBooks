using System.Linq.Expressions;

namespace LibraryBooks.Core.Extentions
{
    public static class LinqExtention
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return !condition ? query : query.Where(predicate);
        }
    }
}
