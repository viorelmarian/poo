namespace OnlinePlatform
{
    public class Admin : User
    {
        public Admin() : base() { }
        public Admin(int Id, string Nume, string Prenume, string Username, string Password, string Email, bool IsAdmin)
            : base(Id, Nume, Prenume, Username, Password, Email, IsAdmin) { }

        public override void WriteToFile()
        {
            string line = this.Id.ToString() + '|' +
                          this.Nume + '|' +
                          this.Prenume + '|' +
                          this.Username + '|' +
                          this.Password + '|' +
                          this.Email + '|' +
                          this.IsAdmin.ToString() + "\n";
            System.IO.File.WriteAllText("Administratori.txt", line);
        }
    }
}
