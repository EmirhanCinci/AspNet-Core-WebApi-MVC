using Castle.DynamicProxy;
using Infrastructure.Utilities.Interceptors;
using MovieApp.Business.CustomExceptions;

namespace Infrastructure.Aspects.LogIn
{
    public class LogInCheckAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            string userName = (string)invocation.Arguments[0];
            string password = (string)invocation.Arguments[1];
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı adı boş bırakılamaz.");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre boş bırakılamaz.");
            }
        }
    }
}
