namespace Web.Installers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Compilation;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using MvcExtensions;

    [UsedImplicitly]
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var concreteTypes = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(assembly => !assembly.GlobalAssemblyCache).ConcreteTypes();

            IList<IModelMetadataConfiguration> configurations = new List<IModelMetadataConfiguration>();

            concreteTypes.Where(type => typeof (IModelMetadataConfiguration).IsAssignableFrom(type))
                         .Each(type =>
                             {
                                 container.Register(Component.For(type).LifestyleTransient());
                                 configurations.Add((IModelMetadataConfiguration) container.Resolve(type));
                             });

            container.Register(Component.For<IModelMetadataRegistry>().ImplementedBy<ModelMetadataRegistry>().LifestyleSingleton());

            var registry = container.Resolve<IModelMetadataRegistry>();

            configurations.Each(configuration => registry.RegisterModelProperties(configuration.ModelType, configuration.Configurations));

            IList<ModelValidatorProvider> validatorProviders = new List<ModelValidatorProvider>(ModelValidatorProviders.Providers);
            validatorProviders.Insert(0, new ExtendedModelValidatorProvider());
            var compositeModelValidatorProvider = new CompositeModelValidatorProvider(validatorProviders.ToArray());

            ModelMetadataProviders.Current = new ExtendedModelMetadataProvider(registry);
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(compositeModelValidatorProvider);
        }
    }
}