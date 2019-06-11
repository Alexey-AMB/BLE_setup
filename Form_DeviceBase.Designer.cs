namespace BLE_setup
{
    partial class Form_DeviceBase
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
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelBleMac = new System.Windows.Forms.Label();
            this.labelSoftVer = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.labelAkkVoltage = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Настройки";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Помигать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "Name";
            // 
            // labelBleMac
            // 
            this.labelBleMac.AutoSize = true;
            this.labelBleMac.Location = new System.Drawing.Point(12, 29);
            this.labelBleMac.Name = "labelBleMac";
            this.labelBleMac.Size = new System.Drawing.Size(43, 13);
            this.labelBleMac.TabIndex = 10;
            this.labelBleMac.Text = "BleMac";
            // 
            // labelSoftVer
            // 
            this.labelSoftVer.AutoSize = true;
            this.labelSoftVer.Location = new System.Drawing.Point(12, 45);
            this.labelSoftVer.Name = "labelSoftVer";
            this.labelSoftVer.Size = new System.Drawing.Size(42, 13);
            this.labelSoftVer.TabIndex = 11;
            this.labelSoftVer.Text = "SoftVer";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Режим сна";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 165);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Режим работы";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 194);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "Режим выкл.";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // labelAkkVoltage
            // 
            this.labelAkkVoltage.AutoSize = true;
            this.labelAkkVoltage.Location = new System.Drawing.Point(12, 61);
            this.labelAkkVoltage.Name = "labelAkkVoltage";
            this.labelAkkVoltage.Size = new System.Drawing.Size(62, 13);
            this.labelAkkVoltage.TabIndex = 17;
            this.labelAkkVoltage.Text = "AkkVoltage";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Установить время";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_DeviceBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 283);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelAkkVoltage);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelSoftVer);
            this.Controls.Add(this.labelBleMac);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DeviceBase";
            this.Text = "База";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Device_FormClosing);
            this.Load += new System.EventHandler(this.Form_Device_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelBleMac;
        private System.Windows.Forms.Label labelSoftVer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label labelAkkVoltage;
        private System.Windows.Forms.Button button2;
    }
}