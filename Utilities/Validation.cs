using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Utilities
{
    public static class Validation
    {
        public static bool IsNullOrEmpty(List<string> value) {
            foreach (var item in value)
            {
                if (!string.IsNullOrEmpty(item)) { }
                else return true;
            }
            return false;
        }
    }
}
