using System;
using Bigdesk8.Business;
using Wxjzgcjczy.Common;
using System.Collections.Generic;

/*
 * ����ö��ȡ��������ԭ����Ҫ�ǣ�ö�ٸ��ϸ�Щ���������ڱ�֤�����߼����Ͻ��ԡ�
 * 
 * �ر�ע�⣡��������������������
 * 1. ��ö�������е�ö���������ȷ�ض���ֵ�����������0��1��2��������������Ȼ�����ĸ�ֵ��ʽ��
 * 2. һ��ϵͳͶ��ʵ�����У��޸�����ö����Ķ��壨����ö��������ƺ�ֵ��ʱҪ�ر��ģ��Է��������ݿ����������ݵı�ʶ�ֶεĺ��塣
 *    ���ܵ�����£���Ҫ�޸ġ�����������ö����Ķ��塣
 */

namespace Wxjzgcjczy
{
    /// <summary>
    /// ����״̬ö��
    /// </summary>
    /// һ���Ӧ��ṹ�е��ֶ�OperateState
    public enum OperateState
    {
        /// <summary>
        /// �޿��в���
        /// </summary>
        NoFeasibleAction = 0,
        /// <summary>
        /// �ȴ�����
        /// </summary>
        WaitingCreate = 10,

        /// <summary>
        /// �ȴ��ύ
        /// </summary>
        WaitingSubmit = 50,

        /// <summary>
        /// �ȴ�һ��
        /// </summary>
        WaitingFirstCheck = 100,

        /// <summary>
        /// �ȴ�����
        /// </summary>
        WaitingSecondCheck = 200,

        /// <summary>
        /// �ȴ�����
        /// </summary>
        WaitingThirdCheck = 400,

        /// <summary>
        /// ҵ�����
        /// </summary>
        Completed = 999,
    }
    /// <summary>
    /// �༭����
    /// </summary>
    public enum OperateSt
    {
        add,
        edit
    }

    /// <summary>
    /// ����״̬ö��
    /// </summary>
    /// һ���Ӧ��ṹ�е��ֶ�DataState
    public enum DataState
    {
        /// <summary>
        /// ������
        /// </summary>
        New = 0,

        /// <summary>
        /// ���ύ(���걨)
        /// </summary>
        Submited = 10,
     
        /// <summary>
        /// �ѳ����ύ�������걨��
        /// </summary>
        SubmitCancelled = -10,

        /// <summary>
        /// ���ͨ����ͨ��Ԥ��
        /// </summary>
        CheckPast = 20,
        /// <summary>
        /// ��˲�ͨ��
        /// </summary>
        CheckRejected = -20,

        /// <summary>
        /// ����ʵʩ״̬,��Ŀ����״̬
        /// </summary>
        FirstCheckPast = 40,

        /// <summary>
        /// һ��ͨ��
        /// </summary>
        FirstCheckRejected = -100,

        /// <summary>
        /// һ���ѳ���
        /// </summary>
        FirstCheckCancelled = 110,

        /// <summary>
        /// ����ͨ��
        /// </summary>
        SecondCheckPast = 200,

        /// <summary>
        /// ����ͨ��
        /// </summary>
        SecondCheckRejected = -200,

        /// <summary>
        /// �����ѳ���
        /// </summary>
        SecondCheckCancelled = 210,

        /// <summary>
        /// ����ͨ��
        /// </summary>
        ThirdCheckPast = 400,

        /// <summary>
        /// ����ͨ��
        /// </summary>
        ThirdCheckRejected = -400,

        /// <summary>
        /// �����ѳ���
        /// </summary>
        ThirdCheckCancelled = 410,

        /// <summary>
        /// ��ɾ��
        /// </summary>
        Deleted = -1,
    }

    /// <summary>
    /// ������еĴ�������
    /// </summary>
    public enum CodeType
    {
        �ո��������� = 0,
        ����״̬ = 10,
        �Ƿ� = 20,
        ��ҵ�������� = 40,
        ��ҵ���ʵȼ� = 60,
        ��ҵ�������� = 30,
        ��Աְ�� = 70,
        ��Աְ�� = 80,
        ��ҵ֤������ = 90,
        ��Աѧ�� = 100,
        ��Աִҵ�ʸ����� = 110,
        ��Ա������� = 120,
        ��Ա���ʵȼ� = 130,
        ��ҵ������� = 140,
        ��Ա������� = 150,
        ��Ŀ������� = 160,
        ��Աְ��רҵ = 170,
        ��ҵ������� = 180,
        �������� = 190,
        �������� = 200,
      
