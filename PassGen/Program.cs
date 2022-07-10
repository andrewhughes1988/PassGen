using System.CommandLine;
using PassGen;


byte defaultPasswordLength = 20;

//Setting up the command line arguments, options, and help system
var rootCommand = new RootCommand("A simple Command-Line password generator");
var lengthOption = new Option<byte>(
    name: "--length",
    description: "Enter the password length you want to generate.\n" +
                 "Must be a positive integer from 0 - 255",
    getDefaultValue: () => defaultPasswordLength);

lengthOption.AddAlias("-l");
rootCommand.Add(lengthOption);

rootCommand.SetHandler((byte lengthOptionValue) =>
{
    Console.WriteLine(Generator.Generate(length: lengthOptionValue));
}, 
lengthOption);

rootCommand.Invoke(args);
