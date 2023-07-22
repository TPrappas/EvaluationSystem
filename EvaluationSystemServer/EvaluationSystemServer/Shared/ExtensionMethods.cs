using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace EvaluationSystemServer
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns a flag indicating whether the specified <paramref name="enumerable"/>  is <see cref="null"/>
        /// or empty
        /// </summary>
        /// <param name="enumerable">The enumerable</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty([NotNullWhen(false)]this IEnumerable? enumerable)
        {
            if (enumerable is null)
                return true;

            foreach (var _ in enumerable)
                return true;

            return false;
        }

        /// <summary>
        /// Used for analyzing an expression like x => x.Property1.Property2.Property3...PropertyN and returning
        /// the <see cref="PropertyInfo"/>s
        /// Ex.: input: x => x.Property1.Property2.Property3
        ///      output: [Property1, Property2, Property3...PropertyN]
        /// </summary>
        /// <param name="propertyExpression">The expression targeting the property</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfos(this LambdaExpression propertyExpression)
        {
            // Create the result
            var results = new List<PropertyInfo>();

            // The expression that is currently being analyzed
            var currentExpression = GetMemberExpression(propertyExpression);

            // While we have an expression to analyze
            while (currentExpression is not null)
            {
                // Attempt to get the property info
                var propertyInfo = currentExpression.Member as PropertyInfo;

                // If we managed to get the property info...
                if (propertyInfo is not null)
                    // Add it to the result
                    results.Add(propertyInfo);
                // Else...
                else
                    // We didn't manage to get a member accessing expression, so break
                    break;

                // Set the sub expression as the current expression if any
                currentExpression = GetMemberExpression(currentExpression.Expression!);
            }

            // The results are returned in a reversed order. For example,
            // for the expression x => x.Property1.Property2.Property3
            // the results are Property3, Property2, Property1, so we need
            // to reverse the list.
            results.Reverse();

            // Return the result
            return results;
        }

        /// <summary>
        /// Returns the <see cref="MemberExpression"/> from the specified <paramref name="expression"/>
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns></returns>
        private static MemberExpression? GetMemberExpression(Expression expression)
        {
            // Initialize the result
            var result = expression;

            // If the result is a lambda expression...
            if (result is LambdaExpression lambdaExpression)
                // Get its body
                result = lambdaExpression.Body;

            // If the expression is unary...
            if (result is UnaryExpression unary)
                // Get the expression of the operand
                result = unary.Operand;

            // If the expression is a method call...
            // NOTE: The method call expression is checked in order for retrieving properties
            //       when in form Property1.First().Property2
            if (result is MethodCallExpression methodCall)
            {
                // For every argument...
                foreach (var argument in methodCall.Arguments)
                    // If the argument is a member expression...
                    if (argument is MemberExpression)
                        // Return the argument
                        return (MemberExpression)argument;
            }

            // Return the type-casted expression
            return result as MemberExpression;
        }

        /// <summary>
        /// Aggregates the specified <paramref name="source"/> into a <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="source">The source</param>
        /// <param name="extractor">The string extractor that is used to convert an item to a string</param>
        /// <param name="func">Delegate that places the extracted strings in order</param>
        /// <returns></returns>
        public static string AggregateString<T>(this IEnumerable<T> source, Func<T, string> extractor, Func<string, string, string> func)
        {
            var result = string.Empty;

            foreach (var item in source)
            {
                if (result == string.Empty)
                {
                    result = extractor(item);
                    continue;
                }

                result = func(result, extractor(item));
            }

            return result;
        }

        /// <summary>
        /// Aggregates the specified <paramref name="source"/> into a <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="source">The source</param>
        /// <param name="extractor">The string extractor that is used to convert an item to a string</param>
        /// <param name="separator">The separator</param>
        /// <returns></returns>
        public static string AggregateString<T>(this IEnumerable<T> source, Func<T, string> extractor, string separator = ", ")
            => AggregateString(source, extractor, (value1, value2) => value1 + separator + value2);

        /// <summary>
        /// Aggregates the specified <paramref name="source"/> into a <see cref="string"/>.
        /// NOTE: This method converts the items of the <paramref name="source"/> to <see cref="string"/>
        ///       using the <see cref="object.ToString()"/> method!
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="source">The source</param>
        /// <param name="func">Delegate that places the extracted strings in order</param>
        /// <returns></returns>
        public static string AggregateString<T>(this IEnumerable<T> source, Func<string, string, string> func)
            => AggregateString(source, item => item?.ToString() ?? string.Empty, func);

        /// <summary>
        /// Aggregates the specified <paramref name="source"/> into a <see cref="string"/>.
        /// NOTE: This method converts the items of the <paramref name="source"/> to <see cref="string"/>
        ///       using the <see cref="object.ToString()"/> method!
        /// NOTE: This method uses ", " as the items separator!
        /// </summary>
        /// <typeparam name="T">The type of the items</typeparam>
        /// <param name="source">The source</param>
        /// <param name="separator">The separator</param>
        /// <returns></returns>
        public static string AggregateString<T>(this IEnumerable<T> source, string separator = ", ")
            => source.AggregateString((s1, s2) => s1 + separator + s2);
    }
}
