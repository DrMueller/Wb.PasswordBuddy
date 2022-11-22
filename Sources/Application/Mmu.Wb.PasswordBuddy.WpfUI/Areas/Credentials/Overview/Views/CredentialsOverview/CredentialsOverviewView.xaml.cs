using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.Views.CredentialsOverview
{
    /// <summary>
    ///     Interaction logic for CredentialsOverviewView.xaml
    /// </summary>
    public partial class CredentialsOverviewView : IViewMap<CredentialsOverviewViewModel>
    {
        public CredentialsOverviewView()
        {
            InitializeComponent();
        }
    }
}