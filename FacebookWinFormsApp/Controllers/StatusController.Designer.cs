namespace BasicFacebookFeatures.Models
{
    public partial class StatusController
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
            this.labelUserDateCreated = new System.Windows.Forms.Label();
            this.labelUserAuthor = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelDateCreated = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.richTextBoxUserMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelUserDateCreated
            // 
            this.labelUserDateCreated.AutoSize = true;
            this.labelUserDateCreated.Location = new System.Drawing.Point(74, 24);
            this.labelUserDateCreated.Name = "labelUserDateCreated";
            this.labelUserDateCreated.Size = new System.Drawing.Size(55, 13);
            this.labelUserDateCreated.TabIndex = 10;
            this.labelUserDateCreated.Text = "User Date";
            // 
            // labelUserAuthor
            // 
            this.labelUserAuthor.AutoSize = true;
            this.labelUserAuthor.Location = new System.Drawing.Point(74, 8);
            this.labelUserAuthor.Name = "labelUserAuthor";
            this.labelUserAuthor.Size = new System.Drawing.Size(63, 13);
            this.labelUserAuthor.TabIndex = 9;
            this.labelUserAuthor.Text = "User Author";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(6, 40);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(53, 13);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "Message:";
            // 
            // labelDateCreated
            // 
            this.labelDateCreated.AutoSize = true;
            this.labelDateCreated.Location = new System.Drawing.Point(6, 24);
            this.labelDateCreated.Name = "labelDateCreated";
            this.labelDateCreated.Size = new System.Drawing.Size(72, 13);
            this.labelDateCreated.TabIndex = 7;
            this.labelDateCreated.Text = "Date created:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(6, 8);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelAuthor.TabIndex = 6;
            this.labelAuthor.Text = "Author:";
            // 
            // richTextBoxUserMessage
            // 
            this.richTextBoxUserMessage.Location = new System.Drawing.Point(9, 56);
            this.richTextBoxUserMessage.Name = "richTextBoxUserMessage";
            this.richTextBoxUserMessage.ReadOnly = true;
            this.richTextBoxUserMessage.Size = new System.Drawing.Size(266, 157);
            this.richTextBoxUserMessage.TabIndex = 11;
            this.richTextBoxUserMessage.Text = "";
            // 
            // StatusController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxUserMessage);
            this.Controls.Add(this.labelUserDateCreated);
            this.Controls.Add(this.labelUserAuthor);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelDateCreated);
            this.Controls.Add(this.labelAuthor);
            this.Name = "StatusController";
            this.Size = new System.Drawing.Size(278, 217);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUserDateCreated;
        private System.Windows.Forms.Label labelUserAuthor;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelDateCreated;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.RichTextBox richTextBoxUserMessage;
    }
}
