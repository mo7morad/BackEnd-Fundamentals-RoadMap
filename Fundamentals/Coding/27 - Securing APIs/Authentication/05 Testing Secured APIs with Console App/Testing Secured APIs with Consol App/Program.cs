using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Threading.Tasks;

namespace StudentApiConsoleClient
{
    class Program
    {
        // ==========================
        // Configuration Section
        // ==========================
        // Base URL of the secured Student API.
        // This should match the HTTPS address shown when the API is running.
        private const string BaseUrl = "https://localhost:7217/";

        // Test credentials that already exist in the API's in-memory data store.
        private const string Email = "ali.ahmed@student.com";
        private const string Password = "password1";

        // Entry point of the console application.
        // The async keyword allows us to use await for HTTP calls.
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Student API Console Client (JWT) ===");
            Console.WriteLine();

            // Create an HttpClient configured for local HTTPS development.
            // This client will be reused for all API calls.
            using var http = CreateHttpClientForLocalDev(BaseUrl);

            // Step 1: Call the login endpoint to obtain a JWT token.
            var token = await LoginAndGetTokenAsync(http, Email, Password);

            // If no token was returned, login failed and we stop execution.
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Login failed.");
                return;
            }

            Console.WriteLine("Login succeeded.");
            Console.WriteLine($"Token (first 30 chars): {token[..30]}...");
            Console.WriteLine();

            // Step 2: Call a secured endpoint without sending a token.
            // This is expected to fail with 401 Unauthorized.
            Console.WriteLine("Calling GET /api/Students WITHOUT token (expected 401)...");
            await CallGetAllStudentsAsync(http, null);
            Console.WriteLine();

            // Step 3: Call the same secured endpoint with a valid JWT token.
            // This is expected to succeed.
            Console.WriteLine("Calling GET /api/Students WITH token (expected 200)...");
            await CallGetAllStudentsAsync(http, token);
            Console.WriteLine();
        }

        // ==========================
        // Helper Methods
        // ==========================

        // Creates an HttpClient configured to work with local HTTPS development.
        // It relaxes certificate validation so self-signed development certificates are accepted.
        static HttpClient CreateHttpClientForLocalDev(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslErrors) =>
                        sslErrors == SslPolicyErrors.None ||
                        sslErrors == SslPolicyErrors.RemoteCertificateChainErrors
            };

            return new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // Calls the login endpoint and retrieves a JWT token if credentials are valid.
        static async Task<string> LoginAndGetTokenAsync(HttpClient http, string email, string password)
        {
            // Create the login request body.
            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };

            // Send a POST request to the login endpoint.
            var response = await http.PostAsJsonAsync("/api/Auth/login", request);

            // If credentials are invalid, the API returns 401 Unauthorized.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Invalid credentials.");
                return "";
            }

            // Handle any other unsuccessful HTTP status.
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Login failed: {response.StatusCode}");
                return "";
            }

            // Deserialize the response body into a TokenResponse object.
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

            // Return the token string, or an empty string if something went wrong.
            return tokenResponse?.Token ?? "";
        }

        // Calls the secured Get All Students endpoint.
        // If a token is provided, it is added to the Authorization header.
        static async Task CallGetAllStudentsAsync(HttpClient http, string token)
        {
            // Create an HTTP GET request to the secured endpoint.
            using var request = new HttpRequestMessage(HttpMethod.Get, "api/Students/All");

            // If a token is provided, attach it as a Bearer token.
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            // Send the request to the API.
            var response = await http.SendAsync(request);

            // If the request is unauthorized, stop processing.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("401 Unauthorized");
                return;
            }

            // Deserialize the response body into a list of students.
            var students = await response.Content.ReadFromJsonAsync<List<StudentDto>>();

            // Display the received students.
            Console.WriteLine($"{students.Count} students returned:");
            foreach (var s in students)
            {
                Console.WriteLine($"- {s.Name} (Age: {s.Age}, Grade: {s.Grade})");
            }
        }
    }

    // ==========================
    // Data Transfer Objects (DTOs)
    // ==========================

    // Represents the request body sent to the login endpoint.
    class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    // Represents the response body returned by the login endpoint.
    class TokenResponse
    {
        public string Token { get; set; }
    }

    // Represents a student object returned from the Student API.
    class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }
}
