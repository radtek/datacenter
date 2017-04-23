﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using Bigdesk8;
using Bigdesk8.Data;
using Bigdesk8.Web;
using Bigdesk8.Web.Controls;

namespace Bigdesk8.Business.UserRightManager.UserRole
{
    public partial class RoleList : SystemBasePage
    {
        private readonly IUserRightManager userManager = new UserRightManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.searchData(0);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            this.searchData(0);
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int roleID = ((Label)this.gridView.Rows[e.RowIndex].FindControl("lbl_RoleID")).Text.ToInt32();

            userManager.DeleteRole(roleID);

            this.searchData(this.gridView.PageIndex);
            this.WindowAlert("删除成功！", false);
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.searchData(e.NewPageIndex);
        }

        private void searchData(int pageIndex)
        {
            string result = this.CheckControlValue();
            if (!result.IsEmpty())
            {
                this.WindowAlert(result, false);
                return;
            }

            List<IDataItem> list = this.GetControlValue();

            int allRecordCount;
            DataTable dt = userManager.SearchRole(list, this.gridView.PageSize, pageIndex, out allRecordCount);

            this.gridView.RecordCount = allRecordCount;
            this.gridView.PageIndex = pageIndex;
            this.gridView.DataSource = dt;
            this.gridView.DataBind();
        }
    }
}
