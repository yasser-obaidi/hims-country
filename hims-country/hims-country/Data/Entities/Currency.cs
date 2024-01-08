using HimsCountry.Data.Entities.Commen;
using System.ComponentModel.DataAnnotations;

namespace HimsCountry.Data.Entities
{

    public class Currency : BaseEntity
    {

        [Key]
        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string CurrencyCode { get; set; }
        public  decimal Rate { get; set; }
        public  string DisplayLocale { get; set; }
        public  bool IsActive { get; set; }
        public  bool IsDefault { get; set; }
        public  int DisplayOrder { get; set; }
        public  DateTime CreatedAt { get; set; }
        public  DateTime UpdatedAt { get; set; }


    }
}




