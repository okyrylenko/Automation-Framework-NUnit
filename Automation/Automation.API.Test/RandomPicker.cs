using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.API.Test
{
    public static class RandomPicker
    {

        public static T PickRandomItem<T>(this IList<T> list)=> list[new Random().Next(1, list.Count)];
    }
}
