namespace MedicsAPI.Models
{
    public class Users
    {
        public int id { get; set; }
        public required string username { get; set; }
        public required string firstname { get; set; }
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string phone { get; set; }
        public DateTime? dob { get; set; }
        public required string passwordhash { get; set; }
        public required string passwordsalt { get; set; }
        public string? verificationtoken { get; set; }
        public DateTime? verifiedat { get; set; }
        public string? passwordresettoken { get; set; }
        public DateTime? resettokenexpires { get; set; }
        public required int refusertype { get; set;}
        public required int refgender { get; set; }
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public DateTime regdate { get; set; } = DateTime.Now;


        // foreign key references
        //public required UserType refUserType { get; set; }
        //public required Gender refGender { get; set; }
    }
}
