using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BLE_setup
{
    public partial class Form_BaseKM : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        private int iCurrCommand = -1;

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

        private void Bc_BuffChanged(byte[] pBuffIn)
        {
            //if (pBuffIn == null) return;

            switch (iCurrCommand)
            {
                //case (int)InCommandBase.CMD_GET_SETTINGS:
                //    GCHandle handle = GCHandle.Alloc(pBuffIn, GCHandleType.Pinned);
                //    SPORT_BASE_SETTINGS sbs = (SPORT_BASE_SETTINGS)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SPORT_BASE_SETTINGS));
                //    handle.Free();

                //    synchronizationContext.Post(new SendOrPostCallback(o =>
                //    {
                //        ShowBaseSettings(sbs);
                //    }), null);

                //    break;
                //case (int)InCommandBase.CMD_GET_AKKVOLTAGE:
                //    int iV = BitConverter.ToInt32(pBuffIn, 0);
                //    synchronizationContext.Post(new SendOrPostCallback(o =>
                //    {
                //        this.labelAkkVoltage.Text = "Напряжение: " + ((float)iV / 1000000).ToString("F2") + " В.";
                //    }), null);
                //    break;
                case (int)InCommandBase.CMD_CLEAR_CARD:
                    
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        //this.label1.Text = "OK.";
                    }), null);
                    break;
                case (int)InCommandBase.CMD_WRITE_CARD_NUM:

                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        //this.label2.Text = "OK.";
                    }), null);
                    break;
                case (int)InCommandBase.CMD_READ_CARD:
                    synchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        ShowKMResult(pBuffIn);
                    }), null);
                    break;
                default:
                    break;
            }
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                this.label3.Text = "OK.";
            }), null);

            iCurrCommand = -1;
        }

        private void BLE_com_BuffError()
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                this.label3.Text = "ERROR!";
            }), null);
        }

        public Form_BaseKM()
        {
            InitializeComponent();

            synchronizationContext = SynchronizationContext.Current;
        }

        private void Form_BaseKM_Load(object sender, EventArgs e)
        {
            BLE_com.BuffChaged += Bc_BuffChanged;
            BLE_com.BuffError += BLE_com_BuffError;
        }
        
        private void Form_BaseKM_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLE_com.BuffChaged -= Bc_BuffChanged;
            BLE_com.BuffError -= BLE_com_BuffError;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SendCommand(InCommandBase.CMD_CLEAR_CARD, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //  DF 0C 04 00 24 23 01 00 00	- write num card
            //  DF 0C 04 00 FE 00 FF FF 00	- write master card sleep
            byte[] nblk = BitConverter.GetBytes((Int32)this.numericUpDownNumCard.Value);
            SendCommand(InCommandBase.CMD_WRITE_CARD_NUM, nblk);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SendCommand(InCommandBase.CMD_READ_CARD, null);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            byte[] nblk = BitConverter.GetBytes((Int32)16776960);
            SendCommand(InCommandBase.CMD_WRITE_CARD_NUM, nblk);
        }



        private void ShowKMResult(byte[] res)
        {
            int iIndex = 4;
            byte[] qBaseTime = new byte[4];
            qBaseTime[3] = res[4];
            qBaseTime[2] = res[5];
            qBaseTime[1] = res[6];
            qBaseTime[0] = res[7];
            int iStartBlockTime = BitConverter.ToInt32(qBaseTime, 0);
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
                    if (iNumbase == 0) continue;

                    byte[] aBaseTime = new byte[4];
                    aBaseTime[3] = res[4];
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

                } while (iIndex < res.Length - 4);
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
            this.labelKmNumber.Text = "Карта № " + res[0].ToString();
            //EnableButtonsZabeg(true);
        }

        
    }
}
