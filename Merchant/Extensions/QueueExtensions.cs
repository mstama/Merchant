using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Extensions
{
    public static class QueueExtensions
    {
        public static bool NotEmpty<T>(this Queue<T> queue)
        {
            return queue.Count > 0;
        }
    }
}
