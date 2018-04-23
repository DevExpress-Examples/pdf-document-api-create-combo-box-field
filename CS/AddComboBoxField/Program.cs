using DevExpress.Pdf;
using System.Drawing;


namespace AddComboBoxField {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw a combo box field.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawComboBoxField(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawComboBoxField(PdfGraphics graphics) {

            // Create a combo box field specifying its name and location.
            PdfGraphicsAcroFormComboBoxField comboBox = new PdfGraphicsAcroFormComboBoxField("combo Box", new RectangleF(20, 20, 100, 20));

            // Add values to the combo box.  
            comboBox.AddValue("Red");
            comboBox.AddValue("Yellow");
            comboBox.AddValue("Green");
            comboBox.AddValue("Blue");

            // Specify combo box selected value, text allignment, and appearance.
            comboBox.SelectValue("Red");
            comboBox.TextAlignment = PdfAcroFormStringAlignment.Far;
            comboBox.Appearance.BackgroundColor = Color.Beige;
            comboBox.Appearance.FontSize = 14;
            
            // Add the field to the document.
            graphics.AddFormField(comboBox);
        }
    }
}
