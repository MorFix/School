using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportStore
{
    public static class Extensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = GetEnumDisplayName(e) };

            return new SelectList(values, "Id", "Name", enumObj);
        }

        private static string GetEnumDisplayName<TEnum>(TEnum enumObj)
            where TEnum : struct
        {
            return enumObj.GetType()
                            .GetMember(enumObj.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName();
        }
    }
}