        ���=210,
        �ṹ=220,
        Ͷ������ =230,
        רҵ���� =240, 
        ʹ�����=250,
        ��ҵ����ҵ������=260,
        ��Ŀ���������ʵȼ�,
        ���ͨ��Ա
    }
    /// <summary>
    /// ���̱������
    /// </summary>
    public enum Gcbglx
    {
        �ֳ�����ǩ֤���,
        �����˶����,
        �����ϼ۱��,
        ��Ʊ��
    }
    /// <summary>
    /// ҵ��׶�
    /// </summary>
    public enum Ywjd
    {
        �ƻ�����׶�,
        �������׶�,
        ����ʩ���׶�,
        �������ս׶�
    }
    /// <summary>
    /// ҵ������
    /// </summary>
    public enum Ywlx
    {
        ��Ŀ����,
        �������,
        �������о�,
        ��������,
        �滮ѡַ,
        �����õ�,
        ��Ŀ����,
        Ͷ������,
        �����Ҫ,
        ��Ŀ���,
        ͼֽ���,
        �б�Ͷ��,
        ��ͬ����,
        ʩ�����,
        ��������,
        ���̱��,
        ���̿�֧��,
        ʩ������,
        ��̬����,
        �ֲ�����,
        ��������,
        �����ƽ�,
        ��������
    }
    /// <summary>
    /// �ļ�����
    /// </summary>
    public enum Wjmc
    {
        ��Ŀ������,
        ��Ŀ����������,
        ����������������,
        �����������,
        ������Ʒ���,
        �������о�����,
        �������о������������,
        ����Ӱ�챨����,
        ����Ӱ�������������,
        ѡַ���뱨��,
        ѡַ�滮�����,
        ���̹滮���֤,
        �õع滮���֤,
        �õ����뱨��,
        �����õ���׼��,
        ��������ʹ��֤,
        ��Ŀ�������뱨��,
        ��Ŀ��������,
        ����������йػ����Ҫ,
        Ͷ�����󱨸�,
        ����ˮ�ĵ��ʿ��챨��,
        ���β����ɹ�����,
        �������ͼֽ��˵��,
        �������ͼֽ��˵��,
        ʩ��ͼ����Ƽ����鼰��˵��,
        ��Ʒ�����������,
        ʩ��ͼ���ϸ�֤��,
        ʩ��ͼֽ�����¼,
        ʩ��ͼֽ�������,
        �б��ļ�,
        Ͷ���ļ�,
        �������嵥����,
        �б�֪ͨ��,
        ��ͬ������,
        ��ͬ���Ӹ���,
        ��ȫ�ල֪ͨ��,
        �����ල֪ͨ��,
        ����ʩ�����֤,
        ���赥λ��Ŀ���������������Ա����,
        ʩ����λ��Ŀ���������������Ա����,
        ����λ��Ŀ���������������Ա����,
        �������ձ�����,
        ר�������Ͽ��ļ�,
        ���̱����,
        ��Ʊ��֪ͨ��,
        �ֳ�ǩ֤��,
        �����˶���,
        �۸���ϻ�ִ��,
        ���̿�֧�����뵥,
        ���̿�֧����Ʊ,
        ʩ�����ȼƻ���,
        ���赥λ�ձ�,
        ʩ����λ�±�,
        ����λ�±�,
        ���鹤������ͼƻ�����,
        �ֲ����ձ���,
        ��λ�����������ռ�¼,
        �������ձ���,
        ��������֤����,
        ��������������,
        ������Ŀ�ƽ�����,
        ����ʹ�òƲ��ܱ�,
        �Ʋ���ϸ��,
        ����������,
        �������������,
        ���̿�֧�������,
        ���˹���֧�������,
        ������˳ɹ�������,
        ���������ѯ������,
        ���������ѯ��ͬ,
        ���̽����󶨵�,
        �����Ҫ,
        ��Ŀ��Ѳ���

    }

    /// <summary>
    /// �ɽ�����Щ����������ö��
    /// </summary>
    /// һ���Ӧ��ṹ�е��ֶ�CancelState
    public enum CancelState
    {
        /// <summary>
        /// �޿ɳ�����û�ж����ɳ���
        /// </summary>
        NoActionToCancel = 0,

