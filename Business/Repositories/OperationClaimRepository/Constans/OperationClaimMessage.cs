using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.OperationClaimRepository.Constans
{
    public class OperationClaimMessage
    {
        public static string Added = "Yetki başarıyla oluşturuldu";
        public static string Updated = "Yetki başarıyla güncellendi";
        public static string Deleted = "Yetki başarıyla silindi";
        public static string NameIsNotAvaible = "Bu Yetki adı daha önce kullanılmıştır";
    }
}
