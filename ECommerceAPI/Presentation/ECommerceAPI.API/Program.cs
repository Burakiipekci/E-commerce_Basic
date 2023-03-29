using ECommerceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())); // Gelebilecek isteklere izin veriyoruz burada.



builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200"))); // Hangi hostingden veya porttan gelebilecek isteklere izin veriyoruz burada. Kısaca hangi clientlerdan veya sitelerde istek gelebilir onlara izin veriyoruz aksi takdirde farklı bir istek geldiğin CORS politikası meydana gelecektir.

// Add services to the container.

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
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
