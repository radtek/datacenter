﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zczyry_List.aspx.cs" Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.Zyry.Zczyry_List" %>

<%@ Register Assembly="Bigdesk8" Namespace="Bigdesk8.Web.Controls" TagPrefix="Bigdesk8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>注册执业人员信息列表</title>
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

</head>
<body style="background-color: #EEEEEE;">
    <form id="formsearch" class="l-form" style="padding: 0px 0px 0px 0px; margin: 1px;">
    <table cellspacing="1" width="100%" align="center" border="0" class="table-bk">
        <tr>
            <td width="11%" class="td-text">
                人员姓名
            </td>
            <td width="22%" class="td-value">
                <input type="text" class="field s-text" name="xm" style="width: 200px" />
            </td>
            <td width="11%" class="td-text">
                身份证号
            </td>
            <td width="22%" class="td-value">
                <input type="text" class="field s-text" name="zjhm" style="width: 200px" up="upper" />
            </td>
            <td width="11%" class="td-text">
                证书编号
            </td>
            <td width="22%" class="td-value">
                <input type="text" class="field s-text" name="zsbh" style="width: 200px" />
            </td>
        </tr>
        <tr>
            <td class="td-text">
                所在企业
            </td>
            <td class="td-value" colspan="3">
                <input type="text" class="field s-text" name="qymc" style="width: 200px" />
            </td>
            <td class="td-text">
                属地
            </td>
            <td class="td-value" id="Td2">
                <select class="field s-text" name="CountyID" op="equal" style="width: 250px;">
                </select>
            </td>
          
        </tr>
        <tr>
          <td class="td-text">
                是否作废
            </td>
            <td class="td-value" id="Td1">
                <select class="field s-text" name="AJ_IsRefuse" op="equal" style="width: 200px;">
                    <option value="">请选择</option>
                    <option value="0">正常</option>
                    <option value="1">作废</option>
                </select>
            </td>
              <td class="td-text">
               <%-- 是否安监实名认证--%>
            </td>
            <td class="td-value" id="Td4">
               <%-- <select class="field s-text" name="AJ_EXISTINIDCARDS" op="equal" style="width: 200px;">
                    <option value="">请选择</option>
                    <option value="1">未实名认证</option>
                    <option value="2">已实名认证</option>
                </select>--%>
            </td>
             <td class="td-text">
                <%--上报状态--%>
            </td>
            <td class="td-value" id="Td3">
              <%-- <select class="field s-text" name="SbToStState" op="equal" style="width: 200px;">
                    <option value="">请选择</option>
                    <option value="-1">未上报</option>
                    <option value="0">已上报</option>
                    <option value="1">上报出错</option>
                </select>--%>
            </td>
        </tr>
        
        <tr>
            <td class="td-text">
                人员类型
            </td>
            <td class="td-value" colspan="5">
                <input name="aa" id="jzs" type="checkbox" value="1" />注册建造师&nbsp;&nbsp;
                 <input name="aa" id="xxxmgls" type="checkbox" value="2" />小型项目管理师&nbsp;&nbsp;
                <input name="aa" id="jls" type="checkbox" value="21" />注册监理师&nbsp;&nbsp;
                <input name="aa" id="zjs" type="checkbox" value="41" />注册造价师&nbsp;&nbsp;
                <input name="aa" id="jzhus" type="checkbox" value="51" />注册建筑师&nbsp;&nbsp;
                <input name="aa" id="jgs" type="checkbox" value="61" />注册结构师&nbsp;&nbsp;<span style="display: none;">
                    <input type="text" class="field" name="ryzyzglxID" op="equal" /></span>
            </td>
        </tr>
        
          <tr>
            <td class="td-value" colspan="6">
                  <div id="btn_search" style="text-align: right">
                 </div>
            </td>
        </tr>
    </table>
    </form>
    <div style="padding: 2px 0px 0px 1px;">
        <div id="maingrid" style="background-color: White;">
        </div>
    </div>

    <script type="text/javascript">
        var manager;
        var rylx = '<%=rylx %>';
        $(function() {


        $.ajax({
            type: 'post', cache: false, dataType: 'text',
            url: '../Handler/Data.ashx?type=rysd',
            async: false,
            success: function(result) {
               
                if (result) {
                    $("select[name='CountyID']").html(result);
                }
            },
            error: function() {

            }
        });
        
        
            $("#Td1").ligerForm({
                toJSON: JSON2.stringify
            });
            $("#Td2").ligerForm({
                toJSON: JSON2.stringify
            });
//            $("#Td3").ligerForm({
//                toJSON: JSON2.stringify
//            });
//            $("#Td4").ligerForm({
//                toJSON: JSON2.stringify
//            });
            if (rylx != null && rylx != '') {
                switch (rylx) {
                    case "jzs":
                        $("input[id='jzs']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("1");
                        break;
                    case "xxxmgls":
                        $("input[id='xxxmgls']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("2");
                        break;
                    case "jls":
                        $("input[id='jls']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("21");
                        break;
                    case "zjs":
                        $("input[id='zjs']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("41");
                        break;
                    case "jzhus":
                        $("input[id='jzhus']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("51");
                        break;
                    case "jgs":
                        $("input[id='jgs']").attr("checked", "checked");
                        $("input[name='ryzyzglxID']").val("61");
                        break;

                }
            }


          

            var prameters = "";
            var rule = LG.bulidFilterGroup("#formsearch");
            if (rule.rules.length) {
                prameters = JSON2.stringify(rule);
            }

            manager = $("#maingrid").ligerGrid({
                columns: [

                //                { display: '序号', name: 'ROWNUMBER___', align: 'center', type: "text", width: "5%" },
               {display: '人员姓名', align: 'center', type: "text", width: "8%",
               render: function(item) {
                   if (item.xm != null && item.xm != "") {
                       return "<a target='_blank' href='RyxxToolBar.aspx?ryid=" + item.ryid + "&rylx=zczyry' style='color:#000066;text-decoration: none;' >" + item.xm + "</a>";
                   }
               }
           },
                { display: '身份证号', name: 'zjhm', align: 'center', type: "text", width: "16%" },
//                { display: '职称级别', name: 'zcjb', align: 'center', type: 'text', width: "8%" },
             
                { display: '执业资格类型', name: 'ryzyzglx', align: 'center', type: 'text', width: "8%" },
                { display: '证书编号', name: 'zsbh', align: 'center', type: 'text', width: "14%" },
                { display: '单位名称', name: 'qymc', align: 'left', type: "text", width: "25%",
                    render: function(item) {
                        if (item.qymc != null && item.qymc != "") {
                            return "<a target='_blank' href='../Szqy/QyxxToolBar.aspx?qyid=" + item.qyid + "' style='color:#000066;text-decoration: none;' >" + item.qymc + "</a>";
                        }
                    }
                },
                { display: '属地', name: 'county', align: 'center', type: 'text', width: "8%" },
                   { display: '联系电话', name: 'lxdh', align: 'center', type: 'text', width: "9%" },
                   { display: '证书有效止日期', name: 'zsyxzrq', align: 'center', type: 'text', width: "8%" }
//                { display: '是否安监实名认证', name: 'sfsmrz', align: 'center', type: 'text', width: "9%" }

//                { display: '上报状态', name: 'SbState', align: 'center', type: 'text', width: "7%" }

                //                { display: '在建工程', name: 'YWZJGC', align: 'center', type: 'text', width: "7%" }
                ], width: '99.8%', pageSizeOptions: [5, 10, 15, 20], isScroll: getGridIsScroll(),
                url: 'List.ashx?fromwhere=Ryxx&rylx=zczyry',
                parms: { where: prameters },
                dataAction: 'server', //服务器排序
                usePager: true,       //服务器分页
                pageSize: 15,
                rownumbers: false,
                alternatingRow: true,
                checkbox: false,
                height: getGridHeight()
            });

            //增加搜索按钮,并创建事件
            LG.appendSearchButtons1("#formsearch", "#btn_search", manager);

            $("input[name='aa']").click(function() {

                var str = "";
                $("input[name='aa']:checkbox").each(function() {
                    if ($(this).attr("checked") == true) {

                        str += $(this).val() + ","
                    }
                })
                if (str != "")
                    str = str.substr(0, str.length - 1);

                $("input[name='ryzyzglxID']").val(str);


            });

        });
     


    </script>

    <form id="form1" runat="server" style="display: none">
    </form>
</body>
</html>
