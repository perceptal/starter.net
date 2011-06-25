using System;

namespace System
{
    public static class TypeExtensions
    {
        public static bool IsTypeWithGenericDefinition(this Type type, Type definition)
        {
            return type.GetTypeWithGenericDefinition(definition) != null;
        }

        public static Type GetTypeWithGenericDefinition(this Type type, Type definition)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (definition == null)
            {
                throw new ArgumentNullException("definition");
            }

            if (!definition.IsGenericTypeDefinition)
            {
                throw new ArgumentException("The definition needs to be a GenericTypeDefinition", "definition");
            }

            if (definition.IsInterface)
            {
                foreach (var interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == definition)
                    {
                        return interfaceType;
                    }
                }
            }

            for (var t = type; t != null; t = t.BaseType)
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == definition)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
