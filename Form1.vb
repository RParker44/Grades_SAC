Public Class Form1
    Dim Students(1) As String
    Dim English(1) As String
    Dim Maths(1) As String
    Dim PE(1) As String
    Dim Title As String = "Name, English, Maths, PE"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Not IsNumeric(txtStudentAmount.Text) Then
            MsgBox("Only enter numbers, and don't leave the box blank.")
            Return
        End If

        Dim Iterations As Integer = (txtStudentAmount.Text - 1)

        For i = 0 To Iterations
            If i = Students.Length Then
                ReDim Preserve Students(Students.Length)
            End If
            Students(i) = InputBox("Enter the student's name:")
            If i = English.Length Then
                ReDim Preserve English(English.Length)
            End If
            English(i) = InputBox("Enter the student's English mark:")
            If i = Maths.Length Then
                ReDim Preserve Maths(Maths.Length)
            End If
            Maths(i) = InputBox("Enter the student's Maths mark:")
            If i = PE.Length Then
                ReDim Preserve PE(PE.Length)
            End If
            PE(i) = InputBox("Enter the student's PE mark:")

            lblDisplay.Text += vbNewLine & Students(i) & "," & English(i) & "," & Maths(i) & "," & PE(i)
        Next i

        Dim StudentNames = lblDisplay.Text

        For i = 0 To Iterations
            If IsNumeric(English(i)) And IsNumeric(Maths(i)) And IsNumeric(PE(i)) Then
                If (English(i) < 100) And (Maths(i) < 100) And (PE(i) < 100) Then
                    If (English(i) >= 0) And (Maths(i) >= 0) And (PE(i) >= 0) Then
                        ReDim Students(Iterations)
                        MsgBox("You entered " & Students.Length & " students into the database.")

                        My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", StudentNames, True)
                        lblDisplay.Text = ""
                        Exit For
                    Else
                        MsgBox("Only enter grades above or equal to 0.")
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

    Dim msg As String = ""
    'Public variable so it is accessable to other functions.
    Public Function ReadFile()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\Grading\grades.csv")
            Dim ReadOut As String = " "
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim Row As String()
            Dim x As Integer = 0
            Dim goThru As Integer = 0
            While Not MyReader.EndOfData
                Row = MyReader.ReadFields()
                Dim cell As String
                For Each cell In Row
                    goThru += 1
                    Select Case goThru
                        Case 1
                            If x = Students.Length Then
                                ReDim Preserve Students(UBound(Students) + 1)
                                Students(UBound(Students)) = cell
                            Else
                                Students(x) = cell
                            End If
                            ReadOut = cell
                        Case 2
                            If x = English.Length Then
                                ReDim Preserve English(UBound(English) + 1)
                                English(UBound(English)) = cell
                            Else
                                English(x) = cell
                            End If
                            ReadOut += ", " & cell
                        Case 3
                            If x = Maths.Length Then
                                ReDim Preserve Maths(UBound(Maths) + 1)
                                Maths(UBound(Maths)) = cell
                            Else
                                Maths(x) = cell
                            End If
                            ReadOut += ", " & cell
                        Case 4
                            If x = PE.Length Then
                                ReDim Preserve PE(UBound(PE) + 1)
                                PE(UBound(PE)) = cell
                            Else
                                PE(x) = cell
                            End If
                            ReadOut += ", " & cell
                            msg += ReadOut & vbNewLine
                            ReadOut = ""
                    End Select
                Next
                goThru = 0
                x += 1
            End While

        End Using
    End Function
    Public Function SortFile()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\Grading\grades.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim Row As String()
            Dim x As Integer = 0
            Dim goThrough As Integer = 0
            Dim msg As String = ""
            While Not MyReader.EndOfData
                Row = MyReader.ReadFields()
                Dim cell As String
                For Each cell In Row
                    goThrough += 1
                    Select Case goThrough
                        Case 1
                            If x = Students.Length Then
                                ReDim Preserve Students(UBound(Students) + 1)
                                Students(UBound(Students)) = cell
                            Else
                                Students(x) = cell
                            End If
                        Case 2
                            If x = English.Length Then
                                ReDim Preserve English(UBound(English) + 1)
                                English(UBound(English)) = cell
                            Else
                                English(x) = cell
                            End If
                        Case 3
                            If x = Maths.Length Then
                                ReDim Preserve Maths(UBound(Maths) + 1)
                                Maths(UBound(Maths)) = cell
                            Else
                                Maths(x) = cell
                            End If
                        Case 4
                            If x = PE.Length Then
                                ReDim Preserve PE(UBound(PE) + 1)
                                PE(UBound(PE)) = cell
                            Else
                                PE(x) = cell
                            End If
                    End Select
                Next
                goThrough = 0
                x += 1
            End While
        End Using

        Dim choice = InputBox("Choose which grade to find the best student in:" & vbNewLine & "English | Maths | PE")

        Dim tempArr(Students.Length - 1)

        If choice = "English" Then
            English.CopyTo(tempArr, 0)
            Students.CopyTo(English, 0)
            tempArr.CopyTo(Students, 0)

            Dim increment As Integer = 0
            Dim TempStudents(Students.Length - 1) As String

            For increment = 0 To Students.Length - 1
                tempArr(increment) = tempArr(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            Array.Sort(tempArr, 1, tempArr.Length - 1)
            Array.Reverse(tempArr, 1, tempArr.Length - 1)

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("Reading and sorting by English marks.")
            ReadFile()

            English.CopyTo(tempArr, 0)
            Students.CopyTo(English, 0)
            tempArr.CopyTo(Students, 0)

            For increment = 0 To Students.Length - 1
                tempArr(increment) = Students(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("This was the total class results:" & vbNewLine & Join(tempArr, vbNewLine))

            MsgBox("The student's English mark is the first grade in the sequence:" & vbNewLine & "The top scorer was: " & tempArr(1) & vbNewLine &
                   "Well done! You've done well to be the best at English!")

        ElseIf choice = "Maths" Then
            Maths.CopyTo(tempArr, 0)
            Students.CopyTo(Maths, 0)
            tempArr.CopyTo(Students, 0)

            Dim increment As Integer = 0
            Dim TempStudents(Students.Length - 1) As String

            For increment = 0 To Students.Length - 1
                tempArr(increment) = tempArr(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            Array.Sort(tempArr, 1, tempArr.Length - 1)
            Array.Reverse(tempArr, 1, tempArr.Length - 1)

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("Reading and sorting by Maths marks.")
            ReadFile()

            Maths.CopyTo(tempArr, 0)
            Students.CopyTo(Maths, 0)
            tempArr.CopyTo(Students, 0)

            For increment = 0 To Students.Length - 1
                tempArr(increment) = Students(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("This was the total class results:" & vbNewLine & Join(tempArr, vbNewLine))

            MsgBox("The student's Maths mark is the second grade in the sequence:" & vbNewLine & "The top scorer was: " & tempArr(1) & vbNewLine &
                   "Congrats at being the best at Maths, you genius!")

        ElseIf choice = "PE" Then
            PE.CopyTo(tempArr, 0)
            Students.CopyTo(PE, 0)
            tempArr.CopyTo(Students, 0)

            Dim increment As Integer = 0
            Dim TempStudents(Students.Length - 1) As String

            For increment = 0 To Students.Length - 1
                tempArr(increment) = tempArr(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            Array.Sort(tempArr, 1, tempArr.Length - 1)
            Array.Reverse(tempArr, 1, tempArr.Length - 1)

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("Reading and sorting by PE marks.")
            ReadFile()

            PE.CopyTo(tempArr, 0)
            Students.CopyTo(PE, 0)
            tempArr.CopyTo(Students, 0)

            For increment = 0 To Students.Length - 1
                tempArr(increment) = Students(increment)
                tempArr(increment) += "," & English(increment)
                tempArr(increment) += "," & Maths(increment)
                tempArr(increment) += "," & PE(increment)
            Next

            My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Join(tempArr, vbNewLine), False)

            MsgBox("This was the total class results:" & vbNewLine & Join(tempArr, vbNewLine))

            MsgBox("The student's PE mark is the third grade in the sequence:" & vbNewLine & "The top scorer was: " & tempArr(1) & vbNewLine &
                   "Give them a cookie, or something. Great work!")
        Else
            Return MsgBox("Only enter a choice from the following options: English | Maths | PE")
        End If

        msg = ""

    End Function
    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        ReadFile()
        MsgBox(msg)
        msg = ""
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
                    Exit Sub
                Else
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
                    MsgBox("Student not found. Make sure you use the correct spelling & case.")
                    btnSearch_Click(sender, New System.EventArgs())
                End If
                MsgBox("Student name and score: " & Output)
                btnSearch_Click(sender, New System.EventArgs())
            End If
        End Using
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", "", False)
        My.Computer.FileSystem.WriteAllText("D:\Grading\grades.csv", Title, True)
        'Simply sets all cells in the CSV to false, wiping them. Then resets the file with the header.

    End Sub

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        SortFile()
    End Sub
End Class
