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
    public partial class Form_SettingsBase : Form
    {
        public SPORT_BASE_SETTINGS returnSettings;

        public class BaseWorkType
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public Form_SettingsBase(SPORT_BASE_SETTINGS sbs)
        {
            InitializeComponent();

            var dataSource = new List<BaseWorkType>();
            dataSource.Add(new BaseWorkType() { Name = "Стартовая", Value = 0 });
            dataSource.Add(new BaseWorkType() { Name = "Обычная", Value = 1 });
            dataSource.Add(new BaseWorkType() { Name = "Финишная", Value = 2 });
            dataSource.Add(new BaseWorkType() { Name = "Очистка", Value = 3 });
            dataSource.Add(new BaseWorkType() { Name = "Проверочная", Value = 4 });

            //Setup data binding
            this.comboBoxType.DataSource = dataSource;
            this.comboBoxType.DisplayMember = "Name";
            this.comboBoxType.ValueMember = "Value";

            this.numericUpDownGainKm.Value = sbs.gain_KM;
            
            this.numericUpDownPowerBle.Value = sbs.powerble_station;
            this.numericUpDownTimeout.Value = sbs.timeut_station;
            this.numericUpDownTimerKm.Value = sbs.timer_KM;
            this.textBoxPassword.Text = Encoding.Default.GetString(sbs.password_station);

            string sKey = "";
            foreach (byte b in sbs.ar_secure_key) sKey += b.ToString("X") + " ";

            this.textBoxKeyKM.Text = sKey;

            int wt = (int)sbs.type_station;
            this.comboBoxType.SelectedIndex = wt;
            this.numericUpDownNum.Value = sbs.num_station;
            if ((sbs.service1 & 0x01) == 1) this.checkBoxLedInverse.Checked = true;
        }

        private void Form_SettingsBase_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnSettings = new SPORT_BASE_SETTINGS();

            returnSettings.mode_station = WORKMODE_BASE.MODE_ACTIVE;
            returnSettings.type_station = (BLE_setup.WORKTYPE)((BaseWorkType)this.comboBoxType.SelectedItem).Value;
            returnSettings.gain_KM = (byte)this.numericUpDownGainKm.Value;
            returnSettings.num_station = (byte)this.numericUpDownNum.Value;
            returnSettings.powerble_station = (byte)this.numericUpDownPowerBle.Value;
            returnSettings.timeut_station = (UInt32)this.numericUpDownTimeout.Value;
            returnSettings.timer_KM = (UInt32)this.numericUpDownTimerKm.Value;
            returnSettings.password_station = new byte[10];
            Array.Copy(Encoding.Default.GetBytes(this.textBoxPassword.Text), returnSettings.password_station, this.textBoxPassword.Text.Length);

            this.textBoxKeyKM.Text = this.textBoxKeyKM.Text.TrimEnd(' ');
            string[] sKa = this.textBoxKeyKM.Text.Split(' ');
            if (sKa.Length != 6)
            {
                MessageBox.Show("В поле Ключи шифрования введите 6 чисел в шестнадцатиричном формате разделенных пробелами. Пример: C1 FF 35 01 AD 0E .");
                return;
            }
            returnSettings.ar_secure_key = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                returnSettings.ar_secure_key[i] = Convert.ToByte(sKa[i], 16);
            }
            returnSettings.signature = 223;
            if (this.checkBoxLedInverse.Checked) returnSettings.service1 = 1;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((BaseWorkType)this.comboBoxType.SelectedItem).Name)
            {
                case "Стартовая":
                    this.numericUpDownNum.Value = 240;
                    break;

                case "Финишная":
                    this.numericUpDownNum.Value = 245;
                    break;

                case "Очистка":
                    this.numericUpDownNum.Value = 249;
                    break;

                case "Проверочная":
                    this.numericUpDownNum.Value = 248;
                    break;

                case "Обычная":
                    this.numericUpDownNum.Value = 1;
                    break;
            }


        }
    }
}
