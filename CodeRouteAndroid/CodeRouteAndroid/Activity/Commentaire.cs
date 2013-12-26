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
    [Activity(Label = "Commentaire")]
    public class Commentaire : Activity
    {

        private EditText nbFautes;
        private EditText commentaires;
        private ImageButton btValide;

        SessionQuestion lesQuestionEnCours;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Commentaire);

            this.RequestedOrientation=Android.Content.PM.ScreenOrientation.Portrait;

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

            nbFautes = FindViewById<EditText>(Resource.Id.commentaire_txtFautes);
            btValide = FindViewById<ImageButton>(Resource.Id.commentaire_suivant);
            commentaires = FindViewById<EditText>(Resource.Id.commentaires_txtCommentaires);

            nbFautes.Text = (40 - lesQuestionEnCours.lesReponses.Where(p => p.responseValide).Count()).ToString();



            btValide.Click += new EventHandler(bt_Valide);

          

            
            

        }


        public void bt_Valide(object sender, EventArgs e)
        {
            Historique Question = new Historique(this);

            lesQuestionEnCours.commantaire = commentaires.Text;
            Question.ajouterQuestionnaire(lesQuestionEnCours);
            ApplicationStore.LesQuestionsEnCours = null;
            ApplicationStore.WantToQuit = true;



            StartActivity(typeof(MainMenu));
            this.Finish();
        }

       








       

    }
}