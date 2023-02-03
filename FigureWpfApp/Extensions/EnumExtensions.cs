using System;
using System.ComponentModel;
using System.Linq;

namespace FigureWpfApp.Extensions
{
    internal static class EnumExtensions
    {
        internal static string GetDescriptionOrValue(this Enum value) =>
            value.GetAttribute<DescriptionAttribute>()?.Description ?? value.ToString();

        private static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo?.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>().ToArray();
            return attributes?.FirstOrDefault() ?? throw new InvalidOperationException();
        }
    }
}