namespace AutoMapper.Demo.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; } // Assuming AddressLine is a concatenation of Address properties
        public int OrderCount { get; set; }
        public string MemberSince { get; set; }
    }
}
