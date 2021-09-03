using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace School
{
    public static class Extensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, Func<TEnum, string> getEnumDisplayName = null, bool withEmpty = false)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            IEnumerable<object> values = from TEnum e in Enum.GetValues(typeof(TEnum))
                                         select new { Id = e, Name = (getEnumDisplayName ?? GetEnumDisplayName)(e) };

            if (withEmpty)
            {
                values = new[] { new { Id = "", Name = "(הכל)" } }.Concat(values);
            }

            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static string GetEnumDisplayName<TEnum>(this TEnum enumObj)
            where TEnum : struct
        {
            return enumObj.GetType()
                            .GetMember(enumObj.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName() ?? enumObj.ToString();
        }
    }
}
