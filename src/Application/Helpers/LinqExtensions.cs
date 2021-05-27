using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CloudyMobile.Application.Helpers
{
    public static class LinqExtensions
    {
        public static IQueryable<T> ConditionalWhere<T>(
        this IQueryable<T> source,
        Func<bool> condition,
        Expression<Func<T, bool>> predicate)
        {
            if (condition())
            {
                return source.Where(predicate);
            }

            return source;
        }

        public static IOrderedQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, bool ascending, string sortingProperty)
        {
            if (ascending)
                return source.OrderBy(item => item.GetReflectedPropertyValue(sortingProperty));
            else
                return source.OrderByDescending(item => item.GetReflectedPropertyValue(sortingProperty));
        }

        private static object GetReflectedPropertyValue(this object subject, string field)
        {
            return subject.GetType().GetProperty(field).GetValue(subject, null);
        }

        public static class QueryableExtension<TQuery>
        {
            internal static IEnumerable<IQueryable<TQuery>> WhereIn<TKey>(IQueryable<TQuery> queryable,
        Expression<Func<TQuery, TKey>> keySelector, IEnumerable<TKey> values, int batchSize)
            {
                List<TKey> distinctValues = values.Distinct().ToList();
                int lastBatchSize = distinctValues.Count % batchSize;
                if (lastBatchSize != 0)
                {
                    distinctValues.AddRange(Enumerable.Repeat(distinctValues.Last(), batchSize - lastBatchSize));
                }

                int count = distinctValues.Count;
                for (int i = 0; i < count; i += batchSize)
                {
                    var body = distinctValues
                        .Skip(i)
                        .Take(batchSize)
                        .Select(v =>
                        {
                            // Create an expression that captures the variable so EF can turn this into a parameterized SQL query
                            Expression<Func<TKey>> valueAsExpression = () => v;
                            return Expression.Equal(keySelector.Body, valueAsExpression.Body);
                        })
                        .Aggregate((a, b) => Expression.OrElse(a, b));
                    if (body == null)
                    {
                        yield break;
                    }

                    var whereClause = Expression.Lambda<Func<TQuery, bool>>(body, keySelector.Parameters);
                    yield return queryable.Where(whereClause);
                }
            }

            // doesn't use batching
            internal static IQueryable<TQuery> WhereIn<TKey>(IQueryable<TQuery> queryable,
                Expression<Func<TQuery, TKey>> keySelector, IEnumerable<TKey> values)
            {
                TKey[] distinctValues = values.Distinct().ToArray();


                int count = distinctValues.Length;
#pragma warning disable CS0162 // Unreachable code detected
                for (int i = 0; i < count; ++i)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    var body = distinctValues
                        .Select(v =>
                        {
                            // Create an expression that captures the variable so EF can turn this into a parameterized SQL query
                            Expression<Func<TKey>> valueAsExpression = () => v;
                            return Expression.Equal(keySelector.Body, valueAsExpression.Body);
                        })
                        .Aggregate((a, b) => Expression.OrElse(a, b));

                    var whereClause = Expression.Lambda<Func<TQuery, bool>>(body, keySelector.Parameters);
                    return queryable.Where(whereClause);
                }

                return Enumerable.Empty<TQuery>().AsQueryable();
            }
        }
    }
}
