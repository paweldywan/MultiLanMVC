using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLanMVC
{
    public class MyController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            HttpCookie langCookie = Request.Cookies["culture"];

            string lang;

            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";

                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LanguageMang.GetDefaultLanguage();
                }
            }

            new LanguageMang().SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }
    }
}