Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

	Public Class Line
    Inherits System.Windows.Forms.UserControl

    Public Enum Direction
        Horizontal = 1
        Vertical = 2
    End Enum

    Private components As System.ComponentModel.IContainer = Nothing
    Private m_LineDirection As Direction = Direction.Horizontal
    Private m_UseInterpolation As Boolean = True
    Private m_LineWidth As Integer = 1
    Private m_StartColor As Color = Color.Black
    Private m_EndColor As Color = Color.White

#Region "Constructors"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "Dispose"
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
#End Region

#Region "Designer generated code"
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.Name = "Line"
        Me.Size = New System.Drawing.Size(230, 31)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "Overrides"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.Clear(Me.BackColor)

        Using lineBrush As New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), Me.m_StartColor, Me.m_EndColor, If(Me.m_LineDirection = Direction.Horizontal, LinearGradientMode.Horizontal, LinearGradientMode.Vertical))

            If Me.m_UseInterpolation Then
                Dim cb As New ColorBlend(3)
                cb.Colors = New Color(2) {Me.m_EndColor, Me.m_StartColor, Me.m_EndColor}
                cb.Positions = New Single(2) {0.0F, 0.5F, 1.0F}
                lineBrush.InterpolationColors = cb
            End If

            Using linePath As New GraphicsPath()
                If Me.m_LineDirection = Direction.Horizontal Then
                    linePath.AddLine(0, CInt(Me.Height) \ 2, Me.Width, CInt(Me.Height) \ 2)
                Else
                    linePath.AddLine(CInt(Me.Width) \ 2, 0, CInt(Me.Width) \ 2, Me.Bottom)
                End If

                Using pen As New Pen(lineBrush, Me.m_LineWidth)
                    e.Graphics.DrawPath(pen, linePath)
                End Using
            End Using
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Me.Invalidate(False)
    End Sub
#End Region

#Region "Properties"
    <Category("Behavior")> _
    Public Property LineDirection() As Direction
        Get
            Return Me.m_LineDirection
        End Get
        Set(value As Direction)
            Me.m_LineDirection = value
            Me.Invalidate(False)
        End Set
    End Property

    <Category("Behavior")> _
    Public Property UseGradientInterpolation() As Boolean
        Get
            Return Me.m_UseInterpolation
        End Get
        Set(value As Boolean)
            Me.m_UseInterpolation = Value
            Me.Invalidate(False)
        End Set
    End Property

    <Category("Behavior")> _
    Public Property LineWidth() As Integer
        Get
            Return Me.m_LineWidth
        End Get
        Set(value As Integer)
            Me.m_LineWidth = Value
            Me.Invalidate(False)
        End Set
    End Property

    <Category("Style")> _
    Public Property StartColor() As Color
        Get
            Return Me.m_StartColor
        End Get
        Set(value As Color)
            Me.m_StartColor = Value
            Me.Invalidate(False)
        End Set
    End Property

    <Category("Style")> _
    Public Property EndColor() As Color
        Get
            Return Me.m_EndColor
        End Get
        Set(value As Color)
            Me.m_EndColor = Value
            Me.Invalidate(False)
        End Set
    End Property
#End Region
	End Class


