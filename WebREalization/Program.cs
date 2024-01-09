using Microsoft.EntityFrameworkCore;
using NotebookDakhnovichMaria.DatabaseFramework;
using NotebookDakhnovichMaria.Presenter;
using NotebookDakhnovichMaria.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NoteContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CONTACT")));

builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<IDataBase, DataBase>();
builder.Services.AddTransient<IMyNotebook, MyNotebook>();


builder.Services.AddControllers();

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