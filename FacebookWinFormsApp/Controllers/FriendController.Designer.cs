namespace BasicFacebookFeatures.Models
{
    public partial class FriendController
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
            this.labelFriendAlbums = new System.Windows.Forms.Label();
            this.flowLayoutPanelFriendPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFriendCommonFriends = new System.Windows.Forms.Label();
            this.labelFriendsOfFriend = new System.Windows.Forms.Label();
            this.labelFriendFullName = new System.Windows.Forms.Label();
            this.pictureBoxFriendProfile = new System.Windows.Forms.PictureBox();
            this.labelFriendBirthday = new System.Windows.Forms.Label();
            this.labelUserFriendBirthday = new System.Windows.Forms.Label();
            this.labelFriendLocation = new System.Windows.Forms.Label();
            this.labelUserFriendLocation = new System.Windows.Forms.Label();
            this.labelFriendEmail = new System.Windows.Forms.Label();
            this.labelUserFriendEmail = new System.Windows.Forms.Label();
            this.labelFriendLanguages = new System.Windows.Forms.Label();
            this.labelUserFriendLanguages = new System.Windows.Forms.Label();
            this.labelFriendStatuses = new System.Windows.Forms.Label();
            this.searchableListBoxControllerFriendsOfFriend = new BasicFacebookFeatures.Models.SearchableListBoxController();
            this.searchableListBoxControllerFriendsStatus = new BasicFacebookFeatures.Models.SearchableListBoxController();
            this.searchableListBoxControllerFriendAlbums = new BasicFacebookFeatures.Models.SearchableListBoxController();
            this.statusesModelFriendStatuses = new BasicFacebookFeatures.Models.StatusController();
            this.searchableListBoxControllerCommonFriends = new BasicFacebookFeatures.Models.SearchableListBoxController();
            this.panelFriendDisplay = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendProfile)).BeginInit();
            this.panelFriendDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFriendAlbums
            // 
            this.labelFriendAlbums.AutoSize = true;
            this.labelFriendAlbums.Location = new System.Drawing.Point(187, 226);
            this.labelFriendAlbums.Name = "labelFriendAlbums";
            this.labelFriendAlbums.Size = new System.Drawing.Size(44, 13);
            this.labelFriendAlbums.TabIndex = 108;
            this.labelFriendAlbums.Text = "Albums:";
            // 
            // flowLayoutPanelFriendPhotos
            // 
            this.flowLayoutPanelFriendPhotos.AutoScroll = true;
            this.flowLayoutPanelFriendPhotos.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelFriendPhotos.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelFriendPhotos.Name = "flowLayoutPanelFriendPhotos";
            this.flowLayoutPanelFriendPhotos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanelFriendPhotos.Size = new System.Drawing.Size(387, 201);
            this.flowLayoutPanelFriendPhotos.TabIndex = 106;
            // 
            // labelFriendCommonFriends
            // 
            this.labelFriendCommonFriends.AutoSize = true;
            this.labelFriendCommonFriends.Location = new System.Drawing.Point(561, 226);
            this.labelFriendCommonFriends.Name = "labelFriendCommonFriends";
            this.labelFriendCommonFriends.Size = new System.Drawing.Size(88, 13);
            this.labelFriendCommonFriends.TabIndex = 104;
            this.labelFriendCommonFriends.Text = "Common Friends:";
            // 
            // labelFriendsOfFriend
            // 
            this.labelFriendsOfFriend.AutoSize = true;
            this.labelFriendsOfFriend.Location = new System.Drawing.Point(374, 226);
            this.labelFriendsOfFriend.Name = "labelFriendsOfFriend";
            this.labelFriendsOfFriend.Size = new System.Drawing.Size(44, 13);
            this.labelFriendsOfFriend.TabIndex = 103;
            this.labelFriendsOfFriend.Text = "Friends:";
            // 
            // labelFriendFullName
            // 
            this.labelFriendFullName.AutoSize = true;
            this.labelFriendFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendFullName.Location = new System.Drawing.Point(1, 1);
            this.labelFriendFullName.Name = "labelFriendFullName";
            this.labelFriendFullName.Size = new System.Drawing.Size(109, 25);
            this.labelFriendFullName.TabIndex = 100;
            this.labelFriendFullName.Text = "Full Name";
            // 
            // pictureBoxFriendProfile
            // 
            this.pictureBoxFriendProfile.Location = new System.Drawing.Point(6, 29);
            this.pictureBoxFriendProfile.Name = "pictureBoxFriendProfile";
            this.pictureBoxFriendProfile.Size = new System.Drawing.Size(136, 136);
            this.pictureBoxFriendProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFriendProfile.TabIndex = 99;
            this.pictureBoxFriendProfile.TabStop = false;
            // 
            // labelFriendBirthday
            // 
            this.labelFriendBirthday.AutoSize = true;
            this.labelFriendBirthday.Location = new System.Drawing.Point(148, 29);
            this.labelFriendBirthday.Name = "labelFriendBirthday";
            this.labelFriendBirthday.Size = new System.Drawing.Size(48, 13);
            this.labelFriendBirthday.TabIndex = 92;
            this.labelFriendBirthday.Text = "Birthday:";
            // 
            // labelUserFriendBirthday
            // 
            this.labelUserFriendBirthday.AutoSize = true;
            this.labelUserFriendBirthday.Location = new System.Drawing.Point(217, 29);
            this.labelUserFriendBirthday.Name = "labelUserFriendBirthday";
            this.labelUserFriendBirthday.Size = new System.Drawing.Size(70, 13);
            this.labelUserFriendBirthday.TabIndex = 96;
            this.labelUserFriendBirthday.Text = "User Birthday";
            // 
            // labelFriendLocation
            // 
            this.labelFriendLocation.AutoSize = true;
            this.labelFriendLocation.Location = new System.Drawing.Point(148, 52);
            this.labelFriendLocation.Name = "labelFriendLocation";
            this.labelFriendLocation.Size = new System.Drawing.Size(51, 13);
            this.labelFriendLocation.TabIndex = 93;
            this.labelFriendLocation.Text = "Location:";
            // 
            // labelUserFriendLocation
            // 
            this.labelUserFriendLocation.AutoSize = true;
            this.labelUserFriendLocation.Location = new System.Drawing.Point(217, 52);
            this.labelUserFriendLocation.Name = "labelUserFriendLocation";
            this.labelUserFriendLocation.Size = new System.Drawing.Size(73, 13);
            this.labelUserFriendLocation.TabIndex = 97;
            this.labelUserFriendLocation.Text = "User Location";
            // 
            // labelFriendEmail
            // 
            this.labelFriendEmail.AutoSize = true;
            this.labelFriendEmail.Location = new System.Drawing.Point(148, 75);
            this.labelFriendEmail.Name = "labelFriendEmail";
            this.labelFriendEmail.Size = new System.Drawing.Size(35, 13);
            this.labelFriendEmail.TabIndex = 91;
            this.labelFriendEmail.Text = "Email:";
            // 
            // labelUserFriendEmail
            // 
            this.labelUserFriendEmail.AutoSize = true;
            this.labelUserFriendEmail.Location = new System.Drawing.Point(217, 75);
            this.labelUserFriendEmail.Name = "labelUserFriendEmail";
            this.labelUserFriendEmail.Size = new System.Drawing.Size(64, 13);
            this.labelUserFriendEmail.TabIndex = 95;
            this.labelUserFriendEmail.Text = "Friend Email";
            // 
            // labelFriendLanguages
            // 
            this.labelFriendLanguages.AutoSize = true;
            this.labelFriendLanguages.Location = new System.Drawing.Point(148, 98);
            this.labelFriendLanguages.Name = "labelFriendLanguages";
            this.labelFriendLanguages.Size = new System.Drawing.Size(63, 13);
            this.labelFriendLanguages.TabIndex = 94;
            this.labelFriendLanguages.Text = "Languages:";
            // 
            // labelUserFriendLanguages
            // 
            this.labelUserFriendLanguages.AutoSize = true;
            this.labelUserFriendLanguages.Location = new System.Drawing.Point(217, 98);
            this.labelUserFriendLanguages.Name = "labelUserFriendLanguages";
            this.labelUserFriendLanguages.Size = new System.Drawing.Size(85, 13);
            this.labelUserFriendLanguages.TabIndex = 98;
            this.labelUserFriendLanguages.Text = "User Languages";
            // 
            // labelFriendStatuses
            // 
            this.labelFriendStatuses.AutoSize = true;
            this.labelFriendStatuses.Location = new System.Drawing.Point(0, 226);
            this.labelFriendStatuses.Name = "labelFriendStatuses";
            this.labelFriendStatuses.Size = new System.Drawing.Size(51, 13);
            this.labelFriendStatuses.TabIndex = 109;
            this.labelFriendStatuses.Text = "Statuses:";
            // 
            // searchableListBoxControllerFriendsOfFriend
            // 
            this.searchableListBoxControllerFriendsOfFriend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchableListBoxControllerFriendsOfFriend.DataSource = null;
            this.searchableListBoxControllerFriendsOfFriend.DisplayMember = "";
            this.searchableListBoxControllerFriendsOfFriend.Location = new System.Drawing.Point(377, 243);
            this.searchableListBoxControllerFriendsOfFriend.Name = "searchableListBoxControllerFriendsOfFriend";
            this.searchableListBoxControllerFriendsOfFriend.Size = new System.Drawing.Size(181, 184);
            this.searchableListBoxControllerFriendsOfFriend.TabIndex = 112;
            this.searchableListBoxControllerFriendsOfFriend.SelectedIndexChanged += new System.EventHandler(this.searchableListBoxControllerFriendAlbums_SelectedIndexChanged);
            // 
            // searchableListBoxControllerFriendsStatus
            // 
            this.searchableListBoxControllerFriendsStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchableListBoxControllerFriendsStatus.DataSource = null;
            this.searchableListBoxControllerFriendsStatus.DisplayMember = "";
            this.searchableListBoxControllerFriendsStatus.Location = new System.Drawing.Point(3, 243);
            this.searchableListBoxControllerFriendsStatus.Name = "searchableListBoxControllerFriendsStatus";
            this.searchableListBoxControllerFriendsStatus.Size = new System.Drawing.Size(181, 184);
            this.searchableListBoxControllerFriendsStatus.TabIndex = 110;
            this.searchableListBoxControllerFriendsStatus.SelectedIndexChanged += new System.EventHandler(this.searchableListBoxControllerFriendsStatus_SelectedIndexChanged);
            // 
            // searchableListBoxControllerFriendAlbums
            // 
            this.searchableListBoxControllerFriendAlbums.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchableListBoxControllerFriendAlbums.DataSource = null;
            this.searchableListBoxControllerFriendAlbums.DisplayMember = "";
            this.searchableListBoxControllerFriendAlbums.Location = new System.Drawing.Point(190, 243);
            this.searchableListBoxControllerFriendAlbums.Name = "searchableListBoxControllerFriendAlbums";
            this.searchableListBoxControllerFriendAlbums.Size = new System.Drawing.Size(181, 184);
            this.searchableListBoxControllerFriendAlbums.TabIndex = 111;
            this.searchableListBoxControllerFriendAlbums.SelectedIndexChanged += new System.EventHandler(this.searchableListBoxControllerFriendAlbums_SelectedIndexChanged);
            // 
            // statusesModelFriendStatuses
            // 
            this.statusesModelFriendStatuses.Location = new System.Drawing.Point(0, 0);
            this.statusesModelFriendStatuses.Name = "statusesModelFriendStatuses";
            this.statusesModelFriendStatuses.Size = new System.Drawing.Size(387, 204);
            this.statusesModelFriendStatuses.TabIndex = 114;
            // 
            // searchableListBoxControllerCommonFriends
            // 
            this.searchableListBoxControllerCommonFriends.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchableListBoxControllerCommonFriends.DataSource = null;
            this.searchableListBoxControllerCommonFriends.DisplayMember = "";
            this.searchableListBoxControllerCommonFriends.Location = new System.Drawing.Point(564, 243);
            this.searchableListBoxControllerCommonFriends.Name = "searchableListBoxControllerCommonFriends";
            this.searchableListBoxControllerCommonFriends.Size = new System.Drawing.Size(181, 184);
            this.searchableListBoxControllerCommonFriends.TabIndex = 113;
            // 
            // panelFriendDisplay
            // 
            this.panelFriendDisplay.Controls.Add(this.statusesModelFriendStatuses);
            this.panelFriendDisplay.Controls.Add(this.flowLayoutPanelFriendPhotos);
            this.panelFriendDisplay.Location = new System.Drawing.Point(358, 21);
            this.panelFriendDisplay.Name = "panelFriendDisplay";
            this.panelFriendDisplay.Size = new System.Drawing.Size(387, 201);
            this.panelFriendDisplay.TabIndex = 115;
            // 
            // FriendModel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelFriendDisplay);
            this.Controls.Add(this.searchableListBoxControllerFriendsOfFriend);
            this.Controls.Add(this.labelFriendStatuses);
            this.Controls.Add(this.searchableListBoxControllerFriendsStatus);
            this.Controls.Add(this.labelFriendAlbums);
            this.Controls.Add(this.searchableListBoxControllerFriendAlbums);
            this.Controls.Add(this.labelFriendsOfFriend);
            this.Controls.Add(this.labelFriendCommonFriends);
            this.Controls.Add(this.searchableListBoxControllerCommonFriends);
            this.Controls.Add(this.labelFriendFullName);
            this.Controls.Add(this.pictureBoxFriendProfile);
            this.Controls.Add(this.labelFriendBirthday);
            this.Controls.Add(this.labelUserFriendBirthday);
            this.Controls.Add(this.labelFriendLocation);
            this.Controls.Add(this.labelUserFriendLocation);
            this.Controls.Add(this.labelFriendEmail);
            this.Controls.Add(this.labelUserFriendEmail);
            this.Controls.Add(this.labelFriendLanguages);
            this.Controls.Add(this.labelUserFriendLanguages);
            this.Name = "FriendModel";
            this.Size = new System.Drawing.Size(780, 431);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendProfile)).EndInit();
            this.panelFriendDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFriendAlbums;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriendPhotos;
        private System.Windows.Forms.Label labelFriendCommonFriends;
        private System.Windows.Forms.Label labelFriendsOfFriend;
        private System.Windows.Forms.Label labelFriendFullName;
        private System.Windows.Forms.PictureBox pictureBoxFriendProfile;
        private System.Windows.Forms.Label labelFriendBirthday;
        private System.Windows.Forms.Label labelUserFriendBirthday;
        private System.Windows.Forms.Label labelFriendLocation;
        private System.Windows.Forms.Label labelUserFriendLocation;
        private System.Windows.Forms.Label labelFriendEmail;
        private System.Windows.Forms.Label labelUserFriendEmail;
        private System.Windows.Forms.Label labelFriendLanguages;
        private System.Windows.Forms.Label labelUserFriendLanguages;
        private System.Windows.Forms.Label labelFriendStatuses;
        private SearchableListBoxController searchableListBoxControllerFriendsStatuses;
        private SearchableListBoxController searchableListBoxControllerFriendsStatus;
        private SearchableListBoxController searchableListBoxControllerFriendAlbums;
        private SearchableListBoxController searchableListBoxControllerFriendsOfFriend;
        private SearchableListBoxController searchableListBoxControllerCommonFriends;
        private StatusController statusesModelFriendStatuses;
        private System.Windows.Forms.Panel panelFriendDisplay;
    }
}
