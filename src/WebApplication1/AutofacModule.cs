using Autofac;
using WebApplication1.Services;

namespace WebApplication1
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AttendeeService>().As<IAttendeeService>();
        }
    }
}
