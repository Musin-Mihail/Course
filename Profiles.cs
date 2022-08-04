namespace Course
{
    public class ProfilesClass
    {
        public List<Profile> profiles = new List<Profile>();
        public void CreateProfile(string FirstName, string LastName, string MiddleName, string Foto, string SocialID, string Email, string PhoneNumber)
        {
            Profile profile = new Profile();
            profile.FirstName = FirstName;
            profile.LastName = LastName;
            profile.MiddleName = MiddleName;
            profile.Foto = Foto;
            profile.SocialID = SocialID;
            profile.Email = Email;
            profile.PhoneNumber = PhoneNumber;
            profiles.Add(profile);
        }
        public string WriteAllProfiles()
        {
            string text = "";
            foreach (Profile profile in profiles)
            {
                text += profile.LastName + " " + profile.FirstName + " " + profile.MiddleName + "\n";
                text += profile.Foto + "\n";
                text += profile.SocialID + "\n";
                text += profile.Email + "\n";
                text += profile.PhoneNumber + "\n";
            }
            return text;
        }
    }
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }
        public string SocialID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
