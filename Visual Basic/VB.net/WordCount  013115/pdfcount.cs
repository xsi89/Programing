using System;

public class Class1
{
	public Class1()
	{
        FileStream fs = new FileStream(@"c:\a.pdf", FileMode.Open, FileAccess.Read);
        StreamReader r = new StreamReader(fs);
        string pdfText = r.ReadToEnd();
	}
}