        /// <summary>
        /// �ȴ������ύ
        /// </summary>
        WaitingCancelSubmit = 100,

        /// <summary>
        /// �ȴ�����һ��
        /// </summary>
        WaitingCancelFirstCheck = 200,

        /// <summary>
        /// �ȴ���������
        /// </summary>
        WaitingCancelSecondCheck = 300,

        /// <summary>
        /// �ȴ���������
        /// </summary>
        WaitingCancelThirdCheck = 400,

        /// <summary>
        /// ��ֹ����
        /// </summary>
        Forbidden = 999
    }

    /// <summary>
    /// ��ˣ�������ˣ����״̬
    /// </summary>
    /// һ���Ӧ��ṹ�еĸ��׶ε���˽���ֶΣ���Checkbz1
    public enum CheckState
    {
        /// <summary>
        /// δ���
        /// </summary>
        NotChecked = 0,

        /// <summary>
        /// ���ͨ��
        /// </summary>
        Past = 100,

        /// <summary>
        /// ��˲�ͨ��
        /// </summary>
        Rejected = -100,

        /// <summary>
        /// �ѳ���(���)
        /// </summary>
        Cancelled = -1
    }

    /// <summary>
    /// ��������ö��
    /// </summary>
    /// ������Ӧҵ����ĳ���ֶΡ����Ƕ�һ��ҵ��ģ��Ŀ��ܵĲ������о٣�Ҳ��Ȩ�޹����һ����Ҫά�ȡ�
    /// ������ÿ�������Ҫ��Ȩ�޹������ñ������ã��磺Retrieve, Update, Delete, CancelSubmit, CancelFirstCheck, 
    /// CancelSecondCheck, CancelThirdCheck��ֻ�����ڳ����߼���
    public enum OperateCode
    {
        /// <summary>
        /// ���
        /// </summary>
        Create = 10,

        /// <summary>
        /// ��ѯ
        /// </summary>
        Retrieve = 20,

        /// <summary>
        /// �޸�
        /// </summary>
        Update = 30,

        /// <summary>
        /// ɾ��
        /// </summary>
        Delete = 40,

        /// <summary>
        /// �걨
        /// </summary>
        Submit = 50,

        /// <summary>
        /// �����걨
        /// </summary>
        CancelSubmit = 60,

        /// <summary>
        /// ���
        /// </summary>
        FirstCheck = 70,

        /// <summary>
        /// �������
        /// </summary>
        CancelFirstCheck = 90,

        /// <summary>
        /// ����
        /// </summary>
        SecondCheck = 100,

        /// <summary>
        /// ��������
        /// </summary>
        CancelSecondCheck = 120,

        /// <summary>
        /// ����
        /// </summary>
        ThirdCheck = 130,

        /// <summary>
        /// ��������
        /// </summary>
        CancelThirdCheck = 150
    }

    /// <summary>
    /// ҵ��ģ�飬ϵͳ����ģ��
    /// </summary>
    public enum ModuleCode
    {
        //��������Ա
        ϵͳ��ɫ = 10,
        �û����� = 20,
        Ȩ������ = 30,
        //��ҵ��
        ��ҵ��Ϣע�� = 39,
        ��ҵ��Ϣ�_������Ϣ = 40,
        ��ҵ��Ϣ�_��ҵ���� = 41,
        ��ҵ��Ϣ�_��Ҫ�ɶ� = 42,
        ��ҵ��Ϣ�_������Ա = 43,
        ��ҵ��Ϣ�_����֤�� = 44,
        ��ҵ��Ϣ�_��ҵ�걨 = 46,

        ��Ա��Ϣ� = 50,

        ��ҵ��Ϣ��� = 60,

        ��Ա��Ϣ��� = 70,

        ��Ա�������� = 80,

        ������Ŀ���� = 90,
        ������Ŀ����_���Ӳ��� = 91,

        ��ҵ�������� = 100,
        ��ҵ���ʱ��� = 105,
        ��ҵ���б��� = 106,

        ��ҵ�ۺϿ��� = 110,

        ��ҵ������Ϣ = 120,

        ��ҵ������Ϣ = 130,

        ��ҵ֤�鸽�� = 140,
        //�����
        ��ҵ�û����� = 150,
        ��ҵ��Ϣ��� = 160,
        ��Ա��Ϣ��� = 170,
        ������Ŀ��Ϣ = 180,
        һ������Ԥ�� = 190,
        �������ʳ��� = 200,
        ����������� = 210,

    }

