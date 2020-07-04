namespace AuthenticationTwoFactor.Util
{
    public class SMSSettings
    {
        public string Twilio_Account_SID { 
            get {
                return "youraccountsidfromtwilio";
            } 
        }
        public string Twilio_Auth_TOKEN {
            get
            {
                return "yourtokenfromtwilio";
            }
        }
        public string Twilio_Phone_Number
        {
            get
            {
                return "yourphonenumberfromtwilio";
            }
        }
    }
}
