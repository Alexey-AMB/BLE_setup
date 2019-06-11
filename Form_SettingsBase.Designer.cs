namespace BLE_setup
{
    partial class Form_SettingsBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.numericUpDownNum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPowerBle = new System.Windows.Forms.NumericUpDown();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.numericUpDownGainKm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimerKm = new System.Windows.Forms.NumericUpDown();
            this.textBoxKeyKM = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPowerBle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerKm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер станции:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип станции:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Время авт. выключения:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Мощность передатчика:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пароль BLE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Усиление карточек:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Время опроса карточек:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ключи шифрования карточек:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(134, 276);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(233, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(186, 3);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 11;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // numericUpDownNum
            // 
            this.numericUpDownNum.InterceptArrowKeys = false;
            this.numericUpDownNum.Location = new System.Drawing.Point(187, 40);
            this.numericUpDownNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNum.Name = "numericUpDownNum";
            this.numericUpDownNum.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNum.TabIndex = 12;
            this.numericUpDownNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeout.Location = new System.Drawing.Point(188, 76);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericUpDownTimeout.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTimeout.TabIndex = 13;
            this.numericUpDownTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericUpDownPowerBle
            // 
            this.numericUpDownPowerBle.Location = new System.Drawing.Point(188, 108);
            this.numericUpDownPowerBle.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownPowerBle.Name = "numericUpDownPowerBle";
            this.numericUpDownPowerBle.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPowerBle.TabIndex = 14;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(188, 139);
            this.textBoxPassword.MaxLength = 10;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(119, 20);
            this.textBoxPassword.TabIndex = 15;
            // 
            // numericUpDownGainKm
            // 
            this.numericUpDownGainKm.Location = new System.Drawing.Point(188, 174);
            this.numericUpDownGainKm.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGainKm.Name = "numericUpDownGainKm";
            this.numericUpDownGainKm.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGainKm.TabIndex = 16;
            // 
            // numericUpDownTimerKm
            // 
            this.numericUpDownTimerKm.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTimerKm.Location = new System.Drawing.Point(187, 206);
            this.numericUpDownTimerKm.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownTimerKm.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTimerKm.Name = "numericUpDownTimerKm";
            this.numericUpDownTimerKm.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTimerKm.TabIndex = 17;
            this.numericUpDownTimerKm.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBoxKeyKM
            // 
            this.textBoxKeyKM.Location = new System.Drawing.Point(187, 235);
            this.textBoxKeyKM.MaxLength = 18;
            this.textBoxKeyKM.Name = "textBoxKeyKM";
            this.textBoxKeyKM.Size = new System.Drawing.Size(120, 20);
            this.textBoxKeyKM.TabIndex = 18;
            this.textBoxKeyKM.Text = "FF FF FF FF FF FF";
            // 
            // Form_SettingsBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 306);
            this.Controls.Add(this.textBoxKeyKM);
            this.Controls.Add(this.numericUpDownTimerKm);
            this.Controls.Add(this.numericUpDownGainKm);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.numericUpDownPowerBle);
            this.Controls.Add(this.numericUpDownTimeout);
            this.Controls.Add(this.numericUpDownNum);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_SettingsBase";
            this.Text = "Настройки базы";
            this.Load += new System.EventHandler(this.Form_SettingsBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPowerBle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerKm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.NumericUpDown numericUpDownNum;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDownPowerBle;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.NumericUpDown numericUpDownGainKm;
        private System.Windows.Forms.NumericUpDown numericUpDownTimerKm;
        private System.Windows.Forms.TextBox textBoxKeyKM;
    }
}