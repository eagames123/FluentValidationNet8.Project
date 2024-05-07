using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationNet8.Project.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Program.cs taraf�nda ilgili entegrasyonlar� tan�ml�yoruz.

//Bu sat�r, ASP.NET Core uygulamas�nda servislerin (services) konfig�rasyonunu yap�yor. 
//builder nesnesi genellikle ASP.NET Core uygulamalar�nda uygulama ba�lat�c� (startup) s�n�f�nda (Startup.cs) kullan�lan bir WebHostBuilder nesnesini temsil eder.
//Bu sat�r�n yapt��� �ey, Personel s�n�f� i�in bir do�rulama (validation) kural� tan�mlamak i�in FluentValidation k�t�phanesini kullanarak bir servis kayd� eklemektir. 
//Bu, IValidator<T> aray�z�n� uygulayan ve Personel s�n�f�n� do�rulayan bir s�n�f�n (PersonelValidator) kullan�laca��n� belirtir.
//AddSingleton metodu, belirtilen t�r i�in bir servis kayd�n� ekler ve bu servisin ya�am d�ng�s�n� "singleton" olarak ayarlar. 
//Yani, uygulaman�n ya�am s�resi boyunca sadece bir �rnek olu�turulur ve bu �rnek her istekte yeniden kullan�l�r.
//Bu kod par�as� genellikle ASP.NET Core uygulamalar�nda, do�rulama kurallar�n� tan�mlamak ve FluentValidation ile bu kurallar� uygulamak i�in kullan�l�r. 
//Bu sayede, gelen verilerin do�rulu�u kolayca kontrol edilebilir ve uygun hata mesajlar�yla birlikte istemciye geri d�nd�r�lebilir.
//builder.Services.AddSingleton<IValidator<Personel>, PersonelValidator>();

//AddFluentValidationAutoValidation, FluentValidation'un ASP.NET Core uygulamalar�nda otomatik do�rulama sa�lamak i�in bir geni�letme y�ntemidir. 
//Bu geni�letme y�ntemi, FluentValidation do�rulama k�t�phanesini kullanarak, gelen isteklerin model ba�lamas�n� yaparken otomatik olarak do�rulama i�lemlerini ger�ekle�tirir.
//ASP.NET Core MVC uygulamalar�nda, gelen isteklerin modele ba�lanmas� (model binding) i�lemi s�ras�nda do�rulama yap�lmas� �nemlidir. 
//Bu, gelen verinin do�ru formatta ve beklenen s�n�rlar i�inde olup olmad���n� kontrol etmek i�in kullan�l�r.
//AddFluentValidationAutoValidation geni�letme y�ntemi, FluentValidation k�t�phanesini kullanarak model ba�lamas� s�ras�nda otomatik do�rulama yap�lmas�n� sa�lar. 
//B�ylece, gelen verinin do�rulu�u otomatik olarak kontrol edilir ve uygun hata mesajlar�yla birlikte istemciye geri d�nd�r�l�r.
//Bu geni�letme y�ntemi, FluentValidation do�rulama k�t�phanesini ASP.NET Core uygulaman�za entegre etmek ve otomatik do�rulama i�lemlerini etkinle�tirmek i�in kullan�l�r. 
//Bu sayede, uygulaman�z�n daha sa�lam ve g�venli olmas�n� sa�layabilirsiniz.
builder.Services.AddFluentValidationAutoValidation();

//unobtrusive istemci kontrollerinin sa�lama i�in gereklidir
//AddFluentValidationClientsideAdapters, ASP.NET Core uygulamalar�nda FluentValidation do�rulama k�t�phanesini istemci taraf�nda da kullan�labilir hale getirmek i�in bir geni�letme y�ntemidir.
//ASP.NET Core MVC uygulamalar�nda, sunucu taraf�nda yap�lan do�rulama kontrollerini istemci taraf�nda da ger�ekle�tirmek isteyebilirsiniz. 
//Bunu yapmak i�in FluentValidation'un istemci taraf� adapt�rlerini kullanabilirsiniz. 
//Bu adapt�rler, do�rulama kurallar�n� JavaScript koduna d�n��t�rerek, istemci taraf�nda taray�c�da da do�rulama yap�lmas�n� sa�lar.
//AddFluentValidationClientsideAdapters, bu adapt�rleri ASP.NET Core uygulaman�za eklemek i�in kullan�l�r. 
//Bu geni�letme y�ntemi, FluentValidation do�rulama kurallar�n� istemci taraf�nda da etkinle�tirmek ve uygun JavaScript dosyalar�n� sayfaya eklemek i�in gerekli yap�land�rmalar� yapar.
//Bu sayede, sunucu taraf�nda tan�mlad���n�z do�rulama kurallar� otomatik olarak istemci taraf�nda da �al���r hale gelir ve kullan�c�ya daha iyi bir kullan�c� deneyimi sunulur.
builder.Services.AddFluentValidationClientsideAdapters();

//Olu�turulan validatorleri tek tek eklememek i�in Assembly seviyesinde tek 1 tanesini eklememiz yeterli olacakt�r.
//Bu kod par�as�, FluentValidation do�rulama k�t�phanesini kullanarak, belirli bir PersonelValidator s�n�f�n� i�eren derlemedeki t�m do�rulama kurallar�n� otomatik olarak kaydedip ekler. 
//Bu, genellikle ASP.NET Core uygulamalar�nda do�rulama kurallar�n� y�netmeyi kolayla�t�r�r.
//AddValidatorsFromAssemblyContaining<T> y�ntemi, belirli bir t�r�n (T) bulundu�u derlemedeki t�m do�rulama s�n�flar�n� bulur ve bu s�n�flar� servis koleksiyonuna ekler. 
//PersonelValidator t�r�n�n bulundu�u derlemedeki t�m do�rulama s�n�flar�, FluentValidation'un IValidator<T> arabirimini uygulayan s�n�flar� i�erir.
//Bu �ekilde, belirli bir derleme i�indeki t�m do�rulama kurallar�, PersonelValidator gibi herhangi bir belirli do�rulama s�n�f�n� tekrar tekrar eklemek zorunda kalmadan otomatik olarak kaydedilir ve kullan�labilir hale gelir. 
//Bu, do�rulama mant���n� uygulaman�n b�y�d�k�e ve geli�tik�e y�netmeyi kolayla�t�r�r ve tekrar kullan�labilirli�i art�r�r.
builder.Services.AddValidatorsFromAssemblyContaining<PersonelValidator>();

//Kullan�m �ekli 2 tanesinden 1 tanesi olabilir duruma g�re de�erlendirilir.
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
