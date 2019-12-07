using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHomeWork.Models
{
    public class Portfolio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string InfoAboutMe { get; set; } //Информация о себе
        public string InfoAboutStudy { get; set; } // Инф об учебе
        public string AboutWork { get; set; } //Инф. о работе
        public string Achievement { get; set; }// Достижения
        public byte[] Image { get; set; } //Примеры работ
        
    }
}
