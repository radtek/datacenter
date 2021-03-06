﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Bigdesk8.Web;
using Bigdesk8;
using Bigdesk8.Data;
using Bigdesk8.Web.Controls;


using System.Collections.Generic;

namespace IntegrativeShow2
{
    //文 件  名:HandleSQLZHJG.cs
    //文件说明:处理综合监管模块所需要数据的SQL
    //创 建  人:李贯涛
    //创建日期:2015-4-2

    #region GridView数据绑定
    /// <summary>
    /// 立项项目GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_LxxmInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();

        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有立项登记项目
            dh.strSQL = @"
select * from (
SELECT 
a.PKID,
a.PrjNum,a.PrjInnerNum,
a.PrjName,
a.PrjPropertyNum,
a.PrjApprovalNum,
a.BuildCorpName,
convert(varchar(10),a.BDate,20) as BDate,
convert(varchar(10),a.EDate,20) as EDate,convert(varchar(10),a.CreateDate,20) as CreateDate,a.PrjTypeNum,c.jsdwID,
(select codeinfo from tbPrjTypeDic where code=a.PrjTypeNum) as PrjType, (case b.OperateState when 0 then 0 when 2 then 2 else 1 end) as OperateState,b.Msg,
(case when (select count(*) from TBTenderInfo where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasZtbxx,
( case when ( select count(*) from TBContractRecordManage where PrjNum=a.PrjNum )=0 then 0 else 1 end) as HasHtba,
(case when (select count(*) from TBProjectCensorInfo where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasSgtsc,
(case when (select count(*) from TBBuilderLicenceManage where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasSgxk,
(case when (select count(*) from TBProjectFinishManage where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasJgba,
(case when (select count(*) from aj_gcjbxx where xmbm=a.PrjNum)=0 then 0 else 1 end) as HasAqbj,
(case when (select count(*) from zj_gcjbxx where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasZlbj,
(case when (select count(*) from xm_gcdjb_dtxm where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasDxgc,
(select count(*) from TBTenderInfo where PrjNum=a.PrjNum) as ZtbxxCount,
(select count(*) from TBContractRecordManage where PrjNum=a.PrjNum ) as HtbaCount,
(select count(*) from TBContractRecordManage where PrjNum=a.PrjNum and ContractTypeNum in ('301','302','303','500','600','700')) as SgHtbaCount,
(select count(*) from TBContractRecordManage where PrjNum=a.PrjNum and ContractTypeNum in('400')) as JlHtbaCount,
(select count(*) from TBContractRecordManage where PrjNum=a.PrjNum and ContractTypeNum in('100','200')) as KcsjHbaCount,
(select count(*) from TBProjectCensorInfo where PrjNum=a.PrjNum) as SgtscCount,
(select count(*) from TBBuilderLicenceManage where PrjNum=a.PrjNum) as SgxkCount,
(select count(*) from TBProjectFinishManage where PrjNum=a.PrjNum) as JgbaCount,
(select count(*) from aj_gcjbxx where xmbm=a.PrjNum) as AqbjCount,
(select count(*) from zj_gcjbxx where PrjNum=a.PrjNum) as ZlbjCount,
(select count(*) from Ap_ajsbb where PrjNum=a.PrjNum) as AqbjNewCount,
(select count(*) from Ap_zjsbb where PrjNum=a.PrjNum) as ZlbjNewCount,
(select count(*) from xm_gcdjb_dtxm where PrjNum=a.PrjNum) as DxgcCount
FROM TBProjectInfo a left join SaveToStLog b on b.TableName='TBProjectinfo' and a.PKID=b.PKID 
left join UEPP_Jsdw c on a.BuildCorpCode=c.zzjgdm 
where a.UpdateFlag='U' ) as aaa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            ////QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);

            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }

            dh.orderBy = " CreateDate desc ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            //这段SQL用于取出所有立项登记项目
            dh.strSQL = @"
select * from (
SELECT 
a.PKID,a.PrjNum,a.PrjInnerNum,a.PrjName,
a.PrjPropertyNum,
a.PrjApprovalNum,a.PrjApprovalLevelNum,(select top 1 codeinfo from tbLxjbDic where code=a.PrjApprovalLevelNum) as PrjApprovalLevel,
a.BuildCorpName,
convert(varchar(10),a.BDate,20) as BDate,
convert(varchar(10),a.EDate,20) as EDate,convert(varchar(19),a.CreateDate,20) as CreateDate,a.PrjTypeNum,a.ProvinceNum,a.CityNum,a.CountyNum,c.jsdwID,
(select CodeInfo from tbXzqdmDic where parentCode='320200' and Code=a.CountyNum) as County,
(select codeinfo from tbPrjTypeDic where code=a.PrjTypeNum) as PrjType, (case b.OperateState when 0 then 0 when 2 then 2 else 1 end) as OperateState,b.Msg,
(case when (select count(*) from TBTenderInfo where UpdateFlag='U'and PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasZtbxx,
(case when ( select count(*) from TBContractRecordManage where UpdateFlag='U'and PrjNum=a.PrjNum )=0 then 0 else 1 end) as HasHtba,
(case when (select count(*) from TBProjectCensorInfo where UpdateFlag='U'and PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasSgtsc,
(case when (select count(*) from TBBuilderLicenceManage where UpdateFlag='U'and PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasSgxk,
(case when (select count(*) from TBProjectFinishManage where UpdateFlag='U'and PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasJgba,
(case when (select count(*) from aj_gcjbxx where xmbm=a.PrjNum)=0 then 0 else 1 end) as HasAqbj,
(case when (select count(*) from zj_gcjbxx where prjNum=a.PrjNum)=0 then 0 else 1 end) as HasZlbj,
(case when (select count(*) from xm_gcdjb_dtxm where PrjNum=a.PrjNum)=0 then 0 else 1 end) as HasDxgc,
(select count(*) from TBTenderInfo where PrjNum=a.PrjNum) as ZtbxxCount,
(select count(*) from TBContractRecordManage where UpdateFlag='U'and PrjNum=a.PrjNum ) as HtbaCount,
(select count(*) from TBContractRecordManage where UpdateFlag='U'and PrjNum=a.PrjNum and ContractTypeNum in ('301','302','303','500','600','700')) as SgHtbaCount,
(select count(*) from TBContractRecordManage where UpdateFlag='U'and PrjNum=a.PrjNum and ContractTypeNum in('400')) as JlHtbaCount,
(select count(*) from TBContractRecordManage where UpdateFlag='U'and PrjNum=a.PrjNum and ContractTypeNum in('100','200')) as KcsjHbaCount,
(select count(*) from TBProjectCensorInfo where UpdateFlag='U'and PrjNum=a.PrjNum) as SgtscCount,
(select count(*) from TBBuilderLicenceManage where UpdateFlag='U'and PrjNum=a.PrjNum) as SgxkCount,
(select count(*) from TBProjectFinishManage where UpdateFlag='U'and PrjNum=a.PrjNum) as JgbaCount,
(select count(*) from aj_gcjbxx where xmbm=a.PrjNum) as AqbjCount,
(select count(*) from zj_gcjbxx where PrjNum=a.PrjNum) as ZlbjCount,
(select count(*) from Ap_ajsbb where PrjNum=a.PrjNum) as AqbjNewCount,
(select count(*) from Ap_zjsbb where PrjNum=a.PrjNum) as ZlbjNewCount,
(select count(*) from xm_gcdjb_dtxm where PrjNum=a.PrjNum) as DxgcCount
FROM TBProjectInfo a left join SaveToStLog b on b.TableName='TBProjectinfo' and a.PKID=b.PKID 
left join UEPP_Jsdw c on a.BuildCorpCode=c.zzjgdm 
where a.UpdateFlag='U') as aaa where 1=1   ";
            //where a.UpdateFlag='U'
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);

            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }

            if (strParas != null && strParas.Length > 0)
            {
                switch (strParas[0])
                {
                    case "0":
                        dh.strSQL += " and HasHtba=1 ";
                        break;

                    case "1":
                        dh.strSQL += " and KcsjHbaCount>0 ";
                        break;
                    case "2":
                        dh.strSQL += " and SgHtbaCount>0 ";
                        break;
                    case "3":
                        dh.strSQL += " and JlHtbaCount>0 ";
                        break;

                }
                if (strParas.Length > 1 && !string.IsNullOrEmpty(strParas[1]))
                {
                    dh.strSQL += " and CountyNum in (" + strParas[1] + ")";

                }
            }

            dh.orderBy = " CreateDate desc ";
        }
        #endregion
    }

    /// <summary>
    /// 立项项目信息-单项项目信息GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_LxxmDxgcInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有单项项目
            dh.strSQL = @"
SELECT
a.PKID,	/*业务编码 guid值*/ 
a.PrjNum,	/*项目编号 按住建部编码规则统一编号*/
a.fxbm,	/* 单项编码 项目编码+流水号*/
a.fxnbbm,	/* 单项内部编号 原业务系统的内部编号*/
a.xmmc,	/*单项名称*/
b1.CodeInfo as gclb,		/*单项项目分类 见代码表*/
a.gczj,		/*单项投资（万元）*/
a.jzmj,		/*单项建筑面积（平方米）*/
a.jsgm,		/*建设规模*/
b2.CodeInfo as jglx,	/*结构类型  见代码表*/
b3.CodeInfo as jsyt,	/* 工程用途  见代码表*/
a.dscs,		/*地上层数*/
a.dxcs,		/*地下层数*/
a.gd,		/*高度(米)*/
a.kd	,		/*跨度(米)*/
a.jhkgrq,		/*计划开工日期*/
a.jhjgrq		/*计划竣工日期*/

FROM xm_gcdjb_dtxm as a
LEFT JOIN tbPrjTypeDic AS b1 ON a.gclb = b1.Code 
LEFT JOIN tbPrjStructureTypeDic AS b2 ON a.jglx = b2.Code 
LEFT JOIN tbPrjFunctionDic AS b3 ON a.jsyt = b3.Code 
LEFT JOIN TBProjectInfo AS c ON a.PrjNum = c.PrjNum
WHERE c.PKID = @PKID and a.UpdateFlag='U'
";
            dh.strSQL += " order by jhjgrq desc";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 施工图审查GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_SgtscInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有施工图审查
            dh.strSQL = @"
                        SELECT * FROM(
                        select 
                        a.PKID,
                        a.CensorNum,a.CensorName,
                        a.PrjNum,
                        a.EconCorpName,
                        a.CensorCorpName,
                        convert(char(10),a.CensorEDate,20) as CensorEDate,a.DesignCorpName,
                        b.PrjName,b.PKID as LxPKID,left(a.EconCorpCode,8) + '-' + right(a.EconCorpCode,1) as kcqyID,left(a.DesignCorpCode,8) + '-' + right(a.DesignCorpCode,1) as sjqyID
                        from TBProjectCensorInfo as a
                        left join TBProjectInfo as b on a.PrjNum = b.PrjNum 
                        where a.UpdateFlag='U'
                        ) AS TEMP WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            // cl.GenerateSearchClauseAndSPC(ref strSqlCondition, dh.spc);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            // dh.strSQL += " order by CensorEDate desc";
            dh.orderBy = " CensorEDate desc ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有施工图审查
            dh.strSQL = @"
            SELECT * FROM(
              select 
                a.PKID,
                a.CensorNum,  a.CensorName,
                a.PrjNum,
                a.EconCorpName,
                a.CensorCorpName,
                convert(char(10),a.CensorEDate,20) as CensorEDate,a.DesignCorpName,
                b.PrjName,b.PKID as LxPKID,left(a.EconCorpCode,8) + '-' + right(a.EconCorpCode,1) as kcqyID,left(a.DesignCorpCode,8) + '-' + right(a.DesignCorpCode,1) as sjqyID
                from TBProjectCensorInfo as a
                left join TBProjectInfo as b on a.PrjNum = b.PrjNum 
                where a.UpdateFlag='U'
            ) AS TEMP WHERE PrjNum=@PrjNum ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            // dh.strSQL += " order by CensorEDate desc";   
            dh.orderBy = " CensorEDate desc ";
        }

        #endregion
    }

    /// <summary>
    /// 施工图审查人员信息
    /// </summary>
    public class Instance_Gdv_SgtscRyInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有施工图审查项目
            dh.strSQL = @"
SELECT
a.PKID,/*业务编码 guid值*/ 
a.CensorNum,	/*施工图审查合格书编号*/
a.PrjNum	,	/*项目编号*/
a.CorpName,	/* 所属单位名称 勘察单位、设计单位、施工图审查机构*/
a.CorpCode,	/*所属单位组织机构代码*/
a.UserName,	/*人员姓名*/
a.IDCardTypeNum,	/*证件类型  见代码表*/
b1.CodeInfo as IDCardType,
a.IDCard,	/*证件号码 身份证号须为18位*/
a.SpecialtyTypNum,	/*注册类型及等级*/
b2.CodeInfo as SpecialtyTyp,
a.UserPhone,		/*人员电话*/
b3.CodeInfo as PrjDuty	/*承担角色*/

FROM TBProjectDesignEconUserInfo as a
LEFT JOIN tbIDCardTypeDic AS b1 ON a.IDCardTypeNum = b1.Code 
LEFT JOIN tbSpecialtyTypeDic AS b2 ON a.SpecialtyTypNum = b2.Code 
LEFT JOIN tbWorkDutyDic AS b3 ON a.PrjDuty = b3.Code 
LEFT JOIN TBProjectCensorInfo AS c ON a.CensorNum = c.CensorNum
WHERE a.CensorNum = @CensorNum and a.UpdateFlag='U' and c.UpdateFlag='U'
";
            // dh.strSQL += " order by c.PKID desc";
            dh.spc.Add("@CensorNum", strParas[0]);

            dh.orderBy = " PKID desc ";
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 安全报监GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_AqbjInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有安全报监项目
            dh.strSQL = @"
                        select * from (
		                   SELECT 
                            a.pKID,
                            a.aqjdbm,
                            a.gcmc,
                            a.Aqjdjgmc,a.zbdwDwmc,
                            a.jldwDwmc,
                            convert(char(10),a.bjrq,20) as  bjrq,
                            convert(char(10),a.gcgkKgrq,20) as  gcgkKgrq,
                            a.xmbm,b.PrjName,b.PKID as LxPKID ,c.qyID ,b.CountyNum
	,(select count(*) from SaveToStLog where TableName='aj_gcjbxx' and  PKID=a.pKID and OperateState=0) OperateState
                            FROM aj_gcjbxx a  
                            left join TBProjectInfo b on a.xmbm=b.PrjNum 
							left join Uepp_Qyjbxx c on c.zzjgdm=a.zbdwDwdm where a.UpdateFlag='U'
                          ) as aaa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  bjrq desc ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有安全报监项目1
            dh.strSQL = @"select *  from (
                            SELECT 
                            a.pKID,
                            a.aqjdbm,
                            a.gcmc,
                            a.Aqjdjgmc,a.zbdwDwmc,
                            a.jldwDwmc,
                            convert(char(10),a.bjrq,20) as  bjrq,
                            convert(char(10),a.gcgkKgrq,20) as  gcgkKgrq,
                            a.xmbm,b.PrjName,b.PKID as LxPKID ,c.qyID ,b.CountyNum
,(select count(*) from SaveToStLog where TableName='aj_gcjbxx' and  PKID=a.pKID and OperateState=0) OperateState
                            FROM aj_gcjbxx a  
                            left join TBProjectInfo b on a.xmbm=b.PrjNum 
							left join Uepp_Qyjbxx c on c.zzjgdm=a.zbdwDwdm WHERE a.xmbm=@PrjNum
                        ) as aaa where 1=1  ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            ////QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);

            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            //dh.strSQL += " order by bjrq desc";

            dh.orderBy = "  bjrq desc ";
        }

        #endregion
    }

    /// <summary>
    /// 合同备案GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_HtbaInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有合同备案项目
            dh.strSQL = @"SELECT * from (
                             SELECT  a.PKID,a.RecordNum,a.RecordInnerNum,
                    a.ContractNum,
                    a.RecordName,
                    a.PropietorCorpName,
                    a.ContractorCorpName,
                    convert(char(10),a.ContractDate,20) as ContractDate,a.ContractTypeNum,
                    (select CodeInfo from tbContractTypeDic where Code= a.ContractTypeNum) as ContractType,
                    a.PrjNum,
                    b.PrjName,b.PKID as LxPKID,c.jsdwID,d.qyID,b.CountyNum
                    FROM TBContractRecordManage a 
                    left join TBProjectInfo b on a.PrjNum=b.PrjNum 
					left join UEPP_Jsdw c on a.PropietorCorpCode=c.zzjgdm 
					left join UEPP_Qyjbxx d  on a.ContractorCorpCode=d.zzjgdm 
					where a.UpdateFlag='U'
                          ) as aaa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " ContractDate desc";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            if (strParas.Length == 2)
            {
                dh.spc.Add("@PrjNum", strParas[0]);
                //这段SQL用于取出所有合同备案项目
                dh.strSQL = @"
                         select * from (
                        SELECT 
                            a.PKID,a.RecordNum,a.RecordInnerNum,
                            a.ContractNum,
                            a.RecordName,
                            a.PropietorCorpName,
                            a.ContractorCorpName,
                            convert(char(10),a.ContractDate,20) as ContractDate,a.ContractTypeNum,
                            (select CodeInfo from tbContractTypeDic where Code=a.ContractTypeNum) as ContractType,
                            a.PrjNum,
                            b.PrjName,b.PKID as LxPKID,c.jsdwID,d.qyID,b.CountyNum
                            FROM TBContractRecordManage a
                            left join TBProjectInfo b on a.PrjNum=b.PrjNum 
                            left join UEPP_Jsdw c on a.PropietorCorpCode=c.zzjgdm 
					        left join UEPP_Qyjbxx d  on a.ContractorCorpCode=d.zzjgdm 
                            WHERE a.PrjNum=@PrjNum and a.UpdateFlag='U') as aaa where 1=1  ";

                if (!string.IsNullOrEmpty(strParas[1]))
                {
                    dh.strSQL += " and ContractTypeNum in (" + strParas[1] + ") ";
                }
            }
            else
            {
                //这段SQL用于取出所有合同备案项目
                dh.strSQL = @"SELECT * from (
                             SELECT  a.PKID,a.RecordNum,a.RecordInnerNum,
                    a.ContractNum,
                    a.RecordName,
                    a.PropietorCorpName,
                    a.ContractorCorpName,
                    convert(char(10),a.ContractDate,20) as ContractDate,a.ContractTypeNum,
                    (select CodeInfo from tbContractTypeDic where Code= a.ContractTypeNum) as ContractType,
                    a.PrjNum,
                    b.PrjName,b.PKID as LxPKID,c.jsdwID,d.qyID,b.CountyNum
                    FROM TBContractRecordManage a 
                    left join TBProjectInfo b on a.PrjNum=b.PrjNum 
					left join UEPP_Jsdw c on a.PropietorCorpCode=c.zzjgdm 
					left join UEPP_Qyjbxx d  on a.ContractorCorpCode=d.zzjgdm 
					where a.UpdateFlag='U'
                          ) as aaa WHERE 1=1 ";

                if (!string.IsNullOrEmpty(strParas[0]))
                {
                    dh.strSQL += " and ContractTypeNum in (" + strParas[0] + ") ";
                }

            }

            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " ContractDate desc";
        }

        #endregion
    }

    /// <summary>
    /// 竣工备案GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_JgbaInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有竣工备案项目
            dh.strSQL = @"select * from (
SELECT 
a.PKID,
a.PrjFinishNum,
a.PrjFinishName,
a.QCCorpName,
convert(char(10),a.BDate,20) as BDate,
convert(char(10),a.EDate,20) as EDate,
a.PrjStructureTypeNum,a.BuilderLicenceNum,a.FactCost,a.FactSize,FactArea,
(select CodeInfo from tbPrjStructureTypeDic where Code=a.PrjStructureTypeNum ) as PrjStructureType,
a.PrjNum,b.PrjName,b.PKID as LxPKID
FROM TBProjectFinishManage a  
left join TBProjectInfo b on a.PrjNum=b.PrjNum  where a.UpdateFlag='U'
) as aaa WHERE 1=1
";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  EDate desc";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有竣工备案项目
            dh.strSQL = @"select * from (
SELECT 
a.PKID,
a.PrjFinishNum,
a.PrjFinishName,
a.QCCorpName,
convert(char(10),a.BDate,20) as BDate,
convert(char(10),a.EDate,20) as EDate,
a.PrjStructureTypeNum,a.BuilderLicenceNum,a.FactCost,a.FactSize,FactArea,
(select CodeInfo from tbPrjStructureTypeDic where Code=a.PrjStructureTypeNum ) as PrjStructureType,
a.PrjNum,b.PrjName,b.PKID as LxPKID 
FROM TBProjectFinishManage a
left join TBProjectInfo b on a.PrjNum=b.PrjNum where a.PrjNum=@PrjNum and a.UpdateFlag='U'
) as aaa WHERE 1=1
";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  EDate desc";
        }

        #endregion
    }

    /// <summary>
    /// 施工许可证GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_SgxkzInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有安全报监项目
            dh.strSQL = @"
                         select * from (
                         SELECT 
                        a.PKID,
                        a.BuilderLicenceName,
                        a.BuilderLicenceNum,a.CensorNum,
                        convert(char(10),a.IssueCertDate,20) as IssueCertDate,
                        a.EconCorpName,a.DesignCorpName,a.ConsCorpName,a.SuperCorpName,
                        a.PrjNum, b.PrjName,b.PKID as LxPKID,c.qyID as kcqyID,d.qyID as sjqyID,e.qyID as sgqyID,b.CountyNum,
                        b.BuildCorpName,b.BuildCorpCode
                        FROM TBBuilderLicenceManage a 
                        left join TBProjectInfo b on a.PrjNum=b.PrjNum 
						left join UEPP_Qyjbxx c on c.zzjgdm=a.EconCorpCode  
						left join UEPP_Qyjbxx d on d.zzjgdm=a.DesignCorpCode  
						left join UEPP_Qyjbxx e on e.zzjgdm=a.ConsCorpCode 
                        where a.UpdateFlag='U'
                        ) as aa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " IssueCertDate desc ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有安全报监项目
            dh.strSQL = @"
                        select * from (
                           SELECT 
                        a.PKID,
                        a.BuilderLicenceName,
                        a.BuilderLicenceNum,a.CensorNum,
                        convert(char(10),a.IssueCertDate,20) as IssueCertDate,
                        a.EconCorpName,a.DesignCorpName,a.ConsCorpName,a.SuperCorpName,
                        a.PrjNum, b.PrjName,b.PKID as LxPKID,c.qyID as kcqyID,d.qyID as sjqyID,e.qyID as sgqyID,b.CountyNum,
                        b.BuildCorpName,b.BuildCorpCode
                        FROM TBBuilderLicenceManage a 
                        left join TBProjectInfo b on a.PrjNum=b.PrjNum 
						left join UEPP_Qyjbxx c on c.zzjgdm=a.EconCorpCode  
						left join UEPP_Qyjbxx d on d.zzjgdm=a.DesignCorpCode  
						left join UEPP_Qyjbxx e on e.zzjgdm=a.ConsCorpCode WHERE a.PrjNum=@PrjNum and a.UpdateFlag='U'
                        ) as aa WHERE 1=1   
";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " IssueCertDate desc ";
        }

        #endregion
    }

