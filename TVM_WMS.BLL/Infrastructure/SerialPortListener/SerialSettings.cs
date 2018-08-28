using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.ComponentModel;
using System.Reflection;

namespace TVM_WMS.BLL.Infrastructure.SerialPortListener
{
    public class SerialSettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SerialPort _serialPort;
        private string _portName = String.Empty;
        private string[] _portNameCollection;
        private int _baudRate;
        private BindingList<int> _baudRateCollection = new BindingList<int>();
        private Parity _parity;
        private int _dataBits;
        private int[] _dataBitsCollection = new int[] { 5, 6, 7, 8 };
        private StopBits _stopBits;

        #region Properties
        /// <summary>
        /// The port to use (for example, COM1).
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set
            {
                if (!_portName.Equals(value))
                {
                    _portName = value;
                    SendPropertyChangedEvent("PortName");
                }
            }
        }
        
        /// <summary>
        /// The baud rate.
        /// </summary>
        public int BaudRate
        {
            get { return _baudRate; }
            set
            {
                if (_baudRate != value)
                {
                    _baudRate = value;
                    SendPropertyChangedEvent("BaudRate");
                }
            }
        }

        /// <summary>
        /// One of the Parity values.
        /// </summary>
        public Parity Parity
        {
            get { return _parity; }
            set
            {
                if (_parity != value)
                {
                    _parity = value;
                    SendPropertyChangedEvent("Parity");
                }
            }
        }
        
        /// <summary>
        /// The data bits value.
        /// </summary>
        public int DataBits
        {
            get { return _dataBits; }
            set
            {
                if (_dataBits != value)
                {
                    _dataBits = value;
                    SendPropertyChangedEvent("DataBits");
                }
            }
        }
        
        /// <summary>
        /// One of the StopBits values.
        /// </summary>
        public StopBits StopBits
        {
            get { return _stopBits; }
            set
            {
                if (_stopBits != value)
                {
                    _stopBits = value;
                    SendPropertyChangedEvent("StopBits");
                }
            }
        }

        /// <summary>
        /// Available ports on the computer
        /// </summary>
        public string[] PortNameCollection
        {
            get{ return _portNameCollection;}
            set{ _portNameCollection = value; }            
        }

        /// <summary>
        /// Available baud rates for current serial port
        /// </summary>
        public BindingList<int> BaudRateCollection
        {
            get { return _baudRateCollection; }
        }

        /// <summary>
        /// Available databits setting
        /// </summary>
        public int[] DataBitsCollection
        {
            get { return _dataBitsCollection; }
            set { _dataBitsCollection = value; }
        }

        #endregion

        public SerialSettings()
        {
            CreateBaudRateCollection();
            _portNameCollection = SerialPort.GetPortNames();
        }

        #region Methods
             
        public void CreateBaudRateCollection()
        {
            const int BAUD_075 = 0x00000001;
            const int BAUD_110 = 0x00000002;
            const int BAUD_150 = 0x00000008;
            const int BAUD_300 = 0x00000010;
            const int BAUD_600 = 0x00000020;
            const int BAUD_1200 = 0x00000040;
            const int BAUD_1800 = 0x00000080;
            const int BAUD_2400 = 0x00000100;
            const int BAUD_4800 = 0x00000200;
            const int BAUD_7200 = 0x00000400;
            const int BAUD_9600 = 0x00000800;
            const int BAUD_14400 = 0x00001000;
            const int BAUD_19200 = 0x00002000;
            const int BAUD_38400 = 0x00004000;
            const int BAUD_56K = 0x00008000;
            const int BAUD_57600 = 0x00040000;
            const int BAUD_115200 = 0x00020000;
            const int BAUD_128K = 0x00010000;

            _baudRateCollection.Clear();

            _serialPort = new SerialPort(SerialPort.GetPortNames().ToList()[0]);
            _serialPort.Open();
            object p = _serialPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
            Int32 dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

            _serialPort.Close();

            if ((dwSettableBaud & BAUD_075) > 0)
                _baudRateCollection.Add(75);
            if ((dwSettableBaud & BAUD_110) > 0)
                _baudRateCollection.Add(110);
            if ((dwSettableBaud & BAUD_150) > 0)
                _baudRateCollection.Add(150);
            if ((dwSettableBaud & BAUD_300) > 0)
                _baudRateCollection.Add(300);
            if ((dwSettableBaud & BAUD_600) > 0)
                _baudRateCollection.Add(600);
            if ((dwSettableBaud & BAUD_1200) > 0)
                _baudRateCollection.Add(1200);
            if ((dwSettableBaud & BAUD_1800) > 0)
                _baudRateCollection.Add(1800);
            if ((dwSettableBaud & BAUD_2400) > 0)
                _baudRateCollection.Add(2400);
            if ((dwSettableBaud & BAUD_4800) > 0)
                _baudRateCollection.Add(4800);
            if ((dwSettableBaud & BAUD_7200) > 0)
                _baudRateCollection.Add(7200);
            if ((dwSettableBaud & BAUD_9600) > 0)
                _baudRateCollection.Add(9600);
            if ((dwSettableBaud & BAUD_14400) > 0)
                _baudRateCollection.Add(14400);
            if ((dwSettableBaud & BAUD_19200) > 0)
                _baudRateCollection.Add(19200);
            if ((dwSettableBaud & BAUD_38400) > 0)
                _baudRateCollection.Add(38400);
            if ((dwSettableBaud & BAUD_56K) > 0)
                _baudRateCollection.Add(56000);
            if ((dwSettableBaud & BAUD_57600) > 0)
                _baudRateCollection.Add(57600);
            if ((dwSettableBaud & BAUD_115200) > 0)
                _baudRateCollection.Add(115200);
            if ((dwSettableBaud & BAUD_128K) > 0)
                _baudRateCollection.Add(128000);

            SendPropertyChangedEvent("BaudRateCollection");
        }

        /// <summary>
        /// Send a PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of changed property</param>
        private void SendPropertyChangedEvent(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
