namespace LibraryBooks.Forms
{
    partial class FormAboutBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutBook));
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelPublication = new System.Windows.Forms.Label();
            this.labelYaer = new System.Windows.Forms.Label();
            this.labelMark = new System.Windows.Forms.Label();
            this.labelPageCount = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelIsFinished = new System.Windows.Forms.Label();
            this.labelIsLiked = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(234, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название: ";
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCover.Image")));
            this.pictureBoxCover.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(181, 222);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCover.TabIndex = 1;
            this.pictureBoxCover.TabStop = false;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(234, 71);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(46, 15);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Автор: ";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(234, 108);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(44, 15);
            this.labelGenre.TabIndex = 3;
            this.labelGenre.Text = "Жанр: ";
            // 
            // labelPublication
            // 
            this.labelPublication.AutoSize = true;
            this.labelPublication.Location = new System.Drawing.Point(234, 144);
            this.labelPublication.Name = "labelPublication";
            this.labelPublication.Size = new System.Drawing.Size(59, 15);
            this.labelPublication.TabIndex = 4;
            this.labelPublication.Text = "Издание: ";
            // 
            // labelYaer
            // 
            this.labelYaer.AutoSize = true;
            this.labelYaer.Location = new System.Drawing.Point(234, 184);
            this.labelYaer.Name = "labelYaer";
            this.labelYaer.Size = new System.Drawing.Size(81, 15);
            this.labelYaer.TabIndex = 5;
            this.labelYaer.Text = "Год выпуска: ";
            // 
            // labelMark
            // 
            this.labelMark.AutoSize = true;
            this.labelMark.Location = new System.Drawing.Point(12, 266);
            this.labelMark.Name = "labelMark";
            this.labelMark.Size = new System.Drawing.Size(133, 15);
            this.labelMark.TabIndex = 6;
            this.labelMark.Text = "Закладка на странице: ";
            // 
            // labelPageCount
            // 
            this.labelPageCount.AutoSize = true;
            this.labelPageCount.Location = new System.Drawing.Point(234, 219);
            this.labelPageCount.Name = "labelPageCount";
            this.labelPageCount.Size = new System.Drawing.Size(126, 15);
            this.labelPageCount.TabIndex = 7;
            this.labelPageCount.Text = "Количество страниц: ";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 310);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(55, 15);
            this.labelPath.TabIndex = 8;
            this.labelPath.Text = "Ссылка: ";
            // 
            // labelIsFinished
            // 
            this.labelIsFinished.AutoSize = true;
            this.labelIsFinished.Location = new System.Drawing.Point(12, 348);
            this.labelIsFinished.Name = "labelIsFinished";
            this.labelIsFinished.Size = new System.Drawing.Size(49, 15);
            this.labelIsFinished.TabIndex = 9;
            this.labelIsFinished.Text = "Статус: ";
            // 
            // labelIsLiked
            // 
            this.labelIsLiked.AutoSize = true;
            this.labelIsLiked.Location = new System.Drawing.Point(12, 386);
            this.labelIsLiked.Name = "labelIsLiked";
            this.labelIsLiked.Size = new System.Drawing.Size(54, 15);
            this.labelIsLiked.TabIndex = 10;
            this.labelIsLiked.Text = "Оценка: ";
            this.labelIsLiked.Visible = false;
            // 
            // FormAboutBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 441);
            this.Controls.Add(this.labelIsLiked);
            this.Controls.Add(this.labelIsFinished);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelPageCount);
            this.Controls.Add(this.labelMark);
            this.Controls.Add(this.labelYaer);
            this.Controls.Add(this.labelPublication);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.labelName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAboutBook";
            this.Text = "Библиотека  / О книге";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelPublication;
        private System.Windows.Forms.Label labelYaer;
        private System.Windows.Forms.Label labelMark;
        private System.Windows.Forms.Label labelPageCount;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelIsFinished;
        private System.Windows.Forms.Label labelIsLiked;
    }
}