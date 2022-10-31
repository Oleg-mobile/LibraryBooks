namespace LibraryBooks.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonGenres = new System.Windows.Forms.Button();
            this.buttonAuthors = new System.Windows.Forms.Button();
            this.buttonBooks = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonGenres);
            this.panel1.Controls.Add(this.buttonAuthors);
            this.panel1.Controls.Add(this.buttonBooks);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 611);
            this.panel1.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(0, 410);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.buttonExit.Size = new System.Drawing.Size(260, 70);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonGenres
            // 
            this.buttonGenres.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGenres.FlatAppearance.BorderSize = 0;
            this.buttonGenres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenres.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenres.Image")));
            this.buttonGenres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenres.Location = new System.Drawing.Point(0, 340);
            this.buttonGenres.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenres.Name = "buttonGenres";
            this.buttonGenres.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.buttonGenres.Size = new System.Drawing.Size(260, 70);
            this.buttonGenres.TabIndex = 3;
            this.buttonGenres.Text = "Жанры";
            this.buttonGenres.UseVisualStyleBackColor = true;
            this.buttonGenres.Click += new System.EventHandler(this.buttonGenres_Click);
            // 
            // buttonAuthors
            // 
            this.buttonAuthors.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAuthors.FlatAppearance.BorderSize = 0;
            this.buttonAuthors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuthors.Image = ((System.Drawing.Image)(resources.GetObject("buttonAuthors.Image")));
            this.buttonAuthors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAuthors.Location = new System.Drawing.Point(0, 270);
            this.buttonAuthors.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAuthors.Name = "buttonAuthors";
            this.buttonAuthors.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.buttonAuthors.Size = new System.Drawing.Size(260, 70);
            this.buttonAuthors.TabIndex = 2;
            this.buttonAuthors.Text = "Авторы";
            this.buttonAuthors.UseVisualStyleBackColor = true;
            this.buttonAuthors.Click += new System.EventHandler(this.buttonAuthors_Click);
            // 
            // buttonBooks
            // 
            this.buttonBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBooks.FlatAppearance.BorderSize = 0;
            this.buttonBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBooks.Image = ((System.Drawing.Image)(resources.GetObject("buttonBooks.Image")));
            this.buttonBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBooks.Location = new System.Drawing.Point(0, 200);
            this.buttonBooks.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBooks.Name = "buttonBooks";
            this.buttonBooks.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.buttonBooks.Size = new System.Drawing.Size(260, 70);
            this.buttonBooks.TabIndex = 0;
            this.buttonBooks.Text = "Книги";
            this.buttonBooks.UseVisualStyleBackColor = true;
            this.buttonBooks.Click += new System.EventHandler(this.buttonBooks_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 200);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(51, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Моя библиотека";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelContent.Location = new System.Drawing.Point(260, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1124, 611);
            this.panelContent.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 611);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Библиотека";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBooks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGenres;
        private System.Windows.Forms.Button buttonAuthors;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonExit;
    }
}