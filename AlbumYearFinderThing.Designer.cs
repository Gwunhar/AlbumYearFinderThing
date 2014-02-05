namespace AlbumYearFinderThing
{
    partial class AlbumYearFinderThing
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
			this.btn_Set_Music_Path = new System.Windows.Forms.Button();
			this.lbl_Music_Path = new System.Windows.Forms.Label();
			this.txt_MusicPath = new System.Windows.Forms.TextBox();
			this.txt_Album_Year = new System.Windows.Forms.TextBox();
			this.lbl_Album_Year = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btn_Peruse = new System.Windows.Forms.Button();
			this.listBox_Albums = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btn_Set_Music_Path
			// 
			this.btn_Set_Music_Path.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Set_Music_Path.Location = new System.Drawing.Point(840, 31);
			this.btn_Set_Music_Path.Name = "btn_Set_Music_Path";
			this.btn_Set_Music_Path.Size = new System.Drawing.Size(37, 23);
			this.btn_Set_Music_Path.TabIndex = 0;
			this.btn_Set_Music_Path.Text = "...";
			this.btn_Set_Music_Path.UseVisualStyleBackColor = true;
			this.btn_Set_Music_Path.Click += new System.EventHandler(this.btn_Set_Music_Path_Click);
			// 
			// lbl_Music_Path
			// 
			this.lbl_Music_Path.AutoSize = true;
			this.lbl_Music_Path.Location = new System.Drawing.Point(32, 35);
			this.lbl_Music_Path.Name = "lbl_Music_Path";
			this.lbl_Music_Path.Size = new System.Drawing.Size(60, 13);
			this.lbl_Music_Path.TabIndex = 1;
			this.lbl_Music_Path.Text = "Music Path";
			// 
			// txt_MusicPath
			// 
			this.txt_MusicPath.Location = new System.Drawing.Point(98, 34);
			this.txt_MusicPath.Name = "txt_MusicPath";
			this.txt_MusicPath.Size = new System.Drawing.Size(736, 20);
			this.txt_MusicPath.TabIndex = 2;
			// 
			// txt_Album_Year
			// 
			this.txt_Album_Year.Location = new System.Drawing.Point(98, 75);
			this.txt_Album_Year.Name = "txt_Album_Year";
			this.txt_Album_Year.Size = new System.Drawing.Size(84, 20);
			this.txt_Album_Year.TabIndex = 4;
			// 
			// lbl_Album_Year
			// 
			this.lbl_Album_Year.AutoSize = true;
			this.lbl_Album_Year.Location = new System.Drawing.Point(32, 76);
			this.lbl_Album_Year.Name = "lbl_Album_Year";
			this.lbl_Album_Year.Size = new System.Drawing.Size(61, 13);
			this.lbl_Album_Year.TabIndex = 3;
			this.lbl_Album_Year.Text = "Album Year";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.SelectedPath = "E:\\Music";
			// 
			// btn_Peruse
			// 
			this.btn_Peruse.Location = new System.Drawing.Point(774, 66);
			this.btn_Peruse.Name = "btn_Peruse";
			this.btn_Peruse.Size = new System.Drawing.Size(103, 23);
			this.btn_Peruse.TabIndex = 5;
			this.btn_Peruse.Text = "Peruse Musics";
			this.btn_Peruse.UseVisualStyleBackColor = true;
			this.btn_Peruse.Click += new System.EventHandler(this.btn_Peruse_Click);
			// 
			// listBox_Albums
			// 
			this.listBox_Albums.FormattingEnabled = true;
			this.listBox_Albums.Location = new System.Drawing.Point(35, 101);
			this.listBox_Albums.Name = "listBox_Albums";
			this.listBox_Albums.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBox_Albums.Size = new System.Drawing.Size(842, 446);
			this.listBox_Albums.Sorted = true;
			this.listBox_Albums.TabIndex = 6;
			this.listBox_Albums.SelectedIndexChanged += new System.EventHandler(this.listBox_Albums_SelectedIndexChanged);
			// 
			// AlbumYearFinderThing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(916, 567);
			this.Controls.Add(this.listBox_Albums);
			this.Controls.Add(this.btn_Peruse);
			this.Controls.Add(this.txt_Album_Year);
			this.Controls.Add(this.lbl_Album_Year);
			this.Controls.Add(this.txt_MusicPath);
			this.Controls.Add(this.lbl_Music_Path);
			this.Controls.Add(this.btn_Set_Music_Path);
			this.Name = "AlbumYearFinderThing";
			this.Text = "Album Year Finder Thing";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Set_Music_Path;
        private System.Windows.Forms.Label lbl_Music_Path;
        private System.Windows.Forms.TextBox txt_MusicPath;
        private System.Windows.Forms.TextBox txt_Album_Year;
        private System.Windows.Forms.Label lbl_Album_Year;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button btn_Peruse;
		private System.Windows.Forms.ListBox listBox_Albums;
    }
}

