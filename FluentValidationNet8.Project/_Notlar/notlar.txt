Fluent Validation Kullanımı Hakkında
---------------------------------------------------------------------------------
Web Projemizi .net 8 Core oluşturuyoruz.
---------------------------------------------------------------------------------
Manage Nuget Manager açıp Fluent Validation aratıyoruz.
---------------------------------------------------------------------------------
Fluent Validation.AspNetCore güncel versiyonu install yapıyoruz.
-----------------------------------
Örnek Class oluşturuyoruz.
public class Personel
{
public string? Name { get; set; } = null;
}

? soru işareti "bir değişkenin null değer alabileceğini belirtmek için kullanılır."
= null; kullanımı default değer olarak null belirtip Name property bilgisini kullanacağımız yerlerde "?" soru işareti kullanma uyarısını kaldırıyor
---------------------------------------------------------------------------------
PersonelValidator sınıfımızı oluşturuyoruz. AbstractValidator, FluentValidation kütüphanesinde bulunan bir sınıftır.
FluentValidation, .NET platformunda kullanılan bir doğrulama (validation) kütüphanesidir. 
Bu kütüphane, nesne doğrulama işlemlerini kolaylaştırmak için geliştirilmiştir.
AbstractValidator, genellikle bir sınıfın doğrulama kurallarını tanımlamak için kullanılır. 
Bu sınıf, soyut bir sınıf olduğu için kendisi doğrudan örneklenmez, bunun yerine bu sınıftan türetilen alt sınıflar oluşturulur. 
Bu alt sınıflar, doğrulama kurallarını belirlemek için soyut metodları ve FluentValidation kütüphanesinin sağladığı çeşitli yöntemleri uygular.
Örneğin, bir kullanıcı sınıfı için doğrulama kurallarını belirlemek için AbstractValidator sınıfından türetilen bir sınıf oluşturabilirsiniz. 
Bu alt sınıf, kullanıcı adının belirli bir uzunlukta olması, e-posta adresinin geçerli bir formatta olması gibi kuralları tanımlayabilir. 
Daha sonra bu kurallar, FluentValidation kütüphanesinin sağladığı yöntemler aracılığıyla uygulanabilir. 
Bu sayede, nesnelerinizin doğrulama işlemlerini kolayca yönetebilir ve kontrol edebilirsiniz.

public class PersonelValidator : AbstractValidator<Personel>
{
public PersonelValidator()
{
RuleFor(x => x.Name).NotNull().WithMessage("Ad Bilginizi lütfen doldurun");
}
}

---------------------------------------------------------------------------------	

