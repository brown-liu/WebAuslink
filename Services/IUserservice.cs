namespace WebAuslink.Services
{
    public interface IUserservice
    {
        string GetUserId();
        public bool IsAuthenticated();
    }
}