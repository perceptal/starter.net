using System;
using System.Reflection;
using System.ComponentModel;

namespace System
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Checks if the value contains the provided type
        /// </summary>
        public static bool Has<T>(this Enum type, T value)
        {
            try
            {
                return ((int)(object)type & (int)(object)value) == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the value is only the provided type
        /// </summary>
        public static bool Is<T>(this Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Appends a value
        /// </summary>
        public static T Set<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)((int)(object)type | (int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    "Could not set value from enumerated type '{0}'.".FormatWith(typeof(T).Name),
                    ex);
            }
        }

        /// <summary>
        /// Completely removes the value
        /// </summary>
        public static T Clear<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)((int)(object)type & ~(int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    "Could not clear value from enumerated type '{0}'.".FormatWith(typeof(T).Name),
                    ex);
            }
        }

        /// <summary>
        /// Completely removes the value
        /// </summary>
        public static T Toggle<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)((int)(object)type ^ (int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    "Could not toggle value from enumerated type '{0}'.".FormatWith(typeof(T).Name),
                    ex);
            }
        }

        /// <summary>
        /// Returns the description attribute
        /// </summary>
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Return an enum of T with the matching description attribute (case sensitive).
        /// Throws exception if none found.
        /// </summary>
        public static T ToEnumFromDescription<T>(this string description)
        {
            return ToEnumFromDescription<T>(description, false);
        }

        /// <summary>
        /// Return an enum of T with the matching description attribute.
        /// Throws exception if none found.
        /// </summary>
        public static T ToEnumFromDescription<T>(this string description, bool ignoreCase)
        {
            //get the member info for the enum
            MemberInfo[] memberInfos = typeof(T).GetMembers();

            var stringComparision = ignoreCase
                                        ? StringComparison.InvariantCultureIgnoreCase
                                        : StringComparison.InvariantCulture;

            if (memberInfos != null && memberInfos.Length > 0)
            {
                foreach (MemberInfo memberinfo in memberInfos)
                {
                    object[] attributes = memberinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes != null && attributes.Length > 0)
                    {
                        if (((DescriptionAttribute)attributes[0]).Description.Equals(description, stringComparision))
                        {
                            return (T)Enum.Parse(typeof(T), memberinfo.Name);
                        }
                    }
                }
            }

            throw new ArgumentException("Requested value '" + description + "' was not found");
        }

        /// <summary>
        /// Return an enum of T with the matching name.
        /// Throws exception if none found.
        /// </summary>
        public static T ToEnum<T>(this string enumValue, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), enumValue, ignoreCase);
        }

        /// <summary>
        /// Return an enum of T with the matching name (case sensitive).
        /// Throws exception if none found.
        /// </summary>
        public static T ToEnum<T>(this string enumValue)
        {
            return ToEnum<T>(enumValue, false);
        }
    }
}
