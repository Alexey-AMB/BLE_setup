using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;

using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

using System.Threading;

using System.Runtime.InteropServices;

using Windows.Devices.Bluetooth.Advertisement;


namespace BLE_setup
{
    public enum DataFormat
    {
        ASCII = 0,
        UTF8,
        Dec,
        Hex,
        Bin,
    }

    //public struct stCommand
    //{
    //    byte signature;  //стартовая сигнатура 223
    //    byte cmd;        //команда из InCommand
    //    Int16 lenbuf;    //длинна буфера с данными
    //    byte crc;
    //}

    public enum OutAsk
    {
        ASK_OK,
        ASK_ERROR,
        ASK_NEXT,
        ASK_MALLOC_ERROR,
        ASK_ERROR_CRC
    }

     public enum InCommandBase
        {
            CMD_NONE,               //test command                          | без буфера
            CMD_GET_SETTINGS,       //пришли настройки на ПК                | без буфера
            CMD_SET_SETTINGS,       //установи настройки                    / структура с настройками базы
            CMD_SET_TIME,           //установи время часов                  / uint32 время в UNIX формате
            CMD_GET_AKKVOLTAGE,     //пришли напряжение на аккумуляторе     | без буфера
            CMD_SET_BLINK,          //помигай лампочками                    | без буфера
            CMD_WRITE_CARD,         //запиши данные на карту
            CMD_READ_CARD,          //считай данные с карты                 | без буфера
            CMD_NEXT,               //пришли следующий блок                 | без буфера
            CMD_MODE_SLEEP,         //переход в сон                         | без буфера
            CMD_MODE_WAIT,          //переход в ожидание                    | без буфера
            CMD_MODE_ACTIVE,        //переход в активный режим              | без буфера
            CMD_WRITE_CARD_NUM,     //записать номер в карточку             / 4 байта номер карточки или мастер-карточки
            CMD_CLEAR_CARD,         //очисти карточку                       | без буфера
            CMD_SET_TIMES_RUN,      //установи время начала и конца забега  / два uint32 начало и конец соревнований
            CMD_GET_VERSION         //Версия софта int32
        }

        public enum WORKMODE_BASE : byte
        {
            MODE_ACTIVE,
            MODE_WAIT,
            MODE_SLEEP
        }

        public enum WORKTYPE : byte
        {
            TYPE_START,
            TYPE_BASE_MAIN,
            TYPE_FINISH,
            TYPE_CLEAR,
            TYPE_CHECK,
            TYPE_READCARD
        }

    public enum WORKMODE_TAG : byte
    {
        MODE_CONNECT,
        MODE_RUN,
        MODE_SLEEP
    }

