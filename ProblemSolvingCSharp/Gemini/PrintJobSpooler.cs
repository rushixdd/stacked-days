namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class PrintJobSpooler
{
    public class Printer
    {
        private readonly Queue<string> printerQueue = new Queue<string>();

        public void AddJob(string documentName)
        {
            printerQueue.Enqueue(documentName);
        }

        public string ProcessNextJob()
        {
            if (printerQueue.Count > 0) { 
                return printerQueue.Dequeue();
            }
            return null;
        }
    }
    [TestMethod]
    public void Printer_ProcessesJobs_In_FIFO_Order()
    {
        // Arrange
        var printer = new Printer();
        printer.AddJob("DocumentA.pdf");
        printer.AddJob("Spreadsheet.xlsx");
        printer.AddJob("Presentation.pptx");

        // Act & Assert
        Assert.AreEqual("DocumentA.pdf", printer.ProcessNextJob());
        Assert.AreEqual("Spreadsheet.xlsx", printer.ProcessNextJob());
        Assert.AreEqual("Presentation.pptx", printer.ProcessNextJob());

        // Act & Assert
        Assert.IsNull(printer.ProcessNextJob());
    }
}