    /// <summary>
    /// 施工许可人员信息（施工安全从业人员）
    /// </summary>
    public class Instance_Gdv_SgxkCyryInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有施工许可证项目  
            //            dh.strSQL = @"
            //SELECT
            //a.PKID,	/*业务编码 guid值*/ 
            //a.PrjNum,	/*项目编号*/
            //a.BuilderLicenceNum,	/*施工许可证编号 按住建部编码规则统一编号*/
            //a.CorpName,	/*所属单位名称*/
            //a.CorpCode,		/*所属单位组织机构代码*/
            //a.SafetyCerID,		/*安全生产许可证编号*/
            //a.UserName,	/*人员姓名*/
            //a.IDCardTypeNum,	/*证件类型  见代码表*/
            //b.CodeInfo as IDCardType,
            //a.IDCard,	/*人员证件号码*/
            //a.UserPhone,		/*人员电话*/
            //a.CertID,	/*安全生产考核合格证书编号*/
            //(CASE UserType WHEN 1 THEN '主要负责人' WHEN 2 THEN '主要负责人' WHEN '3' THEN '安全员' END ) as UserType
            //
            //FROM TBProjectBuilderUserInfo as a
            //LEFT JOIN tbIDCardTypeDic AS b ON a.IDCardTypeNum = b.Code 
            //LEFT JOIN TBBuilderLicenceManage AS c ON a.PrjNum = c.PrjNum
            //WHERE c.PKID = @PKID
            //";
            dh.strSQL = @"
SELECT
a.PKID,	/*业务编码 guid值*/ 
a.PrjNum,	/*项目编号*/
a.BuilderLicenceNum,	/*施工许可证编号 按住建部编码规则统一编号*/
a.CorpName,	/*所属单位名称*/
a.CorpCode,		/*所属单位组织机构代码*/
a.SafetyCerID,		/*安全生产许可证编号*/
a.UserName,	/*人员姓名*/
a.IDCardTypeNum,	/*证件类型  见代码表*/
b.CodeInfo as IDCardType,
a.IDCard,	/*人员证件号码*/
a.UserPhone,		/*人员电话*/
a.CertID,	/*安全生产考核合格证书编号*/
(CASE UserType WHEN 1 THEN '主要负责人' WHEN 2 THEN '主要负责人' WHEN '3' THEN '安全员' END ) as UserType

FROM TBProjectBuilderUserInfo as a
LEFT JOIN tbIDCardTypeDic AS b ON a.IDCardTypeNum = b.Code 
LEFT JOIN TBBuilderLicenceManage AS c ON a.BuilderLicenceNum = c.BuilderLicenceNum
WHERE a.aqjdbm = @aqjdbm and a.UpdateFlag='U'
";
            dh.orderBy += " PKID desc";
            dh.spc.Add("@aqjdbm", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 招标投标GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_ZbtbInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有招标投标项目
            dh.strSQL = @"
                        SELECT * FROM (
                        select  distinct
                        a.PKID,
                        a.TenderName,
                        a.TenderNum,
                        a.TenderClassNum,
                        a.TenderTypeNum,
                        a.AgencyCorpName,a.TenderCorpName,
                        convert(char(10),a.TenderResultDate,20) as TenderResultDate,
                        b1.CodeInfo as TenderClass,
                        b2.CodeInfo as TenderType,
                        c.PrjName,
                        c.PrjNum,c.PKID as LxPKID,d.qyID,c.CountyNum
,(select count(*) from SaveToStLog where TableName='TBTenderInfo' and  PKID=a.pKID and OperateState=0) OperateState
                        from TBTenderInfo as a
                        left join tbTenderClassDic as b1 on a.TenderClassNum = b1.Code 
                        left join tbTenderTypeDic as b2 on a.TenderTypeNum = b2.Code 
                        left join TBProjectInfo c on a.PrjNum=c.PrjNum 
                        left join UEPP_Qyjbxx  d on a.TenderCorpCode=d.zzjgdm and a.TenderClassNum in ('001,002','003','006')
                        where  a.UpdateFlag='U'
                        ) AS TEMP WHERE 1=1
                        ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            //dh.strSQL += " order by TenderResultDate desc ";
            dh.orderBy += " TenderResultDate desc ";

        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有招标投标项目
            dh.strSQL = @"
                        SELECT * FROM (
                        select  distinct
                        a.PrjNum,
                        a.PKID,
                        a.TenderName,
                        a.TenderNum,
                        a.TenderClassNum,
                        a.TenderTypeNum,
                        a.AgencyCorpName,a.TenderCorpName,
                        convert(char(10),a.TenderResultDate,20) as TenderResultDate,
                        b1.CodeInfo as TenderClass,
                        b2.CodeInfo as TenderType,
                        c.PrjName,c.PKID as LxPKID,d.qyID,c.CountyNum
,(select count(*) from SaveToStLog where TableName='TBTenderInfo' and  PKID=a.pKID and OperateState=0) OperateState
                        from TBTenderInfo as a
                        left join tbTenderClassDic as b1 on a.TenderClassNum = b1.Code 
                        left join tbTenderTypeDic as b2 on a.TenderTypeNum = b2.Code
                        left join TBProjectInfo c on a.PrjNum=c.PrjNum 
                        left join UEPP_Qyjbxx  d on a.TenderCorpCode=d.zzjgdm and a.TenderClassNum in ('001,002','003','006')
                        WHERE a.PrjNum=@PrjNum and  a.UpdateFlag='U'
                        ) AS TEMP where 1=1  ";

            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " TenderResultDate desc ";
        }

