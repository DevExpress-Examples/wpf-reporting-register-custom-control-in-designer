Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Namespace ReportDesigner_AddingCustomControl
    <ToolboxItem(True)> _
    Public Class XRProgressBar
        Inherits XRControl

        Private pos As Single = 0
        Private maxVal As Single = 100

        <DefaultValue(100), XtraSerializableProperty> _
        Public Property MaxValue() As Single
            Get
                Return Me.maxVal
            End Get
            Set(ByVal value As Single)
                If value <= 0 Then
                    Return
                End If
                Me.maxVal = value
            End Set
        End Property

        <DefaultValue(0), Bindable(True), XtraSerializableProperty> _
        Public Property Position() As Single
            Get
                Return Me.pos
            End Get
            Set(ByVal value As Single)
                If value < 0 OrElse value > maxVal Then
                    Return
                End If
                Me.pos = value
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
            End Set
        End Property

        Public Sub New()
            Me.ForeColor = SystemColors.Highlight
        End Sub

        Protected Overrides Function CreateBrick(ByVal childrenBricks() As VisualBrick) As VisualBrick
            Return New PanelBrick(Me)
        End Function

        Protected Overrides Sub PutStateToBrick(ByVal brick As VisualBrick, ByVal ps As PrintingSystemBase)
            MyBase.PutStateToBrick(brick, ps)
            Dim panel As PanelBrick = CType(brick, PanelBrick)
            Dim progressBar As New VisualBrick(Me)
            progressBar.Sides = BorderSide.None
            progressBar.BackColor = panel.Style.ForeColor
            progressBar.Rect = New RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue), panel.Rect.Height)
            panel.Bricks.Add(progressBar)
        End Sub
    End Class
End Namespace
