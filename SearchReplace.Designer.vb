<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchReplace
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchStr = New System.Windows.Forms.TextBox()
        Me.ReplaceStr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckLorS = New System.Windows.Forms.CheckBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.Replace = New System.Windows.Forms.Button()
        Me.AllReplace = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "検索する文字列"
        '
        'SearchStr
        '
        Me.SearchStr.Location = New System.Drawing.Point(102, 6)
        Me.SearchStr.Name = "SearchStr"
        Me.SearchStr.Size = New System.Drawing.Size(228, 19)
        Me.SearchStr.TabIndex = 1
        '
        'ReplaceStr
        '
        Me.ReplaceStr.Location = New System.Drawing.Point(102, 31)
        Me.ReplaceStr.Name = "ReplaceStr"
        Me.ReplaceStr.Size = New System.Drawing.Size(228, 19)
        Me.ReplaceStr.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "置換する文字列"
        '
        'CheckLorS
        '
        Me.CheckLorS.AutoSize = True
        Me.CheckLorS.Location = New System.Drawing.Point(12, 61)
        Me.CheckLorS.Name = "CheckLorS"
        Me.CheckLorS.Size = New System.Drawing.Size(156, 16)
        Me.CheckLorS.TabIndex = 4
        Me.CheckLorS.Text = "大文字と小文字を区別する"
        Me.CheckLorS.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(12, 87)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 23)
        Me.Search.TabIndex = 5
        Me.Search.Text = "検索"
        Me.Search.UseVisualStyleBackColor = True
        '
        'Replace
        '
        Me.Replace.Location = New System.Drawing.Point(93, 87)
        Me.Replace.Name = "Replace"
        Me.Replace.Size = New System.Drawing.Size(75, 23)
        Me.Replace.TabIndex = 6
        Me.Replace.Text = "置換"
        Me.Replace.UseVisualStyleBackColor = True
        '
        'AllReplace
        '
        Me.AllReplace.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AllReplace.Location = New System.Drawing.Point(174, 87)
        Me.AllReplace.Name = "AllReplace"
        Me.AllReplace.Size = New System.Drawing.Size(75, 23)
        Me.AllReplace.TabIndex = 7
        Me.AllReplace.Text = "すべて置換"
        Me.AllReplace.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(255, 87)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 8
        Me.Cancel.Text = "キャンセル"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'SearchReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(345, 119)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.AllReplace)
        Me.Controls.Add(Me.Replace)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.CheckLorS)
        Me.Controls.Add(Me.ReplaceStr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SearchStr)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchReplace"
        Me.Text = "検索と置換"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SearchStr As TextBox
    Friend WithEvents ReplaceStr As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckLorS As CheckBox
    Friend WithEvents Search As Button
    Friend WithEvents Replace As Button
    Friend WithEvents AllReplace As Button
    Friend WithEvents Cancel As Button
End Class
