using Report.Business.Factory;
using Report.Business.Factory.Instance;
using Report.Business.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<Resolver>(factory => var =>
    {
        return var switch
        {
            "PDF" => factory.GetRequiredService<Pdf>(),
            "EXCEL" => factory.GetRequiredService<Excel>(),
            _ => factory.GetRequiredService<Pdf>(),
        };
    });

builder.Services.AddTransient<Pdf>();
builder.Services.AddTransient<Excel>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddMvc().AddWebApiConventions();

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
