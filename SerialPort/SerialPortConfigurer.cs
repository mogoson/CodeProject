/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SerialPortConfigurer.cs
 *  Description  :  Read config from local file and write config to
 *                  local file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  10/3/2017
 *  Description  :  Use JsonUtility to serialize and deserialize config.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.2
 *  Date         :  3/2/2018
 *  Description  :  Optimize.
 *************************************************************************/

using System;
using System.IO;
using UnityEngine;
using MGS.Common.Logger;
using MGS.Common.DesignPattern;
using MGS.Common.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if !UNITY_5_3_OR_NEWER
using LitJson;
#endif

namespace MGS.IO.Ports
{
    /// <summary>
    /// Configurer of SerialPort.
    /// </summary>
    public sealed class SerialPortConfigurer : Singleton<SerialPortConfigurer>
    {
        #region Field and Property
        /// <summary>
        /// Full path of serialport config file.
        /// </summary>
        public string ConfigPath { set; get; }
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private SerialPortConfigurer()
        {
            //Init Config file default path.
            ConfigPath = Application.streamingAssetsPath + "/Config/SerialPortConfig.config";
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Read SerialPortConfig from config file.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Config of serialport.</returns>
        public SerialPortConfig ReadConfig(out string error)
        {
            error = string.Empty;
            try
            {
                var json = File.ReadAllText(ConfigPath);
#if UNITY_5_3_OR_NEWER
                return JsonUtility.FromJson<SerialPortConfig>(json);
#else
                return JsonMapper.ToObject<SerialPortConfig>(json);
#endif
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError(0, "[SerialPortConfigurer] ReadConfig error: {0}.", error);
                return null;
            }
        }

        /// <summary>
        /// Write SerialPortConfig to config file.
        /// </summary>
        /// <param name="config">Config of serialport.</param>
        /// <param name="error">Error message.</param>
        /// <returns>succeed?</returns>
        public bool WriteConfig(SerialPortConfig config, out string error)
        {
            error = string.Empty;
            try
            {
#if UNITY_5_3_OR_NEWER
                var configJson = JsonUtility.ToJson(config);
#else
                var configJson = JsonMapper.ToJson(config);
#endif
                DirectoryUtility.RequirePath(ConfigPath);
                File.WriteAllText(ConfigPath, configJson);
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError(0, "[SerialPortConfigurer] WriteConfig error: {0}.", error);
                return false;
            }
        }
        #endregion
    }
}