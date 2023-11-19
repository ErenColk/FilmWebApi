using FilmWebApi.BLL.DTO.FilmDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Validations.FilmValidation
{
    public class CreateFilmWithActorCategoryValid : AbstractValidator<CreateFilmActorCategoryDTO>
    {
        public CreateFilmWithActorCategoryValid()
        {
            RuleFor(a => a.Name).NotEmpty().MaximumLength(30).MinimumLength(1).WithMessage("Category isim alanı boş geçilemez. En az 1 en çok 30 karakter olmalıdır.");
            RuleFor(a => a.Year).Must(Year => BeValidBirthdate(Year)).WithMessage("Geçerli yıl giriniz. (1900- 2023 aralığında)");
            RuleFor(a => a.CategoryId).GreaterThan(0).WithMessage("Kategori Id 0 dan büyük olmalı.");
            RuleFor(a => a.ActorId).GreaterThan(0).WithMessage("Aktör Id 0 dan büyük olmalı.");

        }
        private bool BeValidBirthdate(int Year)
        {
            return Year < 2023 && Year >= 1900;
        }
    }
}
