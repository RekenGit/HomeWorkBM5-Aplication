using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.HtmlControls;

namespace HomeWorkBM5_Aplication
{
    public class Functions
    {
        public bool errorCatch;
        public HtmlGenericControl errorMes, element1, element2, element3, element4, element5;
        // First value "errorMes" is label that show when error message is returned
        // Rest of the values are label that show with textbox is empty and need to be filled
        public void AssignValues(HtmlGenericControl err, HtmlGenericControl a, HtmlGenericControl b, HtmlGenericControl c, HtmlGenericControl d, HtmlGenericControl f)
        {
            errorMes = err;
            element1 = a;
            element2 = b;
            element3 = c;
            element4 = d;
            element5 = f;
        }
        // Checks if value is empty, if so returns a error message, otherwise returns a value.
        public string ErrorMessage(string str, string err)
        {
            if (str == "")
            {
                errorCatch = true;
                errorMes.Visible = true;
                errorMes.InnerHtml = "UWAGA: Nie uzupełniono wszystkich wymaganych pól.";
                switch (err)
                {
                    case "Imię":
                        element1.Visible = true;
                        break;
                    case "Nazwisko":
                        element2.Visible = true;
                        break;
                    case "Tytuł naukowy":
                        element3.Visible = true;
                        break;
                    case "Email":
                        element4.Visible = true;
                        break;
                    case "Numer telefonu":
                        element5.Visible = true;
                        break;
                }
                return null;
            }

            errorMes.Visible = false;
            return str;
        }
    }
}