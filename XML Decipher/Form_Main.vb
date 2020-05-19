

Imports System.Text
Imports System
Imports System.IO



Public Class Form_Main

    'Definition of global variables

    Dim vgAStr_StoryOrderID(1) As String 'This gets the ID of each story, in the order they appear in Indesign layout.  So ID#1, will be the first story, etc.

    Dim vgAStr_StoryIDCol(1) As String 'This gets the ID of the story in the order they are saved in Indesign Stories folder.  This IS NOT the order they appear in Indesign

    Dim vgAStr_StoryHeadCol(1) As String 'This gets the Heading of each story in order of how they are saved.  Later, we match this up with the storyorderID to get the order of the listings

    Dim vgAStr_HeadOrder(1) As String 'This puts the headings in an Array in the order they are in the layout

    Dim vgAInt_OrderOfHeadCol(1) As Int16 'This hold a number that shows how many parts per heading


    Dim vgAStr_Heading(1, 1) As String
    Dim vgAStr_Description(1, 1) As String
    Dim vgAStr_SpecialNote(1, 1) As String
    Dim vgAStr_Application(1, 1) As String
    Dim vgAStr_PartDescription(1, 1) As String
    Dim vgAStr_BoldInfo(1, 1) As String
    Dim vgAStr_RedInfo(1, 1) As String
    Dim vgAStr_Unit(1, 1) As String
    Dim vgAStr_RetailPrice(1, 1) As String
    Dim vgAStr_Picture(1, 1) As String
    Dim vgAStr_Scale(1, 1) As String
    Dim vgAStr_GroupOrder(1, 1) As String
    Dim vgAStr_Section(1, 1) As String
    Dim vgAStr_SectionOrder(1, 1) As String
    Dim vgAStr_PartNumber(1, 1) As String

    Dim vgInt_PartsTotal As Int16

    Dim vgAInt_HeadNumberCol(1) As Int16








    Dim vgInt16_TotalStoryID As Int16 = 0 'Total number of Story Ids

    Dim vgInt16_TotalStoryHead As Int16 = 0 'Total stories with a Head attribute





    'These variables are strings and hold the names of folders and files we are looking at
    Dim vgStr_WorkingDirectory As String = ""
    Dim vgStr_DesignMapFile As String = ""
    Dim vgStr_StoriesFolder As String = ""
    Dim vgStr_SpreadsFolder As String = ""


    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Show the current directory
        cLabel_WorkingDirectory.Text = "Working Director: No directory assigned"
        InitialTextToLabels()


    End Sub

    Private Sub cButton_ChangeWorkingDirectory_Click(sender As Object, e As EventArgs) Handles cButton_ChangeWorkingDirectory.Click

        'Here we can change the working directory so we can get to work
        'Not how the variable is named v=variable, l=local, Obj=Object, then _, then variable name (Should describe what it is doing)

        Dim vlObj_ChooseFolder As New FolderBrowserDialog()
        Dim vlStr_CurrentWorkingDirectory As String = vgStr_WorkingDirectory
        Dim vlBol_DirectoryChanged As Boolean = False

        'Show the folder picker dialog

        'vlObj_ChooseFolder.ShowDialog()

        ' If vlObj_ChooseFolder.ShowDialog = DialogResult.Cancel Then

        'vgStr_WorkingDirectory = vlStr_CurrentWorkingDirectory

        'Exit Sub

        'End If

        'vgStr_WorkingDirectory = vlObj_ChooseFolder.SelectedPath

        vgStr_WorkingDirectory = "C:\Mikes Stuff\InDesign\2018 Tri-Five\IDML\UnCompressed\Sec 2 - 2000-6000\Sec 2 - 2000-6000"





        'Assign folders & files as needed
        cLabel_WorkingDirectory.Text = "Working Directory: " + vgStr_WorkingDirectory

        vgStr_DesignMapFile = vgStr_WorkingDirectory + "\designmap.xml"

        vgStr_StoriesFolder = vgStr_WorkingDirectory + "\Stories\"

        vgStr_SpreadsFolder = vgStr_WorkingDirectory + "\Spreads"



    End Sub

    Private Sub InitialTextToLabels()

        cLabel_GetOrderInfo.Text = "1.  This will read throught the IDML directory and retrieve the order of each listing"
        cLabel_MatchID.Text = "2. This will match all Heads with there story ID"





    End Sub

    Private Sub cButton_GetStoryOrder_Click(sender As Object, e As EventArgs) Handles cButton_GetStoryOrder.Click

        UpdateTheStatus("Looking at the designmap.xml file in current directory")

        GetOrderOfStories()



    End Sub

    Private Sub GetOrderOfStories()

        'OK so to get the proper order of each story in the layout, we have to 
        '(1) Read the designmap.xml file, 
        '(2) Count each ID.  Each story ID is seperated by a space.  Id's are 4 or 5 characters and are in hex code.  We have to count how many ID's there are
        '(3) Redimension our array for the number of ID's
        '(4) parse the file and store each ID in the array using a 1 index.  0 index will be null and is not used.


        'Step 1: Set up XML Object to read XML files, and get the <StoryList> Attribute

        UpdateTheStatus("Counting the number of stories...")

        Dim vlObj_XMLReader As Xml.XmlReader = Xml.XmlReader.Create(vgStr_DesignMapFile)
        Dim vlStr_AllTheStoryID As String = ""

        While vlObj_XMLReader.Read()

            Select Case vlObj_XMLReader.NodeType()

                Case Xml.XmlNodeType.Element

                    If vlObj_XMLReader.Name.ToString = "Document" Then

                        vlStr_AllTheStoryID = vlObj_XMLReader.GetAttribute("StoryList")

                    End If

            End Select

        End While


        'Done with Step 1

        'Step 2: Count the number of ID's, get local vars ready for step 4

        Dim vlInt_Counter As Integer = 0 'This counts the Ids
        Dim vlInt_Start As Integer = 1 'Starting position of the ID Reader
        Dim vlInt_End As Integer = 1 'Ending position of the ID Reader
        Dim vlInt_NextSpace As Integer = 1 'Position of the next space
        Dim vlBol_Done As Boolean = False 'Triggers true when there is no more ID's to be read
        Dim vlStr_ID As String = "" 'The Current Story ID

        'Loop through the AllTheStoryID string, counting each ID

        While vlBol_Done = False

            vlInt_NextSpace = InStr(vlInt_Start, vlStr_AllTheStoryID, " ")

            If vlInt_NextSpace = 0 Then

                vlBol_Done = True


            End If

            vlInt_Counter = vlInt_Counter + 1

            vlInt_Start = vlInt_NextSpace + 1

        End While



        'Done with Step 2

        'Step 3: Redimension our arrays and reset variables *** Note these variables may be too much be sure and check this out



        ReDim vgAStr_StoryOrderID(vlInt_Counter + 1)
        ReDim vgAStr_StoryIDCol(vlInt_Counter + 1)
        ReDim vgAStr_StoryHeadCol(vlInt_Counter + 1)
        ReDim vgAStr_HeadOrder(vlInt_Counter + 1)
        ReDim vgAInt_OrderOfHeadCol(vlInt_Counter + 1)


        vgInt16_TotalStoryID = vlInt_Counter + 1



        vlBol_Done = False
        vlInt_NextSpace = 1
        vlInt_Counter = 1
        vlInt_Start = 1

        'Step 4: Iterate through the string again, storing each ID in the new Array

        UpdateTheStatus("Parsing story IDs....")


        While vlBol_Done = False


            vlInt_NextSpace = InStr(vlInt_Start, vlStr_AllTheStoryID, " ")

            If vlInt_NextSpace = 0 Then

                vlBol_Done = True
                vlInt_NextSpace = Len(vlStr_AllTheStoryID) + 1

            End If

            vlInt_End = vlInt_NextSpace - vlInt_Start

            vlStr_ID = Mid(vlStr_AllTheStoryID, vlInt_Start, vlInt_End)

            vgAStr_StoryOrderID(vlInt_Counter) = Trim(vlStr_ID)

            vlInt_Start = vlInt_NextSpace + 1

            vlInt_Counter = vlInt_Counter + 1


        End While

        UpdateTheStatus(Mid(Str(vlInt_Counter), 2) + "   total story IDs found...")







    End Sub


    Private Sub UpdateTheStatus(sender As String)

        Dim vlStr_NewMessage As String = ""
        Dim vlStr_CurrentTiming As String

        vlStr_CurrentTiming = Format(Now, "hh.mm.ss.fff")

        vlStr_NewMessage = vlStr_CurrentTiming + "   " + sender + Chr(10)

        cTextBox_ProgramStatus.AppendText(vlStr_NewMessage)

    End Sub

    Private Sub cButton_MatchID_Click(sender As Object, e As EventArgs) Handles cButton_MatchID.Click

        'Here we want to find what head goes with what story
        'In order to do that, we must:
        '(1) find all of the stories in the Stories folder, assining each filename to a list
        '(2) Store the list in a filename array
        'Then for each file in the folder we have to
        '   A. Finde the Story Element & the self attribute, this gives us the ID
        '   B. Find the <ParagraphStyleRange> Element, with the <AppliedParagraphStyle> Attribute that equals <"ParagraphStyle/Head>
        '   C. Store the ID and the Head in an Array column

        'So Step 1: Look in the folder and get names of all the files and store them in an array

        Dim vlObj_FileNames = Directory.GetFiles(vgStr_StoriesFolder)
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

            vlInt16_Counter = vlInt16_Counter + 1

        Next

        vlint16_TotalStoryFileNames = vlInt16_Counter - 1
        vlInt16_Counter = 1

        'Step 2:  Open each file, look for the Story number, Head Style, and content and store it in an array

        Dim vlStr_TempStoryID As String = ""
        Dim vlStr_TempStyle As String = ""
        Dim vlBol_LastHead As Boolean = False
        Dim vlStr_LastHead As String = ""
        Dim vlBol_FoundHeadContent As Boolean = False
        Dim vlStr_TempHeadContnet As String = ""

        For I As Int16 = 1 To vlint16_TotalStoryFileNames

            Dim vlObj_XMLReader As Xml.XmlReader = Xml.XmlReader.Create(vlAStr_FileNamesByStoryID(I))



            While vlObj_XMLReader.Read()

                Select Case vlObj_XMLReader.NodeType

                    Case Xml.XmlNodeType.Element

                        If vlObj_XMLReader.Name.ToString = "Story" Then

                            vlStr_TempStoryID = vlObj_XMLReader.GetAttribute("Self")
                            vgAStr_StoryIDCol(I) = vlStr_TempStoryID

                        End If

                        If vlObj_XMLReader.Name.ToString = "ParagraphStyleRange" Then

                            vlStr_TempStyle = vlObj_XMLReader.GetAttribute("AppliedParagraphStyle")

                            If vlStr_TempStyle = "ParagraphStyle/Head" Then

                                vlBol_LastHead = True
                                vlStr_LastHead = "Head"

                            End If

                        End If

                        If vlObj_XMLReader.Name.ToString = "Content" And vlBol_LastHead = True And vlStr_LastHead = "Head" Then

                            vlBol_FoundHeadContent = True

                        End If

                    Case Xml.XmlNodeType.Text

                        If vlBol_FoundHeadContent = True Then

                            vlStr_TempHeadContnet = vlObj_XMLReader.Value.ToString

                            vgAStr_StoryHeadCol(I) = vlStr_TempHeadContnet
                            vlBol_FoundHeadContent = False
                            vlBol_LastHead = False
                            vlStr_LastHead = ""


                        End If

                End Select

            End While

        Next


        UpdateTheStatus("Matched IDs with headings...")

        GetHeadingsInOrder()


    End Sub

    Private Sub GetHeadingsInOrder()

        Dim X As Int16
        Dim Y As Int16
        Dim TempID As String
        Dim LookingID As String

        UpdateTheStatus("Putting heads in order...")


        'Lets Loop Through All The Stories

        For X = 1 To vgInt16_TotalStoryID

            TempID = vgAStr_StoryOrderID(X)

            For Y = 1 To vgInt16_TotalStoryID


                LookingID = vgAStr_StoryIDCol(Y)




                If LookingID = TempID Then

                    UpdateTheStatus(TempID + " " + Str(X) + "    " + LookingID + " " + Str(Y) + vgAStr_StoryHeadCol(Y))




                    vgAStr_HeadOrder(X) = vgAStr_StoryHeadCol(Y)
                    vgAInt_OrderOfHeadCol(Y) = X


                End If

            Next

        Next

        UpdateTheStatus("Finished...")

        ' For X = 1 To vgInt16_TotalStoryID

        'UpdateTheStatus(Str(vgAInt_OrderOfHeadCol(X)) + " " + vgAStr_HeadOrder(X))

        'Next

    End Sub


End Class