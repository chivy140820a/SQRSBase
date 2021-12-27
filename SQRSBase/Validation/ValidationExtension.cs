namespace SQRSBase.Validation
{

    public static class ValidationExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromAssemblyOf<IValidationHandler>()
                .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                  .AsImplementedInterfaces()
                  .WithTransientLifetime());
        }
    }
}
