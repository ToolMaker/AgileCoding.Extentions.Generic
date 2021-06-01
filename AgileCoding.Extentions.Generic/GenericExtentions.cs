namespace AgileCoding.Extentions.Generics
{
    using AgileCoding.Extentions.Activators;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GenericExtentions
    {
        public static void ThrowIfNull<IGenericType, IExceptionType>(this IGenericType target, string errorMessage)
            where IExceptionType : Exception, new()
        {
            if (target == null)
            {
                throw typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
            }
        }

        public static void ThrowIfNullOrEmpty<IGenericType, IExceptionType>(this Array target, string errorMessage)
            where IExceptionType : Exception, new()
        {
            if (target == null || target.Length == 0)
            {
                throw typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
            }
        }

        public static void ThrowIfNullOrEmpty<IGenericType, IExceptionType>(this List<IGenericType> target, string errorMessage)
            where IExceptionType : Exception, new()
        {
            if (target == null || target.Count == 0)
            {
                throw typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
            }
        }

        public static IEnumerable<List<T>> SplitYield<T>(this List<T> target, int BlockSize)
        {
            List<List<T>> blocks = new List<List<T>>();
            if (target != null && target.Count > 0)
            {
                for (int i = 0; i * BlockSize <= target.Count; i++)
                {
                    var list = target.Skip(i * BlockSize).Take(BlockSize).ToList();
                    yield return list;
                }
            }
        }

        public static List<List<T>> Split<T>(this List<T> target, int BlockSize)
        {
            List<List<T>> blocks = new List<List<T>>();
            if (target != null && target.Count > 0)
            {
                for (int i = 0; i * BlockSize <= target.Count; i++)
                {
                    var list = target.Skip(i * BlockSize).Take(BlockSize).ToList();
                    blocks.Add(list);
                }
            }

            return blocks;
        }

        public static bool ThrowIfTrue<TException>(this bool self, string errorMessage)
            where TException : Exception
        {
            if (self)
            {
                throw typeof(bool).CreateInstanceWithoutLogging<TException>(errorMessage);
            }

            return self;
        }

        public static IGenericType InitIfNull<IGenericType>(this IGenericType self, params object[] constructorParams)
            where IGenericType : class
        {
            if (self == null)
            {
                self = typeof(IGenericType).CreateInstanceWithoutLogging<IGenericType>(constructorParams);
            }

            return self;
        }
    }
}
