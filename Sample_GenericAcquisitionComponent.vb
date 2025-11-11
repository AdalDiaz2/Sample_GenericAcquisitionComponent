Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Morpho.MorphoAcquisition


Partial Public Class Sample_GenericAcquisitionComponent
    Inherits Form
    Private GenericAcqComponent As MorphoAcquisitionComponent = Nothing
    Private CurrentComponentType As DeviceType = DeviceType.NO_DEVICE
    Private CurrentDeviceLayoutConfig As DeviceLayoutConfig = Nothing

#Region "Static members and methods"
    Private Shared ReadOnly DeviceLayoutConfigMap As Dictionary(Of DeviceType, DeviceLayoutConfig) = New Dictionary(Of DeviceType, DeviceLayoutConfig)()

    Shared Sub New()
        ' Create one device layout config for each known device type
        DeviceLayoutConfigMap(DeviceType.ACTIVE_MACI) = New DeviceLayoutConfig(DeviceType.ACTIVE_MACI)
        DeviceLayoutConfigMap(DeviceType.MORPHOSMART) = New DeviceLayoutConfig(DeviceType.MORPHOSMART)
        DeviceLayoutConfigMap(DeviceType.MORPHOKIT) = New DeviceLayoutConfig(DeviceType.MORPHOKIT)
        DeviceLayoutConfigMap(DeviceType.MORPHOKIT_FVP) = New DeviceLayoutConfig(DeviceType.MORPHOKIT_FVP)
        DeviceLayoutConfigMap(DeviceType.DUMMYDEVICE) = New DeviceLayoutConfig(DeviceType.DUMMYDEVICE)
    End Sub
