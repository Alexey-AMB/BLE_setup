using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;



namespace BLE_setup
{
    public partial class Form_DeviceBase : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        private int iCurrCommand = -1;
        
        private string sSelBleId = null;

        private void EnableButtons(bool bEn)
        {
            this.button1.Enabled = bEn;
            
            this.button4.Enabled = bEn;

        }

        private void Bc_BuffChanged(byte[] pBuffIn)
        {
            if (pBuffIn == null) return;

            switch (iCurrCommand)
            {
                case (int)InCommandBase.CMD_GET_SETTINGS:
                    GCHandle handle = GCHandle.Alloc(pBuffIn, GCHandleType.Pinned);
                    SPORT_BASE_SETTINGS sbs = (SPORT_BASE_SETTINGS)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SPORT_BASE_SETTINGS));
                    handle.Free();

                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        ShowBaseSettings(sbs);
                    }), null);

                    break;
                case (int)InCommandBase.CMD_GET_AKKVOLTAGE:
                    int iV = BitConverter.ToInt32(pBuffIn, 0);                    
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        this.labelAkkVoltage.Text = "Напряжение: " + ((float)iV / 1000000).ToString("F2") + " В.";
                    }), null);
                    break;
                case (int)InCommandBase.CMD_GET_VERSION:
                    int iVer = BitConverter.ToInt32(pBuffIn, 0);
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        this.labelSoftVer.Text = "Версия программы: " + iVer.ToString() + ".";
                    }), null);
                    break;
                default:
                    break;
            }

            iCurrCommand = -1;
        }

        public Form_DeviceBase(stMyBleDevice mbd)
        {
            InitializeComponent();

            synchronizationContext = SynchronizationContext.Current;

            sSelBleId = mbd.sBleId;            
            this.labelName.Text = "Имя: " + mbd.sName;
            this.labelBleMac.Text = "MAC: " + mbd.sBleMacAddr;
        }

        private void Form_Device_Load(object sender, EventArgs e)
        {
            BLE_com.BuffChaged += Bc_BuffChanged;

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            byte[] buf = BitConverter.GetBytes(unixTimestamp);
            SendCommand(InCommandBase.CMD_SET_TIME, buf);
            //while (iCurrCommand > 0)
                Thread.Sleep(1000);

            SendCommand(InCommandBase.CMD_GET_VERSION, null);

            //while (iCurrCommand > 0)
                Thread.Sleep(1000);

            SendCommand(InCommandBase.CMD_GET_AKKVOLTAGE, null);
        }

        private void Form_Device_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLE_com.BuffChaged -= Bc_BuffChanged;
        }

        private async void SendCommand(InCommandBase cmd, byte[] databuf)
        {            
            iCurrCommand = (byte)cmd;
            if (databuf != null)
            {
                BLE_com.pBuffOut = databuf;
                BLE_com.iBuffOutLen = (UInt16)databuf.Length;

                BLE_com.SendCommand((byte)cmd, true);
            }
            else
            {
                BLE_com.SendCommand((byte)cmd, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandBase.CMD_SET_BLINK, null);
            EnableButtons(true);
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandBase.CMD_GET_SETTINGS, null);
            EnableButtons(true);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            byte[] buf = BitConverter.GetBytes(unixTimestamp);
            SendCommand(InCommandBase.CMD_SET_TIME, buf);
            EnableButtons(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandBase.CMD_MODE_WAIT, null);
            EnableButtons(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandBase.CMD_MODE_ACTIVE, null);
            EnableButtons(true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandBase.CMD_MODE_SLEEP, null);
            EnableButtons(true);
        }

        private void ShowBaseSettings(SPORT_BASE_SETTINGS s)
        {
            Form_SettingsBase fs = new Form_SettingsBase(s);
            fs.StartPosition = FormStartPosition.Manual;
            fs.Location = this.Location;
            DialogResult dr = fs.ShowDialog();
            if(dr == DialogResult.OK)
            {
                //save settings
                byte[] ar2 = BLE_com.GetBytes(fs.returnSettings);
                SendCommand(InCommandBase.CMD_SET_SETTINGS, ar2);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form_BaseKM fbkm = new Form_BaseKM();

            fbkm.ShowDialog();
            SendCommand(InCommandBase.CMD_MODE_ACTIVE, null);
        }
    }
}
