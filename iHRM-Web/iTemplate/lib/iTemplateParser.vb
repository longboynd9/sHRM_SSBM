
'    Update 31/01/2015 by ducnm
'    sua lai cho phu hop voi nhu cau su dung parse long nhau
'

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web



Public Enum UnknownState
    Keep
    Remove
    Comment
End Enum

Public Class iTemplateParser

    Private _TagOpen As String = "\{\{"
    Private _TagClose As String = "\}\}"

    Class iTemp
        Public TempStore As String
        Public TempParsed As String

        Public Sub New(temp As String)
            Me.TempStore = temp
            Me.TempParsed = temp
        End Sub
    End Class

    Private _UnknownsOutput As UnknownState = UnknownState.Keep
    ''' <summary>
    ''' Đặt trạng thái áp dụng cho các thẻ không được parse
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UnknownsOutput As UnknownState
        Get
            Return _UnknownsOutput
        End Get
        Set(value As UnknownState)
            _UnknownsOutput = value
        End Set
    End Property

    ''' <summary>
    ''' lưu mẫu đã được parse
    ''' </summary>
    ''' <remarks></remarks>
    Private _Templates As List(Of iTemp)

    ''' <summary>
    ''' Template đang parse tại thời điểm hiện tại
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Template As String
        Get
            If _Templates.Count = 0 Then Return ""
            Return _Templates(_Templates.Count - 1).TempParsed
        End Get
        Set(value As String)
            If _Templates.Count = 0 Then
                _Templates.Add(New iTemp(value))
            Else
                _Templates(_Templates.Count - 1).TempParsed = value
            End If
        End Set
    End Property



    ''' <summary>
    ''' Khởi tạo đối tượng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(Optional template As String = "")
        _Templates = New List(Of iTemp)()
        _Templates.Add(New iTemp(template))
    End Sub

    ''' <summary>
    ''' Gán Template gốc
    ''' </summary>
    ''' <param name="Template"></param>
    ''' <remarks></remarks>
    Public Sub SetTemplate(Template As String)
        _Templates(0).TempStore = Template
        _Templates(0).TempParsed = Template
    End Sub

    ''' <summary>
    ''' Lấy Template gốc
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetTemplate() As String
        Return _Templates(0).TempParsed
    End Function

    ''' <summary>
    ''' Gán biến
    ''' </summary>
    ''' <param name="BlockName"></param>
    ''' <param name="Text"></param>
    ''' <remarks></remarks>
    Public Sub Parse(BlockName As String, Text As String)
        If Text Is Nothing Then Text = ""
        Template = Regex.Replace(Template, _TagOpen & BlockName & _TagClose, Text, RegexOptions.IgnoreCase)
    End Sub

    ''' <summary>
    ''' Trả lại thẻ đánh dấu văn bản đc lấy ra từ block để parse
    ''' </summary>
    ''' <param name="Token"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBlockMaker(Token As String) As String
        Return "<!--__" & Token & "__-->"
    End Function

    ''' <summary>
    ''' Xóa block
    ''' </summary>
    ''' <param name="BlockName"></param>
    ''' <remarks></remarks>
    Public Sub RemoveBlock(BlockName As String)
        Dim pattern As String = "<!--\s+BEGIN\s+(" & BlockName & ")\s+-->([\s\S.]*)<!--\s+END\s+\1\s+-->"
        Template = Regex.Replace(Template, pattern, "", RegexOptions.IgnoreCase)
    End Sub

    ''' <summary>
    ''' Bắt đầu parse trong 1 đoạn block, các hàm Parse sau sẽ áp dụng trong block này
    ''' </summary>
    ''' <param name="BlockName"></param>
    ''' <remarks></remarks>
    Public Sub BeginBlock(BlockName As String)
        Dim Matches As MatchCollection
        Dim match As Match
        Dim aSubMatch As String = ""
        Dim braceStart As Integer
        Dim braceEnd As Integer

        Dim pattern As String = "<!--\s+BEGIN\s+(" & BlockName & ")\s+-->([\s\S.]*)<!--\s+END\s+\1\s+-->"

        Matches = Regex.Matches(Template, pattern, RegexOptions.IgnoreCase)
        For Each match In Matches
            braceStart = InStr(match.Value, "-->") + 3
            braceEnd = InStrRev(match.Value, "<!--")
            aSubMatch = Mid(match.Value, braceStart, braceEnd - braceStart)

            Template = Regex.Replace(Template, pattern, "<!--__" & BlockName & "__-->" & vbCrLf, RegexOptions.IgnoreCase)
        Next

        _Templates.Add(New iTemp(aSubMatch))
    End Sub

    ''' <summary>
    ''' Parse 1 lần vào block
    ''' </summary>
    ''' <param name="BlockName"></param>
    ''' <remarks></remarks>
    Public Sub ParseBlock(BlockName As String)
        Dim data As String = Template
        Template = _Templates(_Templates.Count - 1).TempStore
        _Templates(_Templates.Count - 2).TempParsed = _Templates(_Templates.Count - 2).TempParsed.Replace(GetBlockMaker(BlockName), data + GetBlockMaker(BlockName))
    End Sub

    ''' <summary>
    ''' Kết thúc việc parse block
    ''' </summary>
    ''' <param name="BlockName"></param>
    ''' <remarks></remarks>
    Public Sub EndBlock(BlockName As String)
        If _Templates.Count < 2 Then Throw New Exception("End of template stack")
        'Dim data As String = Template
        _Templates.RemoveAt(_Templates.Count - 1)
        Template = Template.Replace(GetBlockMaker(BlockName), "")
    End Sub

    ''' <summary>
    ''' Lấy kết quả :v
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Gen As String
        Get
            Dim Matches As MatchCollection
            Dim match As Match
            Dim pattern As String

            pattern = "__[_a-z0-9]*__"
            Matches = Regex.Matches(Template, pattern, RegexOptions.IgnoreCase)
            For Each match In Matches
                pattern = match.Value
                Template = Regex.Replace(Template, pattern, "", RegexOptions.IgnoreCase)
            Next

            'deal with unknown tags
            Select Case _UnknownsOutput
                Case UnknownState.Keep
                    'do nothing, leave it
                Case UnknownState.Remove
                    'all known matches have been replaced, remove every other match now
                    pattern = "(" & _TagOpen & ")([^}]+)" & _TagClose
                    Matches = Regex.Matches(Template, pattern, RegexOptions.IgnoreCase)
                    For Each match In Matches
                        pattern = match.Value
                        Template = Regex.Replace(Template, pattern, "", RegexOptions.IgnoreCase)
                    Next
                Case UnknownState.Comment
                    'all known matches have been replaced, HTML comment every other match
                    pattern = "(" & _TagOpen & ")([^}]+)" & _TagClose
                    Matches = Regex.Matches(Template, pattern, RegexOptions.IgnoreCase)
                    For Each match In Matches
                        pattern = match.Value
                        Template = Regex.Replace(Template, pattern, "<!-- Template variable " & Mid(match.Value, 3, Len(match.Value) - 4) & " undefined -->", RegexOptions.IgnoreCase)
                        'Template = Regex.Replace(Template, pattern, "<!-- Template variable " & match.Groups(2).Value & " undefined -->", RegexOptions.IgnoreCase)
                    Next
            End Select
            Return Template
        End Get
    End Property

End Class

