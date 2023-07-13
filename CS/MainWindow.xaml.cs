using System.Windows;
using System.Windows.Media.Imaging;
using DevExpress.Utils;
using DevExpress.Xpf.Reports.UserDesigner;
using DevExpress.Xpf.Reports.UserDesigner.XRDiagram;
using DevExpress.XtraReports.UI;
// ...

namespace ReportDesigner_AddingCustomControl {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var icon = BitmapFrame.Create(AssemblyHelper.GetResourceUri(GetType().Assembly, "progress.png"));
            ReportDesigner.RegisterControl<XRProgressBar>(() => new DefaultXRControlDiagramItem(), icon);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            reportDesigner.OpenDocument(new XtraReport());
        }
    }
}
