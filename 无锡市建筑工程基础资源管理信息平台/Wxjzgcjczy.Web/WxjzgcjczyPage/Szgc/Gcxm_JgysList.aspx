﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gcxm_JgysList.aspx.cs"
    Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.Szgc.Gcxm_JgysList" %>

<%@ Register Assembly="Bigdesk8" Namespace="Bigdesk8.Web.Controls" TagPrefix="Bigdesk8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>竣工验收项目列表</title>
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-grid.css" rel="stylesheet"
        type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-form.css" rel="stylesheet"
        type="text/css" />
    <link href="../../App_Themes/MunSupervisionProject_Theme/Style.css" rel="stylesheet"
        type="text/css" />

    <script src="../../LigerUI/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/core/base.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/ligerui.min.js" type="text/javascript"></script>

    <script src="../../LigerUI/json2.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerToolBar.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>

    <script src="../../LigerUI/js/ligerui.expand.js" type="text/javascript"></script>

    <script src="../../LigerUI/js/common.js" type="text/javascript"></script>

    <script src="../../LigerUI/js/LG.js" type="text/javascript"></script>

    <link href="../../LigerUI/css/common.css" rel="stylesheet" type="text/css" />

    <script src="../Common/scripts/Common.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>

    <script src="../../SparkClient/DateUtil.js" type="text/javascript"></script>

</head>
<body style="background-color: #EEEEEE;">
    <div style="padding: 2px 0px 0px 1px;">
        <div id="maingrid" style="background-color: White;">
        </div>
    </div>

    <script type="text/javascript">
        var manager;
        $(function() {
            manager = $("#maingrid").ligerGrid({
                columns: [
               { display: '序号', name: 'ROWNUMBER___', align: 'center', type: "text", width: "10%" },
               { display: '竣工验收备案号', name: 'JGBABH', align: 'left', type: "text", width: "25%",
                   render: function(item) {
                       if (item.JGBABH != null && item.JGBABH != "") {
                           return "<a target='_blank' href='Jgys.aspx?LoginID=<%=this.WorkUser.UserID %>&rowid=" + item.ROW_ID + "' style='color:#000066;text-decoration: none;' >" + item.JGBABH + "</a>";
                       }
                   }
               },

                { display: '竣工备案管理部门', name: 'JGBAGLBM', align: 'center', type: 'text', width: "25%" },
                { display: '竣工备案受理人', name: 'JGBASLR', align: 'center', type: 'text', width: "20%" },
                { display: '竣工备案受理时间', name: 'JGBASLSJ', align: 'center', type: 'text', width: "20%" }

                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: getGridIsScroll(),
                url: 'List.ashx?fromwhere=GcxmJgys&rowid=<%=rowID %>',
                dataAction: 'server', //服务器排序
                usePager: true,       //服务器分页
                pageSize: 15,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: getGridHeight()
            });
        });
     
    </script>

</body>
</html>
