using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.BLL.DTO.CategoryDTO;
using FilmWebApi.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Validations.CategoryValidation
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryDTO>
    {

        public CreateCategoryValidation()
        {
            RuleFor(a=> a.Name).NotEmpty().MaximumLength(30).MinimumLength(2).WithMessage("Category isim alanı boş geçilemez. En az 2 en çok 30 karakter olmalıdır.");


        }


    }
}
