namespace CashFlow.Domain.Sercurity.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHash);
    }
}
