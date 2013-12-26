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
using CodeRoute.Common.Store;


namespace CodeRouteAndroid
{
    [Activity(Label = "Question TelCodeRoute")]
    public class Question : Activity
    {
        private Reponse laReponse;
        private TextView textNumeroQuestion;
        private ToggleButton toggleA;
        private ToggleButton toggleB;
        private ToggleButton toggleC;
        private ToggleButton toggleD;
        private ImageButton btQuitter;
        private ImageButton btSuivant;


        int numeroQuestion = 0;


        bool InActivity = false;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);


            SetContentView(Resource.Layout.Question);

            
            Bundle bundleParam = this.Intent.Extras;

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            initComposant();

            //nouvelleQuestion();
           
            
            numeroQuestion = bundleParam.GetInt("numeroquestion");
            setQuestion(numeroQuestion);

            InActivity = true;
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (ApplicationStore.LesQuestionsEnCours == null) StartActivity(typeof(MainMenu));

            if (InActivity == false) numeroQuestion--;

        }


        private void setQuestion(int numQuestion)
        {
            if (ApplicationStore.LesQuestionsEnCours == null) StartActivity(typeof(MainMenu));
            laReponse = ApplicationStore.LesQuestionsEnCours.getReponse(numeroQuestion);
            textNumeroQuestion.Text = (laReponse.numeroquestion + 1).ToString() + "/40";
        }


        private void initComposant()
        {
            textNumeroQuestion = FindViewById<TextView>(Resource.Id.question_tvQuestion);
            toggleA = FindViewById<ToggleButton>(Resource.Id.question_toggleA);
            toggleB = FindViewById<ToggleButton>(Resource.Id.question_toggleB);
            toggleC = FindViewById<ToggleButton>(Resource.Id.question_toggleC);
            toggleD = FindViewById<ToggleButton>(Resource.Id.question_toggleD);
            btQuitter = FindViewById<ImageButton>(Resource.Id.question_btQuitter);
            btSuivant = FindViewById<ImageButton>(Resource.Id.question_btSuivant);

            /*toggleA.Click += new EventHandler(toggle_click);
            toggleB.Click += new EventHandler(toggle_click);
            toggleC.Click += new EventHandler(toggle_click);
            toggleD.Click += new EventHandler(toggle_click);*/
            btQuitter.Click += new EventHandler(btQuitter_click);
            btSuivant.Click += new EventHandler(btSuivant_click);

            toggleA.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(toggle_change);
            toggleB.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(toggle_change);
            toggleC.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(toggle_change);
            toggleD.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(toggle_change);

            //textNumeroQuestion.Text = laReponse.numeroquestion.ToString() + "/40";            
        }


        private void toggle_change(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            ToggleButton leTogle = ((ToggleButton)sender);
            ChangeStyleBouton(leTogle);
        }


        private void btQuitter_click(object sender, EventArgs e)
        {
            ApplicationStore.WantToQuit = true;
            ApplicationStore.LesQuestionsEnCours = null;
            StartActivity(typeof(MainMenu));

            this.Finish();
        }

        private void btSuivant_click(object sender, EventArgs e)
        {
            laReponse.a = toggleA.Checked;
            laReponse.b = toggleB.Checked;
            laReponse.c = toggleC.Checked;
            laReponse.d = toggleD.Checked;

            InActivity = false;
            //Charge une nouvelle question
            numeroQuestion++;
            if (numeroQuestion < 40) 
            {
                /*Intent intent = new Android.Content.Intent(this.ApplicationContext,typeof(Question));
                intent.PutExtra("numeroquestion",numeroQuestion);
                intent.SetFlags(ActivityFlags.NoAnimation);
                StartActivity(intent);*/
                
                nouvelleQuestion();
            }
            else
            {

                ApplicationStore.LesQuestionsEnCours.questionComplete = true;
                StartActivity(typeof(Response));
                this.Finish();
            }
        }

        public override void OnBackPressed()
        {
           

            if (numeroQuestion <= 0)
            {         

                ApplicationStore.WantToQuit = true;
                ApplicationStore.LesQuestionsEnCours = null;
                StartActivity(typeof(MainMenu));

                this.Finish();
            }
            else
            {
                numeroQuestion--;

                laReponse = ApplicationStore.LesQuestionsEnCours.getReponse(numeroQuestion);
                textNumeroQuestion.Text = (laReponse.numeroquestion + 1).ToString() + "/40";

                toggleA.Checked = laReponse.a;
                toggleB.Checked = laReponse.b;
                toggleC.Checked = laReponse.c;
                toggleD.Checked = laReponse.d;
            }
            
        }











        private void nouvelleQuestion()
        {
            laReponse = ApplicationStore.LesQuestionsEnCours.getReponse(numeroQuestion);


            toggleA.Checked = false;
            toggleB.Checked = false;
            toggleC.Checked = false;
            toggleD.Checked = false;

            textNumeroQuestion.Text = (laReponse.numeroquestion+1).ToString() + "/40";
        }



        private void ChangeStyleBouton(ToggleButton bt)
        {
            if (bt.Checked)
            {
                //bt.SetBackgroundResource(Android.Resource.Drawable.IcNotificationOverlay);                
                bt.SetBackgroundResource(Resource.Drawable.bt_choixReponse2);
            }
            else
            {
                bt.SetBackgroundResource(Resource.Drawable.bt_choixReponse);
                //bt.SetBackgroundResource(Android.Resource.Drawable.ButtonDefault);  
            }
            
        }

       

    }
}