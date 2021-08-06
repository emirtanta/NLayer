using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }

        //kategori silindiğinde veri tabanında silinmeyip sadece statü değerini pasif hale getirerek bağlı olan değerlerinde silinmemesini sağlanır
        public bool CategoryStatus { get; set; }

        //Icollection
        public ICollection<Heading> Headings { get; set; }
    }
}
