if (args[0] != "-E")
{
    Console.WriteLine("Expected first argument to be '-E'");
    Environment.Exit(2);
}

var pattern = args[1];
var inputLine = await Console.In.ReadToEndAsync();

// You can use print statements as follows for debugging, they'll be visible when running tests.
await Console.Error.WriteLineAsync("Logs from your program will appear here!");

// Uncomment this block to pass the first stage

if (MatchPattern(inputLine, pattern))
    Environment.Exit(0);
else
    Environment.Exit(1);

return;

static bool MatchPattern(string inputLine, string pattern)
{
    if (pattern.Length < 1) throw new ArgumentException($"Unhandled pattern: {pattern}");

    return pattern switch
    {
        "\\d" => inputLine.Any(char.IsDigit),
        "\\w" => inputLine.All(char.IsLetterOrDigit) || inputLine.Contains('_'),
        "d" => true,
        _ => false
    };
}