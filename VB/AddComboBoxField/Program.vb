Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddComboBoxField

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document. 
                processor.CreateEmptyDocument("..\..\Result.pdf")
                ' Create graphics and draw a combo box field.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawComboBoxField(graphics)
                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawComboBoxField(ByVal graphics As PdfGraphics)
            ' Create a combo box field specifying its name and location.
            Dim comboBox As PdfGraphicsAcroFormComboBoxField = New PdfGraphicsAcroFormComboBoxField("combo Box", New RectangleF(20, 20, 100, 20))
            ' Add values to the combo box.  
            comboBox.AddValue("Red")
            comboBox.AddValue("Yellow")
            comboBox.AddValue("Green")
            comboBox.AddValue("Blue")
            ' Specify combo box selected value, text allignment, and appearance.
            comboBox.SelectValue("Red")
            comboBox.TextAlignment = PdfAcroFormStringAlignment.Far
            comboBox.Appearance.BackgroundColor = Color.Beige
            comboBox.Appearance.FontSize = 14
            ' Add the field to the document.
            graphics.AddFormField(comboBox)
        End Sub
    End Class
End Namespace
