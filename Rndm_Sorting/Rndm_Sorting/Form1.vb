Public Class Form1
    Dim insertionArray() As Integer
    Dim selectionArray() As Integer
    Dim insertionTime As String
    Dim selectionTime As String

    Public Function executionTime(start As DateTime, stops As DateTime)
        Dim elapsed_time As TimeSpan

        elapsed_time = stops.Subtract(start)

        Return elapsed_time.TotalSeconds.ToString("0.000000")
    End Function

    Private Sub selectionSort(array() As Integer)
        Dim Temp2, minimo, i, j As Integer

        For i = 0 To array.Length - 1
            minimo = i
            For j = i + 1 To array.Length - 1
                If array(minimo) > array(j) Then
                    minimo = j
                End If
            Next j
            Temp2 = array(i)
            array(i) = array(minimo)
            array(minimo) = Temp2

        Next i
        ReDim selectionArray(array.Length)
        For i = 0 To array.Length - 1
            selectionArray(i) = array(i)
        Next

    End Sub
    Private Sub insertionSort(array() As Integer)
        Dim pointer As Integer
        Dim current As Integer
        Dim position As Integer

        For pointer = 1 To array.Length - 1
            current = array(pointer)
            position = pointer
            Do While position > 0 AndAlso array(position - 1) > current
                array(position) = array(position - 1)
                position -= 1

            Loop
            array(position) = current
        Next
        ReDim insertionArray(array.Length)

        For i = 0 To array.Length - 1
            insertionArray(i) = array(i)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ext As Integer = InputBox("Write the amount of numbers")
        Dim array(ext) As Integer
        For i As Integer = 0 To array.Length - 1
            array(i) = Math.Ceiling(Rnd() * 250000)
            ListBox1.Items.Add(array(i))
        Next

        Dim _start As DateTime
        Dim _stop As DateTime

        '------------INSERTION EXE--------------
        _start = Now
        Call insertionSort(array)
        _stop = Now
        insertionTime = executionTime(_start, _stop)
        MsgBox(insertionTime)

        '--------SELECTION EXE----------------
        _start = Now
        Call selectionSort(array)
        _stop = Now
        selectionTime = executionTime(_start, _stop)
        MsgBox(selectionTime)

        '--------print values------
        For i As Integer = 0 To array.Length - 1
            ListBox2.Items.Add(selectionArray(i))
        Next

        If selectionTime > insertionTime Then
            MsgBox("Insertion sort is faster")
        Else
            MsgBox("Selection sort is faster")

        End If
    End Sub

End Class
