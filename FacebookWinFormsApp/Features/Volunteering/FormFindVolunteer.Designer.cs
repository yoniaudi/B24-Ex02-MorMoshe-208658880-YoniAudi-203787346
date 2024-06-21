namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormFindVolunteer
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
            this.labelFindVolunteer = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelAvailableTime = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.buttonFindOpportunities = new System.Windows.Forms.Button();
            this.listBoxFoundOpportunities = new System.Windows.Forms.ListBox();
            this.labelOpportunities = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFindVolunteer
            // 
            this.labelFindVolunteer.AutoSize = true;
            this.labelFindVolunteer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFindVolunteer.Location = new System.Drawing.Point(167, 9);
            this.labelFindVolunteer.Name = "labelFindVolunteer";
            this.labelFindVolunteer.Size = new System.Drawing.Size(113, 20);
            this.labelFindVolunteer.TabIndex = 0;
            this.labelFindVolunteer.Text = "Find Volunteer";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(93, 61);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(46, 13);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Subject:";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(93, 88);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(47, 13);
            this.labelLocation.TabIndex = 2;
            this.labelLocation.Text = "location:";
            // 
            // labelAvailableTime
            // 
            this.labelAvailableTime.AutoSize = true;
            this.labelAvailableTime.Location = new System.Drawing.Point(93, 119);
            this.labelAvailableTime.Name = "labelAvailableTime";
            this.labelAvailableTime.Size = new System.Drawing.Size(82, 13);
            this.labelAvailableTime.TabIndex = 3;
            this.labelAvailableTime.Text = "-Available Time-";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(153, 145);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 4;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(156, 84);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(200, 20);
            this.textBoxLocation.TabIndex = 5;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Items.AddRange(new object[] {
            "Teaching",
            "Environment",
            "Health",
            "Community Service",
            "Animal Care",
            "Sports"});
            this.comboBoxSubject.Location = new System.Drawing.Point(156, 57);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSubject.TabIndex = 6;
            // 
            // buttonFindOpportunities
            // 
            this.buttonFindOpportunities.Location = new System.Drawing.Point(318, 198);
            this.buttonFindOpportunities.Name = "buttonFindOpportunities";
            this.buttonFindOpportunities.Size = new System.Drawing.Size(119, 42);
            this.buttonFindOpportunities.TabIndex = 7;
            this.buttonFindOpportunities.Text = "Find Opportunities";
            this.buttonFindOpportunities.UseVisualStyleBackColor = true;
            this.buttonFindOpportunities.Click += new System.EventHandler(this.buttonFindOpportunities_Click);
            // 
            // listBoxFoundOpportunities
            // 
            this.listBoxFoundOpportunities.FormattingEnabled = true;
            this.listBoxFoundOpportunities.Location = new System.Drawing.Point(12, 246);
            this.listBoxFoundOpportunities.Name = "listBoxFoundOpportunities";
            this.listBoxFoundOpportunities.Size = new System.Drawing.Size(431, 212);
            this.listBoxFoundOpportunities.TabIndex = 8;
            // 
            // labelOpportunities
            // 
            this.labelOpportunities.AutoSize = true;
            this.labelOpportunities.Location = new System.Drawing.Point(14, 230);
            this.labelOpportunities.Name = "labelOpportunities";
            this.labelOpportunities.Size = new System.Drawing.Size(70, 13);
            this.labelOpportunities.TabIndex = 9;
            this.labelOpportunities.Text = "Opportunites:";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(153, 171);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 10;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(90, 149);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 11;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(90, 175);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 12;
            this.labelEndDate.Text = "End Date:";
            // 
            // FormFindVolunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(455, 464);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.labelOpportunities);
            this.Controls.Add(this.listBoxFoundOpportunities);
            this.Controls.Add(this.buttonFindOpportunities);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelAvailableTime);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelFindVolunteer);
            this.MaximizeBox = false;
            this.Name = "FormFindVolunteer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFindVolunteer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFindVolunteer;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelAvailableTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Button buttonFindOpportunities;
        private System.Windows.Forms.ListBox listBoxFoundOpportunities;
        private System.Windows.Forms.Label labelOpportunities;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
    }
}