        #endregion
    }

    /// <summary>
    /// 质量报监GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_ZlbjInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有质量报监项目
            dh.strSQL = @"
                        select * from (
                        SELECT 
                        a.PKID,
                        a.gcmc,
                        a.zljdbm,
                        a.zljdjgmc,a.zjzbm,a.sgzbbm,a.jglx,
                        a.gczj,
                        convert(char(10),a.sbrq,20) as sbrq,
                        (select CodeInfo from tbPrjStructureTypeDic where Code=a.jglx) as StructureType,
                        b.PrjName,a.PrjNum,b.PKID as LxPKID,b.CountyNum
,(select count(*) from SaveToStLog where TableName='zj_gcjbxx' and  PKID=a.pKID and OperateState=0) OperateState
                        FROM zj_gcjbxx a 
                        left join TBProjectInfo b on a.PrjNum=b.PrjNum where  a.UpdateFlag='U'  ) as aaa  WHERE 1=1 ";

            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = " sbrq desc ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有质量报监项目

            dh.strSQL = @" select * from (
                        SELECT 
                        a.PKID,
                        a.gcmc,
                        a.zljdbm,
                        a.zljdjgmc,a.zjzbm,a.sgzbbm,a.jglx,
                        a.gczj,
                        convert(char(10),a.sbrq,20) as sbrq,
                        (select CodeInfo from tbPrjStructureTypeDic where Code=a.jglx) as StructureType,
                        b.PrjName,a.PrjNum,b.PKID as LxPKID,b.CountyNum
