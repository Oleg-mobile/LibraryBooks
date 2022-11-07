namespace LibraryBooks.Forms
{
    partial class FormBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBooks));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.buttonRead = new System.Windows.Forms.Button();
            this.buttonBookInfo = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.radioButtonIsFinished = new System.Windows.Forms.RadioButton();
            this.radioButtonIsLiked = new System.Windows.Forms.RadioButton();
            this.radioButtonClearFilter = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(30, 30);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(140, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(30, 70);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(140, 30);
            this.buttonDel.TabIndex = 1;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(30, 110);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(140, 30);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(200, 70);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowTemplate.Height = 25;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(630, 340);
            this.dataGridViewBooks.TabIndex = 3;
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(30, 150);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(140, 30);
            this.buttonRead.TabIndex = 5;
            this.buttonRead.Text = "Читать";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // buttonBookInfo
            // 
            this.buttonBookInfo.Location = new System.Drawing.Point(30, 190);
            this.buttonBookInfo.Name = "buttonBookInfo";
            this.buttonBookInfo.Size = new System.Drawing.Size(140, 30);
            this.buttonBookInfo.TabIndex = 6;
            this.buttonBookInfo.Text = "О книге";
            this.buttonBookInfo.UseVisualStyleBackColor = true;
            this.buttonBookInfo.Click += new System.EventHandler(this.buttonBookInfo_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(630, 30);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(200, 23);
            this.textBoxKeyword.TabIndex = 7;
            this.textBoxKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKeyword_KeyDown);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.Image")));
            this.pictureBoxSearch.Location = new System.Drawing.Point(590, 27);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSearch.TabIndex = 8;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // radioButtonIsFinished
            // 
            this.radioButtonIsFinished.AutoSize = true;
            this.radioButtonIsFinished.Location = new System.Drawing.Point(341, 35);
            this.radioButtonIsFinished.Name = "radioButtonIsFinished";
            this.radioButtonIsFinished.Size = new System.Drawing.Size(102, 19);
            this.radioButtonIsFinished.TabIndex = 9;
            this.radioButtonIsFinished.TabStop = true;
            this.radioButtonIsFinished.Text = "Прочитанные";
            this.radioButtonIsFinished.UseVisualStyleBackColor = true;
            this.radioButtonIsFinished.Click += new System.EventHandler(this.radioButtonIsFinished_Click);
            // 
            // radioButtonIsLiked
            // 
            this.radioButtonIsLiked.AutoSize = true;
            this.radioButtonIsLiked.Location = new System.Drawing.Point(461, 35);
            this.radioButtonIsLiked.Name = "radioButtonIsLiked";
            this.radioButtonIsLiked.Size = new System.Drawing.Size(116, 19);
            this.radioButtonIsLiked.TabIndex = 10;
            this.radioButtonIsLiked.TabStop = true;
            this.radioButtonIsLiked.Text = "Понравившиеся";
            this.radioButtonIsLiked.UseVisualStyleBackColor = true;
            this.radioButtonIsLiked.Click += new System.EventHandler(this.radioButtonIsLiked_Click);
            // 
            // radioButtonClearFilter
            // 
            this.radioButtonClearFilter.AutoSize = true;
            this.radioButtonClearFilter.Location = new System.Drawing.Point(200, 34);
            this.radioButtonClearFilter.Name = "radioButtonClearFilter";
            this.radioButtonClearFilter.Size = new System.Drawing.Size(122, 19);
            this.radioButtonClearFilter.TabIndex = 11;
            this.radioButtonClearFilter.TabStop = true;
            this.radioButtonClearFilter.Text = "Сбросить фильтр";
            this.radioButtonClearFilter.UseVisualStyleBackColor = true;
            this.radioButtonClearFilter.Click += new System.EventHandler(this.radioButtonClearFilter_Click);
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 441);
            this.Controls.Add(this.radioButtonClearFilter);
            this.Controls.Add(this.radioButtonIsLiked);
            this.Controls.Add(this.radioButtonIsFinished);
            this.Controls.Add(this.pictureBoxSearch);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.buttonBookInfo);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormBooks";
            this.Text = "Книги";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonBookInfo;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.RadioButton radioButtonIsFinished;
        private System.Windows.Forms.RadioButton radioButtonIsLiked;
        private System.Windows.Forms.RadioButton radioButtonClearFilter;
    }
}