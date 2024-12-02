// Path to the input and output files
using System.Text.RegularExpressions;

string inputFilePath = @"D:\KSP_SKLDemo\set\Chin\message.ini";
string outputFilePath = @"D:\KSP_SKLDemo\set\Chin\message_output.txt";

// Regular expression to match Chinese characters
string pattern = @"[\u4e00-\u9fff]+";

try
{
    // Read all lines from the input file
    string[] lines = File.ReadAllLines(inputFilePath);

    // Open the output file for writing
    using (StreamWriter writer = new StreamWriter(outputFilePath))
    {
        writer.WriteLine("Chinese Characters Extraction Results");
        writer.WriteLine("===================================");
        writer.WriteLine();

        int lineNumber = 1;
        foreach (string line in lines)
        {
            // Find all Chinese characters in the current line
            MatchCollection matches = Regex.Matches(line, pattern);

            // If there are any matches, write them to the output file
            if (matches.Count > 0)
            {
                writer.WriteLine($"Line {lineNumber}:");
                string chineseText = string.Join(" ", matches);
                writer.WriteLine(chineseText);
                writer.WriteLine(); // Add a blank line for better readability
            }

            lineNumber++;
        }
    }

    Console.WriteLine($"Processing complete. Results have been written to {outputFilePath}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}