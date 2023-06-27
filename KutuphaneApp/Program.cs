using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.UnitOfWorks;
using KutuphaneApp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Db için eklenne kısım
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryDal, CategoryManager>();

//AddScoped, AddTransient, AddSingleton
/*
 * Mülakat alanı 
    Singleton: Uygulama içinde bağımlılık oluşturulurken, kullanılan nesnenin tek bir kez oluşturulması
ve aynı nesnenin uygulama içinde kullanılması.

Transient: Uygulama içinde bağımlılık olarak oluşturulan ve kullanılan nesnenin, her kullanımda (çağrıda)
yeniden oluşturulması.

Scoped:
Uygulama içinde kullanılan nesnenin request sonlanana kadar aynı nesneyi kullanması. 
Farklı bir request için geldiğinde yeni bir nesne yaratılması.
*/
#endregion
// sonradan ekledim
builder.Services.AddControllers();



//builder.Services.AddDbContext<MVCProjemContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//SOnradan ekledim
builder.Services.AddMvc();

//



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCustomRote();

app.Run();
