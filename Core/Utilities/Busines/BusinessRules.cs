using System.Linq;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Busines
{
    public class BusinessRules
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logics"></param>
        /// <returns>Return first error, if any error can't be find return null</returns>
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return new SuccessResult();
        }
    }
}