    public enum InCommandTag
    {
        CMD_NONE,               //test command
        CMD_GET_SETTINGS,       //пришли настройки на ПК
        CMD_SET_SETTINGS,       //установи настройки
        CMD_SET_TIME,           //установи время часов
        CMD_GET_AKKVOLTAGE,     //пришли напряжение на аккумуляторе
        CMD_SET_BLINK,          //помигай лампочками
        //CMD_WRITE_DATA,         //запиши данные
        CMD_READ_DATA,          //считай данные в буфере номер блока от 2 до 15
        CMD_SET_MODE_RUN,
        CMD_SET_MODE_CONN,
        CMD_SET_MODE_SLEEP,
        CMD_NEXT,
        CMD_GET_VERSION
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SPORT_BASE_SETTINGS
    {
        public WORKMODE_BASE mode_station;       //режим работы
        public WORKTYPE type_station;       //тип станции
        public byte num_station;        //номер станции
        public UInt32 timeut_station;     //время через которое станция уснет в сек.
        public byte powerble_station;   //мощность BLE передатчика станции от 0 (-21 дБ) до 12 (+5 дБ) см ll.h строка 404
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] password_station;  //пароль BLE
        public byte gain_KM;            //усиление антенны контактных меток
        public UInt32 timer_KM;           //период поиска приложенных контактных меток в МС
        public byte settins_KM;         //мелкие настройки задачи контактных меток
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] ar_secure_key;   //ключи шифрования для карточек
        public byte signature;          //сигнатура SIGNATURE_EPROM_SETTINGS
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SPORT_TAG_SETTINGS   //len=42
    {
        public WORKMODE_TAG mode_tag;           //режим работы
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] name_tag;       //имя метки
        public Int32 timeut_conn;        //время через которое метка уснет в сек. в режиме соединения
                                       //int         timeut_run;         //время через которое метка уснет в сек. в режиме забега
        public byte powerble_tag;       //мощность BLE передатчика метки от 0 (-21 дБ) до 12 (+5 дБ) см ll.h строка 404
        public sbyte treshold_tag;       //порог чувствительности метки  -40=30cm, -60=200cm, 100=6m
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] password_tag;   //пароль BLE

        //USER_SETTINGS        //len=103
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] fam;        //фамилия
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] imj;        //имя
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] otch;       //отчество
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] group;       //группа
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] razr;        //разряд
        public UInt16 godrojd;        //год рождения
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] colectiv;   //название коллектива
        public byte zabeg;          //номер забега
        public UInt16 startnum;       //стартовый номер
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] starttime;   //время старта
        public byte lgota;          //есть ли льгота
        public byte arenda;         //свой чип или арендованный
        public byte signature;      //сигнатура SIGNATURE_EPROM_SETTINGS
    }

    public enum MyTypeBleDevice
    {
        UNKNOW,
        BASE,
        TAG
    }

    public struct stMyBleDevice
    {
        public string sBleId;
        public string sName;
        public string sBleMacAddr;
        public MyTypeBleDevice type;
        public ulong uBleAddr;
    }

    public struct stCommand
    {
        public byte signature;  //стартовая сигнатура 223
        public byte cmd;        //команда из InCommand
        public UInt16 lenbuf;    //длинна буфера с данными
        public byte crc;
    }

    public class BLE_com
    {
        public bool bUpdateList = false;
        public object oLock = new object();
        public const int SizeStCommand = 5;

        //private int iCurrCommand = 0;
        //private bool bIsOK = false;
        private int iExpectedLen = 0;
        private int iCurrCmd = 0;
        private int iExpectedCrc = 0;
        private int iRecivedLen = 0;
        private int iSendedLen = 0;
        private byte[] pBuffIn = null;
        private int iBuffInLen = 0;
        public byte[] pBuffOut = null;
        public UInt16 iBuffOutLen = 0;
        public byte cCmdNext = 8;

        //==================================================================
        public delegate void HaveBuff(byte[] buff);
        public event HaveBuff BuffChaged;
        
        public BLE_com()
        {
           
        }
        //==================================================================
        public ObservableCollection<BluetoothLEDeviceDisplay> KnownDevices = new ObservableCollection<BluetoothLEDeviceDisplay>();

        private List<DeviceInformation> UnknownDevices = new List<DeviceInformation>();

        public DeviceWatcher deviceWatcher;

        public void StartBleDeviceWatcher()
        {
            // Additional properties we would like about the device.
            // Property strings are documented here https://msdn.microsoft.com/en-us/library/windows/desktop/ff521659(v=vs.85).aspx
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", /*"System.Devices.Aep.IsConnected",*/ "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher =
                    DeviceInformation.CreateWatcher(
                        aqsAllBluetoothLEDevices,
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start over with an empty collection.
            lock (oLock) KnownDevices.Clear();

            // Start the watcher. Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
        }

        public void StopBleDeviceWatcher()
        {
            if (deviceWatcher != null)
            {
                // Unregister the event handlers.
                deviceWatcher.Added -= DeviceWatcher_Added;
                deviceWatcher.Updated -= DeviceWatcher_Updated;
                deviceWatcher.Removed -= DeviceWatcher_Removed;
                deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped -= DeviceWatcher_Stopped;

                // Stop the watcher.
                if (deviceWatcher.Status == DeviceWatcherStatus.Started)
                    deviceWatcher.Stop();
                deviceWatcher = null;
            }

            UpdateList();
        }

        private BluetoothLEDeviceDisplay FindBluetoothLEDeviceDisplay(string id)
        {
            foreach (BluetoothLEDeviceDisplay bleDeviceDisplay in KnownDevices)
            {
                if (bleDeviceDisplay.Id == id)
                {
                    return bleDeviceDisplay;
                }
            }
            return null;
        }

        private DeviceInformation FindUnknownDevices(string id)
        {
            foreach (DeviceInformation bleDeviceInfo in UnknownDevices)
            {
                if (bleDeviceInfo.Id == id)
                {
                    return bleDeviceInfo;
                }
            }
            return null;
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Task.Run(() =>
            {
                lock (oLock)
                {
                    //Debug.WriteLine(String.Format("Added {0}{1}", deviceInfo.Id, deviceInfo.Name));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Make sure device isn't already present in the list.
                        if (FindBluetoothLEDeviceDisplay(deviceInfo.Id) == null)
                        {
                            if (deviceInfo.Name != string.Empty)
                            {
                                // If device has a friendly name display it immediately.
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                                UpdateList();
                            }
                            else
                            {
                                // Add it to a list in case the name gets updated later. 
                                UnknownDevices.Add(deviceInfo);
                            }
                        }

                    }
                }
            });
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Task.Run(() =>
            {
                lock (oLock)
                {
                    //Debug.WriteLine(String.Format("Updated {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            // Device is already being displayed - update UX.
                            bleDeviceDisplay.Update(deviceInfoUpdate);
                            return;
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            deviceInfo.Update(deviceInfoUpdate);
                            // If device has been updated with a friendly name it's no longer unknown.
                            if (deviceInfo.Name != String.Empty)
                            {
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                                UnknownDevices.Remove(deviceInfo);
                            }
                        }
                    }
                    UpdateList();
                }
            });
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Task.Run(() =>
            {
                lock (oLock)
                {
                    //Debug.WriteLine(String.Format("Removed {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Find the corresponding DeviceInformation in the collection and remove it.
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            KnownDevices.Remove(bleDeviceDisplay);
                            UpdateList();
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            UnknownDevices.Remove(deviceInfo);
                        }
                    }
                    //UpdateList();
                }
            });
        }

        private async void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Task.Run(() =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    //synchronizationContext.Post(new SendOrPostCallback(o =>
                    //{
                    //    this.label1.Text = "Complete";

                    //}), null);

                    lock (oLock) UpdateList();

                    //deviceWatcher.Stop();
                }
            });
        }

        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Task.Run(() =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    lock (oLock) UpdateList();
                }
            });
        }

        private void UpdateList()
        {
            //synchronizationContext.Post(new SendOrPostCallback(o =>
            //{
            //    this.listBox1.Items.Clear();
            //}), null);            

            bUpdateList = true;
        }

        //==================================================================

        private BluetoothLEDevice _selectedDevice = null;

        private List<BluetoothLEAttributeDisplay> _services = new List<BluetoothLEAttributeDisplay>();
        private BluetoothLEAttributeDisplay _selectedService = null;

        private List<BluetoothLEAttributeDisplay> _characteristics = new List<BluetoothLEAttributeDisplay>();
        //static BluetoothLEAttributeDisplay _selectedCharacteristic = null;

        private List<GattCharacteristic> _subscribers = new List<GattCharacteristic>();
        private TimeSpan _timeout = TimeSpan.FromSeconds(3);

        private async Task<int> OpenDevice(string deviceName)
        {
            int retVal = 0;
            if (!string.IsNullOrEmpty(deviceName))
            {
                string foundId = deviceName;    // Utilities.GetIdByNameOrNumber(devs, deviceName);

                // If device is found, connect to device and enumerate all services
                if (!string.IsNullOrEmpty(foundId))
                {
                    //_selectedCharacteristic = null;
                    _selectedService = null;
                    _services.Clear();

                    try
                    {
                        // only allow for one connection to be open at a time
                        if (_selectedDevice != null) CloseDevice();

                        _selectedDevice = await BluetoothLEDevice.FromIdAsync(foundId).AsTask().TimeoutAfter(_timeout);

                        var result = await _selectedDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);
                        if (result.Status == GattCommunicationStatus.Success)
                        {
                            for (int i = 0; i < result.Services.Count; i++)
                            {
                                var serviceToDisplay = new BluetoothLEAttributeDisplay(result.Services[i]);
                                _services.Add(serviceToDisplay);
                            }
                        }
                        else
                        {
                            retVal += 1;
                        }
                    }
                    catch
                    {
                        retVal += 1;
                    }
                }
                else
                {
                    retVal += 1;
                }
            }
            else
            {
                retVal += 1;
            }
            return retVal;
        }

        private void CloseDevice()
        {
            // Remove all subscriptions
            if (_subscribers.Count > 0) Unsubscribe();

            if (_selectedDevice != null)
            {
                _services?.ForEach((s) => { s.service?.Dispose(); });
                _services?.Clear();
                _characteristics?.Clear();
                _selectedDevice?.Dispose();
            }
            _selectedDevice = null;
        }

        private async void Unsubscribe()
        {
            foreach (var sub in _subscribers)
            {
                try
                {
                    await sub.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                    sub.ValueChanged -= Characteristic_ValueChanged;
                }
                catch { }
            }
            _subscribers.Clear();
        }

        private async void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var newValue = FormatValue(args.CharacteristicValue, DataFormat.Hex);

            //synchronizationContext.Post(new SendOrPostCallback(o =>
            //{
            //    this.label1.Text = /*"Value changed for " + sender.Uuid + ": " + */ newValue;

            //}), null);

            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out byte[] data);
             GetBuffer(data);
        }

        async Task<int> SetService(string serviceName)
        {
            int retVal = 0;
            if (_selectedDevice != null)
            {
                if (!string.IsNullOrEmpty(serviceName))
                {
                    string foundName = serviceName;
                    // If device is found, connect to device and enumerate all services
                    if (!string.IsNullOrEmpty(foundName))
                    {
                        var attr = _services.FirstOrDefault(s => s.Name.Equals(foundName));
                        IReadOnlyList<GattCharacteristic> characteristics = new List<GattCharacteristic>();

                        try
                        {
                            // Ensure we have access to the device.
                            var accessStatus = await attr.service.RequestAccessAsync();
                            if (accessStatus == DeviceAccessStatus.Allowed)
                            {
                                // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                                // and the new Async functions to get the characteristics of unpaired devices as well. 
                                var result = await attr.service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                                if (result.Status == GattCommunicationStatus.Success)
                                {
                                    characteristics = result.Characteristics;
                                    _selectedService = attr;
                                    _characteristics.Clear();

                                    if (characteristics.Count > 0)
                                    {
                                        for (int i = 0; i < characteristics.Count; i++)
                                        {
                                            var charToDisplay = new BluetoothLEAttributeDisplay(characteristics[i]);
                                            _characteristics.Add(charToDisplay);
                                        }
                                    }
                                    else
                                    {
                                        retVal += 1;
                                    }
                                }
                                else
                                {
                                    retVal += 1;
                                }
                            }
                            // Not granted access
                            else
                            {
                                retVal += 1;
                            }
                        }
                        catch //(Exception ex)
                        {
                            retVal += 1;
                        }
                    }
                    else
                    {
                        retVal += 1;
                    }
                }
                else
                {
                    retVal += 1;
                }
            }
            else
            {
                retVal += 1;
            }

            return retVal;
        }

        async Task<int> WriteCharacteristic(string param, int iCa)
        {
            int retVal = 0;
            if (_selectedDevice != null)
            {
                if (!string.IsNullOrEmpty(param))
                {
                    if (_characteristics.Count < iCa) return 1;
                    var attr = _characteristics[iCa];

                    var buffer = FormatData(param, DataFormat.Hex);

                    if (attr != null && attr.characteristic != null)
                    {
                        // Write data to characteristic
                        GattWriteResult result = await attr.characteristic.WriteValueWithResultAsync(buffer);
                        if (result.Status != GattCommunicationStatus.Success)
                        {
                            retVal += 1;
                        }
                    }
                    else
                    {
                        retVal += 1;
                    }

                }
            }
            else
            {
                retVal += 1;
            }
            return retVal;
        }

        async Task<int> WriteCharacteristic(IBuffer buffer, int iCa)
        {
            int retVal = 0;
            if (_selectedDevice != null)
            {
                if (_characteristics.Count < iCa) return 1;
                var attr = _characteristics[iCa];

                if (attr != null && attr.characteristic != null)
                {
                    // Write data to characteristic
                    GattWriteResult result = await attr.characteristic.WriteValueWithResultAsync(buffer);
                    if (result.Status != GattCommunicationStatus.Success)
                    {
                        retVal += 1;
                    }
                }
                else
                {
                    retVal += 1;
                }
            }
            else
            {
                retVal += 1;
            }
            return retVal;
        }

        async Task<int> SubscribeToCharacteristic(int iCa)
        {
            int retVal = 0;

            var attr = _characteristics[iCa];
            if (attr != null && attr.characteristic != null)
            {
                // First, check for existing subscription
                if (!_subscribers.Contains(attr.characteristic))
                {
                    var status = await attr.characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                    if (status == GattCommunicationStatus.Success)
                    {
                        _subscribers.Add(attr.characteristic);
                        attr.characteristic.ValueChanged += Characteristic_ValueChanged;
                    }
                    else
                    {
                        retVal += 1;
                    }
                }
                else
                {
                    retVal += 1;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Format data for writing by specific format
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static IBuffer FormatData(string data, DataFormat format)
        {
            try
            {
                // For text formats, use CryptographicBuffer
                if (format == DataFormat.ASCII || format == DataFormat.UTF8)
                {
                    return CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);
                }
                else
                {
                    string[] values = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    byte[] bytes = new byte[values.Length];

                    for (int i = 0; i < values.Length; i++)
                        bytes[i] = Convert.ToByte(values[i], (format == DataFormat.Dec ? 10 : (format == DataFormat.Hex ? 16 : 2)));

                    var writer = new DataWriter();
                    writer.ByteOrder = ByteOrder.LittleEndian;
                    writer.WriteBytes(bytes);

                    return writer.DetachBuffer();
                }
            }
            catch //(Exception error)
            {
                return null;
            }
        }

        /// <summary>
        /// This function converts IBuffer data to string by specified format
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string FormatValue(IBuffer buffer, DataFormat format)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(buffer, out data);

            switch (format)
            {
                case DataFormat.ASCII:
                    return Encoding.ASCII.GetString(data);

                case DataFormat.UTF8:
                    return Encoding.UTF8.GetString(data);

                case DataFormat.Dec:
                    return string.Join(" ", data.Select(b => b.ToString("00")));

                case DataFormat.Hex:
                    return BitConverter.ToString(data).Replace("-", " ");

                case DataFormat.Bin:
                    var s = string.Empty;
                    foreach (var b in data) s += Convert.ToString(b, 2).PadLeft(8, '0') + " ";
                    return s;

                default:
                    return Encoding.ASCII.GetString(data);
            }
        }

        //==================================================================

        private void GetBuffer(byte[] buf)
        {
            if ((iRecivedLen == 0) && (iExpectedLen == 0))
            {        //не принят еще не один блок
                if (buf[0] == 223)
                {
                    //if (buf[1] == 0) bIsOK = true;
                    //else bIsOK = false;

                    iExpectedLen = (buf[3] << 8) + buf[2];
                    iCurrCmd = buf[1];
                    iExpectedCrc = buf[4];

                    if (iExpectedLen == 0)
                    {
                        ExecuteCommand(false);
                        return;
                    }
                    else
                    {
                        pBuffIn = new byte[iExpectedLen];
                        iBuffInLen = iExpectedLen;
                        if (iExpectedLen <= (buf.Length - SizeStCommand))
                        {
                            Array.Copy(buf, SizeStCommand, pBuffIn, 0, iExpectedLen);
                            if (GetCRC8(pBuffIn, (UInt16)iExpectedLen) == iExpectedCrc)
                            {
                                ExecuteCommand(true);
                                return;
                            }
                            else
                            { //сообщить об ошибке
                                //SendCommand(OutAsk.ASK_ERROR_CRC, false);
                                iExpectedLen = 0;
                                iCurrCmd = 0;
                                iExpectedCrc = 0;
                                return;
                            }
                        }
                        else
                        { //если данные не влезли в один буфер
                            Array.Copy(buf, SizeStCommand, pBuffIn, 0, buf.Length - SizeStCommand);
                            iRecivedLen = buf.Length - SizeStCommand;
                             SendCommand(cCmdNext, false);
                            return;
                        }
                    }
                }
                else
                {   //не сошлась сигнатура
                    //SendCommand(OutAsk.ASK_ERROR, false);
                    iExpectedLen = 0;
                    iCurrCmd = 0;
                    iExpectedCrc = 0;
                }
            }

            if (iExpectedLen > iRecivedLen)
            {
                if (iExpectedLen - iRecivedLen > buf.Length)
                {
                    Array.Copy(buf, 0, pBuffIn, iRecivedLen, buf.Length);
                    iRecivedLen += buf.Length;
                     SendCommand(cCmdNext, false);
                    return;
                }
                else
                {
                    Array.Copy(buf, 0, pBuffIn, iRecivedLen, iExpectedLen - iRecivedLen);
                    if (GetCRC8(pBuffIn, (UInt16)iExpectedLen) == iExpectedCrc)
                    {
                        ExecuteCommand(true);
                        return;
                    }
                    else
                    { //сообщить об ошибке
                        //SendCommand(OutAsk.ASK_ERROR_CRC, false);
                        iExpectedLen = 0;
                        iCurrCmd = 0;
                        iExpectedCrc = 0;
                        return;
                    }
                }
            }
            else
            {   //странная ситуация, но такое было
                iRecivedLen = 0;
                iExpectedLen = 0;
                iSendedLen = 0;

                pBuffIn = null;
            }
        }

        private byte GetCRC8(byte[] buf, UInt16 len)
        {
            byte crc = 0;
            for (int i = 0; i < len; i++)
            {
                crc += (byte) buf[i];
            }

            return (byte)crc;
        }

        public  const byte SIGNATURE_COMMAND = 223;
        private const byte MYDATATRANSFER_MYBUFIN1_LEN = 23;

        public /*async Task*/ void SendCommand(byte cmd, bool bHaveBuf)
        {
            stCommand cmdOut;
            byte[] buf = null;
            byte len = 0;

            if (iSendedLen == 0)
            {
                cmdOut.cmd = (byte)cmd;
                cmdOut.signature = SIGNATURE_COMMAND;
                cmdOut.lenbuf = 0;
                cmdOut.crc = 0;
                if ((bHaveBuf) && (pBuffOut != null))
                {
                    cmdOut.lenbuf = iBuffOutLen;
                    cmdOut.crc = (byte)GetCRC8(pBuffOut, iBuffOutLen);
                }

                if ((cmdOut.lenbuf + SizeStCommand) > MYDATATRANSFER_MYBUFIN1_LEN)
                {   // все не влезет в один буфер
                    len = MYDATATRANSFER_MYBUFIN1_LEN;
                    iSendedLen = len - SizeStCommand;
                }
                else
                {   // влезет в один буфер
                    len = (byte)(cmdOut.lenbuf + SizeStCommand);
                    iSendedLen = 0;
                }

                buf = new byte[len];
                                                
                Array.Copy(GetBytes(cmdOut), buf, SizeStCommand);
                if ((bHaveBuf) && (pBuffOut != null)) Array.Copy(pBuffOut, 0, buf, SizeStCommand, len - SizeStCommand);
                 WriteToBle(buf);
                buf = null;
                if ((iSendedLen == 0) && (bHaveBuf)) //передача закончена
                {
                    pBuffOut = null;
                }
            }
            else
            {
                if ((iBuffOutLen - iSendedLen) > MYDATATRANSFER_MYBUFIN1_LEN)
                {   // все не влезет в один буфер
                    len = MYDATATRANSFER_MYBUFIN1_LEN;
                    //iSendedLen += len;
                }
                else
                {   // влезет в один буфер
                    len = (byte)(iBuffOutLen - iSendedLen);
                    //iSendedLen = 0;
                }

                buf = new byte[len];

                if ((bHaveBuf) && (pBuffOut != null)) Array.Copy(pBuffOut, iSendedLen, buf, 0, len);
                 WriteToBle(buf);
                
                iSendedLen += len;
                if (iSendedLen == iBuffOutLen) //передача закончена
                {                    
                    pBuffOut = null;
                    iSendedLen = 0;
                }
            }
            
        }

        private async void ExecuteCommand(bool bHaveBuf)
        {
            switch (iCurrCmd)
            {
                case ((int)OutAsk.ASK_NEXT):
                     SendCommand((byte)InCommandBase.CMD_NONE, true);
                    return;
                    //break;
                case ((int)OutAsk.ASK_OK):
                    if(BuffChaged != null) BuffChaged(pBuffIn);
                    break;
            }

            iExpectedLen = 0;
            iCurrCmd = 0;
            iExpectedCrc = 0;
            iRecivedLen = 0;

            pBuffIn = null;
            iBuffInLen = 0;
        }

        public byte[] GetBytes(SPORT_BASE_SETTINGS str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public byte[] GetBytes(stCommand str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public byte[] GetBytes(SPORT_TAG_SETTINGS str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public async Task WriteToBleOneShot(string sSelID, byte[] bytes)
        {
            string sSelServ = "Custom Service: f000ba33-0451-4000-b000-000000000000";
            var writer = new DataWriter();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteBytes(bytes);

            try
            {
                await OpenDevice(sSelID);

                await SetService(sSelServ);

                await SubscribeToCharacteristic(0);

                await WriteCharacteristic(writer.DetachBuffer(), 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения. " + ex.Message);
            }
            finally
            {
                CloseDevice();
            }
        }

        public async Task<bool> OpenBle(string sSelID, MyTypeBleDevice type)
        {
            string sSelServ = null;
            if (type == MyTypeBleDevice.BASE) sSelServ = "Custom Service: f000ba33-0451-4000-b000-000000000000";
            if (type == MyTypeBleDevice.TAG) sSelServ = "Custom Service: f000ba43-0451-4000-b000-000000000000";
            bool bRet = true;
            try
            {
                await OpenDevice(sSelID);

                await SetService(sSelServ);

                await SubscribeToCharacteristic(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения. " + ex.Message);
                CloseDevice();
                bRet = false;
            }
            finally
            {

            }
            return bRet;
        }


        private async Task WriteToBle(byte[] bytes)
        {
            var writer = new DataWriter();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteBytes(bytes);

            try
            {
                await WriteCharacteristic(writer.DetachBuffer(), 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи. " + ex.Message);
            }
            finally
            {

            }
        }

        public void CloseBle()
        {
            CloseDevice();
        }


        BluetoothLEAdvertisementWatcher _watcher = null;

        public void StartDiscoveryAdv()
        {
            _watcher = new BluetoothLEAdvertisementWatcher();
            _watcher.ScanningMode = BluetoothLEScanningMode.Active;
            _watcher.SignalStrengthFilter = new BluetoothSignalStrengthFilter
            {
                InRangeThresholdInDBm = -75,
                OutOfRangeThresholdInDBm = -76,
                OutOfRangeTimeout = TimeSpan.FromSeconds(2),
                SamplingInterval = TimeSpan.FromSeconds(2)
            };

            _watcher.AdvertisementFilter =
                 new BluetoothLEAdvertisementFilter
                 {
                     Advertisement =
                              new BluetoothLEAdvertisement
                              {
                                  ServiceUuids =
                                            { 
                                                //new Guid("0000ba33-0000-1000-8000-00805f9b34fb")
                                            }
                              }
                 };

            //my

            _watcher.AdvertisementFilter.Advertisement.ServiceUuids.Clear();
            //_watcher.AdvertisementFilter.Advertisement.ServiceUuids.Add(new Guid("0000ba33-0000-1000-8000-00805f9b34fb"));
            //_watcher.AdvertisementFilter.Advertisement.ServiceUuids.Add(new Guid("0000ba43-0000-1000-8000-00805f9b34fb"));


            //_watcher.AdvertisementFilter.Advertisement.ServiceUuids.forEach(uuid => {
            //    var uuidString = // format uuid as GUID string
            //    this._advertisementWatcher.advertisementFilter.advertisement.serviceUuids.add(uuidString);
            //});

            _watcher.Received += _watcher_Received;
            _watcher.Stopped += _watcher_Stopped;
            _watcher.Start();
        }

        public void StopDiscoveryAdv()
        {

            _watcher.Stop();

            Thread.Sleep(1000);
            //while (_watcher.Status != BluetoothLEAdvertisementWatcherStatus.Stopped) Thread.Sleep(1);
            _watcher.Received -= _watcher_Received;
            _watcher.Stopped -= _watcher_Stopped;
            _watcher = null;
        }

        public ConcurrentDictionary<string, stMyBleDevice> BleList = new ConcurrentDictionary<string, stMyBleDevice>();
        public bool bBaseFound = true;
        public bool bTagFound = true;

       

        private async void _watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            bool bIsBase = false;
            bool bIsTag = false;
            BluetoothLEDevice device = null;

            try
            {
                device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                if (device == null) return;

                foreach (var s in args.Advertisement.ServiceUuids)
                {
                    if (s.ToString() == "0000ba33-0000-1000-8000-00805f9b34fb") bIsBase = true;
                    if (s.ToString() == "0000ba43-0000-1000-8000-00805f9b34fb") bIsTag = true;
                }
                 
                if ((bIsBase && bBaseFound) || (bIsTag && bTagFound))
                {
                    lock (oLock)
                    {
                        if (!BleList.ContainsKey(device.DeviceId))
                        {
                            stMyBleDevice mbd = new stMyBleDevice();
                            mbd.sName = device.Name;
                            mbd.sBleMacAddr = device.BluetoothAddress.ToString("X12");
                            mbd.sBleId = device.DeviceId;
                            mbd.uBleAddr = device.BluetoothAddress;
                            if (bIsBase) mbd.type = MyTypeBleDevice.BASE;
                            if (bIsTag) mbd.type = MyTypeBleDevice.TAG;
                            BleList.GetOrAdd(device.DeviceId, mbd);
                            bUpdateList = true;
                        }
                    }
                }
                
            }
            catch { }

            finally
            {
                if (device != null) device.Dispose();
            }
            device = null;
        }

        private void _watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            string errorMsg = null;
            if (args != null)
            {
                switch (args.Error)
                {
                    case BluetoothError.Success:
                        //errorMsg = "WatchingSuccessfullyStopped";
                        break;
                    case BluetoothError.RadioNotAvailable:
                        errorMsg = "ErrorNoRadioAvailable";
                        break;
                    case BluetoothError.ResourceInUse:
                        errorMsg = "ErrorResourceInUse";
                        break;
                    case BluetoothError.DeviceNotConnected:
                        errorMsg = "ErrorDeviceNotConnected";
                        break;
                    case BluetoothError.DisabledByPolicy:
                        errorMsg = "ErrorDisabledByPolicy";
                        break;
                    case BluetoothError.NotSupported:
                        errorMsg = "ErrorNotSupported";
                        break;
                }
            }
            if (errorMsg != null)
            {

            }

        }

        public  void wble(string sId)
        {
            //var device = await BluetoothLEDevice.FromIdAsync(sId);
            ////Debug.WriteLine($"BLEWATCHER Found: {device.name}");

            //// SERVICES!!
            //GattDeviceServicesResult gatt = await device.GetGattServicesAsync();
            ////Debug.WriteLine($"{device.Name} Services: {gatt.Services.Count}, {gatt.Status}, {gatt.ProtocolError}");

            //// CHARACTERISTICS!!
            //GattCharacteristicsResult characs = await gatt.Services.Single(s => s.Uuid == new Guid("f000ba33-0451-4000-b000-000000000000")).GetCharacteristicsAsync();
            //var charac = characs.Characteristics.Single(c => c.Uuid == new Guid("f000ba35-0451-4000-b000-000000000000"));

            //byte[] data = new byte[5];
            //data[0] = 223;
            //data[1] = (byte)InCommandBase.CMD_GET_AKKVOLTAGE;

            //var writer = new DataWriter();
            //writer.ByteOrder = ByteOrder.LittleEndian;
            //writer.WriteBytes(data);

            //await charac.WriteValueAsync(writer.DetachBuffer());

            //writer.Dispose();

            ////foreach (var ser in characs.Characteristics) ser?.Service?.Dispose();

            //foreach (var ser in gatt.Services) ser?.Dispose();


            ////    .Characteristics?.ForEach((s) => { s.service?.Dispose(); });
            //device.Dispose();
            //device = null;
        }


    }
}
