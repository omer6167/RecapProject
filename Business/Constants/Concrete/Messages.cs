using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Abstract;

namespace Business.Constants.Concrete
{
    public class Messages : IMessages
    {
        public static string CarAdded = "Araç kayıt işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string CarDeleted = "Araç silme işlemi başarılı";

        public static string ColorAdded = "Renk kayıt işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";
        public static string ColorDeleted = "Renk silme işlemi başarılı";

        public static string BrandAdded = "Marka kayıt işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı"; 
        public static string BrandDeleted = "Marka silme işlemi başarılı";

        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalUpdated = "Kiralama işlemi başarıyla güncellendi";
        public static string RentalDeleted = "Kiralama işlemi başarıyla silindi";

        public static string CarLimitExceded => "Araba Resmi Limiti Aşıldı";
        public static string CarImagesAdded => "Araba Resmi Eklendi";
        public static string CarImagesUpdated => "Araba Resmi Güncellendi";
        public static string CarImagesDeleted => "Araba Resmi Silindi";

        public static string UsersAdded = "Kullanıcı kayıt işlemi başarılı";
        public static string UsersUpdated = "Kullanıcı Güncelleme işlemi başarılı";
        public static string UsersDeleted = "Kullanıcı silme işlemi başarılı";

        public static string CustomersAdded = "Müşteri kayıt işlemi başarılı";
        public static string CustomersUpdated = "Müşteri güncelleme işlemi başarılı";
        public static string CustomersDeleted = "Müşteri silme işlemi başarılı";


        public static string ColorAddError = "Renk Ekleme İşlemi Başarısız.";
        public static string BrandAddError = "Marka Ekle İşlemi Başarısız.";
        public static string CarAddError = "Araç Kayıt İşlemi Başarısız";
        public static string RentalErorr = "Kiralama işlemi Başarısız";
        public static string RentalUpdatedErorr = "İlgili Araba hali hazırda kiralık durumda";


        public static string CarImagesAddedError => "Araba Resmi Ekleme İşlemi Başarısız";
        public static string CarImagesUpdatedError => "Araba Resmi Güncellenme İşlemi Başarısız";
        public static string CarImagesDeletedError => "Araba Resmi Silme İşlemi Başarısız";
        
        
        
        public static string AuthorizationDenied => "A";
    }
}
