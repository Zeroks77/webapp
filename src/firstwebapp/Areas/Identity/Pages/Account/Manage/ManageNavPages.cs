using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace firstwebapp.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string GermanPrivacy => "GermanPrivacy";
        public static string EnglishPrivacy => "EnglishPrivacy";
        public static string ChangePassword => "ChangePassword";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string ShowUsers => "ShowUsers";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string GermanPrivacyNavClass(ViewContext viewContext) => PageNavClass(viewContext, GermanPrivacy);
        public static string EnglishPrivacyNavClass(ViewContext viewContext) => PageNavClass(viewContext, EnglishPrivacy);
        public static string ShowUsersNavClass(ViewContext viewContext) => PageNavClass(viewContext, ShowUsers);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}