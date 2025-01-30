using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_Domain
{
    [Serializable]
    [Table("Book")]
    public class Book : IEntity<int>
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [StringLength(50)]
        public string BookName { get; set; }

        [Required]
        [StringLength(15)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(10)]
        public string Edition { get; set; }

        [Required]
        [StringLength(15)]
        public string CellPhoneNo { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "ISBN must be 5 digits.")]
        public string ISBN { get; set; }
    }
}
