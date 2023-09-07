using JackHenry.Reddit.Api.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
	$"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

	// include models xml documentation
	var modelsAssembly = typeof(JackHenry.Reddit.Models.PostInfo).Assembly;
	var documentationFile = $"{modelsAssembly.GetName().Name}.xml";
	var path = Path.Combine(AppContext.BaseDirectory, documentationFile);
	c.IncludeXmlComments(path);
});

builder.Services.AddScoped<IRedditService, StaticRedditService>();
//builder.Services.AddScoped<IRedditService, RedditService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


