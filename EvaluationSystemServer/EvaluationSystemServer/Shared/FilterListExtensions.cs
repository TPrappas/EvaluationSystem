using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EvaluationSystemServer
{
    /// <summary>
    /// Extension methods for lists of filters
    /// </summary>
    public static class FilterListExtensions
    {
        #region Constants

        /// <summary>
        /// The character used for determining the property path
        /// </summary>
        private const char PropertyPathSeparatorCharacter = '.';

        #endregion

        #region Min / Max

        //public static List<Expression<Func<T, bool>>> AddMinMaxFilters<T>(this List<Expression<Func<T, bool>>> filters, Expression<Func<T, double>> propertySelector, double? minValue, double? maxValue)
        //{
        //    if (minValue is not null)
        //        filters.Add(CreateGreaterThanOrEqualFilter(propertySelector, minValue.Value));
        //    if (maxValue is not null)
        //        filters.Add(CreateLessThanOrEqualFilter(propertySelector, maxValue.Value));

        //    return filters;
        //}

        public static List<Expression<Func<T, bool>>> AddMinMaxFilters<T, TValue>(this List<Expression<Func<T, bool>>> filters, Expression<Func<T, TValue>> propertySelector, TValue? minValue, TValue? maxValue, bool useValidation = true, [CallerArgumentExpression(nameof(minValue))] string? minArgumentName = null, [CallerArgumentExpression(nameof(maxValue))] string? maxArgumentName = null)
            where TValue : struct, INumber<TValue>
        {
            ValidateMinMaxFilters(propertySelector, useValidation, minArgumentName, maxArgumentName);

            if (minValue is not null)
                filters.Add(CreateGreaterThanOrEqualFilter(propertySelector, minValue.Value));
            if (maxValue is not null)
                filters.Add(CreateLessThanOrEqualFilter(propertySelector, maxValue.Value));
            
            return filters;
        }

        public static List<Expression<Func<T, bool>>> AddEqualsFilter<T, TValue>(this List<Expression<Func<T, bool>>> filters, Expression<Func<T, TValue>> propertySelector, TValue? value)
            where TValue : struct
        {
            if (value is not null)
                filters.Add(CreateEqualsFilter(propertySelector, value.Value));

            return filters;
        }

        #region Before / After

        public static List<Expression<Func<T, bool>>> AddBeforeAfterFilters<T, TValue>(this List<Expression<Func<T, bool>>> filters, Expression<Func<T, TValue>> propertySelector, TValue? beforeDate, TValue? afterDate, bool useValidation = true, [CallerArgumentExpression(nameof(beforeDate))] string? minArgumentName = null, [CallerArgumentExpression(nameof(afterDate))] string? maxArgumentName = null)
            where TValue : DateTimeOffsetConverter
        {
            if (beforeDate is not null)
                filters.Add(CreateBeforeOrEqualDateCreatedFilter(propertySelector, beforeDate));
            if (afterDate is not null)
                filters.Add(CreateAfterOrEqualDateCreatedFilter(propertySelector, afterDate));

            return filters;
        }
        #endregion

        #endregion

        #region Private Methods

        private static Expression<Func<T, bool>> CreateEqualsFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue value)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(propertySelector.Body, Expression.Constant(value)),
                propertySelector.Parameters[0]);
        }

        private static Expression<Func<T, bool>> CreateGreaterThanOrEqualFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue value)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.GreaterThanOrEqual(propertySelector.Body, Expression.Constant(value)),
                propertySelector.Parameters[0]);
        }

        private static Expression<Func<T, bool>> CreateLessThanOrEqualFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue value)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.LessThanOrEqual(propertySelector.Body, Expression.Constant(value)),
                propertySelector.Parameters[0]);
        }

        private static Expression<Func<T, bool>> CreateEqualDateCreatedFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue date)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(propertySelector.Body, Expression.Constant(date)),
                propertySelector.Parameters[0]);
        }

        private static Expression<Func<T, bool>> CreateAfterOrEqualDateCreatedFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue date)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.GreaterThanOrEqual(propertySelector.Body, Expression.Constant(date)),
                propertySelector.Parameters[0]);
        }

        private static Expression<Func<T, bool>> CreateBeforeOrEqualDateCreatedFilter<T, TValue>(Expression<Func<T, TValue>> propertySelector, TValue date)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.LessThanOrEqual(propertySelector.Body, Expression.Constant(date)),
                propertySelector.Parameters[0]);
        }


        /// <summary>
        /// Ensures that the inserted arguments used for filtering are targeting correct property
        /// </summary>
        /// <param name="propertySelector">The property selector</param>
        /// <param name="useValidation">A flag indicating whether validation should be used or not</param>
        /// <param name="minArgumentName">The min argument name</param>
        /// <param name="maxArgumentName">The max argument name</param>
        public static void ValidateMinMaxFilters(LambdaExpression propertySelector, bool useValidation, string? minArgumentName, string? maxArgumentName)
        {
            // If we shouldn't validate...
            if (!useValidation)
                // Return
                return;

            // Get the name of the min and the max arguments
            minArgumentName = minArgumentName?.Split(PropertyPathSeparatorCharacter).Last() ?? string.Empty;
            maxArgumentName = maxArgumentName?.Split(PropertyPathSeparatorCharacter).Last() ?? string.Empty;

            // Get the name of the property
            var propertyName = propertySelector.GetPropertyInfos().AggregateString(x => x.Name, string.Empty);

            if (minArgumentName != "Min" + propertyName)
                Debugger.Break();

            if (maxArgumentName != "Max" + propertyName)
                Debugger.Break();
        }

        public static void ValidateBeforeAfterFilters(LambdaExpression propertySelector, bool useValidation, string? beforeArgumentDate, string? afterArgumentDate)
        {
            // If we shouldn't validate...
            if (!useValidation)
                // Return
                return;

            // Get the name of the min and the max arguments
            beforeArgumentDate = beforeArgumentDate?.Split(PropertyPathSeparatorCharacter).Last() ?? string.Empty;
            afterArgumentDate = afterArgumentDate?.Split(PropertyPathSeparatorCharacter).Last() ?? string.Empty;

            // Get the name of the property
            var propertyName = propertySelector.GetPropertyInfos().AggregateString(x => x.Name, string.Empty);

            if (beforeArgumentDate != "Before" + propertyName)
                Debugger.Break();

            if (afterArgumentDate != "After" + propertyName)
                Debugger.Break();
        }

        //private static Expression<Func<T, bool>> CreateGreaterThanOrEqualFilter<T>(Expression<Func<T, double>> propertySelector, double value)
        //{
        //    return Expression.Lambda<Func<T, bool>>(
        //        Expression.GreaterThanOrEqual(propertySelector.Body, Expression.Constant(value)),
        //        propertySelector.Parameters[0]);
        //}

        //private static Expression<Func<T, bool>> CreateLessThanOrEqualFilter<T>(Expression<Func<T, double>> propertySelector, double value)
        //{
        //    return Expression.Lambda<Func<T, bool>>(
        //        Expression.LessThanOrEqual(propertySelector.Body, Expression.Constant(value)),
        //        propertySelector.Parameters[0]);
        //}



        #endregion
    }
}
