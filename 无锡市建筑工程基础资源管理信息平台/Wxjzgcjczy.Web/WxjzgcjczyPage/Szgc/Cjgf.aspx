﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cjgf.aspx.cs" Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.Szgc.Cjgf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Bigdesk8" Namespace="Bigdesk8.Web.Controls" TagPrefix="Bigdesk8" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看安全监督项目信息</title>
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
<body style="padding: 0px; margin-top: 2px;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding: 0; margin: 0;">
                <table cellspacing="1" cellpadding="0" width="100%" align="center" border="0" class="table-bk">
                    <tr>
                        <td colspan="4" class="td-value">
                            <span style="color: blue; font-size: 14px;">建设单位信息</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            建设单位名称
                        </td>
                        <td class="td-value">
                            <a style="color: Blue; text-decoration: none; cursor: hand;" onclick="CheckID('<%=jsdwrowid %>','jsdw')"
                                target="_blank">
                                <Bigdesk8:DBText ID="DBText24" runat="server" ItemName="jsdw">
                                </Bigdesk8:DBText></a>
                        </td>
                        <td class="td-text">
                            组织机构代码证
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText25" runat="server" ItemName="jsdwZzjgdm">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            单位地址
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText26" runat="server" ItemName="dwdz">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText27" runat="server" ItemName="lxdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            单位法人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText28" runat="server" ItemName="fddbr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            法人联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText29" runat="server" ItemName="fddbrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            建设单位现场负责人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText30" runat="server" ItemName="jsdwfzr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            负责人电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText31" runat="server" ItemName="jsdwfrzdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            开户银行
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText32" runat="server" ItemName="khyh">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            银行账号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText33" runat="server" ItemName="khzh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <%--  <tr>
                        <td style="background-color: #FFF; height: 25px; padding-top: 2px; padding-bottom: 2px;"
                            colspan="4">
                            <Bigdesk8:PowerDataGrid ID="gridView" runat="server" AutoGenerateColumns="False"
                                PagerSettings-Position="Top" Width="100%" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="rownum" HeaderText="序号">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="10%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Zzbz" HeaderText="主项/增项">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="30%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Zzlb" HeaderText="资质名称">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="30%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Zzdj" HeaderText="资质等级">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="30%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                </Columns>
                            </Bigdesk8:PowerDataGrid>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="4" class="td-value">
                            <span style="color: blue; font-size: 14px;">施工单位信息</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text" width="15%">
                            施工单位
                        </td>
                        <td class="td-value" width="35%">
                            <a style="color: Blue; text-decoration: none; cursor: hand;" onclick="CheckID('<%=sgdwrowid %>','sgdw')"
                                target="_blank">
                                <Bigdesk8:DBText ID="DBText34" runat="server" ItemName="sgdw">
                                </Bigdesk8:DBText></a>
                        </td>
                        <td class="td-text" width="15%">
                            组织机构代码证
                        </td>
                        <td class="td-value" width="35%">
                            <Bigdesk8:DBText ID="DBText35" runat="server" ItemName="sgdwzzjgdm1">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            施工单位类别
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText36" runat="server" ItemName="sylx">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            营业执照注册编号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText37" runat="server" ItemName="yyzzzch">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            属地
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText38" runat="server" ItemName="county">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            资质证书编号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText39" runat="server" ItemName="zzzsh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            通讯地址
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText40" runat="server" ItemName="xxdd">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText41" runat="server" ItemName="sgdwlxdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td colspan="4" style="background-color: #fff;">
                            <table cellspacing="1" cellpadding="0" width="100%" align="center" border="0" class="table-bk">--%>
                    <tr>
                        <td class="td-text">
                            法定代表人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText42" runat="server" ItemName="sgdwfddbr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText43" runat="server" ItemName="sgdwfddbrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            企业经理
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText45" runat="server" ItemName="sgdwqyjl">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText46" runat="server" ItemName="sgdwlxdh1">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            单位性质
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText44" runat="server" ItemName="sgdwjjxz">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            邮编
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText47" runat="server" ItemName="yzbm">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <%-- </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="td-text">
                            驻锡委托法人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText48" runat="server" ItemName="zxwtfr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText49" runat="server" ItemName="zxwtfrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            驻锡技术负责人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText50" runat="server" ItemName="zxjsfzr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            电话号码
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText51" runat="server" ItemName="zxjsfzrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            驻锡安全负责人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText52" runat="server" ItemName="zxaqfzr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText53" runat="server" ItemName="zxaqfzrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            安全生产负责人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText54" runat="server" ItemName="aqfzr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText55" runat="server" ItemName="aqfzrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            企业主营范围
                        </td>
                        <td class="td-value" colspan="3">
                            <Bigdesk8:DBMemo ID="mb_qyzyfw" runat="server" ItemName="zyfw">
                            </Bigdesk8:DBMemo>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            企业兼营范围
                        </td>
                        <td class="td-value" colspan="3">
                            <Bigdesk8:DBMemo ID="mb_qyjyfw" runat="server" ItemName="jyfw">
                            </Bigdesk8:DBMemo>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="td-value">
                            <span style="color: blue; font-size: 14px;">项目经理信息</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            项目经理
                        </td>
                        <td class="td-value">
                            <a style="color: Blue; text-decoration: none; cursor: hand;" onclick="CheckID('<%=ryrowid %>','ry')"
                                target="_blank">
                                <Bigdesk8:DBText ID="DBText56" runat="server" ItemName="xmjl">
                                </Bigdesk8:DBText></a>
                        </td>
                        <td class="td-text">
                            项目经理联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText57" runat="server" ItemName="xmjldh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            项目经理（建造师）注册号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText58" runat="server" ItemName="zcjzszh">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            项目经理安全考核证书编号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText59" runat="server" ItemName="aqkhzsbh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="td-value">
                            <span style="color: blue; font-size: 14px;">项目组成员 </span>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFF; height: 25px; padding-top: 2px; padding-bottom: 2px;"
                            colspan="4">
                            <Bigdesk8:PowerDataGrid ID="pdg_Aqbjxmzcy" runat="server" AutoGenerateColumns="False"
                                PagerSettings-Position="Top" Width="100%" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="rownum" HeaderText="序号">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="10%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="XM" HeaderText="姓名">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RYGW" HeaderText="岗位">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QYMC" HeaderText="所属单位">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ZZLB" HeaderText="资质类别">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ZZDJ" HeaderText="资质等级">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ZYZGZSH" HeaderText="执业资格证书号">
                                        <ItemStyle CssClass="pdg-itemstyle-center" Width="15%" />
                                        <HeaderStyle CssClass="pdg-headerstyle-center" />
                                    </asp:BoundField>
                                </Columns>
                            </Bigdesk8:PowerDataGrid>
                            <%--  <div id="DivAqbjxmzcy" style="background-color: White;">
                            </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="td-value">
                            <span style="color: blue; font-size: 14px;">监理单位信息</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            监理单位
                        </td>
                        <td class="td-value">
                            <a style="color: Blue; text-decoration: none; cursor: hand;" onclick="CheckID('<%=jldwrowid %>','jldw')"
                                target="_blank">
                                <Bigdesk8:DBText ID="DBText60" runat="server" ItemName="jldw">
                                </Bigdesk8:DBText></a>
                        </td>
                        <td class="td-text">
                            组织机构代码证
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText61" runat="server" ItemName="jldwzzjgdm">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            单位法人
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText62" runat="server" ItemName="jldwfddbr">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText63" runat="server" ItemName="jldwfddbrdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            单位地址
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText64" runat="server" ItemName="jldwdz">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText65" runat="server" ItemName="jldwdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td colspan="4" style="background-color: #fff;">
                            <table cellspacing="1" cellpadding="0" width="100%" align="center" border="0" class="table-bk">--%>
                    <tr>
                        <td class="td-text">
                            项目总监
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText66" runat="server" ItemName="xmzj">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            资质证书编号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText67" runat="server" ItemName="xmzjzzzsh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            总监代表
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText69" runat="server" ItemName="zjdb">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            资质证书编号
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText70" runat="server" ItemName="zjdbzsh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-text">
                            总监联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText68" runat="server" ItemName="xmzjdh">
                            </Bigdesk8:DBText>
                        </td>
                        <td class="td-text">
                            总监代表联系电话
                        </td>
                        <td class="td-value">
                            <Bigdesk8:DBText ID="DBText71" runat="server" ItemName="zjdbdh">
                            </Bigdesk8:DBText>
                        </td>
                    </tr>
                    <%--  </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="4" class="td-value" style="text-align: center">
                            <br />
                            <input type="button" value="领导批示" onclick="openLdpsWindow()" class="button" style="width: 100px;
                                height: 30px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function CheckID(id, lx) {
            if (id == "" || id == null) {
                alert("您所访问的信息不存在！");
            }
            else {
                switch (lx) {
                    case "sgdw":
                        window.open("../Szqy/QyxxToolBar.aspx?dwlx=sgdw&rowid=" + id, "_blank");
                        break;
                    case "jldw":
                        window.open("../Szqy/QyxxToolBar.aspx?dwlx=jldw&befrom=jldw&rowid=" + id, "_blank");
                        break;
                    case "qy":
                        window.open("../Szqy/QyxxToolBar.aspx?rowid=" + id, "_blank");
                        break;
                    case "jsdw":
                        window.open("../Szqy/JsdwxxToolBar.aspx?rowid=" + id, "_blank");
                        break;
                    case "ry":
                        window.open("../Zyry/RyxxToolBar.aspx?rowid=" + id, "_blank");
                        break;
                }

            }
        }

        $(function() {
            var manager;
            manager = $("#maingrid").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '主项/增项', name: 'ZZBZ', align: 'center', type: "text", width: "30%" },
                { display: '资质名称', name: 'ZZLB', align: 'center', type: 'text', width: "30%" },
                { display: '资质等级', name: 'ZZDJ', align: 'center', type: 'text', width: "30%" }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=QyxxView&qyid=<%=jsdwrowid %>',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })

        $(function() {
            var manager;
            manager = $("#DivAqbjxmzcy").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '姓名', name: 'XM', align: 'center', type: "text", width: "15%" },
                { display: '岗位', name: 'RYGW', align: 'center', type: 'text', width: "15%" },
                { display: '所属单位', name: 'QYMC', align: 'center', type: 'text', width: "15%" },
                { display: '资质类别', name: 'ZZLB', align: 'center', type: 'text', width: "15%" },
                { display: '资质等级', name: 'ZZDJ', align: 'center', type: 'text', width: "15%" },
                { display: '执业资格证书号', name: 'ZYZGZSH', align: 'center', type: 'text', width: "15%" }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=Aqbjxmzcy&rowid=<%=rowID %>',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })

        $(function() {
            var manager;
            manager = $("#DivZljd").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '质监项目', name: 'XMMC', align: 'left', type: "text", width: "20%" },
                { display: '监督注册号', name: 'JDZCH', align: 'center', type: 'text', width: "15%" },
                { display: '质量监督受理部门', name: 'ZLJDGLBM', align: 'center', type: 'text', width: "15%" },
                { display: '质量监督受理人', name: 'ZLJDSLR', align: 'center', type: 'text', width: "15%" },
                { display: '质量监督受理时间', name: 'ZLJDSLSJ', align: 'center', type: 'text', width: "15%",
                    render: function(item) {
                        if (item.ZLJDSLSJ != "" && item.ZLJDSLSJ != undefined) {
                            return DateUtil.dateToStr('yyyy-MM-dd', DateUtil.strToDate(item.ZLJDSLSJ));
                        }
                    }
                },
                { display: '详细', name: '', align: 'center', type: 'text', width: "10%", render: function(item) {
                    if (item.ZLJDID != "" && item.ZLJDID != undefined)
                        return "<a target='_blank' href='Zljdzs.aspx?LoginID=<%=this.WorkUser.UserID %>&rowid=" + item.ROW_ID + "' style='color:#000066;text-decoration: none;' >" + "详细" + "</a>";
                }
                }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=AqjdZljd&rowid=<%=rowID %>',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })


        $(function() {
            var manager;
            manager = $("#DivSgxk").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '项目名称', name: 'XMMC', align: 'left', type: "text", width: "20%" },
                { display: '施工许可证编号', name: 'SGXKZBH', align: 'center', type: 'text', width: "15%" },
                { display: '施工许可受理时间', name: 'SGXKSLSJ', align: 'center', type: 'text', width: "15%",
                    render: function(item) {
                        if (item.SGXKSLSJ != "" && item.SGXKSLSJ != undefined) {
                            return DateUtil.dateToStr('yyyy-MM-dd', DateUtil.strToDate(item.SGXKSLSJ));
                        }
                    }
                },
                { display: '施工许可管理部门', name: 'SGXKGLBM', align: 'center', type: 'text', width: "15%" },
                { display: '施工许可受理人', name: 'SGXKSLR', align: 'center', type: 'text', width: "15%" },
                { display: '详细', name: '', align: 'center', type: 'text', width: "10%",
                    render: function(item) {
                        if (item.SGXKID != "" && item.SGXKID != undefined)
                            return "<a target='_blank' href='Sgxkzs.aspx?LoginID=<%=this.WorkUser.UserID %>&rowid=" + item.ROWID + "' style='color:#000066;text-decoration: none;' >" + "详细" + "</a>";
                    }
                }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=AqjdSgxk&rowid=<%=rowID %>',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })
        $(function() {
            var manager;
            manager = $("#DivJgys").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '项目名称', name: 'XMMC', align: 'left', type: "text", width: "35%" },
                { display: '竣工备案管理部门', name: 'JGBAGLBM', align: 'center', type: 'text', width: "20%" },
                { display: '竣工备案受理时间', name: 'JGBASLSJ', align: 'center', type: 'text', width: "15%",
                    render: function(item) {
                        if (item.JGBASLSJ != "" && item.JGBASLSJ != undefined) {
                            return DateUtil.dateToStr('yyyy-MM-dd', DateUtil.strToDate(item.JGBASLSJ));
                        }
                    }
                },
                { display: '竣工备案受理人', name: 'JGBASLR', align: 'center', type: 'text', width: "20%" }
                //                { display: '详细', name: '', align: 'center', type: 'text', width: "15%",
                //                    render: function(item) {
                //                        if (item.ZLJDID != "" && item.ZLJDID != undefined)
                //                            return '详细';
                //                    }
                //                }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=AqjdJgba&rowid=<%=rowID %>',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })

        $(function() {
            var manager;
            manager = $("#DivAqbjxmzcy").ligerGrid({
                columns: [
                { display: '序号', name: 'ROWNUM', align: 'center', type: "text", width: "10%" },
                { display: '姓名', name: 'XM', align: 'center', type: "text", width: "15%" },
                { display: '岗位', name: 'RYGW', align: 'center', type: 'text', width: "15%" },
                { display: '所属单位', name: 'QYMC', align: 'center', type: 'text', width: "15%" },
                { display: '资质类别', name: 'ZZLB', align: 'center', type: 'text', width: "15%" },
                { display: '资质等级', name: 'ZZDJ', align: 'center', type: 'text', width: "15%" },
                { display: '执业资格证书号', name: 'ZYZGZSH', align: 'center', type: 'text', width: "15%" }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: true,
                url: 'List.ashx?fromwhere=Aqbjxmzcy&rowid=<%=rowID %>&befrom=toolbar',
                dataAction: 'server', //服务器排序
                usePager: false,       //服务器分页
                pageSize: 10,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: 'auto'//getGridHeight()
            });
        })

        function openLdpsWindow() {
            var url = "../Zlct/Gzzs_Gzzs_Edit.aspx?operate=add";
            var arguments = window;
            var features = "dialogWidth=950px;dialogHeight=530px;center=yes;status=yes";
            var argReturn = window.showModalDialog(url, arguments, features);
        }
        function OpenWin(url, title, width, height, isReload) {
            var dialogOptions = { width: width, height: height, title: title, url: url, showMax: true, showMin: true, buttons: [
                { text: '发送', onclick: function(item, dialog) {
                    dialog.frame.f_send(dialog, null);
                }
                },
                { text: '关闭', onclick: function(item, dialog) {
                    dialog.close();
                }
                }
            ], isResize: true, timeParmName: 'a'
            };
            activeDialog = $.ligerDialog.open(dialogOptions);
        }
        //        $("a[rel=example_group]").fancybox({
        //            'transitionIn': 'none',
        //            'transitionOut': 'none',
        //            'titlePosition': 'over',
        //            'titleFormat': function(title, currentArray, currentIndex, currentOpts) {
        //                return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
        //            }
        //        });
    </script>

    </form>
</body>
</html>
