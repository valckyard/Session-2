using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Cours10Exercice
{
    public struct Equipe
    {
        public string Nom;
        public List<Joueur> ListeEquipe;
        public int MaxJoueur;
        public int CurrentPlayer;
        public int Score;

        public Equipe(string nomequipe)
        {
            Nom = nomequipe;
            ListeEquipe = new List<Joueur>();
            Score = 0;
            MaxJoueur = ListeEquipe.Count;
            CurrentPlayer = 0;
        }

        public int Nextplayer()
        {
            ++CurrentPlayer;
            if (CurrentPlayer == MaxJoueur)
            {
                CurrentPlayer = 0;
            }

            return CurrentPlayer;
        }



        public List<Joueur> InitJoueurs()
        {
            ListeEquipe = new List<Joueur>();
            return ListeEquipe;

        }

        public List<Joueur> AddPlayer(Joueur newplayer)
        {
            ListeEquipe.Add(newplayer);
            return ListeEquipe;
        }
    }
}