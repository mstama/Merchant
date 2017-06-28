using System.Collections.Generic;

namespace Merchant.Extensions
{
    /// <summary>
    /// Extension methods for generic queue
    /// </summary>
    public static class QueueExtensions
    {
        /// <summary>
        /// Check if the queue is empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static bool NotEmpty<T>(this Queue<T> queue)
        {
            return queue.Count > 0;
        }
    }
}