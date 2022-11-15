namespace LibraryBooks.Forms
{
    partial class FormNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotification));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNotificationCaption = new System.Windows.Forms.Label();
            this.pictureBoxNotification = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelNotificationText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.labelNotificationCaption);
            this.panel1.Controls.Add(this.pictureBoxNotification);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 100);
            this.panel1.TabIndex = 0;
            // 
            // labelNotificationCaption
            // 
            this.labelNotificationCaption.AutoSize = true;
            this.labelNotificationCaption.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNotificationCaption.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNotificationCaption.Location = new System.Drawing.Point(123, 31);
            this.labelNotificationCaption.Name = "labelNotificationCaption";
            this.labelNotificationCaption.Size = new System.Drawing.Size(90, 37);
            this.labelNotificationCaption.TabIndex = 3;
            this.labelNotificationCaption.Text = "label1";
            // 
            // pictureBoxNotification
            // 
            this.pictureBoxNotification.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxNotification.Name = "pictureBoxNotification";
            this.pictureBoxNotification.Size = new System.Drawing.Size(100, 73);
            this.pictureBoxNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNotification.TabIndex = 0;
            this.pictureBoxNotification.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 40);
            this.panel2.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOk.Location = new System.Drawing.Point(123, 164);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(140, 30);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelNotificationText
            // 
            this.labelNotificationText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNotificationText.AutoSize = true;
            this.labelNotificationText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNotificationText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNotificationText.Location = new System.Drawing.Point(111, 116);
            this.labelNotificationText.Name = "labelNotificationText";
            this.labelNotificationText.Size = new System.Drawing.Size(62, 25);
            this.labelNotificationText.TabIndex = 3;
            this.labelNotificationText.Text = "label1";
            // 
            // FormNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.labelNotificationText);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Библиотека / Уведомление";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelNotificationCaption;
        private System.Windows.Forms.PictureBox pictureBoxNotification;
        private System.Windows.Forms.Label labelNotificationText;
    }
}