using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace TraderResult.Conection
{
    public class Cconection
    {
        public static FirebaseClient firebase
            = new FirebaseClient("https://traderresult-8441f-default-rtdb.firebaseio.com/");
    }
}
