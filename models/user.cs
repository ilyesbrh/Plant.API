namespace Plant.API.models
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}