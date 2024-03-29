﻿namespace LibraryBooks.Forms
{
    partial class FormBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBook));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxReader = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBoxPathToCover = new System.Windows.Forms.PictureBox();
            this.pictureBoxPathToBook = new System.Windows.Forms.PictureBox();
            this.textBoxPathToCover = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBoxGenre = new System.Windows.Forms.PictureBox();
            this.pictureBoxAuthor = new System.Windows.Forms.PictureBox();
            this.checkBoxIsFinished = new System.Windows.Forms.CheckBox();
            this.checkBoxIsLiked = new System.Windows.Forms.CheckBox();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.textBoxPathToBook = new System.Windows.Forms.TextBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.textBoxPageCount = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxPublication = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPathToCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPathToBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxReader);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.pictureBoxPathToCover);
            this.groupBox1.Controls.Add(this.pictureBoxPathToBook);
            this.groupBox1.Controls.Add(this.textBoxPathToCover);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pictureBoxGenre);
            this.groupBox1.Controls.Add(this.pictureBoxAuthor);
            this.groupBox1.Controls.Add(this.checkBoxIsFinished);
            this.groupBox1.Controls.Add(this.checkBoxIsLiked);
            this.groupBox1.Controls.Add(this.textBoxMark);
            this.groupBox1.Controls.Add(this.textBoxPathToBook);
            this.groupBox1.Controls.Add(this.comboBoxGenre);
            this.groupBox1.Controls.Add(this.textBoxPageCount);
            this.groupBox1.Controls.Add(this.textBoxYear);
            this.groupBox1.Controls.Add(this.textBoxPublication);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxAuthor);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 455);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Книга";
            // 
            // comboBoxReader
            // 
            this.comboBoxReader.FormattingEnabled = true;
            this.comboBoxReader.Location = new System.Drawing.Point(45, 310);
            this.comboBoxReader.Name = "comboBoxReader";
            this.comboBoxReader.Size = new System.Drawing.Size(180, 23);
            this.comboBoxReader.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Читалка";
            // 
            // pictureBoxPathToCover
            // 
            this.pictureBoxPathToCover.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPathToCover.Image")));
            this.pictureBoxPathToCover.Location = new System.Drawing.Point(605, 160);
            this.pictureBoxPathToCover.Name = "pictureBoxPathToCover";
            this.pictureBoxPathToCover.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxPathToCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPathToCover.TabIndex = 29;
            this.pictureBoxPathToCover.TabStop = false;
            this.pictureBoxPathToCover.Click += new System.EventHandler(this.pictureBoxPathToCover_Click);
            // 
            // pictureBoxPathToBook
            // 
            this.pictureBoxPathToBook.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPathToBook.Image")));
            this.pictureBoxPathToBook.Location = new System.Drawing.Point(605, 110);
            this.pictureBoxPathToBook.Name = "pictureBoxPathToBook";
            this.pictureBoxPathToBook.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxPathToBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPathToBook.TabIndex = 28;
            this.pictureBoxPathToBook.TabStop = false;
            this.pictureBoxPathToBook.Click += new System.EventHandler(this.pictureBoxPathToBook_Click);
            // 
            // textBoxPathToCover
            // 
            this.textBoxPathToCover.Location = new System.Drawing.Point(410, 160);
            this.textBoxPathToCover.Name = "textBoxPathToCover";
            this.textBoxPathToCover.ReadOnly = true;
            this.textBoxPathToCover.Size = new System.Drawing.Size(180, 23);
            this.textBoxPathToCover.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(410, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Путь до обложки";
            // 
            // pictureBoxGenre
            // 
            this.pictureBoxGenre.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGenre.Image")));
            this.pictureBoxGenre.Location = new System.Drawing.Point(242, 258);
            this.pictureBoxGenre.Name = "pictureBoxGenre";
            this.pictureBoxGenre.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxGenre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGenre.TabIndex = 24;
            this.pictureBoxGenre.TabStop = false;
            this.pictureBoxGenre.Click += new System.EventHandler(this.pictureBoxGenre_Click);
            // 
            // pictureBoxAuthor
            // 
            this.pictureBoxAuthor.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAuthor.Image")));
            this.pictureBoxAuthor.Location = new System.Drawing.Point(242, 110);
            this.pictureBoxAuthor.Name = "pictureBoxAuthor";
            this.pictureBoxAuthor.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAuthor.TabIndex = 23;
            this.pictureBoxAuthor.TabStop = false;
            this.pictureBoxAuthor.Click += new System.EventHandler(this.pictureBoxAuthor_Click);
            // 
            // checkBoxIsFinished
            // 
            this.checkBoxIsFinished.AutoSize = true;
            this.checkBoxIsFinished.Location = new System.Drawing.Point(410, 317);
            this.checkBoxIsFinished.Name = "checkBoxIsFinished";
            this.checkBoxIsFinished.Size = new System.Drawing.Size(87, 19);
            this.checkBoxIsFinished.TabIndex = 22;
            this.checkBoxIsFinished.Text = "Прочитана";
            this.checkBoxIsFinished.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsLiked
            // 
            this.checkBoxIsLiked.AutoSize = true;
            this.checkBoxIsLiked.Location = new System.Drawing.Point(410, 264);
            this.checkBoxIsLiked.Name = "checkBoxIsLiked";
            this.checkBoxIsLiked.Size = new System.Drawing.Size(100, 19);
            this.checkBoxIsLiked.TabIndex = 21;
            this.checkBoxIsLiked.Text = "Понравилась";
            this.checkBoxIsLiked.UseVisualStyleBackColor = true;
            // 
            // textBoxMark
            // 
            this.textBoxMark.Location = new System.Drawing.Point(410, 210);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(180, 23);
            this.textBoxMark.TabIndex = 20;
            this.textBoxMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntegerMask_KeyPress);
            // 
            // textBoxPathToBook
            // 
            this.textBoxPathToBook.Location = new System.Drawing.Point(410, 110);
            this.textBoxPathToBook.Name = "textBoxPathToBook";
            this.textBoxPathToBook.ReadOnly = true;
            this.textBoxPathToBook.Size = new System.Drawing.Size(180, 23);
            this.textBoxPathToBook.TabIndex = 19;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(45, 260);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(180, 23);
            this.comboBoxGenre.TabIndex = 17;
            // 
            // textBoxPageCount
            // 
            this.textBoxPageCount.Location = new System.Drawing.Point(410, 60);
            this.textBoxPageCount.Name = "textBoxPageCount";
            this.textBoxPageCount.Size = new System.Drawing.Size(180, 23);
            this.textBoxPageCount.TabIndex = 16;
            this.textBoxPageCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntegerMask_KeyPress);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(45, 210);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(180, 23);
            this.textBoxYear.TabIndex = 15;
            this.textBoxYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntegerMask_KeyPress);
            // 
            // textBoxPublication
            // 
            this.textBoxPublication.Location = new System.Drawing.Point(45, 160);
            this.textBoxPublication.Name = "textBoxPublication";
            this.textBoxPublication.Size = new System.Drawing.Size(180, 23);
            this.textBoxPublication.TabIndex = 14;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(45, 60);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 23);
            this.textBoxName.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(410, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Закладка";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Путь до книги";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Жанр";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Количество страниц";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Год выпуска";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Издание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Автор";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // comboBoxAuthor
            // 
            this.comboBoxAuthor.FormattingEnabled = true;
            this.comboBoxAuthor.Location = new System.Drawing.Point(45, 110);
            this.comboBoxAuthor.Name = "comboBoxAuthor";
            this.comboBoxAuthor.Size = new System.Drawing.Size(180, 23);
            this.comboBoxAuthor.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(45, 360);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(180, 30);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 481);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBook";
            this.Text = "Библиотека  / Книга";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPathToCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPathToBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.ComboBox comboBoxAuthor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.TextBox textBoxPublication;
        public System.Windows.Forms.TextBox textBoxYear;
        public System.Windows.Forms.TextBox textBoxPageCount;
        public System.Windows.Forms.ComboBox comboBoxGenre;
        public System.Windows.Forms.TextBox textBoxMark;
        public System.Windows.Forms.TextBox textBoxPathToBook;
        public System.Windows.Forms.CheckBox checkBoxIsFinished;
        public System.Windows.Forms.CheckBox checkBoxIsLiked;
        private System.Windows.Forms.PictureBox pictureBoxGenre;
        private System.Windows.Forms.PictureBox pictureBoxAuthor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBoxPathToCover;
        private System.Windows.Forms.PictureBox pictureBoxPathToBook;
        public System.Windows.Forms.TextBox textBoxPathToCover;
        public System.Windows.Forms.ComboBox comboBoxReader;
        private System.Windows.Forms.Label label12;
    }
}