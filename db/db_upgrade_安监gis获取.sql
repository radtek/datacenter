use WJSJZX;

/* �����걨gis��Ϣ��*/
CREATE TABLE [dbo].[Ap_ajsbb_gis](
    [pointId] [varchar](50) NOT NULL,/*��¼����*/
	[uuid] [varchar](50) NOT NULL,/*�����걨����,��һվʽ�걨ϵͳ�Զ�����*/
	[modified] [datetime] NOT NULL, /*����޸�����ʱ�� */
	[mapLat] [decimal](18, 6) NULL,
	[mapLng] [decimal](18, 6) NULL,
	[pointOrder] [int] NULL, /*�����˳�� */
	[pointTeam] [int] NULL, /*��������*/
	[pointType] [int] NULL, /* ���������*/
	[updateFlag] [char](1) NULL, /* ���ݸ��±�ʶ:U��������£�Dɾ�� */
	[createTime] [datetime] NULL, /*�Ŀ��޸�����ʱ�� */
	[updateTime] [datetime] NULL, /*�Ŀ��޸�����ʱ�� */
	[updateUser] [varchar](50) NULL,
    Primary key(pointId)
)

/* ����Ȩ�ޱ� */
alter table [WJSJZX].[dbo].[uepp_InterfaceUser] add Has_Ap_ajsbb_gis_Write int not null default 0;
update [WJSJZX].[dbo].[uepp_InterfaceUser] set Has_Ap_ajsbb_gis_Write = 1 where Id = 1;

/* �����걨��Ŀ�ֳ��ල��Ϣ��*/
CREATE TABLE [WJSJZX].[dbo].[Ap_ajsbb_info](
	[uuid] [varchar](50) NOT NULL,/*�����걨����,��һվʽ�걨ϵͳ�Զ�����*/
	[superviseStatus] [int] NULL,/* �ֳ��ල״̬��1.�������� 2.�ڽ� 3.ͣ�� 4.�ڼ���ͣ�� 5.��ֹ���� */
	[modified] [datetime] NULL, /*����޸�����ʱ�� */
	[createTime] [datetime] NULL, /*�Ŀⴴ������ʱ�� */
	[updateTime] [datetime] NULL, /*�Ŀ��޸�����ʱ�� */
	[updateUser] [varchar](50) NULL,
	[updateFlag] [char](1) NULL, 
	Primary key(uuid)
)