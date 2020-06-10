Public Class SearchReplace
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        '検索
        Dim sStr As String = SearchStr.Text
        Dim rStr As String = ReplaceStr.Text
        Dim CheckLS As Boolean

        If CheckLorS.Checked Then
            CheckLS = True
        End If

        '最初に見つかったものを置換する
        '1.現在の行・列を取得
        Dim cRow As Long = CSV_Editor.DataGridView1.CurrentCell.RowIndex + 1
        Dim cCol As Integer = CSV_Editor.DataGridView1.CurrentCell.ColumnIndex + 2

        '2.DataGridView1のセルの内容を配列にコピー
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        '3.1で取得した行・列から一致する文字列を検索する
        Dim ChIdx As Integer
        Dim IsHit As Boolean = False

        For row = cRow To ShInfo.row Step 1
            If IsHit = False Then
                If row = cRow Then
                    For col = cCol To ShInfo.col Step 1
                        If CheckLS Then
                            '大文字と小文字を区別する
                            ChIdx = Data(row, col).IndexOf(sStr)
                            If ChIdx >= 0 Then
                                CSV_Editor.DataGridView1.CurrentCell = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1)
                                IsHit = True
                                Exit For
                            End If
                        Else
                            ChIdx = Data(row, col).IndexOf(sStr, StringComparison.OrdinalIgnoreCase)
                            If ChIdx >= 0 Then
                                CSV_Editor.DataGridView1.CurrentCell = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1)
                                IsHit = True
                                Exit For
                            End If
                        End If
                    Next col
                Else
                    For col = 1 To ShInfo.col Step 1
                        If CheckLS Then
                            '大文字と小文字を区別する
                            ChIdx = Data(row, col).IndexOf(sStr)
                            If ChIdx >= 0 Then
                                CSV_Editor.DataGridView1.CurrentCell = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1)
                                IsHit = True
                                Exit For
                            End If
                        Else
                            ChIdx = Data(row, col).IndexOf(sStr, StringComparison.OrdinalIgnoreCase)
                            If ChIdx >= 0 Then
                                CSV_Editor.DataGridView1.CurrentCell = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1)
                                IsHit = True
                                Exit For
                            End If
                        End If
                    Next col
                End If
            Else
                Exit For
            End If
        Next row
    End Sub

    Private Sub Replace_Click(sender As Object, e As EventArgs) Handles Replace.Click
        '置換
        Dim sStr As String = SearchStr.Text
        Dim rStr As String = ReplaceStr.Text
        Dim CheckLS As Boolean

        If CheckLorS.Checked Then
            CheckLS = True
        End If

        '最初に見つかったものを置換する
        '1.現在の行・列を取得
        Dim cRow As Long = CSV_Editor.DataGridView1.CurrentCell.RowIndex + 1
        Dim cCol As Integer = CSV_Editor.DataGridView1.CurrentCell.ColumnIndex + 1

        '2.DataGridView1のセルの内容を配列にコピー
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        '3.1で取得した行・列から一致する文字列を検索する
        Dim ChIdx As Integer
        Dim tData As String
        Dim IsHit As Boolean = False

        For row = cRow To ShInfo.row Step 1
            If IsHit = False Then
                If row = cRow Then
                    For col = cCol To ShInfo.col Step 1
                        If CheckLS Then
                            '大文字と小文字を区別する
                            ChIdx = Data(row, col).IndexOf(sStr)
                            If ChIdx >= 0 Then
                                tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                                Data(row, col) = tData
                                CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                                IsHit = True
                                Exit For
                            End If
                        Else
                            ChIdx = Data(row, col).IndexOf(sStr, StringComparison.OrdinalIgnoreCase)
                            If ChIdx >= 0 Then
                                tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                                Data(row, col) = tData
                                CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                                IsHit = True
                                Exit For
                            End If
                        End If
                    Next col
                Else
                    For col = 1 To ShInfo.col Step 1
                        If CheckLS Then
                            '大文字と小文字を区別する
                            ChIdx = Data(row, col).IndexOf(sStr)
                            If ChIdx >= 0 Then
                                tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                                Data(row, col) = tData
                                CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                                IsHit = True
                                Exit For
                            End If
                        Else
                            ChIdx = Data(row, col).IndexOf(sStr, StringComparison.OrdinalIgnoreCase)
                            If ChIdx >= 0 Then
                                tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                                Data(row, col) = tData
                                CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                                IsHit = True
                                Exit For
                            End If
                        End If
                    Next col
                End If
            Else
                Exit For
            End If
        Next row
    End Sub

    Private Sub AllReplace_Click(sender As Object, e As EventArgs) Handles AllReplace.Click
        'すべて置換
        Dim sStr As String = SearchStr.Text
        Dim rStr As String = ReplaceStr.Text
        Dim CheckLS As Boolean

        If CheckLorS.Checked Then
            CheckLS = True
        End If

        '2.DataGridView1のセルの内容を配列にコピー
        Dim ShInfo As SheetMgr.shMgrInfo = SheetMgr.ReadSheetInfo(1)
        Dim Data(ShInfo.row, ShInfo.col) As String
        Dim row As Long = 1
        Dim col As Integer = 1

        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If IsNothing(CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value) = False Then
                    Data(row, col) = CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value.ToString
                Else
                    Data(row, col) = ""
                End If
            Next col
        Next row

        '3.1で取得した行・列から一致する文字列を検索する
        Dim ChIdx As Integer
        Dim tData As String
        Dim IsHit As Boolean = False

        For row = 1 To ShInfo.row Step 1
            For col = 1 To ShInfo.col Step 1
                If CheckLS Then
                    '大文字と小文字を区別する
                    ChIdx = Data(row, col).IndexOf(sStr)
                    If ChIdx >= 0 Then
                        tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                        Data(row, col) = tData
                        CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                        IsHit = True
                        Exit For
                    End If
                Else
                    ChIdx = Data(row, col).IndexOf(sStr, StringComparison.OrdinalIgnoreCase)
                    If ChIdx >= 0 Then
                        tData = Data(row, col).Substring(0, ChIdx) & rStr & Data(row, col).Substring(ChIdx + sStr.Length)
                        Data(row, col) = tData
                        CSV_Editor.DataGridView1.Rows(row - 1).Cells(col - 1).Value = tData
                        IsHit = True
                        Exit For
                    End If
                End If
            Next col
        Next row
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        'キャンセル
        Me.Close()
    End Sub
End Class