<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zhjg_Lxxmdj_List.aspx.cs"
    Inherits="IntegrativeShow2.SysFiles.PagesZhjg.Zhjg_Lxxmdj_List" %>
<%@ Register Assembly="Bigdesk8" Namespace="Bigdesk8.Web.Controls" TagPrefix="Bigdesk8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../App_Themes/Themes_Standard/Stylesheet1.css" rel="Stylesheet" type="text/css" />

    <script src="../../Common/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../MyDatePicker/WdatePicker.js" type="text/javascript"></script>
       
    <script type="text/javascript">
         $(function () {

             $("input[FieldType='Date']").click(function () {
                 WdatePicker({ isShowClear: true, readOnly: true });
             });

         });
    </script>

</head>
<body class="body_haveBackImg">
    <form id="form1" runat="server">
    <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="td_search" style="width: 1580px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="2" cellspacing="1" border="0" class="table">
                                <tr>
                                    <td class="td_text" width="15%">
                                        ��Ŀ���
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBTextBox ID="DBTextBox1" ItemName="PrjNum" runat="server">
                                        </Bigdesk8:DBTextBox>
                                    </td>
                                    <td class="td_text" width="15%">
                                        ��Ŀ����
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBTextBox ID="DBTextBox2" ItemName="PrjName" runat="server">
                                        </Bigdesk8:DBTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_text" width="15%">
                                        �����������
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBTextBox ID="PrjInnerNum" ItemName="PrjInnerNum" runat="server">
                                        </Bigdesk8:DBTextBox>
                                    </td>
                                    <td class="td_text" width="15%">
                                        ���赥λ����
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBTextBox ID="BuildCorpName" ItemName="BuildCorpName" runat="server">
                                        </Bigdesk8:DBTextBox>
                                    </td>
                                    <%--    <td class="td_text" width="15%">
                                        �����ĺ�
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBTextBox ID="PrjApprovalNum" ItemName="PrjApprovalNum" runat="server"></Bigdesk8:DBTextBox>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td class="td_text" width="15%">
                                        ��Ŀ����
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBDropDownList ID="ddl_Xmfl" runat="server"  ItemRelation="Equal" 
                                            ToolTip="PrjType" ItemName="PrjTypeNum" >
                                        </Bigdesk8:DBDropDownList>
                                    </td>
                                    <td class="td_text" width="15%">
                                        ��������
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBDropDownList ID="ddl_jsxz" runat="server" ItemRelation="Equal"
                                            ToolTip="PrjProperty" ItemName="PrjPropertyNum" >
                                        </Bigdesk8:DBDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_text" width="15%">
                                        �����
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBDropDownList ID="ddl_lxjb" runat="server" ItemRelation="Equal"
                                            ToolTip="ApprovalLevel" ItemName="PrjApprovalLevelNum" >
                                        </Bigdesk8:DBDropDownList>
                                    </td>
                                    <td class="td_text" width="15%">
                                        ��ʡ״̬
                                    </td>
                                    <td class="td_value" width="35%">
                                        <Bigdesk8:DBDropDownList ID="DBDropDownList2" runat="server" ItemRelation="Equal"
                                             ItemName="OperateState" >
                                            <asp:ListItem Value=""> </asp:ListItem>
                                            <asp:ListItem Value="0">���ϱ�</asp:ListItem>
                                            <asp:ListItem Value="1">δ�ϱ�</asp:ListItem>
                                            <asp:ListItem Value="2">����ʡһ�廯ƽ̨</asp:ListItem>
                                        </Bigdesk8:DBDropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_text" width="15%">
                                        ��Ŀ����
                                    </td>
                                    <td class="td_value" width="85%" colspan="3">
                                        <%--<Bigdesk8:DBDropDownList ID="ddl_ssdq" runat="server" ItemRelation="Equal" ToolTip="Xzqdm"   ItemName="CountyNum"
                                            DropDownListType="Value">
                                        </Bigdesk8:DBDropDownList>--%>
                                        <%--  <Bigdesk8:DBCheckBox ID="dbb_ssdq" runat="server"   ItemName="CountyNum" ValidationGroup="ssdq" />--%>
                                        <asp:CheckBoxList ID="cbl_ssdq" runat="server" RepeatColumns="9">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <asp:PlaceHolder runat="server" ID="holder_gjcx">
                                    <tr>
                                        <td class="td_text" width="15%">
                                            ��������
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBTextBox ID="DBTextBox3" FieldType="Date" Width="36%" ItemName="BDate"
                                                ItemRelation="GreaterThanOrEqual" runat="server">
                                            </Bigdesk8:DBTextBox>
                                            ��
                                            <Bigdesk8:DBTextBox ID="DBTextBox4" FieldType="Date" Width="36%" ItemName="BDate"
                                                ItemRelation="LessThanOrEqual" runat="server">
                                            </Bigdesk8:DBTextBox>
                                        </td>
                                        <td class="td_text" width="15%">
                                            ��������
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBTextBox ID="EDate1" FieldType="Date" Width="36%" ItemName="EDate" ItemRelation="GreaterThanOrEqual"
                                                runat="server">
                                            </Bigdesk8:DBTextBox>
                                            ��
                                            <Bigdesk8:DBTextBox ID="EDate2" FieldType="Date" Width="36%" ItemName="EDate" ItemRelation="LessThanOrEqual"
                                                runat="server">
                                            </Bigdesk8:DBTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_text" width="15%">
                                            ���޵����
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList9" runat="server" ItemRelation="Equal"
                                                 ItemName="HasDxgc">
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                        <td class="td_text" width="15%">
                                            ����ʩ��ͼ���
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList3" runat="server" ItemRelation="Equal"
                                                 ItemName="HasSgtsc" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_text" width="15%">
                                            ������Ͷ����Ϣ
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList1" runat="server" ItemRelation="Equal"
                                                 ItemName="HasZtbxx" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                        <td class="td_text" width="15%">
                                            ��ͬ��������
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="ddl_Heba" runat="server">
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="0">��ͬ����</asp:ListItem>
                                                <asp:ListItem Value="1">������ƺ�ͬ</asp:ListItem>
                                                <asp:ListItem Value="2">ʩ����ͬ����</asp:ListItem>
                                                <asp:ListItem Value="3">�����ͬ����</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_text" width="15%">
                                            ���ް�ȫ����
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList5" runat="server" ItemRelation="Equal"
                                                 ItemName="HasAqbj" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                        <td class="td_text" width="15%">
                                            ������������
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList6" runat="server" ItemRelation="Equal"
                                                 ItemName="HasZlbj" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_text" width="15%">
                                            ����ʩ�����
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList7" runat="server" ItemRelation="Equal"
                                                 ItemName="HasSgxk" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                        <td class="td_text" width="15%">
                                            ���޿�������
                                        </td>
                                        <td class="td_value" width="35%">
                                            <Bigdesk8:DBDropDownList ID="DBDropDownList8" runat="server" ItemRelation="Equal"
                                                 ItemName="HasJgba" >
                                                <asp:ListItem Value="">
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">��</asp:ListItem>
                                                <asp:ListItem Value="0">��</asp:ListItem>
                                            </Bigdesk8:DBDropDownList>
                                        </td>
                                    </tr>
                                </asp:PlaceHolder>
                                <tr>
                                    <td style="background-color: White" colspan="4">
                                        <table width="100%" cellpadding="2" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 5%; text-align: right">
                                                </td>
                                                <td style="width: 15%;">
                                                </td>
                                                <td style="width: 5%; text-align: right">
                                                </td>
                                                <td style="width: 35%">
                                                </td>
                                                <td style="text-align: right;">
                                                    <asp:LinkButton ID="linkButton" runat="server" Text="�򿪸߼�����" Font-Underline="true"
                                                        Font-Size="13px" OnClick="linkButton_Click"></asp:LinkButton>
                                                </td>
                                                <td style="width: 6%; text-align: right; padding-right: 5px;">
                                                    <asp:ImageButton ID="ImageButton" runat="server" ImageUrl="../Images/LinksButton/Search_Button3.png"
                                                        OnClick="ImageButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="view_head" style="width: 1580px;">
                <Bigdesk8:PowerDataGrid ID="Gdv_LxxmInfo" runat="server" OnPageIndexChanging="powerGridView_PageIndexChanging"
                    PageSize="20" DataKeyNames="PKID" Width="1580px" AutoGenerateColumns="false"
                    OnRowDataBound="powerGridView_RowDataBound" AllowPaging="true">
                    <columns>
                        <asp:TemplateField HeaderText="��ʡ״̬">
                            <ItemTemplate>

                                <asp:HyperLink ID="HyperLink_View" runat="server" Text='<%# Int32.Parse(Eval("OperateState").ToString())==0?"���ϱ�":(Int32.Parse(Eval("OperateState").ToString())==2?"����ʡһ�廯ƽ̨":"δ�ϱ�")%>' 
                                NavigateUrl='<%#string.Format("/WxjzgcjczyQybPage/Xxgx/JbZxjk_FailureList.aspx?pkid={0}",Eval("PKID")) %>'
                                    Target="_blank" />

                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="70px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="��Ŀ���" DataField="PrjNum">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="120px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        
                             <asp:BoundField HeaderText="�����������" DataField="PrjInnerNum">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="��Ŀ����">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink_View" runat="server" Text='<%#Eval("PrjName") %>' NavigateUrl='<%#string.Format("{0}?viewUrl=../PagesZHJG/Zhjg_Lxxmdj_Menu.aspx$LoginID={1}%PKID={2}%PrjNum={3}&titleName={4}",publicViewUrl,this.WorkUser.UserID,Eval("PKID"),Eval("PrjNum"),"��Ŀ��Ϣ-"+Eval("PrjName")) %>'
                                    Target="_blank" />
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="350px" HorizontalAlign="left" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" ForeColor="Yellow" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="��Ŀ����" DataField="PrjType">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="100px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>   
                        <asp:BoundField HeaderText="��Ŀ����" DataField="County">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="80px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                     <%--   <asp:BoundField HeaderText="���赥λ����" DataField="BuildCorpName">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="210px" HorizontalAlign="left" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="���赥λ����">
                            <ItemTemplate>
                     
                                <asp:HyperLink ID="HyperLink_View" runat="server" Text='<%#Eval("BuildCorpName") %>'
                                    NavigateUrl='<%#string.Format("/WxjzgcjczyPage/Szqy/JsdwxxToolBar.aspx?jsdwid={0}",Eval("jsdwID")) %>'
                                    Target="_blank" Enabled='<%# Eval("jsdwID")!=DBNull.Value %>'/>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="13%" HorizontalAlign="left" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" ForeColor="Yellow" />
                        </asp:TemplateField>
                        
                        
                   <%--     <asp:BoundField HeaderText="�����ĺ�" DataField="PrjApprovalNum">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="160px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>--%>
                        <asp:BoundField HeaderText="��������" DataField="BDate">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="70px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="��������" DataField="EDate">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="70px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="��������" DataField="CreateDate">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="70px" HorizontalAlign="Center" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="�������" DataField="DxgcCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ʩ��ͼ�����" DataField="SgtscCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="��Ͷ����">
                            <ItemTemplate>
                                <%#Eval("ZtbxxCount") %>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="��ͬ������" DataField="HtbaCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="��ȫ������" DataField="AqbjCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="����������" DataField="ZlbjCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ʩ�������" DataField="SgxkCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="����������" DataField="JgbaCount">
                            <ItemStyle BorderWidth="1px" BorderColor="#7B7B7B" Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle BorderWidth="1px" BorderColor="#7B7B7B" />
                        </asp:BoundField>
                    </columns>
                </Bigdesk8:PowerDataGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
