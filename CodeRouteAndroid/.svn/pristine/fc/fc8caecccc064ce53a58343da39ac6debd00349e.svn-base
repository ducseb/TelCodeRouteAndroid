using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CodeRoute.Common.DAL 
{
    class QuestionnaireDataBaseHelper : SQLiteOpenHelper 
    {

        private const string DATABASE_NAME = "CodeRouteDB";
        private const int DATABASE_VERSION = 1;

        public QuestionnaireDataBaseHelper(Context context) : base(context, DATABASE_NAME, null, DATABASE_VERSION)
	    {
	    }
        public override void OnCreate(SQLiteDatabase db)
        {

            db.ExecSQL(@"CREATE TABLE T_QUESTIONNAIRE (
                                            QST_I_ID  INTEGER PRIMARY KEY AUTOINCREMENT,
                                            QST_DT_DATE  datetime,
                                            QST_I_NB_BONNE_REPONSE  INTEGER,
                                            QST_S_COMMENTAIRE  TEXT,
                                            QST_B_ACTIF  Bool
                                            )");
            
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS T_QUESTIONNAIRE");
            OnCreate(db);  
        }
    }
}