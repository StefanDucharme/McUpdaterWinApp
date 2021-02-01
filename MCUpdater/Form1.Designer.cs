namespace MCUpdater
{
    partial class Form1
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
            this.chooseFilesButton = new System.Windows.Forms.Button();
            this.fileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toUpdateLocation = new System.Windows.Forms.TextBox();
            this.chooseFolderToUpdate = new System.Windows.Forms.Button();
            this.fullProcess = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.Location = new System.Drawing.Point(40, 4);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(75, 23);
            this.chooseFilesButton.TabIndex = 0;
            this.chooseFilesButton.Text = "Select File";
            this.chooseFilesButton.UseVisualStyleBackColor = true;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButton_Click);
            // 
            // fileLocation
            // 
            this.fileLocation.Location = new System.Drawing.Point(12, 33);
            this.fileLocation.Name = "fileLocation";
            this.fileLocation.Size = new System.Drawing.Size(695, 20);
            this.fileLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Folder to update";
            // 
            // toUpdateLocation
            // 
            this.toUpdateLocation.Location = new System.Drawing.Point(12, 88);
            this.toUpdateLocation.Name = "toUpdateLocation";
            this.toUpdateLocation.Size = new System.Drawing.Size(695, 20);
            this.toUpdateLocation.TabIndex = 6;
            // 
            // chooseFolderToUpdate
            // 
            this.chooseFolderToUpdate.Location = new System.Drawing.Point(102, 59);
            this.chooseFolderToUpdate.Name = "chooseFolderToUpdate";
            this.chooseFolderToUpdate.Size = new System.Drawing.Size(102, 23);
            this.chooseFolderToUpdate.TabIndex = 5;
            this.chooseFolderToUpdate.Text = "Select Folder";
            this.chooseFolderToUpdate.UseVisualStyleBackColor = true;
            this.chooseFolderToUpdate.Click += new System.EventHandler(this.chooseFolderToUpdate_click);
            // 
            // fullProcess
            // 
            this.fullProcess.Location = new System.Drawing.Point(12, 415);
            this.fullProcess.Name = "fullProcess";
            this.fullProcess.Size = new System.Drawing.Size(156, 23);
            this.fullProcess.TabIndex = 10;
            this.fullProcess.Text = "Unzip, Backup, and Update";
            this.fullProcess.UseVisualStyleBackColor = true;
            this.fullProcess.Click += new System.EventHandler(this.fullProcess_click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(12, 114);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message.Size = new System.Drawing.Size(775, 295);
            this.message.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.message);
            this.Controls.Add(this.fullProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toUpdateLocation);
            this.Controls.Add(this.chooseFolderToUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileLocation);
            this.Controls.Add(this.chooseFilesButton);
            this.Name = "Form1";
            this.Text = "MCUpdater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFilesButton;
        private System.Windows.Forms.TextBox fileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toUpdateLocation;
        private System.Windows.Forms.Button chooseFolderToUpdate;
        private System.Windows.Forms.Button fullProcess;
        private System.Windows.Forms.TextBox message;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

