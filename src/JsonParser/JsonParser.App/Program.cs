using System.Text;

namespace JsonParser.App;

internal class Program
{
    static void Main(string[] args)
    {
        String? line;
        StringBuilder sb = new("");
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("" +
                "D:\\Projects\\Interviews\\CodingChallenges" +
                "\\src\\JsonParser\\JsonParser.App" +
                "\\Inputs\\step1\\invalid.json");

            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                sb.AppendLine(line);
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            Console.WriteLine(IsValid(sb.ToString()));
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    static int IsValid(String? content)
    {
        if (string.IsNullOrEmpty(content))
            return 1;

        Stack<char> stck = new();
        foreach (char c in content.ToCharArray())
        {
            if (c.Equals('{'))
            {
                stck.Push(c);
            }
            else if (c.Equals('}'))
            {
                if (stck.Peek() == '{')
                {
                    stck.Pop();
                }
                else
                    return 1;
            }
        }
        return stck.Count() == 0 ? 0 : 1;
    }
}
