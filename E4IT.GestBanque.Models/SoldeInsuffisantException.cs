using System.Runtime.Serialization;

namespace E4IT.GestBanque.Models
{
    [Serializable]
    public class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException(string? message) : base(message)
        {
        }
    }
}