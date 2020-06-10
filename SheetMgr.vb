Module SheetMgr
    'シート管理

    '/**************************************************/
    '/* 構造体定義                                     */
    '/**************************************************/
    Structure shMgrInfo
        Dim FilePath As String  'ファイルパス
        Dim Changed As Boolean  '変更されいるか
        Dim row As Long         '行数
        Dim col As Integer      '列数
        'Dim History() As shEdit '変更履歴
    End Structure

    '/**************************************************/
    '/* 列挙体定義                                     */
    '/**************************************************/
    Enum shOpe
        NoOpe           '変更なし
        ChangeCellStr   'セルの値を変更
        InsertRow       '行を挿入
        InsertCol       '列を挿入
    End Enum

    '/**************************************************/
    '/* ファイルスコープ定数定義                       */
    '/**************************************************/
    Private Const MAX_SHEET_HISTORY As Integer = 10

    '/**************************************************/
    '/* ファイルスコープ変数定義                       */
    '/**************************************************/
    Private NumSheets As Integer                            'シート数
    Private shMgr(1) As shMgrInfo                           'シート管理構造体
    Private CellStr As String                               '切り取り、コピーした文字列
    Private SheetHistory(MAX_SHEET_HISTORY) As ArrayList    'シートの変更履歴
    Private NumShHistory As Integer                         'シート履歴数
    Private StoreShHistory As Integer                       '履歴格納数

    '関数名:AddSheetInfo
    '概要:シート情報を追加する
    '引数::
    'shMgrInfo shInfo:シート管理情報
    '戻り値:なし
    Public Sub AddSheetInfo(ByVal shInfo As shMgrInfo)
        NumSheets += 1
        ReDim Preserve shMgr(NumSheets)

        shMgr(NumSheets) = shInfo
    End Sub

    '関数名:ReadSheetInfo
    '概要:シート情報を読み出す
    '引数::
    'Integer NumSh:シート番号
    '戻り値:シート情報
    Public Function ReadSheetInfo(ByVal NumSh As Integer) As shMgrInfo
        ReadSheetInfo = shMgr(NumSh)
    End Function

    '関数名:ReflashSheetInfo
    '概要:シート情報を更新する
    '引数::
    'Integer NumSh:シート番号
    'shMgrInfo shInfo:シート管理情報
    '戻り値:なし
    Public Sub ReflashSheetInfo(ByVal NumSh As Integer, ByVal shInfo As shMgrInfo)
        'ファイルが変更されていれば、履歴データを消去する
        If shMgr(NumSh).FilePath <> shInfo.FilePath _
        And shMgr(NumSh).FilePath <> "" Then
            For i As Integer = 1 To NumShHistory Step 1
                SheetHistory(i).Clear()
            Next i
            NumShHistory = 0
            StoreShHistory = 0
            '戻すを無効化
            CSV_Editor.戻すStripMenuItem1.Enabled = False
        End If

        shMgr(NumSh) = shInfo
    End Sub

    '関数名:DelSheetInfo
    '概要:シート情報を削除する
    '引数::
    'Integer NumSh:シート番号
    '戻り値:なし
    Public Sub DelSheetInfo(ByVal NumSh As Integer)
        shMgr(NumSh).FilePath = ""
        shMgr(NumSh).Changed = False
    End Sub

    '関数名:SetCellStr
    '概要:切り取り、コピーした文字列を保持する
    '引数::
    'String buf:文字列
    '戻り値:なし
    Public Sub SetCellStr(ByVal buf As String)
        CellStr = buf
    End Sub

    '関数名:GetCellStr
    '概要:保持した文字列を取得する
    '引数::
    'String :
    '戻り値:
    Public Sub GetCellStr(ByRef StoreStr As String)
        StoreStr = CellStr
    End Sub

    '関数名:SetSheetContents
    '概要:シートの内容をセットする
    '引数::
    'ArrayList Data:シートの内容
    '戻り値:
    Public Sub SetSheetContents(ByVal Data As ArrayList)
        NumShHistory += 1
        StoreShHistory += 1

        If NumShHistory > MAX_SHEET_HISTORY Then
            For i As Integer = 2 To 10 Step 1
                SheetHistory(i - 1).Clear()
                SheetHistory(i - 1) = SheetHistory(i)
            Next i
            NumShHistory = MAX_SHEET_HISTORY
            StoreShHistory = MAX_SHEET_HISTORY
            SheetHistory(NumShHistory).Clear()
        End If

        If StoreShHistory > NumShHistory Then
            CSV_Editor.やり直すStripMenuItem1.Enabled = True
        End If

        SheetHistory(NumShHistory) = Data
    End Sub

    '関数名:GetSheetBackContents
    '概要:シートの内容を取得する
    '引数::
    '戻り値:ArrayList
    'シートの内容
    Public Function GetSheetBackContents() As ArrayList
        NumShHistory -= 1
        GetSheetBackContents = SheetHistory(NumShHistory)

        If NumShHistory = 1 Then
            CSV_Editor.戻すStripMenuItem1.Enabled = False
        End If

        If StoreShHistory > NumShHistory Then
            CSV_Editor.やり直すStripMenuItem1.Enabled = True
        End If
    End Function

    '関数名:GetSheetNextContents
    '概要:シートの内容を取得する
    '引数::
    '戻り値:ArrayList
    'シートの内容
    Public Function GetSheetNextContents() As ArrayList
        NumShHistory += 1

        If NumShHistory < StoreShHistory Then
            GetSheetNextContents = SheetHistory(NumShHistory)
        Else
            GetSheetNextContents = SheetHistory(StoreShHistory)
            CSV_Editor.やり直すStripMenuItem1.Enabled = False
        End If
        CSV_Editor.戻すStripMenuItem1.Enabled = True
    End Function
End Module
