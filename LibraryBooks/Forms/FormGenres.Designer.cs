namespace LibraryBooks.Forms
{
    partial class FormGenres
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
            this.dataGridViewGenres = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGenres
            // 
            this.dataGridViewGenres.AllowUserToAddRows = false;
            this.dataGridViewGenres.AllowUserToDeleteRows = false;
            this.dataGridViewGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGenres.Location = new System.Drawing.Point(192, 36);
            this.dataGridViewGenres.Name = "dataGridViewGenres";
            this.dataGridViewGenres.ReadOnly = true;
            this.dataGridViewGenres.RowTemplate.Height = 25;
            this.dataGridViewGenres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGenres.Size = new System.Drawing.Size(319, 324);
            this.dataGridViewGenres.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(50, 36);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(50, 83);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(50, 133);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // FormGenres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewGenres);
            this.Name = "FormGenres";
            this.Text = "FormGenres";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGenres;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonEdit;
    }
}