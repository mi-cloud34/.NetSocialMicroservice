using Conservation.WepAPI;
using Conservation.WepAPI.DbSetting;
using Conservation.WepAPI.Extension;
using Conservation.WepAPI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var configuration = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddScoped<IConservationService, ConservationService>();
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
builder.Services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
//builder.Services.AddAutoMapper(ProfileFactory.CustomProfiles);
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));
;
//});
//var app = builder.Build();
WebApplication app = builder.Build();
//Configure the HTTP request pipeline.
app.UseCors(
    opt =>
        opt.WithOrigins(app.Configuration.GetSection("WebAPIConfiguration")
        .Get<WebAPIConfiguration>().AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
);
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthentication();
//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
builder.AddAppAuthetication();
app.Run();
//builder.Services.AddSwaggerGen(opt =>
//{
//    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description =
//            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
//    });
//    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
//            new string[] { }
//        }
//    })
//app.UseCors(x => x
//        .AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader());

//WebApplication app = builder.Build();
// Configure the HTTP request pipeline.
//app.UseCors(
//    opt =>
//        opt.WithOrigins(app.Configuration.GetSection("WebAPIConfiguration")
//        .Get<WebAPIConfiguration>().AllowedOrigins)
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            //.AllowCredentials()
//);
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();