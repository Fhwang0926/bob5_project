Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Threading

Namespace ApiReference
    Class Main

        <DllImport("user32")>
        Public Shared Function FindWindow(lpClassName As [String], lpWindowName As [String]) As IntPtr
        End Function

        Sub Main(args As String())
            Dim hNotepad As IntPtr = FindWindow("Notepad", Nothing)

            If hNotepad <> IntPtr.Zero Then
                Console.WriteLine("메모장이 열려있습니다.")
            Else
                Console.WriteLine("메모장이 없습니다.")
                Process.Start("notepad")
                Thread.Sleep(1000)
                hNotepad = FindWindow("Notepad", Nothing)

                If hNotepad <> IntPtr.Zero Then
                    Console.WriteLine("메모장이 열려있습니다.")
                Else
                    Console.WriteLine("메모장이 없습니다.")
                End If
            End If

            Console.ReadKey(True)
        End Sub
    End Class
End Namespace