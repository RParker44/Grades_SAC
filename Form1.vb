Public Class Form1
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Students(50) As String
        Dim English(50) As String
        Dim Maths(50) As String
        Dim PE(50) As String

        If Not IsNumeric(txtStudentAmount.Text) Then
            MsgBox("Only enter numbers, and don't leave the box blank.")
            Return
        End If

        Dim Iterations As Integer = (txtStudentAmount.Text - 1)
        Dim Title As String = " ,English,Maths,PE"


        For i = 0 To Iterations
            Students(i) = InputBox("Enter the student's name:")
            English(i) = InputBox("Enter the student's English mark:")
            Maths(i) = InputBox("Enter the student's Maths mark:")
            PE(i) = InputBox("Enter the student's PE mark:")

            lblDisplay.Text = lblDisplay.Text & vbNewLine & Students(i) & "," & English(i) & "," & Maths(i) & "," & PE(i)
        Next i

        Dim StudentNames = lblDisplay.Text

        For i = 0 To Iterations
            If IsNumeric(English(i)) And IsNumeric(Maths(i)) And IsNumeric(PE(i)) Then
                If (English(i) < 101) And (Maths(i) < 101) And (PE(i) < 101) Then
                    If (English(i) >= 0) And (Maths(i) >= 0) And (PE(i) >= 0) Then
                        ReDim Students(Iterations)
                        MsgBox("You entered " & Students.Length & " students into the database.")

                        My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", vbNewLine & Title & StudentNames, True)
                        lblDisplay.Text = ""
                        Exit For
                    Else
                        MsgBox("Only enter grades above 100.")
                        MsgBox("The program will now exit.")
                    End If
                Else
                    MsgBox("Only enter grades under 100.")
                    MsgBox("The program will now exit.")
                    lblDisplay.Text = ""
                    Exit For
                End If
            Else
                MsgBox("You have entered one or more non-numeric values for grades.")
                MsgBox("The program will now exit.")
                lblDisplay.Text = ""
                Exit For
            End If
        Next i
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\Grading\grades.csv")
            Dim ReadOut As String = " "
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim Row As String()
            While Not MyReader.EndOfData
                Row = MyReader.ReadFields()
                Dim cell As String
                For Each cell In Row
                    If cell.Contains("English") = True Then
                        ReadOut += vbNewLine
                    End If
                    ReadOut += (" " + cell)
                Next
                ReadOut += vbNewLine
            End While
            MsgBox(ReadOut)
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Using Search As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\Grading\grades.csv")
            Search.TextFieldType = FileIO.FieldType.Delimited
            Search.SetDelimiters(",")
            Dim Rows As String()
            Dim Text As String = InputBox("Enter first name of student to search for:")
            Dim Found As Boolean = False
            Dim Count As Integer = 0
            Dim Output As String = ""
            If Text = "" Then
                Dim answer = MsgBox("Do you want to cancel this process?", vbYesNo)
                If answer = vbYes Then
                    MsgBox("Exiting program.")
                    Application.Exit()
                Else
                    MsgBox("Returning to program...")

                    MsgBox("Make sure you input a student name to search for.")
                    btnSearch_Click(sender, New System.EventArgs())
                End If
            Else
                While Not Search.EndOfData
                    Rows = Search.ReadFields()
                    Dim cells As String
                    For Each cells In Rows
                        If Count > 0 Then
                            Output += " " + cells
                            Count -= 1
                        End If
                        If cells = Text Then
                            MsgBox("Student found!")
                            Found = True
                            Output = Text
                            Count = 3
                        End If
                    Next
                End While
                If Found = False Then
                    MsgBox("Student not found. Make sure you use the correct spelling & lower/uppercase")
                    btnSearch_Click(sender, New System.EventArgs())
                End If
                MsgBox("Student name and score: " & Output)
                btnSearch_Click(sender, New System.EventArgs())
            End If
        End Using
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", "", False)
        'Simply sets all cells in the CSV to false, wiping them.
    End Sub

End Class
