namespace BasicFacebookFeatures.Models
{
    public partial class PageController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPageName = new System.Windows.Forms.Label();
            this.pictureBoxCheckin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPageName
            // 
            this.labelPageName.AutoSize = true;
            this.labelPageName.Location = new System.Drawing.Point(6, 3);
            this.labelPageName.Name = "labelPageName";
            this.labelPageName.Size = new System.Drawing.Size(35, 13);
            this.labelPageName.TabIndex = 2;
            this.labelPageName.Text = "Name";
            // 
            // pictureBoxCheckin
            // 
            this.pictureBoxCheckin.Location = new System.Drawing.Point(9, 19);
            this.pictureBoxCheckin.Name = "pictureBoxCheckin";
            this.pictureBoxCheckin.Size = new System.Drawing.Size(143, 109);
            this.pictureBoxCheckin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCheckin.TabIndex = 7;
            this.pictureBoxCheckin.TabStop = false;
            // 
            // PageModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxCheckin);
            this.Controls.Add(this.labelPageName);
            this.Name = "PageModel";
            this.Size = new System.Drawing.Size(161, 133);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.PictureBox pictureBoxCheckin;
    }
}
