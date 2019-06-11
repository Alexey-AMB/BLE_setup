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
        BLE_com bc;
        private stMyBleDevice SelMBD = new stMyBleDevice();
        private string sSelName = null;

        //==================================================================
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bc = new BLE_com();
            this.timer1.Enabled = true;
            bc.StartDiscoveryAdv();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Enabled = false;
            bc.StopBleDeviceWatcher();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (bc.oLock)
            {
                if (bc.bUpdateList)
                {
                    this.listBox1.Items.Clear();
                    foreach (string dd in bc.BleList.Keys)
                    {

                        stMyBleDevice mbd = bc.BleList[dd];
                        this.listBox1.Items.Add(mbd.sBleMacAddr + " | " + mbd.sName);
                    }
                    //Id = "BluetoothLE#BluetoothLE00:1a:7d:da:71:13-00:81:f9:fc:e2:27"
                    bc.bUpdateList = false;

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
                foreach(stMyBleDevice mbd in bc.BleList.Values)
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
            if (await bc.OpenBle(SelMBD.sBleId, SelMBD.type))
            {
                
                if (SelMBD.type == MyTypeBleDevice.BASE)
                {
                    bc.cCmdNext = (byte)InCommandBase.CMD_NEXT;
                    Form_DeviceBase fdb = new Form_DeviceBase(bc, SelMBD);
                    fdb.StartPosition = FormStartPosition.Manual;
                    fdb.Location = this.Location;
                    fdb.ShowDialog();
                }
                if (SelMBD.type == MyTypeBleDevice.TAG)
                {
                    bc.cCmdNext = (byte)InCommandTag.CMD_NEXT;
                    Form_DeviceTag fdt = new Form_DeviceTag(bc, SelMBD);
                    fdt.StartPosition = FormStartPosition.Manual;
                    fdt.Location = this.Location;
                    fdt.ShowDialog();
                }                
            }
            bc.CloseBle();
            this.timer1.Enabled = true;
            lock (bc.oLock)
            {
                bc.BleList.Clear();
                bc.bUpdateList = true;
            }
            //bc.StartDiscoveryAdv();
        }

        private void checkBoxBase_CheckedChanged(object sender, EventArgs e)
        {
            lock (bc.oLock)
            {
                bc.bBaseFound = this.checkBoxBase.Checked;
                bc.bTagFound = this.checkBoxTag.Checked;

                bc.BleList.Clear();
                bc.bUpdateList = true;
            }
        }

        

        
    }
}
