using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodeRoute.Common;
using CodeRoute.Common.BO;
using CodeRoute.Common.DAL;
using CodeRoute.Common.Store;


namespace CodeRouteAndroid
{
    [Activity(Label = "Correction")]
    public class Response : Activity
    {

        private ListView list;
        private TextView texteFautes;
        private ImageButton boutonValide;


        SessionQuestion lesQuestionEnCours;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Reponse);

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            
            Bundle bundleParam = this.Intent.Extras;

            //Récupération du questionnaire
            lesQuestionEnCours = ApplicationStore.LesQuestionsEnCours;


            initComposant();
            
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (ApplicationStore.LesQuestionsEnCours == null) StartActivity(typeof(MainMenu));
        }


        private void initComposant()
        {
            list = FindViewById<ListView>(Resource.Id.reponse_listview);
            texteFautes = FindViewById<TextView>(Resource.Id.Reponse_NbFautes);
            boutonValide = FindViewById<ImageButton>(Resource.Id.response_btValide);

            /*
            #region Initialisation des la ListeView 
            var laListeDeValeurReponse = new JavaList<IDictionary<string, object>>();

            for (int i = 0; i < lesQuestionEnCours.lesReponses.Count(); i++)
            {
                CodeRoute.Common.BO.Reponse leRep = lesQuestionEnCours.lesReponses[i];
                JavaDictionary<string, object> lesElementsABinder = new JavaDictionary<string, object>();
                lesElementsABinder.Add("list_numeroQuestion", i+1);
                string valeurReponse = String.Empty;
                if (leRep.a) valeurReponse += "A";
                if (leRep.b) valeurReponse += "B";
                if (leRep.c) valeurReponse += "C";
                if (leRep.d) valeurReponse += "D";

                lesElementsABinder.Add("list_valeurReponse", valeurReponse);

                laListeDeValeurReponse.Add(lesElementsABinder);
            }

            string[] from = new string[] { "list_numeroQuestion", "list_valeurReponse" };
            int[] idElement = new int[] { Resource.Id.list_numeroQuestion, Resource.Id.list_valeurReponse };

            ListReponseAdapter adaptListe = new ListReponseAdapter(this.BaseContext, laListeDeValeurReponse,
                Resource.Layout.list_detail, from, idElement, new EventHandler(btClickCheckBox));

            list.Adapter = adaptListe;
            

            #endregion 
            */

            var laListeDeValeurReponse = new JavaList<CodeRoute.Common.BO.Reponse>();
            foreach (CodeRoute.Common.BO.Reponse reponse in lesQuestionEnCours.lesReponses)
            {
                laListeDeValeurReponse.Add(reponse);
            }

            Android.Widget.ArrayAdapter<Reponse> listAdapter = new ListeReponseArrayAdapter(this, laListeDeValeurReponse, new EventHandler(btClickCheckBox));
            list.Adapter = listAdapter;


          

            boutonValide.Click += new EventHandler(bt_Valide);

            for(int i=0;i<40;i++)list.GetChildAt(i);

            
            

        }


        public void bt_Valide(object sender, EventArgs e)
        {
            /*Historique Question = new Historique(this);

            Question.ajouterQuestionnaire(lesQuestionEnCours);*/
            
            StartActivity(typeof(Commentaire));
            this.Finish();
        }

        public void btClickCheckBox(object sender, EventArgs e)
        {
            

            int nbQuestionValide = lesQuestionEnCours.lesReponses.Where(p=>p.responseValide).Count();
            int nbQuestionTotale = lesQuestionEnCours.lesReponses.Count();

            int nbFautes = nbQuestionTotale - nbQuestionValide;
            
            if(nbFautes==0)
            {
                texteFautes.Text ="0 faute :)";
            }
            else if (nbFautes == 1)
            {
                texteFautes.Text = "Faute : " + nbFautes.ToString();
            }
            else
            {
                texteFautes.Text = "Fautes : " + nbFautes.ToString();
            }
            
           
        }








       

    }
}