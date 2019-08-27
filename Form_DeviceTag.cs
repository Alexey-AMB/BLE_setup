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
        
        stMyBleDevice mbd;
        private string sSelBleId = null;

        private void EnableButtons(bool bEn)
        {
            this.button1.Enabled = bEn;
            this.button2.Enabled = bEn;
            this.button3.Enabled = bEn;
            this.button4.Enabled = bEn;
            this.button5.Enabled = bEn;
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
                case (int)InCommandTag.CMD_READ_DATA:
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        ShowTagResult(pBuffIn);
                    }), null);
                    break;
                default:
                    break;
            }

            iCurrCommand = -1;
        }

        public Form_DeviceTag(stMyBleDevice mbdIn)
        {
            InitializeComponent();

            this.Width = 160;
            this.Height = 260;

            synchronizationContext = SynchronizationContext.Current;

            mbd = mbdIn;
            sSelBleId = mbd.sBleId;
            this.labelName.Text = "Имя: " + mbd.sName;
            this.labelBleMac.Text = "MAC: " + mbd.sBleMacAddr;
        }

        private void Form_DeviceTag_Load(object sender, EventArgs e)
        {
            BLE_com.BuffChaged += Bc_BuffChanged;

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
                BLE_com.pBuffOut = databuf;
                BLE_com.iBuffOutLen = (UInt16)databuf.Length;

                BLE_com.SendCommand((byte)cmd, true);
            }
            else
            {
                BLE_com.SendCommand((byte)cmd, false);
            }
        }

        private void Form_DeviceTag_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLE_com.BuffChaged -= Bc_BuffChanged;
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
                byte[] ar2 = BLE_com.GetBytes(fs.returnSettings);
                SendCommand(InCommandTag.CMD_SET_SETTINGS, ar2);
            }
        }

        byte[] nblk = new byte[1];
        
        private void Button2_Click(object sender, EventArgs e)
        {
            //EnableButtons(false);

            this.Width = 630;
            this.Height = 460;

            this.groupBox1.Visible = true;

            nblk[0] = 2;
            SendCommand(InCommandTag.CMD_READ_DATA, nblk);

            EnableButtonsZabeg(false);
        }

        private void ButtonZabegPrev_Click(object sender, EventArgs e)
        {
            if (nblk[0] < 2) return;

            EnableButtonsZabeg(false);
            nblk[0] -= 1;
            SendCommand(InCommandTag.CMD_READ_DATA, nblk);
        }

        private void ButtonZabegNext_Click(object sender, EventArgs e)
        {
            if (nblk[0] > 13) return;

            EnableButtonsZabeg(false);
            nblk[0] += 1;
            SendCommand(InCommandTag.CMD_READ_DATA, nblk);
        }

        private void ShowTagResult(byte[] res)
        {
            int iIndex = 0;
            int iStartBlockTime = BitConverter.ToInt32(res, iIndex);
            int ut01012019 = (int)(new DateTime(2019, 1, 1) - new DateTime(1970, 1, 1)).TotalSeconds;

            DateTime tStartBlockTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(iStartBlockTime);

            //
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            DataColumn Numbase;
            DataColumn TimeBase;
            DataColumn TimeDelta;
            
            dt = new DataTable("Table1");
            Numbase = new DataColumn("NameBase", Type.GetType("System.String"));
            TimeBase = new DataColumn("Time", Type.GetType("System.String"));
            TimeDelta = new DataColumn("Delta", Type.GetType("System.String"));

            dt.Columns.Add(Numbase);
            dt.Columns.Add(TimeBase);
            dt.Columns.Add(TimeDelta);            
            //


            if (iStartBlockTime > ut01012019)
            {
                int iNumbase = 0;
                DateTime tBaseTimePrev = tStartBlockTime;
                do
                {
                    iIndex += 4;

                    iNumbase = (int)res[iIndex];
                    if (iNumbase == 0) break;

                    byte[] aBaseTime = new byte[4];
                    aBaseTime[3] = res[3];
                    aBaseTime[2] = res[iIndex + 1];
                    aBaseTime[1] = res[iIndex + 2];
                    aBaseTime[0] = res[iIndex + 3];

                    int iBaseTime = BitConverter.ToInt32(aBaseTime, 0);
                    DateTime tBaseTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(iBaseTime);


                    dr = dt.NewRow();
                    dr["NameBase"] = iNumbase.ToString();
                    if (iNumbase == 240) dr["NameBase"] = "Start";
                    if (iNumbase == 245) dr["NameBase"] = "Finish";
                    if (iNumbase == 248) dr["NameBase"] = "Check";
                    dr["Time"] = tBaseTime.ToString("dd.MM.yyyy hh:mm:ss");
                    dr["Delta"] = (tBaseTime - tBaseTimePrev).ToString();
                    dt.Rows.Add(dr);
                    tBaseTimePrev = tBaseTime;

                } while (iIndex < res.Length);
                ds.Tables.Add(dt);

                this.dataGridView1.Visible = true;
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = ds;
                this.dataGridView1.DataMember = "Table1";
                this.dataGridView1.Refresh();
            }
            else
            {
                //Блок не читается
                this.dataGridView1.Visible = false;
            }
            this.labelNumZabeg.Text = nblk[0].ToString();
            EnableButtonsZabeg(true);
        }

        private void EnableButtonsZabeg(bool b)
        {
            if(!b)
            {
                this.buttonZabegNext.Enabled = false;
                this.buttonZabegPrev.Enabled = false;
            }
            else
            {
                this.buttonZabegNext.Enabled = true;
                this.buttonZabegPrev.Enabled = true;

                if (nblk[0] < 3) this.buttonZabegPrev.Enabled = false;
                if(nblk[0] > 13) this.buttonZabegNext.Enabled = false;
            }
        }
    }
}
