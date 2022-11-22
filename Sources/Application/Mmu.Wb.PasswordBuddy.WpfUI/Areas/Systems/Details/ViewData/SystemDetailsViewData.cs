using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewData
{
    [PublicAPI]
    public class SystemDetailsViewData : ValidatableViewModel<SystemDetailsViewData>
    {
        private string _additionalData = null!;
        private string? _systemId;
        private string _systemName = null!;

        public string AdditionalData
        {
            get => _additionalData;
            set => OnPropertyChanged(value, ref _additionalData);
        }

        public string? SystemId
        {
            get => _systemId;
            set => OnPropertyChanged(value, ref _systemId);
        }

        public string SystemName
        {
            get => _systemName;
            set => OnPropertyChanged(value, ref _systemName);
        }

        protected override ValidationContainer<SystemDetailsViewData> ConfigureValidation(
            IValidationConfigurationBuilder<SystemDetailsViewData> builder)
        {
            return builder.ForProperty(f => f.SystemName)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .Build();
        }
    }
}