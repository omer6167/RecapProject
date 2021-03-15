using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using Core.Aspects.Autofac.Performance;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new PerformanceAspect(5)); //Tüm methodlar için performans hesaplaması yapacak
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));  //Log Aspect Dahil edilmedi

            
            
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}