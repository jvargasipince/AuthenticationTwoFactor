using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AuthenticationTwoFactor.Util
{
    public class TwilioHelper
    {
        private SMSSettings _smsSettings = new SMSSettings();
        public string SendSMSMessage(string toMobilePhone, string messageToSend)
        {

        TwilioClient.Init(
                    _smsSettings.Twilio_Account_SID,
                    _smsSettings.Twilio_Auth_TOKEN
                );

            if (messageToSend.Length > 160)
                messageToSend = messageToSend.Substring(0, 160);

            var message = MessageResource.Create(
                from: new PhoneNumber(_smsSettings.Twilio_Phone_Number),
                to: new PhoneNumber("+51" + toMobilePhone),
                body: messageToSend
                ); ;

            return message.Sid;
        }
    }
}
