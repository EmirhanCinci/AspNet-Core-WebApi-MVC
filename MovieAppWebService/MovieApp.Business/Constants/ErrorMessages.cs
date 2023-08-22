namespace MovieApp.Business.Constants
{
    public static class ErrorMessages
    {
        public static string InvalidId = "Id değeri 0'dan büyük olmalıdır.";
        public static string InvalidIds = "Id değerleri 0'dan büyük olmalıdır.";

        public static string NotFoundId = "Girilen Id değerine ait içerik bulunamadı.";
        public static string NotFoundIds = "Girilen Id değerlerine göre içerik bulunamadı.";
        public static string NotFoundFullName = "Girilen ad ve soyada ait içerik bulunamadı.";

        public static string NotFoundContentByParameter = "Girilen parametrelere göre içerik bulunamadı.";
        public static string NotFoundContent = "İçerik bulunamadı.";

        public static string MinMaxNotNegative = "Min ve max değerleri negatif olamaz.";

        public static string MinGreaterThanMax = "Min değeri, max değerinden büyük olamaz.";

        public static string StartDateGraterThanEndDate = "Başlangıç tarihi, bitiş tarihinden sonra olamaz.";

        public static string InvalidCount = "Adet sayısı 0'dan büyük olmalıdır.";

        public static string LogInError = "Kullanıcı adı veya şifre hatalıdır.";
        public static string LogInUserNameNullError = "Kullanıcı adı boş bırakılamaz.";
        public static string LogInPasswordNullError = "Şifre boş bırakılamaz.";
    }
}
