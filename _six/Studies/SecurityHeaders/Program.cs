using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;
using SecurityHeaders;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

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

app.UseHsts(opt => opt.MaxAge(365)
    .IncludeSubdomains());
app.UseXContentTypeOptions();
app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
app.UseXfo(opt => opt.SameOrigin());
app.UseReferrerPolicy(opt => opt.NoReferrer());
app.UseCsp(opt => opt
    .DefaultSources(source => source.Self())
    .StyleSources(source => source.Self()
        .UnsafeInline())
    .ScriptSources(source => source.Self()
        .UnsafeInline()
        .UnsafeEval())
);

/* this does not seem to work
var policyCollection = new HeaderPolicyCollection()
       .AddPermissionsPolicy(builder =>
       {
           builder.AddAccelerometer() // accelerometer 'self' http://testUrl.com
               .Self()
               .For("http://testUrl.com");

           builder.AddAmbientLightSensor() // ambient-light-sensor 'self' http://testUrl.com
               .Self()
               .For("http://testUrl.com");

           builder.AddAutoplay() // autoplay 'self'
               .Self();

           builder.AddCamera() // camera 'none'
               .None();

           builder.AddEncryptedMedia() // encrypted-media 'self'
               .Self();

           builder.AddFullscreen() // fullscreen *:
               .All();

           builder.AddGeolocation() // geolocation 'none'
               .None();

           builder.AddGyroscope() // gyroscope 'none'
               .None();

           builder.AddMagnetometer() // magnetometer 'none'
               .None();

           builder.AddMicrophone() // microphone 'none'
               .None();

           builder.AddMidi() // midi 'none'
               .None();

           builder.AddPayment() // payment 'none'
               .None();

           builder.AddPictureInPicture() // picture-in-picture 'none'
               .None();

           builder.AddSpeaker() // speaker 'none'
               .None();

           builder.AddSyncXHR() // sync-xhr 'none'
               .None();

           builder.AddUsb() // usb 'none'
               .None();

           builder.AddVR() // vr 'none'
               .None();

           // You can also add arbitrary extra directives: plugin-types application/x-shockwave-flash"
           builder.AddCustomFeature("plugin-types", "application/x-shockwave-flash");
           // If a new feature policy is added that follows the standard conventions, you can use this overload
           // iframe 'self' http://testUrl.com
           builder.AddCustomFeature("iframe") //
               .Self()
               .For("http://testUrl.com");
       });

app.UseSecurityHeaders(policyCollection);
*/

/*
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
*/

app.UseHttpsRedirection();

app.UseHttpMethodValidation();

app.Use(async (context, next) =>
{
    ///context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
    ////context.Response.Headers[HeaderNames.ContentType] = "nosniff";
    ///context.Response.Headers[HeaderNames.ContentSecurityPolicy] =
    /// "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';";
    ///context.Response.Headers[HeaderNames.XFrameOptions] = "x1";
    ///context.Response.Headers[HeaderNames.XContentTypeOptions] = "X2";

    context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();