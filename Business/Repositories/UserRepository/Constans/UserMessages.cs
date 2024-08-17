using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository.Contans
{
    public class UserMessages
    {
        public static string UpdateUser = "Kullanıcı kaydı başarıyla güncellendi";
        public static string DeleteUser = "Kullanıcı kaydı başarıyla silindi";
        public static string WrongCurrentPassword = "Mevcut şifrenizi yanlış girdiniz ";
        public static string PasswordChanged = "Şifre başarıyla değiştirildi";
    }
}
