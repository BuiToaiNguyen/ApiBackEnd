﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CitizenAPI.Infrastructure.Identity;

public class RegisterUserEmailModel
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Url { get; set; } = default!;
}
