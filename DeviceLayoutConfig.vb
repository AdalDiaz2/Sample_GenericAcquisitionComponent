Imports Morpho.MorphoAcquisition
Imports System

Friend Class DeviceLayoutConfig
    Public Const NoneItemString As String = "<none>"

#Region "Private Members"
    Private m_e_Type As DeviceType = DeviceType.NO_DEVICE

    Private m_b_FVPTemplatesSupported As Boolean = False
    Private m_b_ConsolidateSupported As Boolean = False
    Private m_b_SecurityLevelSupported As Boolean = False
    Private m_b_AcquisitionModeStrategySupported As Boolean = False
    Private m_b_ShowLiveQualityThresholdSupported As Boolean = False

    Private m_x_CoderAlgorithmDefaultValue As String = String.Empty
    Private m_x_FPTemplateDefaultValue As String = String.Empty
    Private m_x_FVPTemplateDefaultValue As String = String.Empty
    Private m_b_ConsolidateDefaultValue As Boolean = False
    Private m_x_SecurityLevelDefaultValue As String = String.Empty
    Private m_x_AcquisitionModeStrategyDefaultValue As String = String.Empty
    Private m_b_ShowLiveQualityThresholdDefaultValue As Boolean = False

    Private m_x_CoderAlgorithmMap As AssociativeTuple(Of String, CoderAlgorithm) = New AssociativeTuple(Of String, CoderAlgorithm)()
    Private m_x_FPTemplateFormatMap As AssociativeTuple(Of String, TemplateFormat) = New AssociativeTuple(Of String, TemplateFormat)()
    Private m_x_FVPTemplateFormatMap As AssociativeTuple(Of String, TemplateFormat) = New AssociativeTuple(Of String, TemplateFormat)()
    Private m_x_SecurityLevelMap As AssociativeTuple(Of String, ExtendedSecurityLevel) = New AssociativeTuple(Of String, ExtendedSecurityLevel)()
    Private m_x_AcquisitionModeStrategyMap As AssociativeTuple(Of String, AcquisitionModeStrategy) = New AssociativeTuple(Of String, AcquisitionModeStrategy)()
    Private m_x_VerifyTemplateFormatMap As AssociativeTuple(Of String, TemplateFormat) = New AssociativeTuple(Of String, TemplateFormat)()
#End Region

#Region "Public Properties"
    Public ReadOnly Property Type As DeviceType
        Get
            Return m_e_Type
        End Get
    End Property

    Public ReadOnly Property FVPTemplatesSupported As Boolean
        Get
            Return m_b_FVPTemplatesSupported
        End Get
    End Property
    Public ReadOnly Property ConsolidateSupported As Boolean
        Get
            Return m_b_ConsolidateSupported
        End Get
    End Property
    Public ReadOnly Property SecurityLevelSupported As Boolean
        Get
            Return m_b_SecurityLevelSupported
        End Get
    End Property
    Public ReadOnly Property AcquisitionModeStrategySupported As Boolean
        Get
            Return m_b_AcquisitionModeStrategySupported
        End Get
    End Property
    Public ReadOnly Property ShowLiveQualityThresholdSupported As Boolean
        Get
            Return m_b_ShowLiveQualityThresholdSupported
        End Get
    End Property

    Public ReadOnly Property CoderAlgorithmDefaultValue As String
        Get
            Return m_x_CoderAlgorithmDefaultValue
        End Get
    End Property
    Public ReadOnly Property FPTemplateDefaultValue As String
        Get
            Return m_x_FPTemplateDefaultValue
        End Get
    End Property
    Public ReadOnly Property FVPTemplateDefaultValue As String
        Get
            Return m_x_FVPTemplateDefaultValue
        End Get
    End Property
    Public ReadOnly Property ConsolidateDefaultValue As Boolean
        Get
            Return m_b_ConsolidateDefaultValue
        End Get
    End Property
    Public ReadOnly Property SecurityLevelDefaultValue As String
        Get
            Return m_x_SecurityLevelDefaultValue
        End Get
    End Property
    Public ReadOnly Property AcquisitionModeStrategyDefaultValue As String
        Get
            Return m_x_AcquisitionModeStrategyDefaultValue
        End Get
    End Property
    Public ReadOnly Property ShowLiveQualityThresholdDefaultValue As Boolean
        Get
            Return m_b_ShowLiveQualityThresholdDefaultValue
        End Get
    End Property

    Public ReadOnly Property CoderAlgorithms As AssociativeTuple(Of String, CoderAlgorithm)
        Get
            Return m_x_CoderAlgorithmMap
        End Get
    End Property
    Public ReadOnly Property FPTemplateFormats As AssociativeTuple(Of String, TemplateFormat)
        Get
            Return m_x_FPTemplateFormatMap
        End Get
    End Property
    Public ReadOnly Property FVPTemplateFormats As AssociativeTuple(Of String, TemplateFormat)
        Get
            Return m_x_FVPTemplateFormatMap
        End Get
    End Property
    Public ReadOnly Property SecurityLevels As AssociativeTuple(Of String, ExtendedSecurityLevel)
        Get
            Return m_x_SecurityLevelMap
        End Get
    End Property
    Public ReadOnly Property AcquisitionModeStrategies As AssociativeTuple(Of String, AcquisitionModeStrategy)
        Get
            Return m_x_AcquisitionModeStrategyMap
        End Get
    End Property
    Public ReadOnly Property VerifyTemplateFormats As AssociativeTuple(Of String, TemplateFormat)
        Get
            Return m_x_VerifyTemplateFormatMap
        End Get
    End Property
