using back;
using back.GQLTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn  more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddGraphQLServer()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>();

var app = builder.Build();

app.UseCors(opt =>
{
    opt.AllowAnyHeader()
        .AllowAnyMethod()
        //.AllowCredentials()
        .AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
