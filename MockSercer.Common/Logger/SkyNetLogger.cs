using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Skynet.Logger;

namespace MockServer.Common.Logger
{
    /// <summary>
    /// 新版日志api 接口  debug ，warn error 和 info api 类似
    /// </summary>
    public class SkyNetLogger
    {
        #region  Debug Log
        public static void LogDebug(string message)
        {
            LogService.Debug(message);
        }
        public static void LogDebug(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Debug(message, extraInfo);
        }
        public static void LogDebug(SkyNetMarker marker, string message)
        {
            LogService.Debug(marker.toBaseMarker(), message);
        }
        public static void LogDebug(string message, string filter1, string filter2)
        {
            LogService.Debug(message, filter1, filter2);
        }
        public static void LogDebug(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Debug(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogDebug(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Debug(message, extraInfo, filter1, filter2);
        }
        public static void LogDebug(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Debug(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogDebug(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Debug(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }

        #endregion

        #region Error Log
        public static void LogError(string message)
        {
            LogService.Error(message);
        }
        public static void LogError(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Error(message, extraInfo);
        }
        public static void LogError(string message, Exception ex)
        {
            LogService.Error(message, ex);
        }
        public static void LogError(SkyNetMarker marker, string message)
        {
            LogService.Error(marker.toBaseMarker(), message);
        }
        public static void LogError(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Error(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogError(string message, Exception ex, Dictionary<string, string> extraInfo)
        {
            LogService.Error(message, ex, extraInfo);
        }
        public static void LogError(string message, string filter1, string filter2)
        {
            LogService.Error(message, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, Exception ex)
        {
            LogService.Error(marker.toBaseMarker(), message, ex);
        }
        public static void LogError(string message, Exception ex, string filter1, string filter2)
        {
            LogService.Error(message, ex, filter1, filter2);
        }
        public static void LogError(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Error(message, extraInfo, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Error(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, Exception ex, Dictionary<string, string> extraInfo)
        {
            LogService.Error(marker.toBaseMarker(), message, ex, extraInfo);
        }
        public static void LogError(string message, Exception ex, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Error(message, ex, extraInfo, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Error(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, Exception ex, string filter1, string filter2)
        {
            LogService.Error(marker.toBaseMarker(), message, ex, filter1, filter2);
        }
        public static void LogError(SkyNetMarker marker, string message, Exception ex, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Error(marker.toBaseMarker(), message, ex, extraInfo, filter1, filter2);
        }

        #endregion

        #region Fatal Log
        public static void LogFatal(string message)
        {
            LogService.Fatal(message);
        }
        public static void LogFatal(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Fatal(message, extraInfo);
        }
        public static void LogFatal(SkyNetMarker marker, string message)
        {
            LogService.Fatal(marker.toBaseMarker(), message);
        }
        public static void LogFatal(string message, string filter1, string filter2)
        {
            LogService.Fatal(message, filter1, filter2);
        }
        public static void LogFatal(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Fatal(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogFatal(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Fatal(message, extraInfo, filter1, filter2);
        }
        public static void LogFatal(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Fatal(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogFatal(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Fatal(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }

        #endregion

        #region Info Log
        public static void LogInfo(string message)
        {
            LogService.Info(message);
        }
        public static void LogInfo(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Info(message, extraInfo);
        }
        public static void LogInfo(SkyNetMarker marker, string message)
        {
            LogService.Info(marker.toBaseMarker(), message);
        }
        public static void LogInfo(string message, string filter1, string filter2)
        {
            LogService.Info(message, filter1, filter2);
        }
        public static void LogInfo(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Info(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogInfo(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Info(message, extraInfo, filter1, filter2);
        }
        public static void LogInfo(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Info(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogInfo(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Info(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }
        #endregion

        #region Trace Log

        public static void LogTrace(string message)
        {
            LogService.Trace(message);
        }
        public static void LogTrace(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Trace(message, extraInfo);
        }
        public static void LogTrace(SkyNetMarker marker, string message)
        {
            LogService.Trace(marker.toBaseMarker(), message);
        }
        public static void LogTrace(string message, string filter1, string filter2)
        {
            LogService.Trace(message, filter1, filter2);
        }
        public static void LogTrace(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Trace(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogTrace(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Trace(message, extraInfo, filter1, filter2);
        }
        public static void LogTrace(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Trace(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogTrace(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Trace(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }

        #endregion

        #region Warn Log

        public static void LogWarn(string message)
        {
            LogService.Warn(message);
        }
        public static void LogWarn(string message, Dictionary<string, string> extraInfo)
        {
            LogService.Warn(message, extraInfo);
        }
        public static void LogWarn(SkyNetMarker marker, string message)
        {
            LogService.Warn(marker.toBaseMarker(), message);
        }
        public static void LogWarn(string message, string filter1, string filter2)
        {
            LogService.Warn(message, filter1, filter2);

        }
        public static void LogWarn(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo)
        {
            LogService.Warn(marker.toBaseMarker(), message, extraInfo);
        }
        public static void LogWarn(string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Warn(message, extraInfo, filter1, filter2);
        }
        public static void LogWarn(SkyNetMarker marker, string message, string filter1, string filter2)
        {
            LogService.Warn(marker.toBaseMarker(), message, filter1, filter2);
        }
        public static void LogWarn(SkyNetMarker marker, string message, Dictionary<string, string> extraInfo, string filter1, string filter2)
        {
            LogService.Warn(marker.toBaseMarker(), message, extraInfo, filter1, filter2);
        }
        #endregion
    }

    /// <summary>
    /// SkyNet 模块信息类
    /// </summary>
    public class SkyNetMarker
    {
        private string module = string.Empty;
        private string category = string.Empty;
        private string subCategory = string.Empty;

        public static readonly SkyNetMarker Empty;

        public SkyNetMarker()
        {

        }
        /// <summary>
        /// 实例化日志的模块信息对象
        /// </summary>
        /// <param name="module">模块名</param>
        public SkyNetMarker(string module)
        {
            this.module = module;
        }

        /// <summary>
        /// 实例化日志的模块信息对象
        /// </summary>
        /// <param name="module">模块名</param>
        /// <param name="category">分类</param>
        public SkyNetMarker(string module, string category)
        {
            this.module = module;
            this.category = category;
        }

        /// <summary>
        /// 实例化日志的模块信息对象
        /// </summary>
        /// <param name="module">模块名</param>
        /// <param name="category">分类</param>
        /// <param name="subCategory">子分类</param>
        public SkyNetMarker(string module, string category, string subCategory)
        {
            this.module = module;
            this.category = category;
            this.subCategory = subCategory;
        }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                this.category = value;
            }
        }
        /// <summary>
        /// 模块
        /// </summary>
        public string Module
        {
            get
            {
                return module;
            }
            set
            {
                module = value;
            }

        }

        /// <summary>
        /// 子分类
        /// </summary>
        public string SubCategory
        {
            get
            {
                return subCategory;
            }
            set
            {
                this.subCategory = value;
            }
        }

        public Marker toBaseMarker()
        {
            Marker marker = new Marker(module, category, subCategory);
            return marker;
        }
    }
}
