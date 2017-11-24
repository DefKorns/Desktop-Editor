using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop_Editor
{
    public partial class MainForm : Form
    {
        bool readyToEdit = false;

        public MainForm()
        {
            InitializeComponent();
            string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart";
            PopulateSNESListView(listViewGames, fullboxartPath, "*.desktop");
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void ButtonGetGames_Click(object sender, EventArgs e)
        {
            string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart";
            Process batch = new Process();
            batch.StartInfo.WorkingDirectory = Path.GetDirectoryName(@".\boxart_downloader\");
            batch.StartInfo.FileName = @"boxart.bat";
            batch.StartInfo.UseShellExecute = true;
            batch.Start();
            batch.WaitForExit();
            listViewGames.Items.Clear();
            if (radioButtonSNES.Checked)
            { 
            PopulateSNESListView(listViewGames, fullboxartPath, "*.desktop");
            }
            if (radioButtonNES.Checked)
            {
            PopulateNESListView(listViewGames, fullboxartPath, "*.desktop");
            }
        }
        private void listViewGames_MouseClick(object sender, MouseEventArgs e)
        {
            ShowSelected();
        }
        private void checkBoxOutpuDir_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOutpuDir.Checked)
            {
                if (!textBoxArguments.Text.Contains(" -output-dir /var/lib/clover/profiles/0/"))
                    textBoxArguments.AppendText(" -output-dir /var/lib/clover/profiles/0/");
            }
            else
            {
                textBoxArguments.Text = textBoxArguments.Text.Replace(" -output-dir /var/lib/clover/profiles/0/", "");
            }
        }
        private void checkBoxRetroarch_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBoxRetroarch.Checked)
            {
                if (!textBoxArguments.Text.Contains(" --retroarch"))

                    textBoxArguments.AppendText(" --retroarch");
            }
            else
            {
                textBoxArguments.Text = textBoxArguments.Text.Replace(" --retroarch", "");
            }
        }
        private void checkBoxNoLowLat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoLowLat.Checked)
            {
                if (!textBoxArguments.Text.Contains(" -no-lowlatency"))
                    textBoxArguments.AppendText(" -no-lowlatency");
            }
            else
            {
                textBoxArguments.Text = textBoxArguments.Text.Replace(" -no-lowlatency", "");
            }
        }
        private void checkBoxEpilepsy_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBoxEpilepsy.Checked)
            {
                if (!textBoxArguments.Text.Contains(" -fp 0"))
                    textBoxArguments.AppendText(" -fp 0");
            }
            else
            {
                textBoxArguments.Text = textBoxArguments.Text.Replace(" -fp 0", "");
            }
        }
        private void comboBoxVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullArguments = textBoxArguments.Text;
            int volumeArgsPosition = 0;
            string volumeArgument = "";
            if (fullArguments.Contains("--volume"))
            {
                volumeArgsPosition = fullArguments.IndexOf("--volume");
                volumeArgument = fullArguments.Substring(volumeArgsPosition);
            }
            if (comboBoxVol.SelectedItem.ToString().Equals("0"))
            {
                textBoxArguments.Text = textBoxArguments.Text.Replace(volumeArgument, "-no-audio ");
            }
            else
            {
                if (textBoxArguments.Text.Contains("-no-audio "))
                {
                    textBoxArguments.Text = textBoxArguments.Text.Replace("-no-audio ", "--volume " + comboBoxVol.SelectedItem.ToString() + " ");
                }
                else
                {
                    string[] volumethingy = volumeArgument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    textBoxArguments.Text = textBoxArguments.Text.Replace(volumethingy[0] + " " + volumethingy[1], "--volume " + comboBoxVol.SelectedItem.ToString());
                }
            }
        }
        private void ComboBoxBoostFX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullArguments = textBoxArguments.Text;
            int boostArgsPosition = 0;
            string boostArgument = "";
            if (fullArguments.Contains("-boost-fx"))
            {
                boostArgsPosition = fullArguments.IndexOf("-boost-fx");
                boostArgument = fullArguments.Substring(boostArgsPosition, 11);
            }
            if (comboBoxBoostFX.SelectedItem.ToString().Equals("0"))
            {
                string removeBoost = fullArguments.Replace(boostArgument, String.Empty);
                removeBoost = removeBoost.TrimEnd();
                textBoxArguments.Text = removeBoost;
            }
            else
            {
                if (textBoxArguments.Text.Contains(" -boost-fx "))
                {
                    textBoxArguments.Text = textBoxArguments.Text.Replace(boostArgument, "-boost-fx " + comboBoxBoostFX.SelectedItem.ToString() + " ");
                }
                else
                {
                    textBoxArguments.AppendText(" -boost-fx " + comboBoxBoostFX.SelectedItem.ToString());
                }
            }
        }
        private void PopulateSNESListView(ListView lsb, string Folder, string FileType)
        {
            lsb.Items.Clear();
            gamesToShow.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                string line;
                using (StreamReader codeToSearch = new StreamReader(Folder + "/" + file.Name))
                {
                    while ((line = codeToSearch.ReadLine()) != null)
                    {
                        string code = file.Name.Remove(11, 8);
                        if (code.Contains("CLV-P-S") || code.Contains("CLV-P-V"))
                        {
                            if (line.Contains("Name="))
                            {
                                string name = line.Remove(0, 5);
                                Games game = new Games
                                {
                                    name = name,
                                    path = Folder + "/" + file.Name
                                };
                                gamesToShow.Add(game);
                            }
                        }
                    }
                }
            }
            gamesToShow.Sort(delegate (Games x, Games y)
            {
                if (x.name == null && y.name == null) return 0;
                else if (x.name == null) return -1;
                else if (y.name == null) return 1;
                else return x.name.CompareTo(y.name);
            });
            foreach (Games game in gamesToShow)
            {
                lsb.Items.Add(game.name);
            }
        }
        private void PopulateNESListView(ListView lsb, string Folder, string FileType)
        {
            lsb.Items.Clear();
            gamesToShow.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                string line;
                using (StreamReader codeToSearch = new StreamReader(Folder + "/" + file.Name))
                {
                    while ((line = codeToSearch.ReadLine()) != null)
                    {
                        string code = file.Name.Remove(11, 8);
                        if (code.Contains("CLV-P-N") || code.Contains("CLV-P-H"))
                        {
                            if (line.Contains("Name="))
                            {
                                string name = line.Remove(0, 5);
                                Games game = new Games
                                {
                                    name = name,
                                    path = Folder + "/" + file.Name
                                };
                                gamesToShow.Add(game);
                            }
                        }
                    }
                }
            }
            gamesToShow.Sort(delegate (Games x, Games y)
            {
                if (x.name == null && y.name == null) return 0;
                else if (x.name == null) return -1;
                else if (y.name == null) return 1;
                else return x.name.CompareTo(y.name);
            });
            foreach (Games game in gamesToShow)
            {
                lsb.Items.Add(game.name);
            }
        }
        public class Games
        {
            public string name;
            public string path;
        }
        private void RadioButtonSNES_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRetroarch.Enabled = true;
            checkBoxEpilepsy.Enabled = true;
            checkBoxOutpuDir.Enabled = true;
            checkBoxNoLowLat.Enabled = true;
            comboBoxBoostFX.Enabled = true;
            label7.Enabled = true;
            checkBoxFrame.Enabled = true;
            comboBoxVol.Enabled = true;
            string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart";
            PopulateSNESListView(listViewGames, fullboxartPath, "*.desktop");
        }
        private void RadioButtonNES_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRetroarch.Enabled = false;
            checkBoxEpilepsy.Enabled = false;
            checkBoxOutpuDir.Enabled = false;
            checkBoxNoLowLat.Enabled = false;
            checkBoxFrame.Enabled = false;
            comboBoxBoostFX.Enabled = false;
            comboBoxBorder.Enabled = false;
            label7.Enabled = false;
            importFrame.Enabled = false;
            comboBoxVol.Enabled = true;
            string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart";
            PopulateNESListView(listViewGames, fullboxartPath, "*.desktop");
        }
        private void buttonAddHack_Click(object sender, EventArgs e)
        {
            Process batch = new Process();
            batch.StartInfo.WorkingDirectory = Path.GetDirectoryName(@".\boxart_downloader\");
            batch.StartInfo.FileName = @"install.bat";
            batch.StartInfo.UseShellExecute = true;
            batch.Start();
            batch.WaitForExit();
        }
        private void exitToolStripMenuItem1_click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBox
            {
                Text = aboutToolStripMenuItem.Text.Replace("&", "")
            };
            about.ShowDialog();
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process batch = new Process();
            batch.StartInfo.WorkingDirectory = Path.GetDirectoryName(@".\boxart_downloader\");
            batch.StartInfo.FileName = @"remove.bat";
            batch.StartInfo.UseShellExecute = true;
            batch.Start();
            batch.WaitForExit();
        }
        private void buttonBrowseImage_Click(object sender, EventArgs e)
        {
            openFileDialogImage.Filter = "Images|*.bmp;*.png;*.jpg;*.jpeg;*.gif";
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart\";
                FileInfo file = new FileInfo(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                string code = "";
                code = file.Name.Remove(11, 8);
                var image = Image.FromFile(openFileDialogImage.FileName);
                var newImage = ScaleImage(image, 228, 204);
                var newImage_small = ScaleImage(image, 40, 40);
                image.Dispose();
                newImage.Save(fullboxartPath + code + ".png");
                newImage_small.Save(fullboxartPath + code + "_small.png");
                pictureBoxArt.Image = newImage;
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

       /* private void SetImage(Image image, bool EightBitCompression = false)
        {
            Bitmap outImage;
            Bitmap outImageSmall;
            Graphics gr;

            // Just keep aspect ratio
            int maxX = 204;
            int maxY = 204;
            if (radioButtonSNES.Checked)
            {
                maxX = 228;
                maxY = 204;
            }
            if ((double)image.Width / (double)image.Height > (double)maxX / (double)maxY)
                outImage = new Bitmap(maxX, (int)((double)maxX * (double)image.Height / (double)image.Width));
            else
                outImage = new Bitmap((int)(maxY * (double)image.Width / (double)image.Height), maxY);

            int maxXsmall = 40;
            int maxYsmall = 40;
            if ((double)image.Width / (double)image.Height > (double)maxXsmall / (double)maxYsmall)
                outImageSmall = new Bitmap(maxXsmall, (int)((double)maxXsmall * (double)image.Height / (double)image.Width));
            else
                outImageSmall = new Bitmap((int)(maxYsmall * (double)image.Width / (double)image.Height), maxYsmall);

            gr = Graphics.FromImage(outImage);
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.DrawImage(image, new Rectangle(0, 0, outImage.Width, outImage.Height),
                                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            gr.Flush();
            outImage.Save(IconPath, ImageFormat.Png);
            gr = Graphics.FromImage(outImageSmall);

            // Better resizing quality (more blur like original files)
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            // Fix first line and column alpha shit
            using (ImageAttributes wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                gr.DrawImage(outImage, new Rectangle(0, 0, outImageSmall.Width, outImageSmall.Height), 0, 0, outImage.Width, outImage.Height, GraphicsUnit.Pixel, wrapMode);
            }
            gr.Flush();
            outImageSmall.Save(SmallIconPath, ImageFormat.Png);
        }*/

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxName.Text.Substring(0, textBoxName.Text.Length - 1);
                textBoxRawTitle.Text = textBoxName.Text;

                string[] name = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                name[4] = "Name=" + textBoxName.Text;

                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, name);
            }
            if (listViewGames.SelectedItems.Count > 0)
            {
                listViewGames.SelectedItems[0].Text = textBoxName.Text;
            }
        }
        private void textBoxRawTitle_TextChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                if (textBoxRawTitle.Text.StartsWith("the "))
                    textBoxRawTitle.Text = textBoxRawTitle.Text.Substring(4); // Sorting without "THE"
                string currentString = textBoxRawTitle.Text.Substring(0, textBoxRawTitle.Text.Length - 1);
                textBoxRawTitle.Text = textBoxRawTitle.Text;

                string[] rawtitle = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);

                if (rawtitle[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    rawtitle[15] = "SortRawTitle=" + textBoxRawTitle.Text;
                }
                else if (rawtitle[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    rawtitle[16] = "SortRawTitle=" + textBoxRawTitle.Text;
                }

                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, rawtitle);
  
            }
        }
        private void textBoxPublisher_TextChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxArguments.Text.Substring(0, textBoxArguments.Text.Length - 1);
                textBoxPublisher.Text = textBoxPublisher.Text;
                string[] publisher = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (publisher[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    publisher[16] = "SortRawPublisher=" + textBoxPublisher.Text;
                }
                else if (publisher[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    publisher[17] = "SortRawPublisher=" + textBoxPublisher.Text;
                }
                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, publisher);
            }
        }
        private void textBoxArguments_TextChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxArguments.Text.Substring(0, textBoxArguments.Text.Length - 1);
                textBoxArguments.Text = textBoxArguments.Text;
                string[] args = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (args[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    string exec = args[2].Substring(0, 93);
                    args[2] = exec + textBoxArguments.Text;
                }
                else if (args[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    string exec = args[2].Substring( 0, 83);
                    args[2] = exec + textBoxArguments.Text;
                }
                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, args);
            }
        }
        private void maskedTextBoxReleaseDate_TextChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = maskedTextBoxReleaseDate.Text.Substring(0, maskedTextBoxReleaseDate.Text.Length - 1);
                maskedTextBoxReleaseDate.Text = maskedTextBoxReleaseDate.Text;
                string[] relDate = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (relDate[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    relDate[13] = "ReleaseDate=" + maskedTextBoxReleaseDate.Text;
                }
                else if (relDate[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    relDate[14] = "ReleaseDate=" + maskedTextBoxReleaseDate.Text;
                }
                    File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, relDate);
                }
            }
        private void radioButtonOne_CheckedChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxArguments.Text.Substring(0, textBoxArguments.Text.Length - 1);
                string[] player = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (player[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    player[11] = "Players=1";
                    player[12] = "Simultaneous=0";
                }
                else if (player[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    player[12] = "Players=1";
                    player[13] = "Simultaneous=0";
                }
                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, player);
            }
        }
        private void radioButtonTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxArguments.Text.Substring(0, textBoxArguments.Text.Length - 1);
                string[] multiplayer = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (multiplayer[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    multiplayer[11] = "Players=2";
                    multiplayer[12] = "Simultaneous=0";
                }
                else if (multiplayer[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    multiplayer[12] = "Players=2";
                    multiplayer[13] = "Simultaneous=0";
                }
                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, multiplayer);
            }
        }
        private void radioButtonTwoSim_CheckedChanged(object sender, EventArgs e)
        {
            if (readyToEdit)
            {
                string currentString = textBoxArguments.Text.Substring(0, textBoxArguments.Text.Length - 1);
                string[] playerSim = File.ReadAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path);
                if (playerSim[2].Contains("Exec=/usr/bin/clover-kachikachi"))
                {
                    playerSim[11] = "Players=2";
                    playerSim[12] = "Simultaneous=1";
                }
                else if (playerSim[2].Contains("Exec=/usr/bin/clover-canoe-shvc"))
                {
                    playerSim[12] = "Players=2";
                    playerSim[13] = "Simultaneous=1";
                }
                File.WriteAllLines(gamesToShow[listViewGames.SelectedItems[0].Index].path, playerSim);
            }

        }
        public void ShowSelected()
        {
            readyToEdit = false;
            FileInfo file = new FileInfo(gamesToShow[listViewGames.SelectedItems[0].Index].path);
            string line;
            string code = "";

            using (StreamReader codeToSearch = new StreamReader(gamesToShow[listViewGames.SelectedItems[0].Index].path))

            {
                while ((line = codeToSearch.ReadLine()) != null)
                {
                    code = file.Name.Remove(11, 8);
                    if (line.Contains("Name="))
                    {
                        string name = line.Remove(0, 5);
                        textBoxName.Text = name;
                    }
                    if (line.Contains("SortRawPublisher="))
                    {
                        string publisher = line.Remove(0, 17);
                        textBoxPublisher.Text = publisher;
                    }
                    if (line.Contains("ReleaseDate="))
                    {
                        string releasedate = line.Remove(0, 12);
                        maskedTextBoxReleaseDate.Text = releasedate;
                    }
                    if (line.Contains("Code="))
                    {
                        string gamecode = line.Remove(0, 5);
                        textBoxGameCode.Text = gamecode;
                    }
                    if (line.Contains("Exec=/usr/bin/clover-kachikachi"))
                    {
                        string exec = line.Remove(0, 93);
                        textBoxArguments.Text = exec;
                        if (line.Contains("-output-dir"))
                        {
                            checkBoxOutpuDir.Checked = true;
                        }
                        else
                        {
                            checkBoxOutpuDir.Checked = false;
                        }
                        if (line.Contains("--volume"))
                        {
                            int volumeArgsPosition = line.IndexOf("--volume");
                            var volumeArgument = line.Substring(volumeArgsPosition);
                            string[] volume = volumeArgument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            comboBoxVol.Text = volume[1];
                           // MessageBox.Show();
                        };

                    }
                    else if (line.Contains("Exec=/usr/bin/clover-canoe-shvc"))
                    {
                        string exec = line.Remove(0, 83);
                        textBoxArguments.Text = exec;
                        if (line.Contains("-output-dir"))
                        {
                            checkBoxOutpuDir.Checked = true;
                        }
                        else
                        {
                            checkBoxOutpuDir.Checked = false;
                        }
                        if (line.Contains("--use-decorative-frame"))
                        {
                            checkBoxFrame.Checked = true;
                        }
                        else
                        {
                            checkBoxFrame.Checked = false;
                        }
                        if (line.Contains("-no-lowlatency"))
                        {
                            checkBoxNoLowLat.Checked = true;
                        }
                        else
                        {
                            checkBoxNoLowLat.Checked = false;
                        }
                        if (line.Contains("--volume"))
                        {
                            int volumeArgsPosition = line.IndexOf("--volume");
                            /*string volumeArgument = line.Substring(volumeArgsPosition, 12);
                            string[] volume = volumeArgument.Split(null);*/
                            var volumeArgument = line.Substring(volumeArgsPosition);
                            string[] volume = volumeArgument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            //MessageBox.Show(volume[1]);
                            comboBoxVol.Text = volume[1];
                        }
                        if (line.Contains("-boost-fx"))
                        {
                            int boostfxArgsPosition = line.IndexOf("-boost-fx");
                            string boosfxArgument = line.Substring(boostfxArgsPosition, 11);
                            string[] boostfx = boosfxArgument.Split(null);
                            comboBoxBoostFX.Text = boostfx[1];
                        }
                        else
                        {
                            comboBoxBoostFX.Text = "";
                        }
                    }
                    if (line.Contains("SortRawTitle="))
                    {
                        string sorttitle = line.Remove(0, 13);
                        textBoxRawTitle.Text = sorttitle;
                    }

                    if (line.Contains("Icon="))
                    {
                        var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                        var iconPath = Path.Combine(outPutDirectory, @".\boxart_downloader\boxart_hack\boxart\");
                        string boxart = code + ".png";
                        pictureBoxArt.ImageLocation = iconPath + boxart;
                    }

                    if (line.Contains("Players=1"))
                        radioButtonOne.Checked = true;
                    if (line.Contains("Simultaneous=0"))
                        radioButtonTwo.Checked = true;
                    if (line.Contains("Simultaneous=1"))
                        radioButtonTwoSim.Checked = true;
                }
                codeToSearch.Close();
                readyToEdit = true;
            }
        }
        private void listViewGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewGames.SelectedItems.Count == 0)
                return;
            ShowSelected();
        }
        private void importFrame_Click(object sender, EventArgs e)
        {
            OpenFileDialog customBorder = new OpenFileDialog();
            customBorder.Filter = "Custom frames|*.png;*.txt";
            customBorder.Multiselect = true;
            if (DialogResult.OK == customBorder.ShowDialog())
            {
                string customBorderDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string fullborderPath = new Uri(customBorderDirectory).LocalPath + @"boxart_downloader\borders\";
                foreach (string file in customBorder.FileNames)
                {
                    File.Copy(file, Path.Combine(fullborderPath, Path.GetFileName(file)), true);
                    string bordersGet = Path.GetFileNameWithoutExtension(file);
                    string[] splitter = {"_4_3", "_pixel_perfect", "_thumbnail" };
                    string[] customBorderName = bordersGet.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    if (comboBoxBorder.SelectedIndex == 0)
                    {
                        if (!textBoxArguments.Text.Contains(" --use-decorative-frame /var/lib/hakchi/rootfs/borders/" + customBorderName[0] + "_4_3"))
                            textBoxArguments.AppendText(" --use-decorative-frame /var/lib/hakchi/rootfs/borders/" + customBorderName[0] + "_4_3");
                    }
                    else 
                    {
                        if (!textBoxArguments.Text.Contains(" --use-decorative-frame /var/lib/hakchi/rootfs/borders/" + customBorderName[0] + "_pixel_perfect"))
                            textBoxArguments.AppendText(" --use-decorative-frame /var/lib/hakchi/rootfs/borders/" + customBorderName[0] + "_pixel_perfect");
                    }
                }
            }
        }
        private void checkBoxFrame_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBoxFrame.Checked == false)
            {
                importFrame.Enabled = false;
                comboBoxBorder.Enabled = false;
                if (textBoxArguments.Text.Contains("--use-decorative-frame"))
                {
                    string argsborder = textBoxArguments.Text;
                    string[] cutter = new string[] { " --use-decorative-frame" };
                    string[] result;
                    result = argsborder.Split(cutter, StringSplitOptions.None);
                    textBoxArguments.Text = textBoxArguments.Text.Replace(" --use-decorative-frame" + result[1], "");
                }
            }
            if (checkBoxFrame.Checked == true)
            {
                importFrame.Enabled = true;
                comboBoxBorder.Enabled = true;
                comboBoxBorder.SelectedIndex = 0;
            }

        }

        private void comboBoxBorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = comboBoxBorder.SelectedItem.ToString();
            if (curItem == "Pixel Perfect")
            {
                if (textBoxArguments.Text.Contains("--use-decorative-frame"))
                {
                    textBoxArguments.Text = textBoxArguments.Text.Replace("_4_3", "_pixel_perfect");
                }
            }
            if (curItem == "4:3")
            {
                if (textBoxArguments.Text.Contains("--use-decorative-frame"))
                {
                    textBoxArguments.Text = textBoxArguments.Text.Replace("_pixel_perfect", "_4_3");
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Char delimiter = '.';
            string[] version = fvi.FileVersion.Split(delimiter);
            Text = "Original Desktop Editor" + " - v" + version[0] + "." + version[1] + "." + version[2];
        }
    }
}