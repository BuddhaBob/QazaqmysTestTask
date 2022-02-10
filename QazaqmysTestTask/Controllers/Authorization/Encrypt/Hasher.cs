namespace QazaqmysTestTask.Controllers.Authorization.Encrypt
{
    public static class Hasher
    {
        public static string HashPassword(string password)
        {
            return EncryptEngine.GetMD5Hash(password);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
