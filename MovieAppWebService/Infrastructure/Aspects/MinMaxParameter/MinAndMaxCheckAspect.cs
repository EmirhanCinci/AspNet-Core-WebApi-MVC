using Castle.DynamicProxy;
using Infrastructure.Utilities.Interceptors;
using MovieApp.Business.CustomExceptions;

namespace Infrastructure.Aspects.MinMaxParameter
{
    public class MinAndMaxCheckAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            int min = (int)invocation.Arguments[0];
            int max = (int)invocation.Arguments[1];
            if (min < 0)
            {
                throw new BadRequestException("Minimum değer negatif olmamalı.");
            }
            if (max < 0)
            {
                throw new BadRequestException("Maximum değer negatif olmamalı.");
            }
            if (min > max)
            {
                throw new BadRequestException("Minumum değer, maximum değerden büyük olmamalı.");
            }
        }
    }
}
