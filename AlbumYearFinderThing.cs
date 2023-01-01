using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace AlbumYearFinderThing
{
	public partial class AlbumYearFinderThing : Form
	{

		List<string> albums = new List<string>() { };

		public AlbumYearFinderThing()
		{
			InitializeComponent();
			loadingBox.Enabled = false;
			loadingBox.Visible = false;
			txt_MusicPath.Text = @"H:\Music";
			txt_Album_Year.Text = DateTime.Today.Year.ToString();
		}

		private void btn_Set_Music_Path_Click(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_MusicPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void btn_Peruse_Click(object sender, EventArgs e)
		{
			listBox_Albums.Items.Clear();
			txt_Album_Year.Text = txt_Album_Year.Text.Trim();
			albums = new List<string>();
			albums.Add(txt_Album_Year.Text);

			foreach (Control ctrl in this.Controls)
			{
				ctrl.Enabled = false;
			}

			loadingBox.ImageLocation = "images/slowpoke loading.gif";
			loadingBox.Visible = true;
			loadingBox.Enabled = true;

			BackgroundWorker queryWorker = new BackgroundWorker();
			queryWorker.DoWork += new DoWorkEventHandler(queryWorker_DoWork);
			queryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(queryWorker_RunWorkerCompleted);
			queryWorker.RunWorkerAsync();
		}

		private void queryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			foreach (Control ctrl in this.Controls)
			{
				ctrl.Enabled = true;
			}
			loadingBox.Enabled = false;
			loadingBox.Visible = false;

			listBox_Albums.Invoke((MethodInvoker)(() => listBox_Albums.Items.AddRange(albums.ToArray())));
		}

		private void queryWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			string[] songs = Directory.GetFiles(txt_MusicPath.Text, "*.mp3", SearchOption.AllDirectories);
			List<string> skipDirs = new List<string>();

			foreach (string song in songs)
			{
				if (skipDirs.Contains(Path.GetDirectoryName(song)))
				{ continue; }

				StringBuilder songInfo = new StringBuilder();
				TagLib.File songFile = TagLib.File.Create(song);

				if (!songFile.Tag.Year.ToString().Equals(txt_Album_Year.Text))
				{
					skipDirs.Add(Path.GetDirectoryName(song));
					continue;
				}

				if (!string.IsNullOrEmpty(songFile.Tag.FirstPerformer))
				{
					songInfo.Append($"{songFile.Tag.FirstPerformer} - ");
				}
				if (!string.IsNullOrEmpty(songFile.Tag.Album))
				{
					songInfo.Append(songFile.Tag.Album);
				}

				string album = songInfo.ToString();
				if (!albums.Contains(album))
				{
					albums.Add(album);
				}
			}

			albums.Sort();
		}

		private void listBox_Albums_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedAlbums = "";
			foreach (object item in listBox_Albums.Items) selectedAlbums += item.ToString() + "\r\n";
			Clipboard.SetText(selectedAlbums);
		}
	}
}
