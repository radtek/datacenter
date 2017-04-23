using System;
using Bigdesk8.Business;

/*
 * ����ö��ȡ��������ԭ����Ҫ�ǣ�ö�ٸ��ϸ�Щ���������ڱ�֤�����߼����Ͻ��ԡ�
 * 
 * �ر�ע�⣡��������������������
 * 1. ��ö�������е�ö���������ȷ�ض���ֵ�����������0��1��2��������������Ȼ�����ĸ�ֵ��ʽ��
 * 2. һ��ϵͳͶ��ʵ�����У��޸�����ö����Ķ��壨����ö��������ƺ�ֵ��ʱҪ�ر��ģ��Է��������ݿ����������ݵı�ʶ�ֶεĺ��塣
 *    ���ܵ�����£���Ҫ�޸ġ�����������ö����Ķ��塣
 */

namespace WxjzgcjczyQyb
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public enum DataState
    {
        ������ = 0,
        ���ϱ� = 1,
        �Ѵ�� = 2,
        ���ͨ�� = 3,
        ����� = 4,
        ������� = 5,
        ��ɾ�� = -1
    }

    /// <summary>
    /// ͳһ����������еĴ�������
    /// </summary>
    public enum CodeType
    {
        �ո���������,
        ģ������,
        ��������,
        ����������ȥ��ʡ,
        ͨѶ¼���,
        ��Ա����,
        ��Աְ��,
        ��������,
        �������ȼ�,
        ����¼����
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
        /// </summary>
        /// �û�����
        /// </summary>
        public UserType UserType;

    }

    /// <summary>
    /// �û�����
    /// </summary>
    public enum UserType
    {
        δ���� = 0,
        //ϵͳ����Ա
        �����û� = 10,
        //�����û�
        ���赥λ = 20,
        //ʩ����ҵ
        ʩ����λ = 30,
    }

    /// <summary>
    /// ҵ��ģ�飬ϵͳ����ģ��
    /// </summary>
    public enum ModuleCode
    {
        /// <summary>
        /// ����Ǽ�
        /// </summary>
        RWDJ = 1,

        /// <summary>
        /// �������
        /// </summary>
        RWFP = 2,

        /// <summary>
        /// �û�����
        /// </summary>
        YHGL = 3,

        /// <summary>
        /// ��ɫ����
        /// </summary>
        JSGL = 4


    }

    public enum BeFrom
    {
        //������Ŀ�Ǽ�Menu
        Zhjg_Lxxmdj_Menu = 0,
        Zhjg_Menu = 1
    }

    public enum OperateCode
    {
        /// <summary>
        /// ���
        /// </summary>
        CREATE = 10,

   
        /// <summary>
        /// �������
        /// </summary>
        FPBM = 20,

    }

}