,(select count(*) from SaveToStLog where TableName='zj_gcjbxx' and  PKID=a.pKID and OperateState=0) OperateState
                        FROM zj_gcjbxx a 
                        left join TBProjectInfo b on a.PrjNum=b.PrjNum  WHERE a.PrjNum=@PrjNum and  a.UpdateFlag='U' ) as aaa  WHERE 1=1 ";

            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            //QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  sbrq desc ";
        }

        #endregion
    }

    /// <summary>
    /// 质量报监责任人员GridViewSQL处理方法
    /// </summary>
    public class Instance_Gdv_ZlbjZrryInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有质量报监责任人员
            //            dh.strSQL = @"select * from (
            //SELECT
            //a.PKID,	/*业务编码 guid值*/ 
            //a.zljdbm,	/*市级平台监督注册号*/
            //a.dwlx,	/*单位类型 分为建设单位、勘察单位、设计单位、施工单位、监理单位、质量检测机构、混凝土供应商*/
            //a.Xh,	/*顺序号 每个监督注册号从1开始排序*/
            //a.Dwmc,	/*单位名称*/
            //a.dwdm,	/*单位组织机构代码*/
            //a.xmfzrxm,	/*项目负责人*/
            //a.xmfzrdm,	/*项目负责人身份证号*/
            //a.xmfzr_lxdh,		/*项目负责人电话*/
            //a.jsfzr,		/*项目技术负责人*/
            //a.jsfzr_lxdh,		/*项目技术负责人电话*/
            //a.Zly,		/*质量员*/
            //a.zly_lxdh,		/*质量员电话*/
            //a.qyy,	/*取样员*/
            //a.qyy_lxdh,	/*取样员电话*/
            //c.PrjNum,b.PrjName,b.PKID as LxPKID
            //FROM zj_gcjbxx_zrdw as a
            //LEFT JOIN zj_gcjbxx AS c ON a.zljdbm = c.zljdbm
            //left join TBProjectInfo b on c.PrjNum=b.PrjNum
            //WHERE a.zljdbm = @zljdbm) as aaa  
            //";
            dh.strSQL = @"SELECT
a.PKID,	/*业务编码 guid值*/ 
a.zljdbm,	/*市级平台监督注册号*/
a.dwlx,	/*单位类型 分为建设单位、勘察单位、设计单位、施工单位、监理单位、质量检测机构、混凝土供应商*/
a.Xh,	/*顺序号 每个监督注册号从1开始排序*/
a.Dwmc,	/*单位名称*/
a.dwdm,	/*单位组织机构代码*/
a.xmfzrxm,	/*项目负责人*/
a.xmfzrdm,	/*项目负责人身份证号*/
a.xmfzr_lxdh,		/*项目负责人电话*/
a.jsfzr,		/*项目技术负责人*/
a.jsfzr_lxdh,		/*项目技术负责人电话*/
a.Zly,		/*质量员*/
a.zly_lxdh,		/*质量员电话*/
a.qyy,	/*取样员*/
a.qyy_lxdh	/*取样员电话*/
FROM zj_gcjbxx_zrdw as a
WHERE a.zljdbm =@zljdbm ";
            dh.orderBy = " Xh ";
            dh.spc.Add("@zljdbm", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }



    #endregion

    #region 表数据查询
    /// <summary>
    /// 获取安全监督详细信息SQL处理类
    /// </summary>
    public class Instance_Read_AqbjInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取安全监督详细信息
            dh.strSQL = @"
SELECT
PKID,	/*业务编码 guid值*/ 
a.xmbm	,	/*项目编号*/
aqjdbm,	/*安全监督编码 市级平台编码*/
gcmc,	/*报监工程名称*/
sgzbbm,		/*施工招标编码*/
Aqjdjgmc,	/*安全监督机构名称*/
sdcode,		/*安全监督机构代码*/
a.gcgkYszj ,		/*工程造价（万元）*/
a.gcgkJzmj ,	/*工程面积（平方米）*/
b1.CodeInfo as gcgkJglx,		/*结构类型*/
a.gcgkCc ,		/*层次*/
bjrq,	/*报监日期*/
a.gcgkKgrq ,	/*开工日期*/
a.gcgkJhjgrq ,	/*计划竣工日期*/
zbdwDwdm ,	/*总包单位组织机构代码*/
zbdwDwmc ,	/*总包单位名称*/
zbdwAqxkzh ,	/*总包单位安全生产许可证*/
zbdwZcjzs ,	/*总包单位注册建造师*/
zbdwZcjzsdm ,	/*总包单位注册建造师身份证号*/
zbdwZcjzslxdh ,		/*总包单位注册建造师电话*/
zbdwAqy1,	/*总包单位专职安全员*/
zbdwAqyzh1,/*总包单位安全员证号*/
zbdwAqy2,zbdwAqyzh2,zbdwAqy3,zbdwAqyzh3,	
jldwDwdm,		/*监理单位组织机构代码*/
jldwDwmc,		/*监理单位名称*/
jldwXmzj,		/*总监姓名*/
jldwZjdm,		/*总监身份证号*/
jldwJlgcs1,	jldwJlgcs2,	jldwJlgcs3		/*监理员*/
bz,		/*备注*/
a.gis_jd,a.gis_wd
,c.qyID
FROM aj_gcjbxx AS a
LEFT JOIN tbPrjStructureTypeDic AS b1 ON a.gcgkJglx = b1.Code 
left join uepp_qyjbxx c on a.zbdwDwdm=c.zzjgdm 
WHERE PKID = @PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 获取合同备案信息SQL处理类
    /// </summary>
    public class Instance_Read_HtbaInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取安全监督详细信息
            dh.strSQL = @"
SELECT
RecordName,	/*合同项目名称*/
RecordNum,	/*合同备案编号*/
RecordInnerNum,	/*合同备案内部编号*/
PrjNum,	/*项目编号*/
ContractNum,	/*合同编号*/
ContractTypeNum,	/*合同类别  见代码表*/
b1.CodeInfo as ContractType,
ContractMoney,	/*合同金额(万元)*/
PrjSize,		/*建设规模*/
ContractDate,	/*合同签订日期*/
PropietorCorpName,	/*发包单位名称*/
PropietorCorpCode,	/*发包单位组织机构代码*/
ContractorCorpName,	/*承包单位名称*/
ContractorCorpCode,	/*承包单位组织机构代码*/
UnionCorpName,		/*联合体承包单位名称*/
UnionCorpCode,		/*联合体承包单位组织代码*/
PrjHead,	/*项目负责人*/
PrjHeadPhone,		/*项目负责人联系电话*/
IDCard	/*项目负责人证件号码*/
,c.jsdwID,d.qyID,e.ryID,a.tag,a.PrjType,ptdic.CodeInfo as PrjTypeLabel
FROM TBContractRecordManage AS a
LEFT JOIN tbContractTypeDic AS b1 ON a.ContractTypeNum = b1.Code 
left join uepp_Jsdw c on a.PropietorCorpCode=c.zzjgdm 
left join UEPP_Qyjbxx d on a.ContractorCorpCode=d.zzjgdm 
left join UEPP_Ryjbxx e on a.IDCard=e.zjhm 
left join tbPrjTypeDic ptdic on ptdic.Code =a.PrjType
WHERE PKID = @PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 获取竣工备案信息SQL处理类
    /// </summary>
    public class Instance_Read_JgbaInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取安全监督详细信息
            dh.strSQL = @"
