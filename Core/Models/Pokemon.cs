using System;
using System.Collections.Generic;
using System.Text;
using UseCollections.Core.Enums;

namespace UseCollections.Core.Models
{
    public class Pokemon
    {
        public int Id;
        public string Name;
        public PokemonType Type;

        public Pokemon(int id, string name, PokemonType type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
        }
    }
}
