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
using CodeRoute.Common.DAL;



namespace CodeRouteAndroid
{
    public class ListeHistoriqueArrayAdapter : Android.Widget.ArrayAdapter<T_QUESTIONNAIRE>
    {
        private LayoutInflater inflater;
        private IList<T_QUESTIONNAIRE> items;
       

        public ListeHistoriqueArrayAdapter(Context context, IList<T_QUESTIONNAIRE> items)
            : base(context, Resource.Layout.list_histo_detail, items)        
        {

            inflater = LayoutInflater.From(context);
            this.items = items;
            
       
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            // Planet to display  
            T_QUESTIONNAIRE leQuestionnaireEnCours = (T_QUESTIONNAIRE)this.items[position];

            TextView tvLaDate;
            TextView tvNbFautes;
            TextView tvCommentaire;


            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.list_histo_detail, null);
                tvLaDate = convertView.FindViewById<TextView>(Resource.Id.listhisto_date);
                tvNbFautes = convertView.FindViewById<TextView>(Resource.Id.listhisto_fautes);
                tvCommentaire = convertView.FindViewById<TextView>(Resource.Id.listhisto_commentaire);

                convertView.Tag = (new HistoriqueViewHolder(tvLaDate, tvNbFautes, tvCommentaire));
               
            }
            else
            {
                HistoriqueViewHolder viewHolder = (HistoriqueViewHolder)convertView.Tag;
                tvLaDate = viewHolder.tvLaDate;
                tvNbFautes = viewHolder.tvNbFautes;
                tvCommentaire = viewHolder.tvCommentaire;
            }

            DateTime dateSession = new DateTime(leQuestionnaireEnCours.QST_DT_DATE);

            tvLaDate.Text = dateSession.ToShortDateString();

            int nbFautes = 40 - leQuestionnaireEnCours.QST_I_NB_BONNE_REPONSE;
            if (nbFautes == 0)
            {
                tvNbFautes.Text = "Aucune :)";
                tvNbFautes.SetTextColor(Android.Graphics.Color.Green);
            }
            else if (nbFautes == 1)
            {
                tvNbFautes.Text = "1 faute";
                tvNbFautes.SetTextColor(Android.Graphics.Color.Green);
            }           
            else if (nbFautes < 6)
            {
                tvNbFautes.Text = nbFautes + " fautes";
                tvNbFautes.SetTextColor(Android.Graphics.Color.Green);
            }
            else if (nbFautes < 10)
            {
                tvNbFautes.Text = nbFautes + " fautes";
                tvNbFautes.SetTextColor(Android.Graphics.Color.Orange);
            }
            else
            {
                tvNbFautes.Text = nbFautes + " fautes";
                tvNbFautes.SetTextColor(Android.Graphics.Color.Red);
            }

            tvCommentaire.Text = leQuestionnaireEnCours.QST_S_COMMENTAIRE;


            return convertView;
        }


       

    }

    class HistoriqueViewHolder : Java.Lang.Object
    {
        public TextView tvCommentaire
        {
            get { return _tvCommentaire; }
            set { _tvCommentaire = value; }
        }
        public TextView tvNbFautes
        {
            get { return _tvNbFautes; }
            set { _tvNbFautes = value; }
        }
        public TextView tvLaDate
        {
            get { return _tvLaDate; }
            set { _tvLaDate = value; }
        }
          TextView _tvLaDate;
            TextView _tvNbFautes;
            TextView _tvCommentaire;

       


        public HistoriqueViewHolder() { }
        public HistoriqueViewHolder(TextView tvLaDate, TextView tvNbFautes, TextView tvCommentaire)
        {
            this._tvLaDate = tvLaDate;
            this._tvNbFautes = tvNbFautes;
            this._tvCommentaire = tvCommentaire;
        }
       
    }  

}