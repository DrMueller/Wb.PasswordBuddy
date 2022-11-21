using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.Details
{
    /// <summary>
    ///     Interaction logic for SystemDetailsView.xaml
    /// </summary>
    public partial class SystemDetailsView : UserControl, IViewMap<SystemDetailsViewModel>
    {
        public SystemDetailsView()
        {
            InitializeComponent();
        }
    }
}