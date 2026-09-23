using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Create the application builder.
// This is where we register services (DI container) and configure the app.
var builder = WebApplication.CreateBuilder(args);

// ===============================
// 1) Authentication (JWT Bearer)
// ===============================
//
// This tells ASP.NET Core that the API will use JWT Bearer tokens.
// After this is configured, the middleware can validate tokens sent in:
// Authorization: Bearer <token>
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // TokenValidationParameters define what "valid token" means for this API.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Ensures the token was issued by a trusted issuer value.
            ValidateIssuer = true,

            // Ensures the token was intended for this API (audience check).
            ValidateAudience = true,

            // Ensures the token has not expired.
            ValidateLifetime = true,

            // Ensures the token's signature matches the signing key (prevents forgery).
            ValidateIssuerSigningKey = true,

            // Must match the issuer used when generating the JWT in the login endpoint.
            ValidIssuer = "StudentApi",

            // Must match the audience used when generating the JWT in the login endpoint.
            ValidAudience = "StudentApiUsers",

            // The symmetric secret key used to validate the token signature.
            // This MUST be the same key used to sign tokens during login.
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"))
        };
    });

// ===============================
// 2) Authorization
// ===============================
//
// This enables authorization features such as:
// - [Authorize]
// - [Authorize(Roles="Admin")]
builder.Services.AddAuthorization();

// Register controller support (enables [ApiController] controllers).
builder.Services.AddControllers();

// ===============================
// 3) Swagger / OpenAPI
// ===============================
//
// AddEndpointsApiExplorer discovers endpoints for Swagger generation.
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger generation and add JWT support to Swagger UI.
// This makes Swagger show the "Authorize" button and allows sending Bearer tokens.
builder.Services.AddSwaggerGen(options =>
{
    // Define the "Bearer" security scheme.
    // Swagger will use it to display an input box for Authorization header.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // The header name where the JWT should be placed.
        Name = "Authorization",

        // HTTP authentication scheme (Authorization header).
        Type = SecuritySchemeType.Http,

        // The scheme name must be "Bearer" for JWT Bearer tokens.
        Scheme = "Bearer",

        // Optional, but helps documentation and UI.
        BearerFormat = "JWT",

        // Token is sent in the request header.
        In = ParameterLocation.Header,

        // Instruction shown in Swagger UI.
        Description = "Enter: Bearer {your JWT token}"
    });

    // Apply the Bearer scheme globally so secured endpoints in Swagger
    // can automatically include the Authorization header after you authorize.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // Reference the security scheme defined above by its Id: "Bearer".
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            // No specific scopes are required for JWT Bearer in this setup.
            new string[] {}
        }
    });
});

// Build the application.
// After Build(), services are finalized and we configure middleware.
var app = builder.Build();

// ===============================
// 4) Middleware Pipeline
// ===============================
//
// Middleware order matters. Requests pass through middleware in the order registered.

// Enable Swagger UI only in development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Authentication must run before authorization.
// Authentication identifies the user (reads token and builds User identity).
app.UseAuthentication();

// Authorization checks access rules (e.g., [Authorize], roles, policies).
app.UseAuthorization();

// Map controller routes (e.g., /api/Auth/login, /api/Students/All).
app.MapControllers();

// Start the web application.
app.Run();
