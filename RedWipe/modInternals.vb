Module modInternals

    Public Cancel As Boolean
    Public threadWipeIT As Threading.Thread
    Public cryptoCount As Int32

    Function ShrinkText(ByVal str As String) As String
        If str.Length > 12 Then
            Return Mid(str, 1, 20) & "..."
        Else
            Return str & "..."
        End If
    End Function


    Function GenerateRandomText(ByVal PlainText As String) As String
        'This function returns a string of letters (upper or lower) or number by using cryptographic functions to generate the random seed for the letters.
        Dim x As Int32
        Dim length As Int32 = PlainText.Length
        Dim objByte As Byte()
        Dim message As String
        Dim Alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        'Assign "" to message
        message = ""
        'Create the array
        objByte = New Byte(Alphabet.Count) {}
        'Get random numbers
        objByte = RandomCharacter(Alphabet.Count)
        'Now we set up the For Next Loop to create the random string
        'This uses the random numbers in objByte to grab characters from Alphabet
        'This is impossibly messy below, this should be fixed.
        For x = 0 To (length - 1)
            If Val(objByte(x Mod Alphabet.Count)) < Alphabet.Count Then
                If Val(objByte(x Mod Alphabet.Count)) > Alphabet.Count Then
                    message = message & Alphabet.ElementAt(Val(objByte(x Mod Alphabet.Count)))
                Else
                    message = message & Alphabet.ElementAt(Val(objByte(x Mod Alphabet.Count)))
                End If
            Else
                message = message & Alphabet.ElementAt((Val(objByte(x Mod Alphabet.Count)) Mod Alphabet.Count))
            End If
        Next
        Return message
    End Function
    Function RandomCharacter(ByVal nBytes As Int32) As Byte()
        'Generating a random byte (we don't need overkill here, just something from 0-255.
        Dim objByte As Byte() = New Byte(nBytes) {}
        Dim objRNG As System.Security.Cryptography.RandomNumberGenerator = System.Security.Cryptography.RandomNumberGenerator.Create()
        objRNG.GetNonZeroBytes(objByte)
        Return objByte
    End Function
End Module
