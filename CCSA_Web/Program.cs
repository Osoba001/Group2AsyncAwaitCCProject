using CCSANoteApp.DB;
using CCSANoteApp.DB.Configurations;
using CCSANoteApp.DB.Repositories;
using CCSANoteApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<NoteRepository>();

builder.Services.AddSingleton<SessionFactory>(x => new SessionFactory(builder.Configuration.GetConnectionString("defaultConnection")));

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
