Module modOld
    'Function WipeIT(ByVal mainForm As Form1, ByVal redReddit As RedditSharp.Reddit, ByVal redUser As RedditSharp.Things.AuthenticatedUser) As Boolean
    '    'Send message to user, letting them know what is about to happen.
    '    mainForm.txtconsole.Text = mainForm.txtconsole.Text & "Wipe engine loading..." & vbCrLf
    '    mainForm.txtconsole.Refresh()
    '    Dim TotalPosts As Int32 = redUser.GetPosts.Count
    '    Dim TotalComments As Int32 = redUser.GetComments.Count
    '    Dim x As Int32 ' Posts
    '    Dim y As Int32 ' Comments
    '    Dim scrambled As String
    '    Dim currentpost As String
    '    Dim post As RedditSharp.Things.Post
    '    Dim comment As RedditSharp.Things.Comment

    '    'First we will handle the posts.
    '    mainForm.txtconsole.Text = mainForm.txtconsole.Text & "Erasing " & TotalPosts & " posts..." & vbCrLf
    '    mainForm.txtconsole.Refresh()
    '    For x = 0 To (TotalPosts - 1)
    '        If Cancel = True Then Return False
    '        post = redReddit.GetMe.GetPosts.ElementAt(x)
    '        'Insert code here to differentiate from text posts and link posts and to treat them differently.
    '        '
    '        currentpost = post.SelfText
    '        scrambled = GenerateRandomText(currentpost)
    '        mainForm.txtconsole.Text = mainForm.txtconsole.Text & ShrinkText(currentpost) & "     Changed to-> " & ShrinkText(scrambled) & vbCrLf
    '        'Insert Code to edit post
    '        'post.EditText(scrambled)
    '        'Insert Code to delete post.
    '        'post.Del()
    '        'Refresf the console so we can see the updates.
    '        mainForm.txtconsole.Refresh()
    '        If Cancel = True Then Return False
    '    Next
    '    Return True
    'End Function
End Module
