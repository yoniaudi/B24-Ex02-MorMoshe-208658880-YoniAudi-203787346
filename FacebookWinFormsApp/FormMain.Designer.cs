using BasicFacebookFeatures.Models;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormMain
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelInstractions = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelFullName = new System.Windows.Forms.Label();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.panelPosts = new System.Windows.Forms.Panel();
            this.panelStatuses = new System.Windows.Forms.Panel();
            this.panelPhotos = new System.Windows.Forms.Panel();
            this.panelPages = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonFriends = new System.Windows.Forms.Button();
            this.buttonStatuses = new System.Windows.Forms.Button();
            this.panelInbox = new System.Windows.Forms.Panel();
            this.panelSecondary = new System.Windows.Forms.Panel();
            this.buttonPosts = new System.Windows.Forms.Button();
            this.buttonPages = new System.Windows.Forms.Button();
            this.buttonPhotos = new System.Windows.Forms.Button();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.buttonTravelBuddy = new System.Windows.Forms.Button();
            this.buttonVolunteer = new System.Windows.Forms.Button();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.pictureBoxAppVisability = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.searchableListBoxMain = new BasicFacebookFeatures.Models.SearchableListBoxController();
            this.panelMain.SuspendLayout();
            this.panelSecondary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppVisability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(18, 57);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelInstractions
            // 
            this.labelInstractions.AutoSize = true;
            this.labelInstractions.Location = new System.Drawing.Point(314, 17);
            this.labelInstractions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInstractions.Name = "labelInstractions";
            this.labelInstractions.Size = new System.Drawing.Size(559, 36);
            this.labelInstractions.TabIndex = 53;
            this.labelInstractions.Text = "This is the AppID of \"Design Patterns App 2.4\". The grader will use it to test yo" +
    "ur app.\r\nType here your own AppID to test it:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(591, 99);
            this.progressBar.Minimum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(600, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 90;
            this.progressBar.Value = 1;
            this.progressBar.Visible = false;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.Location = new System.Drawing.Point(16, 106);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(109, 25);
            this.labelFullName.TabIndex = 80;
            this.labelFullName.Text = "Full Name";
            // 
            // panelProfile
            // 
            this.panelProfile.Location = new System.Drawing.Point(317, 128);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(874, 453);
            this.panelProfile.TabIndex = 76;
            this.panelProfile.Visible = false;
            // 
            // panelFriends
            // 
            this.panelFriends.Location = new System.Drawing.Point(317, 128);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(874, 453);
            this.panelFriends.TabIndex = 77;
            this.panelFriends.Visible = false;
            // 
            // panelPosts
            // 
            this.panelPosts.Location = new System.Drawing.Point(317, 128);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Size = new System.Drawing.Size(874, 453);
            this.panelPosts.TabIndex = 77;
            this.panelPosts.Visible = false;
            // 
            // panelStatuses
            // 
            this.panelStatuses.Location = new System.Drawing.Point(317, 128);
            this.panelStatuses.Name = "panelStatuses";
            this.panelStatuses.Size = new System.Drawing.Size(874, 453);
            this.panelStatuses.TabIndex = 78;
            this.panelStatuses.Visible = false;
            // 
            // panelPhotos
            // 
            this.panelPhotos.Location = new System.Drawing.Point(317, 128);
            this.panelPhotos.Name = "panelPhotos";
            this.panelPhotos.Size = new System.Drawing.Size(874, 453);
            this.panelPhotos.TabIndex = 78;
            this.panelPhotos.Visible = false;
            // 
            // panelPages
            // 
            this.panelPages.Location = new System.Drawing.Point(317, 128);
            this.panelPages.Name = "panelPages";
            this.panelPages.Size = new System.Drawing.Size(874, 453);
            this.panelPages.TabIndex = 78;
            this.panelPages.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.buttonProfile);
            this.panelMain.Controls.Add(this.buttonFriends);
            this.panelMain.Controls.Add(this.buttonStatuses);
            this.panelMain.Location = new System.Drawing.Point(317, 96);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(268, 30);
            this.panelMain.TabIndex = 75;
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(3, 3);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(83, 23);
            this.buttonProfile.TabIndex = 67;
            this.buttonProfile.Text = "Profile";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonFriends
            // 
            this.buttonFriends.Location = new System.Drawing.Point(92, 3);
            this.buttonFriends.Name = "buttonFriends";
            this.buttonFriends.Size = new System.Drawing.Size(83, 23);
            this.buttonFriends.TabIndex = 68;
            this.buttonFriends.Text = "Friends";
            this.buttonFriends.UseVisualStyleBackColor = true;
            this.buttonFriends.Click += new System.EventHandler(this.buttonFriends_Click);
            // 
            // buttonStatuses
            // 
            this.buttonStatuses.Location = new System.Drawing.Point(181, 3);
            this.buttonStatuses.Name = "buttonStatuses";
            this.buttonStatuses.Size = new System.Drawing.Size(83, 23);
            this.buttonStatuses.TabIndex = 69;
            this.buttonStatuses.Text = "Statuses";
            this.buttonStatuses.UseVisualStyleBackColor = true;
            this.buttonStatuses.Click += new System.EventHandler(this.buttonStatuses_Click);
            // 
            // panelInbox
            // 
            this.panelInbox.Location = new System.Drawing.Point(317, 128);
            this.panelInbox.Name = "panelInbox";
            this.panelInbox.Size = new System.Drawing.Size(874, 453);
            this.panelInbox.TabIndex = 79;
            this.panelInbox.Visible = false;
            // 
            // panelSecondary
            // 
            this.panelSecondary.Controls.Add(this.buttonPosts);
            this.panelSecondary.Controls.Add(this.buttonPages);
            this.panelSecondary.Controls.Add(this.buttonPhotos);
            this.panelSecondary.Location = new System.Drawing.Point(15, 145);
            this.panelSecondary.Name = "panelSecondary";
            this.panelSecondary.Size = new System.Drawing.Size(89, 87);
            this.panelSecondary.TabIndex = 74;
            // 
            // buttonPosts
            // 
            this.buttonPosts.Location = new System.Drawing.Point(3, 32);
            this.buttonPosts.Name = "buttonPosts";
            this.buttonPosts.Size = new System.Drawing.Size(83, 23);
            this.buttonPosts.TabIndex = 72;
            this.buttonPosts.Text = "Posts";
            this.buttonPosts.UseVisualStyleBackColor = true;
            this.buttonPosts.Click += new System.EventHandler(this.buttonPosts_Click);
            // 
            // buttonPages
            // 
            this.buttonPages.Location = new System.Drawing.Point(3, 61);
            this.buttonPages.Name = "buttonPages";
            this.buttonPages.Size = new System.Drawing.Size(83, 23);
            this.buttonPages.TabIndex = 73;
            this.buttonPages.Text = "Pages";
            this.buttonPages.UseVisualStyleBackColor = true;
            this.buttonPages.Click += new System.EventHandler(this.buttonPages_Click);
            // 
            // buttonPhotos
            // 
            this.buttonPhotos.Location = new System.Drawing.Point(3, 3);
            this.buttonPhotos.Name = "buttonPhotos";
            this.buttonPhotos.Size = new System.Drawing.Size(83, 23);
            this.buttonPhotos.TabIndex = 71;
            this.buttonPhotos.Text = "Photos";
            this.buttonPhotos.UseVisualStyleBackColor = true;
            this.buttonPhotos.Click += new System.EventHandler(this.buttonPhotos_Click);
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(317, 61);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 24);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1151026866028077";
            // 
            // buttonTravelBuddy
            // 
            this.buttonTravelBuddy.Location = new System.Drawing.Point(1076, 23);
            this.buttonTravelBuddy.Name = "buttonTravelBuddy";
            this.buttonTravelBuddy.Size = new System.Drawing.Size(110, 23);
            this.buttonTravelBuddy.TabIndex = 91;
            this.buttonTravelBuddy.Text = "Travel Buddy";
            this.buttonTravelBuddy.UseVisualStyleBackColor = true;
            this.buttonTravelBuddy.Visible = false;
            this.buttonTravelBuddy.Click += new System.EventHandler(this.buttonTravelBuddy_Click);
            // 
            // buttonVolunteer
            // 
            this.buttonVolunteer.Location = new System.Drawing.Point(1076, 58);
            this.buttonVolunteer.Name = "buttonVolunteer";
            this.buttonVolunteer.Size = new System.Drawing.Size(110, 23);
            this.buttonVolunteer.TabIndex = 92;
            this.buttonVolunteer.Text = "Volunteer";
            this.buttonVolunteer.UseVisualStyleBackColor = true;
            this.buttonVolunteer.Visible = false;
            this.buttonVolunteer.Click += new System.EventHandler(this.buttonVolunteer_Click);
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.Location = new System.Drawing.Point(560, 63);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(126, 22);
            this.checkBoxRememberMe.TabIndex = 93;
            this.checkBoxRememberMe.Text = "Remember Me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // pictureBoxAppVisability
            // 
            this.pictureBoxAppVisability.Location = new System.Drawing.Point(12, 590);
            this.pictureBoxAppVisability.Name = "pictureBoxAppVisability";
            this.pictureBoxAppVisability.Size = new System.Drawing.Size(1197, 29);
            this.pictureBoxAppVisability.TabIndex = 86;
            this.pictureBoxAppVisability.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(150, 96);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(136, 136);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // searchableListBoxMain
            // 
            this.searchableListBoxMain.AutoSize = true;
            this.searchableListBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchableListBoxMain.DataSource = null;
            this.searchableListBoxMain.DisplayMember = "";
            this.searchableListBoxMain.Location = new System.Drawing.Point(18, 241);
            this.searchableListBoxMain.Margin = new System.Windows.Forms.Padding(6);
            this.searchableListBoxMain.Name = "searchableListBoxMain";
            this.searchableListBoxMain.Size = new System.Drawing.Size(268, 340);
            this.searchableListBoxMain.TabIndex = 5;
            this.searchableListBoxMain.SelectedIndexChanged += new System.EventHandler(this.searchableListBoxMain_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1243, 622);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.pictureBoxAppVisability);
            this.Controls.Add(this.searchableListBoxMain);
            this.Controls.Add(this.buttonVolunteer);
            this.Controls.Add(this.buttonTravelBuddy);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSecondary);
            this.Controls.Add(this.panelPhotos);
            this.Controls.Add(this.panelPosts);
            this.Controls.Add(this.panelPages);
            this.Controls.Add(this.panelStatuses);
            this.Controls.Add(this.panelFriends);
            this.Controls.Add(this.panelProfile);
            this.Controls.Add(this.panelInbox);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.textBoxAppID);
            this.Controls.Add(this.labelInstractions);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Minimal App";
            this.panelMain.ResumeLayout(false);
            this.panelSecondary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppVisability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label labelInstractions;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonPages;
        private System.Windows.Forms.Button buttonPosts;
        private System.Windows.Forms.Button buttonPhotos;
        private System.Windows.Forms.Button buttonStatuses;
        private System.Windows.Forms.Button buttonFriends;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSecondary;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Panel panelStatuses;
        private System.Windows.Forms.Panel panelInbox;
        private System.Windows.Forms.Panel panelPhotos;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.Panel panelPages;
        private System.Windows.Forms.PictureBox pictureBoxAppVisability;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonTravelBuddy;
        private System.Windows.Forms.Button buttonVolunteer;
        private SearchableListBoxController searchableListBoxMain;
        private CheckBox checkBoxRememberMe;
    }
}

