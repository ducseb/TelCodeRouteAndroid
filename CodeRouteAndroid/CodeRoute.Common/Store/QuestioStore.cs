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
using CodeRoute.Common.BO;
using CodeRoute.Common.DAL;

namespace CodeRoute.Common.Store
{
    public class ApplicationStore
    {

        public static SessionQuestion LesQuestionsEnCours;
        public static bool WantToQuit = false;

        public static IQuestionnaireRepository historiqueEnCours;
    }
}