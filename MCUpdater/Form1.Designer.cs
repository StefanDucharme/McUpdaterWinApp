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
            this.unzip = new System.Windows.Forms.Button();
            this.backup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toUpdateLocation = new System.Windows.Forms.TextBox();
            this.chooseFolderToUpdate = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
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
            // unzip
            // 
            this.unzip.Location = new System.Drawing.Point(12, 415);
            this.unzip.Name = "unzip";
            this.unzip.Size = new System.Drawing.Size(75, 23);
            this.unzip.TabIndex = 2;
            this.unzip.Text = "Unzip";
            this.unzip.UseVisualStyleBackColor = true;
            this.unzip.Click += new System.EventHandler(this.unzip_click);
            // 
            // backup
            // 
            this.backup.Location = new System.Drawing.Point(93, 415);
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(75, 23);
            this.backup.TabIndex = 3;
            this.backup.Text = "Backup";
            this.backup.UseVisualStyleBackColor = true;
            this.backup.Click += new System.EventHandler(this.backup_click);
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
            // update
            // 
            this.update.Location = new System.Drawing.Point(174, 415);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 8;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_click);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(12, 228);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(49, 13);
            this.message.TabIndex = 9;
            this.message.Text = "message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.message);
            this.Controls.Add(this.update);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toUpdateLocation);
            this.Controls.Add(this.chooseFolderToUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backup);
            this.Controls.Add(this.unzip);
            this.Controls.Add(this.fileLocation);
            this.Controls.Add(this.chooseFilesButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFilesButton;
        private System.Windows.Forms.TextBox fileLocation;
        private System.Windows.Forms.Button unzip;
        private System.Windows.Forms.Button backup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toUpdateLocation;
        private System.Windows.Forms.Button chooseFolderToUpdate;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label message;
    }
}

