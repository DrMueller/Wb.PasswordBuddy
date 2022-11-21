using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.Views.Details
{
    /// <summary>
    ///     Interaction logic for CredentialDetailsView.xaml
    /// </summary>
    public partial class CredentialDetailsView : UserControl, IViewMap<CredentialDetailsViewModel>
    {
        public CredentialDetailsView()
        {
            InitializeComponent();
        }
    }
}