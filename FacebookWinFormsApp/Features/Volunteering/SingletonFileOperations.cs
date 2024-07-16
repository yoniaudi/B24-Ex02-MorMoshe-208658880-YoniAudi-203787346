using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public sealed class SingletonFileOperations
    {
        private readonly string r_FileName = null;

        private SingletonFileOperations()
        {
            r_FileName = Application.ExecutablePath + "volunteers.xml";
        }

        public void SaveVolunteerPersonToFile(VolunteerModel i_Volunteer)
        {
            List<VolunteerModel> existingVolunteers = new List<VolunteerModel>();
            VolunteerModel volunteer = new VolunteerModel()
            {
                Subject = i_Volunteer.Subject,
                Location = i_Volunteer.Location,
                PhoneNumber = i_Volunteer.PhoneNumber,
                StartDate = i_Volunteer.StartDate,
                EndDate = i_Volunteer.EndDate
            };

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerModel>));

                    existingVolunteers = (List<VolunteerModel>)serializer.Deserialize(stream);
                }
            }

            existingVolunteers.Add(volunteer);

            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerModel>));
                
                listSerializer.Serialize(stream, existingVolunteers);
            }
        }

        public void SaveToFile(List<VolunteerModel> i_Volunteers)
        {
            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<VolunteerModel>));
                
                listSerializer.Serialize(stream, i_Volunteers);
            }
        }

        public List<VolunteerModel> LoadFromFile()
        {
            List<VolunteerModel> volunteers = new List<VolunteerModel>();

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VolunteerModel>));
                    
                    volunteers = (List<VolunteerModel>)serializer.Deserialize(stream);
                }
            }

            return volunteers;
        }
    }
}