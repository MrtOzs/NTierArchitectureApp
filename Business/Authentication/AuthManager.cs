﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(LoginAuthDto loginDto)
        {
           var user = _userService.GetByEmail(loginDto.Email);
           var result = HashingHelper.VerifyPasswordHash(loginDto.Password,user.PasswordHash,user.PasswordSalt);
           if(result)
            {
                return "Kullanıcı girişi başarılı";
            }
            return "Kullanıcı bilgileri hatalı";
        }


        [ValidationAspect(typeof(AuthValidator))]   
        public IResult Register(RegisterAuthDto  registerDto)
        {
            int imgSize = 1;


            IResult result = BusinessRules.Run(
                CheckIfEmailExists(registerDto.Email),
                CheckImageSizeIsLessThanOneMb(registerDto.Image.Length),
                CheckIfImageExtensionsAllow(registerDto.Image.FileName)
                );

               if (result != null)
               {
                   return result;
               }
          

                _userService.Add(registerDto);
                 return new SuccessResult("Kullanıcı kaydı başarıyla tamamlandı");
              
           
        }

        private IResult CheckIfEmailExists(string email) 
        {
              var list = _userService.GetByEmail(email);
              if(list != null)
            {
                return new ErrorResult("Bu mail adresi daha önce kullanılmış"); 
            }
            return new SuccessResult();
        
        
        }


        private IResult CheckImageSizeIsLessThanOneMb(long imgSize)
        {
           decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001); 
           if(imgMbSize > 1)
            {
                return new ErrorResult("Yüklediğiniz resmin boyutu en fazla 1mb olmalıdır");
            }
            return new SuccessResult(); 

        }
        private IResult CheckIfImageExtensionsAllow(string fileName) 
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string> {".jpg",".jpeg",".gif",".png" };
            if(!AllowFileExtensions.Contains(extension))
            {
                return new ErrorResult("Eklediğiniz resim .jpg , .jpeg , .gif , .png türlerinden biri olmalıdır!");
            }
            return new SuccessResult(); 



        }

    }

}
