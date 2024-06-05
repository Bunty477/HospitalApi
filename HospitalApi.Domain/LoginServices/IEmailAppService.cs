using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.LoginServices;
public interface IEmailAppService
{
    public void SendEmail(string recipientEmail, string subject, string htmlbody);
}
