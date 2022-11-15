namespace LibraryBooks.Forms
{
    partial class FormPasswordChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPasswordChange));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPasswordRepeat = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureBoxVis = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите старый пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите новый пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Повторите новый пароль";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(97, 50);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(180, 23);
            this.textBoxOldPassword.TabIndex = 3;
            this.textBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(97, 100);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(180, 23);
            this.textBoxNewPassword.TabIndex = 4;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxNewPasswordRepeat
            // 
            this.textBoxNewPasswordRepeat.Location = new System.Drawing.Point(97, 150);
            this.textBoxNewPasswordRepeat.Name = "textBoxNewPasswordRepeat";
            this.textBoxNewPasswordRepeat.Size = new System.Drawing.Size(180, 23);
            this.textBoxNewPasswordRepeat.TabIndex = 5;
            this.textBoxNewPasswordRepeat.UseSystemPasswordChar = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(97, 200);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(180, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBoxVis
            // 
            this.pictureBoxVis.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxVis.Image")));
            this.pictureBoxVis.Location = new System.Drawing.Point(289, 50);
            this.pictureBoxVis.Name = "pictureBoxVis";
            this.pictureBoxVis.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxVis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxVis.TabIndex = 7;
            this.pictureBoxVis.TabStop = false;
            this.pictureBoxVis.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.pictureBoxVis);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNewPasswordRepeat);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxOldPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPasswordChange";
            this.Text = "Библиотека  / Смена пароля";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxOldPassword;
        public System.Windows.Forms.TextBox textBoxNewPassword;
        public System.Windows.Forms.TextBox textBoxNewPasswordRepeat;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureBoxVis;
    }
}