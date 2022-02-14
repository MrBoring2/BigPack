using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemPodgotovka.Data
{
    public class BaseEntity
    {
        public object GetProperty(string property)
        {
            return GetType().GetProperty(property).GetValue(this);
        }
    }
}
