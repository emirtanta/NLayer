﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.EntityLayer.Concrete
{
    //Kullanıcılar kendi arasında mesajlaşabileci sınıf(Admine de yazabilir)
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        //gönderen kişi(Session üzerinden kotrol edilecek)
        public string SenderMail { get; set; }

        [StringLength(50)]
        //alıcı kişi(Session üzerinden kotrol edilecek)
        public string ReceiverMail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