SELECT
PrjNum,	/*项目编号*/
PrjFinishName,	/*指本次备案的内容项目名称*/
PrjFinishNum,	/*竣工备案编号*/
PrjFinishInnerNum,	/*竣工备案内部编号*/
BuilderLicenceNum,	/*施工许可证编号*/
QCCorpName,		/*质量检测机构名称*/
QCCorpCode,		/*质量检测机构组织机构代码*/
FactCost,	/*实际造价（万元）*/
FactArea,	/*实际面积（平方米）*/
FactSize,		/*实际建设规模*/
PrjStructureTypeNum,	/*结构体系  见代码表*/
b1.CodeInfo as PrjStructureType,
BDate,	/*实际开工日期*/
EDate,	/*实际竣工验收日期*/
Mark		/*备注*/

FROM TBProjectFinishManage AS a
LEFT JOIN tbPrjStructureTypeDic AS b1 ON a.PrjStructureTypeNum = b1.Code
WHERE PKID = @PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 获取招标投标信息SQL处理类
    /// </summary>
    public class Instance_Read_ZbtbInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取招标投标详细信息
            dh.strSQL = @"
SELECT
TenderName	,	/*标段名称*/
TenderNum,	/*中标通知书编号 按住建部编码规则统一编号*/
TenderInnerNum,	/*中标通知书内部编号 原业务系统内部编号*/
PrjNum	,		/*项目编号*/
TenderClassNum,		/*招标类型  见代码表*/
b1.CodeInfo as TenderClass,
TenderTypeNum,		/*招标方式  见代码表*/
b2.CodeInfo as TenderType,
TenderResultDate,		/*中标日期*/
TenderMoney,		/*中标金额*/
PrjSize,			/*建设规模*/
Area,		/*面积（平方米）*/
AgencyCorpName	,			/*招标代理单位名称*/
AgencyCorpCode,			/*招标代理单位组织机构代码*/
TenderCorpName,		/*中标单位名称*/
TenderCorpCode,		/*中标单位组织机构代码*/
ConstructorName,			/*项目经理/总监理工程师姓名*/
ConstructorPhone,			/*项目经理/总监理工程师电话*/
IDCardTypeNum,			/*项目经理/总监理工程师证件类型  见代码表*/
b3.CodeInfo as IDCardType,
ConstructorIDCard,			/*项目经理/总监理工程师证件号码 施工:项目经理 监理:总监理工程师*/
shypbf		/*项是否采用了三合*/
,c.qyID 
FROM TBTenderInfo AS a
LEFT JOIN tbTenderClassDic AS b1 ON a.TenderClassNum = b1.Code 
LEFT JOIN tbTenderTypeDic AS b2 ON a.TenderTypeNum = b2.Code 
LEFT JOIN tbIDCardTypeDic AS b3 ON a.IDCardTypeNum = b3.Code
left join UEPP_Qyjbxx c on a.TenderClassNum in ('001','002','003','006') and c.zzjgdm=a.TenderCorpCode 

