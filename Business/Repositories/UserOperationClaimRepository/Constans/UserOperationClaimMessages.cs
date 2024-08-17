using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserOperationClaimRepository.Constans
{
    public class UserOperationClaimMessages
    {
        public static string Added = "Yetki başarıyla oluşturuldu";
        public static string Updated = "Yetki başarıyla güncellendi";
        public static string Deleted = "Yetki başarıyla silindi";
        public static string OperationClaimSetExist = "Bu kullanıcıya daha önce yetki atanmış!";
        public static string OperationClaimNotExist = "Seçtiğiniz yetki bilgisi yetkilerde bulunmuyor!";
        public static string UserNotExist = "Seçtiğiniz kullanıcı bulunamadı!";
    }
}
