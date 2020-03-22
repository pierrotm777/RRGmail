﻿Imports System.Globalization
Imports System.Threading
Imports System.Speech.Recognition
Imports System.Speech
Imports System.Collections.Generic

'Imports System.Speech.Synthesis
'Imports System.Media

'Public Class CultureInformation : Inherits MarshalByRefObject
'    Public Function ShowCurrentCultureInfo() As String
'        Return CultureInfo.CurrentCulture.Name
'        'Return CultureInfo.CurrentUICulture.EnglishName
'    End Function
'End Class

Public Class ClassSpeechRecognition
    'speech recognition
    Dim WithEvents reco As SpeechRecognitionEngine

    'Public Event MobilePhoneSeepchRecognitionIsON()


    Public Sub New()
        Try
            'MsgBox(inf.ShowCurrentCultureInfo())
            'Initialize an in-process speech recognition engine and set its input.
            'reco = New SpeechRecognitionEngine(New System.Globalization.CultureInfo(inf.ShowCurrentCultureInfo()))
            reco = New SpeechRecognitionEngine()
            reco.SetInputToDefaultAudioDevice()

            'Initialize an in-process speech synthesizer engine and set its output.
            'synth = New SpeechSynthesizer()
            'synth.SetOutputToDefaultAudioDevice()
            'player = New SoundPlayer

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#Region "Speech Recognition Standard"
    Public Sub SpeechProcessing_Load()
        '' Create the "yesno" grammar.
        'Dim yesChoices As New Choices(New String() {"oui", "yup", "yeah"})
        'Dim yesValue As New SemanticResultValue(yesChoices, CBool(True))

        'Dim noChoices As New Choices(New String() {"non", "nope", "neah"})
        'Dim noValue As New SemanticResultValue(noChoices, CBool(False))

        'Dim yesNoKey As New SemanticResultKey("yesno", New Choices(New GrammarBuilder() {yesValue, noValue}))
        'Dim yesnoGrammar As New Grammar(yesNoKey)
        'yesnoGrammar.Name = "ouiNon"

        ' Create the "Phone Dictionnary" grammar.
        'SpeechArray = {"zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "plus", "étoile", "dièze", "effacer", "annuler", "appeler", "stop appel", "aide appel"}
        'SpeechArray = TempPluginSettings.PhoneSpeechNumbers.Split(",")
        'Dim phoneGrammar As New Grammar(New Choices(New String() {"zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "plus", "étoile", "dièze", "effacer", "annuler", "appeler", "stop appel", "help call"}))

        'Dim PhoneWords As New Choices(SpeechArray)
        'Dim phoneGrammar As New Grammar(PhoneWords)
        'phoneGrammar.Name = "Phone Dictionnary"

        ''Read the Names from the Phone Book as array
        'ContactNameListToArray()
        'Dim PhoneNames As New Choices(PhoneBookNameArray)

        '' Build the phrase and add SemanticResultKeys.
        'Dim chooseContactByName As New GrammarBuilder()
        'chooseContactByName.Append(SpeechArray(15)) 'appeler
        'chooseContactByName.Append(SpeechArray(18)) 'par nom
        'chooseContactByName.Append(PhoneNames)

        'chooseContactByName.Append(New SemanticResultKey("contact", PhoneNames)) 'nom du contact


        ' Build a Grammar object from the GrammarBuilder.
        'Dim ContactGrammar As New Grammar(chooseContactByName)
        'ContactGrammar.Name = "PhoneName Dictionnary"

        ' Create a free text dictation grammar.
        Dim dictation As Grammar = New DictationGrammar()
        dictation.Name = "Dictation"

        ' Load grammars to the recognizer.
        'reco.LoadGrammarAsync(yesnoGrammar)
        reco.LoadGrammarAsync(dictation)
        'reco.LoadGrammarAsync(phoneGrammar)
        'reco.LoadGrammarAsync(ContactGrammar)

        ' Start asynchronous, continuous recognition.
        reco.RecognizeAsync(RecognizeMode.Multiple)

        'RR event
        'RaiseEvent MobilePhoneSeepchRecognitionIsON()
    End Sub


    Public Sub SpeechProcessing_Stop()
        reco.RecognizeAsyncCancel()
        SpeechRecognitionIsActive = False
        SpeechRecognitionSentenceIs = ""

        'RR event
        'RaiseEvent MobilePhoneSeepchRecognitionIsOFF()
    End Sub

    Private Sub recognizer_LoadGrammarCompleted(sender As Object, e As LoadGrammarCompletedEventArgs) Handles reco.LoadGrammarCompleted
        Dim grammarName As String = e.Grammar.Name
        Dim grammarLoaded As Boolean = e.Grammar.Loaded
        If e.[Error] IsNot Nothing Then
            ' Add exception handling code here.
            SpeechRecognizedIs = "LoadGrammar for " & grammarName & " failed with a " & e.[Error].[GetType]().Name & "."
        Else
            SpeechRecognitionIsActive = True
            SpeechRecognitionSentenceIs = ""
        End If

        SpeechRecognizedIs = ("Grammar " & grammarName & " " & If((grammarLoaded), "Is", "Is Not") & " loaded !")
    End Sub

    'Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
    '    Try
    '        SpeechRecognizedIs = "Grammar " & e.Result.Grammar.Name & " --> " & e.Result.Text '& " " & e.Result.Words.Item(1).Text

    '        Select Case e.Result.Text
    '            Case SpeechArray(0)
    '                SpeechRecognitionSentenceIs += "0"
    '            Case SpeechArray(1)
    '                SpeechRecognitionSentenceIs += "1"
    '            Case SpeechArray(2)
    '                SpeechRecognitionSentenceIs += "2"
    '            Case SpeechArray(3)
    '                SpeechRecognitionSentenceIs += "3"
    '            Case SpeechArray(4)
    '                SpeechRecognitionSentenceIs += "4"
    '            Case SpeechArray(5)
    '                SpeechRecognitionSentenceIs += "5"
    '            Case SpeechArray(6)
    '                SpeechRecognitionSentenceIs += "6"
    '            Case SpeechArray(7)
    '                SpeechRecognitionSentenceIs += "7"
    '            Case SpeechArray(8)
    '                SpeechRecognitionSentenceIs += "8"
    '            Case SpeechArray(9)
    '                SpeechRecognitionSentenceIs += "9"
    '            Case SpeechArray(10)
    '                SpeechRecognitionSentenceIs += "+"
    '            Case SpeechArray(11)
    '                SpeechRecognitionSentenceIs += "*"
    '            Case SpeechArray(12)
    '                SpeechRecognizedIs += "#"
    '            Case SpeechArray(13) 'effacer
    '                SpeechRecognitionSentenceIs = SpeechRecognitionSentenceIs.Remove(SpeechRecognitionSentenceIs.Length - 1)
    '            Case SpeechArray(14) 'annuler
    '                SpeechRecognitionSentenceIs = ""
    '            Case SpeechArray(15) 'appeler
    '                RaiseEvent MobilePhoneSeepchDial()
    '            Case SpeechArray(16) 'stop appel
    '                RaiseEvent MobilePhoneSeepchHangup()
    '            Case SpeechArray(17) 'aide appel
    '                RaiseEvent MobilePhoneSeepchHelp()
    '                'Case SpeechArray(18) 'appel par nom
    '                'CallByNameResult = e.Result.Text.Replace(SpeechArray(18), "").Trim
    '                'MsgBox(e.Result.Text) '.Replace(SpeechArray(18), "").Trim)
    '                'RaiseEvent MobilePhoneSeepchDialByName()

    '            Case SpeechArray(19) 'supplement 1
    '                RaiseEvent MobilePhoneSeepchSupp1()
    '            Case SpeechArray(20) 'supplement 2
    '                RaiseEvent MobilePhoneSeepchSupp2()
    '            Case SpeechArray(21) 'supplement 3
    '                RaiseEvent MobilePhoneSeepchSupp3()

    '                'Case Else
    '                '    MsgBox(e.Result.Text)
    '        End Select

    '    Catch ex As Exception
    '        SpeechToNumberError = ex.Message '& " " & ex.InnerException.ToString '"SpeechHypothesized --> " & e.Result.Text
    '    End Try
    'End Sub

    Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
        SpeechRecognizedIs = "Grammar " & e.Result.Grammar.Name & " --> " & e.Result.Text '& " " & e.Result.Words.Item(1).Text
        MsgBox(SpeechRecognizedIs)
    End Sub

    'Private Sub recognizer_SpeechDetected(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechDetectedEventArgs) Handles reco.SpeechDetected
    '    SpeechToNumberError = "SpeechDetected --> " & e.AudioPosition.ToString
    '    'SDK.SetUserVar("MOBILEPHONE_SPEECHRECOGNIZED", "speech detected")
    'End Sub

    'Private Sub recognizer_SpeechHypothesized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechHypothesized
    '    SpeechToNumberError = "SpeechHypothesized --> " & e.Result.Text
    'End Sub

    'Private Sub recognizer_SpeechRecognitionRejected(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognitionRejected
    '    SpeechToNumberError = "SpeechRecognitionRejected --> " & e.Result.Text
    '    'SDK.SetUserVar("MOBILEPHONE_SPEECHRECOGNIZED", "recognition rejected")
    'End Sub


#End Region

    Public Sub unload()
        reco.Dispose()
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        unload()
    End Sub

End Class
