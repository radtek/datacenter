<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index_Zyry.aspx.cs" Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.MainPage.Index_Zyry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ִҵ��Աר��</title>
    <link href="../Common/css/IndexStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../LigerUI/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../../SparkClient/DateTime_ligerui.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/MunSupervisionProject_Theme/Style.css" rel="stylesheet"
        type="text/css" />

    <script src="../../LigerUI/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/ligerui.min.js" type="text/javascript"></script>

    <script src="../../SparkClient/DateTime_ligerui.js" type="text/javascript"></script>

    <script src="../../SparkClient/control_ligerui.js" type="text/javascript"></script>

    <script src="../../SparkClient/jquery.validate.min.js" type="text/javascript"></script>

    <script src="../../LigerUI/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>

    <script src="../../LigerUI/js/common.js" type="text/javascript"></script>

    <script src="../../LigerUI/js/LG.js" type="text/javascript"></script>

    <script src="../Common/scripts/frame.js" type="text/javascript"></script>

    <script src="../Common/scripts/Common.js" type="text/javascript"></script>

    <script type="text/javascript">

        function setHeight(height) {
            var h = window.document.documentElement.clientHeight;
            //window.document.documentElement.clientHeight
            $("#ItemIf").height(h);
            $("#ItemTd").height(h);
        }

    </script>

</head>
<%--<body style="background-color: #4364A9; padding: 0;" onload="leftclick('03010000','left_icon_3_1','left_icon_2_1');">--%>
<body style="background-color: #4364A9; padding: 0;" onload="leftclick4('<%=nodeID %>','<%=treeID %>','<%=zyry %>','<%=rylx %>');">
    <form id="Form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding: 0px 0px 0px 0px;">
        <tr>
            <td width="150" valign="top">
                <div id="leftmenu" style="position: absolute; top: 0px;">
                    <table border="0" cellspacing="0" cellpadding="0" width="150">
                        <tr>
                            <input type="hidden" id="hd2" value="" />
                            <input type="hidden" id="hd2_num" value="" />
                            <td id="left_icon_3_1" class="left_icon_leave" onmousemove="leftover(this.id);" onmouseout="leftout(this.id);"
                                onclick="leftclick('03010000',this.id);">
                                <table style="width: 100%; height: 100%">
                                    <tr>
                                        <td class="tdImg">
                                            <img src="../Common/images/FrameImages/03_01_0.png" />
                                        </td>
                                        <td class="tdFont">
                                            ע��ִҵ��Ա
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="menuSpan">
                            </td>
                        </tr>
                        <tr>
                            <td id="left_icon_3_2" class="left_icon_leave" onmousemove="leftover(this.id);" onmouseout="leftout(this.id);"
                                onclick="leftclick('03020000',this.id);">
                                <table >
                                    <tr>
                                        <td class="tdImg">
                                            <img src="../Common/images/FrameImages/03_02_0.png" />
                                        </td>
                                        <td class="tdFont">
                                            ��ȫ����������Ա
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="menuSpan">
                            </td>
                        </tr>
                        <tr>
                            <td id="left_icon_3_3" class="left_icon_leave" onmousemove="leftover(this.id);" onmouseout="leftout(this.id);"
                                onclick="leftclick('03030000',this.id);">
                                <table >
                                    <tr>
                                        <td class="tdImg">
                                            <img src="../Common/images/FrameImages/03_03_0.png" />
                                        </td>
                                        <td class="tdFont">
                                            ��ҵ������Ա
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="menuSpan">
                            </td>
                        </tr>
                        <tr>
                            <td id="left_icon_3_4" class="left_icon_leave" onmousemove="leftover(this.id);" onmouseout="leftout(this.id);"
                                onclick="leftclick('03040000',this.id);">
                                <table>
                                    <tr>
                                        <td class="tdImg">
                                            <img src="../Common/images/FrameImages/03_04_0.png" />
                                        </td>
                                        <td class="tdFont">
                                            רҵ��λ������Ա
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="menuSpan">
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
             
            <td id="ItemTd" bgcolor="#EEEEEE" style="padding: 0; padding-left: 4px;">
                <iframe id="ItemIf" width="100%" style="padding: 0;" scrolling="no" onload="setHeight(window.document.documentElement.clientHeight)"
                    frameborder="0"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
