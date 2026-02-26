using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Exo3TDD;

namespace Exo3TDD
{


    public class NotFoundException : Exception
    {
        public NotFoundException() : base("La recherche doit contenir au moins 2 caractères.") { }
    }

    public class RechercheVille
    {
        private List<string> _villes;

        public RechercheVille(List<string> villes)
        {
            _villes = villes;
        }

        public List<string> Rechercher(string mot)
        {
            if (mot == "*") return _villes;

            if (string.IsNullOrEmpty(mot) || mot.Length < 2)
            {
                throw new NotFoundException();
            }

            return _villes
                .Where(v => v.Contains(mot, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
