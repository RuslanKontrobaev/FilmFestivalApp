
namespace Film_Festival_App
{
    partial class AddGuestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_bd = new System.Windows.Forms.DateTimePicker();
            this.textBox_nameGuest = new System.Windows.Forms.TextBox();
            this.label_dateBDGuest = new System.Windows.Forms.Label();
            this.label_nameGuest = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_addGuest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_bd);
            this.groupBox1.Controls.Add(this.textBox_nameGuest);
            this.groupBox1.Controls.Add(this.label_dateBDGuest);
            this.groupBox1.Controls.Add(this.label_nameGuest);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление гостя";
            // 
            // dateTimePicker_bd
            // 
            this.dateTimePicker_bd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_bd.Location = new System.Drawing.Point(144, 63);
            this.dateTimePicker_bd.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_bd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_bd.Name = "dateTimePicker_bd";
            this.dateTimePicker_bd.Size = new System.Drawing.Size(480, 26);
            this.dateTimePicker_bd.TabIndex = 2;
            this.dateTimePicker_bd.Value = new System.DateTime(2021, 1, 18, 0, 0, 0, 0);
            // 
            // textBox_nameGuest
            // 
            this.textBox_nameGuest.Location = new System.Drawing.Point(144, 31);
            this.textBox_nameGuest.Name = "textBox_nameGuest";
            this.textBox_nameGuest.Size = new System.Drawing.Size(480, 26);
            this.textBox_nameGuest.TabIndex = 1;
            // 
            // label_dateBDGuest
            // 
            this.label_dateBDGuest.AutoSize = true;
            this.label_dateBDGuest.Location = new System.Drawing.Point(6, 66);
            this.label_dateBDGuest.Name = "label_dateBDGuest";
            this.label_dateBDGuest.Size = new System.Drawing.Size(115, 19);
            this.label_dateBDGuest.TabIndex = 1;
            this.label_dateBDGuest.Text = "Дата рождения:";
            // 
            // label_nameGuest
            // 
            this.label_nameGuest.AutoSize = true;
            this.label_nameGuest.Location = new System.Drawing.Point(6, 34);
            this.label_nameGuest.Name = "label_nameGuest";
            this.label_nameGuest.Size = new System.Drawing.Size(132, 19);
            this.label_nameGuest.TabIndex = 0;
            this.label_nameGuest.Text = "Полное имя гостя:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_close);
            this.groupBox2.Controls.Add(this.button_addGuest);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Действия";
            // 
            // button_close
            // 
            this.button_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_close.Location = new System.Drawing.Point(105, 25);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(90, 32);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "Закрыть";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_addGuest
            // 
            this.button_addGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addGuest.Location = new System.Drawing.Point(9, 25);
            this.button_addGuest.Name = "button_addGuest";
            this.button_addGuest.Size = new System.Drawing.Size(90, 32);
            this.button_addGuest.TabIndex = 3;
            this.button_addGuest.Text = "Добавить";
            this.button_addGuest.UseVisualStyleBackColor = true;
            this.button_addGuest.Click += new System.EventHandler(this.button_addGuest_Click);
            // 
            // AddGuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 191);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AddGuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма добавления гостя";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_nameGuest;
        private System.Windows.Forms.Label label_dateBDGuest;
        private System.Windows.Forms.Label label_nameGuest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_addGuest;
        private System.Windows.Forms.DateTimePicker dateTimePicker_bd;
    }
}