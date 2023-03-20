using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    public class User
    {
        #region Constructor

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        #endregion

        /// <summary>
        /// tên đăng nhập
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// mật khẩu
        /// </summary>
        public string Password { get; set; }

    }
}
