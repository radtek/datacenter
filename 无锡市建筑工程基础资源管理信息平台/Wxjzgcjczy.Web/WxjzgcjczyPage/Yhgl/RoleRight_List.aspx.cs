﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wxjzgcjczy.Web.WxjzgcjczyPage.Yhgl
{
    public partial class RoleRight_List : BasePage
    {
        public string UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID=Request.QueryString["id"];
        }
    }
}
