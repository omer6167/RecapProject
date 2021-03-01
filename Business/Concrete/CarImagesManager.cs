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
        private readonly string _defaultImagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\CarImages\logo.jpg");

        private ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(carId));

            if (result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(
                    new List<CarImage>
                    {
                        new CarImage {
                            CarId = carId,
                            ImagePath = _defaultImagePath,
                            Date = DateTime.Now}
                    });
            }

            return new ErrorDataResult<List<CarImage>>(_carImagesDal.GetAll(c=>c.CarId == carId));
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
                
            }

            carImage.ImagePath = FileHelper.Add(file);

            _carImagesDal.Add(carImage);

            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _carImagesDal.Get(c => c.Id == carImage.Id);

           carImage.ImagePath = FileHelper.Update(file,result.ImagePath);

           _carImagesDal.Update(carImage);
           
           return new SuccessResult(Messages.CarImagesUpdated);
        }

        public IResult Delete(int id)
        {
            var data = _carImagesDal.Get(c=>c.CarId ==id);

            var result = FileHelper.Delete(data.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.CarImagesDeletedError);
            }

            _carImagesDal.Delete(data);


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

        /// <summary>
        /// Return true if car's image == null
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        private IResult CheckIfCarImageNull(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckIsFormatImage(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            if (allowedExtensions.Contains(extension.ToLower()))
            {
                return new SuccessResult();
            }
            
            return new ErrorResult();
        }
    }
}