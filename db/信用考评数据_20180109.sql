 
CREATE TABLE [WJSJZX].[dbo].[Xypj_kpjlhz](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kp_nf] [int] NOT NULL, /* 考评年份 */
	[kp_jd] [int] NOT NULL, /* 考评时段:1,2,3,4 */
	[kpqymc] [varchar](255) NOT NULL, /* 企业名称 */
	[kpqy_zzjgdm] [varchar](20) NOT NULL, /* 企业组织机构代码 */
	[zhdf] [decimal](18, 2) NULL, /* 评价得分 */
	[khnf] [int] NULL, /* 考核年度, (不填默认为考评年份) */
	[khyf] [int] NULL, /* 考核月份:1,2,3,4 ,(不填默认为考评时段)*/
	[updateFlag] [char](1) NULL, /* 操作符号，修改或增加为U，删除为D */
	[updateUser] [varchar](50) NULL, /* 更新人员 */
	[createTime] [datetime] NULL, /* 创建时间 */
	[updateTime] [datetime] NULL, /* 更新时间 */
	Primary key(id)
);


-- 新增信用考评接口用户权限
INSERT INTO [WJSJZX].[dbo].[uepp_InterfaceUser]
           ([UserName]
           ,[Pwd]
           ,[FullName]
           ,[Flag]
           ,[Has_TBProjectInfo]
           ,[Has_xm_gcdjb_dtxm]
           ,[Has_TBTenderInfo]
           ,[Has_TBContractRecordManage]
           ,[Has_TBProjectCensorInfo]
           ,[Has_TBProjectDesignEconUserInfo]
           ,[Has_TBBuilderLicenceManage]
           ,[Has_TBProjectBuilderUserInfo]
           ,[Has_TBProjectFinishManage]
           ,[Has_aj_gcjbxx]
           ,[Has_zj_gcjbxx]
           ,[Has_aj_zj_sgxk_relation]
           ,[Has_Xykp]
           ,[Has_Htba]
           ,[Has_Jsdw]
           ,[Has_Sgdw]
           ,[Has_Kcdw]
           ,[Has_Sjdw]
           ,[Has_Zjjg]
           ,[Has_Zczyry]
           ,[Has_Aqscglry]
           ,[Has_Zygwglry]
           ,[UpdateTime]
           ,[DataState]
           ,[Has_TBProjectInfo_Write]
           ,[Has_xm_gcdjb_dtxm_Write]
           ,[Has_TBTenderInfo_Write]
           ,[Has_TBContractRecordManage_Write]
           ,[Has_TBProjectCensorInfo_Write]
           ,[Has_TBProjectDesignEconUserInfo_Write]
           ,[Has_TBBuilderLicenceManage_Write]
           ,[Has_TBProjectBuilderUserInfo_Write]
           ,[Has_TBProjectFinishManage_Write]
           ,[Has_aj_gcjbxx_Write]
           ,[Has_zj_gcjbxx_Write]
           ,[Has_aj_zj_sgxk_relation_Write]
           ,[Has_Xykp_Write]
           ,[Has_Xzcf_Write]
           ,[Has_platform_write])
     VALUES
           ('xykpsb','DflB6WsS','信用考评数据上报',0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,GETDATE()
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,1
           ,0
           ,0)

 update WJSJZX.dbo.uepp_InterfaceUser set [Has_Xykp_Write] = 1 where UserName = 'wxjsj';




