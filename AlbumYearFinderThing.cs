using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
			albums = new List<string>() { };

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

			foreach (string song in songs)
			{
				string songInfo = "";
				TagLib.File songFile = TagLib.File.Create(song);
				if (songFile.Tag.FirstPerformer != null)
				{
					songInfo += songFile.Tag.FirstPerformer.ToString();
					songInfo += " - ";
				}
				if (songFile.Tag.Album != null)
				{
					songInfo += songFile.Tag.Album.ToString();
					songInfo += " - ";
				}
				if (songFile.Tag.Year != null)
				{
					songInfo += songFile.Tag.Year.ToString();
				}
				albums.Sort();

				if (songFile.Tag.Year.ToString() == txt_Album_Year.Text && albums.Contains(songInfo) == false)
				{
					albums.Add(songInfo);
					songInfo = "";
				}
			}
		}

		private void listBox_Albums_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedAlbums = "";
			foreach (object item in listBox_Albums.Items) selectedAlbums += item.ToString() + "\r\n";
			Clipboard.SetText(selectedAlbums);
		}
	}
}
