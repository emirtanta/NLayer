using FluentValidation;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            //kategori adı için fulent validation
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkımıda kısmını boş geçemezsiniz");
            //RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanı kısmını boş geçemezsiniz");

            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");

            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");

            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
        }
    }
}
