


Imports System.Text
Imports System
Imports System.Globalization
Imports System.IO

Public Class Form_PicData


    Public ImageLink(1000) As String
    Public ImageToPart(1000) As String
    Public ImageTrans(1000) As String
    Public ImageTotal As Int16 = 0

    'The Object Variable below allows us to fix strings for proper title case, sentence case, etc.

    Dim ChangeTextCase As TextInfo = New CultureInfo("en-US", False).TextInfo



    Dim vgStr_WorkingDirectory As String = ""
    Dim vgStr_DesignMapFile As String = ""

    Dim vgStr_StoriesFolder As String = ""

    Dim vGStr_SpreadsFolder As String = ""



    Private Sub cButton_OpenFolderLocation_Click(sender As Object, e As EventArgs) Handles cButton_OpenFolderLocation.Click

        'Get The Folder
        Dim vlObj_ChooseFolder As New FolderBrowserDialog()
        Dim vlStr_CurrentWorkingDirectory As String = vgStr_WorkingDirectory
        Dim vlBol_DirectoryChanged As Boolean = False

        'Show the folder picker dialog

        vlObj_ChooseFolder.ShowDialog()

        If vlObj_ChooseFolder.ShowDialog = DialogResult.Cancel Then

            vgStr_WorkingDirectory = vlStr_CurrentWorkingDirectory

            Exit Sub

        End If

        vgStr_WorkingDirectory = vlObj_ChooseFolder.SelectedPath

        '***Un Comment the following for testing folder Paths
        'vgStr_WorkingDirectory = "C:\Mikes Stuff\InDesign\2018 Ford Truck\IDML\Sec 6"


        'Assign folders & files as needed
        cLabel_Directory.Text = "Working Directory: " + vgStr_WorkingDirectory

        vgStr_DesignMapFile = vgStr_WorkingDirectory + "\designmap.xml"

        vgStr_StoriesFolder = vgStr_WorkingDirectory + "\Stories\"

        vGStr_SpreadsFolder = vgStr_WorkingDirectory + "\Spreads"


    End Sub

    Private Sub cButton_StartExtract_Click(sender As Object, e As EventArgs) Handles cButton_StartExtract.Click

        'Run This Subroutine

        ExtractPictureData()

    End Sub


    Private Sub ExtractPictureData()

        'OK, First we need to get the name of every spread file in the spreads folder


        'So Step 1: Look in the folder and get names of all the files and store them in an array

        Dim vlObj_FileNames = Directory.GetFiles(vGStr_SpreadsFolder)
        Dim vlAObj_FileList As New ArrayList()
        Dim vlStr_NameOfFile As String = ""
        Dim vlInt16_Counter As Int16 = 1
        Dim vlAStr_FileNamesByStoryID(1) As String
        Dim vlint16_TotalStoryFileNames As Int16



        For Each vlStr_NameOfFile In vlObj_FileNames

            vlAObj_FileList.Add(vlStr_NameOfFile)

            vlInt16_Counter = vlInt16_Counter + 1

        Next

        ReDim vlAStr_FileNamesByStoryID(vlInt16_Counter)

        vlInt16_Counter = 1

        For Each vlStr_NameOfFile In vlObj_FileNames

            vlAStr_FileNamesByStoryID(vlInt16_Counter) = vlStr_NameOfFile.ToString

            UpdateTheStatus(vlAStr_FileNamesByStoryID(vlInt16_Counter))

            vlInt16_Counter = vlInt16_Counter + 1

        Next

        vlint16_TotalStoryFileNames = vlInt16_Counter - 1
        vlInt16_Counter = 1

        'Step 2 Is To Read Through Each File Looking For Images

        Dim PicLinks(1000) As String
        Dim PicPartNumber(1000) As String
        Dim TransForm(1000) As String

        Dim vlStr_Link As String = ""


        Dim vlStr_ItemTransform As String = ""

        Dim Rect As Boolean = False
        Dim RectLink As Boolean = False
        Dim RectItemTrans As Boolean = False
        Dim ImageCount As Int16 = 1



        For I As Int16 = 1 To vlint16_TotalStoryFileNames

            Dim vlObj_XMLReader As Xml.XmlReader = Xml.XmlReader.Create(vlAStr_FileNamesByStoryID(I))


            While vlObj_XMLReader.Read()

                Select Case vlObj_XMLReader.NodeType

                    Case Xml.XmlNodeType.Element

                        If vlObj_XMLReader.Name.ToString = "Rectangle" Then

                            Rect = True

                        End If

                        If vlObj_XMLReader.Name.ToString = "Image" And Rect = True Then


                            vlStr_ItemTransform = vlObj_XMLReader.GetAttribute("ItemTransform")

                            RectItemTrans = True


                        End If

                        If vlObj_XMLReader.Name.ToString = "Link" And Rect = True And RectItemTrans = True Then

                            vlStr_Link = vlObj_XMLReader.GetAttribute("LinkResourceURI")
                            RectLink = True

                        End If

                        If Rect = True And RectLink = True And RectItemTrans = True Then

                            PicLinks(ImageCount) = ChangeTextCase.ToUpper(vlStr_Link)

                            TransForm(ImageCount) = vlStr_ItemTransform
                            ImageCount = ImageCount + 1
                            Rect = False
                            RectLink = False
                            RectItemTrans = False



                        End If



                End Select

            End While

        Next

        UpdateTheStatus("Total Images = " + Str(ImageCount))
        UpdateTheStatus("Getting Item Transforms")

        Dim X As Double = 0
        Dim ZZ As String = ""
        Dim J As Int16 = 0

        For I = 1 To ImageCount

            J = InStr(TransForm(I), " ")

            ZZ = Mid(TransForm(I), 1, J)



            X = Val(ZZ) * 100



            TransForm(I) = Str(X)


        Next

        UpdateTheStatus("Found all transforms")

        'Now Lets Extract The Part Number

        Dim A As Int16 = 0
        Dim B As Int16 = 0
        Dim JJ As String = ""
        Dim KK As String = ""

        UpdateTheStatus("Extracting Part Numbers...")

        For I = 1 To ImageCount

            JJ = PicLinks(I)

            A = InStrRev(JJ, ".")
            B = InStrRev(JJ, "/")

            If B > 0 Then


                KK = Mid(JJ, B + 1, A - B - 1)



                PicPartNumber(I) = KK

            End If



        Next

        ImageTotal = ImageCount


        'Imagelink(I) is the link



        For I = 1 To ImageCount



            ImageLink(I) = PicLinks(I)

            ImageToPart(I) = PicPartNumber(I)
            ImageTrans(I) = TransForm(I)


        Next

        UpdateTheStatus("All images extracted from document...")



    End Sub

    Private Sub UpdateTheStatus(sender As String)


        Dim vlStr_NewMessage As String = ""
        Dim vlStr_CurrentTiming As String

        vlStr_CurrentTiming = Format(Now, "hh.mm.ss.fff")

        vlStr_NewMessage = vlStr_CurrentTiming + "   " + sender + Chr(10)

        cTextBox_Status.AppendText(vlStr_NewMessage)



    End Sub

    Private Sub cButton_MatchPartNumbers_Click(sender As Object, e As EventArgs) Handles cButton_MatchPartNumbers.Click

        Me.Hide()


    End Sub
End Class