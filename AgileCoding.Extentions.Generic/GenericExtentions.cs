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
                var exception = typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
                if (exception != null)
                {
                    throw exception;
                }
                else
                {
                    throw new Exception(errorMessage);
                }
            }
        }

        public static void ThrowIfNullOrEmpty<IGenericType, IExceptionType>(this Array target, string errorMessage)
            where IExceptionType : Exception, new()
        {
            if (target == null || target.Length == 0)
            {
                var exception = typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
                if (exception != null)
                {
                    throw exception;
                }
                else
                {
                    throw new Exception(errorMessage);
                }
            }
        }

        public static void ThrowIfNullOrEmpty<IGenericType, IExceptionType>(this List<IGenericType> target, string errorMessage)
            where IExceptionType : Exception, new()
        {
            if (target == null || target.Count == 0)
            {
                var exception = typeof(IExceptionType).CreateInstanceWithoutLogging<IExceptionType>(errorMessage);
                if (exception != null)
                {
                    throw exception;
                }
                else
                {
                    throw new Exception(errorMessage);
                }
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
                var exception = typeof(bool).CreateInstanceWithoutLogging<TException>(errorMessage);
                if (exception != null)
                {
                    throw exception;
                }
                else
                {
                    throw new Exception(errorMessage);
                }
            }

            return self;
        }

        public static IGenericType InitIfNull<IGenericType>(this IGenericType self, params object[] constructorParams)
            where IGenericType : class
        {
            if (self == null)
            {
                IGenericType? genericType = typeof(IGenericType).CreateInstanceWithoutLogging<IGenericType>(constructorParams);
                if (genericType != null)
                {
                    self = genericType;
                }
                else
                { 
                    throw new Exception("Failed to create instance of type " + typeof(IGenericType).FullName);
                }
            }

            return self;
        }
    }
}
