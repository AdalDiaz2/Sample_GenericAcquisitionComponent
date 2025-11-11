Imports System
Imports System.Windows.Forms

Module Program
    ''' <summary>
    ''' Inicio de Aplicacion
    ''' </summary>
    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Sample_GenericAcquisitionComponent())
    End Sub
End Module
