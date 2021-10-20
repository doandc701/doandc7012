using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_flim.Areas.Admin.Models.DAO
{
    public class AccountDAO
    {
        private static Models.Framework.PhimEntities db = new Models.Framework.PhimEntities();

        public static bool checkLogin(string Username, string Password)
        {
            //Hash password befor check

            //Đếm số tài khoản thỏa mãn điều kiện

            int count = db.Account.Count(x => x.TaiKhoan == Username && x.MatKhau == Password);
            //Nếu count ==1 => đăng nhập thành công

            return count == 1;
        }
    }
}