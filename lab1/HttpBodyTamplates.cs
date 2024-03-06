using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class HttpBodyTamplates
    {
        private static String PostAuthRegister =
            "\"email\":\"{0}\"," +
            "\"password\":\"{1}\"," +
            "\"firstName\":\"{2}\"," +
            "\"lastName\":\"{3}\"";

        private static String PostAuthLogin= 
            "\"email\":\"{0}\"," +
            "\"password\":\"{1}\"";

        private static String PostMessage = 
            "\"author\":\"{0}\"" +
            "\"message\":\"{1}\"";


        public static String GetPostAuthRegisterBody(String email, String password, String firstName, String lastName)
        {
            return "{" + String.Format(PostAuthRegister, email, password, firstName, lastName)+ "}";
        }

        public static String GetPostAuthLoginBody(String email, String password)
        {
            return "{" + String.Format(PostAuthLogin, email, password) + "}";
        }

        public static String GetPostMessageBody(String author, String message)
        {
            return "{" + String.Format(PostMessage, author, message) + "}";
        }


    }
}
