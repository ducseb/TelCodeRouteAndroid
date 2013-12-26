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



namespace CodeRouteAndroid
{
public class ListReponseAdapter : SimpleAdapter
{
	private LayoutInflater	mInflater;
    private EventHandler clickCheckBox;
   

	public ListReponseAdapter (Context context, IList<IDictionary<String, object>> data,int resource, string[] from, int[] to,EventHandler clickCheckBox) : base(context,data,resource,from,to)
	{
        
		mInflater = LayoutInflater.From (context);
        this.clickCheckBox = clickCheckBox;
	}

	
	public override Java.Lang.Object GetItem (int position)
	{
        return base.GetItem(position);		
	}

	
	public override View GetView (int position, View convertView, ViewGroup parent)
	{
		//Ce test permet de ne pas reconstruire la vue si elle est déjà créée
		if (convertView == null)
		{
			// On récupère les éléments de notre vue
			convertView = mInflater.Inflate (Resource.Layout.list_detail, null);
			// On récupère notre checkBox
			CheckBox cb = (CheckBox) convertView.FindViewById (Resource.Id.list_check);
			// On lui affecte un tag comportant la position de l'item afin de
			// pouvoir le récupérer au clic de la checkbox
            cb.Tag = position;
            cb.Click += clickCheckBox;
		}

        CheckBox cb2 = (CheckBox)convertView.FindViewById(Resource.Id.list_check);
        cb2.Tag = position;
        cb2.Click += clickCheckBox;

		return base.GetView(position, convertView, parent);
	}

}
}