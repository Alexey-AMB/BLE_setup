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
    public partial class Form_DeviceTag : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        private int iCurrCommand = -1;
        BLE_com bc;
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
                case (int)InCommandTag.CMD_GET_SETTINGS:
                    GCHandle handle = GCHandle.Alloc(pBuffIn, GCHandleType.Pinned);
                    SPORT_TAG_SETTINGS sbs = (SPORT_TAG_SETTINGS)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SPORT_TAG_SETTINGS));
                    handle.Free();

                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        ShowTagSettings(sbs);
                    }), null);

                    break;
                case (int)InCommandTag.CMD_GET_AKKVOLTAGE:
                    int iV = BitConverter.ToInt32(pBuffIn, 0);
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        this.labelAkkVoltage.Text = "Напряжение: " + ((float)iV / 1000000).ToString("F2") + " В.";
                    }), null);
                    break;
                case (int)InCommandTag.CMD_GET_VERSION:
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

        public Form_DeviceTag(BLE_com bIn, stMyBleDevice mbd)
        {
            InitializeComponent();

            synchronizationContext = SynchronizationContext.Current;

            bc = bIn;
            sSelBleId = mbd.sBleId;
            this.labelName.Text = "Имя: " + mbd.sName;
            this.labelBleMac.Text = "MAC: " + mbd.sBleMacAddr;
        }

        private void Form_DeviceTag_Load(object sender, EventArgs e)
        {
            bc.BuffChaged += Bc_BuffChanged;

            SendCommand(InCommandTag.CMD_GET_VERSION, null);

            //while (iCurrCommand > 0)
            Thread.Sleep(1500);

            SendCommand(InCommandTag.CMD_GET_AKKVOLTAGE, null);
        }

        private async void SendCommand(InCommandTag cmd, byte[] databuf)
        {
            iCurrCommand = (byte)cmd;
            if (databuf != null)
            {
                bc.pBuffOut = databuf;
                bc.iBuffOutLen = (UInt16)databuf.Length;

                 bc.SendCommand((byte)cmd, true);
            }
            else
            {
                 bc.SendCommand((byte)cmd, false);
            }
        }

        private void Form_DeviceTag_FormClosing(object sender, FormClosingEventArgs e)
        {
            bc.BuffChaged -= Bc_BuffChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandTag.CMD_SET_BLINK, null);
            EnableButtons(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandTag.CMD_GET_SETTINGS, null);
            EnableButtons(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandTag.CMD_SET_MODE_CONN, null);
            EnableButtons(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            SendCommand(InCommandTag.CMD_SET_MODE_RUN, null);
            EnableButtons(true);
            this.Close();
        }

        private void ShowTagSettings(SPORT_TAG_SETTINGS s)
        {
            Form_SettingsTag fs = new Form_SettingsTag(s);
            fs.StartPosition = FormStartPosition.Manual;
            fs.Location = this.Location;
            DialogResult dr = fs.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //save settings
                byte[] ar2 = bc.GetBytes(fs.returnSettings);
                SendCommand(InCommandTag.CMD_SET_SETTINGS, ar2);
            }
        }

    }
}
