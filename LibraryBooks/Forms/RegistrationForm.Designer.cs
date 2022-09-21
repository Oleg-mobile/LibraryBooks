namespace LibraryBooks.Forms
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRepeat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxPassVis = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassVis)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(54, 200);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(180, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(54, 50);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(54, 100);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(180, 23);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPasswordRepeat
            // 
            this.textBoxPasswordRepeat.Location = new System.Drawing.Point(54, 150);
            this.textBoxPasswordRepeat.Name = "textBoxPasswordRepeat";
            this.textBoxPasswordRepeat.Size = new System.Drawing.Size(180, 23);
            this.textBoxPasswordRepeat.TabIndex = 3;
            this.textBoxPasswordRepeat.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите лигин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Повторите пароль:";
            // 
            // pictureBoxPassVis
            // 
            this.pictureBoxPassVis.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPassVis.Image")));
            this.pictureBoxPassVis.Location = new System.Drawing.Point(248, 100);
            this.pictureBoxPassVis.Name = "pictureBoxPassVis";
            this.pictureBoxPassVis.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxPassVis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPassVis.TabIndex = 7;
            this.pictureBoxPassVis.TabStop = false;
            this.pictureBoxPassVis.Click += new System.EventHandler(this.pictureBoxPassVis_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBoxPassVis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPasswordRepeat);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonAdd);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassVis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPasswordRepeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxPassVis;
    }
}