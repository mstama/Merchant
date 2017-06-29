using System.Collections;

namespace Merchant.Extensions
{
    /// <summary>
    /// Extension methods for collection
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Check if it is empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotEmpty(this ICollection value)
        {
            return value.Count > 0;
        }
    }
}