WHERE PKID = @PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    ///  获取立项项目信息SQL处理类
    /// </summary>
    public class Instance_Read_LxxmInfo : IHandleSQL
    {

        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取安全监督详细信息
            dh.strSQL = @"select  
a.PKID,		/*业务编码 guid值*/ 
a.PrjNum,		/*项目编号 按住建部编码规则统一编号*/
a.PrjInnerNum,		/*原业务系统的内部编号*/
a.PrjName,		/*项目名称*/
a.PrjTypeNum,		/*项目分类 见代码表*/
b1.CodeInfo as PrjType,
a.BuildCorpName,		/*建设单位名称*/
a.BuildCorpCode,		/*建设单位组织机构代码*/
a.ProvinceNum,		/*项目所在省  见代码表*/
b2.CodeInfo as Province,
a.CityNum,		/*项目所在地市  见代码表*/
b3.CodeInfo as City,
a.CountyNum,		/* 项目所在区县  见代码表*/
b4.CodeInfo as County,
a.PrjApprovalNum,		/*立项文号*/
a.PrjApprovalLevelNum,		/*立项级别Num*/
b7.codeinfo as PrjApprovalLevel,/*立项级别*/
a.BuldPlanNum,		/*建设用地规划许可证编号*/
a.ProjectPlanNum,		/*建设工程规划许可证编号*/
a.AllInvest,		/*总投资（万元）*/
a.AllArea,		/*总面积（平方米）*/
a.PrjSize,		/*建设规模*/
a.PrjPropertyNum,	/*建设性质*/
b5.CodeInfo as PrjProperty,
a.PrjFunctionNum,	/*工程用途*/
b6.CodeInfo as PrjFunction,
a.BDate,		/*实际开工日期*/
a.EDate,		/*实际竣工日期*/
(select count(*) from TBTenderInfo where PrjNum=a.PrjNum) as ZtbxxCount,
(select count(*) from TBContractRecordManage where PrjNum=a.PrjNum ) as HtbaCount,
(select count(*) from TBProjectCensorInfo where PrjNum=a.PrjNum) as SgtscCount,
(select count(*) from TBBuilderLicenceManage where PrjNum=a.PrjNum) as SgxkCount,
(select count(*) from TBProjectFinishManage where PrjNum=a.PrjNum) as JgbaCount,
(select count(*) from aj_gcjbxx where xmbm=a.PrjNum) as AqbjCount,
(select count(*) from zj_gcjbxx where PrjNum=a.PrjNum) as ZlbjCount,
(select count(*) from xm_gcdjb_dtxm where PrjNum=a.PrjNum) as DxgcCount
,ISNULL(infov.jd1, a.jd) AS jd,ISNULL(infov.wd1,a.wd) AS wd,a.isSgbz
,c.jsdwID 
,ai.gyzzpl
,ai.dzyx
,ai.lxr
,ai.yddh
,ai.xmtz
,ai.gytze
,ai.gytzbl
,ai.lxtzze
,ai.programme_address
,infov.DocNum
,infov.DocCount
from TBProjectInfo as a
LEFT JOIN tbPrjTypeDic AS b1 ON a.PrjTypeNum = b1.Code 
LEFT JOIN tbXzqdmDic AS b2 ON a.ProvinceNum = b2.Code 
LEFT JOIN tbXzqdmDic AS b3 ON a.CityNum = b3.Code 
LEFT JOIN tbXzqdmDic AS b4 ON a.CountyNum = b4.Code 
LEFT JOIN tbPrjPropertyDic AS b5 ON a.PrjPropertyNum = b5.Code
LEFT JOIN tbPrjFunctionDic AS b6 ON a.PrjFunctionNum = b6.Code 
LEFT JOIN tbLxjbDic AS b7 ON a.PrjApprovalLevelNum = b7.Code 
left join uepp_Jsdw c on a.BuildCorpCode=c.zzjgdm 
LEFT JOIN TBProjectAdditionalInfo ai ON a.PrjNum=ai.prjnum 
LEFT JOIN VProjectInfoDoc infov ON a.PrjNum=infov.prjnum 
where a.PKID = @PKID";
            dh.spc.Add("@PKID", strParas[0]);

        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    ///  获取立项项目单项工程信息SQL处理类
    /// </summary>
    public class Instance_Read_LxxmDxgcInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有单项项目
            dh.strSQL = @"
select
PKID,	/*业务编码 guid值*/ 
PrjNum,	/*项目编号 按住建部编码规则统一编号*/
fxbm,	/* 单项编码 项目编码+流水号*/
fxnbbm,	/* 单项内部编号 原业务系统的内部编号*/
xmmc,	/*单项名称*/
b1.CodeInfo as gclb,		/*单项项目分类 见代码表*/
gczj,		/*单项投资（万元）*/
jzmj,		/*单项建筑面积（平方米）*/
jsgm,		/*建设规模*/
b2.CodeInfo as jglx,	/*结构类型  见代码表*/
b3.CodeInfo as jsyt,	/* 工程用途  见代码表*/
dscs,		/*地上层数*/
dxcs,		/*地下层数*/
gd,		/*高度(米)*/
kd	,		/*跨度(米)*/
jhkgrq,		/*计划开工日期*/
jhjgrq		/*计划竣工日期*/

FROM xm_gcdjb_dtxm as a
LEFT JOIN tbPrjFunctionDic AS b1 ON a.gclb = b1.Code 
LEFT JOIN tbPrjStructureTypeDic AS b2 ON a.jglx = b2.Code
LEFT JOIN tbPrjFunctionDic AS b3 ON a.jsyt = b3.Code 
WHERE PKID=@PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    ///  获取施工图审查信息SQL处理类
    /// </summary>
    public class Instance_Read_SgtscInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有单项项目
            dh.strSQL = @"
select
b.PrjName,
a.PKID,	/*业务编码 guid值*/ 
a.CensorName,	/*施工图审查合格书编号*/
a.CensorNum,/*施工图审查名称*/
a.CensorInnerNum,	/*施工图审查合格书内部编号*/
a.PrjNum,	/*项目编号*/
a.CensorCorpName,	/*施工图审查机构名称*/
a.CensorCorpCode,	/*施工图审查机构组织机构代码*/
a.CensorEDate,	/*审查完成日期*/
a.PrjSize,		/*建设规模*/
a.EconCorpName,	/*勘察单位名称*/
a.EconCorpCode,	/*勘察单位组织机构代码*/
a.DesignCorpName,	/*设计单位名称*/
a.DesignCorpCode,	/*设计单位组织机构代码*/
a.EconCorpNum,		/*勘察合同编码*/
a.DesignCorpNum,		/*设计合同编码*/
(CASE a.OneCensorIsPass WHEN 1 THEN '是'  WHEN 0 THEN '否' END) AS OneCensorIsPass,		/*一次审查是否通过 通过为1；不通过为0*/
a.OneCensorWfqtCount,		/*一次审查时违反强条数*/
a.OneCensorWfqtContent		/*一次审查时违反的强条条目*/
,c.qyID as kcqyID,d.qyID as sjqyID 
FROM TBProjectCensorInfo as a
LEFT JOIN TBProjectInfo as b ON a.PrjNum = b.PrjNum
left join UEPP_Qyjbxx c on a.EconCorpCode=c.zzjgdm
left join UEPP_Qyjbxx d on a.DesignCorpCode=d.zzjgdm 
WHERE a.PKID=@PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 获取施工许可证信息
    /// </summary>
    public class Instance_Read_SgxkzInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有单项项目
            dh.strSQL = @"
select
a.PKID,	/*业务编码 guid值*/ 
a.BuilderLicenceName,	/*项目名称*/
a.BuilderLicenceNum,	/*施工许可证编号 按住建部编码规则统一编号*/
a.BuilderLicenceInnerNum,	/*施工许可证内部编号*/
a.PrjNum,	/*项目编号*/
a.BuldPlanNum,		/*建设用地规划许可证编号*/
a.ProjectPlanNum,		/*建设工程规划许可证编号*/
a.CensorNum,		/*施工图审查合格书编号*/
a.ContractMoney,		/*合同金额(万元)*/
a.Area,	/*面积（平方米）*/
a.PrjSize,		/*建设规模*/
a.IssueCertDate,	/*发证日期*/
a.EconCorpName,	/*勘察单位名称*/
a.EconCorpCode,	/*勘察单位组织机构代码*/
a.DesignCorpName,	/*设计单位名称*/
a.DesignCorpCode,	/*设计单位组织机构代码*/
a.ConsCorpName,	/*施工单位名称*/
a.ConsCorpCode,	/*施工单位组织机构代码*/
a.SafetyCerID,		/*施工单位安全生产许可证编号*/
a.SuperCorpName,	/*监理单位名称*/
a.SuperCorpCode,	/*监理单位组织机构代码*/
a.ConstructorName,	/*项目经理姓名*/
a.CIDCardTypeNum,	/*项目经理证件类型  见代码表*/
b1.CodeInfo as CIDCardType,
a.ConstructorIDCard,	/*项目经理证件号码*/
a.ConstructorPhone	,		/*项目经理电话号码*/
a.SupervisionName,	/*总监理工程师姓名*/
a.SIDCardTypeNum,	/*总监理工程师证件类型 见代码表*/
b2.CodeInfo as SIDCardType,
a.SupervisionIDCard,	/*总监理工程师证件号码*/
a.SupervisionPhone		/*总监理工程师电话*/
,c.qyID as kcqyID,d.qyID as sjqyID,e.qyID as sgqyID,
b.BuildCorpName,b.BuildCorpCode
FROM TBBuilderLicenceManage as a
LEFT JOIN tbIDCardTypeDic AS b1 ON a.CIDCardTypeNum = b1.Code 
LEFT JOIN tbIDCardTypeDic AS b2 ON a.SIDCardTypeNum = b2.Code 
left join UEPP_Qyjbxx c on a.EconCorpCode =c.zzjgdm 
left join UEPP_Qyjbxx d on a.DesignCorpCode =d.zzjgdm 
left join UEPP_Qyjbxx e on a.ConsCorpCode =e.zzjgdm 
left join TBProjectInfo b on a.PrjNum=b.PrjNum 
WHERE a.PKID=@PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 获取质监信息
    /// </summary>
    public class Instance_Read_ZlbjInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //这段SQL用于取出所有单项项目
            dh.strSQL = @"
select
PKID,	/*业务编码 guid值*/ 
PrjNum,	/*项目编号*/
gcmc,	/*报监工程名称*/
zljdbm,	/*质量监督编码 市级平台监督注册号*/
sgzbbm,		/*施工招标编码*/
zljdjgmc,		/*质量监督机构名称*/
zjzbm,		/*质量监督机构代码*/
gczj,		/*工程造价（万元）*/
jzmj,		/*工程面积（平方米）*/
dlcd,		/*道路长度（米）*/
b.CodeInfo as jglx,		/*结构类型 详见数据字典表TBPRJSTRUCTURETYPEDIC*/
cc,		/*层次*/
jzgm,		/*建筑规模*/
sbrq,	/*报监日期*/
kgrq,	/*开工日期*/
jhjgrq,	/*计划竣工日期*/
xxjd,		/*形象进度*/
bz			/*备注*/

FROM zj_gcjbxx as a
LEFT JOIN tbPrjStructureTypeDic AS b ON a.jglx = b.Code 
WHERE PKID=@PKID
";
            dh.spc.Add("@PKID", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    #region 一站式申报安监页面
    /// <summary>
    /// 一站式申报：安全报监列表
    /// </summary>
    public class Instance_Gdv_AqbjNewInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有安全报监表
            dh.strSQL = @" SELECT * FROM (
SELECT a.[uuid]
      ,a.[xmmc]
      ,a.[PrjNum]
      ,a.[PrjName]
      ,a.[Ajjgmc]
      ,a.[AjCorpCode]
      ,a.[PrjSize]
      ,a.[EconCorpName]
      ,a.[EconCorpCode]
      ,a.[PrjApprovalNum]
      ,a.[BuldPlanNum]
      ,a.[ProjectPlanNum]
      ,a.[CityNum]
      ,a.[CountyNum]
      ,a.[PrjTypeNum]
      ,a.[sPrjTypeNum]
      ,a.[PrjFunctionNum]
      ,a.[sbr]
      ,a.[sbryddh]
      ,a.[CreateDate]
      ,a.[sfzps]
      ,a.[sfbz]
      ,a.[jdz]
      ,a.[wdz]
      ,a.[mj]
      ,a.[zj]
      ,a.[jgcc]
      ,a.[sbmb]
      ,a.[sfjk]
      ,a.[sgxkz]
      ,a.[UpdateFlag]
      ,a.[FetchDate]
      ,a.[UpdateTime]
      ,a.[UpdateUser]
      ,a.[updateDate]
      ,a.[Status]
      ,(case [status]
      when '1' then '已退回'
      when '2' then '已受理(已推送申报结果)'
      when '3' then '已办结'
      else '未受理' end ) AS StatusLabel
	  ,b.PKID AS LxPKID
      ,d.CodeInfo AS Country
    ,(
		SELECT TOP 1 jg.success
		FROM WJSJZX.dbo.Ap_ajsbjg jg
		WHERE jg.uuid = a.uuid
		ORDER BY jg.slrq DESC
		) AS SBJG
	,(
		SELECT TOP 1 tzs.jdzch
		FROM WJSJZX.dbo.Ap_ajtzs tzs
		WHERE tzs.uuid = a.uuid
		ORDER BY tzs.UpdateTime DESC
		) AS TZS
  FROM [dbo].[Ap_ajsbb] a
    LEFT JOIN [dbo].TBProjectInfo b ON a.PrjNum = b.PrjNum
    LEFT JOIN [dbo].tbXzqdmDic d on a.CountyNum = d.Code
                            ) as aaa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            List<IDataItem> list = cl.GetControlValue();
            string specialCountryNum = string.Empty;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if ("CountyNum".Equals(list[i].ItemName) && "320213".Equals(list[i].ItemData))
                {
                    specialCountryNum = "320213,320202,320203,320204";
                    list.RemoveAt(i);
                    break;
                }
            }

            if (!string.IsNullOrEmpty(specialCountryNum))
            {
                dh.strSQL += " and CountyNum in (" + specialCountryNum + ") ";
            }
            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  updateDate DESC ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有安全报监项目1
            dh.strSQL = @" SELECT * FROM (
SELECT a.[uuid]
      ,a.[xmmc]
      ,a.[PrjNum]
      ,a.[PrjName]
      ,a.[Ajjgmc]
      ,a.[AjCorpCode]
      ,a.[PrjSize]
      ,a.[EconCorpName]
      ,a.[EconCorpCode]
      ,a.[PrjApprovalNum]
      ,a.[BuldPlanNum]
      ,a.[ProjectPlanNum]
      ,a.[CityNum]
      ,a.[CountyNum]
      ,a.[PrjTypeNum]
      ,a.[sPrjTypeNum]
      ,a.[PrjFunctionNum]
      ,a.[sbr]
      ,a.[sbryddh]
      ,a.[CreateDate]
      ,a.[sfzps]
      ,a.[sfbz]
      ,a.[jdz]
      ,a.[wdz]
      ,a.[mj]
      ,a.[zj]
      ,a.[jgcc]
      ,a.[sbmb]
      ,a.[sfjk]
      ,a.[sgxkz]
      ,a.[UpdateFlag]
      ,a.[FetchDate]
      ,a.[UpdateTime]
      ,a.[UpdateUser]
      ,a.[updateDate]
      ,a.[Status]
      ,(case [status]
      when '1' then '已退回'
      when '2' then '已受理(已推送申报结果)'
      when '3' then '已办结'
      else '未受理' end ) AS StatusLabel
	  ,b.PKID AS LxPKID
      ,d.CodeInfo AS Country
    ,(
		SELECT TOP 1 jg.success
		FROM WJSJZX.dbo.Ap_ajsbjg jg
		WHERE jg.uuid = a.uuid
		ORDER BY jg.slrq DESC
		) AS SBJG
	,(
		SELECT TOP 1 tzs.jdzch
		FROM WJSJZX.dbo.Ap_ajtzs tzs
		WHERE tzs.uuid = a.uuid
		ORDER BY tzs.UpdateTime DESC
		) AS TZS
  FROM [dbo].[Ap_ajsbb] a
    LEFT JOIN [dbo].TBProjectInfo b ON a.PrjNum = b.PrjNum
    LEFT JOIN [dbo].tbXzqdmDic d on a.CountyNum = d.Code
    WHERE a.PrjNum=@PrjNum
                            ) as aaa WHERE 1=1";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            ////QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();
            string specialCountryNum = string.Empty;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if ("CountyNum".Equals(list[i].ItemName) && "320213".Equals(list[i].ItemData))
                {
                    specialCountryNum = "320213,320202,320203,320204";
                    list.RemoveAt(i);
                    break;
                }
            }

            if (!string.IsNullOrEmpty(specialCountryNum))
            {
                dh.strSQL += " and CountyNum in (" + specialCountryNum + ") ";
            }
            list.GetSearchClause(dh.spc, ref strSqlCondition);

            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            //dh.strSQL += " order by bjrq desc";

            dh.orderBy = "  updateDate DESC ";
        }

        #endregion
    }


    /// <summary>
    /// 一站式申报：安全报监详细信息
    /// </summary>
    public class Instance_Read_AqbjNewInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            //获取安全监督详细信息
            dh.strSQL = @"
