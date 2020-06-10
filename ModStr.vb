Module ModStr
    '文字列モジュール

    '関数名:SplitPath
    '概要:パスとファイル名に分ける
    '引数::
    'String Buf:バッファ
    'String Path:パス
    'String FileName:ファイル名
    '戻り値:なし
    Public Sub SplitPath(ByVal Buf As String, ByRef Path As String, ByRef FileName As String)
        Dim sCh As Integer = 0
        Dim tCh As Integer = 0

        While tCh >= 0
            tCh = Buf.IndexOf("\", sCh + 1)
            If tCh > 0 Then
                sCh = tCh
            End If
        End While

        Path = Buf.Substring(0, sCh + 1)
        FileName = Buf.Substring(sCh + 1)
    End Sub

    '関数名:ExtExtensionFromPath
    '概要:パスから拡張子を抽出する
    '引数::
    'String Path:パス
    '戻り値:拡張子
    Public Function ExtExtensionFromPath(ByVal Path As String) As String
        ExtExtensionFromPath = ""

        Dim DotPos As Integer = Path.LastIndexOf(".")

        ExtExtensionFromPath = Path.Substring(DotPos + 1)
    End Function

End Module
