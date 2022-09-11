namespace LibraryBooks.Forms
{
    partial class BookForm
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
            this.checkBoxIsFinished = new System.Windows.Forms.CheckBox();
            this.checkBoxIsLiked = new System.Windows.Forms.CheckBox();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.textBoxPathToBook = new System.Windows.Forms.TextBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.textBoxPageCount = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxPublication = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxIsFinished);
            this.groupBox1.Controls.Add(this.checkBoxIsLiked);
            this.groupBox1.Controls.Add(this.textBoxMark);
            this.groupBox1.Controls.Add(this.textBoxPathToBook);
            this.groupBox1.Controls.Add(this.comboBoxUser);
            this.groupBox1.Controls.Add(this.comboBoxGenre);
            this.groupBox1.Controls.Add(this.textBoxPageCount);
            this.groupBox1.Controls.Add(this.textBoxYear);
            this.groupBox1.Controls.Add(this.textBoxPublication);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
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
            // checkBoxIsFinished
            // 
            this.checkBoxIsFinished.AutoSize = true;
            this.checkBoxIsFinished.Location = new System.Drawing.Point(410, 262);
            this.checkBoxIsFinished.Name = "checkBoxIsFinished";
            this.checkBoxIsFinished.Size = new System.Drawing.Size(87, 19);
            this.checkBoxIsFinished.TabIndex = 22;
            this.checkBoxIsFinished.Text = "Прочитана";
            this.checkBoxIsFinished.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsLiked
            // 
            this.checkBoxIsLiked.AutoSize = true;
            this.checkBoxIsLiked.Location = new System.Drawing.Point(410, 214);
            this.checkBoxIsLiked.Name = "checkBoxIsLiked";
            this.checkBoxIsLiked.Size = new System.Drawing.Size(100, 19);
            this.checkBoxIsLiked.TabIndex = 21;
            this.checkBoxIsLiked.Text = "Понравилась";
            this.checkBoxIsLiked.UseVisualStyleBackColor = true;
            // 
            // textBoxMark
            // 
            this.textBoxMark.Location = new System.Drawing.Point(410, 160);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(180, 23);
            this.textBoxMark.TabIndex = 20;
            this.textBoxMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntegerMask_KeyPress);
            // 
            // textBoxPathToBook
            // 
            this.textBoxPathToBook.Location = new System.Drawing.Point(410, 110);
            this.textBoxPathToBook.Name = "textBoxPathToBook";
            this.textBoxPathToBook.Size = new System.Drawing.Size(180, 23);
            this.textBoxPathToBook.TabIndex = 19;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(410, 60);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(180, 23);
            this.comboBoxUser.TabIndex = 18;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(45, 310);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(180, 23);
            this.comboBoxGenre.TabIndex = 17;
            // 
            // textBoxPageCount
            // 
            this.textBoxPageCount.Location = new System.Drawing.Point(45, 260);
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
            this.label11.Location = new System.Drawing.Point(410, 140);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Пользователь";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Жанр";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 240);
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
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 481);
            this.Controls.Add(this.groupBox1);
            this.Name = "BookForm";
            this.Text = "Книга";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.ComboBox comboBoxAuthor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        public System.Windows.Forms.ComboBox comboBoxUser;
        public System.Windows.Forms.CheckBox checkBoxIsFinished;
        public System.Windows.Forms.CheckBox checkBoxIsLiked;
    }
}