#End Region

    Public Sub New(i_e_Type As DeviceType)
        ' Save the device type
        m_e_Type = i_e_Type

        ' Adding the "None" values for optional template format lists for all device type
        m_x_FPTemplateFormatMap(DeviceLayoutConfig.NoneItemString) = TemplateFormat.PK_FVP
        m_x_FVPTemplateFormatMap(DeviceLayoutConfig.NoneItemString) = TemplateFormat.CFV

        ' Configure the device layout config depending on its type
        Select Case m_e_Type
            Case DeviceType.ACTIVE_MACI
                ' Setup coder algorithm list and default value
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.EmbeddedCoder)
                m_x_CoderAlgorithmDefaultValue = m_x_CoderAlgorithmMap(CoderAlgorithm.EmbeddedCoder)

                ' Setup Fingerprint template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)
                m_x_FPTemplateDefaultValue = m_x_FPTemplateFormatMap(TemplateFormat.PKCOMPV2)

                ' Disable and setup the Finger VP template format list and default value
                m_b_FVPTemplatesSupported = False
                m_x_FVPTemplateDefaultValue = DeviceLayoutConfig.NoneItemString

                ' Enable and setup the consolidate default value
                m_b_ConsolidateSupported = True
                m_b_ConsolidateDefaultValue = True

                ' Disable and setup the security level list and default value
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.STANDARD)
                m_b_SecurityLevelSupported = False
                m_x_SecurityLevelDefaultValue = m_x_SecurityLevelMap(ExtendedSecurityLevel.STANDARD)

                ' Disable and setup the acquisition mode strategy list and default value
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.EXPERT)
                m_b_AcquisitionModeStrategySupported = False
                m_x_AcquisitionModeStrategyDefaultValue = m_x_AcquisitionModeStrategyMap(AcquisitionModeStrategy.EXPERT)

                ' Disable and setup the show live quality threshold default value
                m_b_ShowLiveQualityThresholdSupported = False
                m_b_ShowLiveQualityThresholdDefaultValue = False

                ' Setup the verify template format list
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)

                Exit Select



            Case DeviceType.MORPHOSMART
                ' Setup coder algorithm list and default value
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.EmbeddedCoder)
                m_x_CoderAlgorithmDefaultValue = m_x_CoderAlgorithmMap(CoderAlgorithm.EmbeddedCoder)

                ' Setup Fingerprint template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKCOMPV2_NORM)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKMAT_NORM)
                m_x_FPTemplateDefaultValue = m_x_FPTemplateFormatMap(TemplateFormat.PKMAT)

                ' Enable and setup the Finger VP template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FVPTemplateFormatMap, TemplateFormat.PK_FVP)
                m_b_FVPTemplatesSupported = True
                m_x_FVPTemplateDefaultValue = DeviceLayoutConfig.NoneItemString

                ' Enable and setup the consolidate default value
                m_b_ConsolidateSupported = True
                m_b_ConsolidateDefaultValue = True

                ' Enable and setup the security level list and default value
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.STANDARD)
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.MEDIUM)
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.HIGH)
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.CRITICAL)
                m_b_SecurityLevelSupported = True
                m_x_SecurityLevelDefaultValue = m_x_SecurityLevelMap(ExtendedSecurityLevel.STANDARD)

                ' Disable and setup the acquisition mode strategy list and default value
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.EXPERT)
                m_b_AcquisitionModeStrategySupported = False
                m_x_AcquisitionModeStrategyDefaultValue = m_x_AcquisitionModeStrategyMap(AcquisitionModeStrategy.EXPERT)

                ' Enable and setup the show live quality threshold default value
                m_b_ShowLiveQualityThresholdSupported = True
                m_b_ShowLiveQualityThresholdDefaultValue = False

                ' Setup the verify template format list
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PK_FVP)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKCOMPV2_NORM)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKMAT_NORM)

                Exit Select



            Case DeviceType.MORPHOKIT
                ' Setup coder algorithm list and default value
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.V6)
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.V9)
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.V10)
                m_x_CoderAlgorithmDefaultValue = m_x_CoderAlgorithmMap(CoderAlgorithm.V10)

                ' Setup Fingerprint template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.CFV)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)
                m_x_FPTemplateDefaultValue = m_x_FPTemplateFormatMap(TemplateFormat.CFV)

                ' Disable and setup the Finger VP template format list and default value
                m_b_FVPTemplatesSupported = False
                m_x_FVPTemplateDefaultValue = DeviceLayoutConfig.NoneItemString

                ' Enable and setup the consolidate default value
                m_b_ConsolidateSupported = True
                m_b_ConsolidateDefaultValue = True

                ' Disable and setup the security level list and default value
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.STANDARD)
                m_b_SecurityLevelSupported = False
                m_x_SecurityLevelDefaultValue = m_x_SecurityLevelMap(ExtendedSecurityLevel.STANDARD)

                ' Disable and setup the acquisition mode strategy list and default value
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.EXPERT)
                m_b_AcquisitionModeStrategySupported = False
                m_x_AcquisitionModeStrategyDefaultValue = m_x_AcquisitionModeStrategyMap(AcquisitionModeStrategy.EXPERT)

                ' Enable and setup the show live quality threshold default value
                m_b_ShowLiveQualityThresholdSupported = True
                m_b_ShowLiveQualityThresholdDefaultValue = False

                ' Setup the verify template format list
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.CFV)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)

                Exit Select



            Case DeviceType.MORPHOKIT_FVP
                ' Setup coder algorithm list and default value
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.V6)
                DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, CoderAlgorithm.V10)
                m_x_CoderAlgorithmDefaultValue = m_x_CoderAlgorithmMap(CoderAlgorithm.V10)

                ' Setup Fingerprint template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.CFV)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKMAT)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKCOMPV2)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.PKLITE)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ANSI_378)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_FMR)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Normal_Size)
                DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, TemplateFormat.ISO_19794_2_Card_Format_Compact_Size)
                m_x_FPTemplateDefaultValue = DeviceLayoutConfig.NoneItemString

                ' Enable and setup the Finger VP template format list and default value
                DeviceLayoutConfig.AddTemplateFormat(m_x_FVPTemplateFormatMap, TemplateFormat.PK_FVP)
                m_b_FVPTemplatesSupported = True
                m_x_FVPTemplateDefaultValue = m_x_FVPTemplateFormatMap(TemplateFormat.PK_FVP)

                ' Disable and setup the consolidate default value
                m_b_ConsolidateSupported = False
                m_b_ConsolidateDefaultValue = True

                ' Enable and setup the security level list and default value
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.STANDARD)
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.MEDIUM)
                DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, ExtendedSecurityLevel.HIGH)
                'AddSecurityLevel(ref this.m_x_SecurityLevelMap, ExtendedSecurityLevel.CRITICAL);
                m_b_SecurityLevelSupported = True
                m_x_SecurityLevelDefaultValue = m_x_SecurityLevelMap(ExtendedSecurityLevel.STANDARD)

                ' Enable and setup the acquisition mode strategy list and default value
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.EXPERT)
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.UNIVERSAL_FAST)
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.UNIVERSAL_ACCURATE)
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.FULL_MULTIMODAL)
                DeviceLayoutConfig.AddAcquisitionModeStrategy(m_x_AcquisitionModeStrategyMap, AcquisitionModeStrategy.ANTI_SPOOFING)
                m_b_AcquisitionModeStrategySupported = True
                m_x_AcquisitionModeStrategyDefaultValue = m_x_AcquisitionModeStrategyMap(AcquisitionModeStrategy.EXPERT)

                ' Enable and setup the show live quality threshold default value
                m_b_ShowLiveQualityThresholdSupported = True
                m_b_ShowLiveQualityThresholdDefaultValue = False

                ' Setup the verify template format list
                DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, TemplateFormat.PK_FVP)

                Exit Select



            Case DeviceType.DUMMYDEVICE
                ' Setup coder algorithm list and default value
                For Each l_e_CoderAlgorithm As CoderAlgorithm In [Enum].GetValues(GetType(CoderAlgorithm))
                    DeviceLayoutConfig.AddCoderAlgorithm(m_x_CoderAlgorithmMap, l_e_CoderAlgorithm)
                Next
                m_x_CoderAlgorithmDefaultValue = m_x_CoderAlgorithmMap.Firsts(0)

                ' Setup Fingerprint template format list and default value
                For Each l_e_TemplateFormat As TemplateFormat In [Enum].GetValues(GetType(TemplateFormat))
                    DeviceLayoutConfig.AddTemplateFormat(m_x_FPTemplateFormatMap, l_e_TemplateFormat)
                Next
                m_x_FPTemplateDefaultValue = m_x_FPTemplateFormatMap.Firsts(1)

                ' Enable and setup the Finger VP template format list and default value
                For Each l_e_TemplateFormat As TemplateFormat In [Enum].GetValues(GetType(TemplateFormat))
                    DeviceLayoutConfig.AddTemplateFormat(m_x_FVPTemplateFormatMap, l_e_TemplateFormat)
                Next
                m_b_FVPTemplatesSupported = True
                m_x_FVPTemplateDefaultValue = DeviceLayoutConfig.NoneItemString

                ' Enable and setup the consolidate default value
                m_b_ConsolidateSupported = True
                m_b_ConsolidateDefaultValue = True

                ' Enable and setup the security level list and default value
                For Each l_e_SecurityLevel As ExtendedSecurityLevel In [Enum].GetValues(GetType(ExtendedSecurityLevel))
                    DeviceLayoutConfig.AddSecurityLevel(m_x_SecurityLevelMap, l_e_SecurityLevel)
                Next
                m_b_SecurityLevelSupported = True
                m_x_SecurityLevelDefaultValue = m_x_SecurityLevelMap.Firsts(0)

                ' Enable and setup the show live quality threshold default value
                m_b_ShowLiveQualityThresholdSupported = True
                m_b_ShowLiveQualityThresholdDefaultValue = False

                ' Setup the verify template format list
                For Each l_e_TemplateFormat As TemplateFormat In [Enum].GetValues(GetType(TemplateFormat))
                    DeviceLayoutConfig.AddTemplateFormat(m_x_VerifyTemplateFormatMap, l_e_TemplateFormat)
                Next

                Exit Select
            Case Else
                Throw New InvalidParameterException("Unknown device layout type", ErrorCodes.IED_ERR_INTERNAL)
        End Select
    End Sub

    Private Shared Sub AddCoderAlgorithm(ByRef io_x_CoderAlgorithmMap As AssociativeTuple(Of String, CoderAlgorithm), i_e_CoderAlgorithm As CoderAlgorithm)
        Select Case i_e_CoderAlgorithm
            Case CoderAlgorithm.EmbeddedCoder
                io_x_CoderAlgorithmMap("Device Embedded Coder") = CoderAlgorithm.EmbeddedCoder
            Case CoderAlgorithm.V6
                io_x_CoderAlgorithmMap("Morpho V6 Coder") = CoderAlgorithm.V6
            Case CoderAlgorithm.V9
                io_x_CoderAlgorithmMap("Morpho V9 Coder") = CoderAlgorithm.V9
            Case CoderAlgorithm.V10
                io_x_CoderAlgorithmMap("Morpho V10 Coder") = CoderAlgorithm.V10
            Case Else
                Throw New InvalidParameterException("Unknown coder algorithm value", ErrorCodes.IED_ERR_INTERNAL)
        End Select
    End Sub

    Private Shared Sub AddTemplateFormat(ByRef io_x_TemplateFormatMap As AssociativeTuple(Of String, TemplateFormat), i_e_TemplateFormat As TemplateFormat)
        Select Case i_e_TemplateFormat
            Case TemplateFormat.CFV
                io_x_TemplateFormatMap("Morpho CFV Fingerprint Template") = TemplateFormat.CFV
            Case TemplateFormat.PKMAT
                io_x_TemplateFormatMap("Morpho PkMat Fingerprint Template") = TemplateFormat.PKMAT
            Case TemplateFormat.PKCOMPV2
                io_x_TemplateFormatMap("Morpho PkComp V2 Fingerprint Template") = TemplateFormat.PKCOMPV2
            Case TemplateFormat.PKLITE
                io_x_TemplateFormatMap("Morpho PkLite Fingerprint Template") = TemplateFormat.PKLITE
            Case TemplateFormat.PK_FVP
                io_x_TemplateFormatMap("Morpho PkFVP Finger Vein/Fingerprint Template") = TemplateFormat.PK_FVP
            Case TemplateFormat.ANSI_378
                io_x_TemplateFormatMap("ANSI INCITS 378-2004 Finger Minutiae Record") = TemplateFormat.ANSI_378
            Case TemplateFormat.ISO_19794_2_FMR
                io_x_TemplateFormatMap("ISO/IEC 19794-2:2005 Finger Minutiae Record") = TemplateFormat.ISO_19794_2_FMR
            Case TemplateFormat.ISO_19794_2_Card_Format_Normal_Size
                io_x_TemplateFormatMap("ISO/IEC 19794-2:2005 Finger Minutiae Card Format Normal Size") = TemplateFormat.ISO_19794_2_Card_Format_Normal_Size
            Case TemplateFormat.ISO_19794_2_Card_Format_Compact_Size
                io_x_TemplateFormatMap("ISO/IEC 19794-2:2005 Finger Minutiae Card Format Compact Size") = TemplateFormat.ISO_19794_2_Card_Format_Compact_Size
            Case TemplateFormat.PKMAT_NORM
                io_x_TemplateFormatMap("Morpho PkMat Norm Fingerprint Template") = TemplateFormat.PKMAT_NORM
            Case TemplateFormat.PKCOMPV2_NORM
                io_x_TemplateFormatMap("Morpho PkComp V2 Norm Fingerprint Template") = TemplateFormat.PKCOMPV2_NORM
            Case Else
                Throw New InvalidParameterException("Unknown template format value", ErrorCodes.IED_ERR_INTERNAL)
        End Select
    End Sub

    Private Shared Sub AddSecurityLevel(ByRef io_x_SecurityLevelMap As AssociativeTuple(Of String, ExtendedSecurityLevel), i_e_SecurityLevel As ExtendedSecurityLevel)
        Select Case i_e_SecurityLevel
            Case ExtendedSecurityLevel.STANDARD
                io_x_SecurityLevelMap("Standard") = ExtendedSecurityLevel.STANDARD
            Case ExtendedSecurityLevel.MEDIUM
                io_x_SecurityLevelMap("Medium") = ExtendedSecurityLevel.MEDIUM
            Case ExtendedSecurityLevel.HIGH
                io_x_SecurityLevelMap("High") = ExtendedSecurityLevel.HIGH
            Case ExtendedSecurityLevel.CRITICAL
                io_x_SecurityLevelMap("Critical") = ExtendedSecurityLevel.CRITICAL
            Case Else
                Throw New InvalidParameterException("Unknown security level value", ErrorCodes.IED_ERR_INTERNAL)
        End Select
    End Sub

    Private Shared Sub AddAcquisitionModeStrategy(ByRef io_x_AcquisitionModeStrategyMap As AssociativeTuple(Of String, AcquisitionModeStrategy), i_e_AcquisitionModeStrategy As AcquisitionModeStrategy)
        Select Case i_e_AcquisitionModeStrategy
            Case AcquisitionModeStrategy.EXPERT
                io_x_AcquisitionModeStrategyMap("Expert") = AcquisitionModeStrategy.EXPERT
            Case AcquisitionModeStrategy.UNIVERSAL_FAST
                io_x_AcquisitionModeStrategyMap("Universal (fast)") = AcquisitionModeStrategy.UNIVERSAL_FAST
            Case AcquisitionModeStrategy.UNIVERSAL_ACCURATE
                io_x_AcquisitionModeStrategyMap("Universal (accurate)") = AcquisitionModeStrategy.UNIVERSAL_ACCURATE
            Case AcquisitionModeStrategy.FULL_MULTIMODAL
                io_x_AcquisitionModeStrategyMap("Full multimodal") = AcquisitionModeStrategy.FULL_MULTIMODAL
            Case AcquisitionModeStrategy.ANTI_SPOOFING
                io_x_AcquisitionModeStrategyMap("Anti-spoofing") = AcquisitionModeStrategy.ANTI_SPOOFING
            Case Else
                Throw New InvalidParameterException("Unknown acquisition mode strategy value", ErrorCodes.IED_ERR_INTERNAL)
        End Select
    End Sub
End Class