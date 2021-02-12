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
        public static string CarDeleted = "Araç silme işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı";
        public static string ColorDeleted = "Renk silme işlemi başarılı";
        public static string BrandDeleted = "Marka silme işlemi başarılı";
        public static string ColorAddError = "Eklemek istediğiniz renk zaten mevcut.Farklı bir renk giriniz.";
        public static string BrandAddError = "Eklemek istediğiniz marka zaten mevcut.Farklı bir renk giriniz.";

        public static string CarAddError = "Araç Kayıt İşlemi başarısız";
    }
}
