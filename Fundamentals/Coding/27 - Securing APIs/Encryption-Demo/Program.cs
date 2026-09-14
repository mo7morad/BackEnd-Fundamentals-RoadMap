/* ┌─────────────────────────────────────────────────────────────┐
   │ ✅ Code Overview                                            │
   ├─────────────────────────────────────────────────────────────┤
   │ 🔹 Purpose      → Beginner demo: Encryption (AES)            │
   │ 🔹 Layout       → 4 demos: Encrypt/Decrypt, Wrong Key,       │
   │                 → Key/IV meaning, and Safe mental model      │
   │ 🔹 Use Cases    → Protect data that must be read again       │
   │ 🔹 Key Properties→ Reversible + requires secret key + IV     │
   │                 → Lose key = data lost                       │
   └─────────────────────────────────────────────────────────────┘ */

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionDemo
{
    public static void Main()
    {
        Console.WriteLine("Encryption Demo (.NET) — Protecting data that must be read again\n");

        // ------------------------------------------------------------
        // ✅ Our "document in a safe" (sensitive data example)
        // ------------------------------------------------------------
        string secretMessage = "Top Secret: Student grades report 2026";

        // ------------------------------------------------------------
        // ✅ Generate a strong random AES key and IV for this demo
        //    Key = the "safe key"
        //    IV  = a random starting value that makes encryption safer
        // ------------------------------------------------------------
        byte[] key = RandomBytes(32); // 32 bytes = 256-bit AES key (strong)
        byte[] iv = RandomBytes(16); // 16 bytes = 128-bit IV (AES block size)

        // ============================================================
        // 1️⃣ Encrypt the secret message
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("1- Encrypt (Lock the safe)");
        Console.WriteLine("============================================================");

        byte[] cipherBytes = AesEncryptToBytes(secretMessage, key, iv);

        // Cipher is binary, so we Base64 it just to DISPLAY it in console.
        // Base64 here is NOT security — only formatting for printing.
        string cipherBase64 = Convert.ToBase64String(cipherBytes);

        Console.WriteLine($"Original (plain text): {secretMessage}");
        Console.WriteLine($"Encrypted (cipher b64): {cipherBase64}\n");

        // ============================================================
        // 2️- Decrypt the message (using the SAME key + IV)
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("2- Decrypt (Open the safe)");
        Console.WriteLine("============================================================");

        string decrypted = AesDecryptFromBytes(cipherBytes, key, iv);

        Console.WriteLine($"Decrypted text: {decrypted}");
        Console.WriteLine("Works because we used the SAME key + IV.\n");

        // ============================================================
        // 3- Try decrypting with a WRONG key (should fail or produce garbage)
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("3- Wrong Key Demo (No key = no access)");
        Console.WriteLine("============================================================");

        byte[] wrongKey = RandomBytes(32); // attacker does not have the real key

        try
        {
            // If key is wrong, decryption should fail (often padding exception).
            string wrongDecrypted = AesDecryptFromBytes(cipherBytes, wrongKey, iv);

            // Sometimes wrong keys can produce nonsense output (rare),
            // but in real systems we consider it "unreadable / invalid."
            Console.WriteLine($"Decrypted with WRONG key: {wrongDecrypted}");
            Console.WriteLine("If you see readable text here, it’s coincidence—not success.");
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine("Decryption failed with WRONG key (expected).");
            Console.WriteLine($"Reason: {ex.Message}");
        }

        Console.WriteLine();

        // ============================================================
        // 4️⃣ Explain what key management means (beginner-friendly)
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("4- Key Management (The real security)");
        Console.WriteLine("============================================================");

        Console.WriteLine("Encryption algorithm (AES) is public and well-known.");
        Console.WriteLine("-Security depends on keeping the KEY secret.");
        Console.WriteLine("-If you lose the key → your data is effectively lost.");
        Console.WriteLine("-If someone steals the key → they can decrypt everything.\n");

        // Show the key/IV (ONLY for demo; NEVER print secrets in production)
        Console.WriteLine("Demo only (do NOT do this in production):");
        Console.WriteLine($"Key (b64): {Convert.ToBase64String(key)}");
        Console.WriteLine($"IV  (b64): {Convert.ToBase64String(iv)}");

        Console.WriteLine("\nEnd of demo.");
    }

    // ============================================================
    // ✅ AES ENCRYPTION (Symmetric)
    // ============================================================
    // AES uses the SAME key to encrypt and decrypt.
    // This is why it’s called "symmetric" encryption.
    // ============================================================

    private static byte[] AesEncryptToBytes(string plainText, byte[] key, byte[] iv)
    {
        // Create AES object
        using Aes aes = Aes.Create();

        // Assign key and IV (must be kept and reused for decryption)
        aes.Key = key;
        aes.IV = iv;

        // Create encryptor (this performs the encryption operation)
        using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        // Convert plain text -> bytes
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        // Encrypt and return encrypted bytes (cipher text)
        return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }

    private static string AesDecryptFromBytes(byte[] cipherBytes, byte[] key, byte[] iv)
    {
        // Create AES object
        using Aes aes = Aes.Create();

        // Use the SAME key and IV used for encryption
        aes.Key = key;
        aes.IV = iv;

        // Create decryptor
        using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        // Decrypt cipher bytes -> original bytes
        byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

        // Convert bytes back to text
        return Encoding.UTF8.GetString(plainBytes);
    }

    // ============================================================
    // ✅ Utility: secure random bytes
    // ============================================================
    // Used to generate:
    // - AES keys
    // - IVs
    // ============================================================

    private static byte[] RandomBytes(int length)
    {
        byte[] bytes = new byte[length];

        // Fill with cryptographically strong random values
        RandomNumberGenerator.Fill(bytes);

        return bytes;
    }
}
