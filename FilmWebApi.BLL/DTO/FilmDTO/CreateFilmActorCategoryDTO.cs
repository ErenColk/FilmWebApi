﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.DTO.FilmDTO
{
    public class CreateFilmActorCategoryDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public int ActorId { get; set; }

    }
}
