
namespace Film_Festival_App
{
    partial class AddCinemaFestForm
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
            this.textBox_nameFest = new System.Windows.Forms.TextBox();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.label_nameFest = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_addFest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_nameFest);
            this.groupBox1.Controls.Add(this.textBox_location);
            this.groupBox1.Controls.Add(this.label_location);
            this.groupBox1.Controls.Add(this.label_nameFest);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление кинофестиваля";
            // 
            // textBox_nameFest
            // 
            this.textBox_nameFest.Location = new System.Drawing.Point(194, 31);
            this.textBox_nameFest.Name = "textBox_nameFest";
            this.textBox_nameFest.Size = new System.Drawing.Size(430, 26);
            this.textBox_nameFest.TabIndex = 1;
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(194, 63);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(430, 26);
            this.textBox_location.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(6, 66);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(139, 19);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "Место проведения:";
            // 
            // label_nameFest
            // 
            this.label_nameFest.AutoSize = true;
            this.label_nameFest.Location = new System.Drawing.Point(6, 34);
            this.label_nameFest.Name = "label_nameFest";
            this.label_nameFest.Size = new System.Drawing.Size(182, 19);
            this.label_nameFest.TabIndex = 0;
            this.label_nameFest.Text = "Название кинофестиваля:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_close);
            this.groupBox2.Controls.Add(this.button_addFest);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 67);
            this.groupBox2.TabIndex = 1;
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
            // button_addFest
            // 
            this.button_addFest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addFest.Location = new System.Drawing.Point(9, 25);
            this.button_addFest.Name = "button_addFest";
            this.button_addFest.Size = new System.Drawing.Size(90, 32);
            this.button_addFest.TabIndex = 3;
            this.button_addFest.Text = "Добавить";
            this.button_addFest.UseVisualStyleBackColor = true;
            this.button_addFest.Click += new System.EventHandler(this.button_addFest_Click);
            // 
            // AddCinemaFestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 191);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddCinemaFestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление кинофестиваля";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_nameFest;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Label label_nameFest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_addFest;
    }
}