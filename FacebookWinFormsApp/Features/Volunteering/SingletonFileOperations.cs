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

        public void SaveVolunteerPersonToFile(Volunteer i_VoluinteerPerson)
        {
            List<Volunteer> existingVolunteers = new List<Volunteer>();
            Volunteer volunteerPerson = new Volunteer()
            {
                Subject = i_VoluinteerPerson.Subject,
                Location = i_VoluinteerPerson.Location,
                PhoneNumber = i_VoluinteerPerson.PhoneNumber,
                StartDate = i_VoluinteerPerson.StartDate,
                EndDate = i_VoluinteerPerson.EndDate
            };

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Volunteer>));

                    existingVolunteers = (List<Volunteer>)serializer.Deserialize(stream);
                }
            }

            existingVolunteers.Add(volunteerPerson);

            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<Volunteer>));
                
                listSerializer.Serialize(stream, existingVolunteers);
            }
        }

        public void SaveToFile(List<Volunteer> i_VoluinteerPerson)
        {
            using (FileStream stream = new FileStream(r_FileName, FileMode.Create))
            {
                XmlSerializer listSerializer = new XmlSerializer(typeof(List<Volunteer>));
                
                listSerializer.Serialize(stream, i_VoluinteerPerson);
            }
        }

        public List<Volunteer> LoadFromFile()
        {
            List<Volunteer> volunteerPeople = new List<Volunteer>();

            if (File.Exists(r_FileName))
            {
                using (FileStream stream = new FileStream(r_FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Volunteer>));
                    
                    volunteerPeople = (List<Volunteer>)serializer.Deserialize(stream);
                }
            }

            return volunteerPeople;
        }
    }
}
