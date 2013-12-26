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
    [Activity(Label = "TelCodeRoute", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainMenu : Activity
    {

          ImageButton btCommencer = null;
          ImageButton btHisto = null;
         // ImageButton btParam = null;

          TextView tbNbSession = null;

          

          protected override void OnResume()
          {
              base.OnResume();
              if (ApplicationStore.WantToQuit)
              {
                  ApplicationStore.WantToQuit = false;
                  ApplicationStore.LesQuestionsEnCours = null;
                  return;
              }
              else
              {

              }

          }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainMenu);

            initComposant();

            Historique Question = new Historique(this);
            //Chargement de l'historique
            ApplicationStore.historiqueEnCours = Question;
            

            int nbSessionEnregistrer = ApplicationStore.historiqueEnCours.GetAllQuestionnaire().Count();
            tbNbSession.Text = nbSessionEnregistrer + " session(s) enregistré(s)";
        }

        private void initComposant()
        {
            #region Referencement des composants
            btCommencer = FindViewById<ImageButton>(Resource.Id.btCommencer);
            btHisto = FindViewById<ImageButton>(Resource.Id.btHisto);
            //btParam = FindViewById<ImageButton>(Resource.Id.btParam);
            tbNbSession = FindViewById<TextView>(Resource.Id.MainMenu_Session);
            #endregion

            #region Ajout des event Handler
            btCommencer.Click += new EventHandler(btCommencerClick);
            btHisto.Click += new EventHandler(btHistoClick);
           // btParam.Click += new EventHandler(btParamClick);
            #endregion

        }


        public void btCommencerClick(object sender, EventArgs e)
        {
            

            //Creation d'un nouveau questionnaire           
            ApplicationStore.LesQuestionsEnCours = new SessionQuestion(); ;

            Intent intent = new Android.Content.Intent(this.ApplicationContext, typeof(Question));
            intent.PutExtra("numeroquestion", 0);
            
            StartActivity(intent);

            this.Finish();

            //StartActivity(typeof(Question));

        }

        public void btHistoClick(object sender, EventArgs e)
        {

            if (ApplicationStore.historiqueEnCours.GetAllQuestionnaire().Count() <= 0)
            {
                AlertDialog newDialogAlert = new AlertDialog.Builder(this).Create();
                newDialogAlert.SetTitle("Historique vide !");
                newDialogAlert.SetMessage("Vôtre historique est vide pour le moment !");

                newDialogAlert.Show();

            }
            else
            {
                StartActivity(typeof(HistoriqueAct));
                this.Finish();
            }
            
          
        }
        public void btParamClick(object sender, EventArgs e)
        {
            AlertDialog newDialogAlert = new AlertDialog.Builder(this).Create();
            newDialogAlert.SetTitle("Beta");
            newDialogAlert.SetMessage("Fonction non disponible en version BETA.");

            newDialogAlert.Show();

        }

      
        public override void OnBackPressed() {
            this.Finish();
        }
    }
}