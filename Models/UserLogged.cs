namespace AuthenticationTwoFactor.Models
{
    public class UserLogged
    {
        public UserLogged()
        {

        }

        public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public int SMSCode { get; set; }

        public int SMSCodeVerify { get; set; }

        public bool IsLogged { 
            get {
                return !string.IsNullOrWhiteSpace(FullName);
            } 
        }
    }
}
