using Business.Abstract;
using Business.Repositories.OperationClaimRepository.Constans;
using Business.Repositories.OperationClaimRepository.Validation.FluentValidation;
using Core.Aspects.Validation;
using Core.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;

        }
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(IsNameExistForAdd(operationClaim.Name));
            if(result != null)
            {
                return result;

            }
             _operationClaimDal.Add(operationClaim);
            return new SuccessResult(OperationClaimMessage.Added);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(OperationClaimMessage.Deleted);
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(p=>p.Id ==id));
        }

        public IDataResult<List<OperationClaim>> GetList()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(IsNameExistForUpdate(operationClaim.Name));
            if (result != null)
            {
                return result;

            }
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(OperationClaimMessage.Updated);
        }

        private IResult IsNameExistForAdd(string name)
        {
            var result = _operationClaimDal.Get(p => p.Name == name);

            if(result != null) 
            {
                return new ErrorResult(OperationClaimMessage.NameIsNotAvaible);


            }
            return new SuccessResult();

        }
        private IResult IsNameExistForUpdate(OperationClaim operationClaim)
        {
            var result = _operationClaimDal.Get(p => p.Name == operationClaim.Name);
            var currentOperationClaim = _operationClaimDal.Get(p => p.Id == operationClaim.Id);
            if(currentOperationClaim.Name != operationClaim.Name) { }

            if (result != null)
            {
                return new ErrorResult(OperationClaimMessage.NameIsNotAvaible);


            }
            return new SuccessResult();


        }
    }
