﻿/*************************************************************************
 *  Copyright (c) 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SerialPortController.cs
 *  Description  :  Synchronous read and write serialport data.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/5/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.2.0
 *  Date         :  2/13/2018
 *  Description  :  Singleton pattern version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using MGS.Common.Logger;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace MGS.IO.Ports
{
    /// <summary>
    /// Controller of serialport.
    /// </summary>
    public sealed class SerialPortController : Singleton<SerialPortController>
    {
        #region Field and Property
        /// <summary>
        /// Bytes read from serialport.
        /// </summary>
        public byte[] ReadBytes
        {
            get
            {
                lock (readBytes.SyncRoot)
                {
                    return readBytes.Clone() as byte[];
                }
            }
        }

        /// <summary>
        /// Bytes write to serialport.
        /// </summary>
        public byte[] WriteBytes
        {
            set
            {
                lock (writeBytes.SyncRoot)
                {
                    value.CopyTo(writeBytes, 0);
                }
            }
        }

        /// <summary>
        /// SerialPort is open.
        /// </summary>
        public bool IsOpen { get { return serialPort.IsOpen; } }

        /// <summary>
        /// Is reading from serialport.
        /// </summary>
        public bool IsReading { get { return readThread.IsAlive; } }

        /// <summary>
        /// Is writing to serialport.
        /// </summary>
        public bool IsWriting { get { return writeThread.IsAlive; } }

        /// <summary>
        /// Is Timeout reading from serialport.
        /// </summary>
        public bool IsReadTimeout { private set; get; }

        /// <summary>
        /// Is Timeout writing to serialport.
        /// </summary>
        public bool IsWriteTimeout { private set; get; }

        /// <summary>
        /// Target serialport of controller.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Config of serialport.
        /// </summary>
        private SerialPortConfig config;

        /// <summary>
        /// Thread to read bytes from serialport.
        /// </summary>
        private Thread readThread;

        /// <summary>
        /// Thread to write bytes to serialport.
        /// </summary>
        private Thread writeThread;

        /// <summary>
        /// Bytes read from serialport.
        /// </summary>
        private byte[] readBytes;

        /// <summary>
        /// Bytes write to serialport.
        /// </summary>
        private byte[] writeBytes;
        #endregion

        #region Private Method
        /// <summary>
        /// Private constructor.
        /// </summary>
        private SerialPortController()
        {
            InitializeSerialPort();
        }

        /// <summary>
        /// Read bytes from serialport buffer.
        /// </summary>
        private void ReadBytesFromBuffer()
        {
            //Frame bytes length is config.readCount + 2(readHead + readTail).
            var frameLength = config.readCount + 2;
            var frameBuffer = new List<byte>();

            //SerialPort.BytesToRead can not get in Unity.
            //Try to read more bytes of the SerialPort ReadBuffer to avoid delay.
            var readBuffer = new byte[frameLength * 3];
            var readCount = 0;
            var index = 0;
            while (true)
            {
                try
                {
                    //Read bytes from serialport.
                    readCount = serialPort.Read(readBuffer, 0, readBuffer.Length);

                    //Calculate the last index of double frame bytes to avoid delay.
                    //Under normal circumstances, bouble frame bytes affirm contain a intact frame bytes.
                    index = readCount - 2 * frameLength;
                    index = index > 0 ? index : 0;

                    //Add filter bytes to frameBuffer.
                    for (; index < readCount; index++)
                    {
                        frameBuffer.Add(readBuffer[index]);
                    }

                    //Check frameBuffer is enough for frame bytes.
                    while (frameBuffer.Count >= frameLength)
                    {
                        //Find readHead.
                        if (frameBuffer[0] == config.readHead)
                        {
                            //Find readTail, save the intact bytes to readBytes.
                            if (frameBuffer[frameLength - 1] == config.readTail)
                            {
                                readBytes = frameBuffer.GetRange(1, config.readCount).ToArray();
                            }

                            //Remove the obsolete or invalid frame bytes.
                            frameBuffer.RemoveRange(0, frameLength);
                        }
                        else
                        {
                            //Remove the invalid byte.
                            frameBuffer.RemoveAt(0);
                        }
                    }

                    //Clear read timeout flag.
                    IsReadTimeout = false;
                    Thread.Sleep(config.readCycle);
                }
                catch (TimeoutException tEx)
                {
                    LogUtility.Log("Read bytes from serialport buffer exception: {0}", tEx.Message);
                    ClearReadBytes();
                    IsReadTimeout = true;
                    Thread.Sleep(config.readCycle);
                    continue;
                }
                catch (Exception ex)
                {
                    LogUtility.LogError("Read bytes from serialport buffer exception: {0}", ex.Message);
                    readThread.Abort();
                    ClearReadBytes();
                    IsReadTimeout = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Write bytes to serialport buffer.
        /// </summary>
        private void WriteBytesToBuffer()
        {
            //writeBuffer length is config.writeCount + 2(writeHead + writeTail).
            var writeBuffer = new byte[config.writeCount + 2];

            //Add writeHead and writeTail to writeBuffer.
            writeBuffer[0] = config.writeHead;
            writeBuffer[config.writeCount + 1] = config.writeTail;
            while (true)
            {
                //Add writeBytes to writeBuffer.
                writeBytes.CopyTo(writeBuffer, 1);
                try
                {
                    //Write writeBuffer to serialport
                    serialPort.Write(writeBuffer, 0, writeBuffer.Length);
                    IsWriteTimeout = false;
                    Thread.Sleep(config.writeCycle);
                }
                catch (TimeoutException tEx)
                {
                    LogUtility.Log("Write bytes to serialport exception: {0}", tEx.Message);
                    IsWriteTimeout = true;
                    Thread.Sleep(config.writeCycle);
                    continue;
                }
                catch (Exception ex)
                {
                    LogUtility.LogError("Write bytes to serialport buffer exception: {0}", ex.Message);
                    writeThread.Abort();
                    IsWriteTimeout = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Clear the elements of ReadBytes to default value(zero).
        /// </summary>
        private void ClearReadBytes()
        {
            Array.Clear(readBytes, 0, readBytes.Length);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize serialport.
        /// </summary>
        /// <returns>Initialize serialport use config file succeed?</returns>
        public bool InitializeSerialPort()
        {
            //Read config and initialize serialport.
            config = SerialPortConfigurer.Instance.ReadConfig();
            var isReadConfig = true;
            if (config == null)
            {
                isReadConfig = false;
                config = new SerialPortConfig();
                LogUtility.LogWarning("Initialize serialport: Read config is failed, serialport will initialize with default config.");
            }

            serialPort = new SerialPort(config.portName, config.baudRate, config.parity, config.dataBits, config.stopBits)
            {
                ReadBufferSize = config.readBufferSize,
                ReadTimeout = config.readTimeout,
                WriteBufferSize = config.writeBufferSize,
                WriteTimeout = config.writeTimeout
            };

            //Initialize read and write thread.
            readThread = new Thread(ReadBytesFromBuffer) { IsBackground = true };
            writeThread = new Thread(WriteBytesToBuffer) { IsBackground = true };

            //Initialize bytes array.
            readBytes = new byte[config.readCount];
            writeBytes = new byte[config.writeCount];
            return isReadConfig;
        }

        /// <summary>
        /// Open serialport.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to open serialport?</returns>
        public bool OpenSerialPort(out string error)
        {
            error = string.Empty;
            if (IsOpen)
            {
                return true;
            }

            try
            {
                serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Open serialport exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Close serialport.
        /// This method will try abort thread if it is alive.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to close serialport?</returns>
        public bool CloseSerialPort(out string error)
        {
            error = string.Empty;
            if (!IsOpen)
            {
                return true;
            }

            if (IsReading)
            {
                if (!StopRead(out error))
                {
                    return false;
                }
            }

            if (IsWriting)
            {
                if (!StopWrite(out error))
                {
                    return false;
                }
            }

            try
            {
                serialPort.Close();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Close serialport exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Start thread to read.
        /// This method will try to open serialport if it is not open.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to start read thread?</returns>
        public bool StartRead(out string error)
        {
            //SerialPort.ReceivedBytesThreshold is not implemented in Unity.
            //SerialPort.DataReceived event is can not work in Unity.
            //So use thread to read bytes.

            error = string.Empty;
            if (IsReading)
            {
                return true;
            }

            if (!IsOpen)
            {
                if (!OpenSerialPort(out error))
                {
                    return false;
                }
            }

            try
            {
                //SerialPort.DiscardInBuffer can not work in Unity.
                //Do not do it is ok.
                serialPort.DiscardInBuffer();

                //readThread can not start after readThread.Abort().
                //New read thread.
                readThread = new Thread(ReadBytesFromBuffer) { IsBackground = true };
                readThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Start read serialport data exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Stop thread of read.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to stop read thread?</returns>
        public bool StopRead(out string error)
        {
            error = string.Empty;
            if (!IsReading)
            {
                return true;
            }

            try
            {
                readThread.Abort();
                ClearReadBytes();
                IsReadTimeout = false;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Stop read serialport data exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Start thread to write.
        /// This method will try to open serialport if it is not open.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to start write thread?</returns>
        public bool StartWrite(out string error)
        {
            error = string.Empty;
            if (IsWriting)
            {
                return true;
            }

            if (!IsOpen)
            {
                if (!OpenSerialPort(out error))
                {
                    return false;
                }
            }

            try
            {
                //SerialPort.DiscardOutBuffer can not work in Unity.
                //Do not do it is ok.
                serialPort.DiscardOutBuffer();

                //writeThread can not start after writeThread.Abort().
                //New write thread.
                writeThread = new Thread(WriteBytesToBuffer) { IsBackground = true };
                writeThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Start write data to serialport exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Stop thread of write.
        /// </summary>
        /// <param name="error">Error message.</param>
        /// <returns>Is succeed to stop write thread?</returns>
        public bool StopWrite(out string error)
        {
            error = string.Empty;
            if (!IsWriting)
            {
                return true;
            }

            try
            {
                writeThread.Abort();
                IsWriteTimeout = false;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                LogUtility.LogError("Stop write data to serialport exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Clear the elements of WriteBytes to default value(zero).
        /// </summary>
        public void ClearWriteBytes()
        {
            Array.Clear(writeBytes, 0, writeBytes.Length);
        }
        #endregion
    }
}