using FluentValidation;
using FluentValidationNet8.Project.Models;

namespace FluentValidationNet8.Project.ValidationRules
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad Bilginizi lütfen doldurun");
        }
    }

    //PersonelValidator sınıfımızı oluşturuyoruz.AbstractValidator, FluentValidation kütüphanesinde bulunan bir sınıftır.
    //FluentValidation, .NET platformunda kullanılan bir doğrulama(validation) kütüphanesidir.
    //Bu kütüphane, nesne doğrulama işlemlerini kolaylaştırmak için geliştirilmiştir.

    //AbstractValidator, genellikle bir sınıfın doğrulama kurallarını tanımlamak için kullanılır.
    //Bu sınıf, soyut bir sınıf olduğu için kendisi doğrudan örneklenmez, bunun yerine bu sınıftan türetilen alt sınıflar oluşturulur. 
    //Bu alt sınıflar, doğrulama kurallarını belirlemek için soyut metodları ve FluentValidation kütüphanesinin sağladığı çeşitli yöntemleri uygular.

    //Örneğin, bir kullanıcı sınıfı için doğrulama kurallarını belirlemek için AbstractValidator sınıfından türetilen bir sınıf oluşturabilirsiniz. 
    //Bu alt sınıf, kullanıcı adının belirli bir uzunlukta olması, e-posta adresinin geçerli bir formatta olması gibi kuralları tanımlayabilir.
    //Daha sonra bu kurallar, FluentValidation kütüphanesinin sağladığı yöntemler aracılığıyla uygulanabilir. 
    //Bu sayede, nesnelerinizin doğrulama işlemlerini kolayca yönetebilir ve kontrol edebilirsiniz.

}
