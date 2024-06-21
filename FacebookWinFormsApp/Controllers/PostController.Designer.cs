namespace BasicFacebookFeatures.Models
{
    public partial class PostController
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
            this.picturePost = new System.Windows.Forms.PictureBox();
            this.labelUserPostPlace = new System.Windows.Forms.Label();
            this.labelUserPostFrom = new System.Windows.Forms.Label();
            this.labelPostinAuthor = new System.Windows.Forms.Label();
            this.labelPostDateCreated = new System.Windows.Forms.Label();
            this.labelPostinMessage = new System.Windows.Forms.Label();
            this.labelUserPostAuthor = new System.Windows.Forms.Label();
            this.labelUserPostDateCreated = new System.Windows.Forms.Label();
            this.labelPostinFrom = new System.Windows.Forms.Label();
            this.labelPostinPlace = new System.Windows.Forms.Label();
            this.labelUserPostMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePost)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePost
            // 
            this.picturePost.Location = new System.Drawing.Point(3, 3);
            this.picturePost.Name = "picturePost";
            this.picturePost.Size = new System.Drawing.Size(128, 128);
            this.picturePost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePost.TabIndex = 29;
            this.picturePost.TabStop = false;
            // 
            // labelUserPostPlace
            // 
            this.labelUserPostPlace.AutoSize = true;
            this.labelUserPostPlace.Location = new System.Drawing.Point(76, 205);
            this.labelUserPostPlace.Name = "labelUserPostPlace";
            this.labelUserPostPlace.Size = new System.Drawing.Size(59, 13);
            this.labelUserPostPlace.TabIndex = 28;
            this.labelUserPostPlace.Text = "User Place";
            // 
            // labelUserPostFrom
            // 
            this.labelUserPostFrom.AutoSize = true;
            this.labelUserPostFrom.Location = new System.Drawing.Point(76, 182);
            this.labelUserPostFrom.Name = "labelUserPostFrom";
            this.labelUserPostFrom.Size = new System.Drawing.Size(55, 13);
            this.labelUserPostFrom.TabIndex = 27;
            this.labelUserPostFrom.Text = "User From";
            // 
            // labelPostinAuthor
            // 
            this.labelPostinAuthor.AutoSize = true;
            this.labelPostinAuthor.Location = new System.Drawing.Point(4, 136);
            this.labelPostinAuthor.Name = "labelPostinAuthor";
            this.labelPostinAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelPostinAuthor.TabIndex = 19;
            this.labelPostinAuthor.Text = "Author:";
            // 
            // labelPostDateCreated
            // 
            this.labelPostDateCreated.AutoSize = true;
            this.labelPostDateCreated.Location = new System.Drawing.Point(4, 159);
            this.labelPostDateCreated.Name = "labelPostDateCreated";
            this.labelPostDateCreated.Size = new System.Drawing.Size(72, 13);
            this.labelPostDateCreated.TabIndex = 20;
            this.labelPostDateCreated.Text = "Date created:";
            // 
            // labelPostinMessage
            // 
            this.labelPostinMessage.AutoSize = true;
            this.labelPostinMessage.Location = new System.Drawing.Point(4, 228);
            this.labelPostinMessage.Name = "labelPostinMessage";
            this.labelPostinMessage.Size = new System.Drawing.Size(53, 13);
            this.labelPostinMessage.TabIndex = 21;
            this.labelPostinMessage.Text = "Message:";
            // 
            // labelUserPostAuthor
            // 
            this.labelUserPostAuthor.AutoSize = true;
            this.labelUserPostAuthor.Location = new System.Drawing.Point(76, 136);
            this.labelUserPostAuthor.Name = "labelUserPostAuthor";
            this.labelUserPostAuthor.Size = new System.Drawing.Size(63, 13);
            this.labelUserPostAuthor.TabIndex = 22;
            this.labelUserPostAuthor.Text = "User Author";
            // 
            // labelUserPostDateCreated
            // 
            this.labelUserPostDateCreated.AutoSize = true;
            this.labelUserPostDateCreated.Location = new System.Drawing.Point(76, 159);
            this.labelUserPostDateCreated.Name = "labelUserPostDateCreated";
            this.labelUserPostDateCreated.Size = new System.Drawing.Size(55, 13);
            this.labelUserPostDateCreated.TabIndex = 23;
            this.labelUserPostDateCreated.Text = "User Date";
            // 
            // labelPostinFrom
            // 
            this.labelPostinFrom.AutoSize = true;
            this.labelPostinFrom.Location = new System.Drawing.Point(4, 182);
            this.labelPostinFrom.Name = "labelPostinFrom";
            this.labelPostinFrom.Size = new System.Drawing.Size(33, 13);
            this.labelPostinFrom.TabIndex = 25;
            this.labelPostinFrom.Text = "From:";
            // 
            // labelPostinPlace
            // 
            this.labelPostinPlace.AutoSize = true;
            this.labelPostinPlace.Location = new System.Drawing.Point(4, 205);
            this.labelPostinPlace.Name = "labelPostinPlace";
            this.labelPostinPlace.Size = new System.Drawing.Size(37, 13);
            this.labelPostinPlace.TabIndex = 26;
            this.labelPostinPlace.Text = "Place:";
            // 
            // labelUserPostMessage
            // 
            this.labelUserPostMessage.Location = new System.Drawing.Point(79, 228);
            this.labelUserPostMessage.Name = "labelUserPostMessage";
            this.labelUserPostMessage.ReadOnly = true;
            this.labelUserPostMessage.Size = new System.Drawing.Size(367, 89);
            this.labelUserPostMessage.TabIndex = 30;
            this.labelUserPostMessage.Text = "";
            // 
            // PostModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.labelUserPostMessage);
            this.Controls.Add(this.picturePost);
            this.Controls.Add(this.labelUserPostPlace);
            this.Controls.Add(this.labelUserPostFrom);
            this.Controls.Add(this.labelPostinPlace);
            this.Controls.Add(this.labelPostinFrom);
            this.Controls.Add(this.labelUserPostDateCreated);
            this.Controls.Add(this.labelUserPostAuthor);
            this.Controls.Add(this.labelPostinMessage);
            this.Controls.Add(this.labelPostDateCreated);
            this.Controls.Add(this.labelPostinAuthor);
            this.Name = "PostModel";
            this.Size = new System.Drawing.Size(466, 350);
            ((System.ComponentModel.ISupportInitialize)(this.picturePost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturePost;
        private System.Windows.Forms.Label labelUserPostPlace;
        private System.Windows.Forms.Label labelUserPostFrom;
        private System.Windows.Forms.Label labelPostinAuthor;
        private System.Windows.Forms.Label labelPostDateCreated;
        private System.Windows.Forms.Label labelPostinMessage;
        private System.Windows.Forms.Label labelUserPostAuthor;
        private System.Windows.Forms.Label labelUserPostDateCreated;
        private System.Windows.Forms.Label labelPostinFrom;
        private System.Windows.Forms.Label labelPostinPlace;
        private System.Windows.Forms.RichTextBox labelUserPostMessage;
    }
}
