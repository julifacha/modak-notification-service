namespace Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        protected User(string id, string name, string email) 
        { 
            Id = id;
            Name = name;
            Email = email;
        }

        public static User Create(string id, string name, string email)
        {
            return new User(id, name, email);
        }
    }
}
