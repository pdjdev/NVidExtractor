<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.UrlTB = New System.Windows.Forms.TextBox()
        Me.LinkAddBT = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.devurl = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.SelectionApplyBT = New System.Windows.Forms.Button()
        Me.QualityCB = New System.Windows.Forms.ComboBox()
        Me.ModeCB = New System.Windows.Forms.ComboBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.SaveLocTB = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.SetLocationBT = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.GetBlogPostBT = New System.Windows.Forms.Button()
        Me.ClipboardChk = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TipLabel = New System.Windows.Forms.Label()
        Me.ListPanel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DeleteCompleteBT = New System.Windows.Forms.Button()
        Me.ForceResetBT = New System.Windows.Forms.Button()
        Me.DeleteBT = New System.Windows.Forms.Button()
        Me.SelectAllBT = New System.Windows.Forms.Button()
        Me.BottomPanel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.appurl = New System.Windows.Forms.LinkLabel()
        Me.DownCountUD = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LogBT = New System.Windows.Forms.Button()
        Me.DownStartBT = New System.Windows.Forms.Button()
        Me.DownCheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ClipboardChecker = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DownCountUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'UrlTB
        '
        Me.UrlTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.UrlTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UrlTB.Dock = System.Windows.Forms.DockStyle.Top
        Me.UrlTB.ForeColor = System.Drawing.Color.White
        Me.UrlTB.Location = New System.Drawing.Point(0, 0)
        Me.UrlTB.Name = "UrlTB"
        Me.UrlTB.Size = New System.Drawing.Size(316, 23)
        Me.UrlTB.TabIndex = 0
        '
        'LinkAddBT
        '
        Me.LinkAddBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.LinkAddBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.LinkAddBT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.LinkAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LinkAddBT.ForeColor = System.Drawing.Color.White
        Me.LinkAddBT.Location = New System.Drawing.Point(1, 0)
        Me.LinkAddBT.Name = "LinkAddBT"
        Me.LinkAddBT.Size = New System.Drawing.Size(88, 54)
        Me.LinkAddBT.TabIndex = 1
        Me.LinkAddBT.Text = "링크" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "분석/추가"
        Me.LinkAddBT.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.devurl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(540, 130)
        Me.Panel1.TabIndex = 2
        '
        'devurl
        '
        Me.devurl.BackColor = System.Drawing.Color.Transparent
        Me.devurl.DisabledLinkColor = System.Drawing.Color.Silver
        Me.devurl.Dock = System.Windows.Forms.DockStyle.Right
        Me.devurl.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.devurl.LinkColor = System.Drawing.Color.Silver
        Me.devurl.Location = New System.Drawing.Point(441, 0)
        Me.devurl.Name = "devurl"
        Me.devurl.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.devurl.Size = New System.Drawing.Size(99, 32)
        Me.devurl.TabIndex = 15
        Me.devurl.TabStop = True
        Me.devurl.Text = "프로그램 정보..."
        Me.devurl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(7, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "공유 링크 입력 (플레이어, 페이지 URL)"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Panel9)
        Me.Panel7.Controls.Add(Me.Panel12)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 32)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 13)
        Me.Panel7.Size = New System.Drawing.Size(540, 98)
        Me.Panel7.TabIndex = 13
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.SelectionApplyBT)
        Me.Panel9.Controls.Add(Me.QualityCB)
        Me.Panel9.Controls.Add(Me.ModeCB)
        Me.Panel9.Controls.Add(Me.Panel8)
        Me.Panel9.Controls.Add(Me.UrlTB)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(10, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Panel9.Size = New System.Drawing.Size(326, 85)
        Me.Panel9.TabIndex = 14
        '
        'SelectionApplyBT
        '
        Me.SelectionApplyBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SelectionApplyBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.SelectionApplyBT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.SelectionApplyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectionApplyBT.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SelectionApplyBT.ForeColor = System.Drawing.Color.White
        Me.SelectionApplyBT.Location = New System.Drawing.Point(180, 61)
        Me.SelectionApplyBT.Name = "SelectionApplyBT"
        Me.SelectionApplyBT.Size = New System.Drawing.Size(136, 24)
        Me.SelectionApplyBT.TabIndex = 9
        Me.SelectionApplyBT.Text = "선택 항목 옵션 적용"
        Me.SelectionApplyBT.UseVisualStyleBackColor = False
        '
        'QualityCB
        '
        Me.QualityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.QualityCB.FormattingEnabled = True
        Me.QualityCB.Items.AddRange(New Object() {"270p", "480p", "720p", "1080p"})
        Me.QualityCB.Location = New System.Drawing.Point(97, 61)
        Me.QualityCB.Name = "QualityCB"
        Me.QualityCB.Size = New System.Drawing.Size(76, 23)
        Me.QualityCB.TabIndex = 4
        '
        'ModeCB
        '
        Me.ModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModeCB.FormattingEnabled = True
        Me.ModeCB.Items.AddRange(New Object() {"영상만", "영상+자막", "자막만"})
        Me.ModeCB.Location = New System.Drawing.Point(0, 61)
        Me.ModeCB.Name = "ModeCB"
        Me.ModeCB.Size = New System.Drawing.Size(90, 23)
        Me.ModeCB.TabIndex = 10
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.SaveLocTB)
        Me.Panel8.Controls.Add(Me.Panel11)
        Me.Panel8.Controls.Add(Me.SetLocationBT)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 23)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(0, 8, 0, 7)
        Me.Panel8.Size = New System.Drawing.Size(316, 38)
        Me.Panel8.TabIndex = 13
        '
        'SaveLocTB
        '
        Me.SaveLocTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SaveLocTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaveLocTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveLocTB.ForeColor = System.Drawing.Color.White
        Me.SaveLocTB.Location = New System.Drawing.Point(0, 8)
        Me.SaveLocTB.Name = "SaveLocTB"
        Me.SaveLocTB.Size = New System.Drawing.Size(268, 23)
        Me.SaveLocTB.TabIndex = 11
        '
        'Panel11
        '
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel11.Location = New System.Drawing.Point(268, 8)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(10, 23)
        Me.Panel11.TabIndex = 16
        '
        'SetLocationBT
        '
        Me.SetLocationBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SetLocationBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.SetLocationBT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.SetLocationBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SetLocationBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SetLocationBT.ForeColor = System.Drawing.Color.White
        Me.SetLocationBT.Location = New System.Drawing.Point(278, 8)
        Me.SetLocationBT.Name = "SetLocationBT"
        Me.SetLocationBT.Size = New System.Drawing.Size(38, 23)
        Me.SetLocationBT.TabIndex = 12
        Me.SetLocationBT.Text = "..."
        Me.SetLocationBT.UseVisualStyleBackColor = False
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.LinkAddBT)
        Me.Panel12.Controls.Add(Me.Panel10)
        Me.Panel12.Controls.Add(Me.GetBlogPostBT)
        Me.Panel12.Controls.Add(Me.ClipboardChk)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(336, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(194, 85)
        Me.Panel12.TabIndex = 16
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(89, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(10, 54)
        Me.Panel10.TabIndex = 15
        '
        'GetBlogPostBT
        '
        Me.GetBlogPostBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.GetBlogPostBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.GetBlogPostBT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.GetBlogPostBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GetBlogPostBT.ForeColor = System.Drawing.Color.White
        Me.GetBlogPostBT.Location = New System.Drawing.Point(99, 0)
        Me.GetBlogPostBT.Name = "GetBlogPostBT"
        Me.GetBlogPostBT.Size = New System.Drawing.Size(95, 54)
        Me.GetBlogPostBT.TabIndex = 2
        Me.GetBlogPostBT.Text = "블로그에서" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "모두 불러오기"
        Me.GetBlogPostBT.UseVisualStyleBackColor = False
        '
        'ClipboardChk
        '
        Me.ClipboardChk.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ClipboardChk.Font = New System.Drawing.Font("맑은 고딕", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ClipboardChk.ForeColor = System.Drawing.Color.White
        Me.ClipboardChk.Location = New System.Drawing.Point(0, 54)
        Me.ClipboardChk.Name = "ClipboardChk"
        Me.ClipboardChk.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.ClipboardChk.Size = New System.Drawing.Size(194, 31)
        Me.ClipboardChk.TabIndex = 16
        Me.ClipboardChk.Text = "클립보드에서 자동으로 불러오기"
        Me.ClipboardChk.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TipLabel)
        Me.Panel2.Controls.Add(Me.ListPanel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 130)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(540, 455)
        Me.Panel2.TabIndex = 3
        '
        'TipLabel
        '
        Me.TipLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TipLabel.Font = New System.Drawing.Font("맑은 고딕 Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TipLabel.ForeColor = System.Drawing.Color.Silver
        Me.TipLabel.Location = New System.Drawing.Point(0, 35)
        Me.TipLabel.Name = "TipLabel"
        Me.TipLabel.Size = New System.Drawing.Size(540, 368)
        Me.TipLabel.TabIndex = 0
        Me.TipLabel.Text = "다운로드 받을 비디오를 추가해 주세요."
        Me.TipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TipLabel.Visible = False
        '
        'ListPanel
        '
        Me.ListPanel.AutoScroll = True
        Me.ListPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPanel.Location = New System.Drawing.Point(0, 35)
        Me.ListPanel.Name = "ListPanel"
        Me.ListPanel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ListPanel.Size = New System.Drawing.Size(540, 368)
        Me.ListPanel.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.SelectAllBT)
        Me.Panel4.Controls.Add(Me.BottomPanel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(540, 35)
        Me.Panel4.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DeleteCompleteBT)
        Me.Panel5.Controls.Add(Me.ForceResetBT)
        Me.Panel5.Controls.Add(Me.DeleteBT)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(288, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(252, 30)
        Me.Panel5.TabIndex = 16
        '
        'DeleteCompleteBT
        '
        Me.DeleteCompleteBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.DeleteCompleteBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.DeleteCompleteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteCompleteBT.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DeleteCompleteBT.ForeColor = System.Drawing.Color.Black
        Me.DeleteCompleteBT.Location = New System.Drawing.Point(9, 2)
        Me.DeleteCompleteBT.Name = "DeleteCompleteBT"
        Me.DeleteCompleteBT.Size = New System.Drawing.Size(90, 23)
        Me.DeleteCompleteBT.TabIndex = 19
        Me.DeleteCompleteBT.Text = "완료항목 삭제"
        Me.DeleteCompleteBT.UseVisualStyleBackColor = False
        '
        'ForceResetBT
        '
        Me.ForceResetBT.BackColor = System.Drawing.Color.IndianRed
        Me.ForceResetBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.ForceResetBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ForceResetBT.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForceResetBT.ForeColor = System.Drawing.Color.White
        Me.ForceResetBT.Location = New System.Drawing.Point(105, 2)
        Me.ForceResetBT.Name = "ForceResetBT"
        Me.ForceResetBT.Size = New System.Drawing.Size(81, 23)
        Me.ForceResetBT.TabIndex = 17
        Me.ForceResetBT.Text = "강제 초기화"
        Me.ForceResetBT.UseVisualStyleBackColor = False
        '
        'DeleteBT
        '
        Me.DeleteBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.DeleteBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.DeleteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteBT.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DeleteBT.ForeColor = System.Drawing.Color.Black
        Me.DeleteBT.Location = New System.Drawing.Point(192, 2)
        Me.DeleteBT.Name = "DeleteBT"
        Me.DeleteBT.Size = New System.Drawing.Size(50, 23)
        Me.DeleteBT.TabIndex = 16
        Me.DeleteBT.Text = "삭제"
        Me.DeleteBT.UseVisualStyleBackColor = False
        '
        'SelectAllBT
        '
        Me.SelectAllBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SelectAllBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.SelectAllBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectAllBT.ForeColor = System.Drawing.Color.Black
        Me.SelectAllBT.Location = New System.Drawing.Point(12, 6)
        Me.SelectAllBT.Name = "SelectAllBT"
        Me.SelectAllBT.Size = New System.Drawing.Size(84, 23)
        Me.SelectAllBT.TabIndex = 11
        Me.SelectAllBT.Text = "전체 선택"
        Me.SelectAllBT.UseVisualStyleBackColor = False
        '
        'BottomPanel
        '
        Me.BottomPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.bottom_mid
        Me.BottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BottomPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.BottomPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomPanel.Name = "BottomPanel"
        Me.BottomPanel.Size = New System.Drawing.Size(540, 5)
        Me.BottomPanel.TabIndex = 17
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.appurl)
        Me.Panel3.Controls.Add(Me.DownCountUD)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 403)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(540, 52)
        Me.Panel3.TabIndex = 0
        '
        'appurl
        '
        Me.appurl.AutoSize = True
        Me.appurl.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.appurl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.appurl.Location = New System.Drawing.Point(6, 33)
        Me.appurl.Name = "appurl"
        Me.appurl.Size = New System.Drawing.Size(172, 13)
        Me.appurl.TabIndex = 16
        Me.appurl.TabStop = True
        Me.appurl.Text = "프로그램 페이지 (최신 버전 확인)"
        '
        'DownCountUD
        '
        Me.DownCountUD.Location = New System.Drawing.Point(97, 7)
        Me.DownCountUD.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.DownCountUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.DownCountUD.Name = "DownCountUD"
        Me.DownCountUD.Size = New System.Drawing.Size(37, 23)
        Me.DownCountUD.TabIndex = 13
        Me.DownCountUD.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "동시 다운 개수"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.LogBT)
        Me.Panel6.Controls.Add(Me.DownStartBT)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(307, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(233, 52)
        Me.Panel6.TabIndex = 11
        '
        'LogBT
        '
        Me.LogBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LogBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.LogBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogBT.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LogBT.ForeColor = System.Drawing.Color.Black
        Me.LogBT.Location = New System.Drawing.Point(3, 23)
        Me.LogBT.Name = "LogBT"
        Me.LogBT.Size = New System.Drawing.Size(66, 21)
        Me.LogBT.TabIndex = 12
        Me.LogBT.Text = "로그 보기"
        Me.LogBT.UseVisualStyleBackColor = False
        '
        'DownStartBT
        '
        Me.DownStartBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.DownStartBT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.DownStartBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DownStartBT.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DownStartBT.ForeColor = System.Drawing.Color.Black
        Me.DownStartBT.Location = New System.Drawing.Point(75, 6)
        Me.DownStartBT.Name = "DownStartBT"
        Me.DownStartBT.Size = New System.Drawing.Size(146, 38)
        Me.DownStartBT.TabIndex = 11
        Me.DownStartBT.Text = "다운로드 시작"
        Me.DownStartBT.UseVisualStyleBackColor = False
        '
        'DownCheckTimer
        '
        Me.DownCheckTimer.Interval = 1000
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "저장할 위치를 선택해 주십시오."
        '
        'ClipboardChecker
        '
        Me.ClipboardChecker.Interval = 500
        '
        'Form1
        '
        Me.AcceptButton = Me.LinkAddBT
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(540, 585)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Icon = Global.NVidExtractor.My.Resources.Resources.icon
        Me.MinimumSize = New System.Drawing.Size(556, 370)
        Me.Name = "Form1"
        Me.Text = "네이버 비디오 추출기 1.0v"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DownCountUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UrlTB As TextBox
    Friend WithEvents LinkAddBT As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GetBlogPostBT As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListPanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents SelectionApplyBT As Button
    Friend WithEvents QualityCB As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DeleteCompleteBT As Button
    Friend WithEvents ForceResetBT As Button
    Friend WithEvents DeleteBT As Button
    Friend WithEvents SelectAllBT As Button
    Friend WithEvents DownStartBT As Button
    Friend WithEvents DownCheckTimer As Timer
    Friend WithEvents Panel6 As Panel
    Friend WithEvents DownCountUD As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents LogBT As Button
    Friend WithEvents TipLabel As Label
    Friend WithEvents ModeCB As ComboBox
    Friend WithEvents SetLocationBT As Button
    Friend WithEvents SaveLocTB As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Panel12 As Panel
    Friend WithEvents ClipboardChk As CheckBox
    Friend WithEvents ClipboardChecker As Timer
    Friend WithEvents BottomPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents devurl As LinkLabel
    Friend WithEvents appurl As LinkLabel
End Class
