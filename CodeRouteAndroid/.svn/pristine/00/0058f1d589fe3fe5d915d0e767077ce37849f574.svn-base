using System;
using System.Collections.Generic;
using System.Text;


using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Android.Widget;
using Android.Content;
using Android.Runtime;

using CodeRoute.Common.BO;



namespace CodeRouteAndroid
{
    public class ListeReponseArrayAdapter : Android.Widget.ArrayAdapter<Reponse>
    {
        private LayoutInflater inflater;  
        private IList<Reponse> items;
        private EventHandler miseAJourInfo;

        public ListeReponseArrayAdapter(Context context, IList<Reponse> items, EventHandler miseAJourInfo)
            : base(context, Resource.Layout.list_detail, items)        
        {

            inflater = LayoutInflater.From(context);
            this.items = items;
            this.miseAJourInfo = miseAJourInfo;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            // Planet to display  
            Reponse laReponEnCours = (Reponse)this.items[position];

            CheckBox checkBox;
            TextView textViewNumQuestion;
            TextView textViewReponse;


            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.list_detail, null);
                textViewNumQuestion = convertView.FindViewById<TextView>(Resource.Id.list_numeroQuestion);
                textViewReponse = convertView.FindViewById<TextView>(Resource.Id.list_valeurReponse);
                checkBox = convertView.FindViewById<CheckBox>(Resource.Id.list_check);

                convertView.Tag=(new ResponseViewHolder(textViewNumQuestion,textViewReponse,checkBox));

                checkBox.Click += new EventHandler(btClickCheckBox);
                checkBox.Click += miseAJourInfo;
            }
            else
            {
                ResponseViewHolder viewHolder = (ResponseViewHolder)convertView.Tag;
                checkBox = viewHolder.CheckBox;
                textViewNumQuestion = viewHolder.TextViewNumQuestion;
                textViewReponse = viewHolder.TextViewReponse;
            }

            checkBox.Tag = position;

            checkBox.Checked = laReponEnCours.responseValide;
            textViewNumQuestion.Text = (laReponEnCours.numeroquestion+1).ToString();
            string valeurReponse = String.Empty;
            if (laReponEnCours.a) valeurReponse += "A";
            if (laReponEnCours.b) valeurReponse += "B";
            if (laReponEnCours.c) valeurReponse += "C";
            if (laReponEnCours.d) valeurReponse += "D";
            textViewReponse.Text = valeurReponse;





            return convertView;
        }


        public void btClickCheckBox(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;


            //on récupère la position à l'aide du tag défini dans la classe MyListAdapter
            int position = (int)cb.Tag;

            if (cb.Checked)
            {
                items[position].responseValide = true;
            }
            else
            {
                items[position].responseValide = false;
            }
        }

    }

    class ResponseViewHolder : Java.Lang.Object
    {
        public CheckBox CheckBox
        {
            get { return _checkBox; }
            set { _checkBox = value; }
        }
        public TextView TextViewNumQuestion
        {
            get { return _textViewNumQuestion; }
            set { _textViewNumQuestion = value; }
        }
        public TextView TextViewReponse
        {
            get { return _textViewReponse; }
            set { _textViewReponse = value; }
        }
        CheckBox _checkBox;      
        TextView _textViewNumQuestion;        
        TextView _textViewReponse;

       


        public ResponseViewHolder() { }
        public ResponseViewHolder(TextView textViewNumQuestion, TextView textViewReponse, CheckBox checkBox)
        {
            this._checkBox = checkBox;
            this._textViewNumQuestion = textViewNumQuestion;
            this._textViewReponse = textViewReponse;
        }
       
    }  

}