using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.EmailDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDto request);
    }
}
