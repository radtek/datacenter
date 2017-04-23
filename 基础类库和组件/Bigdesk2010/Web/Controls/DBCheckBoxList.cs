﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bigdesk2010.Data;

namespace Bigdesk2010.Web.Controls
{
    /// <summary>
    /// 多项选择复选框组，多个值间以“;”分号分隔
    /// </summary>
    [ToolboxData("<{0}:DBCheckBoxList runat=server></{0}:DBCheckBoxList>")]
    public class DBCheckBoxList : CheckBoxList, IValueTextItem
    {
        #region ValueItem IDataItem 成员

        /// <summary>
        /// 中文名称
        /// </summary>
        [
        Description("数据项中文名称"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue("")
        ]
        public string ItemNameCN
        {
            get
            {
                if (this.ViewState["DataItem_NameCN"].IsEmpty()) return "";
                return this.ViewState["DataItem_NameCN"].TrimString();
            }
            set
            {
                this.ViewState["DataItem_NameCN"] = value;
            }
        }

        /// <summary>
        /// 是否为必填项
        /// </summary>
        [
        Description("是否为必填项"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(false)
        ]
        public bool ItemIsRequired
        {
            get
            {
                if (this.ViewState["DataItem_IsRequired"].IsEmpty()) return false;
                return this.ViewState["DataItem_IsRequired"].ToBoolean();
            }
            set
            {
                this.ViewState["DataItem_IsRequired"] = value;
            }
        }

        /// <summary>
        /// 错误信息，如果不为String.Empty,则有错误
        /// </summary>
        private string _ErrorMessage;
        /// <summary>
        /// 检查类型是否匹配，长度是否超长，必填项是否已填，取值范围是否正确等等.....
        /// </summary>
        /// <returns>检查成功返回true,不成功返回false</returns>
        public string ItemCheck()
        {
            string nameCN = this.ItemNameCN.IsEmpty() ? "控件ID：" + this.ID : this.ItemNameCN;
            string data = this.GetItemData();

            // 必填项检查
            if (this.ItemIsRequired && data.IsEmpty())
            {
                this.Focus();
                this._ErrorMessage = DataUtility.GetErrorMessage_DataRequired(nameCN);
                return this._ErrorMessage;
            }

            if (data.IsEmpty()) return "";

            //等等.....


            return string.Empty;
        }

        /// <summary>
        /// Value 数据项名称
        /// </summary>
        [
        Description("Value 数据项名称"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue("")
        ]
        public string ItemName
        {
            get
            {
                if (this.ViewState["DataItem_Name"].IsEmpty()) return "";

                return this.ViewState["DataItem_Name"].TrimString();
            }
            set
            {
                this.ViewState["DataItem_Name"] = value;
            }
        }

        /// <summary>
        /// Value 数据类型
        /// </summary>
        [
        Description("Value 数据类型"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(DataType.String)
        ]
        public DataType ItemType
        {
            get
            {
                if (this.ViewState["DataType_Type"].IsEmpty()) return DataType.String;

                return (DataType)this.ViewState["DataType_Type"];
            }
            set
            {
                this.ViewState["DataType_Type"] = value;
            }
        }

        /// <summary>
        /// Value 数据项与数据的关系
        /// </summary>
        [
        Description("数据项与数据的关系"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(DataRelation.Equal)
        ]
        public DataRelation ItemRelation
        {
            get
            {
                if (this.ViewState["DataItem_Relation"].IsEmpty()) return DataRelation.Equal;

                return (DataRelation)this.ViewState["DataItem_Relation"];
            }
            set
            {
                this.ViewState["DataItem_Relation"] = value;
            }
        }

        private string ItemData
        {
            get
            {
                return GetItemData();
            }
            set
            {
                base.ClearSelection();

                string[] ss = value.TrimString().SplitToString(SplitString, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in ss)
                {
                    ListItem li = base.Items.FindByValue(s);
                    if (li != null)
                    {
                        li.Selected = true;
                    }
                    else if (this.IsAutoAddItem && s != string.Empty)
                    {
                        base.Items.Add(new ListItem(s, s));
                        base.Items.FindByValue(s).Selected = true;
                    }
                }
            }
        }

        private string GetItemData()
        {
            List<string> list = new List<string>();
            foreach (ListItem li in base.Items)
            {
                if (li.Selected)
                    list.Add(li.Value);
            }
            return list.ToArray().ArrayToString(SplitString);
        }

        private string GetTextItemData()
        {
            List<string> list = new List<string>();
            foreach (ListItem li in base.Items)
            {
                if (li.Selected)
                    list.Add(li.Text);
            }
            return list.ToArray().ArrayToString(SplitString);
        }

        #endregion

        #region TextItem IDataItem 成员

        /// <summary>
        /// Text 数据项名称
        /// </summary>
        [
        Description("Text 数据项名称"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue("")
        ]
        public string TextItemName
        {
            get
            {
                if (this.ViewState["TextDataItem_Name"].IsEmpty()) return "";

                return this.ViewState["TextDataItem_Name"].TrimString();
            }
            set
            {
                this.ViewState["TextDataItem_Name"] = value;
            }
        }

        /// <summary>
        /// Text 数据类型
        /// </summary>
        [
        Description("Text 数据类型"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(DataType.String)
        ]
        public DataType TextItemType
        {
            get
            {
                if (this.ViewState["TextDataType_Type"].IsEmpty()) return DataType.String;

                return (DataType)this.ViewState["TextDataType_Type"];
            }
            set
            {
                this.ViewState["TextDataType_Type"] = value;
            }
        }

        /// <summary>
        /// Text 数据项与数据的关系
        /// </summary>
        [
        Description("Text 数据项与数据的关系"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(DataRelation.Equal)
        ]
        public DataRelation TextItemRelation
        {
            get
            {
                if (this.ViewState["TextDataItem_Relation"].IsEmpty()) return DataRelation.Equal;

                return (DataRelation)this.ViewState["TextDataItem_Relation"];
            }
            set
            {
                this.ViewState["TextDataItem_Relation"] = value;
            }
        }

        #endregion

        #region IValueTextItem 成员

        IDataItem IValueTextItem.ValueItem
        {
            get
            {
                //if (this.ItemName.IsEmpty())
                //    return null;

                DataItem di = new DataItem();
                di.ItemName = this.ItemName;
                di.ItemType = this.ItemType;
                di.ItemData = this.ItemData;
                di.ItemNameCN = this.ItemNameCN;
                di.ItemIsRequired = this.ItemIsRequired;
                di.ItemRelation = this.ItemRelation;

                di.ItemFormat = "";
                di.ItemLength = 0;
                di.ItemDefaultData = "";
                di.Checked += this.ItemCheck;
                di.ItemDataChanged += this.DataItem_ItemDataChanged;
                return di;
            }
            set
            {
                if (value == null)
                    this.ItemData = "";
                else
                    this.ItemData = value.ItemData;
            }
        }

        private void DataItem_ItemDataChanged(string newData)
        {
            this.ItemData = newData;
        }

        IDataItem IValueTextItem.TextItem
        {
            get
            {
                //if (this.TextItemName.IsEmpty())
                //    return null;

                DataItem di = new DataItem();
                di.ItemName = this.TextItemName;
                di.ItemType = this.TextItemType;
                di.ItemData = this.GetTextItemData();
                di.ItemNameCN = this.ItemNameCN;
                //di.ItemIsRequired = this.ItemIsRequired;
                //di.ItemRelation = this.TextItemRelation;

                di.ItemFormat = "";
                di.ItemLength = 0;
                di.ItemDefaultData = "";
                //di.Checked += this.ItemCheck;
                //di.ItemDataChanged += this.DataItem_ItemDataChanged;
                return di;
            }
            set
            {
                //
            }
        }

        #endregion


        /// <summary>
        /// 内容分隔符
        /// </summary>
        [
        Description("内容分隔符"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(";")
        ]
        public string SplitString
        {
            get
            {
                if (this.ViewState["_SplitString"].IsEmpty()) return ";";
                return this.ViewState["_SplitString"].TrimString();
            }
            set
            {
                this.ViewState["_SplitString"] = value;
            }
        }


        #region 重写属性

        /// <summary>
        /// 获取列表控件中选定项的值，或选择列表控件中包含指定值的项。
        /// 返回结果:
        ///     列表控件中选定项的值。默认值为空字符串 ("")。
        /// </summary>
        [Category("扩展属性")]
        [Description("获取列表控件中选定项的值")]
        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue("")]
        public override string SelectedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                this.ItemData = value;
            }
        }

        #endregion 重写属性

        #region 重写受保护的方法

        /// <summary>
        /// 将需要呈现的 HTML 属性和样式添加到指定的 <see cref="HtmlTextWriter"/> 实例中。
        /// </summary>
        /// <param name="writer"><see cref="HtmlTextWriter"/>，表示要在客户端呈现 HTML 内容的输出流。</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (!this._ErrorMessage.IsEmpty())
            {
                writer.AddAttribute("myerror", "true");
            }

            base.AddAttributesToRender(writer);
        }

        #endregion 重写受保护的方法

        #region 其它

        /// <summary>
        /// 当列表中可选项不存在时，是否自动添加
        /// </summary>
        [
        Description("当列表中可选项不存在时，是否自动添加"),
        Category("扩展属性"),
        Bindable(true),
        DefaultValue(true)
        ]
        public virtual bool IsAutoAddItem
        {
            get
            {
                if (this.ViewState["IsAutoAddItem"].IsEmpty()) return true;

                return this.ViewState["IsAutoAddItem"].ToBoolean();
            }
            set
            {
                this.ViewState["IsAutoAddItem"] = value;
            }
        }

        #endregion 其它
    }
}
