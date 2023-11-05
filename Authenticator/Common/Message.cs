namespace Authenticator.Common
{
    public class Message
    {
        public bool EstaAutenticado { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
        public string Token { get; set; }
    }
}
