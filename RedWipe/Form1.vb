Public Class Form1
    Public RED As RedditSharp.Reddit
    Public USER As RedditSharp.Things.AuthenticatedUser

    Delegate Sub SetTextCallback(obj As Object, [text] As String)

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            'The below code logs the user into Reddit
            If txtPWD.Text = txtPWD2.Text Then
                USER = New RedditSharp.Things.AuthenticatedUser
                USER = RED.LogIn(txtUSER.Text, txtPWD.Text, True)
                'Assuming nothing has fone wrong, enable the rest of the interface.
                txtconsole.Enabled = True
                btnWipe.Enabled = True
                btnStop.Enabled = True
                txtconsole.Enabled = True
                'Display status in the console.
                txtconsole.Text = "Logged in as " & USER.ToString & vbCrLf
                Me.Text = Me.Text & " - [" & RED.User.FullName & "]"
            Else
                txtconsole.Text = "Unable to login, passwords do not match." & vbCrLf
            End If
        Catch ex As Exception
            txtconsole.Text = "Error: " & ex.GetBaseException.Message
            USER = Nothing
        End Try
    End Sub

    Private Sub txtPWD_GotFocus(sender As Object, e As EventArgs) Handles txtPWD.GotFocus
        If txtPWD.Text = "Enter Password" Then
            txtPWD.PasswordChar = "*"
            txtPWD.Text = ""
        End If
    End Sub

    Private Sub txtPWD_LostFocus(sender As Object, e As EventArgs) Handles txtPWD.LostFocus
        If txtPWD.Text = "" Then
            txtPWD.PasswordChar = ""
            txtPWD.Text = "Enter Password"
        End If
    End Sub

    Private Sub txtPWD2_GotFocus(sender As Object, e As EventArgs) Handles txtPWD2.GotFocus
        If txtPWD2.Text = "Re-Enter Password" Then
            txtPWD2.PasswordChar = "*"
            txtPWD2.Text = ""
        End If
    End Sub

    Private Sub txtPWD2_LostFocus(sender As Object, e As EventArgs) Handles txtPWD2.LostFocus
        If txtPWD2.Text = "" Then
            txtPWD2.PasswordChar = ""
            txtPWD2.Text = "Re-Enter Password"
        End If
    End Sub

    Private Sub txtUSER_Click(sender As Object, e As EventArgs) Handles txtUSER.Click
        If txtUSER.Text = "Enter Your Username" Then
            txtUSER.Text = ""
        End If
    End Sub


    Private Sub txtUSER_LostFocus(sender As Object, e As EventArgs) Handles txtUSER.LostFocus
        If txtUSER.Text = "" Then
            txtUSER.Text = "Enter Your Username"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Show Warning
        Dim w As Form
        w = New Form2
        With w
            .ShowDialog()
        End With
        'Center form
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x / 2, y / 2)
        'Declares RED as a new instance of RedditSharp.Reddit
        Cancel = False
        RED = New RedditSharp.Reddit
        RED.RateLimit = RedditSharp.WebAgent.RateLimitMode.Pace
    End Sub

    Private Sub btnWipe_Click(sender As Object, e As EventArgs) Handles btnWipe.Click
        'Debug Code
        'Update CrytoCount
        cryptoCount = 0
        'End Debug Code
        'This prompts the user to confirm that they understand what will happen.
        'If the user selects yes the WipeIT function will run which will start deleting allt the posts and comments.
        Dim result As Boolean
        If MsgBox("Terms and conditions:" & vbCrLf & vbCrLf & "This process will 'Edit' all of your posts and replace them with random data, then delete them.  This process is irreversable!" & vbCrLf & vbCrLf & "Do you accept?", MsgBoxStyle.YesNoCancel, "WARNING!!!") = MsgBoxResult.Yes Then
            Cancel = False
            'Create new WipeIT class
            Dim WI As classWipeEngine
            WI = New classWipeEngine
            With WI
                .mainForm = Me
                .redReddit = RED
                .redUser = USER
            End With
            'Create new thread
            threadWipeIT = New Threading.Thread(AddressOf WI.WipeIT)
            'Run WipeIT
            threadWipeIT.Start()
            'Old Way
            'result = WipeIT(Me, RED, USER)
        Else
            txtconsole.Text = "Current Process Canceled!" & vbCrLf
        End If
    End Sub

    Public Sub SetText(ByVal obj As Object, ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the 
        ' calling thread to the thread ID of the creating thread. 
        ' If these threads are different, it returns true. 
        If obj.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {obj, [text]})
        Else
            obj.Text = [text]
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Cancel = True
    End Sub

    Private Sub txtconsole_TextChanged(sender As Object, e As EventArgs) Handles txtconsole.TextChanged
        'Auto scroll the text box.
        txtconsole.Select(txtconsole.Text.Length, 0)
        txtconsole.ScrollToCaret()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As Form3
        f = New Form3
        f.ShowDialog()
    End Sub
End Class