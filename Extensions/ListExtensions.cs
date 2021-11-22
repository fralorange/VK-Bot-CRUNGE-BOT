using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Control_Panel_Bot.Extensions
{
    public static class ListExtensions
    {
        public static void AddMultiple<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
    }
}
