

'Classic Auto Parts Group Media Manager (C) 2016-2017 By: Mike Burch
'***DO NOT COPY, CHANGE, EXTRACT, OR USE THIS SOFTWARE UNLESS YOU HAVE SPECIFIC WRITTEN AUTHORIZATION OF MIKE BURCH!!!  email: mikeburch@classicautoparts.com

'This Class will parse XML exported from InDesign and put it into a UTF-8 encoded PIPE CHARACTER ("|") delimeted text file
'This is The MAIN CLASS of hte module for Catalog Data Extraction


Imports System
Imports System.Globalization
Imports System.IO
Imports System.Text






Public Class Form1

    'How to do variables, subs, etc.

    'Variables are xxyyy_Name

    'Global variables vG_ (name)
    'Local variables v_(name)
    'Public variables vp_(name)
    'Controls are c_control name & number_name so label is c_label1_Main

    'String variables globally would be vGStr_NameOFString


    'Name of the file user is working with
    Dim myFileName As String

    'Name of IDML Variables
    Dim myWorkingFolder As String 'Folder that contains IDML From Indesign
    Dim myDesignMapFile As String 'File of designmap.xml
    Dim myStoriesFolder As String 'Folder with stories

    Dim NumberOfListings As Int16 'Total listings
    Dim StoryCode(1) As String 'The code, listed in order the InDesign assigns to each story
    Dim ListHeading(1) As String 'Name Of The Heading

    Dim AllDesignMapStoryID As String

    Dim StoryIDHeads(1, 1) As String 'Array for matching ID with Head

    Dim FileNameByStoryID(1) As String 'Array with the filename of each story
    Dim TotalStoryFileNames As Int16 = 0 ' Total Number of StoryFilenames

    'For Using IDML With Database

    Dim StoryIDCol(1) As String
    Dim StoryHeadCol(1) As String




    'Array that holdes each node value
    Dim XMLNode(1) As String

    'String for holding information to be displayed to the user
    Dim Information As String = ""

    Dim StoryNode(500)
    'Total Nodes in file
    Dim TotalNodes As Integer

    'Total Story Nodes in File
    Public TotalStory As Integer

    'Total Images in File
    Dim TotalImage As Integer

    'Global arrays for dealing with images and their repective paths plus part numbers

    Dim ImageCount As Integer
    Dim ImagePath(1) As String
    Dim ImageForPartNumber(1) As String
    Dim PartNumberPicture(1) As String




    'Part Count holds the higest part numbers regardless of node, it is the highest part count
    Dim PartCount As Integer = 0

    'Which Story (1 through the end) has the most parts.
    Dim StoryWithMostParts As Integer = 0

    'Tag string variables for tag names.  Tag names are a work in progress.  Not there yet.
    Dim Tag1 As String = "Heading"

    'Has Section Been Changed
    Dim ChgSec As Boolean = False

    'Global boolean variables for extracted text in a story

    Dim BOOL_PartDesc As Boolean = False


    'String that handles updates shown to the user

    Dim STR_UpdateInfo As String = ""

    'The Object Variable below allows us to fix strings for proper title case, sentence case, etc.

    Dim ChangeTextCase As TextInfo = New CultureInfo("en-US", False).TextInfo




    'Global Arrays that hold the values of the types of data found in the XML document

    Public Head(1, 1)
    Public Description(1, 1)
    Public SpecialNote(1, 1)

    Public Application(1, 1)
    Public PartDescription(1, 1)
    Public BlueBoldInfo(1, 1)
    Public RedInformation(1, 1)
    Public Picture(1, 1)
    Public ImageScale(1, 1)
    Public StockNumber(1, 1)
    Public PartNumber(1, 1)

    'Total parts in story
    Public PartsInStory(1)


    Dim TotalPartNumbers As Integer



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Show(Form_Main)


        'Set up form

        'but means button.  pb means progressbar.  Working on this.

        butLoadXMLFile.Visible = True
        butReadXML.Visible = False
        lblStatus.Text = "Click Button to open XML file."
        tbxProcess.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butLoadXMLFile.Click

        Dim myFileDIalog As New OpenFileDialog()

        'myFileDIalog.InitialDirectory = "C:\"
        'Default to last used directory

        myFileDIalog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        myFileDIalog.FilterIndex = 1

        myFileDIalog.ShowDialog()

        If myFileDIalog.FileName = "" Then

            butReadXML.Visible = False

            lblStatus.Text = "No File Loaded"


        End If

        myFileName = myFileDIalog.FileName

        lblStatus.Text = myFileName

        butReadXML.Visible = True


    End Sub

    Private Sub butReadXML_Click(sender As Object, e As EventArgs) Handles butReadXML.Click

        tbxProcess.Visible = True
        'pbParseXML.Visible = True
        tbxProcess.AppendText("Reading file...." + Chr(10))
        butLoadXMLFile.Visible = False

        ShowInfoToUser("Reading XML file....")
        ExecuteXMLParse()



    End Sub

    Private Sub ExecuteXMLParse()

        'This sub simply executes each subset sub-routine
        'First we read the entire XML file
        ReadXMLFile()

        'Then we find all the stories.  Remember ALL TEXT FRAMES are stories
        GetAllStories()
        ReConFigureArray()
        CountPartsPerStory()
        ReConFigureArrayAgain()
        'IterateThroughStories()
        GoThroughXML()

        'If Get Image info box is checked, do that here

        If CheckBox1_ExportImageInfo.Checked = True Then

            GoThroughImageXml()
            MatchPictureToPart()

        End If


        ClearForm()
        'WriteNewXMLFile()
        'End

    End Sub

    Private Sub ReadXMLFile()

        'First and foremost, we need to see how many nodes we have so we can configure our dimensioned arrays and iteration steps.

        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)
        Dim A As Int16

        A = 0

        ShowInfoToUser("Searching XML data...")

        While myXMLReader.Read()


            Select Case myXMLReader.NodeType()
                Case Xml.XmlNodeType.Element

                    A = A + 1

            End Select

        End While

        ShowInfoToUser(Str(A) + " total XML nodes found....")

        TotalNodes = A

    End Sub

    Private Sub GetAllStories()

        'Secondly, since we are first concerned with just story nodes, versus other nodes, we have to see how many nodes are tagged as stories.
        'THere are two caveats here.  One, ALL text frames in InDesign are tagged as stories.  Two, The order that the stories are presented in XML ARE NOT the order they are presented to
        'InDesign.  I have not figured out a solution for this just yet, but it is coming.  So then, let's see how many story nodes we have.

        'UPDAT AS OF JUNE 7, 2017:  We are now going to get all stories AND all images....

        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)
        Dim A As Int16 'Count Of Stories
        Dim B As Int16 'Count of Images

        A = 0
        B = 0

        ShowInfoToUser("Counting Total Stories & Images")

        While myXMLReader.Read()


            Select Case myXMLReader.NodeType()
                Case Xml.XmlNodeType.Element
                    If myXMLReader.Name.ToString = "Story" Then

                        A = A + 1

                    End If

                    If CheckBox1_ExportImageInfo.Checked = True Then


                        If myXMLReader.Name.ToString = "Image" Then

                            B = B + 1

                        End If


                    End If

            End Select



        End While

        ShowInfoToUser(Str(A) + " total story nodes...")

        ShowInfoToUser(Str(B) + " total image nodes.....")


        TotalStory = A

        TotalImage = B

        ImageCount = B



    End Sub

    Private Sub ReConFigureArray()

        ReDim Head(TotalStory, 1)
        ReDim Description(TotalStory, 1)
        ReDim SpecialNote(TotalStory, 1)

        ReDim PartsInStory(TotalStory)

        ShowInfoToUser("Reconfiguring Head & Description Array")


    End Sub

    Private Sub CountPartsPerStory()

        'Here, we find the story that has the most part numbers.  This is so we can ReDimension the array in the form of (TOTAL_STORIES, MOST_PARTS_IN_A STORY)
        'This clears out of RAM any excess memory usage and allocates space for all of the actual part numbers.

        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)
        Dim A As Int16
        Dim B As Int16
        Dim C As Int16

        A = 0 'A holds the story we are on
        C = 0 'B is the part number in the story (A, B)
        B = 0 'C not used currently--reserved for future enhancement

        While myXMLReader.Read()

            'Run through each node and see what type it is
            'Remember, we have to iterate through Nodetypes and text at the same time.  We cannot do one then the other.  It makes the code look strange, but on second glance it
            'Makes sense.

            Select Case myXMLReader.NodeType()
                Case Xml.XmlNodeType.Element
                    If myXMLReader.Name.ToString = "Story" Then

                        'When the 1st Story node is found, PARTSINSTORY(0) will equal 0.  The 0th array is never referenced so it acts like a temporary placeholder.
                        'All subsequent stories will align perfectly.

                        PartsInStory(A) = B

                        'Now we add 1 to the story counter.  
                        A = A + 1

                        'Now we increase the TOTAL_PART_NUMBERS.  On the first story, before any parts are found, TOTALPARTNUMBERS ++ B will be 0, as it should be.

                        TotalPartNumbers = TotalPartNumbers + B

                        B = 0

                    End If

                    If myXMLReader.Name.ToString = "Part_Number" Then

                        B = B + 1

                        If B > PartCount Then

                            PartCount = B

                            StoryWithMostParts = A

                        End If

                    End If

            End Select


        End While

        ShowInfoToUser(Str(TotalPartNumbers) + " total part numbers found in file....")

    End Sub

    Private Sub ReConFigureArrayAgain()

        'We redim the array again.  This code should be cleaned up and merged with the first redim to form only one instance of rediming the arrays

        ReDim Head(TotalStory, PartCount)
        ReDim Description(TotalStory, PartCount)
        ReDim SpecialNote(TotalStory, PartCount)

        ReDim Application(TotalStory, PartCount)
        ReDim PartDescription(TotalStory, PartCount)
        ReDim BlueBoldInfo(TotalStory, PartCount)
        ReDim RedInformation(TotalStory, PartCount)

        ReDim Picture(TotalStory, PartCount)
        ReDim ImageScale(TotalStory, PartCount)

        ReDim StockNumber(TotalStory, PartCount)

        ReDim PartNumber(TotalStory, PartCount)

        ReDim ImagePath(TotalImage)
        ReDim ImageForPartNumber(TotalImage)
        ReDim PartNumberPicture(TotalImage)



        ShowInfoToUser("Reconfigured array for further processing...")

    End Sub

    Private Sub IterateThroughStories()


        'CURENTLY THIS SUB IS NOT USED -- IT WAS USED FOR TESTING
        'This subroutine is the meat of this script.  This iterates through all of the XML in a file and tries to parse data with specific tags.
        'Data without these specific tags, or data with these tags but not in a parts list is discarded.
        'NOTE: **InDesign makes EVERY text frame a story.  Stories not conforming to our specific pattern are discarded.

        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)

        Dim A As Int16  'Keeps Track Of Which Story We Are Looking At
        Dim B As Int16  'Keeps Track of Part Number we are looking at in the current story
        Dim C As Int16
        Dim X As String 'Temporarily holds the current line of text in the XML document

        Dim tHead As String = "" 'temp head string
        Dim tDescription As String = "" ' temp description string
        Dim tSpecialNote As String = "" 'temp special note string

        A = 0
        C = 0
        B = 0

        Dim bHead As Boolean = False
        Dim bDescription As Boolean = False
        Dim bSpecialNote As Boolean = False
        Dim bApplication As Boolean = False
        Dim bPartNumber As Boolean = False



        tbxProcess.AppendText("Deflating All Stories...." + Chr(10))

        While myXMLReader.Read()

            Select Case myXMLReader.NodeType()
                Case Xml.XmlNodeType.Element
                    If myXMLReader.Name.ToString = "Story" Then

                        'As soon as a STORY frame is found, it sets the PartsInStory to 0.  As the story is iterated through, this number increases.

                        PartsInStory(A) = B

                        'A will not increase beyond 0 unless a valid XML Node Type is found, so it excludes any data not specifically for listing parts.

                        If A > 0 Then

                            tbxProcess.AppendText("Processing Story # " + Str(A) + Chr(10))

                        End If


                        tHead = ""
                        tDescription = ""
                        tSpecialNote = ""

                        'Since we have passed the above test, this is a valid story.  As such, we add 1 to A and reset B

                        A = A + 1

                        B = 1

                    End If




                    If myXMLReader.Name.ToString = "Head" Then

                        X = myXMLReader.Value


                        tHead = tHead + X

                    End If

                    If myXMLReader.Name.ToString = "Description" Then

                        X = myXMLReader.Value.ToString

                        tDescription = tDescription + X

                    End If


                    If myXMLReader.Name.ToString = "SpecialNote" Then

                        X = myXMLReader.Value.ToString

                        tSpecialNote = tSpecialNote + X

                    End If

                    If myXMLReader.Name.ToString = "Application" Then

                        X = myXMLReader.Value.ToString

                        Application(A, B) = Application(A, B) + X

                    End If

                    If myXMLReader.Name.ToString = "Part_Description" Then

                        X = myXMLReader.Value.ToString

                        PartDescription(A, B) = PartDescription(A, B) + X

                    End If

                    If myXMLReader.Name.ToString = "Blue_Bold_Info" Then

                        X = myXMLReader.Value.ToString

                        PartDescription(A, B) = PartDescription(A, B) + X

                    End If

                    If myXMLReader.Name.ToString = "Red_Information" Then

                        X = myXMLReader.Value.ToString

                        RedInformation(A, B) = RedInformation(A, B) + X


                    End If

                    If myXMLReader.Name.ToString = "Stock_Number" Then

                        X = myXMLReader.Value.ToString

                        StockNumber(A, B) = StockNumber(A, B) + X


                    End If

                    If myXMLReader.Name.ToString = "Part_Number" Then



                        Head(A, B) = tHead
                        Description(A, B) = tDescription
                        SpecialNote(A, B) = tSpecialNote

                        X = myXMLReader.Value.ToString

                        PartNumber(A, B) = X

                        Console.WriteLine(Head(A, B) + ", " + Description(A, B) + ", " + SpecialNote(A, B) + ", " + Application(A, B) + ", " + PartDescription(A, B) + ", " +
                        BlueBoldInfo(A, B) + ", " + RedInformation(A, B) + ", " + PartNumber(A, B))


                        B = B + 1



                    End If

            End Select



        End While









    End Sub

    Private Sub GoThroughXML()

        ShowInfoToUser("Processing XML in each story....")

        'Set up XML reader object
        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)

        Dim A As Int16  'Keeps Track Of Story On
        Dim B As Int16  'Keeps Track of Part Number On
        Dim C As Int16
        Dim X As String

        Dim LastElement As String = "" ' this keeps track of the last type of Element Node

        Dim tHead As String = "" 'temp head string
        Dim tDescription As String = "" ' temp description string
        Dim tSpecialNote As String = "" 'temp special note string


        A = 0 'Story Number we are on
        C = 0
        B = 1 'Parts in the story we are on

        'Trigger to see if there is a heading in the story
        Dim bHead As Boolean = False
        Dim bDescription As Boolean = False
        Dim bSpecialNote As Boolean = False
        Dim bApplication As Boolean = False
        Dim bPartDescription As Boolean = False
        Dim bBlueBoldInfo As Boolean = False
        Dim bRedInformation As Boolean = False
        Dim bStockNumber As Boolean = False
        Dim bPartNumber As Boolean = False
        Dim heading As Boolean = False
        Dim newStory As Boolean = False
        Dim PartsInLastStory As Boolean = False

        Dim SameStyle As Boolean = False

        Dim HeadAlreadyInStory = False 'Trigger this variable if we encounter another head style in the same story
        Dim DescAlreadyInStory As Boolean = False 'If this variable is triggered true, then further descriptions become part descriptions


        'These variable with PNodeT (Previous NODE Text, T or F),  show true if (1) The current node is a text node, and 
        '(2) the previous node was a text node.  See further comments at that part of this sub below after element node type

        'Trigger to see if there is a validly named element in story.  True or False.
        Dim bAnotherStyle As Boolean = False

        'This registers to see if there was a part number in the story, comparing it to the heading.  If we encounter a part number style in a story, but that
        'story DOES NOT HAVE a Heading, it is NOT a valid listing.

        Dim HadPartnumber As Boolean = False


        While myXMLReader.Read()

            Select Case myXMLReader.NodeType()

                'Read the next piece of XML and determine if it is the name of a node (Element) or it's value (Text)

                'If it is an Element then do this case

                Case Xml.XmlNodeType.Element


                    'Lets clear up temp local variables used for a Text Node just to be safe
                    'Since it is an element, see also what kind it is.  If it is a STORY element then, (All text frames in InDesign are STORY frames),
                    'Then that means it is a NEW STORY

                    If myXMLReader.Name.ToString = "Story" Then


                        newStory = True
                        LastElement = ""
                        SameStyle = False
                        HeadAlreadyInStory = False
                        DescAlreadyInStory = False

                        ' PartsInStory(A) = B


                        B = 1



                        A = A + 1

                        ' If A > 1 And PartsInLastStory = False Then

                        'A = A - 1

                        'End If

                        'Since it is a new story, we need to see if the previous story was valid.  There are 2 reasons it may not be valid.
                        'So we check to see if:
                        '(1) There was a heading, but no valid element OR (2) there was a heading but no part number
                        'If either of these conditions are met, we nullify previous story

                        '*****IMPORTANT***** Make sure all of the If/Thens Have Correct Tags In The XML!!!********

                        '  If (heading = True And bAnotherStyle = False) Or (heading = True And HadPartnumber = False) Then

                        'We move back the A counter by 1 ('A' variable holds the CURRENT story number locally), this puts our pointer 
                        'back 1 which effectively destroys previous story since a new story will now overwrite this
                        '*NOTE this maybe causing some problems if (1) we move back the pointer but there is no new STORY elements--Work on this problem

                        'A = A - 1

                        'End If



                        'PartsInStory(A) = B


                        heading = False

                        bAnotherStyle = False
                        HadPartnumber = False
                        tHead = ""
                        tDescription = ""
                        tSpecialNote = ""

                        ' ShowInfoToUser(Str(A))




                    End If



                    'Using simple compare we step through each possible valid node


                    If myXMLReader.Name.ToString = "Head" And HeadAlreadyInStory = False Then

                        bHead = True
                        heading = True 'This means this story has a head
                        LastElement = "Head"

                        'If this element is a HEAD element, then we store it and trigger boolean TRUE for a heading in the story

                    End If



                    If myXMLReader.Name.ToString = "Description" Then

                        If LastElement = "Description" Then

                            SameStyle = True

                        Else

                            SameStyle = False

                        End If

                        bDescription = True
                        bAnotherStyle = True
                        LastElement = "Description"

                    End If


                    If myXMLReader.Name.ToString = "Special_Note" Then

                        If LastElement = "Special_Note" Then

                            SameStyle = True

                        Else

                            SameStyle = False

                        End If

                        bSpecialNote = True
                        bAnotherStyle = True
                        LastElement = "Special_Note"

                    End If

                    If myXMLReader.Name.ToString = "Application" Then

                        If LastElement = "Application" Then

                            SameStyle = True

                        Else

                            SameStyle = False


                        End If

                        bApplication = True
                        bAnotherStyle = True
                        LastElement = "Application"



                    End If

                    If myXMLReader.Name.ToString = "Part_Description" Then

                            If LastElement = "Part_Description" Then

                                SameStyle = True

                            Else

                                SameStyle = False


                            End If

                            bPartDescription = True
                            bAnotherStyle = True
                            LastElement = "Part_Description"


                        End If

                        If myXMLReader.Name.ToString = "Blue_Bold_Info" Then

                            If LastElement = "Blue_Bold_Info" Then

                                SameStyle = True

                            Else

                                SameStyle = False

                            End If

                            bBlueBoldInfo = True
                            bAnotherStyle = True
                            LastElement = "Blue_Bold_Info"

                        End If

                        If myXMLReader.Name.ToString = "Red_Information" Then

                            If LastElement = "Red_Information" Then

                                SameStyle = True

                            Else

                                SameStyle = False


                            End If



                            bRedInformation = True
                            bAnotherStyle = True
                            LastElement = "Red_Information"


                        End If

                        If myXMLReader.Name.ToString = "Stock_Number" Then

                            bStockNumber = True
                            bAnotherStyle = True
                            LastElement = "Stock_Number"

                        End If

                        If myXMLReader.Name.ToString = "Part_Number" Then

                            bPartNumber = True
                            bAnotherStyle = True
                            HadPartnumber = True
                            LastElement = "Part_Number"


                        End If





                        Exit Select

                    'So This first CASE is used to see if what we are looking at is A Node, and it stores such 
                    'Now, we see what the VALUE of that node is

                Case Xml.XmlNodeType.Text

                    'If this is a value node, not an element, we trim all whitespace around the string because InDesign uses a lot of special
                    'meta characters that cause formatting problems in spreadsheets and databases

                    X = myXMLReader.Value.ToString.TrimEnd({ChrW(8233), Chr(13), Chr(32)})

                    X = Trim(X)


                    'Now we check to see if the value we are looking at is within a proper STORY, by checking to see that there is a HEADING
                    'If there is, then we make each part number have the same heading under the group listing of the story
                    'We also check to see if this is a value node of the same kind on the last iteration.  This could happen if a carrriage return (13) was used in InDesign
                    'for multiple values and not chr(10) line feed.  If this is the case, we fix it accordingly.  This is where the PNODET variables come into play. (Noted earlier)

                    'So now X hold the text

                    'So... If we find a VALUE for Head, and this is the first value of head, then
                    '***t at the start of variable means temporary

                    If bHead = True And HeadAlreadyInStory = False Then

                        Head(A, B) = ChangeTextCase.ToTitleCase(Trim(X))

                        tHead = X
                        HeadAlreadyInStory = True

                        bHead = False

                    End If

                    'Now On to the description

                    If bDescription = True And heading = True Then


                        If SameStyle = True Then

                            Description(A, B) = Description(A, B).TrimEnd({ChrW(8233), Chr(13), Chr(32)}) + ChrW(8232) + X

                            tDescription = tDescription.TrimEnd({ChrW(8233), Chr(13), Chr(32)}) + "∞" + X


                        End If

                        If SameStyle = False Then

                            Description(A, B) = X
                            tDescription = X

                        End If

                        Description(A, B) = Description(A, B).ToString.TrimEnd({ChrW(8233), Chr(13), Chr(32)})

                        bDescription = False

                    End If

                    If bDescription = True And heading = False Then

                        bDescription = False

                    End If



                    If bSpecialNote = True And heading = True Then

                        If SameStyle = True Then

                            SpecialNote(A, B) = SpecialNote(A, B) + "∞" + X


                            tSpecialNote = tSpecialNote + "∞" + X


                        End If

                        If SameStyle = False Then


                            SpecialNote(A, B) = X
                            tSpecialNote = X

                        End If


                        bSpecialNote = False


                    ElseIf bSpecialNote = True And heading = False Then

                        bSpecialNote = False

                    End If

                    If bApplication = True And heading = True Then


                        If SameStyle = True Then

                            Application(A, B) = Application(A, B) + ChrW(8232) + X

                        Else

                            Application(A, B) = X

                        End If



                        ' Application(A, B) = Application(A, B).ToString.TrimEnd({ChrW(8233), Chr(13), Chr(32)})


                        bApplication = False


                    ElseIf bApplication = True And heading = False Then

                        bApplication = False

                    End If

                    If bPartDescription = True And heading = True Then

                        If SameStyle = True Then

                            PartDescription(A, B) = PartDescription(A, B) + ChrW(8232) + X

                        Else

                            PartDescription(A, B) = X


                        End If

                        bPartDescription = False

                    ElseIf bPartDescription = True And heading = False Then

                        bPartDescription = False

                    End If

                    If bBlueBoldInfo = True And heading = True Then

                        If SameStyle = True Then

                            BlueBoldInfo(A, B) = BlueBoldInfo(A, B) + ChrW(8232) + X

                        Else
                            BlueBoldInfo(A, B) = X


                        End If

                        bBlueBoldInfo = False

                    ElseIf bBlueBoldInfo = True And heading = False Then

                        bBlueBoldInfo = False

                    End If

                    If bRedInformation = True And heading = True Then

                        If SameStyle = True Then

                            RedInformation(A, B) = RedInformation(A, B) + ChrW(8232) + X

                        Else

                            RedInformation(A, B) = X


                        End If

                        bRedInformation = False

                    ElseIf bRedInformation = True And heading = False Then

                        bRedInformation = False

                    End If

                    If bStockNumber = True And heading = True Then

                        StockNumber(A, B) = X


                        bStockNumber = False


                    ElseIf bStockNumber = True And heading = False Then

                        bStockNumber = False


                    End If





                    If bPartNumber = True And heading = True Then

                        PartNumber(A, B) = X

                        PartsInLastStory = True

                        'B = B + 1

                        Head(A, B) = tHead
                        Description(A, B) = tDescription
                        SpecialNote(A, B) = tSpecialNote

                        'Head(A, B) = Head(A, B - 1)

                        'Description(A, B) = Description(A, B - 1)

                        'SpecialNote(A, B) = SpecialNote(A, B - 1)

                        bPartNumber = False

                        PartsInStory(A) = B



                        SameStyle = False

                        'ShowInfoToUser(Str(A) + " " + Str(B) + " " + PartNumber(A, B) + Head(A, B))


                        B = B + 1


                    ElseIf bPartNumber = True And heading = False Then

                        bPartNumber = False
                        PartsInLastStory = False




                    End If


                    Exit Select

            End Select



        End While


        ShowInfoToUser("Finished parsing all XML....")

    End Sub

    Private Sub LetsLookAtXML()

        'Lets Shuffle Throught Xml And See What Is What

        Dim A As Int16 = 0 ' This Counts THe Story
        Dim B As Int16 = 0 ' This counts The Parts In The Story



        'First, lets get variables ready that will indicate T or F if we have the proper Elements

        Dim HasHeading As Boolean = False
        Dim HasDescription As Boolean = False
        Dim HasPartNumber As Boolean = False
        Dim HasHeadAndPart As Boolean = False
        Dim HasApplication As Boolean = False
        Dim HasPartDescription As Boolean = False
        Dim HasBlueBold As Boolean = False
        Dim HasRedInfo As Boolean = False

        'Then We Have temp variables to hold the values until we count the number of parts

        Dim TempHead As String = ""
        Dim TempDescription As String = ""
        Dim TempSpecialNote As String = ""
        Dim TempApplication As String = ""
        Dim TempPartDescription As String = ""
        Dim TempBlueBold As String = ""
        Dim TempRedInfo As String = ""
        Dim TempPartNumber As String = ""

        Dim LastElement As String = "" 'What was the last element

        'This is our XML Reader
        Dim vlObj_XMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)

        Dim ELEM As String = ""



        'Start Reading Now

        While vlObj_XMLReader.Read()

            Select Case vlObj_XMLReader.NodeType()

                Case Xml.XmlNodeType.Element

                    ELEM = vlObj_XMLReader.Name.ToString


                    If ELEM = "Story" Then

                        A = A + 1 'We are on a new story


                    End If

                    If ELEM = "Head" Then

                        HasHeading = True


                    End If

                    If ELEM = "Description" Then

                        HasDescription = True


                    End If


                    If ELEM = "Application" Then



                    End If


            End Select


        End While





    End Sub

    Private Sub GoThroughImageXml()

        ShowInfoToUser("Finding Image Paths...")

        Dim A As Int16 = 0  'Keeps Track of Which Image We Are on

        Dim B As Int16 = 0 'Used when searching partnumbers later

        Dim C As Int16 = 0 'used for position of first '/' character
        Dim D As Int16 = 0   'Used for position of first "." character

        Dim Z As Int16 = 0





        Dim bImage As Boolean = False

        Dim XX As String = ""  'temperorary string that hold href path for image element

        Dim ZZ As String = "" 'Concacted href string value (This is value that will be saved to the final .TXT file for Excel import).  Basiclly this the path starting with "T:"




        'Set up XML reader object to read Images and paths
        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myFileName)


        While myXMLReader.Read()

            Select Case myXMLReader.NodeType()

                Case Xml.XmlNodeType.Element

                    If myXMLReader.Name.ToString = "Image" Then

                        A = A + 1

                        XX = myXMLReader.GetAttribute("href")



                        'We can clean up the next few lines... they have been spaced like this for debugging purposes....

                        ImagePath(A) = Trim(XX)

                        ZZ = Mid(XX, 9) 'Network drive path ***This may need to be changed if we go to a URI path***

                        ImageForPartNumber(A) = ZZ


                        'Clear out temp vars... not really necessary but may be if we convert this to C#

                        ZZ = ""

                        XX = ""

                    End If



            End Select




        End While

        ShowInfoToUser("Found Image paths...")

        'Now get Only the part number from the href string

        ShowInfoToUser("Extracting Part Number...")


        For Z = 1 To TotalImage




            XX = ImageForPartNumber(Z)

            C = InStrRev(XX, "/", -1)

            D = InStr(XX, ".")


            ShowInfoToUser("Part " + Str(Z))






            'ShowInfoToUser("Found the / character at position " + Str(C) + " and the . at pos" + Str(D))

            'ShowInfoToUser("From This String:   " + XX)

            'ShowInfoToUser("Length of String is:   " + Str(Len(XX)))

            ZZ = UCase(Mid(XX, C + 1, D - (C + 1)))



            'ShowInfoToUser("Part Number is: " + ZZ)

            PartNumberPicture(Z) = ZZ











        Next Z




        ShowInfoToUser("Got all part numbers...")



    End Sub

    Private Sub MatchPictureToPart()

        ShowInfoToUser("Matching Image path with proper part number...")


        'OK, let's get some temporary variables ready

        Dim A As Int16 = 0 'This is keeps track of the story we ar eon
        Dim B As Int16 = 0 'This keeps track of the part number in the story
        Dim C As Int16 = 0 'This keeps track of where we ar epointing to the Image path

        Dim D As Int16 = 0 'This keeps track of the total parts we are on

        Dim F As Int16 = 0 'This flags an occurance of the part number string in the path string

        Dim H As Int16 = 0 'This keeps track of how many parts an image was found for.  


        Dim WW As String = ""

        Dim XX As String = "" 'This hold the temporary string of the part number we are looking at
        Dim YY As String = ""
        Dim ZZ As String = ""

        Dim bPicFound As Boolean = False 'Was a path found for the current part number?




        'Start FOR/NEXT Loop To Check Each Found Part Number Path (This slows things down, but it's easy to find the proper part number pattern this way

        For C = 1 To TotalImage

            WW = PartNumberPicture(C)



            For A = 1 To TotalStory

                'Start inner FOR/NEXT For Each Part Of Story

                For B = 1 To PartsInStory(A)


                    XX = PartNumber(A, B)

                    'We have the striong we are looking for, now we must iterate through the image paths to find a match


                    If bPicFound = False And XX <> "" Then

                        F = XX.IndexOf(WW)

                    End If



                    If F > 0 And bPicFound = False Then


                        Picture(A, B) = ImageForPartNumber(C)

                        bPicFound = True



                    End If







                Next



            Next

            bPicFound = False


        Next


        ShowInfoToUser("Matched Image Path to proper part numbers...")







    End Sub

    Private Sub ClearForm()


        tbxProcess.Visible = True
        lblStatus.Text = "Done Parsing XML"

        butReadXML.Visible = False
        butSaveXML.Visible = True


    End Sub

    Private Sub butSaveXML_Click(sender As Object, e As EventArgs) Handles butSaveXML.Click

        'see if section has been changed



        'lblStatus.Text = "Saving XML File..."

        Dim myFileDIalog As New SaveFileDialog()

        'myFileDIalog.InitialDirectory = "C:\"

        myFileDIalog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

        myFileDIalog.FilterIndex = 1

        myFileDIalog.ShowDialog()

        If myFileDIalog.FileName = "" Then

            'butReadXML.Visible = False

            'lblStatus.Text = "No File Loaded"


        End If

        myFileName = myFileDIalog.FileName

        'lblStatus.Text = myFileName

        'butReadXML.Visible = True

        WriteNewXMLFile()



    End Sub

    Private Sub WriteNewXMLFile()

        'This function writes all data to a .txt file, delimited by the pipe ("|") character. ***I need to update this to write to a data table to save to Excel format*** July 2017

        Dim A As Int16 = 0
        Dim B As Int16 = 0

        Using sw As StreamWriter = New StreamWriter(myFileName)

            sw.WriteLine("Heading|Heading Description|Special Note|Application|Part Description|Blue Bold Info|Side|Picture|Scale|Part Number|Stock Number|Group Order|Section")

            For A = 1 To TotalStory

                For B = 1 To PartsInStory(A)

                    If Head(A, B) <> "" And PartNumber(A, B) <> "" Then

                        sw.WriteLine(Chr(34) + Head(A, B) + Chr(34) + "|" + Chr(34) + Description(A, B) + Chr(34) + "|" + Chr(34) + SpecialNote(A, B) + Chr(34) + "|" +
                                     Chr(34) + Application(A, B) + Chr(34) + "|" + Chr(34) + PartDescription(A, B) + Chr(34) + "|" +
                                 Chr(34) + BlueBoldInfo(A, B) + Chr(34) + "|" + Chr(34) + RedInformation(A, B) + Chr(34) + "|" + Chr(34) + Picture(A, B) + Chr(34) + "|" +
                                 Chr(34) + ImageScale(A, B) + Chr(34) + "|" + Chr(34) + PartNumber(A, B) + Chr(34) + "|" +
                                 Chr(34) + StockNumber(A, B) + Chr(34) + "|" + Chr(34) + Str(B) + Chr(34) + "|" + Chr(34) + Str(nudSection.Value) + Chr(34))

                    End If


                Next

            Next

        End Using


    End Sub

    Private Sub ShowInfoToUser(sender As String)

        Dim FF As String

        FF = Format(Now, "hh:mm:ss:fff")

        tbxProcess.AppendText(FF + "     " + sender + Chr(10))

    End Sub

    Private Sub OpenXMLFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenXMLFileToolStripMenuItem.Click


        Dim myFileDIalog As New OpenFileDialog()

        'myFileDIalog.InitialDirectory = "C:\"
        'Default to last used directory

        myFileDIalog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        myFileDIalog.FilterIndex = 1

        myFileDIalog.ShowDialog()

        If myFileDIalog.FileName = "" Then

            butReadXML.Visible = False

            lblStatus.Text = "No File Loaded"


        End If

        myFileName = myFileDIalog.FileName

        lblStatus.Text = myFileName

        butReadXML.Visible = True







    End Sub

    Private Sub XMLFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLFileToolStripMenuItem.Click

        lblStatus.Text = "Parsing XML..."
        tbxProcess.Visible = True
        tbxProcess.AppendText("Reading file...." + Chr(10))
        butLoadXMLFile.Visible = False


        Timer1.Enabled = True



    End Sub

    Private Sub nudSection_ValueChanged(sender As Object, e As EventArgs) Handles nudSection.ValueChanged

        ChgSec = True

    End Sub

    Private Sub Button_ListingOrder_Click(sender As Object, e As EventArgs)

        'Now we need to know what folder the IDML info is in.  That's what we do here.

        Dim myFolder As New FolderBrowserDialog()

        ' myFolder.RootFolder = "C:\Mikes Stuff\InDesign"

        myFolder.ShowDialog()


        myWorkingFolder = myFolder.SelectedPath

        ShowInfoToUser(myWorkingFolder)


    End Sub

    Private Sub Button_GetStoryOrder_Click(sender As Object, e As EventArgs)

        'OK Let's Get The Story Order
        'First we have to get the order from the designmap.xml file
        'We set up another XML reader

        Dim CompleteList As String = ""



        myDesignMapFile = myWorkingFolder + "\designmap.xml"


        Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(myDesignMapFile)


        While myXMLReader.Read()

            Select Case myXMLReader.NodeType()

                Case Xml.XmlNodeType.Element

                    If myXMLReader.Name.ToString = "Document" Then

                        CompleteList = myXMLReader.GetAttribute("StoryList")


                    End If



            End Select


        End While

        AllDesignMapStoryID = CompleteList

        ShowInfoToUser("Analizing designmap.xml....")

        'Go to the next step

        SortOutStories()




    End Sub

    Private Sub SortOutStories()

        'First we have to parse the designmap string to get each ID.  This will also be the way we figure the redimensiond array

        Dim Z As Int16 = 1 'Counter
        Dim G As Int16 = 1 'Character Number we are on
        Dim J As Int16 = 1 'Character Of Next space
        Dim K As Int16 = 1 'Total length of string
        Dim M As Int16 = 1 'Characters left
        Dim Done As Boolean = False



        Dim ID As String = "" '4 or 5 digit hexcode for story ID

        '***Very Sloppy Routine.... This Needs To Be Cleaned Up

        K = Len(AllDesignMapStoryID)

        While Done = False

            J = InStr(G, AllDesignMapStoryID, " ")

            If J = 0 Then

                Done = True

            End If

            G = J + 1

            Z = Z + 1

        End While

        'After we loop, we redim our story codes and go at it again

        ReDim StoryCode(Z)
        ReDim StoryIDHeads(Z, 1)

        Done = False
        J = 1
        Z = 1
        G = 1

        'Now We reloop and assign IDs To Each Story

        While Done = False

            J = InStr(G, AllDesignMapStoryID, " ")

            If J = 0 Then

                Exit While

            End If


            ID = Mid(AllDesignMapStoryID, G, J - G)


            StoryCode(Z) = ID

            ID = ""


            G = J + 1 'New Starting number
            Z = Z + 1 'increment Counter



        End While

        ShowInfoToUser(Str(Z) + " Id's found")

        FindStoryHeads()



    End Sub

    Private Sub FindStoryHeads()

        'Now we need to see what the HEAD is for each story but looking at each of them
        'So we need to see how many files are in the folder "Stories" first


        Dim FolderLookingIn As String

        Dim Z = 1 ' Counter




        'Set to look inside the Stories for all listings of files

        FolderLookingIn = myWorkingFolder + "\Stories\"

        Dim FileNames = Directory.GetFiles(FolderLookingIn)

        Dim FileNameArray As New ArrayList()

        For Each NameOfFile As String In FileNames

            FileNameArray.Add(NameOfFile)

            Z = Z + 1

        Next

        ReDim FileNameByStoryID(Z)
        ReDim StoryIDHeads(Z, 1)

        TotalStoryFileNames = Z

        Dim X = 1

        For Each NameOfFile As String In FileNames

            FileNameByStoryID(X) = NameOfFile.ToString

            X = X + 1

        Next

        GetInfoFromEachStoryFile()

    End Sub

    Private Sub GetInfoFromEachStoryFile()

        Dim TempStoryID As String
        Dim TempParagraphStyle As String = ""
        Dim TempStoryHead As String = ""
        Dim TempHeadContent As String = ""
        Dim LastElement As String = ""
        Dim ContentHead As Boolean = False
        Dim FoundHead As Boolean = False
        Dim vStr_Content As String = ""



        Dim I As Int16 = 0




        For I = 1 To TotalStoryFileNames

            Dim myXMLReader As Xml.XmlReader = Xml.XmlReader.Create(FileNameByStoryID(I))

            While myXMLReader.Read()


                Select Case myXMLReader.NodeType()

                    Case Xml.XmlNodeType.Element


                        If myXMLReader.Name.ToString = "Story" Then
                            TempStoryID = myXMLReader.GetAttribute("Self")
                            StoryIDCol(I) = TempStoryID
                        End If

                        If myXMLReader.Name.ToString = "ParagraphStyleRange" Then
                            TempParagraphStyle = myXMLReader.GetAttribute("AppliedParagraphStyle")
                            If TempParagraphStyle = "ParagraphStyle/Head" Then
                                FoundHead = True
                                LastElement = "Head"
                            End If
                        End If

                        If myXMLReader.Name.ToString = "Content" And FoundHead = True And LastElement = "Head" Then
                            ContentHead = True
                        End If

                    Case Xml.XmlNodeType.Text

                        If ContentHead = True Then

                            vStr_Content = myXMLReader.Value.ToString
                            StoryHeadCol(I) = vStr_Content
                            ContentHead = False
                            LastElement = ""
                            FoundHead = False
                        End If
                End Select
            End While
        Next

        MatchHeadWithID()


    End Sub

    Private Sub MatchHeadWithID()

        'Now we match the head with the ID






    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        Form_PicData.Show()


    End Sub

    Private Sub MatchPartsToImages()

        Dim A As Int16 = 0
        Dim B As Int16 = 0
        Dim I As Int16 = 0
        Dim ZZ As String = ""
        Dim KK As String = ""
        Dim C As Int16 = 0
        Dim F As Int16 = 0

        F = Form_PicData.ImageTotal


        For I = 1 To F



            KK = Form_PicData.ImageToPart(I)

            For A = 1 To TotalStory

                For B = 1 To PartsInStory(A)

                    ZZ = PartNumber(A, B)

                    C = InStr(ZZ, KK)

                    If C > 1 And ZZ <> "" And KK <> "" Then

                        Picture(A, B) = Mid(Form_PicData.ImageLink(I), 6)
                        ImageScale(A, B) = Mid(Form_PicData.ImageTrans(I), 2)


                    End If




                Next

            Next


        Next


        For A = 1 To TotalStory

            For B = 1 To PartsInStory(A)


                ShowInfoToUser(Picture(A, B))



            Next


        Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        MatchPartsToImages()



    End Sub
End Class
