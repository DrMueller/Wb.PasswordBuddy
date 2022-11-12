using JetBrains.Annotations;
using Lamar;
using Lamar.Scanning.Conventions;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    ExcludeAggregates(scanner);
                    scanner.WithDefaultConventions();
                });
        }

        private static void ExcludeAggregates(IAssemblyScanner scanner)
        {
            var agType = typeof(IAggregateRoot);

            var agTypes = typeof(RegistryCollection)
                .Assembly.GetTypes().Where(f => agType.IsAssignableFrom(f) && !f.IsAbstract)
                .ToList();

            agTypes.ForEach(ag => scanner.Exclude(f => f == ag));
        }
    }
}