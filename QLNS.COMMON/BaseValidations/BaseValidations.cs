using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeRequired : Attribute
    {
        #region fields
        public string ErrorMessage;
        #endregion

        #region methods
        public AttributeRequired(string message)
        {
            ErrorMessage = message;
        }
        #endregion
    }
}
