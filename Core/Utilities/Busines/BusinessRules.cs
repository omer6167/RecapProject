using System.Linq;
using Core.Utilities.Results.Abstract;

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
            return logics.FirstOrDefault(logic => !logic.Success);
        }
    }
}