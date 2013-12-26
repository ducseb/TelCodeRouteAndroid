using System;
using System.Collections.Generic;
using System.Text;
using CodeRoute.Common.BO;
using System.Linq;
using Android.Database;
using Android.Content;


namespace CodeRoute.Common.DAL
{

    public class T_QUESTIONNAIRE
    {
        public int QST_I_ID { get; set; }
        public long QST_DT_DATE { get; set; }
        public int QST_I_NB_BONNE_REPONSE { get; set; }
        public string QST_S_COMMENTAIRE { get; set; }
        public bool QST_B_ACTIF { get; set; }        

    }
    

    public interface IQuestionnaireRepository
    {
         IList<T_QUESTIONNAIRE> GetAllQuestionnaire();
         long ajouterQuestionnaire(SessionQuestion laSession);
    }

    public class Historique : IQuestionnaireRepository
    {
        public static DateTime baseTemps = new DateTime(0);

        private QuestionnaireDataBaseHelper _helper;

        public Historique(Context context)
    	  {
        	    _helper = new QuestionnaireDataBaseHelper(context);
          }

        public IList<T_QUESTIONNAIRE> GetAllQuestionnaire()
        {
            ICursor questionCursor = _helper.ReadableDatabase.Query("T_QUESTIONNAIRE", null, null, null, null, null, null);

            var LesQuestions = new List<T_QUESTIONNAIRE>();

            while (questionCursor.MoveToNext())
    	    {
                LesQuestions.Add(mapQuestionnaire(questionCursor));
    	    }
            return LesQuestions;
        }

        public long ajouterQuestionnaire(SessionQuestion laSession)
        {
                var values = new ContentValues();

                values.Put("QST_DT_DATE", laSession.dateSerie.Ticks);
                values.Put("QST_I_NB_BONNE_REPONSE", laSession.lesReponses.Where(p=>p.responseValide).Count());
                values.Put("QST_S_COMMENTAIRE", laSession.commantaire);
                values.Put("QST_B_ACTIF", true);

                return _helper.WritableDatabase.Insert("T_QUESTIONNAIRE", null, values);
        }

        private T_QUESTIONNAIRE mapQuestionnaire(ICursor cursor)
        {
            return new T_QUESTIONNAIRE
            {
                QST_I_ID = cursor.GetInt(0),
                QST_DT_DATE = cursor.GetLong(1),
                QST_I_NB_BONNE_REPONSE = cursor.GetInt(2),
                QST_S_COMMENTAIRE = cursor.GetString(3),
                QST_B_ACTIF = true
            };
        }

    }

    
}
