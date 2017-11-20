//using com.clusterrr.hakchi_gui;
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
            Process batch = new Process();
            batch.StartInfo.WorkingDirectory = Path.GetDirectoryName(@".\boxart_downloader\");
            batch.StartInfo.FileName = @"boxart.bat";
            batch.StartInfo.UseShellExecute = true;
            batch.Start();
            batch.WaitForExit();
            // MessageBox.Show("Batch Script Done");
        }
        private void listViewGames_MouseClick(object sender, MouseEventArgs e)
        {
            readyToEdit = false;
            FileInfo file = new FileInfo(gamesToShow[listViewGames.SelectedItems[0].Index].path);
            string line;
            string code = "";
            string toReplace = "";
            bool iconReplaced = false;

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
                           string volumeArgument = line.Substring(volumeArgsPosition, 12);
                           string[] volume = volumeArgument.Split(null);
                            comboBoxVol.Text = volume[1];
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
                            string volumeArgument = line.Substring(volumeArgsPosition, 12);
                            string[] volume = volumeArgument.Split(null);
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

                    if (line.Contains("Icon=/usr/share/games/"))
                    {
                        iconReplaced = true;
                        toReplace = "Icon=/usr/share/games/";
                    }
                    if (line.Contains("Icon=/usr/share/games/nes/kachikachi/"))
                    {
                        iconReplaced = true;
                        toReplace = "Icon=/usr/share/games/nes/kachikachi/";
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

            string icon = File.ReadAllText(gamesToShow[listViewGames.SelectedItems[0].Index].path);

            if (iconReplaced == true)
                icon = icon.Replace(toReplace + code + "/", "Icon=/var/lib/hakchi/rootfs/boxart/");

            File.WriteAllText(gamesToShow[listViewGames.SelectedItems[0].Index].path, icon);


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
                volumeArgument = fullArguments.Substring(volumeArgsPosition, 12);
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
                    textBoxArguments.Text = textBoxArguments.Text.Replace(volumeArgument, "--volume " + comboBoxVol.SelectedItem.ToString() + " ");
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

                             /*
                                Games game = new Games();
                                game.name = name;
                                game.path = Folder + "/" + file.Name;
                                gamesToShow.Add(game);    
                             */
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
            comboBoxBoostFX.Enabled = false;
            comboBoxVol.Enabled = true;
            string boxartDirectory = AppDomain.CurrentDomain.BaseDirectory; Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullboxartPath = new Uri(boxartDirectory).LocalPath + @"boxart_downloader\boxart_hack\boxart";
            PopulateNESListView(listViewGames, fullboxartPath, "*.desktop");
        }
        private void buttonAddHack_Click(object sender, EventArgs e)
        {
           /* WaitingClovershellForm settingsForm = new WaitingClovershellForm();

            // Show the settings form
            settingsForm.Show();*/
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
                image.Dispose();//Add this to your code
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
                //radioButtonOne.Checked = true;
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
              //  radioButtonTwoSim.Checked = true;
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
               // radioButtonTwo.Checked = true;
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
    }
}