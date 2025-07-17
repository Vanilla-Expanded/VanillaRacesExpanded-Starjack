using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VanillaRacesExpandedStarjack
{
    public static class Utils
    {


        public static object Clone(this object obj)
        {
            var cloneMethod = obj.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            return cloneMethod.Invoke(obj, null);
        }
    }
}
