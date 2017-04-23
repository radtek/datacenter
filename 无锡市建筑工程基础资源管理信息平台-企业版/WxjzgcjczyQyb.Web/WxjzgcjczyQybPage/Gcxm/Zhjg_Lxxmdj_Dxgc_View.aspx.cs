﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WxjzgcjczyQyb.BLL;
using Bigdesk8;
using Bigdesk8.Data;
using Bigdesk8.Web;
using Bigdesk8.Web.Controls;

namespace WxjzgcjczyQyb.Web.WxjzgcjczyQybPage.Gcxm
{
    public partial class Zhjg_Lxxmdj_Dxgc_View : BasePage
    {
        public string PKID;
        GcxmBLL gcxm;
        private AppUser WorkUser = new AppUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            PKID = Request.QueryString["PKID"].ToString();
            gcxm = new GcxmBLL(this.WorkUser);
            if (!IsPostBack)
            {
                SearchData();
            }
        }

        public void SearchData()
        {
            DataTable dt = gcxm.GetDxXmxx(PKID).Result;
            this.SetControlValue(dt.Rows[0].ToDataItem());
        }
    }
}