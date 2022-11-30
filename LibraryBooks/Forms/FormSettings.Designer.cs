namespace LibraryBooks.Forms
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonGetPath = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDell = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetPath
            // 
            this.buttonGetPath.Location = new System.Drawing.Point(25, 25);
            this.buttonGetPath.Name = "buttonGetPath";
            this.buttonGetPath.Size = new System.Drawing.Size(140, 30);
            this.buttonGetPath.TabIndex = 1;
            this.buttonGetPath.Text = "Выбрать читалку";
            this.buttonGetPath.UseVisualStyleBackColor = true;
            this.buttonGetPath.Click += new System.EventHandler(this.buttonGetPath_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(25, 70);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(384, 23);
            this.textBoxFilePath.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сменить пароль";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(25, 120);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(140, 30);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDell
            // 
            this.buttonDell.Location = new System.Drawing.Point(25, 170);
            this.buttonDell.Name = "buttonDell";
            this.buttonDell.Size = new System.Drawing.Size(140, 30);
            this.buttonDell.TabIndex = 5;
            this.buttonDell.Text = "Удалить";
            this.buttonDell.UseVisualStyleBackColor = true;
            this.buttonDell.Click += new System.EventHandler(this.buttonDell_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(25, 220);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(140, 30);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.AllowUserToAddRows = false;
            this.dataGridViewReaders.AllowUserToDeleteRows = false;
            this.dataGridViewReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Location = new System.Drawing.Point(188, 120);
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.ReadOnly = true;
            this.dataGridViewReaders.RowTemplate.Height = 25;
            this.dataGridViewReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReaders.Size = new System.Drawing.Size(221, 275);
            this.dataGridViewReaders.TabIndex = 7;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 441);
            this.Controls.Add(this.dataGridViewReaders);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDell);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonGetPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "Библиотека  / Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGetPath;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDell;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
    }
}