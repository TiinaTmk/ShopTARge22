﻿using Microsoft.AspNetCore.Authentication;

namespace ShopTARge22.Core.Dto.AccountsDtos
{
    public class LoginDto
    {
        public string Email { get; set; }


        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
