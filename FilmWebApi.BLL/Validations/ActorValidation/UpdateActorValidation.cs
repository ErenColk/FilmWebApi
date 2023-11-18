using FilmWebApi.BLL.DTO.ActorDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Validations.ActorValidation
{
    public class UpdateActorValidation : AbstractValidator<UpdateActorDTO>
    {
        public UpdateActorValidation()
        {
            RuleFor(a=> a.Id).GreaterThan(0).WithMessage("Id 1 den küçük olamaz...");
            RuleFor(a => a.Name).NotEmpty().MinimumLength(3).MaximumLength(30).WithMessage("İsim alani bos gecilemez. En az 3 en fazla 30 karakter icermelidir.");
            RuleFor(a => a.LastName).NotEmpty().MinimumLength(3).MaximumLength(30).WithMessage("Soyisim alani bos gecilemez. En az 3 en fazla 30 karakter icermelidir.");
            RuleFor(a => a.BirthDate).Must(BirthDate => BeValidBirthdate(BirthDate)).WithMessage("Dogum yilini gecerli bir tarih girmelisiniz...");
            RuleFor(a => a.FilmId).GreaterThan(0).WithMessage("Film Id si 1 den küçük olamaz...");
        }


        private bool BeValidBirthdate(DateTime birthdate)
        {
            return birthdate.Year < 2005 && birthdate.Year >= 1938;
        }
    }
}