    /// <summary>
    /// ���ü����Ƕ�ö��
    /// </summary>
    public enum WhatToRetrieve
    {
        δ���� = 0,

        �ҵ�����ҵ�� = 5,

        ����δɾ�� = 8,

        �ȴ��걨 = 10,

        ���걨 = 40,

        �ȴ���� = 50,

        /// <summary>
        /// �������ͨ������˲�ͨ��
        /// </summary>
        ����� = 80,

        �ȴ����� = 90,

        /// <summary>
        /// ��������ͨ��������ͨ��
        /// </summary>
        �Ѷ��� = 120,
    }

    /// <summary>
    /// ��ǰϵͳ��Ϣ
    /// </summary>
    public struct AppInfo
    {
        /// <summary>
        /// ��ǰӦ��ϵͳID
        /// </summary>
        public static int SystemID = Convert.ToInt32(SubSystem.���������������Ŀ�������ϵͳ);

        public static string SystemName = SubSystem.���������������Ŀ�������ϵͳ.ToString();
    }
    /// <summary>
    /// �û�����
    /// </summary>
    public enum UserType
    {
        δ���� = 0,
        //
        ϵͳ����Ա = 10,
        //
        �����û� = 20,
        //
        ������� = 30,
        //
        ʵʩ��λ = 40,

        ����λ = 50,

        �걨���� = 60,

    }
    /// <summary>
    /// Ӧ��ϵͳ�û���Ϣ�ṹ��
    /// </summary>
    [Serializable]
    public struct AppUser
    {
        /// <summary>
        /// �û�ID
        /// </summary>
        public string UserID;
        /// <summary>
        /// �û���¼��
        /// </summary>
        public string LoginName;
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName;

        /// <summary>
        /// ���һ�ε�¼ʱ��
        /// </summary>
        public string LastLoginTime;
        /// <summary>
        /// �û�����
        /// </summary>
        public UserType UserType;

        /// <summary>
        /// ��ҵID
        /// </summary>
        public string qyID;
        /// <summary>
        /// ��֯��������
        /// </summary>
        public string zzjgdm;

        public List<ModuleOperate> list;
 
    }

    public enum Xmlx
    { 
        �����Ŀ,������Ŀ,�н���Ŀ,ȫ������
    }
    /// <summary>
    /// ���ݼ����������
    /// </summary>

    public enum DataFlow
    {
        ʡһ�廯ƽ̨�������������� = 0, ʡ��ͼϵͳ�������������� = 1, ʡʩ�����ϵͳ�������������� = 2, ʡ�ʼ�ϵͳ�������������� = 3, ʡ��������ϵͳ�������������� = 4,
        ��һ��ͨϵͳ�������������� = 5, �п������ϵͳ�������������� = 6, ����Ͷ��ϵͳ�������������� = 7, ��������Ͷ��ϵͳ�������������� = 8, ��������Ͷ��ϵͳ�������������� = 9, �а���ϵͳ = 10, ���ʼ�ϵͳ�������������� = 11, ���ÿ���ϵͳ�������������� = 12, ��ɽ���������������� = 13, �������������������� = 14, ��������ƽ̨�������������� = 15,
        �����������ĵ��п������ϵͳ = 16, �����������ĵ�����Ͷ��ϵͳ = 17, �����������ĵ���������Ͷ��ϵͳ = 18, �����������ĵ���������Ͷ��ϵͳ = 19, �����������ĵ��а���ϵͳ = 20, �����������ĵ����ʼ�ϵͳ = 21, �����������ĵ����ÿ���ϵͳ = 22, �����������ĵ���ɽ�� = 23, �����������ĵ������� = 24, �����������ĵ���������ƽ̨ = 25
    }


    public enum Tag
    {
        ���ս��蹫����������ƽ̨ = 0,
        ��һ��ͨϵͳ = 1,
        �����н��蹤�̰�ȫ�ලվ = 2,
        �����п��������ҵ��Ϣ����ϵͳ = 3,
        ʡһ�廯ƽ̨ = 4,
        ʡʩ�����ϵͳ = 5,
        ʡ��������ϵͳ = 6,
        ʡ�ʼ�ϵͳ = 7,
        ס������������� = 8

    }
   
}