SELECT [uuid] /*安监申报表编号*/ 
      ,[xmmc] /*安监项目名称*/
      ,[PrjNum] /*项目编号*/
      ,[PrjName] /*立项项目名称*/
      ,[Ajjgmc] /*安全监督机构名称*/
      ,[AjCorpCode] /*安全监督机构组织机构代码*/
      ,[PrjSize] /*建设规模*/
      ,[EconCorpName] /*建设单位名称*/
      ,[EconCorpCode] /*建设单位组织机构代码*/
      ,[PrjApprovalNum] /*立项批准文号*/
      ,[BuldPlanNum] /*建设用地规划许可证号*/
      ,[ProjectPlanNum] /*建设工程规划许可证号*/
      ,[CityNum] /*所在市州*/
	  ,d.CodeInfo AS CityLabel
      ,[CountyNum] /*所在县区*/
	  ,d2.CodeInfo AS CountryLabel
      ,[PrjTypeNum] /*项目分类*/
	  ,p.CodeInfo AS PrjTypeNumLabel
      ,[sPrjTypeNum] /*项目分类小类*/
	  ,p1.CodeInfo AS sPrjTypeLabel
      ,[PrjFunctionNum] /*工程用途*/
	  ,f.CodeInfo AS PrjFunctionLabel
      ,[sbr] /*申办人*/
      ,[sbryddh] /*申办人移动电话*/
      ,[CreateDate] /*记录登记日期*/
      ,[sfzps] /*是否是装配式*/
      ,[sfbz] /*是否是保障房*/
      ,[jdz] /*坐标经度*/
      ,[wdz] /*坐标纬度*/
      ,[mj] /*项目面积*/
      ,[zj] /*项目造价*/
      ,[jgcc] /*结构层次*/
      ,[sbmb] /*申报目标*/
      ,[sfjk] /*是否符合安装远程监控条件*/
      ,[sgxkz] /*施工许可证号*/
      ,[UpdateFlag]
      ,[FetchDate]
      ,[UpdateTime]
      ,[UpdateUser]
      ,[updateDate]
  FROM [dbo].[Ap_ajsbb] b
  left join dbo.tbXzqdmDic d on  b.CityNum = d.Code
  left join dbo.tbXzqdmDic d2 on  b.CountyNum = d2.Code
  left join dbo.tbPrjTypeDic p on b.PrjTypeNum = p.Code
  left join dbo.tbPrjSmallTypeDic p1 on b.sPrjTypeNum = p1.Code
  left join dbo.tbPrjFunctionDic f on b.PrjFunctionNum = f.Code
    WHERE uuid = @uuid
";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 一站式申报：安全报监-相关合同
    /// </summary>
    public class Instance_Gdv_AqbjNew_ht : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
      ,[RecordNum]
      ,[ContractTypeNum]
	  ,t.CodeInfo AS ContractTypeLabel
      ,[ContractMoney]
      ,[CorpCode]
      ,[CorpName]
      ,[PrjSize]
      ,[xmfzr]
      ,[xmfzrsfzh]
  FROM [dbo].[Ap_ajsbb_ht] h
  left join [dbo].[tbContractTypeDic] t on h.ContractTypeNum = t.Code
  where uuid = @uuid
                        ";
            dh.orderBy += " RecordNum asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：安全报监-单位人员
    /// </summary>
    public class Instance_Gdv_AqbjNew_dwry : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
      ,[idCard]
      ,[dwlx]
      ,[CorpCode]
      ,[CorpName]
      ,[zzzs]
      ,[zzlxdj]
      ,[zzyxq]
      ,[xm]
      ,[gw]
      ,[mp]
      ,[zgzh]
      ,[zy]
      ,[jhjcsj]
      ,[jhccsj]
      ,[lhtsx]
	  ,(case lhtsx
  when 1 then '联合体主体单位'
  when 2 then '联合体合作单位'
  else '非联合体' end) zyzgzshLabel
      ,[zyzgzsh]
  FROM [dbo].[Ap_ajsbb_dwry]
  where uuid = @uuid ";
            dh.orderBy += " dwlx asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：安全报监-材料清单
    /// </summary>
    public class Instance_Gdv_AqbjNew_clqd : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT *
FROM [dbo].[Ap_ajsbb_clqd]
WHERE uuid = @uuid";
            dh.orderBy += " sbzl asc,xh asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：安全报监-环境及地下设施交底项目
    /// </summary>
    public class Instance_Gdv_AqbjNew_hjssjd : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT *
FROM [dbo].[Ap_ajsbb_hjssjd]
WHERE uuid = @uuid";
            dh.orderBy += " xh asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：危险源较大工程清单
    /// </summary>
    public class Instance_Gdv_AqbjNew_wxyjdgcqd : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT *
FROM [dbo].[Ap_ajsbb_wxyjdgcqd]
WHERE uuid = @uuid";
            dh.orderBy += " fbfxgc asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// 一站式申报：超大规模危险源工程清单
    /// </summary>
    public class Instance_Gdv_AqbjNew_cgmgcqd : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT *
FROM [dbo].[Ap_ajsbb_cgmgcqd]
WHERE uuid = @uuid";
            dh.orderBy += " fbfxgc asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// 一站式申报：安监申报审批日志
    /// </summary>
    public class Instance_Gdv_AqbjNew_sprz : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"SELECT jg.slry AS TUser
	,(
		CASE jg.success
			WHEN 'Yes'
				THEN '受理通过'
			WHEN 'No'
				THEN '退回:' + jg.thyy
			ELSE ''
			END
		) AS Content
	,jg.UpdateTime
FROM [WJSJZX].[dbo].[Ap_ajsbjg] jg
WHERE uuid = @uuid
UNION ALL
SELECT tzs.tzrq AS Tuser
	,'推送监督通知书-监督注册号（' + tzs.jdzch + ')' AS Content
	,tzs.UpdateTime
FROM [WJSJZX].[dbo].[Ap_ajtzs] tzs
WHERE uuid = @uuid
";
            dh.orderBy += " UpdateTime asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region 一站式申报：质监申报相关页面
    /// <summary>
    /// 一站式申报：质量报监列表
    /// </summary>
    public class Instance_Gdv_ZlbjNewInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            //这段SQL用于取出所有质量报监表
            dh.strSQL = @" SELECT * FROM (
                SELECT a.[uuid]
	,a.[xmmc]
	,a.[PrjNum]
	,a.[PrjName]
	,a.[gcdz]
	,a.[Zjjgmc]
	,a.[ZjCorpCode]
	,a.[PrjSize]
	,a.[EconCorpName]
	,a.[EconCorpCode]
	,a.[PrjApprovalNum]
	,a.[BuldPlanNum]
	,a.[ProjectPlanNum]
	,a.[CityNum]
	,a.[CountyNum]
	,a.[PrjTypeNum]
	,a.[PrjFunctionNum]
	,a.[sbr]
	,a.[sbryddh]
	,a.[CreateDate]
	,a.[sfzps]
	,a.[UpdateFlag]
	,a.[FetchDate]
	,a.[UpdateTime]
	,a.[UpdateUser]
	,a.[updateDate]
	,a.[Status]
    ,(case a.[Status]
  when 1 then '已退回'
  when 2 then '已受理(已推送申报结果)'
  when 3 then '已办结'
  else '未受理' end) StatusLabel
	,a.[jsxz]
	,a.[tzlx]
	,b.PKID AS LxPKID
	,d.CodeInfo AS Country
FROM [WJSJZX].[dbo].[Ap_zjsbb] a
LEFT JOIN [WJSJZX].[dbo].TBProjectInfo b ON a.PrjNum = b.PrjNum
LEFT JOIN [WJSJZX].[dbo].tbXzqdmDic d ON a.CountyNum = d.Code
            ) as aaa WHERE 1=1 ";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;

            List<IDataItem> list = cl.GetControlValue();
            string specialCountryNum = string.Empty;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if ("CountyNum".Equals(list[i].ItemName) && "320213".Equals(list[i].ItemData))
                {
                    specialCountryNum = "320213,320202,320203,320204";
                    list.RemoveAt(i);
                    break;
                }
            }

            if (!string.IsNullOrEmpty(specialCountryNum))
            {
                dh.strSQL += " and CountyNum in (" + specialCountryNum + ") ";
            }

            list.GetSearchClause(dh.spc, ref strSqlCondition);
            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  updateDate DESC ";
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            dh.spc.Add("@PrjNum", strParas[0]);
            //这段SQL用于取出所有质量报监表
            dh.strSQL = @" SELECT * FROM (
