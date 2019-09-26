using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLE_setup
{
    public partial class Form_SettingsTag : Form
    {
        public SPORT_TAG_SETTINGS returnSettings;

        public Form_SettingsTag(SPORT_TAG_SETTINGS sts)
        {
            InitializeComponent();

            this.textBoxName.Text = Encoding.Default.GetString(sts.name_tag);
            this.numericUpDownTimeOut.Value = CheckNUDvalue((int)sts.timeut_conn, this.numericUpDownTimeOut);
            this.numericUpDownTreshold.Value = CheckNUDvalue((int)sts.treshold_tag, this.numericUpDownTreshold);
            this.textBoxPass.Text = Encoding.Default.GetString(sts.password_tag);

            this.textBoxFam.Text = Encoding.Default.GetString(sts.fam);
            this.textBoxImja.Text = Encoding.Default.GetString(sts.imj);
            this.textBoxOtch.Text = Encoding.Default.GetString(sts.otch);
            this.numericUpDownGodRojd.Value = CheckNUDvalue((int)sts.godrojd, this.numericUpDownGodRojd);
            this.textBoxColectiv.Text = Encoding.Default.GetString(sts.colectiv);
            if (sts.arenda > 0) this.checkBoxClub.Checked = true;
        }

        private void Form_SettingsTag_Load(object sender, EventArgs e)
        {

        }

        private int CheckNUDvalue(int bin, NumericUpDown nud)
        {
            int iRet = bin;

            if (bin > nud.Maximum) iRet = (int)nud.Maximum;
            if (bin < nud.Minimum) iRet = (int)nud.Minimum;

            return iRet;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            returnSettings = new SPORT_TAG_SETTINGS();
                        
            returnSettings.name_tag = new byte[20];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxName.Text), returnSettings.name_tag, this.textBoxName.Text.Length);
            returnSettings.timeut_conn = (Int32)this.numericUpDownTimeOut.Value;
            returnSettings.treshold_tag = (sbyte)this.numericUpDownTreshold.Value;
            returnSettings.password_tag = new byte[10];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxPass.Text), returnSettings.password_tag, this.textBoxPass.Text.Length);

            returnSettings.fam = new byte[20];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxFam.Text), returnSettings.fam, this.textBoxFam.Text.Length);
            returnSettings.imj = new byte[20];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxImja.Text), returnSettings.imj, this.textBoxImja.Text.Length);
            returnSettings.otch = new byte[20];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxOtch.Text), returnSettings.otch, this.textBoxOtch.Text.Length);
            returnSettings.godrojd = (UInt16)this.numericUpDownGodRojd.Value;
            returnSettings.colectiv = new byte[20];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxColectiv.Text), returnSettings.colectiv, this.textBoxColectiv.Text.Length);

            if(this.checkBoxClub.Checked) returnSettings.arenda = 1;
            else returnSettings.arenda = 0;

            returnSettings.mode_tag = WORKMODE_TAG.MODE_CONNECT;
            returnSettings.powerble_tag = 5;
            returnSettings.group = new byte[4];
            returnSettings.razr = new byte[4];
            returnSettings.zabeg = 0;
            returnSettings.startnum = 0;
            returnSettings.starttime = new byte[7];
            returnSettings.lgota = 0;
            
            returnSettings.signature = 223;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
