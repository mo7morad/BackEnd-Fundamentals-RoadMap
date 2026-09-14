/* ┌─────────────────────────────────────────────────────────────┐
   │ ✅ Code Overview                                            │
   ├─────────────────────────────────────────────────────────────┤
   │ 🔹 Purpose      → Beginner demo: Encoding ≠ Security         │
   │ 🔹 Layout       → 4 demos: UTF-8 bytes, Base64, URL encode,  │
   │                 → and "why NOT for passwords"                │
   │ 🔹 Use Cases    → Transport compatibility (HTTP/URLs/JSON)   │
   │ 🔹 Key Properties→ Reversible + no secret key + anyone can   │
   │                 → decode (packaging, not locking)            │
   └─────────────────────────────────────────────────────────────┘ */

using System;
using System.Linq;
using System.Text;

public static class EncodingDemo
{
    public static void Main()
    {
        // ------------------------------------------------------------
        // The lesson’s main point:
        // Encoding helps data travel safely (compatibility),
        // but it does NOT hide data and does NOT protect secrets.
        // ------------------------------------------------------------

        Console.WriteLine("Encoding Demo (.NET) — Encoding ≠ Security\n");

        // ============================================================
        // 1️- UTF-8: How text becomes bytes (for storage/transmission)
        // ============================================================

        DemoUtf8Bytes();

        // ============================================================
        // 2️- Base64: Convert bytes to safe text (for transport)
        // ============================================================

        DemoBase64();

        // ============================================================
        // 3️- URL Encoding: Protect special characters in query strings
        // ============================================================

        DemoUrlEncoding();

        // ============================================================
        // 4️- Why Base64 is NOT security (password example)
        // ============================================================

        DemoWhyNotSecurity();

        Console.WriteLine("\nEnd of demo.");
    }

    // ------------------------------------------------------------
    // 1️⃣ UTF-8 Demo
    // ------------------------------------------------------------
    private static void DemoUtf8Bytes()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("1- UTF-8 Encoding (Text to Bytes)");
        Console.WriteLine("============================================================");

        // Example with English + Arabic + Emoji to show cross-platform safety
        string text = "Hello  مرحبا";

        // UTF-8 is the most common way to convert text into bytes
        // because it can represent almost all characters.
        byte[] bytes = Encoding.UTF8.GetBytes(text);

        Console.WriteLine($"Original text: {text}");
        Console.WriteLine($"UTF-8 byte count: {bytes.Length}");

        // Print the bytes in a readable format (hex)
        // (Hex is a common way developers view raw bytes.)
        Console.WriteLine("Bytes (hex): " + string.Join(" ", bytes.Select(b => b.ToString("X2"))));

        // Convert bytes back into text (reversible)
        string backToText = Encoding.UTF8.GetString(bytes);

        Console.WriteLine($"Decoded back: {backToText}");
        Console.WriteLine("Note: UTF-8 is for compatibility, not for hiding.\n");
    }

    // ------------------------------------------------------------
    // 2️- Base64 Demo
    // ------------------------------------------------------------
    private static void DemoBase64()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("2- Base64 (Bytes to Safe Text to Bytes)");
        Console.WriteLine("============================================================");

        // Base64 is commonly used when you need to send binary bytes
        // through systems that expect text (HTTP headers, JSON, XML, etc.)
        string message = "Binary-safe transport";

        // Step A: Convert text to bytes (UTF-8)
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        // Step B: Convert bytes to Base64 text
        string base64 = Convert.ToBase64String(messageBytes);

        Console.WriteLine($"Original message: {message}");
        Console.WriteLine($"Base64 encoded  : {base64}");

        // Step C: Decode Base64 back to the same bytes
        byte[] decodedBytes = Convert.FromBase64String(base64);

        // Step D: Convert bytes back to text
        string decodedMessage = Encoding.UTF8.GetString(decodedBytes);

        Console.WriteLine($"Decoded message : {decodedMessage}");

        // Key takeaway
        Console.WriteLine("Base64 is reversible and has NO secret key.\n");
    }

    // ------------------------------------------------------------
    // 3️⃣ URL Encoding Demo
    // ------------------------------------------------------------
    private static void DemoUrlEncoding()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("3- URL Encoding (Protect special characters in URLs)");
        Console.WriteLine("============================================================");

        // In query strings, characters like space and & have special meaning.
        // Example: name=John&role=Admin  => "&" separates parameters!
        string rawValue = "John & Admin";

        // URL encode converts special characters into safe representations.
        // Example:
        // space => %20
        // &     => %26
        string urlEncoded = Uri.EscapeDataString(rawValue);

        // URL decode returns the original.
        string urlDecoded = Uri.UnescapeDataString(urlEncoded);

        Console.WriteLine($"Raw value      : {rawValue}");
        Console.WriteLine($"URL Encoded    : {urlEncoded}");
        Console.WriteLine($"URL Decoded    : {urlDecoded}");

        Console.WriteLine("URL encoding prevents protocol parsing issues, not attackers.\n");
    }

    // ------------------------------------------------------------
    // 4️⃣ Why Encoding is NOT Security (Password example)
    // ------------------------------------------------------------
    private static void DemoWhyNotSecurity()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("4- Encoding is NOT Security (Password example)");
        Console.WriteLine("============================================================");

        // This example shows the exact mistake some beginners make:
        // "I'll store Base64(password) in the database."
        // That is NOT security — anyone can decode it instantly.

        string password = "Password123";

        // "Encode" password (WRONG as protection)
        string base64Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

        Console.WriteLine($"Original password : {password}");
        Console.WriteLine($"Base64 stored value: {base64Password}");

        // Attacker (or any developer) decodes it back easily:
        string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(base64Password));

        Console.WriteLine($"Decoded back      : {decoded}");

        // Mental model reminder:
        Console.WriteLine("\nMental model:");
        Console.WriteLine("Encoding = packaging a TV for shipping.");
        Console.WriteLine("It helps delivery (compatibility), but it does NOT lock the TV.");
        Console.WriteLine("\nCorrect rule:");
        Console.WriteLine("Never use encoding to protect passwords or secrets.");
        Console.WriteLine("Use hashing (bcrypt/Argon2/PBKDF2) for passwords.\n");
    }
}
