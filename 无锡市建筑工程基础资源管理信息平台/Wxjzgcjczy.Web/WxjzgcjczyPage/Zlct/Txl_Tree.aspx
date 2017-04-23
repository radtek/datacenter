<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Txl_Tree.aspx.cs" Inherits="Wxjzgcjczy.Web.WxjzgcjczyPage.Zlct.Txl_Tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <link rel="stylesheet" type="text/css" href="../../zTree-v3.5.14/css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../../zTree-v3.5.14/css/zTreeStyle/zTreeStyle.css" />

    <script type="text/javascript" src="../../zTree-v3.5.14/js/jquery-1.4.4.min.js"></script>

    <script type="text/javascript" src="../../zTree-v3.5.14/js/jquery.ztree.core-3.5.min.js"></script>

    <script type="text/javascript" src="../../zTree-v3.5.14/js/jquery.ztree.excheck-3.5.min.js"></script>

    <script src="../Common/scripts/Common.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        var type = getParamValue("type");
        var gzzsId = getParamValue("gzzsId");
        var dxjbId = getParamValue("dxjbId");
        var setting = {
            view: {
                showIcon: isShowIcon,
                fontCss: getFont
            },
            check: {
                enable: true,
                autoCheckTrigger: true,
                chkStyle: "checkbox"
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onDblClick: false,
                beforeCheck: beforeCheck,
                onCheck: onChecked,
                beforeClick: beforeClicked
            }
        };
        var zNodes = "";
        function LoadSjmlZTree() {

            if (type == "gzzs") {
                $.ajax({
                    type: 'POST',
                    url: '../Handler/Data.ashx?type=getTxlTree&gzzsId=' + gzzsId,
                    async: false,
                    data: null,
                    success: function(res) {
                        closeBg();
                        zNodes = eval('(' + res + ')');
                        $.fn.zTree.init($("#treeTxl"), setting, zNodes);

                    }
                });
            }
            else
                if (type == "dxjb") {
                $.ajax({
                    type: 'POST',
                    url: '../Handler/Data.ashx?type=getTxlTree_Dxjb&dxjbId=' + dxjbId,
                    async: false,
                    data: null,
                    success: function(res) {
                        closeBg();
                        zNodes = eval('(' + res + ')');
                        $.fn.zTree.init($("#treeTxl"), setting, zNodes);

                    }
                });
            }
        }

        function isShowIcon(treeId, treeNode) {

            return true; // treeNode.isParent;
        }

        function getFont(treeId, node) {
            return node.font ? node.font : {};
        }

        function beforeCheck(treeId, treeNode, clickFlag) {

            var zTree = $.fn.zTree.getZTreeObj("treeTxl");

            if (!treeNode.isParent) {
                var name = treeNode.name;

                var number = name.substring(name.indexOf('��') + 1, name.indexOf('��'));
                if (number == null || number == "" || number == "undefined") {

                    if (window.parent.location.href.indexOf("Dxjb_Send.aspx") >= 0) {
                        if (!treeNode.checked) {
                            parentAlert("����ϵ��û���ֻ����룬�޷�����<br/>����Ϣ��");
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        function beforeClicked(treeId, treeNode, clickFlag) {
            var zTree = $.fn.zTree.getZTreeObj("treeTxl");
            if (treeNode.isParent) {
                zTree.expandNode(treeNode, null, null, null, null);
            }

            return false;
        }


        function onChecked(event, treeId, treeNode) {
            var winP = parent || window;
            var zTree = $.fn.zTree.getZTreeObj("treeTxl");
            if (!treeNode.isParent) {
                if (treeNode.checked) {
                    winP.fSelectedSjr(treeNode.id, treeNode.name);
                }
                else {
                    fCanbeDelete(treeNode.id);
                }
            }
        }

        function fCanbeDelete(code) {
            /*  �˴�������������ظ���ӡ�ɾ�����⡣
            �����һ��˼�룺
            ����һ�����������жϽ��true��false�ı�����
            ������ǰ�����ж��Ƿ�Ҫ���иò��������жϽ����ֵ���ñ�����
            Ȼ�����Ϊtrue����У�false��ȡ��*/
            //�ҵ����б�Checked�Ľڵ�
            var treeObj = $.fn.zTree.getZTreeObj("treeTxl");
            var oCheckedNodes = treeObj.getCheckedNodes(true);
            var bCanDelete = true;

            for (var i = 0; i < oCheckedNodes.length; i++) {
                /*  ����ѹ�ѡ�Ľڵ�ID��Ҫɾ���Ľڵ�ID��ȣ�
                �Ǿ�˵����ͬһ���˱��ظ���ѡ��
                �Ҵ�ʱ����Ա���б���ѡ�Ľڵ㣬
                ���ж�������ɾ���� */
                if (oCheckedNodes[i].checked) {
                    if (!oCheckedNodes[i].isParent) {
                        if (oCheckedNodes[i].id === code) {
                            bCanDelete = false; //��CanDelete ��ֵΪfalse
                            break;
                        }
                    }
                }
            }
            var winP = parent || window;
            return winP.fDeleteSjr(code, bCanDelete);
        }
        function parentAlert(msg) {
            var winP = parent || window;
            if (winP.showMessage != "undefined")
                return winP.showWarn(msg);

        }
        //��ʾ��ɫJS���ֲ�
        function showBg() {
            var ct = "dialog";
            var bH = $(document).height() + 30;
            var bW = $(document).width() + 16;
            var objWH = getObjWh(ct);

            var tbT = objWH.split("|")[0] + "px";
            var tbL = objWH.split("|")[1] + "px";

            $("#fullbg").css({ width: bW, height: bH, display: "block" });
            $("#" + ct).css({ top: tbT, left: tbL, display: "block" });
            $(window).scroll(function() { resetBg() });
            $(window).resize(function() { resetBg() });

            window.setTimeout(LoadSjmlZTree, 10);
        }

        function getObjWh(obj) {

            var st = document.documentElement.scrollTop; //�������ඥ���ľ���
            var sl = document.documentElement.scrollLeft; //����������ߵľ���
            var ch = document.documentElement.clientHeight; //��Ļ�ĸ߶�
            var cw = document.documentElement.clientWidth; //��Ļ�Ŀ��
            var objH = $("#" + obj).height(); //��������ĸ߶�
            var objW = $("#" + obj).width(); //��������Ŀ��
            var objT = Number(st) + (Number(ch) - Number(objH)) / 2;
            var objL = Number(sl) + (Number(cw) - Number(objW)) / 2;

            return objT + "|" + objL;
        }
        function resetBg() {
            var fullbg = $("#fullbg").css("display");
            if (fullbg == "block") {
                var bH2 = $(document).height();
                var bW2 = $(document).width();
                $("#fullbg").css({ width: bW2, height: bH2 });
                var objV = getObjWh("dialog");
                var tbT = objV.split("|")[0] + "px";
                var tbL = objV.split("|")[1] + "px";
                $("#dialog").css({ top: (tbT - 100), left: tbL });
            }
        }

        //�رջ�ɫJS���ֲ�Ͳ�������
        function closeBg() {
            $("#fullbg").css("display", "none");
            $("#dialog").css("display", "none");
        }

        $(document).ready(function() {
            showBg();
        });
    </script>

    <style type="text/css">
        body
        {
            color: #000; /* MAIN BODY TEXT COLOR */
            font-family: "Lucida Grande" , "Lucida Sans Unicode" ,Arial,Verdana,sans-serif;
            font-size: 16px;
        }
        #fullbg
        {
            background-color: #33393C;
            display: none;
            z-index: 1000;
            position: absolute;
            left: 0px;
            top: 0px;
            filter: Alpha(Opacity=40);
            -moz-opacity: 0.4;
            opacity: 0.4;
        }
        #dialog
        {
            position: absolute;
            width: 200px;
            height: 40px;
            background: #EFEFEF;
            display: none;
            z-index: 1005;
            vertical-align: middle;
            text-align: left;
        }
    </style>
</head>
<body style="border: none;">
    <ul id="treeTxl" class="ztree" style="width: 95%; margin-top: 1px; background-color: transparent;
        height: 430px; border: none;">
    </ul>
    <!-- JS���ֲ� -->
    <div id="fullbg">
    </div>
    <!-- end JS���ֲ� -->
    <!-- JS���ֲ��Ϸ��ĶԻ��� -->
    <div id="dialog">
        <div style="text-align: center; width: 100%; height: 100%; padding-top: 7px;">
            <img src="../../jquery-easyui-1.3.0/themes/gray/images/panel_loading.gif" />
            �ռ����б������...</div>
    </div>
</body>
</html>
