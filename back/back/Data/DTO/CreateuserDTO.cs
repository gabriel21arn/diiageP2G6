namespace back.Data.DTO
{
    public class CreateUserDTO
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public int ApplicationId { get; set; }
    }

}
