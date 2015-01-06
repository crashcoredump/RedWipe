Imports System.ComponentModel

Public Class classWipeEngine
    Friend mainForm As Form1
    Friend redReddit As RedditSharp.Reddit
    Friend redUser As RedditSharp.Things.AuthenticatedUser
    Friend startTime As System.DateTime




    Function WipeIT() As Boolean
        'Send message to user, letting them know what is about to happen.
        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Wipe engine loading..." & vbCrLf)
        'Display Counts
        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "User has " & redUser.Posts.Count & " posts, and " & redUser.Comments.Count & " comments." & vbCrLf)
        'Declare variables
        Dim TotalPosts As Int32 = redUser.Posts.Count 'redUser.GetPosts.Count
        Dim TotalComments As Int32 = redUser.Comments.Count 'redUser.GetComments.Count
        Dim x As Int32 ' Posts
        Dim y As Int32 ' Comments
        Dim scrambled As String
        Dim currentpost As String
        Dim currentcomment As String
        Dim post As RedditSharp.Things.Post
        Dim comment As RedditSharp.Things.Comment

        If Cancel = True Then handleCanceled()

        'First we will handle the comments.
        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Erasing " & TotalComments & " comments..." & vbCrLf)
        'Set Current time. This will be used to est. the time remaining.
        startTime = System.DateTime.Now
        '
        For y = (TotalComments - 1) To 0 Step -1
            'Check for if the user canceled the operation
            If Cancel = True Then handleCanceled()
            comment = redReddit.GetMe.GetComments.ElementAt(y)
            'comment = redReddit.User.Comments.ElementAt(y)


            currentcomment = comment.Body.ToString

            scrambled = GenerateRandomText(currentcomment)
            mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & ShrinkText(currentcomment) & "     Changed to-> " & ShrinkText(scrambled) & vbCrLf)
            'Insert Code to edit comment
            comment.EditText(scrambled)

            'Insert Code to delete comment.
            comment.Remove()
            mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Comment: " & y & "     Deleted." & vbCrLf)
            'Show time elapsed
            mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Time of Completion: " & calculateTimeRemaining(startTime, y, (TotalComments + TotalPosts)) & vbCrLf & vbCrLf)
            'Refresf the console so we can see the updates.
            If Cancel = True Then handleCanceled()
        Next

        If Cancel = True Then handleCanceled()

        'Now we will handle the posts.
        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Erasing " & TotalPosts & " posts..." & vbCrLf)


        For x = (TotalPosts - 1) To 0 Step -1
            'Check for if the user canceled the operation
            If Cancel = True Then handleCanceled()
            'post = redReddit.GetMe.GetPosts.ElementAt(x)
            post = redReddit.User.Posts.ElementAt(x)

            'Insert code here to differentiate from text posts and link posts and to treat them differently.
            '
            currentpost = post.SelfText
            If currentpost <> "" Then
                scrambled = GenerateRandomText(currentpost)
                mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & ShrinkText(currentpost) & "     Changed to-> " & ShrinkText(scrambled) & vbCrLf)
                'Insert Code to edit post
                post.EditText(scrambled)
            Else
                mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & ShrinkText(post.Url.ToString) & "     Will be deleted." & vbCrLf)
            End If


            'Insert Code to delete post.
            post.Remove()
            mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Post: " & x & "     Deleted." & vbCrLf)
            'Show time elapsed
            mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Time of Completion: " & calculateTimeRemaining(startTime, (x + TotalComments), TotalPosts) & vbCrLf & vbCrLf)
            'Refresf the console so we can see the updates.
            If Cancel = True Then handleCanceled()
        Next


        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Everything should be gone You will need to manually delete your account." & vbCrLf)
        Return True
10:
    End Function
    Sub handleCanceled()
        'Display that the process is canceled
        mainForm.SetText(mainForm.txtconsole, mainForm.txtconsole.Text & "Current procedure stopped, your account may or may not be wiped." & vbCrLf)
        'Kill this thread...
        Cancel = False
        threadWipeIT.Abort()
    End Sub
    Function calculateTimeRemaining(ByVal start As System.DateTime, ByVal x As Int32, ByVal Total As Int32) As DateTime
        Dim startTime As DateTime = start
        Dim nowTime As DateTime = DateTime.Now
        Dim elapsedTime As Int32 = (nowTime - startTime).Seconds
        Dim estimatedTime As Int32
        Dim timeLeft As DateTime
        timeLeft = DateTime.Now
        Try
            'elapsedTime is the amount of seconds past since the procedure started.
            'esitmatedTime will be the number of seconds we estimate left to finish.
            estimatedTime = ((elapsedTime / x) * (Total - x))
            'convert seconds to HH:MM:SS to show timeleft.
            'timeLeft.AddSeconds(estimatedTime)
            timeLeft = timeLeft.AddSeconds(estimatedTime)
            Return timeLeft
        Catch ex As Exception
            Return timeLeft
        End Try
    End Function
End Class