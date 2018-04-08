namespace Contacts.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Company { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string Middle { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Department { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [NotMapped]
        public string FullName
        {
            get => $"{FirstName}{(!string.IsNullOrWhiteSpace(Middle) ? $" {Middle} " : " ")}{ LastName}";
        }
    }
}
