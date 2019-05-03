/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SerialPortConfig.cs
 *  Description  :  Config of serialport parameters.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/5/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/2/2018
 *  Description  :  Optimize.
 *************************************************************************/

using System;
using System.IO.Ports;

namespace MGS.IO.Ports
{
    /// <summary>
    /// Config of SerialPort.
    /// </summary>
    [Serializable]
    public class SerialPortConfig
    {
        #region Field and Property
        /// <summary>
        /// Port name of serialport.
        /// </summary>
        public string portName = "COM1";

        /// <summary>
        /// Baud rate of serialport.
        /// </summary>
        public int baudRate = 9600;

        /// <summary>
        /// Parity of serialport.
        /// </summary>
        public Parity parity = Parity.None;

        /// <summary>
        /// Data bits of serialport.
        /// </summary>
        public int dataBits = 8;

        /// <summary>
        /// Stop bits of serialport.
        /// </summary>
        public StopBits stopBits = StopBits.One;

        /// <summary>
        /// Read buffer size of serialport.
        /// </summary>
        public int readBufferSize = 1024;

        /// <summary>
        /// Read timeout of serialport.
        /// </summary>
        public int readTimeout = 500;

        /// <summary>
        /// Read head of serialport frame data.
        /// </summary>
        public byte readHead = 254;

        /// <summary>
        /// Read tail of serialport frame data.
        /// </summary>
        public byte readTail = 255;

        /// <summary>
        /// Read count of serialport frame data.
        /// </summary>
        public int readCount = 10;

        /// <summary>
        /// Read cycle of serialport frame data.
        /// </summary>
        public int readCycle = 250;

        /// <summary>
        /// Write buffer size of serialport.
        /// </summary>
        public int writeBufferSize = 1024;

        /// <summary>
        /// Write timeout size of serialport.
        /// </summary>
        public int writeTimeout = 500;

        /// <summary>
        /// Write head of serialport frame data.
        /// </summary>
        public byte writeHead = 254;

        /// <summary>
        /// Write tail of serialport frame data.
        /// </summary>
        public byte writeTail = 255;

        /// <summary>
        /// Write count of serialport frame data.
        /// </summary>
        public int writeCount = 10;

        /// <summary>
        /// Write cycle of serialport frame data.
        /// </summary>
        public int writeCycle = 250;
        #endregion

        #region Public Method
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SerialPortConfig() { }

        /// <summary>
        /// Constructor of SerialPortConfig.
        /// </summary>
        /// <param name="portName">Port name of serialport.</param>
        /// <param name="baudRate">Baud rate of serialport.</param>
        /// <param name="parity">Parity of serialport.</param>
        /// <param name="dataBits">Data bits of serialport.</param>
        /// <param name="stopBits">Stop bits of serialport.</param>
        public SerialPortConfig(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.parity = parity;
            this.dataBits = dataBits;
            this.stopBits = stopBits;
        }
        #endregion
    }
}