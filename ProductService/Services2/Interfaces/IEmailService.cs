﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services2.Interfaces
{
    public interface IEmailService
    {
        Task SendErrorNotification(string errorMessage);
    }
}