Program.cs tarafında ilgili entegrasyonları tanımlıyoruz.
*******************************
//Bu satır, ASP.NET Core uygulamasında servislerin (services) konfigürasyonunu yapıyor. 
//builder nesnesi genellikle ASP.NET Core uygulamalarında uygulama başlatıcı (startup) sınıfında (Startup.cs) kullanılan bir WebHostBuilder nesnesini temsil eder.
//Bu satırın yaptığı şey, Personel sınıfı için bir doğrulama (validation) kuralı tanımlamak için FluentValidation kütüphanesini kullanarak bir servis kaydı eklemektir. 
//Bu, IValidator<T> arayüzünü uygulayan ve Personel sınıfını doğrulayan bir sınıfın (PersonelValidator) kullanılacağını belirtir.
//AddSingleton metodu, belirtilen tür için bir servis kaydını ekler ve bu servisin yaşam döngüsünü "singleton" olarak ayarlar. 
//Yani, uygulamanın yaşam süresi boyunca sadece bir örnek oluşturulur ve bu örnek her istekte yeniden kullanılır.
//Bu kod parçası genellikle ASP.NET Core uygulamalarında, doğrulama kurallarını tanımlamak ve FluentValidation ile bu kuralları uygulamak için kullanılır. 
//Bu sayede, gelen verilerin doğruluğu kolayca kontrol edilebilir ve uygun hata mesajlarıyla birlikte istemciye geri döndürülebilir.
/////////////////builder.Services.AddSingleton<IValidator<Personel>, PersonelValidator>();
*******************************
//AddFluentValidationAutoValidation, FluentValidation'un ASP.NET Core uygulamalarında otomatik doğrulama sağlamak için bir genişletme yöntemidir. 
//Bu genişletme yöntemi, FluentValidation doğrulama kütüphanesini kullanarak, gelen isteklerin model bağlamasını yaparken otomatik olarak doğrulama işlemlerini gerçekleştirir.
//ASP.NET Core MVC uygulamalarında, gelen isteklerin modele bağlanması (model binding) işlemi sırasında doğrulama yapılması önemlidir. 
//Bu, gelen verinin doğru formatta ve beklenen sınırlar içinde olup olmadığını kontrol etmek için kullanılır.
//AddFluentValidationAutoValidation genişletme yöntemi, FluentValidation kütüphanesini kullanarak model bağlaması sırasında otomatik doğrulama yapılmasını sağlar. 
//Böylece, gelen verinin doğruluğu otomatik olarak kontrol edilir ve uygun hata mesajlarıyla birlikte istemciye geri döndürülür.
//Bu genişletme yöntemi, FluentValidation doğrulama kütüphanesini ASP.NET Core uygulamanıza entegre etmek ve otomatik doğrulama işlemlerini etkinleştirmek için kullanılır. 
//Bu sayede, uygulamanızın daha sağlam ve güvenli olmasını sağlayabilirsiniz.
/////////////////builder.Services.AddFluentValidationAutoValidation();
*******************************
//unobtrusive istemci kontrollerinin sağlama için gereklidir
//AddFluentValidationClientsideAdapters, ASP.NET Core uygulamalarında FluentValidation doğrulama kütüphanesini istemci tarafında da kullanılabilir hale getirmek için bir genişletme yöntemidir.
//ASP.NET Core MVC uygulamalarında, sunucu tarafında yapılan doğrulama kontrollerini istemci tarafında da gerçekleştirmek isteyebilirsiniz. 
//Bunu yapmak için FluentValidation'un istemci tarafı adaptörlerini kullanabilirsiniz. 
//Bu adaptörler, doğrulama kurallarını JavaScript koduna dönüştürerek, istemci tarafında tarayıcıda da doğrulama yapılmasını sağlar.
//AddFluentValidationClientsideAdapters, bu adaptörleri ASP.NET Core uygulamanıza eklemek için kullanılır. 
//Bu genişletme yöntemi, FluentValidation doğrulama kurallarını istemci tarafında da etkinleştirmek ve uygun JavaScript dosyalarını sayfaya eklemek için gerekli yapılandırmaları yapar.
//Bu sayede, sunucu tarafında tanımladığınız doğrulama kuralları otomatik olarak istemci tarafında da çalışır hale gelir ve kullanıcıya daha iyi bir kullanıcı deneyimi sunulur.
/////////////////builder.Services.AddFluentValidationClientsideAdapters();

Oluşturulan validatorleri tek tek eklememek için Assembly seviyesinde tek 1 tanesini eklememiz yeterli olacaktır.
Bu kod parçası, FluentValidation doğrulama kütüphanesini kullanarak, belirli bir PersonelValidator sınıfını içeren derlemedeki tüm doğrulama kurallarını otomatik olarak kaydedip ekler. 
Bu, genellikle ASP.NET Core uygulamalarında doğrulama kurallarını yönetmeyi kolaylaştırır.
AddValidatorsFromAssemblyContaining<T> yöntemi, belirli bir türün (T) bulunduğu derlemedeki tüm doğrulama sınıflarını bulur ve bu sınıfları servis koleksiyonuna ekler. 
PersonelValidator türünün bulunduğu derlemedeki tüm doğrulama sınıfları, FluentValidation'un IValidator<T> arabirimini uygulayan sınıfları içerir.
Bu şekilde, belirli bir derleme içindeki tüm doğrulama kuralları, PersonelValidator gibi herhangi bir belirli doğrulama sınıfını tekrar tekrar eklemek zorunda kalmadan otomatik olarak kaydedilir ve kullanılabilir hale gelir. 
Bu, doğrulama mantığını uygulamanın büyüdükçe ve geliştikçe yönetmeyi kolaylaştırır ve tekrar kullanılabilirliği artırır.
/////////////////builder.Services.AddValidatorsFromAssemblyContaining<PersonelValidator>();

