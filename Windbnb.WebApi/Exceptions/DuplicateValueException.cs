namespace Windbnb.WebApi.Exceptions
{
    public class DuplicateValueException : Exception
    {
        public DuplicateValueException(string message) : base(message) { }
    }
}