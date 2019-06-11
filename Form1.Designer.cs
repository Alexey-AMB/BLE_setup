namespace BLE_setup
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxBase = new System.Windows.Forms.CheckBox();
            this.checkBoxTag = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(12, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(236, 228);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxBase
            // 
            this.checkBoxBase.AutoSize = true;
            this.checkBoxBase.Checked = true;
            this.checkBoxBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBase.Location = new System.Drawing.Point(13, 13);
            this.checkBoxBase.Name = "checkBoxBase";
            this.checkBoxBase.Size = new System.Drawing.Size(53, 17);
            this.checkBoxBase.TabIndex = 1;
            this.checkBoxBase.Text = "Базы";
            this.checkBoxBase.UseVisualStyleBackColor = true;
            this.checkBoxBase.CheckedChanged += new System.EventHandler(this.checkBoxBase_CheckedChanged);
            // 
            // checkBoxTag
            // 
            this.checkBoxTag.AutoSize = true;
            this.checkBoxTag.Checked = true;
            this.checkBoxTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTag.Location = new System.Drawing.Point(110, 13);
            this.checkBoxTag.Name = "checkBoxTag";
            this.checkBoxTag.Size = new System.Drawing.Size(58, 17);
            this.checkBoxTag.TabIndex = 2;
            this.checkBoxTag.Text = "Метки";
            this.checkBoxTag.UseVisualStyleBackColor = true;
            this.checkBoxTag.CheckedChanged += new System.EventHandler(this.checkBoxBase_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 287);
            this.Controls.Add(this.checkBoxTag);
            this.Controls.Add(this.checkBoxBase);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BLE Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxBase;
        private System.Windows.Forms.CheckBox checkBoxTag;
    }
}

