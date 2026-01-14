using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum TokenType
    {
        FORGOT_PASSWORD, // Mã xác thực quên mật khẩu
        EMAIL_VERIFICATION, // Mã xác thực email
        ACCOUNT_ACTIVATION, // Mã kích hoạt tài khoản
        REFRESH_TOKEN, // Mã làm mới token
    }
}
