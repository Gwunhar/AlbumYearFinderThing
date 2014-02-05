using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using TagLib;
using System.Linq;

namespace AlbumYearFinderThing
{
	public partial class AlbumYearFinderThing : Form
	{
		public AlbumYearFinderThing()
		{
			InitializeComponent();
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
			string[] bandDirectories = Directory.GetDirectories(txt_MusicPath.Text);
			List<string> albums = new List<string>() { };

			foreach (string bandFolder in bandDirectories)
			{
				string[] albumFolders = Directory.GetDirectories(bandFolder);
				foreach (string albumFolder in albumFolders)
				{
					string[] songs = Directory.GetFiles(albumFolder, "*.mp3");
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
			}
			listBox_Albums.Items.AddRange(albums.ToArray());
		}

		private void listBox_Albums_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedAlbums = "";
			foreach (object item in listBox_Albums.Items) selectedAlbums += item.ToString() + "\r\n";
			Clipboard.SetText(selectedAlbums);
		}
	}
}
