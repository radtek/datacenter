﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wxjzgcjczy.Web.WxjzgcjczyPage.Szgc
{
    public partial class Gcxm_AqjdList : BasePage
    {
        protected string rowID;
        protected void Page_Load(object sender, EventArgs e)
        {
            rowID = Request.QueryString["rowid"];
        }
    }
}
