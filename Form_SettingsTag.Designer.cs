namespace BLE_setup
{
    partial class Form_SettingsTag
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxColectiv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownGodRojd = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOtch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxImja = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGodRojd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя метки";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(130, 6);
            this.textBoxName.MaxLength = 20;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Автовыключение (сек)";
            // 
            // numericUpDownTimeOut
            // 
            this.numericUpDownTimeOut.Location = new System.Drawing.Point(130, 32);
            this.numericUpDownTimeOut.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numericUpDownTimeOut.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeOut.Name = "numericUpDownTimeOut";
            this.numericUpDownTimeOut.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownTimeOut.TabIndex = 3;
            this.numericUpDownTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Порог метки";
            // 
            // numericUpDownTreshold
            // 
            this.numericUpDownTreshold.Location = new System.Drawing.Point(130, 58);
            this.numericUpDownTreshold.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numericUpDownTreshold.Minimum = new decimal(new int[] {
            140,
            0,
            0,
            -2147483648});
            this.numericUpDownTreshold.Name = "numericUpDownTreshold";
            this.numericUpDownTreshold.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownTreshold.TabIndex = 5;
            this.numericUpDownTreshold.Value = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пароль метки";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(130, 84);
            this.textBoxPass.MaxLength = 10;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPass.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxColectiv);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDownGodRojd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxOtch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxImja);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxFam);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 174);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователь";
            // 
            // textBoxColectiv
            // 
            this.textBoxColectiv.Location = new System.Drawing.Point(124, 139);
            this.textBoxColectiv.MaxLength = 20;
            this.textBoxColectiv.Name = "textBoxColectiv";
            this.textBoxColectiv.Size = new System.Drawing.Size(100, 20);
            this.textBoxColectiv.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Коллектив";
            // 
            // numericUpDownGodRojd
            // 
            this.numericUpDownGodRojd.Location = new System.Drawing.Point(124, 113);
            this.numericUpDownGodRojd.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.numericUpDownGodRojd.Minimum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDownGodRojd.Name = "numericUpDownGodRojd";
            this.numericUpDownGodRojd.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownGodRojd.TabIndex = 7;
            this.numericUpDownGodRojd.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Год рождения";
            // 
            // textBoxOtch
            // 
            this.textBoxOtch.Location = new System.Drawing.Point(124, 82);
            this.textBoxOtch.MaxLength = 20;
            this.textBoxOtch.Name = "textBoxOtch";
            this.textBoxOtch.Size = new System.Drawing.Size(100, 20);
            this.textBoxOtch.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Отчество";
            // 
            // textBoxImja
            // 
            this.textBoxImja.Location = new System.Drawing.Point(124, 56);
            this.textBoxImja.MaxLength = 20;
            this.textBoxImja.Name = "textBoxImja";
            this.textBoxImja.Size = new System.Drawing.Size(100, 20);
            this.textBoxImja.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Имя";
            // 
            // textBoxFam
            // 
            this.textBoxFam.Location = new System.Drawing.Point(124, 28);
            this.textBoxFam.MaxLength = 20;
            this.textBoxFam.Name = "textBoxFam";
            this.textBoxFam.Size = new System.Drawing.Size(100, 20);
            this.textBoxFam.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Фамилия";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(34, 291);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(146, 290);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Form_SettingsTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 318);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownTreshold);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownTimeOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SettingsTag";
            this.Text = "Настройки метки";
            this.Load += new System.EventHandler(this.Form_SettingsTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGodRojd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxColectiv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownGodRojd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxOtch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxImja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}