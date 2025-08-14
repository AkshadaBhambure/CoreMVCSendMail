using CoreMVCSendMail.Models;

namespace CoreMVCSendMail.Services
{
    public interface IExtraService
    {
        void SendEmail(EmailModel model);
    }
}
