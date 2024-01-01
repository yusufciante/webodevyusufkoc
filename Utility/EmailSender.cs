using Microsoft.AspNetCore.Identity.UI.Services;

namespace hospital.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email,string subject,string htmlMessage) {
           
            //email gönderme işlemlerimizi burayaekkliyoruz 
            return Task.CompletedTask;  
        }
    }
}
