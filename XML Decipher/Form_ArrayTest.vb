Public Class Form_ArrayTest


    Dim MaxPart As Int16 = 0

    Dim Part1 As Int16 = 1
    Dim Part2 As Int16 = 1


    Private Sub Form_ArrayTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = Str(Part1)

        Label2.Text = Str(Part2)

        MaxPart = Form1.PartsInStory(Part1)






    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        TextBox1.AppendText(Form1.PartNumber(Part1, Part2))



    End Sub
End Class