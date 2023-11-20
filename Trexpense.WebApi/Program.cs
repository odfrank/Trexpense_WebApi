using Expenses.Core;
using Microsoft.EntityFrameworkCore;
using Trexpense.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseDBConn")));
builder.Services.AddTransient<IExpensesServices, ExpensesServices>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ExpensesPolicy", builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ExpensesPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
