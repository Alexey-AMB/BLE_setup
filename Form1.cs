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

namespace BLE_setup
{
    public partial class Form1 : Form
    {
        
        private stMyBleDevice SelMBD = new stMyBleDevice();
        private string sSelName = null;

        //==================================================================
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            this.timer1.Enabled = true;
            BLE_com.StartDiscoveryAdv();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Enabled = false;
            BLE_com.StopBleDeviceWatcher();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (BLE_com.oLock)
            {
                if (BLE_com.bUpdateList)
                {
                    this.listBox1.Items.Clear();
                    foreach (string dd in BLE_com.BleList.Keys)
                    {

                        stMyBleDevice mbd = BLE_com.BleList[dd];
                        this.listBox1.Items.Add(mbd.sBleMacAddr + " | " + mbd.sName);
                    }
                    //Id = "BluetoothLE#BluetoothLE00:1a:7d:da:71:13-00:81:f9:fc:e2:27"
                    BLE_com.bUpdateList = false;

                    if (SelMBD.sBleId != null)
                    {
                        int i = 0;
                        bool bIsFound = false;

                        foreach (string s in this.listBox1.Items)
                        {
                            if (s == sSelName)
                            {
                                bIsFound = true;
                                break;
                            }
                            i++;
                        }
                        if (bIsFound)
                        {
                            this.listBox1.SelectedIndex = i;
                        }                        
                    }
                }
            }
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                string s = this.listBox1.SelectedItem.ToString();
                foreach(stMyBleDevice mbd in BLE_com.BleList.Values)
                {
                    if(mbd.sBleMacAddr == s.Substring(0, s.IndexOf(" | ")))
                    {
                        SelMBD = mbd;
                        sSelName = s;
                        break;
                    }
                }
            }
        }

        private async void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelMBD.sBleId)) return;
            if (this.listBox1.SelectedItem == null) return;

            //bc.StopDiscoveryAdv();
            this.timer1.Enabled = false;
            if (await BLE_com.OpenBle(SelMBD.sBleId, SelMBD.type))
            {
                
                if (SelMBD.type == MyTypeBleDevice.BASE)
                {
                    BLE_com.cCmdNext = (byte)InCommandBase.CMD_NEXT;
                    Form_DeviceBase fdb = new Form_DeviceBase(SelMBD);
                    fdb.StartPosition = FormStartPosition.Manual;
                    fdb.Location = this.Location;
                    fdb.ShowDialog();
                }
                if (SelMBD.type == MyTypeBleDevice.TAG)
                {
                    BLE_com.cCmdNext = (byte)InCommandTag.CMD_NEXT;
                    Form_DeviceTag fdt = new Form_DeviceTag(SelMBD);
                    fdt.StartPosition = FormStartPosition.Manual;
                    fdt.Location = this.Location;
                    fdt.ShowDialog();
                }                
            }
            BLE_com.CloseBle();
            this.timer1.Enabled = true;
            lock (BLE_com.oLock)
            {
                if(this.checkBoxClearList.Checked) BLE_com.BleList.Clear();
                BLE_com.bUpdateList = true;
            }
            //bc.StartDiscoveryAdv();
        }

        private void checkBoxBase_CheckedChanged(object sender, EventArgs e)
        {
            lock (BLE_com.oLock)
            {
                BLE_com.bBaseFound = this.checkBoxBase.Checked;
                BLE_com.bTagFound = this.checkBoxTag.Checked;

                BLE_com.BleList.Clear();
                BLE_com.bUpdateList = true;
            }
        }

        

        
    }
}
