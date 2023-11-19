using FilmWebApi.BLL.DTO.FilmDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Validations.FilmValidation
{
    public class UpdateFilmValidation : AbstractValidator<UpdateFilmDTO>
    {

        public UpdateFilmValidation()
        {
            RuleFor(a => a.Name).NotEmpty().MaximumLength(30).MinimumLength(1).WithMessage("Category isim alanı boş geçilemez. En az 1 en çok 30 karakter olmalıdır.");
            RuleFor(a => a.Year).Must(Year => BeValidBirthdate(Year)).WithMessage("Geçerli yıl giriniz. (1900- 2023 aralığında)");

        }
        private bool BeValidBirthdate(int Year)
        {
            return Year < 2023 && Year >= 1900;
        }
    }
}
