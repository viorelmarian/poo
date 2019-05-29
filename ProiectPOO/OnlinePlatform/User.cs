namespace OnlinePlatform
{
    public class User
    {
        public int Id { get; private set; }
        public string Nume { get; private set; }
        public string Prenume { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; set; }
        public User()
        {
        }

        public User(int Id, string Nume, string Prenume, string Username, string Password, string Email, bool IsAdmin)
        {
            this.Id = Id;
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.IsAdmin = IsAdmin;
        }

        public virtual void WriteToFile() { }
    }
}
