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
        public HtmlGenericControl errorMes, element1, element2, element3, element4, element5, element6, element7;
        // First value "errorMes" is label that show when error message is returned
        // Rest of the values are label that show with textbox is empty and need to be filled
        public void AssignValues(HtmlGenericControl err, HtmlGenericControl a, HtmlGenericControl b, HtmlGenericControl c, HtmlGenericControl d, HtmlGenericControl e, HtmlGenericControl f, HtmlGenericControl g)
        {
            errorMes = err;
            element1 = a;
            element2 = b;
            element3 = c;
            element4 = d;
            element5 = e;
            element6 = f;
            element7 = g;
        }
        // Checks if value is empty, if so returns a error message, otherwise returns a value.
        public string ErrorMessage(string str, int err)
        {
            if (str == "")
            {
                errorCatch = true;
                switch (err)
                {
                    case 1:
                        element1.Visible = true;
                        break;
                    case 2:
                        element2.Visible = true;
                        break;
                    case 3:
                        element3.Visible = true;
                        break;
                    case 4:
                        element4.Visible = true;
                        break;
                    case 5:
                        element5.Visible = true;
                        break;
                    case 6:
                        element6.Visible = true;
                        break;
                    case 7:
                        element7.Visible = true;
                        break;
                }
                return null;
            }

            errorMes.Visible = false;
            return str;
        }
    }
}