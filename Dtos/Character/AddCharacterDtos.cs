using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Character
{
    public class AddCharacterDtos
    {
        public string Name { get; set; } = "Yunin";// asigno un valor por defecto

        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; }   = 10;
        public int Defense { get; set; }    = 10;
        public int Intelligence { get; set; }   = 10;
        public RpgClass Clase   { get; set; }   = RpgClass.Knight;
    }
}