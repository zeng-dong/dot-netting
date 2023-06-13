using Microsoft.Net.Http.Headers;
using SecurityHeaders;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.AddServerHeader = false;
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///app.UseSecurityHeaders();
var policyCollection = new HeaderPolicyCollection()
        .AddFrameOptionsDeny()
        .AddXssProtectionBlock()
        .AddContentTypeOptionsNoSniff()
        .AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365) // maxage = one year in seconds
        .AddReferrerPolicyStrictOriginWhenCrossOrigin()
        .RemoveServerHeader()
        .AddContentSecurityPolicy(builder =>
        {
            builder.AddObjectSrc().None();
            builder.AddFormAction().Self();
            builder.AddFrameAncestors().None();
        })
        .AddCrossOriginOpenerPolicy(builder =>
        {
            builder.SameOrigin();
        })
        .AddCrossOriginEmbedderPolicy(builder =>
        {
            builder.RequireCorp();
        })
        .AddCrossOriginResourcePolicy(builder =>
        {
            builder.SameOrigin();
        })
        .AddCustomHeader("X-My-Test-Header", "Header value");

app.UseSecurityHeaders(policyCollection);

app.UseHttpsRedirection();

app.UseHttpMethodValidation();

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
//    ////context.Response.Headers[HeaderNames.ContentType] = "nosniff";
//    context.Response.Headers[HeaderNames.ContentSecurityPolicy] =
//        "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';";
//    ///context.Response.Headers[HeaderNames.XFrameOptions] = "x1";
//    ///context.Response.Headers[HeaderNames.XContentTypeOptions] = "X2";

//    await next();
//});

app.UseAuthorization();

app.MapControllers();

app.Run();