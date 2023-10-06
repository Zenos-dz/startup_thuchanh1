namespace startup.Utilities
{
    public class Functions
    {
        public static string TitleSlugGeneration(string type, string title, long id) 
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
    }
}
