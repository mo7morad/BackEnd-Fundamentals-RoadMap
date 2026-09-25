/* ┌─────────────────────────────────────────────────────────────┐
   │ ✅ Code Overview                                            │
   ├─────────────────────────────────────────────────────────────┤
   │ 🔹 Purpose      : Beginner demo: Hashing for passwords       │
   │ 🔹 Layout       : 4 demos: SHA-256 (fast), PBKDF2 (slow),    │
   │                 : Register/Login verify, and "cannot reverse"│
   │ 🔹 Use Cases    : Store & verify secrets without revealing   │
   │ 🔹 Key Properties: One-way + no secret key + verify by       │
   │                 : recomputing + salt prevents reuse          │
   └─────────────────────────────────────────────────────────────┘ */

using System;
using System.Security.Cryptography;
using System.Text;

public static class HashingDemo
{
    public static void Main()
    {
        Console.WriteLine("Hashing Demo (.NET) — Protecting secrets that must never be revealed\n");

        // ------------------------------------------------------------
        // ✅ Demo inputs (pretend these come from user UI)
        // ------------------------------------------------------------
        string password = "Password123!";         // what user chooses at registration
        string wrongPassword = "WrongPassword!";  // what attacker/user types later

        // ============================================================
        // 1- Show FAST hashing (SHA-256) — good for integrity, NOT passwords
        // ============================================================
        DemoFastHashSha256(password);

        // ============================================================
        // 2- Register a user (store ONLY salt + slow hash)
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("2- Registration (Store hash, discard password)");
        Console.WriteLine("============================================================");

        PasswordRecord stored = RegisterUser(password);

        Console.WriteLine("Stored in DB (example):");
        Console.WriteLine($"Salt (b64)      : {Convert.ToBase64String(stored.Salt)}");
        Console.WriteLine($"Hash (b64)      : {Convert.ToBase64String(stored.Hash)}");
        Console.WriteLine($"Iterations      : {stored.Iterations}");
        Console.WriteLine("Notice: We did NOT store the password.\n");

        // ============================================================
        // 3- Login verification (recompute hash, then compare)
        // ============================================================
        Console.WriteLine("============================================================");
        Console.WriteLine("3- Login (Verify by recomputing hash)");
        Console.WriteLine("============================================================");

        bool ok = LoginVerify(password, stored);
        bool bad = LoginVerify(wrongPassword, stored);

        Console.WriteLine($"Verify correct password : {ok}   (expected: True)");
        Console.WriteLine($"Verify wrong password   : {bad} (expected: False)");

        Console.WriteLine("\nKey idea:");
        Console.WriteLine("We never compare passwords.");
        Console.WriteLine("We compute hash(entered) using the SAME salt + settings, then compare hashes.\n");

        // ============================================================
        // 4️⃣ Show why hashing is "one-way" (you cannot decrypt it)
        // ============================================================
        DemoCannotReverseHash(stored);

        Console.WriteLine("\nEnd of demo.");
    }

    // ============================================================
    // 1️⃣ FAST HASH (SHA-256) — NOT recommended for passwords alone
    // ============================================================
    private static void DemoFastHashSha256(string password)
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("1- Fast Hash (SHA-256) — good for integrity, NOT passwords");
        Console.WriteLine("============================================================");

        // SHA-256 produces a fixed-length hash quickly.
        // Fast is GOOD for file integrity checks...
        // But fast is BAD for passwords because attackers can guess millions/sec.
        string sha = Sha256Hex(password);

        Console.WriteLine($"Password input  : {password}");
        Console.WriteLine($"SHA-256 hash(hex): {sha}");
        Console.WriteLine("SHA-256 is fast : fast cracking if DB is stolen.\n");
    }

    // ============================================================
    // 2️⃣ REGISTRATION (Create salt + slow hash, store only salt+hash)
    // ============================================================
    private static PasswordRecord RegisterUser(string password)
    {
        // ✅ Salt is random data added to the password BEFORE hashing.
        // It prevents:
        // - identical passwords producing identical hashes
        // - rainbow table attacks
        byte[] salt = RandomBytes(16);

        // ✅ Iterations make PBKDF2 intentionally slow (defends brute-force).
        // Increase this over time as hardware gets faster.
        int iterations = 100_000;

        // ✅ Derive a password hash using PBKDF2 (slow hashing)
        byte[] hash = Pbkdf2Hash(password, salt, iterations, hashLengthBytes: 32);

        // ✅ This is what you store in DB (NOT the password)
        return new PasswordRecord(salt, hash, iterations);
    }

    // ============================================================
    // 3- LOGIN (Recompute hash using stored salt/settings, compare hashes)
    // ============================================================
    private static bool LoginVerify(string passwordAttempt, PasswordRecord stored)
    {
        // ✅ Recompute hash using:
        // - the entered password
        // - the SAME salt stored in DB
        // - the SAME iterations stored in DB
        byte[] attemptHash = Pbkdf2Hash(passwordAttempt, stored.Salt, stored.Iterations, stored.Hash.Length);

        // ✅ Compare hashes in constant time to avoid timing attacks
        return CryptographicOperations.FixedTimeEquals(attemptHash, stored.Hash);
    }

    // ============================================================
    // 4️⃣ "Cannot reverse" demo (why you compare, not decrypt)
    // ============================================================
    private static void DemoCannotReverseHash(PasswordRecord stored)
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("4- Why you can't 'decrypt' a hash");
        Console.WriteLine("============================================================");

        Console.WriteLine("A hash is not encrypted data.");
        Console.WriteLine("There is no key and no 'decrypt' function.");
        Console.WriteLine("\nWhat you can do instead:");
        Console.WriteLine("✅ Take a guess password : hash it : compare with stored hash.");

        Console.WriteLine("\nStored hash example (b64):");
        Console.WriteLine(Convert.ToBase64String(stored.Hash));

        Console.WriteLine("\nIf a system can show you the original password, it stored it wrong.");
    }

    // ============================================================
    // PBKDF2 helper (Slow hashing for passwords)
    // ============================================================
    private static byte[] Pbkdf2Hash(string password, byte[] salt, int iterations, int hashLengthBytes)
    {
        // PBKDF2 derives a "hash" from:
        // password + salt + work factor (iterations)
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password: password,
            salt: salt,
            iterations: iterations,
            hashAlgorithm: HashAlgorithmName.SHA256
        );

        return pbkdf2.GetBytes(hashLengthBytes);
    }

    // ============================================================
    // SHA-256 helper (Fast hash, used for integrity checks)
    // ============================================================
    private static string Sha256Hex(string input)
    {
        using SHA256 sha = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha.ComputeHash(bytes);

        // Convert bytes : hex string for readable display
        var sb = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            sb.Append(b.ToString("x2"));

        return sb.ToString();
    }

    // ============================================================
    // Secure random bytes (for salts)
    // ============================================================
    private static byte[] RandomBytes(int length)
    {
        byte[] bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);
        return bytes;
    }

    // ============================================================
    // Simple "DB record" structure:
    // Store Salt + Hash + Iterations (NOT the password!)
    // ============================================================
    private sealed record PasswordRecord(byte[] Salt, byte[] Hash, int Iterations);
}
