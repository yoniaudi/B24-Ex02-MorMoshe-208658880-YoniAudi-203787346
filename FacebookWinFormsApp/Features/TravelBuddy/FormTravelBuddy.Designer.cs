using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.TravelBuddy
{
    public partial class FormTravelBuddy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCountry = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.textBoxMinAge = new System.Windows.Forms.TextBox();
            this.buttonFindMatch = new System.Windows.Forms.Button();
            this.checkBoxAge = new System.Windows.Forms.CheckBox();
            this.checkBoxGender = new System.Windows.Forms.CheckBox();
            this.textBoxArrivalDate = new System.Windows.Forms.TextBox();
            this.textBoxDepartureDate = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.comboBoxCountries = new System.Windows.Forms.ComboBox();
            this.listBoxTravelBuddies = new System.Windows.Forms.ListBox();
            this.labelTravelBuddies = new System.Windows.Forms.Label();
            this.labelTraveledFriends = new System.Windows.Forms.Label();
            this.listBoxTraveledFriends = new System.Windows.Forms.ListBox();
            this.labelAgeRange = new System.Windows.Forms.Label();
            this.textBoxMaxAge = new System.Windows.Forms.TextBox();
            this.labelTravelBuddy = new System.Windows.Forms.Label();
            this.labelDetail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(13, 47);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(46, 13);
            this.labelCountry.TabIndex = 0;
            this.labelCountry.Text = "Country:";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(16, 124);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(8);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 2;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBoxGender.Location = new System.Drawing.Point(77, 321);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(166, 21);
            this.comboBoxGender.TabIndex = 5;
            this.comboBoxGender.Visible = false;
            // 
            // textBoxMinAge
            // 
            this.textBoxMinAge.Location = new System.Drawing.Point(130, 295);
            this.textBoxMinAge.Name = "textBoxMinAge";
            this.textBoxMinAge.Size = new System.Drawing.Size(52, 20);
            this.textBoxMinAge.TabIndex = 6;
            this.textBoxMinAge.Visible = false;
            this.textBoxMinAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinAge_KeyPress);
            // 
            // buttonFindMatch
            // 
            this.buttonFindMatch.Location = new System.Drawing.Point(16, 350);
            this.buttonFindMatch.Name = "buttonFindMatch";
            this.buttonFindMatch.Size = new System.Drawing.Size(227, 36);
            this.buttonFindMatch.TabIndex = 7;
            this.buttonFindMatch.Text = "Find Match!";
            this.buttonFindMatch.UseVisualStyleBackColor = true;
            this.buttonFindMatch.Click += new System.EventHandler(this.buttonFindMatch_Click);
            // 
            // checkBoxAge
            // 
            this.checkBoxAge.AutoSize = true;
            this.checkBoxAge.Location = new System.Drawing.Point(16, 297);
            this.checkBoxAge.Name = "checkBoxAge";
            this.checkBoxAge.Size = new System.Drawing.Size(45, 17);
            this.checkBoxAge.TabIndex = 8;
            this.checkBoxAge.Text = "Age";
            this.checkBoxAge.UseVisualStyleBackColor = true;
            this.checkBoxAge.CheckedChanged += new System.EventHandler(this.checkBoxAge_CheckedChanged);
            // 
            // checkBoxGender
            // 
            this.checkBoxGender.AutoSize = true;
            this.checkBoxGender.Location = new System.Drawing.Point(16, 323);
            this.checkBoxGender.Name = "checkBoxGender";
            this.checkBoxGender.Size = new System.Drawing.Size(61, 17);
            this.checkBoxGender.TabIndex = 9;
            this.checkBoxGender.Text = "Gender";
            this.checkBoxGender.UseVisualStyleBackColor = true;
            this.checkBoxGender.CheckedChanged += new System.EventHandler(this.checkBoxGender_CheckedChanged);
            // 
            // textBoxArrivalDate
            // 
            this.textBoxArrivalDate.Location = new System.Drawing.Point(77, 70);
            this.textBoxArrivalDate.Name = "textBoxArrivalDate";
            this.textBoxArrivalDate.Size = new System.Drawing.Size(166, 20);
            this.textBoxArrivalDate.TabIndex = 10;
            this.textBoxArrivalDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxArrivalDate_KeyPress);
            // 
            // textBoxDepartureDate
            // 
            this.textBoxDepartureDate.Location = new System.Drawing.Point(77, 97);
            this.textBoxDepartureDate.Name = "textBoxDepartureDate";
            this.textBoxDepartureDate.Size = new System.Drawing.Size(166, 20);
            this.textBoxDepartureDate.TabIndex = 11;
            this.textBoxDepartureDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDepartureDate_KeyPress);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(13, 74);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 12;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(13, 101);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 13;
            this.labelEndDate.Text = "End Date:";
            // 
            // comboBoxCountries
            // 
            this.comboBoxCountries.FormattingEnabled = true;
            this.comboBoxCountries.Location = new System.Drawing.Point(77, 43);
            this.comboBoxCountries.Name = "comboBoxCountries";
            this.comboBoxCountries.Size = new System.Drawing.Size(166, 21);
            this.comboBoxCountries.TabIndex = 14;
            // 
            // listBoxTravelBuddies
            // 
            this.listBoxTravelBuddies.FormattingEnabled = true;
            this.listBoxTravelBuddies.Location = new System.Drawing.Point(6, 409);
            this.listBoxTravelBuddies.Name = "listBoxTravelBuddies";
            this.listBoxTravelBuddies.Size = new System.Drawing.Size(147, 147);
            this.listBoxTravelBuddies.TabIndex = 15;
            // 
            // labelTravelBuddies
            // 
            this.labelTravelBuddies.AutoSize = true;
            this.labelTravelBuddies.Location = new System.Drawing.Point(3, 393);
            this.labelTravelBuddies.Name = "labelTravelBuddies";
            this.labelTravelBuddies.Size = new System.Drawing.Size(81, 13);
            this.labelTravelBuddies.TabIndex = 16;
            this.labelTravelBuddies.Text = "Travel Buddies:";
            // 
            // labelTraveledFriends
            // 
            this.labelTraveledFriends.AutoSize = true;
            this.labelTraveledFriends.Location = new System.Drawing.Point(156, 393);
            this.labelTraveledFriends.Name = "labelTraveledFriends";
            this.labelTraveledFriends.Size = new System.Drawing.Size(120, 13);
            this.labelTraveledFriends.TabIndex = 18;
            this.labelTraveledFriends.Text = "Friends who were there:";
            // 
            // listBoxTraveledFriends
            // 
            this.listBoxTraveledFriends.FormattingEnabled = true;
            this.listBoxTraveledFriends.Location = new System.Drawing.Point(159, 409);
            this.listBoxTraveledFriends.Name = "listBoxTraveledFriends";
            this.listBoxTraveledFriends.Size = new System.Drawing.Size(147, 147);
            this.listBoxTraveledFriends.TabIndex = 17;
            // 
            // labelAgeRange
            // 
            this.labelAgeRange.AutoSize = true;
            this.labelAgeRange.Location = new System.Drawing.Point(70, 299);
            this.labelAgeRange.Name = "labelAgeRange";
            this.labelAgeRange.Size = new System.Drawing.Size(42, 13);
            this.labelAgeRange.TabIndex = 19;
            this.labelAgeRange.Text = "Range:";
            this.labelAgeRange.Visible = false;
            // 
            // textBoxMaxAge
            // 
            this.textBoxMaxAge.Location = new System.Drawing.Point(191, 295);
            this.textBoxMaxAge.Name = "textBoxMaxAge";
            this.textBoxMaxAge.Size = new System.Drawing.Size(52, 20);
            this.textBoxMaxAge.TabIndex = 20;
            this.textBoxMaxAge.Visible = false;
            this.textBoxMaxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxAge_KeyPress);
            // 
            // labelTravelBuddy
            // 
            this.labelTravelBuddy.AutoSize = true;
            this.labelTravelBuddy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTravelBuddy.Location = new System.Drawing.Point(12, 9);
            this.labelTravelBuddy.Name = "labelTravelBuddy";
            this.labelTravelBuddy.Size = new System.Drawing.Size(100, 20);
            this.labelTravelBuddy.TabIndex = 21;
            this.labelTravelBuddy.Text = "Travel Buddy";
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Location = new System.Drawing.Point(118, 16);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(136, 13);
            this.labelDetail.TabIndex = 22;
            this.labelDetail.Text = "Find someone to travel with";
            // 
            // FormTravelBuddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(314, 568);
            this.Controls.Add(this.labelDetail);
            this.Controls.Add(this.labelTravelBuddy);
            this.Controls.Add(this.textBoxMaxAge);
            this.Controls.Add(this.labelAgeRange);
            this.Controls.Add(this.labelTraveledFriends);
            this.Controls.Add(this.listBoxTraveledFriends);
            this.Controls.Add(this.labelTravelBuddies);
            this.Controls.Add(this.listBoxTravelBuddies);
            this.Controls.Add(this.comboBoxCountries);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.textBoxDepartureDate);
            this.Controls.Add(this.textBoxArrivalDate);
            this.Controls.Add(this.checkBoxGender);
            this.Controls.Add(this.checkBoxAge);
            this.Controls.Add(this.buttonFindMatch);
            this.Controls.Add(this.textBoxMinAge);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.labelCountry);
            this.MaximizeBox = false;
            this.Name = "FormTravelBuddy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Buddy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelCountry;
        private MonthCalendar monthCalendar;
        private ComboBox comboBoxGender;
        private TextBox textBoxMinAge;
        private Button buttonFindMatch;
        private CheckBox checkBoxAge;
        private CheckBox checkBoxGender;
        private TextBox textBoxArrivalDate;
        private TextBox textBoxDepartureDate;
        private Label labelStartDate;
        private Label labelEndDate;
        private ComboBox comboBoxCountries;
        private ListBox listBoxTravelBuddies;
        private Label labelTravelBuddies;
        private Label labelTraveledFriends;
        private ListBox listBoxTraveledFriends;
        private Label labelAgeRange;
        private TextBox textBoxMaxAge;
        private Label labelTravelBuddy;
        private Label labelDetail;
    }
}