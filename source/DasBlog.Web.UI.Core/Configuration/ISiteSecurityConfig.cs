﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DasBlog.Web.UI.Core.Configuration
{
    public interface ISiteSecurityConfig
    {
        List<User> Users { get; set; }
    }
}
