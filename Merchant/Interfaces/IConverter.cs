namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the converters
    /// </summary>
    public interface IConverter<TSource, TTarget>
    {
        /// <summary>
        /// Executes the conversion
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Converted value</returns>
        TTarget Convert(TSource value);
    }
}