#End Region
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitDialog()
        Try
            comboBoxCoderAlgo.SelectedItem = CurrentDeviceLayoutConfig.CoderAlgorithms(GenericAcqComponent.CoderAlgorithm)
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            checkBoxJuvenile.Checked = GenericAcqComponent.JuvenileMode
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            checkBoxRetry.Checked = GenericAcqComponent.RetryAcquisition
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            checkBoxAccept.Checked = GenericAcqComponent.AcceptBadQualityEnrollment
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            textBoxLiveQualityThreshold.Text = GenericAcqComponent.LiveQualityThreshold.ToString()
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            If CurrentDeviceLayoutConfig.FPTemplateFormats.Contains(GenericAcqComponent.TemplateFormat) Then
                comboBoxFPFormat.SelectedItem = CurrentDeviceLayoutConfig.FPTemplateFormats(GenericAcqComponent.TemplateFormat)

                If CurrentDeviceLayoutConfig.FVPTemplatesSupported Then comboBoxFVPFormat.SelectedItem = CurrentDeviceLayoutConfig.FVPTemplateFormats(TemplateFormat.PK_FVP)
            Else
                comboBoxFPFormat.SelectedItem = DeviceLayoutConfig.NoneItemString

                If CurrentDeviceLayoutConfig.FVPTemplatesSupported AndAlso CurrentDeviceLayoutConfig.FVPTemplateFormats.Contains(GenericAcqComponent.TemplateFormat) Then
                    comboBoxFVPFormat.SelectedItem = CurrentDeviceLayoutConfig.FVPTemplateFormats(GenericAcqComponent.TemplateFormat)
                Else
                    comboBoxFVPFormat.SelectedItem = DeviceLayoutConfig.NoneItemString
                End If
            End If
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            textBoxTimeout.Text = GenericAcqComponent.Timeout.ToString()
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        Catch __unusedException3__ As Exception
            textBoxTimeout.Text = "15"
        End Try

        Try
            comboBoxSecurityLevel.SelectedItem = CurrentDeviceLayoutConfig.SecurityLevels(GenericAcqComponent.ExtSecurityLevel)
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            comboBoxAcquisitionModeStrategy.SelectedItem = CurrentDeviceLayoutConfig.AcquisitionModeStrategies(GenericAcqComponent.AcquisitionModeStrategy)
        Catch
        End Try
    End Sub

    Private Sub SetDropDownAutoWidth(i_x_ComboBox As ComboBox)
        Dim l_x_Label As Label = New Label()
        Dim l_i_LabelWidth = 0
        Dim l_i_MaxWidth = 0

        For Each l_x_Item In i_x_ComboBox.Items
            l_x_Label.Text = l_x_Item.ToString() & "      "
            l_i_LabelWidth = l_x_Label.PreferredWidth

            If l_i_LabelWidth > l_i_MaxWidth Then l_i_MaxWidth = l_i_LabelWidth
        Next

        l_x_Label.Dispose()
        i_x_ComboBox.DropDownWidth = l_i_MaxWidth
    End Sub

    Private Sub buttonEnroll_Click(sender As Object, e As EventArgs)
        Try

            'Init Acquisition Component
            InitAcquisition(GenericAcqComponent)

            'verify the checkbox of consolidation
            Try
                GenericAcqComponent.Consolidation = checkBoxConsolidate.Checked
            Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
            Catch __unusedNullReferenceException2__ As NullReferenceException
            End Try

            'Run Acquisition
            Dim result As EnrollmentResult = GenericAcqComponent.RunEnroll()

            If result Is Nothing Then Return

            If result.Status <> ErrorCodes.IED_NO_ERROR AndAlso result.Status <> ErrorCodes.WARNING_BAD_QUALITY_ACCEPTED Then Return
            Dim info As String = "Quality Score: " & result.TemplateQuality.ToString() & "." & Environment.NewLine
            If CurrentDeviceLayoutConfig.SecurityLevelSupported Then
                Dim str = If(result.IsAdvancedSecurityLevelsCompatible, "Yes", "No")
                info = info & "Advanced Security Level Compatible: " & str & "."
            End If
            MessageBox.Show(info, "Acquisition info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result.ImageList IsNot Nothing AndAlso checkBoxSaveBitmap.Checked Then
                Dim index = 0
                If checkBoxConsolidate.Checked Then index = result.BestImageIndex - 1

                SaveFingerPrint(TryCast(result.ImageList(index).Image, Byte()), result.ImageList(index).Width, result.ImageList(index).Height)
            End If

            If checkBoxSaveTemplate.Checked Then
                SaveTemplate(result.Template, result.TemplateFormat)
                SaveTemplate(result.AdditionalFPTemplate, result.AdditionalFPTemplateFormat)
            End If
        Catch exc As Exception
            Call MessageBox.Show(exc.Message, exc.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub buttonVerify_Click(sender As Object, e As EventArgs)
        Try
            'Select File
            Dim dlg As OpenFileDialog = New OpenFileDialog()

            dlg.Multiselect = False
            dlg.Title = "Select reference template"

            Dim l_x_TemplateFormatFilterMap As Dictionary(Of TemplateFormat, String) = New Dictionary(Of TemplateFormat, String)()

            l_x_TemplateFormatFilterMap(TemplateFormat.CFV) = "IDEMIA CFV Fingerprint Template (*.cfv)|*.cfv"
            l_x_TemplateFormatFilterMap(TemplateFormat.PKMAT) = "IDEMIA PkMat Fingerprint Template (*.pkmat)|*.pkmat"
            l_x_TemplateFormatFilterMap(TemplateFormat.PKCOMPV2) = "IDEMIA PkComp V2 Fingerprint Template (*.pkc)|*.pkc"
            l_x_TemplateFormatFilterMap(TemplateFormat.PKLITE) = "IDEMIA PkLite Fingerprint Template (*.pklite)|*.pklite"
            l_x_TemplateFormatFilterMap(TemplateFormat.PK_FVP) = "IDEMIA PkFVP Finger Vein/Fingerprint Template (*.fvp)|*.fvp"
            l_x_TemplateFormatFilterMap(TemplateFormat.ANSI_378) = "ANSI INCITS 378-2004 Finger Minutiae Record (*.ansi-fmr)|*.ansi-fmr"
            l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_FMR) = "ISO/IEC 19794-2:2005 Finger Minutiae Record (*.iso-fmr)|*.iso-fmr"
            l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_Card_Format_Normal_Size) = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Normal Size (*.iso-fmc-ns)|*.iso-fmc-ns"
            l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_Card_Format_Compact_Size) = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Compact Size (*.iso-fmc-cs)|*.iso-fmc-cs"
            l_x_TemplateFormatFilterMap(TemplateFormat.PKMAT_NORM) = "IDEMIA PkMat Norm Fingerprint Template (*.pkmn)|*.pkmn"
            l_x_TemplateFormatFilterMap(TemplateFormat.PKCOMPV2_NORM) = "IDEMIA PkComp V2 Norm Fingerprint Template (*.pkcn)|*.pkcn"


            Dim l_x_FilterTemplates As AssociativeTuple(Of Integer, TemplateFormat) = New AssociativeTuple(Of Integer, TemplateFormat)()
            Dim l_x_Filter = String.Empty
            Dim l_i_FilterIndex = -1
            Dim l_i_FilterCount = 1

            For Each l_x_TemplateFormat As TemplateFormat In CurrentDeviceLayoutConfig.VerifyTemplateFormats.Seconds
                l_x_FilterTemplates(l_i_FilterCount) = l_x_TemplateFormat
                l_x_Filter += l_x_TemplateFormatFilterMap(l_x_TemplateFormat) & "|"

                If l_x_TemplateFormat = CurrentDeviceLayoutConfig.FPTemplateFormats(comboBoxFPFormat.SelectedItem.ToString()) OrElse (CurrentDeviceLayoutConfig.FVPTemplatesSupported AndAlso (l_x_TemplateFormat = CurrentDeviceLayoutConfig.FVPTemplateFormats(comboBoxFVPFormat.SelectedItem.ToString()))) Then l_i_FilterIndex = l_i_FilterCount

                l_i_FilterCount += 1
            Next

            If CurrentDeviceLayoutConfig.FVPTemplatesSupported Then
                l_x_FilterTemplates(l_i_FilterCount) = CurrentDeviceLayoutConfig.FVPTemplateFormats(CurrentDeviceLayoutConfig.FVPTemplateDefaultValue)

                If l_i_FilterIndex = -1 Then l_i_FilterIndex = l_x_FilterTemplates(CurrentDeviceLayoutConfig.FVPTemplateFormats(CurrentDeviceLayoutConfig.FVPTemplateDefaultValue))
            Else
                l_x_FilterTemplates(l_i_FilterCount) = CurrentDeviceLayoutConfig.FPTemplateFormats(CurrentDeviceLayoutConfig.FPTemplateDefaultValue)

                If l_i_FilterIndex = -1 Then l_i_FilterIndex = l_x_FilterTemplates(CurrentDeviceLayoutConfig.FPTemplateFormats(CurrentDeviceLayoutConfig.FPTemplateDefaultValue))
            End If

            l_x_Filter += "All Files (*.*)|*.*"

            dlg.Filter = l_x_Filter
            dlg.FilterIndex = l_i_FilterIndex

            If dlg.ShowDialog() <> DialogResult.OK Then
                'Cancel by User
                Return
            End If

            'Open Template
            Dim fs As FileStream = New FileStream(dlg.FileName, FileMode.Open, FileAccess.Read)
            Dim reference_template = New Byte(CInt(fs.Length) - 1) {}
            fs.Read(TryCast(reference_template, Byte()), 0, fs.Length)
            fs.Close()

            'Init Acquisition Component
            InitAcquisition(GenericAcqComponent)

            ' Retrieve the template format selected by user for the reference template
            Dim l_e_ReferenceTemplateFormat As TemplateFormat = l_x_FilterTemplates(dlg.FilterIndex)

            ' Backup the previous template format value
            Dim l_e_PreviousTemplateFormat = GenericAcqComponent.TemplateFormat

            ' Set MorphoAcquisition template format to the reference template format
            GenericAcqComponent.TemplateFormat = l_e_ReferenceTemplateFormat

            'Run Acquisition
            Dim result = GenericAcqComponent.RunCaptureVerify(reference_template)

            ' Restore MorphoAcquisition previous template format
            GenericAcqComponent.TemplateFormat = l_e_PreviousTemplateFormat

            If result.Status <> ErrorCodes.IED_NO_ERROR AndAlso result.Status <> ErrorCodes.IED_ERR_NO_HIT Then
                ' Error happened (matching not done)
                MessageBox.Show(String.Format("Verification failed with error {0}.", result.Status), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf result.Status = ErrorCodes.IED_ERR_NO_HIT Then
                ' Sensor returned NO_HIT
                MessageBox.Show("Authentication failed.", "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf CurrentComponentType = DeviceType.ACTIVE_MACI Then
                ' MorphoAccess does not indicate the matching score so it is not pertinent to check it
                MessageBox.Show("Authentication succeeded.", "Authentication succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf result.AuthenticationScore >= Convert.ToInt16(textBoxAuthent.Text) Then
                ' Other wise, we check the matching score
                MessageBox.Show(String.Format("Authentication succeeded, score : {0}", result.AuthenticationScore), "Authentication succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' This should never happen
                MessageBox.Show(String.Format("Authentication failed, score : {0}", result.AuthenticationScore), "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch exc As Exception
            Call MessageBox.Show(exc.Message, exc.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitAcquisition(ByRef AcqComponent As MorphoAcquisitionComponent)
        ' For Active_MACI, device name are: "TCP;IP_Address=<value>;Port=<value>"
        If CurrentComponentType = DeviceType.ACTIVE_MACI Then
            AcqComponent.DeviceName = "TCP;IP_Address=" & textBoxIP.AddressText & ";Port=" & textBoxPort.Text & ";Application=APPLICATION_" & comboBoxGen.SelectedItem.ToString()
        Else
            If comboBoxDevice.Items.Count > 0 Then
                AcqComponent.DeviceName = comboBoxDevice.SelectedItem.ToString()
            Else
                Throw New Exception("No device name was assigned.")
            End If
        End If

        Try
            AcqComponent.CoderAlgorithm = CurrentDeviceLayoutConfig.CoderAlgorithms(comboBoxCoderAlgo.SelectedItem.ToString())
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            If comboBoxFPFormat.SelectedItem.ToString() IsNot DeviceLayoutConfig.NoneItemString Then
                AcqComponent.TemplateFormat = CurrentDeviceLayoutConfig.FPTemplateFormats(comboBoxFPFormat.SelectedItem.ToString())
            ElseIf comboBoxFVPFormat.Enabled AndAlso (comboBoxFVPFormat.SelectedItem.ToString() IsNot DeviceLayoutConfig.NoneItemString) Then
                AcqComponent.TemplateFormat = CurrentDeviceLayoutConfig.FVPTemplateFormats(comboBoxFVPFormat.SelectedItem.ToString())
            End If
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.JuvenileMode = checkBoxJuvenile.Checked
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.LiveQualityThreshold = Integer.Parse(textBoxLiveQualityThreshold.Text)
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.RetryAcquisition = checkBoxRetry.Checked
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.AcceptBadQualityEnrollment = checkBoxAccept.Checked
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.ShowLiveQualityBar = checkBoxShowLiveQualityBar.Checked
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.ShowLiveQualityThreshold = checkBoxShowLiveQualityThreshold.Checked
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.Timeout = UShort.Parse(textBoxTimeout.Text)
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.TimeoutQualityCoder = Convert.ToInt32(textBoxShowQualityDuration.Text)
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.ExtSecurityLevel = CurrentDeviceLayoutConfig.SecurityLevels(comboBoxSecurityLevel.SelectedItem.ToString())
        Catch __unusedMethodNotImplementedException1__ As MethodNotImplementedException
        Catch __unusedNullReferenceException2__ As NullReferenceException
        End Try

        Try
            AcqComponent.AcquisitionModeStrategy = CurrentDeviceLayoutConfig.AcquisitionModeStrategies(comboBoxAcquisitionModeStrategy.SelectedItem.ToString())
        Catch
        End Try

        GenericAcqComponent.LiveImage = checkBoxLiveImage.Checked

        If radioButtonCultureFr.Checked Then
            AcqComponent.SetCulture("fr-FR")
        ElseIf radioButtonCulturePt.Checked Then
            AcqComponent.SetCulture("pt-PT")
        ElseIf radioButtonCultureEs.Checked Then
            AcqComponent.SetCulture("es-ES")
        ElseIf radioButtonCultureEn.Checked Then
            AcqComponent.SetCulture("en-US")
        ElseIf radioButtonCultureAr.Checked Then
            AcqComponent.SetCulture("ar-SA")
        ElseIf radioButtonCultureIt.Checked Then
            AcqComponent.SetCulture("it-IT")
        ElseIf radioButtonCultureDe.Checked Then
            AcqComponent.SetCulture("de-DE")
        ElseIf radioButtonCultureDefault.Checked Then
            AcqComponent.SetCulture("en-US")
        End If
    End Sub

    Private Sub buttonRefreshDevice_Click(sender As Object, e As EventArgs)
        'Get Serial Numbers
        comboBoxDevice.Items.Clear()
        Dim DeviceList As String() = GenericAcqComponent.GetConnectedDevices()

        If DeviceList IsNot Nothing Then
            For i = 0 To DeviceList.Length - 1
                comboBoxDevice.Items.Add(DeviceList(i))
            Next

            SetDropDownAutoWidth(comboBoxDevice)
        End If

        'Select First
        If comboBoxDevice.Items.Count > 0 Then comboBoxDevice.SelectedIndex = 0
    End Sub

    Private Sub SaveFingerPrint(picture As Byte(), width As Integer, height As Integer)
        Dim dlg As SaveFileDialog = New SaveFileDialog()
        dlg.AddExtension = True

        dlg.FileName = "fingerprint"
        dlg.Title = "Save picture"
        dlg.DefaultExt = "png"
        dlg.Filter = "PNG Image (*.png)|*.png|All Files (*.*)|*.*"
        If dlg.ShowDialog() = DialogResult.OK Then
            CreateGreyscaleBitmap(picture, width, height).Save(dlg.FileName, ImageFormat.Png)
        End If
    End Sub

    Private Sub SaveTemplate(template As Byte(), format As TemplateFormat)
        If template IsNot Nothing Then
            If format = TemplateFormat.PK_FVP Then
                SaveFVPTemplate(template, format)
            Else
                SaveFPTemplate(template, format)
            End If
        End If
    End Sub

    Private Sub SaveFPTemplate(template As Byte(), format As TemplateFormat)
        If comboBoxFPFormat.SelectedItem.ToString() IsNot DeviceLayoutConfig.NoneItemString Then
            Dim dlg As SaveFileDialog = New SaveFileDialog()
            dlg.AddExtension = False

            dlg.FileName = "fingerprint"
            dlg.Title = "Save fingerprint template"
            dlg.AddExtension = True

            Dim l_s_Filter As String

            Select Case format
                Case TemplateFormat.CFV
                    l_s_Filter = "IDEMIA CFV Fingerprint Template (*.cfv)|*.cfv|"
                    dlg.DefaultExt = "cfv"

                Case TemplateFormat.PKMAT
                    l_s_Filter = "IDEMIA PkMat Fingerprint Template (*.pkmat)|*.pkmat|"
                    dlg.DefaultExt = "pkmat"

                Case TemplateFormat.PKCOMPV2
                    l_s_Filter = "IDEMIA PkComp V2 Fingerprint Template (*.pkc)|*.pkc|"
                    dlg.DefaultExt = "pkc"

                Case TemplateFormat.PKLITE
                    l_s_Filter = "IDEMIA PkLite Fingerprint Template (*.pklite)|*.pklite|"
                    dlg.DefaultExt = "pklite"

                Case TemplateFormat.ANSI_378
                    l_s_Filter = "ANSI INCITS 378-2004 Finger Minutiae Record (*.ansi-fmr)|*.ansi-fmr|"
                    dlg.DefaultExt = "ansi-fmr"

                Case TemplateFormat.ISO_19794_2_FMR
                    l_s_Filter = "ISO/IEC 19794-2:2005 Finger Minutiae Record (*.iso-fmr)|*.iso-fmr|"
                    dlg.DefaultExt = "iso-fmr"

                Case TemplateFormat.ISO_19794_2_Card_Format_Normal_Size
                    l_s_Filter = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Normal Size (*.iso-fmc-ns)|*.iso-fmc-ns|"
                    dlg.DefaultExt = "iso-fmc-ns"

                Case TemplateFormat.ISO_19794_2_Card_Format_Compact_Size
                    l_s_Filter = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Compact Size (*.iso-fmc-cs)|*.iso-fmc-cs|"
                    dlg.DefaultExt = "iso-fmc-cs"

                Case TemplateFormat.PKMAT_NORM
                    l_s_Filter = "IDEMIA PkMat Norm Fingerprint Template (*.pkmn)|*.pkmn|"
                    dlg.DefaultExt = "pkmn"

                Case TemplateFormat.PKCOMPV2_NORM
                    l_s_Filter = "IDEMIA PkComp V2 Norm Fingerprint Template (*.pkcn)|*.pkcn|"
                    dlg.DefaultExt = "pkcn"
                Case Else
                    l_s_Filter = String.Empty
            End Select

            dlg.Filter = l_s_Filter & "All Files (*.*)|*.*"

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim fs As FileStream = New FileStream(dlg.FileName, FileMode.Create, FileAccess.Write)
                fs.Write(template, 0, template.Length)
                fs.Close()
            End If
        End If
    End Sub

    Private Sub SaveFVPTemplate(template As Byte(), format As TemplateFormat)
        If comboBoxFVPFormat.SelectedItem.ToString() IsNot DeviceLayoutConfig.NoneItemString Then
            Dim dlg As SaveFileDialog = New SaveFileDialog()
            dlg.AddExtension = False

            dlg.FileName = "fvp_template"
            dlg.Title = "Save finger vein/fingerprint template"
            dlg.AddExtension = True

            Dim l_s_Filter As String

            Select Case format
                Case TemplateFormat.PK_FVP
                    l_s_Filter = "IDEMIA PK_FVP Finger Vein/Fingerprint Template (*.fvp)|*.fvp|"
                    dlg.DefaultExt = "fvp"
                Case Else
                    l_s_Filter = String.Empty
            End Select

            dlg.Filter = l_s_Filter & "All Files (*.*)|*.*"

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim fs As FileStream = New FileStream(dlg.FileName, FileMode.Create, FileAccess.Write)
                fs.Write(template, 0, template.Length)
                fs.Close()
            End If
        End If
    End Sub

    Private Function CreateGreyscaleBitmap(buffer As Byte(), width As Integer, height As Integer) As Bitmap
        Dim bmp As Bitmap = New Bitmap(width, height, PixelFormat.Format8bppIndexed)
        ' copy the acquire image data to our bitmap
        ' this works because the width of all MSO images is a multiple of 4
        Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)
        Marshal.Copy(buffer, 0, bmpData.Scan0, width * height)
        bmp.UnlockBits(bmpData)

        ' set up a greyscale palette
        Dim pal = bmp.Palette
        For i = 0 To 255
            pal.Entries(i) = Color.FromArgb(i, i, i)
        Next
        bmp.Palette = pal

        Return bmp
    End Function

    Private Sub GenericAcquisitionComponent_Shown(sender As Object, e As EventArgs)
    End Sub

    Private Sub comboBoxCoderAlgo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If CurrentDeviceLayoutConfig.CoderAlgorithms(comboBoxCoderAlgo.SelectedItem.ToString()) = CoderAlgorithm.V9 Then
            checkBoxConsolidate.Checked = False
            checkBoxConsolidate.Enabled = False
        Else
            If Not checkBoxConsolidate.Enabled Then checkBoxConsolidate.Checked = CurrentDeviceLayoutConfig.ConsolidateDefaultValue

            checkBoxConsolidate.Enabled = CurrentDeviceLayoutConfig.ConsolidateSupported
        End If
    End Sub

    Private Sub buttonCreateObject_Click(sender As Object, e As EventArgs)
        If ComponentTypes.SelectedItem Is Nothing Then
            MessageBox.Show("No component was selected." & Microsoft.VisualBasic.Constants.vbLf & "Please choose a component from the list.", "Sample generic acquisition component", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim l_x_DeviceName As String = ComponentTypes.SelectedItem.ToString()

            If [Enum].IsDefined(GetType(DeviceType), l_x_DeviceName) Then
                CurrentComponentType = CType([Enum].Parse(GetType(DeviceType), l_x_DeviceName, True), DeviceType)
            Else
                CurrentComponentType = DeviceType.NO_DEVICE
            End If

            GenericAcqComponent = New MorphoAcquisitionComponent(CurrentComponentType)
            CurrentDeviceLayoutConfig = DeviceLayoutConfigMap(CurrentComponentType)

            tabControlOptions.Enabled = True
            buttonEnroll.Enabled = True
            buttonVerify.Enabled = True
            buttonVerifyMatch.Enabled = True

            buttonRefreshDevice_Click(Me, EventArgs.Empty)

            groupBoxMorphoAccess.Enabled = CurrentDeviceLayoutConfig.Type = DeviceType.ACTIVE_MACI
            groupBoxMorphoSmart.Enabled = CurrentDeviceLayoutConfig.Type <> DeviceType.ACTIVE_MACI

            comboBoxCoderAlgo.Enabled = True
            comboBoxFPFormat.Enabled = True
            comboBoxFVPFormat.Enabled = True
            checkBoxConsolidate.Enabled = True
            comboBoxSecurityLevel.Enabled = True
            comboBoxAcquisitionModeStrategy.Enabled = True
            checkBoxShowLiveQualityThreshold.Enabled = True

            comboBoxCoderAlgo.Items.Clear()
            comboBoxFPFormat.Items.Clear()
            comboBoxFVPFormat.Items.Clear()
            comboBoxSecurityLevel.Items.Clear()
            comboBoxAcquisitionModeStrategy.Items.Clear()

            comboBoxCoderAlgo.Items.AddRange(CurrentDeviceLayoutConfig.CoderAlgorithms.Firsts)
            comboBoxFPFormat.Items.AddRange(CurrentDeviceLayoutConfig.FPTemplateFormats.Firsts)
            comboBoxFVPFormat.Items.AddRange(CurrentDeviceLayoutConfig.FVPTemplateFormats.Firsts)
            comboBoxSecurityLevel.Items.AddRange(CurrentDeviceLayoutConfig.SecurityLevels.Firsts)
            comboBoxAcquisitionModeStrategy.Items.AddRange(CurrentDeviceLayoutConfig.AcquisitionModeStrategies.Firsts)

            SetDropDownAutoWidth(comboBoxCoderAlgo)
            SetDropDownAutoWidth(comboBoxFPFormat)
            SetDropDownAutoWidth(comboBoxFVPFormat)
            SetDropDownAutoWidth(comboBoxSecurityLevel)
            SetDropDownAutoWidth(comboBoxAcquisitionModeStrategy)

            comboBoxCoderAlgo.SelectedItem = CurrentDeviceLayoutConfig.CoderAlgorithmDefaultValue
            comboBoxFPFormat.SelectedItem = CurrentDeviceLayoutConfig.FPTemplateDefaultValue
            comboBoxFVPFormat.SelectedItem = CurrentDeviceLayoutConfig.FVPTemplateDefaultValue
            checkBoxConsolidate.Checked = CurrentDeviceLayoutConfig.ConsolidateDefaultValue
            comboBoxSecurityLevel.SelectedItem = CurrentDeviceLayoutConfig.SecurityLevelDefaultValue
            comboBoxAcquisitionModeStrategy.SelectedItem = CurrentDeviceLayoutConfig.AcquisitionModeStrategyDefaultValue
            checkBoxShowLiveQualityThreshold.Checked = CurrentDeviceLayoutConfig.ShowLiveQualityThresholdDefaultValue

            comboBoxFVPFormat.Enabled = CurrentDeviceLayoutConfig.FVPTemplatesSupported
            checkBoxConsolidate.Enabled = CurrentDeviceLayoutConfig.ConsolidateSupported
            comboBoxSecurityLevel.Enabled = CurrentDeviceLayoutConfig.SecurityLevelSupported
            comboBoxAcquisitionModeStrategy.Enabled = CurrentDeviceLayoutConfig.AcquisitionModeStrategySupported
            checkBoxShowLiveQualityThreshold.Enabled = CurrentDeviceLayoutConfig.ShowLiveQualityThresholdSupported

            InitDialog()
        Catch exc As Exception
            tabControlOptions.Enabled = False
            buttonEnroll.Enabled = False
            buttonVerify.Enabled = False
            buttonVerifyMatch.Enabled = False
            comboBoxSecurityLevel.Enabled = False
            comboBoxAcquisitionModeStrategy.Enabled = False
            groupBoxMorphoAccess.Enabled = False
            groupBoxMorphoSmart.Enabled = False
            comboBoxFVPFormat.Enabled = False
            checkBoxShowLiveQualityThreshold.Enabled = True
            checkBoxConsolidate.Enabled = True

            Call MessageBox.Show(exc.Message, exc.GetType().ToString())
        End Try
    End Sub

    Private Sub GenericAcquisitionComponent_Load(sender As Object, e As EventArgs)
        tabControlOptions.Enabled = False
        buttonEnroll.Enabled = False
        buttonVerify.Enabled = False
        buttonVerifyMatch.Enabled = False

        GenericAcqComponent = New MorphoAcquisitionComponent()
        Dim availableTypes As DeviceType() = GenericAcqComponent.CheckAvailableComponents()

        If availableTypes Is Nothing OrElse availableTypes.Length = 0 Then ComponentTypes.Items.Add(DeviceType.NO_DEVICE)

        For Each item In availableTypes
            ComponentTypes.Items.Add(item)
        Next

        SetDropDownAutoWidth(ComponentTypes)

        GenericAcqComponent = Nothing

        For Each item As FingerEventStatus In [Enum].GetValues(GetType(FingerEventStatus))
            comboBoxFingerPosition.Items.Add(item.ToString())
        Next

        SetDropDownAutoWidth(comboBoxFingerPosition)
        comboBoxFingerPosition.SelectedIndex = 0
    End Sub

    Private Sub buttonSetImagePath_Click(sender As Object, e As EventArgs)
        'Select File
        Dim dlg As OpenFileDialog = New OpenFileDialog()
        dlg.Multiselect = False
        dlg.Title = "Select customized image for " & comboBoxFingerPosition.SelectedItem.ToString() & " status"

        Dim l_x_Filter = "All Files (*.*)|*.*"
        l_x_Filter += "|All Image types (*.bmp, *.gif, *.jpg, *.jpeg, *.jpe, *.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.jpe;*.png"
        l_x_Filter += "|Windows BMP Image (*.bmp)|*.bmp"
        l_x_Filter += "|GIF Image (*.gif)|*.gif"
        l_x_Filter += "|JPEG Image (*.jpg, *.jpeg, *.jpe)|*.jpg;*.jpeg;*.jpe"
        l_x_Filter += "|PNG Image (*.png)|*.png"

        dlg.Filter = l_x_Filter
        dlg.FilterIndex = 2

        If dlg.ShowDialog() <> DialogResult.OK Then
            'Cancel by User
            Return
        End If

        GenericAcqComponent.SetImagePath(comboBoxFingerPosition.SelectedIndex, dlg.FileName)
    End Sub

    Private Sub textBoxLiveQualityThreshold_Leave(sender As Object, e As EventArgs)
        Dim l_i_LiveQualityThreshold = 0

        If String.IsNullOrEmpty(textBoxLiveQualityThreshold.Text) OrElse Not Integer.TryParse(textBoxLiveQualityThreshold.Text, l_i_LiveQualityThreshold) OrElse l_i_LiveQualityThreshold < 0 OrElse l_i_LiveQualityThreshold > &H64 Then
            textBoxLiveQualityThreshold.BackColor = Color.Red
            textBoxLiveQualityThreshold.Focus()
            MessageBox.Show("Invalid value")
        Else
            textBoxLiveQualityThreshold.BackColor = Color.White
        End If
    End Sub

    Private Sub textBoxTimeout_Leave(sender As Object, e As EventArgs)
        Dim l_i_Timeout = 0

        If String.IsNullOrEmpty(textBoxTimeout.Text) OrElse Not Integer.TryParse(textBoxTimeout.Text, l_i_Timeout) OrElse l_i_Timeout < 0 OrElse l_i_Timeout > &HFFFF Then
            textBoxTimeout.BackColor = Color.Red
            textBoxTimeout.Focus()
            MessageBox.Show("Invalid value")
        Else
            textBoxTimeout.BackColor = Color.White
        End If
    End Sub

    Private Sub textBoxShowQualityDuration_Leave(sender As Object, e As EventArgs)
        Dim l_i_ShowQualityDuration = 0

        If String.IsNullOrEmpty(textBoxShowQualityDuration.Text) OrElse Not Integer.TryParse(textBoxShowQualityDuration.Text, l_i_ShowQualityDuration) OrElse l_i_ShowQualityDuration < 0 Then
            textBoxShowQualityDuration.BackColor = Color.Red
            textBoxShowQualityDuration.Focus()
            MessageBox.Show("Invalid value")
        Else
            textBoxShowQualityDuration.BackColor = Color.White
        End If
    End Sub

    Private Function selectTemplates(title As String, referenceTemplate As Boolean) As List(Of Object)
        'Select File
        Dim dlg As OpenFileDialog = New OpenFileDialog()

        'if user wants to select the reference template
        'the dialog will not offer the multiselect mode, 
        'the multiselect mode will be enabled only for 
        'matching templates.
        If Not referenceTemplate Then
            dlg.Multiselect = True
        End If

        dlg.Title = title

        Dim l_x_TemplateFormatFilterMap As Dictionary(Of TemplateFormat, String) = New Dictionary(Of TemplateFormat, String)()

        l_x_TemplateFormatFilterMap(TemplateFormat.CFV) = "IDEMIA CFV Fingerprint Template (*.cfv)|*.cfv"
        l_x_TemplateFormatFilterMap(TemplateFormat.PKMAT) = "IDEMIA PkMat Fingerprint Template (*.pkmat)|*.pkmat"
        l_x_TemplateFormatFilterMap(TemplateFormat.PKCOMPV2) = "IDEMIA PkComp V2 Fingerprint Template (*.pkc)|*.pkc"
        l_x_TemplateFormatFilterMap(TemplateFormat.PKLITE) = "IDEMIA PkLite Fingerprint Template (*.pklite)|*.pklite"
        l_x_TemplateFormatFilterMap(TemplateFormat.PK_FVP) = "IDEMIA PkFVP Finger Vein/Fingerprint Template (*.fvp)|*.fvp"
        l_x_TemplateFormatFilterMap(TemplateFormat.ANSI_378) = "ANSI INCITS 378-2004 Finger Minutiae Record (*.ansi-fmr)|*.ansi-fmr"
        l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_FMR) = "ISO/IEC 19794-2:2005 Finger Minutiae Record (*.iso-fmr)|*.iso-fmr"
        l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_Card_Format_Normal_Size) = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Normal Size (*.iso-fmc-ns)|*.iso-fmc-ns"
        l_x_TemplateFormatFilterMap(TemplateFormat.ISO_19794_2_Card_Format_Compact_Size) = "ISO/IEC 19794-2:2005 Finger Minutiae Card Format Compact Size (*.iso-fmc-cs)|*.iso-fmc-cs"
        l_x_TemplateFormatFilterMap(TemplateFormat.PKMAT_NORM) = "IDEMIA PkMat Norm Fingerprint Template (*.pkmn)|*.pkmn"
        l_x_TemplateFormatFilterMap(TemplateFormat.PKCOMPV2_NORM) = "IDEMIA PkComp V2 Norm Fingerprint Template (*.pkcn)|*.pkcn"

        Dim l_x_FilterTemplates As AssociativeTuple(Of Integer, TemplateFormat) = New AssociativeTuple(Of Integer, TemplateFormat)()
        Dim l_x_Filter = String.Empty
        Dim l_i_FilterIndex = -1
        Dim l_i_FilterCount = 1

        For Each l_x_TemplateFormat As TemplateFormat In CurrentDeviceLayoutConfig.VerifyTemplateFormats.Seconds
            l_x_FilterTemplates(l_i_FilterCount) = l_x_TemplateFormat
            l_x_Filter += l_x_TemplateFormatFilterMap(l_x_TemplateFormat) & "|"

            If l_x_TemplateFormat = CurrentDeviceLayoutConfig.FPTemplateFormats(comboBoxFPFormat.SelectedItem.ToString()) OrElse (CurrentDeviceLayoutConfig.FVPTemplatesSupported AndAlso (l_x_TemplateFormat = CurrentDeviceLayoutConfig.FVPTemplateFormats(comboBoxFVPFormat.SelectedItem.ToString()))) Then l_i_FilterIndex = l_i_FilterCount

            l_i_FilterCount += 1
        Next

        If CurrentDeviceLayoutConfig.FVPTemplatesSupported Then
            l_x_FilterTemplates(l_i_FilterCount) = CurrentDeviceLayoutConfig.FVPTemplateFormats(CurrentDeviceLayoutConfig.FVPTemplateDefaultValue)

            If l_i_FilterIndex = -1 Then l_i_FilterIndex = l_x_FilterTemplates(CurrentDeviceLayoutConfig.FVPTemplateFormats(CurrentDeviceLayoutConfig.FVPTemplateDefaultValue))
        Else
            l_x_FilterTemplates(l_i_FilterCount) = CurrentDeviceLayoutConfig.FPTemplateFormats(CurrentDeviceLayoutConfig.FPTemplateDefaultValue)

            If l_i_FilterIndex = -1 Then l_i_FilterIndex = l_x_FilterTemplates(CurrentDeviceLayoutConfig.FPTemplateFormats(CurrentDeviceLayoutConfig.FPTemplateDefaultValue))
        End If

        l_x_Filter += "All Files (*.*)|*.*"

        dlg.Filter = l_x_Filter
        dlg.FilterIndex = l_i_FilterIndex

        If dlg.ShowDialog() <> DialogResult.OK Then
            'Canceled by User
            'no extra work to do.
            Return Nothing
        End If

        'Open Template 
        Dim templates As List(Of Object) = New List(Of Object)()
        For Each file In dlg.FileNames
            Dim fs As FileStream = New FileStream(file, FileMode.Open, FileAccess.Read)
            Dim reference_template = New Byte(CInt(fs.Length) - 1) {}
            fs.Read(reference_template, 0, fs.Length)
            templates.Add(reference_template)
            fs.Close()
        Next


        'Setting the template format for either
        'reference or matching templates list
        If referenceTemplate Then
            GenericAcqComponent.TemplateFormat = l_x_FilterTemplates(dlg.FilterIndex)
        Else
            GenericAcqComponent.SetMatchingTemplateListFormat(l_x_FilterTemplates(dlg.FilterIndex))
        End If

        Return templates
    End Function

    Private Sub buttonVerifyMatch_Click(sender As Object, e As EventArgs)
        Try
            Dim reference_template As List(Of Object)
            Dim matching_templates_list As List(Of Object)

            'Init Acquisition Component
            InitAcquisition(GenericAcqComponent)

            reference_template = selectTemplates("Select Reference Template", True)
            If reference_template Is Nothing Then Return

            matching_templates_list = selectTemplates("Select Matching Template(s)", False)
            If matching_templates_list Is Nothing Then Return

            Dim result = GenericAcqComponent.RunVerifyMatch(reference_template(0), matching_templates_list)


            If result.Status <> ErrorCodes.IED_NO_ERROR AndAlso result.Status <> ErrorCodes.IED_ERR_NO_HIT Then
                ' Error happened (matching not done)
                MessageBox.Show(String.Format("Verification failed with error {0}.", result.Status), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf result.Status = ErrorCodes.IED_ERR_NO_HIT Then
                ' Sensor returned NO_HIT
                MessageBox.Show("Authentication failed.", "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf result.AuthenticationScore >= Convert.ToInt16(textBoxAuthent.Text) Then
                ' Other wise, we check the matching score
                MessageBox.Show(String.Format("Authentication succeeded, score : {0}", result.AuthenticationScore), "Authentication succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' This should never happen
                MessageBox.Show(String.Format("Authentication failed, score : {0}", result.AuthenticationScore), "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch exc As Exception
            Call MessageBox.Show(exc.Message, exc.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class