Module libcsv
    'csvライブラリ
    '関数名:ExtCSV
    '概要:CSVを開き、内容を配列に展開する
    '引数::
    'String FilePath:ファイルパス
    'ArrayList Datas:csvのデータ
    'Integer row:Max行
    'Integer col:Max列
    '戻り値:なし
    Public Sub ExtCSV(ByVal FilePath As String, ByRef Datas As ArrayList, ByRef row As Integer, ByRef col As Integer)
        Dim reader As New System.IO.StreamReader(FilePath, System.Text.Encoding.Default)
        Dim buf As String
        Dim MaxCol As Integer

        MaxCol = 1

        While reader.Peek() >= 0
            row += 1
            col = 1
            '一行読み込む
            buf = reader.ReadLine()
            ExtBuf2Array(buf, Datas, row, col)

            If col > MaxCol Then
                MaxCol = col
            End If
        End While

        'ファイルを閉じる
        reader.Close()

        col = MaxCol
    End Sub

    '関数名:ExtBuf2Array
    '概要:バッファを内容を配列に展開する
    '引数::
    'String buf:バッファ
    'String Datas():csvのデータ
    'Integer row:開始行
    'Integer col:列
    '戻り値:なし
    Private Sub ExtBuf2Array(ByVal buf As String, ByRef Datas As ArrayList, ByRef row As Integer, ByRef col As Integer)
        '1.カンマの個数を数える(必要な列数を算出)
        col = CountComma(buf) + 1   'カンマの個数 + 1

        'ReDim Preserve Datas(row)

        '4.Datas配列にデータを格納する
        Dim i As Integer

        For i = 1 To col Step 1
            Datas.Add(ExtColData(buf, i))
        Next
        Datas.Add("[vbCrLf]")
    End Sub

    '関数名:CountComma
    '概要:カンマの個数を数える
    '引数::
    'String buf:バッファ
    '戻り値:カンマの個数
    Private Function CountComma(ByVal buf As String) As Integer
        Dim NumComma As Integer = 0
        Dim StartChar As Integer = 0

        If buf <> "" Then
            While StartChar >= 0
                StartChar = buf.IndexOf(",", StartChar + 1)
                If StartChar > 0 Then
                    NumComma += 1
                End If
            End While
        End If
        CountComma = NumComma
    End Function

    '関数名:ExtColData
    '概要:列データを抽出する
    '引数::
    'String buf:バッファ
    'Integer col:列(1,2,3,...)
    '戻り値:列データ
    Private Function ExtColData(ByVal buf As String, ByVal col As Integer) As String
        Dim data As String = ""
        Dim i As Integer
        Dim StartChar As Integer = 0
        Dim EndChar As Integer = 0

        For i = 1 To col Step 1
            EndChar = buf.IndexOf(",", StartChar)
            If EndChar >= 0 Then
                data = buf.Substring(StartChar, EndChar - StartChar)
                StartChar = EndChar + 1
            Else
                data = buf.Substring(StartChar)
                Exit For
            End If
        Next i

        ExtColData = data
    End Function

    '関数名:SaveCSV
    '概要:csv形式で保存する
    '引数::
    'String Path:保存するファイルのパス
    'String Data(,):保存するデータ
    'Long rows:行
    'Integer cols:列
    '戻り値:
    Public Sub SaveCSV(ByVal Path As String, ByVal Data(,) As String, ByVal rows As Long, ByVal cols As Integer)
        Dim row As Long = 1
        Dim col As Integer = 1
        Dim writer As New System.IO.StreamWriter(Path, False, System.Text.Encoding.Default)
        Dim buf As String = ""
        Dim LineCnt As Integer = 1

        For row = 1 To rows Step 1
            For col = 1 To cols Step 1
                'ボトルネック区間になる
                buf = buf & Data(row, col) & ","
            Next col

            '末尾のカンマを取り除く
            buf = buf.Substring(0, buf.Length - 1) & vbCrLf

            If LineCnt = 100 Then
                '100行単位でファイルに書き込む
                writer.WriteLine(buf)
                LineCnt = 1
            Else
                LineCnt += 1
            End If
        Next row

        If LineCnt > 1 Then
            '末尾のcrlfを取り除く
            buf = buf.Substring(0, buf.Length - 2)
            writer.WriteLine(buf)
        End If
        'ファイルを閉じる
        writer.Close()
    End Sub
End Module
