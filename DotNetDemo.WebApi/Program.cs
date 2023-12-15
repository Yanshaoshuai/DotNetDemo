using DotNetDemo.WebApi.Config;
using DotNetDemo.WebApi.DAO;
using DotNetDemo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    //添加前缀
//    options.Conventions.Insert(0, new RouteConversion(new RouteAttribute("api/")));

//}).AddJsonOptions(options =>
//{   //解决乱码问题
//    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
//});
builder.Services.AddControllers();
//注入mysql ef上下文
builder.Services.AddDbContext<MysqlEfContext>(p =>
{
    p.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion("8.0.12"));
});

builder.Services.AddDbContext<TodoContext>(p =>
{
    p.UseInMemoryDatabase("TodoList");
});
builder.Services.AddSwaggerConfig(builder.Configuration);
WebApplication app = builder.Build();
app.UseHttpsRedirection();

app.UseSwaggerConfig();

app.MapControllers();
app.Run();
