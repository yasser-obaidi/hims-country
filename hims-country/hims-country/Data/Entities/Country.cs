using HimsCountry.Data.Entities.Commen;
using System.ComponentModel.DataAnnotations;

namespace HimsCountry.Data.Entities
{

    public class Country : BaseEntity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string NumericIsoCode { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }






        



    }
}




