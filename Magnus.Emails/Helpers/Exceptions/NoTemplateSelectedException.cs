namespace Magnus.Emails.Helpers.Exceptions
{
    public class NoTemplateSelectedException : Exception
    {
        public NoTemplateSelectedException() 
            : base ("No such template type exist!")
        {
            
        }
    }
}