Kullanım şekli 2 tanesinden 1 tanesi olabilir duruma göre değerlendirilir.
builder.Services.AddValidatorsFromAssemblyContaining<PersonelValidator>();
builder.Services.AddSingleton<IValidator<Personel>, PersonelValidator>();
---------------------------------------------------------------------------------
View tarafında örnek formumuzu oluşturuyoruz
<form asp-controller="Home" asp-action="Index" method="post">
    <input type="text" asp-for="Name"/>
    <span asp-validation-for="Name"></span>
    <hr/>
    <input type="submit" value="Gönder"/>
</form>

<span asp-validation-for="Name"></span> oluşturulan hata mesajımızı göstermek için kullanıyoruz.
Bu HTML kodu, ASP.NET Core MVC veya Razor Pages uygulamalarında kullanılan bir doğrulama (validation) yardımcı yöntemini temsil eder.
<span asp-validation-for="Name"></span>
Bu kod parçası, Name özelliği için tanımlanan doğrulama mesajlarını görüntülemek için kullanılır. 
Bu özellik, genellikle bir model sınıfının özelliklerinden biridir ve bu özellik için belirli bir doğrulama kuralı tanımlanmışsa, bu kuralın geçerliliği kontrol edilir.
Örneğin, bir HTML formunda kullanıcıdan bir ad girmesini istiyorsanız ve bu ad alanı için belirli bir minimum uzunluk kuralı tanımladıysanız, bu <span> etiketi bu kuralın sağlanıp sağlanmadığını kontrol eder. 
Eğer belirtilen kurala uymayan bir değer girilirse, bu <span> etiketi, belirtilen doğrulama kuralına ilişkin hata mesajını görüntüler.
asp-validation-for özelliği, belirtilen özellik için tanımlanan doğrulama mesajlarını göstermek için kullanılır. 
Bu özelliğin değeri, doğrulama hatalarının görüntüleneceği özelliğin adını içerir. 
Yukarıdaki örnekte, Name özelliği için belirlenen doğrulama hataları bu <span> etiketi içinde görüntülenecektir.

---------------------------------------------------------------------------------
jquery.validate.unobtrusive.min.js

jquery.validate.unobtrusive.min.js, ASP.NET MVC (Model-View-Controller) uygulamalarında istemci tarafında doğrulama (validation) işlemlerini kolaylaştırmak için kullanılan bir JavaScript kütüphanesidir.
Bu kütüphane, ASP.NET MVC'nin "Unobtrusive Client Validation" özelliğiyle birlikte gelir. Bu özellik, sunucu tarafında tanımlanan doğrulama kurallarının istemci tarafında da çalıştırılmasını sağlar. 
Böylece, kullanıcılar formu göndermeden önce hataları hızlıca görebilir ve düzeltebilirler.
jquery.validate.unobtrusive.min.js, jQuery Validation eklentisinin bir parçasıdır ve ASP.NET MVC'de kullanılan HTML formlarının doğrulama işlemlerini otomatikleştirmek için tasarlanmıştır. 
Bu kütüphane, HTML form elemanlarının data-val-* özniteliklerini kullanarak sunucu tarafında tanımlanan doğrulama kurallarını algılar ve bu kuralları JavaScript koduyla işleyerek istemci tarafında doğrulama sağlar.
Bu kütüphane, ASP.NET MVC uygulamalarında kullanılan birçok doğrulama kütüphanesinden biridir ve istemci tarafında doğrulama işlemlerini basitleştirmek için sıklıkla tercih edilir.

