namespace BLE_setup
{
    partial class Form_DeviceTag
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
            this.labelAkkVoltage = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelSoftVer = new System.Windows.Forms.Label();
            this.labelBleMac = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonZabegNext = new System.Windows.Forms.Button();
            this.buttonZabegPrev = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelNumZabeg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAkkVoltage
            // 
            this.labelAkkVoltage.AutoSize = true;
            this.labelAkkVoltage.Location = new System.Drawing.Point(12, 55);
            this.labelAkkVoltage.Name = "labelAkkVoltage";
            this.labelAkkVoltage.Size = new System.Drawing.Size(62, 13);
            this.labelAkkVoltage.TabIndex = 25;
            this.labelAkkVoltage.Text = "AkkVoltage";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 159);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "Режим забега";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Режим подкл.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelSoftVer
            // 
            this.labelSoftVer.AutoSize = true;
            this.labelSoftVer.Location = new System.Drawing.Point(12, 39);
            this.labelSoftVer.Name = "labelSoftVer";
            this.labelSoftVer.Size = new System.Drawing.Size(42, 13);
            this.labelSoftVer.TabIndex = 22;
            this.labelSoftVer.Text = "SoftVer";
            // 
            // labelBleMac
            // 
            this.labelBleMac.AutoSize = true;
            this.labelBleMac.Location = new System.Drawing.Point(12, 23);
            this.labelBleMac.Name = "labelBleMac";
            this.labelBleMac.Size = new System.Drawing.Size(43, 13);
            this.labelBleMac.TabIndex = 21;
            this.labelBleMac.Text = "BleMac";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 20;
            this.labelName.Text = "Name";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Настройки";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Помигать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Результаты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonZabegNext);
            this.groupBox1.Controls.Add(this.buttonZabegPrev);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.labelNumZabeg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(154, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 397);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результаты";
            // 
            // buttonZabegNext
            // 
            this.buttonZabegNext.Location = new System.Drawing.Point(365, 357);
            this.buttonZabegNext.Name = "buttonZabegNext";
            this.buttonZabegNext.Size = new System.Drawing.Size(75, 23);
            this.buttonZabegNext.TabIndex = 4;
            this.buttonZabegNext.Text = "Следующий";
            this.buttonZabegNext.UseVisualStyleBackColor = true;
            this.buttonZabegNext.Click += new System.EventHandler(this.ButtonZabegNext_Click);
            // 
            // buttonZabegPrev
            // 
            this.buttonZabegPrev.Location = new System.Drawing.Point(10, 357);
            this.buttonZabegPrev.Name = "buttonZabegPrev";
            this.buttonZabegPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonZabegPrev.TabIndex = 3;
            this.buttonZabegPrev.Text = "Назад";
            this.buttonZabegPrev.UseVisualStyleBackColor = true;
            this.buttonZabegPrev.Click += new System.EventHandler(this.ButtonZabegPrev_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(430, 296);
            this.dataGridView1.TabIndex = 2;
            // 
            // labelNumZabeg
            // 
            this.labelNumZabeg.AutoSize = true;
            this.labelNumZabeg.Location = new System.Drawing.Point(65, 20);
            this.labelNumZabeg.Name = "labelNumZabeg";
            this.labelNumZabeg.Size = new System.Drawing.Size(25, 13);
            this.labelNumZabeg.TabIndex = 1;
            this.labelNumZabeg.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Забег №";
            // 
            // Form_DeviceTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelAkkVoltage);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelSoftVer);
            this.Controls.Add(this.labelBleMac);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DeviceTag";
            this.Text = "Метка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_DeviceTag_FormClosing);
            this.Load += new System.EventHandler(this.Form_DeviceTag_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAkkVoltage;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelSoftVer;
        private System.Windows.Forms.Label labelBleMac;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonZabegNext;
        private System.Windows.Forms.Button buttonZabegPrev;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelNumZabeg;
        private System.Windows.Forms.Label label1;
    }
}