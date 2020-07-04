using AuthenticationTwoFactor.Models;
using System;

namespace AuthenticationTwoFactor.Repository
{
    public class LoginRepository
    {

        public UserLogged LoginUser(LoginModel loginModel)
        {

            if (loginModel.UserName.Equals("kaizenforce", System.StringComparison.InvariantCultureIgnoreCase)
                && loginModel.Password.Equals("demosms", System.StringComparison.InvariantCultureIgnoreCase))
            {
                Random random = new Random();

                return new UserLogged {
                    FullName = "Jorge Vargas",
                    MobilePhone = "979643186",
                    SMSCode = random.Next(1000, 9999)
                    };
            }
            else
            {
                return new UserLogged();
            }
        }

    }
}
