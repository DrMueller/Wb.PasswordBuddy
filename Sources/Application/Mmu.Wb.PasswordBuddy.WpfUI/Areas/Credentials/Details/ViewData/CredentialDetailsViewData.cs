using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewData
{
    public class CredentialDetailsViewData : ValidatableViewModel<CredentialDetailsViewData>
    {
        private string _id;

        public string ID
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public string IdDescription => string.IsNullOrEmpty(ID) ? "New" : ID;

        public DateTime? LastChanged { get; private set; }

        public string LastChangedDescription => LastChanged == null ? "Never" : LastChanged.ToString();

        private string _name;
        private string _useName;
        private string _password;

        public string Name
        {
            get => _name;
            set => OnPropertyChanged(value, ref _name);
        }

        public string Password
        {
            get => _password;
            set => OnPropertyChanged(value, ref _password);
        }


        public string UserName
        {
            get => _useName;
            set => OnPropertyChanged(value, ref _useName);
        }

        protected override Task OnInitializeAsync(params object[] initParams)
        {
            ID = (string)initParams[0];
            LastChanged = (DateTime?)initParams[1];
            return base.OnInitializeAsync(initParams);
        }

        protected override ValidationContainer<CredentialDetailsViewData> ConfigureValidation(IValidationConfigurationBuilder<CredentialDetailsViewData> builder)
        {
            return builder
                .ForProperty(f => f.Name)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .ForProperty(f => f.Password)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .Build();
        }
    }
}