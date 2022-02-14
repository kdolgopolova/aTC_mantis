namespace mantis_tests
{
    public class AccountData
    {
        public object Id { get; internal set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public AccountData()
        {
        }

        public AccountData(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}