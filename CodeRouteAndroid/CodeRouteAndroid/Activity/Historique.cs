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
    [Activity(Label = "Historique...")]
    public class HistoriqueAct : Activity
    {

        private ListView list;      
        private ImageButton boutonValide;


        SessionQuestion lesQuestionEnCours;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Historique);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            
            Bundle bundleParam = this.Intent.Extras;

          


            initComposant();            
        }

        private void initComposant()
        {
            list = FindViewById<ListView>(Resource.Id.historique_liste);
            boutonValide = FindViewById<ImageButton>(Resource.Id.historique_btValide);

            Historique Question = new Historique(this);






            Android.Widget.ArrayAdapter<T_QUESTIONNAIRE> listAdapter = new ListeHistoriqueArrayAdapter(this, Question.GetAllQuestionnaire());
            list.Adapter = listAdapter;


          

            boutonValide.Click += new EventHandler(bt_Valide);

            for(int i=0;i<40;i++)list.GetChildAt(i);

            
            

        }


        public void bt_Valide(object sender, EventArgs e)
        {
           
            
            StartActivity(typeof(MainMenu));
            this.Finish();
        }

      








       

    }
}