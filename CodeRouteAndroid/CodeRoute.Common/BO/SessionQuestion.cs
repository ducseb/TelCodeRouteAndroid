using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeRoute.Common.BO
{
   public class SessionQuestion
    {
        public DateTime dateSerie;
        public string commantaire;
        public List<Reponse> lesReponses;
        public bool questionComplete;

        public SessionQuestion()
        {
            dateSerie=DateTime.Now;
            lesReponses = new List<Reponse>();
        }


        public Reponse getReponse(int numReponse)
        {
            if (lesReponses.Where(p => p.numeroquestion == numReponse).Count() > 0)
            {
                return lesReponses.Where(p => p.numeroquestion == numReponse).Single();
            }
            else
            {
                Reponse laReponse = new Reponse(numReponse);
                lesReponses.Add(laReponse);
                return laReponse;
            }
        }

        
    }
}
