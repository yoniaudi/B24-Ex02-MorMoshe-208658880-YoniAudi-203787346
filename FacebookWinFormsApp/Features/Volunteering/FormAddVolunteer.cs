using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public partial class FormAddVolunteer : Form
    {
        private readonly AddVolunteerService r_VolunteerService = null;
        private DateTime m_StartAvailableDate;
        private DateTime m_EndAvailableDate;

        public FormAddVolunteer()
        {
            InitializeComponent();
            m_StartAvailableDate = DateTime.Now;
            m_EndAvailableDate = DateTime.Now;
            r_VolunteerService = new AddVolunteerService();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_StartAvailableDate = dateTimePickerStartDate.Value;
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            m_EndAvailableDate = dateTimePickerEndDate.Value;
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void buttonAddVolunteer_Click(object sender, EventArgs e)
        {
            bool isDataValid = validateData(out VolunteerModel volunteer);

            if (isDataValid == true)
            {
                r_VolunteerService.SaveVolunteerPerson(volunteer);
                MessageBox.Show("Data Saved Successfully!");
            }
        }

        private VolunteerModel collectFormData()
        {
            return new VolunteerModel()
            {
                Subject = comboBoxSubject.Text,
                Location = textBoxLocation.Text,
                PhoneNumber = textBoxPhone.Text,
                StartDate = m_StartAvailableDate,
                EndDate = m_EndAvailableDate
            };
        }

        private bool validateData(out VolunteerModel io_Volunteer)
        {
            string errorMessage = "";
            bool isValid = true;

            io_Volunteer = collectFormData();
            isValid = r_VolunteerService.DataValidation(io_Volunteer, out errorMessage);

            if (!isValid)
            {
                MessageBox.Show(errorMessage);
            }

            return isValid;
        }
    }
}