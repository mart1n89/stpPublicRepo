using stp.Models.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stp.Models
{
    internal class Training : ModelBase
    {
        public static explicit operator Training(DataRow source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Could not be null.");

            return (ToEmployee(source));
        }
        public static Training ToEmployee(DataRow record)
        {
            if (record == null)
                throw new ArgumentNullException("record", "Could not be null.");

            Training aTraining = new Training();

            // set Properties here.

            return aTraining;
        }
    }
}
