
Imports System

Partial Class Sample_GenericAcquisitionComponent
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Sample_GenericAcquisitionComponent))
        tabControlOptions = New Windows.Forms.TabControl()
        tabPageCoder = New Windows.Forms.TabPage()
        comboBoxAcquisitionModeStrategy = New Windows.Forms.ComboBox()
        label11 = New Windows.Forms.Label()
        comboBoxFVPFormat = New Windows.Forms.ComboBox()
        label10 = New Windows.Forms.Label()
        textBoxAuthent = New Windows.Forms.MaskedTextBox()
        textBoxLiveQualityThreshold = New Windows.Forms.MaskedTextBox()
        comboBoxSecurityLevel = New Windows.Forms.ComboBox()
        label9 = New Windows.Forms.Label()
        label8 = New Windows.Forms.Label()
        checkBoxAccept = New Windows.Forms.CheckBox()
        label7 = New Windows.Forms.Label()
        checkBoxRetry = New Windows.Forms.CheckBox()
        checkBoxJuvenile = New Windows.Forms.CheckBox()
        comboBoxFPFormat = New Windows.Forms.ComboBox()
        label4 = New Windows.Forms.Label()
        label3 = New Windows.Forms.Label()
        comboBoxCoderAlgo = New Windows.Forms.ComboBox()
        checkBoxConsolidate = New Windows.Forms.CheckBox()
        tabPageDisplay = New Windows.Forms.TabPage()
        textBoxShowQualityDuration = New Windows.Forms.TextBox()
        checkBoxLiveImage = New Windows.Forms.CheckBox()
        groupBox1 = New Windows.Forms.GroupBox()
        buttonSetImagePath = New Windows.Forms.Button()
        comboBoxFingerPosition = New Windows.Forms.ComboBox()
        labelShowQualityDuration = New Windows.Forms.Label()
        checkBoxSaveTemplate = New Windows.Forms.CheckBox()
        checkBoxSaveBitmap = New Windows.Forms.CheckBox()
        checkBoxShowLiveQualityBar = New Windows.Forms.CheckBox()
        checkBoxShowLiveQualityThreshold = New Windows.Forms.CheckBox()
        tabPageDevice = New Windows.Forms.TabPage()
        textBoxTimeout = New Windows.Forms.MaskedTextBox()
        groupBoxMorphoAccess = New Windows.Forms.GroupBox()
        comboBoxGen = New Windows.Forms.ComboBox()
        textBoxPort = New Windows.Forms.MaskedTextBox()
        textBoxIP = New MorphoControls.IPv4InputBox()
        label5 = New Windows.Forms.Label()
        label2 = New Windows.Forms.Label()
        label1 = New Windows.Forms.Label()
        groupBoxMorphoSmart = New Windows.Forms.GroupBox()
        buttonRefreshDevice = New Windows.Forms.Button()
        comboBoxDevice = New Windows.Forms.ComboBox()
        label6 = New Windows.Forms.Label()
        tabPageCulture = New Windows.Forms.TabPage()
        groupBoxCulture = New Windows.Forms.GroupBox()
        radioButtonCultureDe = New Windows.Forms.RadioButton()
        radioButtonCultureIt = New Windows.Forms.RadioButton()
        radioButtonCultureEn = New Windows.Forms.RadioButton()
        radioButtonCultureAr = New Windows.Forms.RadioButton()
        radioButtonCulturePt = New Windows.Forms.RadioButton()
        radioButtonCultureEs = New Windows.Forms.RadioButton()
        radioButtonCultureFr = New Windows.Forms.RadioButton()
        radioButtonCultureDefault = New Windows.Forms.RadioButton()
        buttonEnroll = New Windows.Forms.Button()
        buttonVerify = New Windows.Forms.Button()
        buttonCreateObject = New Windows.Forms.Button()
        ComponentTypes = New Windows.Forms.ComboBox()
        buttonVerifyMatch = New Windows.Forms.Button()
        tabControlOptions.SuspendLayout()
        tabPageCoder.SuspendLayout()
        tabPageDisplay.SuspendLayout()
        groupBox1.SuspendLayout()
        tabPageDevice.SuspendLayout()
        groupBoxMorphoAccess.SuspendLayout()
        groupBoxMorphoSmart.SuspendLayout()
        tabPageCulture.SuspendLayout()
        groupBoxCulture.SuspendLayout()
        SuspendLayout()
        ' 
        ' tabControlOptions
        ' 
        tabControlOptions.Controls.Add(tabPageCoder)
        tabControlOptions.Controls.Add(tabPageDisplay)
        tabControlOptions.Controls.Add(tabPageDevice)
        tabControlOptions.Controls.Add(tabPageCulture)
        tabControlOptions.Location = New Drawing.Point(12, 39)
        tabControlOptions.Name = "tabControlOptions"
        tabControlOptions.SelectedIndex = 0
        tabControlOptions.Size = New Drawing.Size(357, 249)
        tabControlOptions.TabIndex = 2
        ' 
        ' tabPageCoder
        ' 
        tabPageCoder.Controls.Add(comboBoxAcquisitionModeStrategy)
        tabPageCoder.Controls.Add(label11)
        tabPageCoder.Controls.Add(comboBoxFVPFormat)
        tabPageCoder.Controls.Add(label10)
        tabPageCoder.Controls.Add(textBoxAuthent)
        tabPageCoder.Controls.Add(textBoxLiveQualityThreshold)
        tabPageCoder.Controls.Add(comboBoxSecurityLevel)
        tabPageCoder.Controls.Add(label9)
        tabPageCoder.Controls.Add(label8)
        tabPageCoder.Controls.Add(checkBoxAccept)
        tabPageCoder.Controls.Add(label7)
        tabPageCoder.Controls.Add(checkBoxRetry)
        tabPageCoder.Controls.Add(checkBoxJuvenile)
        tabPageCoder.Controls.Add(comboBoxFPFormat)
        tabPageCoder.Controls.Add(label4)
        tabPageCoder.Controls.Add(label3)
        tabPageCoder.Controls.Add(comboBoxCoderAlgo)
        tabPageCoder.Controls.Add(checkBoxConsolidate)
        tabPageCoder.Location = New Drawing.Point(4, 22)
        tabPageCoder.Name = "tabPageCoder"
        tabPageCoder.Padding = New Windows.Forms.Padding(12)
        tabPageCoder.Size = New Drawing.Size(349, 223)
        tabPageCoder.TabIndex = 0
        tabPageCoder.Text = "Coder"
        tabPageCoder.UseVisualStyleBackColor = True
        ' 
        ' comboBoxAcquisitionModeStrategy
        ' 
        comboBoxAcquisitionModeStrategy.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxAcquisitionModeStrategy.FormattingEnabled = True
        comboBoxAcquisitionModeStrategy.Location = New Drawing.Point(15, 187)
        comboBoxAcquisitionModeStrategy.Name = "comboBoxAcquisitionModeStrategy"
        comboBoxAcquisitionModeStrategy.Size = New Drawing.Size(177, 21)
        comboBoxAcquisitionModeStrategy.TabIndex = 9
        ' 
        ' label11
        ' 
        label11.AutoSize = True
        label11.Location = New Drawing.Point(15, 171)
        label11.Name = "label11"
        label11.Size = New Drawing.Size(130, 13)
        label11.TabIndex = 8
        label11.Text = "Acquisition Mode Strategy"
        ' 
        ' comboBoxFVPFormat
        ' 
        comboBoxFVPFormat.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxFVPFormat.Enabled = False
        comboBoxFVPFormat.FormattingEnabled = True
        comboBoxFVPFormat.Items.AddRange(New Object() {"<none>", "IDEMIA PkFVP Finger Vein/Fingerprint Template"})
        comboBoxFVPFormat.Location = New Drawing.Point(15, 108)
        comboBoxFVPFormat.Name = "comboBoxFVPFormat"
        comboBoxFVPFormat.Size = New Drawing.Size(177, 21)
        comboBoxFVPFormat.TabIndex = 5
        ' 
        ' label10
        ' 
        label10.AutoSize = True
        label10.Location = New Drawing.Point(15, 92)
        label10.Name = "label10"
        label10.Size = New Drawing.Size(109, 13)
        label10.TabIndex = 4
        label10.Text = "FVP Template Format"
        ' 
        ' textBoxAuthent
        ' 
        textBoxAuthent.Location = New Drawing.Point(213, 148)
        textBoxAuthent.Mask = "99999"
        textBoxAuthent.Name = "textBoxAuthent"
        textBoxAuthent.PromptChar = " "c
        textBoxAuthent.Size = New Drawing.Size(121, 20)
        textBoxAuthent.TabIndex = 15
        textBoxAuthent.Text = "3500"
        textBoxAuthent.ValidatingType = GetType(Integer)
        ' 
        ' textBoxLiveQualityThreshold
        ' 
        textBoxLiveQualityThreshold.Location = New Drawing.Point(15, 148)
        textBoxLiveQualityThreshold.Mask = "999"
        textBoxLiveQualityThreshold.Name = "textBoxLiveQualityThreshold"
        textBoxLiveQualityThreshold.PromptChar = " "c
        textBoxLiveQualityThreshold.Size = New Drawing.Size(38, 20)
        textBoxLiveQualityThreshold.TabIndex = 7
        textBoxLiveQualityThreshold.Text = "60"
        AddHandler textBoxLiveQualityThreshold.Leave, New EventHandler(AddressOf textBoxLiveQualityThreshold_Leave)
        ' 
        ' comboBoxSecurityLevel
        ' 
        comboBoxSecurityLevel.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxSecurityLevel.FormattingEnabled = True
        comboBoxSecurityLevel.Items.AddRange(New Object() {"Standard", "Medium", "High"})
        comboBoxSecurityLevel.Location = New Drawing.Point(213, 187)
        comboBoxSecurityLevel.Name = "comboBoxSecurityLevel"
        comboBoxSecurityLevel.Size = New Drawing.Size(121, 21)
        comboBoxSecurityLevel.TabIndex = 17
        ' 
        ' label9
        ' 
        label9.AutoSize = True
        label9.Location = New Drawing.Point(213, 171)
        label9.Name = "label9"
        label9.Size = New Drawing.Size(74, 13)
        label9.TabIndex = 16
        label9.Text = "Security Level"
        ' 
        ' label8
        ' 
        label8.AutoSize = True
        label8.Location = New Drawing.Point(213, 132)
        label8.Name = "label8"
        label8.Size = New Drawing.Size(83, 13)
        label8.TabIndex = 14
        label8.Text = "Authentify score"
        ' 
        ' checkBoxAccept
        ' 
        checkBoxAccept.AutoSize = True
        checkBoxAccept.Checked = True
        checkBoxAccept.CheckState = Windows.Forms.CheckState.Checked
        checkBoxAccept.Location = New Drawing.Point(213, 84)
        checkBoxAccept.Name = "checkBoxAccept"
        checkBoxAccept.Size = New Drawing.Size(117, 17)
        checkBoxAccept.TabIndex = 13
        checkBoxAccept.Text = "Accept Bad Quality"
        checkBoxAccept.UseVisualStyleBackColor = True
        ' 
        ' label7
        ' 
        label7.AutoSize = True
        label7.Location = New Drawing.Point(15, 132)
        label7.Name = "label7"
        label7.Size = New Drawing.Size(106, 13)
        label7.TabIndex = 6
        label7.Text = "LiveQualityThreshold"
        ' 
        ' checkBoxRetry
        ' 
        checkBoxRetry.AutoSize = True
        checkBoxRetry.Checked = True
        checkBoxRetry.CheckState = Windows.Forms.CheckState.Checked
        checkBoxRetry.Location = New Drawing.Point(213, 15)
        checkBoxRetry.Name = "checkBoxRetry"
        checkBoxRetry.Size = New Drawing.Size(105, 17)
        checkBoxRetry.TabIndex = 10
        checkBoxRetry.Text = "Retry Acquisition"
        checkBoxRetry.UseVisualStyleBackColor = True
        ' 
        ' checkBoxJuvenile
        ' 
        checkBoxJuvenile.AutoSize = True
        checkBoxJuvenile.Checked = True
        checkBoxJuvenile.CheckState = Windows.Forms.CheckState.Checked
        checkBoxJuvenile.Location = New Drawing.Point(213, 38)
        checkBoxJuvenile.Name = "checkBoxJuvenile"
        checkBoxJuvenile.Size = New Drawing.Size(65, 17)
        checkBoxJuvenile.TabIndex = 11
        checkBoxJuvenile.Text = "Juvenile"
        checkBoxJuvenile.UseVisualStyleBackColor = True
        ' 
        ' comboBoxFPFormat
        ' 
        comboBoxFPFormat.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxFPFormat.FormattingEnabled = True
        comboBoxFPFormat.Items.AddRange(New Object() {"<none>", "IDEMIA CFV Fingerprint Template", "IDEMIA PkMat Fingerprint Template", "IDEMIA PkComp V2 Fingerprint Template", "IDEMIA PkLite Fingerprint Template", "ANSI INCITS 378-2004 Finger Minutiae Record", "ISO/IEC 19794-2:2005 Finger Minutiae Record", "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Normal Size", "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Compact Size"})
        comboBoxFPFormat.Location = New Drawing.Point(15, 68)
        comboBoxFPFormat.Name = "comboBoxFPFormat"
        comboBoxFPFormat.Size = New Drawing.Size(177, 21)
        comboBoxFPFormat.TabIndex = 3
        ' 
        ' label4
        ' 
        label4.AutoSize = True
        label4.Location = New Drawing.Point(15, 52)
        label4.Name = "label4"
        label4.Size = New Drawing.Size(102, 13)
        label4.TabIndex = 2
        label4.Text = "FP Template Format"
        ' 
        ' label3
        ' 
        label3.AutoSize = True
        label3.Location = New Drawing.Point(15, 12)
        label3.Name = "label3"
        label3.Size = New Drawing.Size(59, 13)
        label3.TabIndex = 0
        label3.Text = "Coder Algo"
        ' 
        ' comboBoxCoderAlgo
        ' 
        comboBoxCoderAlgo.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxCoderAlgo.FormattingEnabled = True
        comboBoxCoderAlgo.Items.AddRange(New Object() {"IDEMIA V6 Coder", "IDEMIA V9 Coder", "IDEMIA V10 Coder", "Device Embedded Coder"})
        comboBoxCoderAlgo.Location = New Drawing.Point(15, 28)
        comboBoxCoderAlgo.Name = "comboBoxCoderAlgo"
        comboBoxCoderAlgo.Size = New Drawing.Size(177, 21)
        comboBoxCoderAlgo.TabIndex = 1
        AddHandler comboBoxCoderAlgo.SelectedIndexChanged, New EventHandler(AddressOf comboBoxCoderAlgo_SelectedIndexChanged)
        ' 
        ' checkBoxConsolidate
        ' 
        checkBoxConsolidate.AutoSize = True
        checkBoxConsolidate.Checked = True
        checkBoxConsolidate.CheckState = Windows.Forms.CheckState.Checked
        checkBoxConsolidate.Location = New Drawing.Point(213, 61)
        checkBoxConsolidate.Name = "checkBoxConsolidate"
        checkBoxConsolidate.Size = New Drawing.Size(81, 17)
        checkBoxConsolidate.TabIndex = 12
        checkBoxConsolidate.Text = "Consolidate"
        checkBoxConsolidate.UseVisualStyleBackColor = True
        ' 
        ' tabPageDisplay
        ' 
        tabPageDisplay.Controls.Add(textBoxShowQualityDuration)
        tabPageDisplay.Controls.Add(checkBoxLiveImage)
        tabPageDisplay.Controls.Add(groupBox1)
        tabPageDisplay.Controls.Add(labelShowQualityDuration)
        tabPageDisplay.Controls.Add(checkBoxSaveTemplate)
        tabPageDisplay.Controls.Add(checkBoxSaveBitmap)
        tabPageDisplay.Controls.Add(checkBoxShowLiveQualityBar)
        tabPageDisplay.Controls.Add(checkBoxShowLiveQualityThreshold)
        tabPageDisplay.Location = New Drawing.Point(4, 22)
        tabPageDisplay.Name = "tabPageDisplay"
        tabPageDisplay.Padding = New Windows.Forms.Padding(12)
        tabPageDisplay.Size = New Drawing.Size(349, 223)
        tabPageDisplay.TabIndex = 1
        tabPageDisplay.Text = "Display"
        tabPageDisplay.UseVisualStyleBackColor = True
        ' 
        ' textBoxShowQualityDuration
        ' 
        textBoxShowQualityDuration.Location = New Drawing.Point(15, 89)
        textBoxShowQualityDuration.Name = "textBoxShowQualityDuration"
        textBoxShowQualityDuration.Size = New Drawing.Size(54, 20)
        textBoxShowQualityDuration.TabIndex = 3
        textBoxShowQualityDuration.Text = "500"
        AddHandler textBoxShowQualityDuration.Leave, New EventHandler(AddressOf textBoxShowQualityDuration_Leave)
        ' 
        ' checkBoxLiveImage
        ' 
        checkBoxLiveImage.AutoSize = True
        checkBoxLiveImage.Checked = True
        checkBoxLiveImage.CheckState = Windows.Forms.CheckState.Checked
        checkBoxLiveImage.Location = New Drawing.Point(236, 61)
        checkBoxLiveImage.Name = "checkBoxLiveImage"
        checkBoxLiveImage.Size = New Drawing.Size(78, 17)
        checkBoxLiveImage.TabIndex = 6
        checkBoxLiveImage.Text = "Live Image"
        checkBoxLiveImage.UseVisualStyleBackColor = True
        ' 
        ' groupBox1
        ' 
        groupBox1.Controls.Add(buttonSetImagePath)
        groupBox1.Controls.Add(comboBoxFingerPosition)
        groupBox1.Location = New Drawing.Point(15, 131)
        groupBox1.Name = "groupBox1"
        groupBox1.Padding = New Windows.Forms.Padding(10, 9, 10, 8)
        groupBox1.Size = New Drawing.Size(319, 57)
        groupBox1.TabIndex = 7
        groupBox1.TabStop = False
        groupBox1.Text = "Customized Images"
        ' 
        ' buttonSetImagePath
        ' 
        buttonSetImagePath.Location = New Drawing.Point(221, 25)
        buttonSetImagePath.Name = "buttonSetImagePath"
        buttonSetImagePath.Size = New Drawing.Size(85, 21)
        buttonSetImagePath.TabIndex = 1
        buttonSetImagePath.Text = "Associate File"
        buttonSetImagePath.UseVisualStyleBackColor = True
        AddHandler buttonSetImagePath.Click, New EventHandler(AddressOf buttonSetImagePath_Click)
        ' 
        ' comboBoxFingerPosition
        ' 
        comboBoxFingerPosition.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxFingerPosition.FormattingEnabled = True
        comboBoxFingerPosition.Location = New Drawing.Point(13, 25)
        comboBoxFingerPosition.Name = "comboBoxFingerPosition"
        comboBoxFingerPosition.Size = New Drawing.Size(202, 21)
        comboBoxFingerPosition.TabIndex = 0
        ' 
        ' labelShowQualityDuration
        ' 
        labelShowQualityDuration.AutoSize = True
        labelShowQualityDuration.Location = New Drawing.Point(12, 73)
        labelShowQualityDuration.Name = "labelShowQualityDuration"
        labelShowQualityDuration.Size = New Drawing.Size(188, 13)
        labelShowQualityDuration.TabIndex = 2
        labelShowQualityDuration.Text = "Show Coder Quality Duration (millisec.)"
        ' 
        ' checkBoxSaveTemplate
        ' 
        checkBoxSaveTemplate.AutoSize = True
        checkBoxSaveTemplate.Checked = True
        checkBoxSaveTemplate.CheckState = Windows.Forms.CheckState.Checked
        checkBoxSaveTemplate.Location = New Drawing.Point(236, 38)
        checkBoxSaveTemplate.Name = "checkBoxSaveTemplate"
        checkBoxSaveTemplate.Size = New Drawing.Size(98, 17)
        checkBoxSaveTemplate.TabIndex = 5
        checkBoxSaveTemplate.Text = "Save Template"
        checkBoxSaveTemplate.UseVisualStyleBackColor = True
        ' 
        ' checkBoxSaveBitmap
        ' 
        checkBoxSaveBitmap.AutoSize = True
        checkBoxSaveBitmap.Checked = True
        checkBoxSaveBitmap.CheckState = Windows.Forms.CheckState.Checked
        checkBoxSaveBitmap.Location = New Drawing.Point(236, 15)
        checkBoxSaveBitmap.Name = "checkBoxSaveBitmap"
        checkBoxSaveBitmap.Size = New Drawing.Size(83, 17)
        checkBoxSaveBitmap.TabIndex = 4
        checkBoxSaveBitmap.Text = "Save Image"
        checkBoxSaveBitmap.UseVisualStyleBackColor = True
        ' 
        ' checkBoxShowLiveQualityBar
        ' 
        checkBoxShowLiveQualityBar.AutoSize = True
        checkBoxShowLiveQualityBar.Checked = True
        checkBoxShowLiveQualityBar.CheckState = Windows.Forms.CheckState.Checked
        checkBoxShowLiveQualityBar.Location = New Drawing.Point(15, 15)
        checkBoxShowLiveQualityBar.Name = "checkBoxShowLiveQualityBar"
        checkBoxShowLiveQualityBar.Size = New Drawing.Size(130, 17)
        checkBoxShowLiveQualityBar.TabIndex = 0
        checkBoxShowLiveQualityBar.Text = "Show Live Quality Bar"
        checkBoxShowLiveQualityBar.UseVisualStyleBackColor = True
        ' 
        ' checkBoxShowLiveQualityThreshold
        ' 
        checkBoxShowLiveQualityThreshold.AutoSize = True
        checkBoxShowLiveQualityThreshold.Location = New Drawing.Point(15, 38)
        checkBoxShowLiveQualityThreshold.Name = "checkBoxShowLiveQualityThreshold"
        checkBoxShowLiveQualityThreshold.Size = New Drawing.Size(161, 17)
        checkBoxShowLiveQualityThreshold.TabIndex = 1
        checkBoxShowLiveQualityThreshold.Text = "Show Live Quality Threshold"
        checkBoxShowLiveQualityThreshold.UseVisualStyleBackColor = True
        ' 
        ' tabPageDevice
        ' 
        tabPageDevice.Controls.Add(textBoxTimeout)
        tabPageDevice.Controls.Add(groupBoxMorphoAccess)
        tabPageDevice.Controls.Add(label1)
        tabPageDevice.Controls.Add(groupBoxMorphoSmart)
        tabPageDevice.Location = New Drawing.Point(4, 22)
        tabPageDevice.Name = "tabPageDevice"
        tabPageDevice.Padding = New Windows.Forms.Padding(12)
        tabPageDevice.Size = New Drawing.Size(349, 223)
        tabPageDevice.TabIndex = 2
        tabPageDevice.Text = "Device"
        tabPageDevice.UseVisualStyleBackColor = True
        ' 
        ' textBoxTimeout
        ' 
        textBoxTimeout.Location = New Drawing.Point(15, 126)
        textBoxTimeout.Mask = "99999"
        textBoxTimeout.Name = "textBoxTimeout"
        textBoxTimeout.PromptChar = " "c
        textBoxTimeout.Size = New Drawing.Size(46, 20)
        textBoxTimeout.TabIndex = 3
        textBoxTimeout.Text = "15"
        textBoxTimeout.ValidatingType = GetType(Integer)
        AddHandler textBoxTimeout.Leave, New EventHandler(AddressOf textBoxTimeout_Leave)
        ' 
        ' groupBoxMorphoAccess
        ' 
        groupBoxMorphoAccess.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
        groupBoxMorphoAccess.Controls.Add(comboBoxGen)
        groupBoxMorphoAccess.Controls.Add(textBoxPort)
        groupBoxMorphoAccess.Controls.Add(textBoxIP)
        groupBoxMorphoAccess.Controls.Add(label5)
        groupBoxMorphoAccess.Controls.Add(label2)
        groupBoxMorphoAccess.Enabled = False
        groupBoxMorphoAccess.Location = New Drawing.Point(92, 110)
        groupBoxMorphoAccess.Name = "groupBoxMorphoAccess"
        groupBoxMorphoAccess.Padding = New Windows.Forms.Padding(10, 9, 10, 8)
        groupBoxMorphoAccess.Size = New Drawing.Size(242, 78)
        groupBoxMorphoAccess.TabIndex = 1
        groupBoxMorphoAccess.TabStop = False
        groupBoxMorphoAccess.Text = "MorphoAccess"
        ' 
        ' comboBoxGen
        ' 
        comboBoxGen.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
        comboBoxGen.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        comboBoxGen.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
        comboBoxGen.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxGen.Items.AddRange(New Object() {"MA2G", "MA5G"})
        comboBoxGen.Location = New Drawing.Point(147, 47)
        comboBoxGen.Name = "comboBoxGen"
        comboBoxGen.Size = New Drawing.Size(82, 21)
        comboBoxGen.TabIndex = 4
        ' 
        ' textBoxPort
        ' 
        textBoxPort.Location = New Drawing.Point(77, 47)
        textBoxPort.Mask = "99999"
        textBoxPort.Name = "textBoxPort"
        textBoxPort.PromptChar = " "c
        textBoxPort.Size = New Drawing.Size(63, 20)
        textBoxPort.TabIndex = 3
        textBoxPort.Text = "11010"
        textBoxPort.ValidatingType = GetType(Integer)
        ' 
        ' textBoxIP
        ' 
        textBoxIP.Address = CType(resources.GetObject("textBoxIP.Address"), Net.IPAddress)
        textBoxIP.AddressText = "10.126.46.54"
        textBoxIP.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
        textBoxIP.BackColor = Drawing.SystemColors.Window
        textBoxIP.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        textBoxIP.Cursor = Windows.Forms.Cursors.IBeam
        textBoxIP.ForeColor = Drawing.SystemColors.WindowText
        textBoxIP.Location = New Drawing.Point(77, 16)
        textBoxIP.MinimumSize = New Drawing.Size(136, 20)
        textBoxIP.Name = "textBoxIP"
        textBoxIP.Padding = New Windows.Forms.Padding(1, 1, 1, 2)
        textBoxIP.Size = New Drawing.Size(152, 25)
        textBoxIP.TabIndex = 1
        ' 
        ' label5
        ' 
        label5.AutoSize = True
        label5.Location = New Drawing.Point(13, 50)
        label5.Name = "label5"
        label5.Size = New Drawing.Size(26, 13)
        label5.TabIndex = 2
        label5.Text = "Port"
        ' 
        ' label2
        ' 
        label2.AutoSize = True
        label2.Location = New Drawing.Point(13, 22)
        label2.Name = "label2"
        label2.Size = New Drawing.Size(58, 13)
        label2.TabIndex = 0
        label2.Text = "IP Address"
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Location = New Drawing.Point(12, 110)
        label1.Name = "label1"
        label1.Size = New Drawing.Size(74, 13)
        label1.TabIndex = 2
        label1.Text = "Timeout (sec.)"
        ' 
        ' groupBoxMorphoSmart
        ' 
        groupBoxMorphoSmart.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
        groupBoxMorphoSmart.Controls.Add(buttonRefreshDevice)
        groupBoxMorphoSmart.Controls.Add(comboBoxDevice)
        groupBoxMorphoSmart.Controls.Add(label6)
        groupBoxMorphoSmart.Location = New Drawing.Point(15, 15)
        groupBoxMorphoSmart.Name = "groupBoxMorphoSmart"
        groupBoxMorphoSmart.Padding = New Windows.Forms.Padding(10, 9, 10, 8)
        groupBoxMorphoSmart.Size = New Drawing.Size(319, 70)
        groupBoxMorphoSmart.TabIndex = 0
        groupBoxMorphoSmart.TabStop = False
        groupBoxMorphoSmart.Text = "MorphoSmart"
        ' 
        ' buttonRefreshDevice
        ' 
        buttonRefreshDevice.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Right
        buttonRefreshDevice.Location = New Drawing.Point(252, 38)
        buttonRefreshDevice.Name = "buttonRefreshDevice"
        buttonRefreshDevice.Size = New Drawing.Size(54, 21)
        buttonRefreshDevice.TabIndex = 2
        buttonRefreshDevice.Text = "Refresh"
        buttonRefreshDevice.UseVisualStyleBackColor = True
        AddHandler buttonRefreshDevice.Click, New EventHandler(AddressOf buttonRefreshDevice_Click)
        ' 
        ' comboBoxDevice
        ' 
        comboBoxDevice.Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
        comboBoxDevice.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        comboBoxDevice.FormattingEnabled = True
        comboBoxDevice.Location = New Drawing.Point(16, 38)
        comboBoxDevice.Name = "comboBoxDevice"
        comboBoxDevice.Size = New Drawing.Size(230, 21)
        comboBoxDevice.TabIndex = 1
        ' 
        ' label6
        ' 
        label6.AutoSize = True
        label6.Location = New Drawing.Point(13, 22)
        label6.Name = "label6"
        label6.Size = New Drawing.Size(107, 13)
        label6.TabIndex = 0
        label6.Text = "MorphoSmart Device"
        ' 
        ' tabPageCulture
        ' 
        tabPageCulture.Controls.Add(groupBoxCulture)
        tabPageCulture.Location = New Drawing.Point(4, 22)
        tabPageCulture.Name = "tabPageCulture"
        tabPageCulture.Padding = New Windows.Forms.Padding(12)
        tabPageCulture.Size = New Drawing.Size(349, 223)
        tabPageCulture.TabIndex = 3
        tabPageCulture.Text = "Culture"
        tabPageCulture.UseVisualStyleBackColor = True
        ' 
        ' groupBoxCulture
        ' 
        groupBoxCulture.BackgroundImageLayout = Windows.Forms.ImageLayout.None
        groupBoxCulture.Controls.Add(radioButtonCultureDe)
        groupBoxCulture.Controls.Add(radioButtonCultureIt)
        groupBoxCulture.Controls.Add(radioButtonCultureEn)
        groupBoxCulture.Controls.Add(radioButtonCultureAr)
        groupBoxCulture.Controls.Add(radioButtonCulturePt)
        groupBoxCulture.Controls.Add(radioButtonCultureEs)
        groupBoxCulture.Controls.Add(radioButtonCultureFr)
        groupBoxCulture.Controls.Add(radioButtonCultureDefault)
        groupBoxCulture.FlatStyle = Windows.Forms.FlatStyle.Flat
        groupBoxCulture.ForeColor = Drawing.SystemColors.ControlText
        groupBoxCulture.Location = New Drawing.Point(15, 15)
        groupBoxCulture.Name = "groupBoxCulture"
        groupBoxCulture.Padding = New Windows.Forms.Padding(10, 9, 10, 8)
        groupBoxCulture.RightToLeft = Windows.Forms.RightToLeft.No
        groupBoxCulture.Size = New Drawing.Size(319, 99)
        groupBoxCulture.TabIndex = 0
        groupBoxCulture.TabStop = False
        groupBoxCulture.Text = "Culture"
        ' 
        ' radioButtonCultureDe
        ' 
        radioButtonCultureDe.AutoSize = True
        radioButtonCultureDe.Location = New Drawing.Point(223, 48)
        radioButtonCultureDe.Name = "radioButtonCultureDe"
        radioButtonCultureDe.Size = New Drawing.Size(83, 17)
        radioButtonCultureDe.TabIndex = 7
        radioButtonCultureDe.Text = "German (de)"
        radioButtonCultureDe.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureIt
        ' 
        radioButtonCultureIt.AutoSize = True
        radioButtonCultureIt.Location = New Drawing.Point(223, 25)
        radioButtonCultureIt.Name = "radioButtonCultureIt"
        radioButtonCultureIt.Size = New Drawing.Size(67, 17)
        radioButtonCultureIt.TabIndex = 6
        radioButtonCultureIt.Text = "Italian (it)"
        radioButtonCultureIt.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureEn
        ' 
        radioButtonCultureEn.AutoSize = True
        radioButtonCultureEn.Location = New Drawing.Point(13, 48)
        radioButtonCultureEn.Name = "radioButtonCultureEn"
        radioButtonCultureEn.Size = New Drawing.Size(80, 17)
        radioButtonCultureEn.TabIndex = 1
        radioButtonCultureEn.Text = "English (en)"
        radioButtonCultureEn.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureAr
        ' 
        radioButtonCultureAr.AutoSize = True
        radioButtonCultureAr.Location = New Drawing.Point(109, 71)
        radioButtonCultureAr.Name = "radioButtonCultureAr"
        radioButtonCultureAr.Size = New Drawing.Size(73, 17)
        radioButtonCultureAr.TabIndex = 5
        radioButtonCultureAr.Text = "Arabic (ar)"
        radioButtonCultureAr.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCulturePt
        ' 
        radioButtonCulturePt.AutoSize = True
        radioButtonCulturePt.Location = New Drawing.Point(109, 25)
        radioButtonCulturePt.Name = "radioButtonCulturePt"
        radioButtonCulturePt.Size = New Drawing.Size(97, 17)
        radioButtonCulturePt.TabIndex = 3
        radioButtonCulturePt.Text = "Portuguese (pt)"
        radioButtonCulturePt.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureEs
        ' 
        radioButtonCultureEs.AutoSize = True
        radioButtonCultureEs.Location = New Drawing.Point(109, 48)
        radioButtonCultureEs.Name = "radioButtonCultureEs"
        radioButtonCultureEs.Size = New Drawing.Size(83, 17)
        radioButtonCultureEs.TabIndex = 4
        radioButtonCultureEs.Text = "Spanish (es)"
        radioButtonCultureEs.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureFr
        ' 
        radioButtonCultureFr.AutoSize = True
        radioButtonCultureFr.Location = New Drawing.Point(13, 71)
        radioButtonCultureFr.Name = "radioButtonCultureFr"
        radioButtonCultureFr.Size = New Drawing.Size(73, 17)
        radioButtonCultureFr.TabIndex = 2
        radioButtonCultureFr.Text = "French (fr)"
        radioButtonCultureFr.UseVisualStyleBackColor = True
        ' 
        ' radioButtonCultureDefault
        ' 
        radioButtonCultureDefault.AutoSize = True
        radioButtonCultureDefault.Checked = True
        radioButtonCultureDefault.Location = New Drawing.Point(13, 25)
        radioButtonCultureDefault.Name = "radioButtonCultureDefault"
        radioButtonCultureDefault.Size = New Drawing.Size(63, 17)
        radioButtonCultureDefault.TabIndex = 0
        radioButtonCultureDefault.TabStop = True
        radioButtonCultureDefault.Text = "(default)"
        radioButtonCultureDefault.UseVisualStyleBackColor = True
        ' 
        ' buttonEnroll
        ' 
        buttonEnroll.Location = New Drawing.Point(12, 294)
        buttonEnroll.Name = "buttonEnroll"
        buttonEnroll.Size = New Drawing.Size(85, 21)
        buttonEnroll.TabIndex = 3
        buttonEnroll.Text = "Enroll"
        buttonEnroll.UseVisualStyleBackColor = True
        AddHandler buttonEnroll.Click, New EventHandler(AddressOf buttonEnroll_Click)
        ' 
        ' buttonVerify
        ' 
        buttonVerify.Location = New Drawing.Point(284, 294)
        buttonVerify.Name = "buttonVerify"
        buttonVerify.Size = New Drawing.Size(85, 21)
        buttonVerify.TabIndex = 4
        buttonVerify.Text = "Verify"
        buttonVerify.UseVisualStyleBackColor = True
        AddHandler buttonVerify.Click, New EventHandler(AddressOf buttonVerify_Click)
        ' 
        ' buttonCreateObject
        ' 
        buttonCreateObject.Location = New Drawing.Point(284, 12)
        buttonCreateObject.Name = "buttonCreateObject"
        buttonCreateObject.Size = New Drawing.Size(85, 21)
        buttonCreateObject.TabIndex = 1
        buttonCreateObject.Text = "Create Object"
        buttonCreateObject.UseVisualStyleBackColor = True
        AddHandler buttonCreateObject.Click, New EventHandler(AddressOf buttonCreateObject_Click)
        ' 
        ' ComponentTypes
        ' 
        ComponentTypes.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        ComponentTypes.FormattingEnabled = True
        ComponentTypes.Location = New Drawing.Point(12, 12)
        ComponentTypes.Name = "ComponentTypes"
        ComponentTypes.Size = New Drawing.Size(266, 21)
        ComponentTypes.TabIndex = 0
        ' 
        ' buttonVerifyMatch
        ' 
        buttonVerifyMatch.Location = New Drawing.Point(151, 294)
        buttonVerifyMatch.Name = "buttonVerifyMatch"
        buttonVerifyMatch.Size = New Drawing.Size(85, 21)
        buttonVerifyMatch.TabIndex = 5
        buttonVerifyMatch.Text = "VerifyMatch"
        buttonVerifyMatch.UseVisualStyleBackColor = True
        AddHandler buttonVerifyMatch.Click, New EventHandler(AddressOf buttonVerifyMatch_Click)
        ' 
        ' Sample_GenericAcquisitionComponent
        ' 
        AutoScaleDimensions = New Drawing.SizeF(6.0F, 13.0F)
        AutoScaleMode = Windows.Forms.AutoScaleMode.Font
        ClientSize = New Drawing.Size(381, 327)
        Controls.Add(buttonVerifyMatch)
        Controls.Add(buttonCreateObject)
        Controls.Add(ComponentTypes)
        Controls.Add(buttonVerify)
        Controls.Add(buttonEnroll)
        Controls.Add(tabControlOptions)
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "Sample_GenericAcquisitionComponent"
        StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Text = "Test Generic Acquisition Component"
        AddHandler Load, New EventHandler(AddressOf GenericAcquisitionComponent_Load)
        AddHandler Shown, New EventHandler(AddressOf GenericAcquisitionComponent_Shown)
        tabControlOptions.ResumeLayout(False)
        tabPageCoder.ResumeLayout(False)
        tabPageCoder.PerformLayout()
        tabPageDisplay.ResumeLayout(False)
        tabPageDisplay.PerformLayout()
        groupBox1.ResumeLayout(False)
        tabPageDevice.ResumeLayout(False)
        tabPageDevice.PerformLayout()
        groupBoxMorphoAccess.ResumeLayout(False)
        groupBoxMorphoAccess.PerformLayout()
        groupBoxMorphoSmart.ResumeLayout(False)
        groupBoxMorphoSmart.PerformLayout()
        tabPageCulture.ResumeLayout(False)
        groupBoxCulture.ResumeLayout(False)
        groupBoxCulture.PerformLayout()
        ResumeLayout(False)

    End Sub

