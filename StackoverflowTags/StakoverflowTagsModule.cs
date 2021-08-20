using Autofac;
using Application.Services;
using Application.Services.Implementations;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace StackoverflowTags
{
    public class StakoverflowTagsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SerilogLoggerFactory>().As<ILoggerFactory>().SingleInstance();

            builder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();    
        }
    }
}
