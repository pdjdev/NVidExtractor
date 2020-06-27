<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.DownModeLabel = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.SaveLocTB = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.ThumbnailBox = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LengthLabel = New System.Windows.Forms.Label()
        Me.RightPanel = New System.Windows.Forms.Panel()
        Me.RMidPanel = New System.Windows.Forms.Panel()
        Me.RBottomPanel = New System.Windows.Forms.Panel()
        Me.RTopPanel = New System.Windows.Forms.Panel()
        Me.LeftPanel = New System.Windows.Forms.Panel()
        Me.LMidPanel = New System.Windows.Forms.Panel()
        Me.LBottomPanel = New System.Windows.Forms.Panel()
        Me.LTopPanel = New System.Windows.Forms.Panel()
        Me.SidePanel = New System.Windows.Forms.Panel()
        Me.PauseResumeBT = New System.Windows.Forms.PictureBox()
        Me.MenuBT = New System.Windows.Forms.PictureBox()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.ProgPanel = New System.Windows.Forms.Panel()
        Me.ProgPanelOver = New System.Windows.Forms.Panel()
        Me.BottomPanel = New System.Windows.Forms.Panel()
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.VideoInfoReader = New System.ComponentModel.BackgroundWorker()
        Me.VidInfo_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.비디오정보보기ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetStrLink_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToOriginalLink_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSavePathMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceInfoRead_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceReset_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainPanel.SuspendLayout()
        Me.ThumbnailBox.SuspendLayout()
        Me.RightPanel.SuspendLayout()
        Me.LeftPanel.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        CType(Me.PauseResumeBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProgPanel.SuspendLayout()
        Me.VidInfo_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.White
        Me.MainPanel.Controls.Add(Me.DownModeLabel)
        Me.MainPanel.Controls.Add(Me.ComboBox2)
        Me.MainPanel.Controls.Add(Me.ComboBox1)
        Me.MainPanel.Controls.Add(Me.TitleLabel)
        Me.MainPanel.Controls.Add(Me.SaveLocTB)
        Me.MainPanel.Controls.Add(Me.Panel10)
        Me.MainPanel.Controls.Add(Me.ThumbnailBox)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MainPanel.Location = New System.Drawing.Point(10, 5)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Padding = New System.Windows.Forms.Padding(10, 17, 10, 10)
        Me.MainPanel.Size = New System.Drawing.Size(423, 98)
        Me.MainPanel.TabIndex = 9
        '
        'DownModeLabel
        '
        Me.DownModeLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.DownModeLabel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DownModeLabel.ForeColor = System.Drawing.Color.Gray
        Me.DownModeLabel.Location = New System.Drawing.Point(327, 51)
        Me.DownModeLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.DownModeLabel.Name = "DownModeLabel"
        Me.DownModeLabel.Size = New System.Drawing.Size(86, 24)
        Me.DownModeLabel.TabIndex = 5
        Me.DownModeLabel.Text = "영상+자막"
        Me.DownModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(246, 52)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(78, 20)
        Me.ComboBox2.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(140, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 20)
        Me.ComboBox1.TabIndex = 3
        '
        'TitleLabel
        '
        Me.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(140, 17)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(273, 34)
        Me.TitleLabel.TabIndex = 1
        Me.TitleLabel.Text = "비디오 정보를 읽어내는중..."
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveLocTB
        '
        Me.SaveLocTB.BackColor = System.Drawing.Color.White
        Me.SaveLocTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SaveLocTB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SaveLocTB.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SaveLocTB.ForeColor = System.Drawing.Color.Gray
        Me.SaveLocTB.Location = New System.Drawing.Point(140, 75)
        Me.SaveLocTB.Name = "SaveLocTB"
        Me.SaveLocTB.ReadOnly = True
        Me.SaveLocTB.Size = New System.Drawing.Size(273, 13)
        Me.SaveLocTB.TabIndex = 6
        Me.SaveLocTB.Text = "(저장 위치가 지정되지 않음)"
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.Location = New System.Drawing.Point(130, 17)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(10, 71)
        Me.Panel10.TabIndex = 16
        '
        'ThumbnailBox
        '
        Me.ThumbnailBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ThumbnailBox.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.alim_notfound
        Me.ThumbnailBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ThumbnailBox.Controls.Add(Me.CheckBox1)
        Me.ThumbnailBox.Controls.Add(Me.LengthLabel)
        Me.ThumbnailBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.ThumbnailBox.Location = New System.Drawing.Point(10, 17)
        Me.ThumbnailBox.Name = "ThumbnailBox"
        Me.ThumbnailBox.Size = New System.Drawing.Size(120, 71)
        Me.ThumbnailBox.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'LengthLabel
        '
        Me.LengthLabel.AutoSize = True
        Me.LengthLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LengthLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.LengthLabel.ForeColor = System.Drawing.Color.White
        Me.LengthLabel.Location = New System.Drawing.Point(82, 0)
        Me.LengthLabel.Name = "LengthLabel"
        Me.LengthLabel.Size = New System.Drawing.Size(38, 15)
        Me.LengthLabel.TabIndex = 0
        Me.LengthLabel.Text = "00:00"
        '
        'RightPanel
        '
        Me.RightPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RightPanel.Controls.Add(Me.RMidPanel)
        Me.RightPanel.Controls.Add(Me.RBottomPanel)
        Me.RightPanel.Controls.Add(Me.RTopPanel)
        Me.RightPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightPanel.Location = New System.Drawing.Point(460, 0)
        Me.RightPanel.Name = "RightPanel"
        Me.RightPanel.Size = New System.Drawing.Size(5, 120)
        Me.RightPanel.TabIndex = 6
        '
        'RMidPanel
        '
        Me.RMidPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.right_mid
        Me.RMidPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RMidPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RMidPanel.Location = New System.Drawing.Point(0, 5)
        Me.RMidPanel.Name = "RMidPanel"
        Me.RMidPanel.Size = New System.Drawing.Size(5, 110)
        Me.RMidPanel.TabIndex = 4
        '
        'RBottomPanel
        '
        Me.RBottomPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.bottom_right
        Me.RBottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RBottomPanel.Location = New System.Drawing.Point(0, 115)
        Me.RBottomPanel.Name = "RBottomPanel"
        Me.RBottomPanel.Size = New System.Drawing.Size(5, 5)
        Me.RBottomPanel.TabIndex = 3
        '
        'RTopPanel
        '
        Me.RTopPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.top_right
        Me.RTopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.RTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.RTopPanel.Name = "RTopPanel"
        Me.RTopPanel.Size = New System.Drawing.Size(5, 5)
        Me.RTopPanel.TabIndex = 2
        '
        'LeftPanel
        '
        Me.LeftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LeftPanel.Controls.Add(Me.LMidPanel)
        Me.LeftPanel.Controls.Add(Me.LBottomPanel)
        Me.LeftPanel.Controls.Add(Me.LTopPanel)
        Me.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftPanel.Location = New System.Drawing.Point(5, 0)
        Me.LeftPanel.Name = "LeftPanel"
        Me.LeftPanel.Size = New System.Drawing.Size(5, 120)
        Me.LeftPanel.TabIndex = 5
        '
        'LMidPanel
        '
        Me.LMidPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.left_mid
        Me.LMidPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LMidPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LMidPanel.Location = New System.Drawing.Point(0, 5)
        Me.LMidPanel.Name = "LMidPanel"
        Me.LMidPanel.Size = New System.Drawing.Size(5, 110)
        Me.LMidPanel.TabIndex = 0
        '
        'LBottomPanel
        '
        Me.LBottomPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.bottom_left
        Me.LBottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LBottomPanel.Location = New System.Drawing.Point(0, 115)
        Me.LBottomPanel.Name = "LBottomPanel"
        Me.LBottomPanel.Size = New System.Drawing.Size(5, 5)
        Me.LBottomPanel.TabIndex = 1
        '
        'LTopPanel
        '
        Me.LTopPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.top_left
        Me.LTopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LTopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LTopPanel.Location = New System.Drawing.Point(0, 0)
        Me.LTopPanel.Name = "LTopPanel"
        Me.LTopPanel.Size = New System.Drawing.Size(5, 5)
        Me.LTopPanel.TabIndex = 0
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.White
        Me.SidePanel.Controls.Add(Me.PauseResumeBT)
        Me.SidePanel.Controls.Add(Me.MenuBT)
        Me.SidePanel.Controls.Add(Me.CloseBT)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SidePanel.Location = New System.Drawing.Point(433, 5)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(27, 98)
        Me.SidePanel.TabIndex = 4
        '
        'PauseResumeBT
        '
        Me.PauseResumeBT.Dock = System.Windows.Forms.DockStyle.Top
        Me.PauseResumeBT.Image = Global.NVidExtractor.My.Resources.Resources.resume_b
        Me.PauseResumeBT.Location = New System.Drawing.Point(0, 54)
        Me.PauseResumeBT.Name = "PauseResumeBT"
        Me.PauseResumeBT.Size = New System.Drawing.Size(27, 27)
        Me.PauseResumeBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PauseResumeBT.TabIndex = 4
        Me.PauseResumeBT.TabStop = False
        '
        'MenuBT
        '
        Me.MenuBT.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuBT.Image = Global.NVidExtractor.My.Resources.Resources.menu_b
        Me.MenuBT.Location = New System.Drawing.Point(0, 27)
        Me.MenuBT.Name = "MenuBT"
        Me.MenuBT.Size = New System.Drawing.Size(27, 27)
        Me.MenuBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MenuBT.TabIndex = 5
        Me.MenuBT.TabStop = False
        '
        'CloseBT
        '
        Me.CloseBT.Dock = System.Windows.Forms.DockStyle.Top
        Me.CloseBT.Image = Global.NVidExtractor.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(0, 0)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(27, 27)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 3
        Me.CloseBT.TabStop = False
        '
        'ProgPanel
        '
        Me.ProgPanel.BackColor = System.Drawing.Color.White
        Me.ProgPanel.Controls.Add(Me.ProgPanelOver)
        Me.ProgPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgPanel.Location = New System.Drawing.Point(10, 103)
        Me.ProgPanel.Name = "ProgPanel"
        Me.ProgPanel.Size = New System.Drawing.Size(450, 12)
        Me.ProgPanel.TabIndex = 3
        '
        'ProgPanelOver
        '
        Me.ProgPanelOver.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ProgPanelOver.Dock = System.Windows.Forms.DockStyle.Left
        Me.ProgPanelOver.Location = New System.Drawing.Point(0, 0)
        Me.ProgPanelOver.Name = "ProgPanelOver"
        Me.ProgPanelOver.Size = New System.Drawing.Size(230, 12)
        Me.ProgPanelOver.TabIndex = 0
        '
        'BottomPanel
        '
        Me.BottomPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.bottom_mid
        Me.BottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomPanel.Location = New System.Drawing.Point(10, 115)
        Me.BottomPanel.Name = "BottomPanel"
        Me.BottomPanel.Size = New System.Drawing.Size(450, 5)
        Me.BottomPanel.TabIndex = 8
        '
        'TopPanel
        '
        Me.TopPanel.BackgroundImage = Global.NVidExtractor.My.Resources.Resources.top_mid
        Me.TopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(10, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(450, 5)
        Me.TopPanel.TabIndex = 7
        '
        'VideoInfoReader
        '
        '
        'VidInfo_Menu
        '
        Me.VidInfo_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.비디오정보보기ToolStripMenuItem, Me.GetStrLink_Menu, Me.ToOriginalLink_Menu, Me.OpenSavePathMenuToolStripMenuItem, Me.ForceInfoRead_Menu, Me.ForceReset_Menu})
        Me.VidInfo_Menu.Name = "ContextMenuStrip1"
        Me.VidInfo_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.VidInfo_Menu.ShowImageMargin = False
        Me.VidInfo_Menu.Size = New System.Drawing.Size(202, 136)
        '
        '비디오정보보기ToolStripMenuItem
        '
        Me.비디오정보보기ToolStripMenuItem.Name = "비디오정보보기ToolStripMenuItem"
        Me.비디오정보보기ToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.비디오정보보기ToolStripMenuItem.Text = "비디오 정보 보기"
        '
        'GetStrLink_Menu
        '
        Me.GetStrLink_Menu.Name = "GetStrLink_Menu"
        Me.GetStrLink_Menu.Size = New System.Drawing.Size(201, 22)
        Me.GetStrLink_Menu.Text = "스트리밍 링크 추출"
        '
        'ToOriginalLink_Menu
        '
        Me.ToOriginalLink_Menu.Name = "ToOriginalLink_Menu"
        Me.ToOriginalLink_Menu.Size = New System.Drawing.Size(201, 22)
        Me.ToOriginalLink_Menu.Text = "원본 비디오 링크 접속"
        '
        'OpenSavePathMenuToolStripMenuItem
        '
        Me.OpenSavePathMenuToolStripMenuItem.Name = "OpenSavePathMenuToolStripMenuItem"
        Me.OpenSavePathMenuToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.OpenSavePathMenuToolStripMenuItem.Text = "저장 위치 열기"
        '
        'ForceInfoRead_Menu
        '
        Me.ForceInfoRead_Menu.Name = "ForceInfoRead_Menu"
        Me.ForceInfoRead_Menu.Size = New System.Drawing.Size(201, 22)
        Me.ForceInfoRead_Menu.Text = "비디오 정보 다시 읽기"
        Me.ForceInfoRead_Menu.Visible = False
        '
        'ForceReset_Menu
        '
        Me.ForceReset_Menu.Name = "ForceReset_Menu"
        Me.ForceReset_Menu.Size = New System.Drawing.Size(201, 22)
        Me.ForceReset_Menu.Text = "다운로드 강제로 초기화하기"
        Me.ForceReset_Menu.Visible = False
        '
        'ItemPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.ProgPanel)
        Me.Controls.Add(Me.BottomPanel)
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.RightPanel)
        Me.Controls.Add(Me.LeftPanel)
        Me.DoubleBuffered = True
        Me.Name = "ItemPanel"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Size = New System.Drawing.Size(470, 120)
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ThumbnailBox.ResumeLayout(False)
        Me.ThumbnailBox.PerformLayout()
        Me.RightPanel.ResumeLayout(False)
        Me.LeftPanel.ResumeLayout(False)
        Me.SidePanel.ResumeLayout(False)
        CType(Me.PauseResumeBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProgPanel.ResumeLayout(False)
        Me.VidInfo_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BottomPanel As Panel
    Friend WithEvents LeftPanel As Panel
    Friend WithEvents LBottomPanel As Panel
    Friend WithEvents LTopPanel As Panel
    Friend WithEvents RightPanel As Panel
    Friend WithEvents RBottomPanel As Panel
    Friend WithEvents RTopPanel As Panel
    Friend WithEvents TopPanel As Panel
    Friend WithEvents MainPanel As Panel
    Friend WithEvents RMidPanel As Panel
    Friend WithEvents LMidPanel As Panel
    Friend WithEvents ThumbnailBox As Panel
    Friend WithEvents LengthLabel As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents SidePanel As Panel
    Friend WithEvents ProgPanel As Panel
    Friend WithEvents ProgPanelOver As Panel
    Friend WithEvents MenuBT As PictureBox
    Friend WithEvents PauseResumeBT As PictureBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DownModeLabel As Label
    Friend WithEvents VideoInfoReader As System.ComponentModel.BackgroundWorker
    Friend WithEvents VidInfo_Menu As ContextMenuStrip
    Friend WithEvents 비디오정보보기ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GetStrLink_Menu As ToolStripMenuItem
    Friend WithEvents ToOriginalLink_Menu As ToolStripMenuItem
    Friend WithEvents ForceInfoRead_Menu As ToolStripMenuItem
    Friend WithEvents ForceReset_Menu As ToolStripMenuItem
    Friend WithEvents SaveLocTB As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents OpenSavePathMenuToolStripMenuItem As ToolStripMenuItem
End Class
