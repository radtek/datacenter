using System;
using System.IO;
using System.Xml.Serialization;

namespace Bigdesk8
{
    /// <summary>
    /// ���л��ͷ����л�������
    /// </summary>
    public static class SerializationUtility
    {
        /// <summary>
        /// ���л� - ���������л����ļ�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="obj">����</param>
        /// <param name="filename">�ļ�·��</param>
        public static void Save<T>(T obj, string filename) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(fs, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �����л� - ���ļ����л��ɶ���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="filename">�ļ�·��</param>
        /// <returns></returns>
        public static T Load<T>(string filename) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ���л� - ���������л���XML�ַ���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="obj">����</param>
        /// <returns>XML�ַ���</returns>
        public static string Serialize<T>(T obj) where T : class
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(ms, obj);

                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �����л� - ��XML�ַ������л��ɶ���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="objXML">����XML�ַ���</param>
        /// <returns></returns>
        public static T DeSerialize<T>(string objXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(objXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
