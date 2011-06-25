using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        
        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentException("format");
            }

            return string.Format(format, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentException("format");
            }

            return string.Format(provider, format, args);
        }

        public static string FormatWith(this string format, string source)
        {
            return string.Format(format, source);
        }

        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            var r = new Regex(
                    @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                    RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            var values = new List<object>();

            string rewrittenFormat = r.Replace(
                format,
                m =>
                    {
                        var startGroup = m.Groups["start"];
                        var propertyGroup = m.Groups["property"];
                        var formatGroup = m.Groups["format"];
                        var endGroup = m.Groups["end"];

                        values.Add((propertyGroup.Value == "0")
                                       ? source
                                       : DataBinder.Eval(source, propertyGroup.Value));

                        return new string('{', startGroup.Captures.Count) + (values.Count - 1) + formatGroup.Value
                               + new string('}', endGroup.Captures.Count);
                    });

            return string.Format(provider, rewrittenFormat, values.ToArray());
        }

        public static string ToHumanName(this string name)
        {
            string human = Regex.Replace(name, "([A-Z]|[0-9]+)", " $1");

            if (Regex.IsMatch(human, "^[a-z]"))
            {
                return (human.Substring(0, 1).ToUpperInvariant() + human.Substring(1)).Trim();
            }

            return human.Trim();
        }

        public static string ToCamelCase(this string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            var camelCased = 
                Regex.Split(name.Trim(), @"\s+")
                    .Select(x => x.Substring(0, 1).ToUpperInvariant() + x.Substring(1));

            return string.Join(string.Empty, camelCased.ToArray());
        }
    }
}
