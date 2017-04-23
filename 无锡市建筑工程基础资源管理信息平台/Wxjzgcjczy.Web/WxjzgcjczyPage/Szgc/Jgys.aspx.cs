﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wxjzgcjczy.BLL;
using System.Data;
using Bigdesk8.Data;
using Bigdesk8.Web;
using Bigdesk8.Web.Controls;
using Bigdesk8;

namespace Wxjzgcjczy.Web.WxjzgcjczyPage.Szgc
{
    public partial class Jgys : BasePage
    {
        private SzgcBLL BLL;
        protected string rowID;
        protected string befrom;
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL = new SzgcBLL(WorkUser);
            rowID = Request.QueryString["rowID"];
            befrom = Request.QueryString["befrom"];
            List<IDataItem> list = BLL.ReadXmxx("jgys", rowID, befrom).Result;
            this.SetControlValue(list);

        }
    }
}
