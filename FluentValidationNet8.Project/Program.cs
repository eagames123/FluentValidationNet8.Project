using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationNet8.Project.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Program.cs tarafýnda ilgili entegrasyonlarý tanýmlýyoruz.

//Bu satýr, ASP.NET Core uygulamasýnda servislerin (services) konfigürasyonunu yapýyor. 
//builder nesnesi genellikle ASP.NET Core uygulamalarýnda uygulama baþlatýcý (startup) sýnýfýnda (Startup.cs) kullanýlan bir WebHostBuilder nesnesini temsil eder.
//Bu satýrýn yaptýðý þey, Personel sýnýfý için bir doðrulama (validation) kuralý tanýmlamak için FluentValidation kütüphanesini kullanarak bir servis kaydý eklemektir. 
//Bu, IValidator<T> arayüzünü uygulayan ve Personel sýnýfýný doðrulayan bir sýnýfýn (PersonelValidator) kullanýlacaðýný belirtir.
//AddSingleton metodu, belirtilen tür için bir servis kaydýný ekler ve bu servisin yaþam döngüsünü "singleton" olarak ayarlar. 
//Yani, uygulamanýn yaþam süresi boyunca sadece bir örnek oluþturulur ve bu örnek her istekte yeniden kullanýlýr.
//Bu kod parçasý genellikle ASP.NET Core uygulamalarýnda, doðrulama kurallarýný tanýmlamak ve FluentValidation ile bu kurallarý uygulamak için kullanýlýr. 
//Bu sayede, gelen verilerin doðruluðu kolayca kontrol edilebilir ve uygun hata mesajlarýyla birlikte istemciye geri döndürülebilir.
//builder.Services.AddSingleton<IValidator<Personel>, PersonelValidator>();

//AddFluentValidationAutoValidation, FluentValidation'un ASP.NET Core uygulamalarýnda otomatik doðrulama saðlamak için bir geniþletme yöntemidir. 
//Bu geniþletme yöntemi, FluentValidation doðrulama kütüphanesini kullanarak, gelen isteklerin model baðlamasýný yaparken otomatik olarak doðrulama iþlemlerini gerçekleþtirir.
//ASP.NET Core MVC uygulamalarýnda, gelen isteklerin modele baðlanmasý (model binding) iþlemi sýrasýnda doðrulama yapýlmasý önemlidir. 
//Bu, gelen verinin doðru formatta ve beklenen sýnýrlar içinde olup olmadýðýný kontrol etmek için kullanýlýr.
//AddFluentValidationAutoValidation geniþletme yöntemi, FluentValidation kütüphanesini kullanarak model baðlamasý sýrasýnda otomatik doðrulama yapýlmasýný saðlar. 
//Böylece, gelen verinin doðruluðu otomatik olarak kontrol edilir ve uygun hata mesajlarýyla birlikte istemciye geri döndürülür.
//Bu geniþletme yöntemi, FluentValidation doðrulama kütüphanesini ASP.NET Core uygulamanýza entegre etmek ve otomatik doðrulama iþlemlerini etkinleþtirmek için kullanýlýr. 
//Bu sayede, uygulamanýzýn daha saðlam ve güvenli olmasýný saðlayabilirsiniz.
builder.Services.AddFluentValidationAutoValidation();

//unobtrusive istemci kontrollerinin saðlama için gereklidir
//AddFluentValidationClientsideAdapters, ASP.NET Core uygulamalarýnda FluentValidation doðrulama kütüphanesini istemci tarafýnda da kullanýlabilir hale getirmek için bir geniþletme yöntemidir.
//ASP.NET Core MVC uygulamalarýnda, sunucu tarafýnda yapýlan doðrulama kontrollerini istemci tarafýnda da gerçekleþtirmek isteyebilirsiniz. 
//Bunu yapmak için FluentValidation'un istemci tarafý adaptörlerini kullanabilirsiniz. 
//Bu adaptörler, doðrulama kurallarýný JavaScript koduna dönüþtürerek, istemci tarafýnda tarayýcýda da doðrulama yapýlmasýný saðlar.
//AddFluentValidationClientsideAdapters, bu adaptörleri ASP.NET Core uygulamanýza eklemek için kullanýlýr. 
//Bu geniþletme yöntemi, FluentValidation doðrulama kurallarýný istemci tarafýnda da etkinleþtirmek ve uygun JavaScript dosyalarýný sayfaya eklemek için gerekli yapýlandýrmalarý yapar.
//Bu sayede, sunucu tarafýnda tanýmladýðýnýz doðrulama kurallarý otomatik olarak istemci tarafýnda da çalýþýr hale gelir ve kullanýcýya daha iyi bir kullanýcý deneyimi sunulur.
builder.Services.AddFluentValidationClientsideAdapters();

//Oluþturulan validatorleri tek tek eklememek için Assembly seviyesinde tek 1 tanesini eklememiz yeterli olacaktýr.
//Bu kod parçasý, FluentValidation doðrulama kütüphanesini kullanarak, belirli bir PersonelValidator sýnýfýný içeren derlemedeki tüm doðrulama kurallarýný otomatik olarak kaydedip ekler. 
//Bu, genellikle ASP.NET Core uygulamalarýnda doðrulama kurallarýný yönetmeyi kolaylaþtýrýr.
//AddValidatorsFromAssemblyContaining<T> yöntemi, belirli bir türün (T) bulunduðu derlemedeki tüm doðrulama sýnýflarýný bulur ve bu sýnýflarý servis koleksiyonuna ekler. 
//PersonelValidator türünün bulunduðu derlemedeki tüm doðrulama sýnýflarý, FluentValidation'un IValidator<T> arabirimini uygulayan sýnýflarý içerir.
//Bu þekilde, belirli bir derleme içindeki tüm doðrulama kurallarý, PersonelValidator gibi herhangi bir belirli doðrulama sýnýfýný tekrar tekrar eklemek zorunda kalmadan otomatik olarak kaydedilir ve kullanýlabilir hale gelir. 
//Bu, doðrulama mantýðýný uygulamanýn büyüdükçe ve geliþtikçe yönetmeyi kolaylaþtýrýr ve tekrar kullanýlabilirliði artýrýr.
builder.Services.AddValidatorsFromAssemblyContaining<PersonelValidator>();

//Kullaným þekli 2 tanesinden 1 tanesi olabilir duruma göre deðerlendirilir.
//builder.Services.AddValidatorsFromAssemblyContaining<PersonelValidator>();
//builder.Services.AddSingleton<IValidator<Personel>, PersonelValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
