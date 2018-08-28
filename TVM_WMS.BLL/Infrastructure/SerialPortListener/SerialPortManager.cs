using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Reflection;
using System.ComponentModel;
using System.Threading;
using System.IO;
using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.Infrastructure.SerialPortListener
{
    public class SerialPortManager : IDisposable
    {
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;
        
        private ConfigClass.BarcodeSettingSource _settings;
        private SerialPort _serialPort;

        public SerialPortManager(ConfigClass.BarcodeSettingSource settings)
        {
            _settings = settings;
        }
        
        ~SerialPortManager()
        {
            Dispose(false);
        }
        
        #region Event handlers
               
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _serialPort.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = _serialPort.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;

            // Send data to whom ever interested
            if (NewSerialDataRecieved != null)
                NewSerialDataRecieved(this, new SerialDataEventArgs(data));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public void StartListening()
        {
            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
            
            // Setting serial port settings
            _serialPort = new SerialPort(
                _settings.PortName,//"COM3"
                _settings.BaudRate,//9600
                _settings.Parity,//Parity.None
                _settings.DataBits,//1
                _settings.StopBits);//0

            // Subscribe to event and open serial port for data
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.Open();
        }

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            if (_serialPort != null)
                _serialPort.Close();
        }


        ///// <summary>
        ///// Retrieves the current selected device's COMMPROP structure, and extracts the dwSettableBaud property
        ///// </summary>
        //private void UpdateBaudRateCollection()
        //{
        //    _serialPort = new SerialPort(_currentSerialSettings.PortName);
        //    _serialPort.Open();
        //    object p = _serialPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
        //    Int32 dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

        //    _serialPort.Close();
        //    _currentSerialSettings.UpdateBaudRateCollection(dwSettableBaud);
        //}

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }

        #endregion

    }

    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public byte[] Data;
    }
}
