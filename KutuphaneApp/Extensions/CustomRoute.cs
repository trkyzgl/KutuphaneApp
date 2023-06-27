namespace KutuphaneApp.Extensions
{
    public static class CustomRoute
    {
        /// <summary>
        /// MapControllerRoute işlemleri burada yapılmaktadır
        /// </summary>
        /// <param name="app"></param>
        public static void UseCustomRote(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            /*
            app.MapControllerRoute(name: "blog",
                            pattern: "blog",
                            defaults: new { controller = "Blog", action = "Article" });
            */
        }
    }
}