jquery.validate.min.js
jquery.validate.min.js, jQuery kütüphanesine dayalı olarak geliştirilmiş bir JavaScript eklentisidir. B
u eklenti, HTML formlarının istemci tarafında doğrulama (validation) işlemlerini gerçekleştirmek için kullanılır.
Bu eklenti, bir HTML formunun gönderilmeden önce belirli kriterlere göre doğrulanmasını sağlar. 
Örneğin, bir kullanıcının bir formu doldurduktan sonra göndermeden önce gerekli alanları doldurması gerektiğini kontrol etmek gibi.
jquery.validate.min.js, form elemanlarına doğrulama kurallarını belirlemek için HTML5'in data-* özniteliklerini kullanır. 
Bu kurallar, bir alanın zorunlu olup olmadığını, belirli bir desene uyup uymadığını, minimum veya maksimum uzunluk gibi kriterleri belirtir.
Bu eklenti, öncelikle jQuery kütüphanesine ve ardından jquery.validate.min.js dosyasına referans verildiğinde kullanılabilir hale gelir. 
Bu sayede, jQuery tabanlı ASP.NET MVC veya diğer web uygulamalarında form doğrulama işlemleri basitleştirilir ve daha kolay hale getirilir.
------------------------------------------------------------------------------------------------------
@section Scripts {
    @{
        await Html.RenderPartialAsync("_ValidationScriptsPartial");
    }
} 
await Html.RenderPartialAsync("_ValidationScriptsPartial");, ASP.NET Core MVC veya Razor Pages uygulamalarında form doğrulama (validation) işlemleri için gerekli JavaScript dosyalarını sayfaya eklemek için kullanılan bir yardımcı yöntemdir.
_ValidationScriptsPartial adlı bir kısmi görünümü (Partial View) render etmek için kullanılır. Bu kısmi görünüm, form doğrulama işlemleri için gerekli olan JavaScript kodunu içerir. 
Bu kodlar, genellikle jQuery ve jQuery Validation eklentisi gibi kütüphaneleri içerir.
Bu kod parçası, form doğrulama işlemleri için gerekli JavaScript dosyalarını sayfaya eklemek için kullanılır. 
Bu dosyalar, form elemanlarının doğrulanmasını sağlar, yani kullanıcı formu göndermeden önce gerekli alanları doldurduğunu veya geçerli veri girdileri sağladığını kontrol eder.
await ifadesi, bu işlemin asenkron olarak gerçekleşebileceğini belirtir ve işlemin tamamlanmasını bekler. 
Html.RenderPartialAsync yöntemi, belirtilen kısmi görünümü render eder ve sonucu HTTP yanıt akışına ekler.
Bu yöntem genellikle _Layout.cshtml gibi bir genel görünüm dosyasında veya belirli bir Razor sayfasında kullanılır. 
Bu şekilde, uygulamanın tüm sayfalarında form doğrulama için gerekli JavaScript dosyaları otomatik olarak eklenir. 
Bu da geliştirme sürecini kolaylaştırır ve kod tekrarını azaltır.
------------------------------------------------------------------------------------------------------

Controller tarafında ilgili kodlarımızı hazırlıyoruz.

[HttpPost]
public IActionResult Index(Personel personel)
{
if (ModelState.IsValid)
{
return RedirectToAction("Privacy");
}
return View(personel);
}

ModelState.IsValid, ASP.NET MVC veya ASP.NET Core MVC uygulamalarında, bir HTTP isteği ile gelen modelin doğrulama (validation) durumunu kontrol etmek için kullanılan bir özelliktir.
ASP.NET MVC'de, bir HTTP isteği ile gelen veriler, bir model sınıfına bağlanır (model binding). Bu işlem sırasında, gelen verilerin model sınıfındaki özelliklerle eşleşip eşleşmediği kontrol edilir. 
Ayrıca, gelen verilerin belirli doğrulama kurallarına uyup uymadığı da kontrol edilir.
ModelState.IsValid, bu doğrulama işleminin sonucunu verir. Eğer gelen veriler, model sınıfındaki özelliklerle eşleşiyor ve tüm doğrulama kurallarına uyuyorsa, ModelState.IsValid true (doğru) değerini döndürür. 
Bu durumda, model geçerli (valid) kabul edilir ve işlem devam eder.
Ancak, eğer gelen verilerden biri veya birkaçı model sınıfındaki özelliklerle eşleşmiyorsa veya belirtilen doğrulama kurallarına uymuyorsa, ModelState.IsValid false (yanlış) değerini döndürür. 
Bu durumda, model geçersiz (invalid) kabul edilir ve genellikle hata mesajlarıyla birlikte kullanıcıya geri döndürülür.
Bu özellik, sunucu tarafında doğrulama durumunu kontrol etmek ve buna göre işlem yapmak için kullanılır.
Örneğin, bir formun gönderilmesi durumunda, ModelState.IsValid kullanılarak gelen verilerin doğruluğu kontrol edilir ve eğer geçersiz ise uygun hata mesajlarıyla birlikte tekrar formun gösterilmesi sağlanabilir.
