using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace CodeRoute.Common.BO
{

    public class Reponse
    {
        public bool a=false;
        public bool b=false;
        public bool c = false;
        public bool d = false;
        public int numeroquestion=0;
        public bool responseValide=false;

        public Reponse(bool a, bool b, bool c, bool d, int numQuestion, bool reponseValide)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            this.numeroquestion = numQuestion;
            this.responseValide = reponseValide;
        }

        public Reponse(int numquestion)
        {
            this.numeroquestion=numquestion;
        }
    }
  
    

 
   
}
