using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHomeWork.Models
{
    public class PortfolioViewModel
    {
        public string InfoAboutMe { get; set; } //Информация о себе
        public string InfoAboutStudy { get; set; } // Инф об учебе
        public string AboutWork { get; set; } //Инф. о работе
        public string Achievement { get; set; }// Достижения
        public IFormFile Image { get; set; } //Примеры работ
    }
}
