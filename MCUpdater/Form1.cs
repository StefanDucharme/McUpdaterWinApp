using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            message.Text = string.Empty;
        }

        private void chooseFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog zipDialog = new OpenFileDialog();
                zipDialog.CheckFileExists = true;
                zipDialog.CheckPathExists = true;

                var result = zipDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileLocation.Text = zipDialog.FileName;
                }

                //Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void chooseFolderToUpdate_click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog toUpdateDialog = new FolderBrowserDialog();

                var result = toUpdateDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(toUpdateDialog.SelectedPath))
                {
                    toUpdateLocation.Text = toUpdateDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }

        }

        //private void unzip_click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Unzip();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(ex.ToString());
        //    }

        //}

        private void fullProcess_click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileLocation.Text))
                {
                    message.Text = "Please select a zip file location.";
                    return;
                }

                if (!File.Exists(fileLocation.Text))
                {
                    message.Text = fileLocation.Text + " does not exist";
                    return;
                }

                if (string.IsNullOrWhiteSpace(toUpdateLocation.Text))
                {
                    message.Text = "Please select a folder to update.";
                    return;
                }

                if (!Directory.Exists(toUpdateLocation.Text))
                {
                    message.Text = toUpdateLocation.Text + " does not exist";
                    return;
                }

                var result = MessageBox.Show("Click No to halt this operation so you can close it. Click Yes to continue", "Has the server been closed?", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                message.Text = string.Empty;

                fullProcess.Enabled = false;
                chooseFilesButton.Enabled = false;
                chooseFolderToUpdate.Enabled = false;
                fileLocation.Enabled = false;
                toUpdateLocation.Enabled = false;

                if (backgroundWorker1.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }

        }

        private string Unzip()
        {
            if (!File.Exists(fileLocation.Text))
            {
                throw new Exception(fileLocation.Text + " does not exist");
            }
            
            var extension = Path.GetExtension(fileLocation.Text);

            var extractedLocation = fileLocation.Text.Replace(extension, string.Empty);

            Log("Unzipping " + fileLocation.Text + " to " + extractedLocation);

            if (Directory.Exists(extractedLocation))
            {
                throw new Exception(extractedLocation + " already exists");
            }

            ZipFile.ExtractToDirectory(fileLocation.Text, extractedLocation);

            Log("Finished unzipping");
            return extractedLocation;
        }

        private void Backup()
        {            
            if (!Directory.Exists(toUpdateLocation.Text))
            {
                throw new Exception(toUpdateLocation.Text + " does not exist");
            }
            
            var newZipLocation = toUpdateLocation.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip";

            Log("Backing up " + toUpdateLocation.Text + " to " + newZipLocation);

            if (File.Exists(newZipLocation))
            {
                throw new Exception(newZipLocation + " already exists");
            }

            //todo set version in name?
            ZipFile.CreateFromDirectory(toUpdateLocation.Text, newZipLocation);
            Log("Finished backing up");
        }

        private void UpdateFolder(string extractedLocation)
        {

            //todo kill server
            //Process[] runningProcesses = Process.GetProcesses();
            //foreach (Process process in runningProcesses)
            //{
            //    // now check the modules of the process
            //    foreach (ProcessModule module in process.Modules)
            //    {
            //        Log(module.FileName);
            //        if (module.FileName.Equals("cmd.exe"))
            //        {
            //            //process.Kill();
            //        }
            //    }
            //}

            var updateLocation = toUpdateLocation.Text;

            if (!Directory.Exists(updateLocation))
            {
                throw new Exception(updateLocation + " does not exist");
            }

            Log("Updating");

            Log("Deleting directories");
            foreach (var dir in Directory.GetDirectories(updateLocation))
            {
                var parts = dir.Split('\\');
                var folder = parts[parts.Length - 1];

                //todo config for which folders
                switch (folder)
                {
                    case "config":
                    case "defaultconfigs":
                    case "kubejs":
                    case "mods":
                    case "patchouli_books":
                        Log("Deleting " + dir);
                        Directory.Delete(dir, true);
                        break;
                    default:
                        break;
                }
            }

            Log("Copying");
            foreach (var dir in Directory.GetDirectories(extractedLocation))
            {
                var parts = dir.Split('\\');
                var folder = parts[parts.Length - 1];

                switch (folder)
                {
                    case "config":
                    case "defaultconfigs":
                    case "kubejs":
                    case "mods":
                    case "patchouli_books":
                        Log("Copying " + extractedLocation + "\\" + folder +" to "+ updateLocation + "\\" + folder);
                        DirectoryCopy(extractedLocation + "\\" + folder, updateLocation + "\\" + folder, true);

                        break;
                    default:
                        break;
                }
            }

            Log("Copying over settings.cfg");
            File.Copy(extractedLocation + "\\settings.cfg", updateLocation + "\\settings.cfg", true);//todo config for any files to copy over outside of the folders above
                        
            CreateUpdateLogFile();

            Log("Finished updating");
        }

        private void CreateUpdateLogFile()
        {
            Log("Creating/updating updateLog.txt");
            //todo config on how to get version
            var extension = Path.GetExtension(fileLocation.Text);
            var extensionless = fileLocation.Text.Replace(extension, string.Empty);
            var version = extensionless.Split('-')[1];
            File.AppendAllText(toUpdateLocation.Text + "\\updateLog.txt", "Updated to " + version + Environment.NewLine);
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void Log(string msg)
        {
            Console.WriteLine(msg);

            message.Invoke((MethodInvoker)delegate
            {
                message.Text += msg + Environment.NewLine;
            });

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                message.Text += "Canceled!";
            }
            else if (e.Error != null)
            {
                message.Text += "Error: " + e.Error.Message;
            }
            else
            {
                message.Text += "Done!";
            }

            fullProcess.Enabled = true;
            chooseFilesButton.Enabled = true;
            chooseFolderToUpdate.Enabled = true;
            fileLocation.Enabled = true;
            toUpdateLocation.Enabled = true;

            var result = MessageBox.Show("Update complete", "Done!", MessageBoxButtons.OK);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var extractedLocation = Unzip();
            Backup();
            UpdateFolder(extractedLocation);
            CleanUp(extractedLocation);
        }

        private void CleanUp(string extractedLocation)
        {
            Log("Cleaning up");
            Directory.Delete(extractedLocation, true);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //message.Text += (e.ProgressPercentage.ToString() + "%");
        }

    }
}
