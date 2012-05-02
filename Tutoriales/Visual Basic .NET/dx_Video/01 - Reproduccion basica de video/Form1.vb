Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private Video As New dx_lib32.dx_Video_Class ' Instancia del objeto de video de dx_lib32.
	Private clip As Integer ' Guarda el identificador de la pelicula de video.
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Video.Init(Me.Handle.ToInt32)
		clip = Video.VIDEO_Load(My.Application.Info.DirectoryPath & "\clock.avi") ' Carga la pelicula de video en memoria.
		Video.VIDEO_Play(clip, 0, 0, 0, 0)
	End Sub
	
	Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Video.VIDEO_Unload(clip) ' Descarga la pelicula de video de la memoria.
		Video.Terminate() ' Terminamos la ejecucion de la clase de video y liberamos los recursos utilizados.
		'UPGRADE_NOTE: El objeto Video no se puede destruir hasta que no se realice la recolecci�n de los elementos no utilizados. Haga clic aqu� para obtener m�s informaci�n: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Video = Nothing
	End Sub
End Class