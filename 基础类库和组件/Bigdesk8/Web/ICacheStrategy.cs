using System;
using System.Collections.Generic;

namespace Bigdesk8.Web
{
    /// <summary>
    /// ����������Խӿ�
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// ���ָ��ID�Ķ���
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        void AddObject(string objId, object o);

        /// <summary>
        /// ���ָ��ID�Ķ���(����ָ���ļ���)
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="files"></param>
        void AddObjectWithFileChange(string objId, object o, string[] files);

        /// <summary>
        /// ���ָ��ID�Ķ���(����ָ����ֵ��)
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="dependKey"></param>
        void AddObjectWithDepend(string objId, object o, string[] dependKey);

        /// <summary>
        /// �Ƴ�ָ��ID�Ķ���
        /// </summary>
        /// <param name="objId"></param>
        void RemoveObject(string objId);

        /// <summary>
        /// ����ָ��ID�Ķ���
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        object RetrieveObject(string objId);

        /// <summary>
        /// ����ʱ��,��λ���룬��Ϊ0ʱ����ʾ������
        /// </summary>
        int TimeOut { set; get; }

        /// <summary>
        /// ��ȡID�Ͷ������Ŀ
        /// </summary>
        int Count { get; }

        /// <summary>
        /// �Ƴ����е�ID�Ͷ���
        /// </summary>
        void Clear();

        /// <summary>
        /// ��ȡ���е�ID
        /// </summary>
        /// <returns></returns>
        IList<string> GetObjIDs();

        /// <summary>
        /// ��ȡ����ID�Ͷ���
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> GetData();
    }
}
