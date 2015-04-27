﻿using MongoDB.Driver;
using System.Linq;

namespace MongoUtility.Basic
{
    public static class EnumMgr
    {
        /// <summary>
        ///     导出类型
        /// </summary>
        public enum ExportType
        {
            Excel,
            Text,
            Xml
        }

        /// <summary>
        ///     Key String
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetKeyString(IndexKeysDocument keys)
        {
            var KeyString = string.Empty;
            foreach (var key in keys.Elements)
            {
                KeyString += key.Name + ":";
                switch (key.Value.ToString())
                {
                    case "1":
                        KeyString += EnumMgr.IndexType.Ascending.ToString();
                        break;
                    case "-1":
                        KeyString += EnumMgr.IndexType.Descending.ToString();
                        break;
                    case "2d":
                        KeyString += EnumMgr.IndexType.GeoSpatial.ToString();
                        break;
                    case "text":
                        KeyString += EnumMgr.IndexType.Text.ToString();
                        break;
                    default:
                        break;
                }
                KeyString += ";";
            }
            KeyString = "[" + KeyString.TrimEnd(";".ToArray()) + "]";
            return KeyString;
        }


        /// <summary>
        ///     索引类型
        /// </summary>
        public enum IndexType
        {
            /// <summary>
            ///     升序
            /// </summary>
            Ascending,

            /// <summary>
            ///     降序
            /// </summary>
            Descending,

            /// <summary>
            ///     Geo
            /// </summary>
            GeoSpatial,

            /// <summary>
            ///     拉丁语的全文检索(Since mongodb 2.2.4)
            /// </summary>
            Text
        }

        /// <summary>
        ///     路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        public enum PathLv
        {
            /// <summary>
            ///     连接/服务器
            /// </summary>
            ConnectionLv = 0,

            /// <summary>
            ///     具体的实例
            /// </summary>
            InstanceLv = 1,

            /// <summary>
            ///     数据库
            /// </summary>
            DatabaseLv = 2,

            /// <summary>
            ///     数据集
            /// </summary>
            CollectionLv = 3,

            /// <summary>
            ///     数据文档
            /// </summary>
            DocumentLv = 4
        }

        /// <summary>
        ///     存储引擎
        /// </summary>
        public enum StorageEngineType
        {
            /// <summary>
            ///     MMAPv1
            /// </summary>
            MMAPv1,

            /// <summary>
            ///     WiredTiger
            /// </summary>
            WiredTiger
        }

        /// <summary>
        ///     Text Search 时候能指定的语言枚举
        /// </summary>
        public enum TextSearchLanguage
        {
            danish,
            dutch,
            english,
            finnish,
            french,
            german,
            hungarian,
            italian,
            norwegian,
            portuguese,
            romanian,
            russian,
            spanish,
            swedish,
            turkish
        }
    }
}