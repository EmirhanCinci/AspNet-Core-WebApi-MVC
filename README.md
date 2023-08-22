# ASP.NET CORE WEB API VE MVC İLE MOVIEAPP PROJESİ

Bu proje, ASP.NET Core 6 kullanılarak oluşturulmuş bir Web API ve MVC uygulamasını içermektedir. Projenin amacı, vizyona giren veya girecek filmleri tanıtmak ve kullanıcıların bu filmler hakkında yorum yapmasına olanak tanımaktır.

## Kullanılan Teknolojiler ve Kütüphaneler

* **ASP.NET Core 6**: Web API ve MVC uygulamaları oluşturmak için kullanılan framework.
AutoFac: Bağımlılık enjeksiyonunu ve Aspect Oriented Programming (AOP) desteğini sağlayan bir kütüphane.

* **Entity Framework Core**: Veritabanı işlemleri için kullanılan ORM (Object-Relational Mapping) kütüphanesi.

* **Fluent Validation**: Nesne doğrulama kurallarını akıcı bir şekilde tanımlamak için kullanılan bir kütüphane.

* **Tokens.JWT**: Kimlik doğrulama ve yetkilendirme işlemleri için JSON Web Token (JWT) kullanımını kolaylaştıran bir kütüphane.

* **AutoMapper**: Nesneler arasında veri eşleştirmesini otomatik olarak yapmaya yardımcı olan bir kütüphane.

* **Swagger**: API belgelerini otomatik olarak oluşturan bir arayüz.

* **Postman**: API testleri yapmak için kullanılan bir araç.

## Proje Katmanları ve Mimari

Bu proje, katmanlı bir mimari kullanılarak tasarlanmıştır. Aşağıda projenin ana katmanları ve içerikleri açıklanmıştır.

1. **Infrastructure Katmanı**: Projenin temel işlemlerini desteklemek ve yönetmek için gereken yapıları içerir. 

2. **DataAccess Katmanı**: Veritabanı işlemleri için gerekli temel arayüzleri içerir. Generic bir repository interface'i ve Entity Framework Core ile çalışan implementasyonlar yer alır.

3. **Business Katmanı**: İş mantığına ait kodları içerir. Sabitler ve Dependency Resolvers altındaki yapılar, bağımlılıkların nasıl çözümleneceğini belirler. Aspectler metotların üzerine eklenir. Profiles altında AutoMapper kullanılarak nesnelerin eşleştirilmesi sağlanır. Validations altında nesne doğrulama kuralları ve hata mesajları tanımlanır.

4. **API Katmanı**: Web API'nin oluşturulduğu katmandır. Token bilgileri ve diğer yapılandırmalar appsettings dosyasında tanımlanır. Middlewares altında hata durumları ele alınır. Controllers altında API metodları ve yönlendiricileri bulunur.

5. **MVC Katmanı**: Kullanıcı arabirimini (UI) oluşturan katmandır. Bu katman içinde kullanıcının filmlere, oyunculara ve yönetmenlere yorum yapabilmesini sağlayan bileşenler yer alır.

## Nasıl Çalıştırılır?

1. Projeyi bilgisayarınıza klonlayın veya indirin.

2. Gerekli bağımlılıkları yüklemek için **"dotnet restore"** komutunu çalıştırın.

3. Projenin ana klasöründe bulunan **"appsettings.json"** dosyasında gerekli yapılandırmaları yapın (örneğin veritabanı bağlantısı, token bilgileri).

4. Proje kök dizininde **"dotnet run"** komutunu çalıştırarak projeyi başlatın.

5. API'ye veya MVC uygulamasına tarayıcınızdan erişebilirsiniz.

## Proje Tanıtım Videosu

[Tanıtım Videosu](https://www.youtube.com/watch?v=2Ii6Ee2u35Y)

## NOT

Proje içerisindeki MovieAppContext sınıfındaki bağlantı yolu çalıştırılan bilgisayara göre düzenlenmelidir.