﻿namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the converters
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public interface IMapConverter<TSource, TTarget> : IConverter<TSource, TTarget>
    {
        /// <summary>
        /// Add a map
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        void AddMap(TSource from, TTarget target);
    }
}