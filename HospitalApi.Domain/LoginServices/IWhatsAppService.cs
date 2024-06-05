using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.LoginServices;
public interface IWhatsAppService
{
    public Task<string> SendMessage(long fromNumber , long toNumber , string message);
}
