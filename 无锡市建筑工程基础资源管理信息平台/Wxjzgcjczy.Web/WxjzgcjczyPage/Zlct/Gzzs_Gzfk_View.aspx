﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gzzs_Gzfk_View.aspx.cs" Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.Zlct.Gzzs_Gzfk_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Bigdesk8" Namespace="Bigdesk8.Web.Controls" TagPrefix="Bigdesk8" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-grid.css" rel="stylesheet"
        type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-form.css" rel="stylesheet"
        type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-tab.css" rel="stylesheet"
        type="text/css" />
    <link href="../../App_Themes/MunSupervisionProject_Theme/Style.css" rel="stylesheet"
        type="text/css" />
    <link href="../Common/css/base.css" rel="stylesheet" type="text/css" />
    <link href="../Common/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../../LigerUI/css/common.css" rel="stylesheet" type="text/css" />

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

    <script src="../../SparkClient/DateUtil.js" type="text/javascript"></script>

    <script src="../Common/scripts/Common.js" type="text/javascript"></script>

    <script src="../../SparkClient/DateTime.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" width="100%" height="100%">
        <tr>
            <td>
                <table cellspacing="1" width="100%" align="center" border="0" class="table-bk">
                    <tr style="height: 20px;">
                        <td style="background-color: White" colspan="4">
                            <div style="position: relative; top: 0px; left: 0px;">
                                <img alt="" src="../Common/icons/communication.gif" height="20px" width="20px" /><span
                                    style="line-height: 22px; padding-left: 3px;"><b>工作指示信息</b></span>
                            </div>
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td width="15%" class="td-text">
                            指示主题
                        </td>
                        <td width="35%" class="td-value" colspan="3">
                            <Bigdesk8:DBText ID="db_Gzzszt" runat="server" ItemName="Gzzszt"></Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="td-text">
                            指示内容
                        </td>
                        <td width="35%" class="td-value" colspan="3" style="padding: 2px;">
                            <Bigdesk8:DBMemo ID="db_GzzsNr" runat="server" ItemName="GzzsNr" Width="99%" ItemNameCN="指示内容"></Bigdesk8:DBMemo>
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td width="15%" class="td-text">
                            指示人
                        </td>
                        <td width="35%" class="td-value">
                            <Bigdesk8:DBText ID="db_ZsrName" runat="server" ItemName="ZsrName"></Bigdesk8:DBText>
                        </td>
                        <td width="15%" class="td-text">
                            指示时间
                        </td>
                        <td width="35%" class="td-value">
                            <Bigdesk8:DBText ID="dp_Zssj" runat="server" ItemName="Zssj" ItemType="DateTime"></Bigdesk8:DBText>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="1" width="100%" align="center" border="0" class="table-bk">
                    <tr style="height: 20px;">
                        <td style="background-color: White" colspan="4">
                            <div style="position: relative; top: 0px; left: 0px;">
                                <img alt="" src="../Common/icons/communication.gif" height="20px" width="20px" /><span
                                    style="line-height: 22px; padding-left: 3px;"><b>工作指示反馈信息</b></span>
                                    <span style=" display:none;"><Bigdesk8:DBText ID="db_zshfState" runat="server"  ItemType="String" ItemName="DataState" ></Bigdesk8:DBText></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="td-text">
                            反馈人
                        </td>
                        <td width="35%" class="td-value">
                            <Bigdesk8:DBText ID="db_ZshfrName" runat="server" ItemName="ZshfrName"></Bigdesk8:DBText>
                        </td>
                        <td width="15%" class="td-text">
                            反馈时间
                        </td>
                        <td width="35%" class="td-value">
                            <Bigdesk8:DBText ID="db_Zshfsj" runat="server"  ItemType="DateTime" ItemName="Zshfsj" ></Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="td-text">
                            反馈内容
                        </td>
                        <td width="85%" class="td-value"  colspan="3">
                            <Bigdesk8:DBMemo ID="db_ZshfNr" ItemName="ZshfNr" runat="server" 
                                 ></Bigdesk8:DBMemo>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script>

      
    </script>
</body>
</html>
