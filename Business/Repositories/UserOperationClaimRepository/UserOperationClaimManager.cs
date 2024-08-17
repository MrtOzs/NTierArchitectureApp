using Business.Abstract;
using Business.Repositories.OperationClaimRepository.Constans;
using Business.Repositories.UserOperationClaimRepository.Constans;
using Business.Repositories.UserOperationClaimRepository.Validation.FluentValidation;
using Core.Aspects.Validation;
using Core.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
            _userService = userService;
        }


        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.Deleted);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(p => p.Id == id));
        }

        public IDataResult<List<UserOperationClaim>> GetList()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(
                IsUserExist(userOperationClaim.UserId),
                IsOperationClaimExist(userOperationClaim.OperationClaimId),
                IsOperationSetExist(userOperationClaim));
            if (result != null)
            {
                return result;

            }
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.Updated);
        }
        [ValidationAspect(typeof(UserOperationClaimValidator))]
         public IResult Add(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(
                IsUserExist(userOperationClaim.UserId),
                IsOperationClaimExist(userOperationClaim.OperationClaimId),
                IsOperationSetExist(userOperationClaim));
            if (result != null)
            {
                return result;

            }
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.Added);
        }
        public IResult IsOperationSetExist(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.Get(p => p.UserId == userOperationClaim.UserId && p.OperationClaimId == userOperationClaim.Id);
            if (result != null)
            {
                return new ErrorResult(UserOperationClaimMessages.OperationClaimSetExist);
            }
            return new SuccessResult();
        }
        public IResult IsOperationClaimExist(int operationClaimId)
        {
            var result = _operationClaimService.GetById(operationClaimId);
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.OperationClaimNotExist);
            }
            return new SuccessResult();
        }
        public IResult IsUserExist(int userId)
        {
            var result = _userService.GetById(userId).Data;
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.UserNotExist);
            }
            return new SuccessResult();
        }

    }
}
