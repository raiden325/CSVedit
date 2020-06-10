Public Class CSV_Editor
    Private ReadOk As Boolean = False

    Private Sub 開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開くToolStripMenuItem.Click
        '開く
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        ReadOk = False

        If ShInfo.Changed = True Then
            '変更あり -> 保存するか聞く
            Dim FileName As String = ""
            Dim Path As String = ""

            ModStr.SplitPath(ShInfo.FilePath, Path, FileName)

            Dim Ans As Long = MsgBox("変更を" & FileName & "に保存しますか?", vbYesNoCancel + vbQuestion, "確認")

            Select Case Ans
                Case vbYes
                    '保存して開く
                    Dim Data(ShInfo.row, ShInfo.col) As String
                    Dim trow As Long = 1
                    Dim tcol As Integer = 1

                    'DataGridViewのデータを取り込む
                    For trow = 1 To ShInfo.row Step 1
                        For tcol = 1 To ShInfo.col Step 1
                            If IsNothing(DataGridView1.Rows(trow - 1).Cells(tcol - 1).Value) = False Then
                                Data(trow, tcol) = DataGridView1.Rows(trow - 1).Cells(tcol - 1).Value.ToString
                            Else
                                Data(trow, tcol) = ""
                            End If
                        Next tcol
                    Next trow

                    libcsv.SaveCSV(ShInfo.FilePath, Data, ShInfo.row, ShInfo.col)

                    ShInfo.Changed = False

                    SheetMgr.ReflashSheetInfo(1, ShInfo)
                Case vbNo
                    '保存しないで開く
                Case vbCancel
                    '開かない
                    Exit Sub
            End Select
        End If

        '変更なし -> ファイルを開く
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "CSVファイル(*.csv)|*.csv"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim FileName As String = ""
            Dim Path As String = ""

            'OKボタンが押されたとき
            FileName = OpenFileDialog1.FileName

            ModStr.SplitPath(FileName, Path, FileName)

            FormStatus.Text = FileName & "を読み込んでいます..."

            'DataGridViewをクリア
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("", "1")

            Dim Datas As New ArrayList
            Dim row As Long = 0
            Dim col As Integer = 0

            'csvファイルを読み込む
            libcsv.ExtCSV(Path & FileName, Datas, row, col)

            '元のシート内容を登録する
            SheetMgr.SetSheetContents(Datas)

            'データを表示する
            Dim i As Integer

            For i = 1 To col - 1 Step 1
                DataGridView1.Columns.Add("", i + 1)
            Next i

            For Each c As DataGridViewColumn In DataGridView1.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

            For i = 1 To row - 1 Step 1
                DataGridView1.Rows.Add()
            Next i

            Dim oRow As Long
            Dim oCol As Integer

            For i = 0 To Datas.Count - 1 Step 1
                Dim data As String = Datas(i)
                If data <> "[vbCrLf]" Then
                    DataGridView1.Rows(oRow).Cells(oCol).Value = data
                    oCol += 1
                Else
                    oRow += 1
                    oCol = 0
                End If
            Next i

            Me.Text = "CSV Editor  :  " & Path & FileName

            'シート情報を登録する
            ShInfo.FilePath = Path & FileName
            ShInfo.Changed = False
            ShInfo.row = row
            ShInfo.col = col

            SheetMgr.ReflashSheetInfo(1, ShInfo)

            '上書き保存有効化
            保存ToolStripMenuItem.Enabled = True

            ReadOk = True

            RowCol.Text = row & "行, " & col & "列"
            FormStatus.Text = "Ready"
        End If
    End Sub

    Private Sub 保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存ToolStripMenuItem.Click
        '保存
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        'DataGridViewのデータを取り込む
        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        libcsv.SaveCSV(ShInfo.FilePath, Data, ShInfo.row, ShInfo.col)

        ShInfo.Changed = False

        SheetMgr.ReflashSheetInfo(1, ShInfo)
    End Sub

    Private Sub 保存ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 名前をつけて保存ToolStripMenuItem1.Click
        '名前をつけて保存
        SaveFileDialog1.Filter = "CSVファイル(*.csv)|*.csv"

        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim FileName As String = SaveFileDialog1.FileName
            Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
            ShInfo.FilePath = FileName
            SheetMgr.ReflashSheetInfo(1, ShInfo)

            '保存処理
            Dim Data(ShInfo.row, ShInfo.col) As String
            Dim row As Long = 1
            Dim col As Integer = 1

            'DataGridViewのデータを取り込む
            For row = 1 To ShInfo.row Step 1
                For col = 1 To ShInfo.col Step 1
                    If IsNothing(DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                        Data(row, col) = DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                    Else
                        Data(row, col) = ""
                    End If
                Next col
            Next row

            libcsv.SaveCSV(ShInfo.FilePath, Data, ShInfo.row, ShInfo.col)

            ShInfo.Changed = False

            SheetMgr.ReflashSheetInfo(1, ShInfo)
        End If
    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        '閉じる
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)

        If ShInfo.Changed = True Then
            '変更あり -> 保存するか聞く
            Dim FileName As String = ""
            Dim Path As String = ""

            ModStr.SplitPath(ShInfo.FilePath, Path, FileName)

            Dim Ans As Long = MsgBox("変更を" & FileName & "に保存しますか?", vbYesNoCancel + vbQuestion, "確認")

            Select Case Ans
                Case vbYes
                    '保存して閉じる
                    Dim Data(ShInfo.row, ShInfo.col) As String
                    Dim row As Long = 1
                    Dim col As Integer = 1

                    'DataGridViewのデータを取り込む
                    For row = 1 To ShInfo.row Step 1
                        For col = 1 To ShInfo.col Step 1
                            If IsNothing(DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                                Data(row, col) = DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                            Else
                                Data(row, col) = ""
                            End If
                        Next col
                    Next row

                    libcsv.SaveCSV(ShInfo.FilePath, Data, ShInfo.row, ShInfo.col)

                    ShInfo.Changed = False

                    SheetMgr.ReflashSheetInfo(1, ShInfo)
                    Me.Close()
                Case vbNo
                    '保存せず閉じる
                    Me.Close()
                Case vbCancel
                    '閉じない
            End Select
        Else
            '変更なし -> 閉じる
            Me.Close()
        End If
    End Sub

    Private Sub 検索と置換ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索と置換ToolStripMenuItem.Click
        '検索と置換
        SearchReplace.Show()
    End Sub

    Private Sub フォントの変更ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles フォントの変更ToolStripMenuItem.Click
        'フォントの変更
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            DataGridView1.DefaultCellStyle.Font = FontDialog1.Font
        End If
    End Sub

    '画面ロード時
    Private Sub CSV_Editor_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.Columns.Add("", "1")

        '上書き保存を無効化
        保存ToolStripMenuItem.Enabled = False

        '戻すを無効化
        戻すStripMenuItem1.Enabled = False

        'やり直すを無効化
        やり直すStripMenuItem1.Enabled = False

        RowCol.Text = "1行, 1列"
        FormStatus.Text = "Ready"
    End Sub

    'DataGridViewのRowPostPaintイベントハンドラ
    Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint

        ' 行ヘッダのセル領域を、行番号を描画する長方形とする
        ' （ただし右端に4ドットのすき間を空ける）
        Dim rect As New Rectangle(
            e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            DataGridView1.RowHeadersWidth - 4,
            DataGridView1.Rows(e.RowIndex).Height)

        ' 上記の長方形内に行番号を縦方向中央＆右詰で描画する
        ' フォントや色は行ヘッダの既定値を使用する
        TextRenderer.DrawText(
            e.Graphics, (e.RowIndex + 1).ToString(),
            DataGridView1.RowHeadersDefaultCellStyle.Font,
            rect,
            DataGridView1.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter Or TextFormatFlags.Right)
    End Sub

    'DataGridViewのセル変更イベントハンドラ
    Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        '未保存フラグを立てる
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        ShInfo.Changed = True
        SheetMgr.ReflashSheetInfo(1, ShInfo)

        If ReadOk = True Then
            '履歴を保存するためデータを格納する
            Dim Datas As New ArrayList
            For i As Long = 0 To ShInfo.row - 1 Step 1
                For j As Integer = 0 To ShInfo.col - 1 Step 1
                    Dim temp As String = ""

                    If IsNothing(DataGridView1.Rows(i).Cells(j).Value) = False Then
                        temp = DataGridView1.Rows(i).Cells(j).Value.ToString
                    End If

                    Datas.Add(temp)
                Next j
                Datas.Add("[vbCrLf]")
            Next i

            SheetMgr.SetSheetContents(Datas)

            '戻すを有効化
            戻すStripMenuItem1.Enabled = True
        End If
    End Sub

    Private Sub 戻すStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 戻すStripMenuItem1.Click
        '戻す
        FormStatus.Text = "戻しています..."
        Dim Datas As ArrayList = SheetMgr.GetSheetBackContents()

        'セルにデータを展開する
        ReadOk = False

        'DataGridViewをクリア -> 行、列のサイズが違う可能性があるため
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("", "1")

        Dim Row As Long
        Dim Col As Integer
        Dim MaxCol As Integer

        '列と行を算出する
        For i As Integer = 0 To Datas.Count - 1 Step 1
            Dim data As String = Datas(i)
            If data <> "[vbCrLf]" Then
                Col += 1
                If Col > MaxCol Then
                    MaxCol = Col
                End If
            Else
                Row += 1
                Col = 0
            End If
        Next i


        '列を追加
        For i = 1 To MaxCol - 1 Step 1
            DataGridView1.Columns.Add("", i + 1)
        Next i

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        '行を追加
        For i = 1 To Row - 1 Step 1
            DataGridView1.Rows.Add()
        Next i

        'データの表示
        Dim oRow As Long
        Dim oCol As Integer

        For i As Integer = 0 To Datas.Count - 1 Step 1
            Dim data As String = Datas(i)
            If data <> "[vbCrLf]" Then
                DataGridView1.Rows(oRow).Cells(oCol).Value = data
                oCol += 1
            Else
                oRow += 1
                oCol = 0
            End If
        Next i

        ReadOk = True

        RowCol.Text = Row & "行, " & Col & "列"
        FormStatus.Text = "Ready"
    End Sub

    Private Sub やり直すStripMenuItem1_Click(sender As Object, e As EventArgs) Handles やり直すStripMenuItem1.Click
        'やり直す
        FormStatus.Text = "やり直しています..."
        Dim Datas As ArrayList = SheetMgr.GetSheetNextContents()

        'セルにデータを展開する
        ReadOk = False

        'DataGridViewをクリア -> 行、列のサイズが違う可能性があるため
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("", "1")

        Dim Row As Long
        Dim Col As Integer
        Dim MaxCol As Integer

        '列と行を算出する
        For i As Integer = 0 To Datas.Count - 1 Step 1
            Dim data As String = Datas(i)
            If data <> "[vbCrLf]" Then
                Col += 1
                If Col > MaxCol Then
                    MaxCol = Col
                End If
            Else
                Row += 1
                Col = 0
            End If
        Next i


        '列を追加
        For i = 1 To MaxCol - 1 Step 1
            DataGridView1.Columns.Add("", i + 1)
        Next i

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        '行を追加
        For i = 1 To Row - 1 Step 1
            DataGridView1.Rows.Add()
        Next i

        'データの表示
        Dim oRow As Long
        Dim oCol As Integer

        For i As Integer = 0 To Datas.Count - 1 Step 1
            Dim data As String = Datas(i)
            If data <> "[vbCrLf]" Then
                DataGridView1.Rows(oRow).Cells(oCol).Value = data
                oCol += 1
            Else
                oRow += 1
                oCol = 0
            End If
        Next i

        ReadOk = True

        RowCol.Text = Row & "行, " & Col & "列"
        FormStatus.Text = "Ready"
    End Sub

    Private Sub 切り取りStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 切り取りStripMenuItem1.Click
        '切り取り
        Dim CopyStr As String = ""

        If IsNothing(DataGridView1.CurrentCell.Value) = False Then
            CopyStr = DataGridView1.CurrentCell.Value.ToString
        End If

        SheetMgr.SetCellStr(CopyStr)

        DataGridView1.CurrentCell.Value = ""
    End Sub

    Private Sub コピーStripMenuItem1_Click(sender As Object, e As EventArgs) Handles コピーStripMenuItem1.Click
        'コピー
        Dim CopyStr As String = ""

        If IsNothing(DataGridView1.CurrentCell.Value) = False Then
            CopyStr = DataGridView1.CurrentCell.Value.ToString
        End If

        SheetMgr.SetCellStr(CopyStr)
    End Sub

    Private Sub 貼り付けStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 貼り付けStripMenuItem1.Click
        '貼り付け
        Dim PasteStr As String = ""

        SheetMgr.GetCellStr(PasteStr)

        DataGridView1.CurrentCell.Value = PasteStr
    End Sub

    Private Sub 行を挿入StripMenuItem1_Click(sender As Object, e As EventArgs) Handles 行を挿入StripMenuItem1.Click
        '行を挿入
        '1.現在DataGridView1にあるデータを配列にコピーする
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        ReadOk = False

        'DataGridViewのデータを取り込む
        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        '2.現在選択されている行を取得
        Dim CurrentRow As Long = DataGridView1.CurrentCell.RowIndex + 1

        '3.行を追加
        DataGridView1.Rows.Add()

        '4.2で取得した行を1行空白にしてデータをコピー
        For row = 1 To ShInfo.row + 1 Step 1
            If row < CurrentRow Then
                For col = 1 To ShInfo.col Step 1
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = Data(row, col)
                Next col
            ElseIf row > CurrentRow Then
                For col = 1 To ShInfo.col Step 1
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = Data(row - 1, col)
                Next col
            Else
                For col = 1 To ShInfo.col Step 1
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = ""
                Next col
            End If
        Next row

        ReadOk = True
        ShInfo.row += 1
        ShInfo.Changed = True
        SheetMgr.ReflashSheetInfo(1, ShInfo)

        '履歴を保存するためデータを格納する
        Dim Datas As New ArrayList
        For i As Long = 0 To ShInfo.row - 1 Step 1
            For j As Integer = 0 To ShInfo.col - 1 Step 1
                Dim temp As String = ""

                If IsNothing(DataGridView1.Rows(i).Cells(j).Value) = False Then
                    temp = DataGridView1.Rows(i).Cells(j).Value.ToString
                End If

                Datas.Add(temp)
            Next j
            Datas.Add("[vbCrLf]")
        Next i

        SheetMgr.SetSheetContents(Datas)

        '戻すを有効化
        戻すStripMenuItem1.Enabled = True
    End Sub

    Private Sub 列を挿入StripMenuItem1_Click(sender As Object, e As EventArgs) Handles 列を挿入StripMenuItem1.Click
        '列を挿入
        '1.現在DataGridView1にあるデータを配列にコピーする
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        ReadOk = False

        'DataGridViewのデータを取り込む
        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        '2.現在選択されている行を取得
        Dim CurrentCol As Long = DataGridView1.CurrentCell.ColumnIndex + 1

        '3.列を追加
        DataGridView1.Columns.Add("", ShInfo.col + 1)

        'ソートできないようにする
        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        '4.2で取得した列を空白にしてデータをコピー
        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col + 1 Step 1
                If col < CurrentCol Then
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = Data(row, col)
                ElseIf col > CurrentCol Then
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = Data(row, col - 1)
                Else
                    DataGridView1.Rows(row - 1).Cells(col - 1).Value = ""
                End If
            Next col
        Next row

        ReadOk = True

        ShInfo.col += 1
        ShInfo.Changed = True
        SheetMgr.ReflashSheetInfo(1, ShInfo)

        '履歴を保存するためデータを格納する
        Dim Datas As New ArrayList
        For i As Long = 0 To ShInfo.row - 1 Step 1
            For j As Integer = 0 To ShInfo.col - 1 Step 1
                Dim temp As String = ""

                If IsNothing(DataGridView1.Rows(i).Cells(j).Value) = False Then
                    temp = DataGridView1.Rows(i).Cells(j).Value.ToString
                End If

                Datas.Add(temp)
            Next j
            Datas.Add("[vbCrLf]")
        Next i

        SheetMgr.SetSheetContents(Datas)

        '戻すを有効化
        戻すStripMenuItem1.Enabled = True
    End Sub

    Private Sub DataGridView1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridView1.DragEnter
        'コントロール内にドラッグされたとき実行される
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、csvファイルのときはコピー
            Dim FileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
            Dim Ext As String = ModStr.ExtExtensionFromPath(FileName(0))

            If Ext.IndexOf("csv", StringComparison.OrdinalIgnoreCase) >= 0 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop
        'コントロール内にドロップされたとき実行される
        'ドロップされたすべてのファイル名を取得する
        Dim FileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Path As String = ""
        Dim FName As String = ""


        If ShInfo.Changed = True Then
            '変更あり -> 保存するか聞く
            ModStr.SplitPath(ShInfo.FilePath, Path, FName)

            Dim Ans As Long = MsgBox("変更を" & FName & "に保存しますか?", vbYesNoCancel + vbQuestion, "確認")

            Select Case Ans
                Case vbYes
                    '保存して開く
                    Dim Data(ShInfo.row, ShInfo.col) As String
                    Dim trow As Long = 1
                    Dim tcol As Integer = 1

                    'DataGridViewのデータを取り込む
                    For trow = 1 To ShInfo.row Step 1
                        For tcol = 1 To ShInfo.col Step 1
                            If IsNothing(DataGridView1.Rows(trow - 1).Cells(tcol - 1).Value) = False Then
                                Data(trow, tcol) = DataGridView1.Rows(trow - 1).Cells(tcol - 1).Value.ToString
                            Else
                                Data(trow, tcol) = ""
                            End If
                        Next tcol
                    Next trow

                    libcsv.SaveCSV(ShInfo.FilePath, Data, ShInfo.row, ShInfo.col)

                    ShInfo.Changed = False

                    SheetMgr.ReflashSheetInfo(1, ShInfo)
                Case vbNo
                    '保存しないで開く
                Case vbCancel
                    '開かない
                    Exit Sub
            End Select
        End If

        ModStr.SplitPath(FileName(0), Path, FName)

        FormStatus.Text = FName & "を読み込んでいます..."

        'DataGridViewをクリア
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("", "1")

        Dim Datas As New ArrayList
        Dim row As Long = 0
        Dim col As Integer = 0

        'csvファイルを読み込む
        libcsv.ExtCSV(Path & FName, Datas, row, col)

        'データを表示する
        Dim i As Integer

        For i = 1 To col - 1 Step 1
            DataGridView1.Columns.Add("", i + 1)
        Next i

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        For i = 1 To row - 1 Step 1
            DataGridView1.Rows.Add()
        Next i

        Dim oRow As Long
        Dim oCol As Integer

        For i = 0 To Datas.Count - 1 Step 1
            Dim data As String = Datas(i)
            If data <> "[vbCrLf]" Then
                DataGridView1.Rows(oRow).Cells(oCol).Value = data
                oCol += 1
            Else
                oRow += 1
                oCol = 0
            End If
        Next i

        Me.Text = "CSV Editor  :  " & Path & FName

        'シート情報を登録する
        ShInfo.FilePath = Path & FName
        ShInfo.Changed = False
        ShInfo.row = row
        ShInfo.col = col

        SheetMgr.ReflashSheetInfo(1, ShInfo)

        RowCol.Text = row & "行, " & col & "列"
        FormStatus.Text = "Ready"
    End Sub

End Class
