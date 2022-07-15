namespace DataAccess.Context.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Cart Cart { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Role Role { get; set; }
    }
}
