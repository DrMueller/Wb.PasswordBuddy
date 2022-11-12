using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.Views
{
    /// <summary>
    /// Interaction logic for SystemOverviewView.xaml
    /// </summary>
    public partial class SystemOverviewView : UserControl, IViewMap<SystemOverviewViewModel>
    {
        public SystemOverviewView()
        {
            InitializeComponent();
        }
    }
}
