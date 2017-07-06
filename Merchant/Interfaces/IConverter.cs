namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the converters
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public interface IConverter<in TSource, out TTarget>
    {
        /// <summary>
        /// Executes the conversion
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Converted value</returns>
        TTarget Convert(TSource value);
    }
}