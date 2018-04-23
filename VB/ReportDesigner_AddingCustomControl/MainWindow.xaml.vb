Imports System.Windows
Imports System.Windows.Media.Imaging
Imports DevExpress.Utils
Imports DevExpress.Xpf.Reports.UserDesigner
Imports DevExpress.Xpf.Reports.UserDesigner.XRDiagram
Imports DevExpress.XtraReports.UI
' ...

Namespace ReportDesigner_AddingCustomControl
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            Dim icon_Renamed = BitmapFrame.Create(AssemblyHelper.GetResourceUri(Me.GetType().Assembly, "progress.png"))
            DevExpress.Xpf.Reports.UserDesigner.ReportDesigner.RegisterControl(Of XRProgressBar)(Function() New DefaultXRControlDiagramItem(), icon_Renamed)
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            reportDesigner.OpenDocument(New XtraReport())
        End Sub
    End Class
End Namespace
