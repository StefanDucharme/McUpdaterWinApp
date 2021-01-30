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
        private string extractedLocation = string.Empty;

        public Form1()
        {
            InitializeComponent();
            message.Text = string.Empty;
        }


        private void chooseFilesButton_Click(object sender, EventArgs e)
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

        private void chooseFolderToUpdate_click(object sender, EventArgs e)
        {
            OpenFileDialog toUpdateDialog = new OpenFileDialog();
            toUpdateDialog.CheckFileExists = true;
            toUpdateDialog.CheckPathExists = true;

            var result = toUpdateDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                toUpdateLocation.Text = toUpdateDialog.FileName;
            }
        }

        private void unzip_click(object sender, EventArgs e)
        {
            if (!File.Exists(fileLocation.Text))
            {
                message.Text = fileLocation.Text + " does not exist";
                return;
            }

            var extension = Path.GetExtension(fileLocation.Text);

            extractedLocation = fileLocation.Text.Replace(extension, string.Empty);

            if (Directory.Exists(extractedLocation))
            {
                message.Text = extractedLocation + " already exists";
                return;
            }

            ZipFile.ExtractToDirectory(fileLocation.Text, extractedLocation);
        }

        private void backup_click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Click No to halt this operation so you can close it. Click Yes to continue", "Has the server been closed?", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }


            if (!Directory.Exists(toUpdateLocation.Text))
            {
                message.Text = toUpdateLocation.Text + " does not exist";
                return;
            }

            var newZipLocation = toUpdateLocation + ".zip";

            if (File.Exists(newZipLocation))
            {
                message.Text = newZipLocation + " already exists";
                return;
            }

            //todo set version in name?
            ZipFile.CreateFromDirectory(toUpdateLocation.Text, newZipLocation);
        }

        private void update_click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Click No to halt this operation so you can close it. Click Yes to continue", "Has the server been closed?", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            //todo config
            //todo create txt with version

            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                // now check the modules of the process
                foreach (ProcessModule module in process.Modules)
                {
                    Console.WriteLine(module.FileName);
                    if (module.FileName.Equals("cmd.exe"))
                    {
                        //process.Kill();
                    }
                }
            }
        }

        
    }
}
