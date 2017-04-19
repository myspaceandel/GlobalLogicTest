namespace GlobalLogicTestTask
{
    partial class MainForm
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
            this.btn_serialize = new System.Windows.Forms.Button();
            this.openFolderToSer = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_deserialize = new System.Windows.Forms.Button();
            this.openFileToDes = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_serialize
            // 
            this.btn_serialize.Location = new System.Drawing.Point(13, 13);
            this.btn_serialize.Name = "btn_serialize";
            this.btn_serialize.Size = new System.Drawing.Size(259, 23);
            this.btn_serialize.TabIndex = 0;
            this.btn_serialize.Text = "Choose folder";
            this.btn_serialize.UseVisualStyleBackColor = true;
            this.btn_serialize.Click += new System.EventHandler(this.serialize_Click);
            // 
            // btn_deserialize
            // 
            this.btn_deserialize.Location = new System.Drawing.Point(13, 43);
            this.btn_deserialize.Name = "btn_deserialize";
            this.btn_deserialize.Size = new System.Drawing.Size(259, 23);
            this.btn_deserialize.TabIndex = 1;
            this.btn_deserialize.Text = "Choose file";
            this.btn_deserialize.UseVisualStyleBackColor = true;
            this.btn_deserialize.Click += new System.EventHandler(this.deserialize_Click);
            // 
            // openFileToDes
            // 
            this.openFileToDes.FileName = "openFileToDes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 77);
            this.Controls.Add(this.btn_deserialize);
            this.Controls.Add(this.btn_serialize);
            this.Name = "Form1";
            this.Text = "GlobalLogic Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_serialize;
        private System.Windows.Forms.FolderBrowserDialog openFolderToSer;
        private System.Windows.Forms.Button btn_deserialize;
        private System.Windows.Forms.OpenFileDialog openFileToDes;
    }
}

