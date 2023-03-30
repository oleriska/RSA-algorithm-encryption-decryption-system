
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Get plaintext input from user
        Console.Write(" Enter plaintext: ");
        string plaintext = Console.ReadLine();

        // Generate RSA key pair
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        Console.WriteLine(" Generated Private Key: ");
        Console.WriteLine(Convert.ToBase64String(rsa.ExportRSAPrivateKey()));
        
        Console.WriteLine("\n Generated Public Key: ");
        Console.WriteLine(Convert.ToBase64String(rsa.ExportRSAPublicKey()));

        // Encrypt plaintext using RSA
        byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
        byte[] encryptedBytes = rsa.Encrypt(plaintextBytes, false);

        // Convert encrypted bytes to base64 string
        string encryptedText = Convert.ToBase64String(encryptedBytes);
        Console.WriteLine("\n Encrypted text: " + encryptedText);

        // Decrypt encrypted text using RSA
        byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);

        // Convert decrypted bytes to plaintext string
        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
        
        Console.WriteLine("\n Decrypted text: " + decryptedText);
    }
}