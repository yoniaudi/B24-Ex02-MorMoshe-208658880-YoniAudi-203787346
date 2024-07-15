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

        public void SaveVolunteerPersonToFile(Volunteer i_Volunteer)
        {
            List<Volunteer> existingVolunteers = new List<Volunteer>();
            Volunteer volunteer = new Volunteer()
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Volunteer>));

                    existingVolunteers = (List<Volunteer>)serializer.Deserialize(stream);
                }
            }

            existingVolunteers.Add(volunteer);

            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<Volunteer>));
                
                listSerializer.Serialize(stream, existingVolunteers);
            }
        }

        public void SaveToFile(List<Volunteer> i_Volunteers)
        {
            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<Volunteer>));
                
                listSerializer.Serialize(stream, i_Volunteers);
            }
        }

        public List<Volunteer> LoadFromFile()
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Volunteer>));
                    
                    volunteers = (List<Volunteer>)serializer.Deserialize(stream);
                }
            }

            return volunteers;
        }
    }
}