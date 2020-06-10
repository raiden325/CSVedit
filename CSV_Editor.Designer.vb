<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CSV_Editor
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.名前をつけて保存ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.編集ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索と置換ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.オプションToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.フォントの変更ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.FormStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RowCol = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.戻すStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.切り取りStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.コピーStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.貼り付けStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.挿入StripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.行を挿入StripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.列を挿入StripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.やり直すStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.編集ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開くToolStripMenuItem, Me.ToolStripSeparator1, Me.保存ToolStripMenuItem, Me.名前をつけて保存ToolStripMenuItem1, Me.ToolStripSeparator2, Me.閉じるToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        '開くToolStripMenuItem
        '
        Me.開くToolStripMenuItem.Name = "開くToolStripMenuItem"
        Me.開くToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.開くToolStripMenuItem.Text = "開く"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.保存ToolStripMenuItem.Text = "上書き保存"
        '
        '名前をつけて保存ToolStripMenuItem1
        '
        Me.名前をつけて保存ToolStripMenuItem1.Name = "名前をつけて保存ToolStripMenuItem1"
        Me.名前をつけて保存ToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.名前をつけて保存ToolStripMenuItem1.Text = "名前をつけて保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(155, 6)
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        '編集ToolStripMenuItem
        '
        Me.編集ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.検索と置換ToolStripMenuItem, Me.オプションToolStripMenuItem})
        Me.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem"
        Me.編集ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.編集ToolStripMenuItem.Text = "編集"
        '
        '検索と置換ToolStripMenuItem
        '
        Me.検索と置換ToolStripMenuItem.Name = "検索と置換ToolStripMenuItem"
        Me.検索と置換ToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.検索と置換ToolStripMenuItem.Text = "検索と置換"
        '
        'オプションToolStripMenuItem
        '
        Me.オプションToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.フォントの変更ToolStripMenuItem})
        Me.オプションToolStripMenuItem.Name = "オプションToolStripMenuItem"
        Me.オプションToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.オプションToolStripMenuItem.Text = "オプション"
        '
        'フォントの変更ToolStripMenuItem
        '
        Me.フォントの変更ToolStripMenuItem.Name = "フォントの変更ToolStripMenuItem"
        Me.フォントの変更ToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.フォントの変更ToolStripMenuItem.Text = "フォントの変更"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormStatus, Me.RowCol})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 537)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 24)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FormStatus
        '
        Me.FormStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.FormStatus.Name = "FormStatus"
        Me.FormStatus.Size = New System.Drawing.Size(55, 19)
        Me.FormStatus.Text = "ステータス"
        '
        'RowCol
        '
        Me.RowCol.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.RowCol.Name = "RowCol"
        Me.RowCol.Size = New System.Drawing.Size(65, 19)
        Me.RowCol.Text = "xx行, xx列"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(784, 513)
        Me.DataGridView1.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.やり直すStripMenuItem1, Me.戻すStripMenuItem1, Me.ToolStripSeparator4, Me.切り取りStripMenuItem1, Me.コピーStripMenuItem1, Me.貼り付けStripMenuItem1, Me.ToolStripSeparator3, Me.挿入StripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 170)
        '
        '戻すStripMenuItem1
        '
        Me.戻すStripMenuItem1.Name = "戻すStripMenuItem1"
        Me.戻すStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.戻すStripMenuItem1.Text = "元に戻す"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
        '
        '切り取りStripMenuItem1
        '
        Me.切り取りStripMenuItem1.Name = "切り取りStripMenuItem1"
        Me.切り取りStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.切り取りStripMenuItem1.Text = "切り取り"
        '
        'コピーStripMenuItem1
        '
        Me.コピーStripMenuItem1.Name = "コピーStripMenuItem1"
        Me.コピーStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.コピーStripMenuItem1.Text = "コピー"
        '
        '貼り付けStripMenuItem1
        '
        Me.貼り付けStripMenuItem1.Name = "貼り付けStripMenuItem1"
        Me.貼り付けStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.貼り付けStripMenuItem1.Text = "貼り付け"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(177, 6)
        '
        '挿入StripMenuItem1
        '
        Me.挿入StripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.行を挿入StripMenuItem1, Me.列を挿入StripMenuItem1})
        Me.挿入StripMenuItem1.Name = "挿入StripMenuItem1"
        Me.挿入StripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.挿入StripMenuItem1.Text = "挿入"
        '
        '行を挿入StripMenuItem1
        '
        Me.行を挿入StripMenuItem1.Name = "行を挿入StripMenuItem1"
        Me.行を挿入StripMenuItem1.Size = New System.Drawing.Size(119, 22)
        Me.行を挿入StripMenuItem1.Text = "行を挿入"
        '
        '列を挿入StripMenuItem1
        '
        Me.列を挿入StripMenuItem1.Name = "列を挿入StripMenuItem1"
        Me.列を挿入StripMenuItem1.Size = New System.Drawing.Size(119, 22)
        Me.列を挿入StripMenuItem1.Text = "列を挿入"
        '
        'やり直すStripMenuItem1
        '
        Me.やり直すStripMenuItem1.Name = "やり直すStripMenuItem1"
        Me.やり直すStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.やり直すStripMenuItem1.Text = "やり直す"
        '
        'CSV_Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CSV_Editor"
        Me.Text = "CSV Editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 編集ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 検索と置換ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents FormStatus As ToolStripStatusLabel
    Friend WithEvents RowCol As ToolStripStatusLabel
    Friend WithEvents オプションToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents フォントの変更ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 名前をつけて保存ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 挿入StripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 行を挿入StripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 列を挿入StripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 戻すStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents 切り取りStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents コピーStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 貼り付けStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents やり直すStripMenuItem1 As ToolStripMenuItem
End Class
