namespace Plant.API.models
{
    public class user
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}