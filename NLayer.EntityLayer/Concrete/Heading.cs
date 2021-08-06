using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.EntityLayer.Concrete
{
    //Başlık Sınıfı
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]

        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }


        public int CategoryID { get; set; }

        //virtual tanımı ile tablolar arası ilişki kurmak için tanımlandı
        public virtual Category Category { get; set; }


        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }


        public ICollection<Content> Contents { get; set; }

    }
}
