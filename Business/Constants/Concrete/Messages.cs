using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Abstract;

namespace Business.Constants.Concrete
{
    public class Messages :IMessages
    {
        public static string CarAdded = "Araç kayıt işlemi başarılı";
        public static string ColorAdded = "Renk kayıt işlemi başarılı";
        public static string BrandAdded = "Marka kayıt işlemi başarılı";
        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalUpdated = "Kiralama işlemi Güncellendi";
        public static string CarDeleted = "Araç silme işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı";
        public static string RentalDeleted = "Kiralama işlemi başarıyla silindi";
        public static string ColorDeleted = "Renk silme işlemi başarılı";
        public static string BrandDeleted = "Marka silme işlemi başarılı";
        public static string ColorAddError = "Renk Ekleme İşlemi Başarısız.";
        public static string BrandAddError = "Marka Ekle İşlemi Başarısız.";
        public static string CarAddError = "Araç Kayıt İşlemi Başarısız";
        public static string RentalErorr = "Kiralama işlemi Başarısız";


    }
}
