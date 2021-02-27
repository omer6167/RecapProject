using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants.Concrete;
using Core.Utilities.Busines;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        private ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId);

            return new SuccessDataResult<List<CarImages>>(result);
        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (!result.Success)
            {
                return new ErrorResult(result.Messages);
                
            }

            carImage.ImagePath = FileHelper.Add(file);


            _carImagesDal.Add(carImage);

            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            var result = _carImagesDal.Get(c => c.Id == carImage.Id);

           carImage.ImagePath = FileHelper.Update(file,result.ImagePath);

           return new SuccessResult(Messages.CarImagesUpdated);
        }

        public IResult Delete(CarImages carImages)
        {
            var result = FileHelper.Delete(carImages.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.CarImagesDeletedError);
            }

            return new SuccessResult(Messages.CarImagesAdded);
        }



        private IResult CheckCarImageLimit(int carId)
        {
            var imageCount = _carImagesDal.GetAll(c => c.CarId == carId).Count;

            if (imageCount > 5)
            {
                return new ErrorResult(Messages.CarLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImages>> CheckIfCarImageNull(int carId)
        {
            
            var result = _carImagesDal.GetAll(c => c.CarId == carId);
            if (result.Count==0)
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\CarImages\logo.jpg");
                return new SuccessDataResult<List<CarImages>>(
                    new List<CarImages>
                    {
                        new CarImages {
                            CarId = carId,
                            ImagePath = path,
                            Date = DateTime.Now}
                    });
            }
            return new ErrorDataResult<List<CarImages>>(result);
        }
    }
}