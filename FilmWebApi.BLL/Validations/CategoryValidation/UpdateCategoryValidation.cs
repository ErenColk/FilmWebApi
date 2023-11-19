using FilmWebApi.BLL.DTO.CategoryDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Validations.CategoryValidation
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDTO>
    {

        public UpdateCategoryValidation()
        {
            RuleFor(a=> a.Id).GreaterThan(0).WithMessage("Id 0 dan büyük bir değer olmalı");
            RuleFor(a => a.Name).NotEmpty().MaximumLength(30).MinimumLength(2).WithMessage("Category isim alanı boş geçilemez. En az 2 en çok 30 karakter olmalıdır.");


        }
    }
}
 