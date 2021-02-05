using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public void Add(Color color)
        {
            throw new NotImplementedException();
        }

        public void Update(Color color)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
