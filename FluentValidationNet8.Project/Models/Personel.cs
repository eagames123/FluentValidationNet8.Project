namespace FluentValidationNet8.Project.Models
{
    public class Personel
    {
        //? soru işareti "bir değişkenin null değer alabileceğini belirtmek için kullanılır."
        //= null; kullanımı default değer olarak null belirtip Name property bilgisini kullanacağımız yerlerde "?" soru işareti kullanma uyarısını kaldırıyor

        //C# dilinde, değişken tanımlarken soru işareti kullanımı "nullable" veya "nullable types" olarak bilinen bir özelliği ifade eder. Bu, bir değişkenin null değer alabileceğini belirtmek için kullanılır. Yani, o değişkenin hem normal değerler alabileceği, hem de null olabileceği anlamına gelir.

        //Örneğin, int? nullableInteger = null; şeklinde tanımlanan bir değişken, bir tam sayı değeri alabileceği gibi, null değeri de alabilir.Bu, özellikle veritabanından veri alırken veya bir fonksiyonun dönüş değeri olarak null durumunun geçerli olduğu durumlarda kullanışlı olabilir.
        public string? Name { get; set; } = null;
    }
}
