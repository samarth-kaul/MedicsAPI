namespace MedicsAPI.Models
{
    public class Users
    {
        public int id { get; set; }
        public required string firstname { get; set; }
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string username { get; set; }
        public required string phone { get; set; }
        public DateTime? dob { get; set; }
        public required string passwordHash { get; set; }
        public required string passwordSalt { get; set; }
        public string? verificationToken { get; set; }
        public DateTime? verifiedAt { get; set; }
        public string? passwordResetToken { get; set; }
        public DateTime? resetTokenExpires { get; set; }
        public required int refusertype { get; set;}
        public required int refgender { get; set; }
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public DateTime regDate { get; set; } = DateTime.Now;


        // foreign key references
        //public required UserType refUserType { get; set; }
        //public required Gender refGender { get; set; }
    }
}
