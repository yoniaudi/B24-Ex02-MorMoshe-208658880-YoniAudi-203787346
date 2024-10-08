﻿using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormFindVolunteer : Form
    {
        private readonly FindVolunteerService r_VolunteerService = null;

        public FormFindVolunteer(User i_LoggedInUser)
        {
            InitializeComponent();
            r_VolunteerService = new FindVolunteerService(i_LoggedInUser);
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            r_VolunteerService.UpdateStartDate(dateTimePickerStartDate.Value);
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            r_VolunteerService.UpdateEndDate(dateTimePickerEndDate.Value);
        }

        private void buttonFindOpportunities_Click(object sender, EventArgs e)
        {
            findOpportunities();
        }

        private void findOpportunities()
        {
            VolunteerModel volunteer = collectDataFromForm();
            bool isDataValid = r_VolunteerService.DataValidation(volunteer, out string errorMessage);

            if (isDataValid == true)
            {
                List<VolunteerModel> foundOpportunities = null;

                buttonFindOpportunities.Cursor = Cursors.AppStarting;
                foundOpportunities = r_VolunteerService.FindMatchingOpportunities(volunteer);
                displayVolunteerPlaces(foundOpportunities);
                buttonFindOpportunities.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private VolunteerModel collectDataFromForm()
        {
            return new VolunteerModel
            {
                Subject = comboBoxSubject.Text,
                Location = textBoxLocation.Text,
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value
            };
        }

        private void displayVolunteerPlaces(List<VolunteerModel> i_Volunteers)
        {
            List<string> volunteers = new List<string>();

            foreach (VolunteerModel volunteer in i_Volunteers)
            {
                volunteers.Add(volunteer.ToString());
            }

            listBoxFoundOpportunities.DataSource = volunteers;
        }
    }
}