SELECT a.[uuid]
	,a.[xmmc]
	,a.[PrjNum]
	,a.[PrjName]
	,a.[gcdz]
	,a.[Zjjgmc]
	,a.[ZjCorpCode]
	,a.[PrjSize]
	,a.[EconCorpName]
	,a.[EconCorpCode]
	,a.[PrjApprovalNum]
	,a.[BuldPlanNum]
	,a.[ProjectPlanNum]
	,a.[CityNum]
	,a.[CountyNum]
	,a.[PrjTypeNum]
	,a.[PrjFunctionNum]
	,a.[sbr]
	,a.[sbryddh]
	,a.[CreateDate]
	,a.[sfzps]
	,a.[UpdateFlag]
	,a.[FetchDate]
	,a.[UpdateTime]
	,a.[UpdateUser]
	,a.[updateDate]
	,a.[Status]
    ,(case a.[Status]
  when 1 then '审批退回'
  when 2 then '审批通过'
  else '未受理' end) StatusLabel
	,a.[jsxz]
	,a.[tzlx]
	,b.PKID AS LxPKID
	,d.CodeInfo AS Country
FROM [WJSJZX].[dbo].[Ap_zjsbb] a
LEFT JOIN [WJSJZX].[dbo].TBProjectInfo b ON a.PrjNum = b.PrjNum
LEFT JOIN [WJSJZX].[dbo].tbXzqdmDic d ON a.CountyNum = d.Code
WHERE a.PrjNum=@PrjNum
                            ) as aaa WHERE 1=1";
            //此处用于自动生成页面查询条件合并入strSQL
            string strSqlCondition = string.Empty;
            ////QueryAssistant.GenerateSearchClauseAndSPC(cl, ref strSqlCondition, dh.spc);
            List<IDataItem> list = cl.GetControlValue();

            string specialCountryNum = string.Empty;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if ("CountyNum".Equals(list[i].ItemName) && "320213".Equals(list[i].ItemData))
                {
                    specialCountryNum = "320213,320202,320203,320204";
                    list.RemoveAt(i);
                    break;
                } 
            }

            if (!string.IsNullOrEmpty(specialCountryNum))
            {
                dh.strSQL += " and CountyNum in (" + specialCountryNum + ") ";
            }

            list.GetSearchClause(dh.spc, ref strSqlCondition);

            if (!string.IsNullOrEmpty(strSqlCondition))
            {
                dh.strSQL = dh.strSQL + strSqlCondition;
            }
            dh.orderBy = "  updateDate DESC ";
        }

        #endregion
    }

    /// <summary>
    /// 一站式申报：质量报监详细信息
    /// </summary>
    public class Instance_Read_ZlbjNewInfo : IHandleSQL
    {
        #region IHandleSQL 成员

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
	,[xmmc]
	,[PrjNum]
	,[PrjName]
	,[gcdz]
	,[Zjjgmc]
	,[ZjCorpCode]
	,[PrjSize]
	,[EconCorpName]
	,[EconCorpCode]
	,[PrjApprovalNum]
	,[BuldPlanNum]
	,[ProjectPlanNum]
	,[CityNum]
	,d.CodeInfo AS CityLabel
	,[CountyNum]
	,d2.CodeInfo AS CountryLabel
	,[PrjTypeNum]
	,p.CodeInfo AS PrjTypeLabel
	,[PrjFunctionNum]
	,f.CodeInfo AS PrjFunctionLabel
	,[sbr]
	,[sbryddh]
	,[CreateDate]
	,[sfzps]
	,[UpdateFlag]
	,[FetchDate]
	,[UpdateTime]
	,[UpdateUser]
	,[updateDate]
	,[Status]
	,[jsxz]
    ,x.CodeInfo AS jsxzLabel
	,[tzlx]
FROM [dbo].[Ap_zjsbb] b
LEFT JOIN dbo.tbXzqdmDic d ON b.CityNum = d.Code
LEFT JOIN dbo.tbXzqdmDic d2 ON b.CountyNum = d2.Code
LEFT JOIN dbo.tbPrjTypeDicNew p ON b.PrjTypeNum = p.Code
LEFT JOIN dbo.tbPrjFunctionDic f ON b.PrjFunctionNum = f.Code
LEFT JOIN dbo.tbPrjPropertyDic x ON b.jsxz = x.Code
    WHERE uuid = @uuid
";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 一站式申报：质量报监-相关合同
    /// </summary>
    public class Instance_Gdv_ZlbjNew_ht : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
	,[RecordNum]
	,[ContractTypeNum]
	,t.CodeInfo AS ContractTypeLabel
	,[ContractMoney]
	,[CorpCode]
	,[CorpName]
	,[PrjSize]
	,[xmfzr]
	,[xmfzrsfzh]
FROM [dbo].[Ap_zjsbb_ht] h
LEFT JOIN [dbo].[tbContractTypeDic] t ON h.ContractTypeNum = t.Code
WHERE uuid = @uuid ";
            dh.orderBy += " RecordNum asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：质量报监-单位人员
    /// </summary>
    public class Instance_Gdv_ZlbjNew_dwry : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
	,[idCard]
	,[dwlx]
	,[CorpCode]
	,[CorpName]
	,[zzzs]
	,[zzlxdj]
	,[zzyxq]
	,[dwdz]
	,[fddbr]
	,[fddbrsfz]
	,[dwlxdh]
	,[xm]
	,[gw]
	,[lxdh]
	,[zgzh]
	,[zgdj]
	,[zy]
	,[jhjcsj]
	,[jhccsj]
	,[lhtsx]
    ,(case lhtsx
  when 1 then '联合体主体单位'
  when 2 then '联合体合作单位'
  else '非联合体' end) zyzgzshLabel
	,[zyzgzsh]
FROM [dbo].[Ap_zjsbb_dwry]
WHERE uuid = @uuid ";
            dh.orderBy += " dwlx asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：质量报监-施工图审查合格书
    /// </summary>
    public class Instance_Gdv_ZlbjNew_schgs : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
	,[CensorNum]
	,[CensorName]
	,[CensorCorpName]
	,[CensorCorpCode]
	,[CensorEDate]
	,[PrjSize]
	,[UpdateFlag]
FROM [dbo].[Ap_zjsbb_schgs]
WHERE uuid = @uuid ";
            dh.orderBy += " CensorNum asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：质量报监-单位工程
    /// </summary>
    public class Instance_Gdv_ZlbjNew_dwgc : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT [uuid]
	,[dtzljdbm]
	,[dwgcbm]
	,[dwgcmc]
	,[gcfl]
	,ISNULL(p.CodeInfo, [gcfl]) AS gcflLabel
	,[dsjzmj]
	,[dxjzmj]
	,[rfmj]
	,[dsjzcd]
	,[dxjzcd]
	,[dwgczj]
	,[ztcs]
	,[dscs]
	,[dxcs]
	,[gd]
	,[kd]
	,[PrjStructureTypeNum]
	,ISNULL(s.CodeInfo, [PrjStructureTypeNum]) AS PrjStructureTypeLabel
	,[kzdj]
	,[xfdj]
	,[jclx]
	,ISNULL(j.CodeInfo, [jclx]) AS jclxLabel
	,[djlx]
	,ISNULL(d.CodeInfo, [djlx]) AS djlxLabel
	,[stbh]
	,[gclx]
	,[jsyt]
	,ISNULL(f.CodeInfo, [jsyt]) AS jsytLabel
	,[zzts]
	,[sfzps]
	,[jhkgrq]
	,[jhjgrq]
	,[UpdateFlag]
FROM [dbo].[Ap_zjsbb_dwgc] b
LEFT JOIN dbo.tbPrjTypeZj p ON p.Code = b.gcfl
LEFT JOIN dbo.tbPrjStructureTypeDic s ON s.Code = b.PrjStructureTypeNum
LEFT JOIN dbo.tbJCLXDic j ON j.Code = b.jclx
LEFT JOIN dbo.tbDJLXDic d ON d.Code = b.djlx
LEFT JOIN dbo.tbPrjFunctionDic f ON f.Code = b.jsyt
WHERE uuid = @uuid ";
            dh.orderBy += " dwgcbm asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// 一站式申报：质量报监-材料清单
    /// </summary>
    public class Instance_Gdv_ZlbjNew_clqd : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"
SELECT *
FROM [dbo].[Ap_zjsbb_clqd]
WHERE uuid = @uuid";
            dh.orderBy += " sbzl asc,xh asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 一站式申报：质监申报审批日志
    /// </summary>
    public class Instance_Gdv_ZlbjNew_sprz : IHandleSQL
    {

        public void HandleSQL(DataHandle dh)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas)
        {
            dh.strSQL = @"SELECT jg.slry AS TUser
	,(
		CASE jg.success
			WHEN 'Yes'
				THEN '受理通过'
			WHEN 'No'
				THEN '退回:' + jg.thyy
			ELSE ''
			END
		) AS Content
	,jg.UpdateTime
FROM [WJSJZX].[dbo].[Ap_zjsbjg] jg
WHERE uuid = @uuid
UNION ALL
SELECT tzs.tzrq AS Tuser
	,'推送监督通知书-监督注册号（' + tzs.jdzch + ')' AS Content
	,tzs.UpdateTime
FROM [WJSJZX].[dbo].[Ap_zjtzs] tzs
WHERE uuid = @uuid
";
            dh.orderBy += " UpdateTime asc";
            dh.spc.Add("@uuid", strParas[0]);
        }

        public void HandleSQL(DataHandle dh, Control cl)
        {
            throw new NotImplementedException();
        }

        public void HandleSQL(DataHandle dh, string[] strParas, Control cl)
        {
            throw new NotImplementedException();
        }
    }


    #endregion


    #endregion



}
