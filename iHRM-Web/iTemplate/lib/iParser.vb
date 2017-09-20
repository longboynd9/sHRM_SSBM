'    ASP Template .Net v1.0.3
'    Copyright (C) 2004 Manuel Bua, InvisibleSite s.r.l.
'    Based on the original ASP Template v1.2.1 (c) by Valerio Santinelli
'
'    A "Page" derived class for our template parsing system.
'



Public Class iParser
    Inherits System.Web.UI.Page

    Protected PageParser As iTemplateParser

    Public Sub New()
        PageParser = New iTemplateParser
    End Sub

    Public Overridable Sub OnGen()
    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)

        Dim sbOut As New Text.StringBuilder()
        Dim swOut As New IO.StringWriter(sbOut)
        Dim htwOut As New Web.UI.HtmlTextWriter(swOut)
        MyBase.Render(htwOut)

        PageParser.SetTemplate(sbOut.ToString())
        'If OnGen IsNot Nothing Then
        OnGen()
        writer.Write(PageParser.Gen())
    End Sub

End Class