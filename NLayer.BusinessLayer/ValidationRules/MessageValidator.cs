using FluentValidation;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Açıklama boş olamaz");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen 5 karakterden az değer girişi yapmayın");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
        }
    }
}