#End Region

    Private tabControlOptions As Windows.Forms.TabControl
    Private tabPageCoder As Windows.Forms.TabPage
    Private tabPageDisplay As Windows.Forms.TabPage
    Private tabPageDevice As Windows.Forms.TabPage
    Private tabPageCulture As Windows.Forms.TabPage
    Private checkBoxConsolidate As Windows.Forms.CheckBox
    Private buttonEnroll As Windows.Forms.Button
    Private buttonVerify As Windows.Forms.Button
    Private checkBoxRetry As Windows.Forms.CheckBox
    Private checkBoxJuvenile As Windows.Forms.CheckBox
    Private comboBoxFPFormat As Windows.Forms.ComboBox
    Private label4 As Windows.Forms.Label
    Private label3 As Windows.Forms.Label
    Private comboBoxCoderAlgo As Windows.Forms.ComboBox
    Private checkBoxSaveTemplate As Windows.Forms.CheckBox
    Private checkBoxSaveBitmap As Windows.Forms.CheckBox
    Private checkBoxShowLiveQualityBar As Windows.Forms.CheckBox
    Private checkBoxShowLiveQualityThreshold As Windows.Forms.CheckBox
    Private label1 As Windows.Forms.Label
    Private groupBoxCulture As Windows.Forms.GroupBox
    Private radioButtonCultureDefault As Windows.Forms.RadioButton
    Private radioButtonCultureFr As Windows.Forms.RadioButton
    Private label7 As Windows.Forms.Label
    Private radioButtonCulturePt As Windows.Forms.RadioButton
    Private radioButtonCultureEs As Windows.Forms.RadioButton
    Private radioButtonCultureAr As Windows.Forms.RadioButton
    Private radioButtonCultureEn As Windows.Forms.RadioButton
    Private radioButtonCultureIt As Windows.Forms.RadioButton
    Private radioButtonCultureDe As Windows.Forms.RadioButton
    Private checkBoxAccept As Windows.Forms.CheckBox
    Private buttonCreateObject As Windows.Forms.Button
    Private ComponentTypes As Windows.Forms.ComboBox
    Private groupBoxMorphoAccess As Windows.Forms.GroupBox
    Private labelShowQualityDuration As Windows.Forms.Label
    Private label5 As Windows.Forms.Label
    Private label2 As Windows.Forms.Label
    Private textBoxIP As MorphoControls.IPv4InputBox
    Private groupBoxMorphoSmart As Windows.Forms.GroupBox
    Private buttonRefreshDevice As Windows.Forms.Button
    Private comboBoxDevice As Windows.Forms.ComboBox
    Private label6 As Windows.Forms.Label
    Private groupBox1 As Windows.Forms.GroupBox
    Private checkBoxLiveImage As Windows.Forms.CheckBox
    Private buttonSetImagePath As Windows.Forms.Button
    Private comboBoxFingerPosition As Windows.Forms.ComboBox
    Private label8 As Windows.Forms.Label
    Private comboBoxSecurityLevel As Windows.Forms.ComboBox
    Private label9 As Windows.Forms.Label
    Private textBoxLiveQualityThreshold As Windows.Forms.MaskedTextBox
    Private textBoxAuthent As Windows.Forms.MaskedTextBox
    Private textBoxTimeout As Windows.Forms.MaskedTextBox
    Private textBoxPort As Windows.Forms.MaskedTextBox
    Private textBoxShowQualityDuration As Windows.Forms.TextBox
    Private comboBoxFVPFormat As Windows.Forms.ComboBox
    Private label10 As Windows.Forms.Label
    Private comboBoxGen As Windows.Forms.ComboBox
    Private comboBoxAcquisitionModeStrategy As Windows.Forms.ComboBox
    Private label11 As Windows.Forms.Label
    Private buttonVerifyMatch As Windows.Forms.Button
End Class
