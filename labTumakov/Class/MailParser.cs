namespace labTumakov.Class
{
    public class MailParser
    {
        public void SearchMail(ref string s)
        {
            int separatorIndex = s.IndexOf('#');

            if (separatorIndex == -1)
            {
                s = string.Empty;
                return;
            }

            s = s.Substring(separatorIndex + 1).Trim();
        }
    }
}
