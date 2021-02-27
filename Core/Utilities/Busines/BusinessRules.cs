using System.Linq;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Busines
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            return logics.FirstOrDefault(logic => !logic.Success);
        }
    }
}