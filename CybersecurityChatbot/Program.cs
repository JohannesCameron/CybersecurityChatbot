using System;
using System.Media;
using NAudio.Wave;
using System.Threading;

class CyberSecurityChatBot
{
  static void Main()
  {
    //voice greeting
    PlayVoiceGreeting();

    //ASCII logo
    DisplayAsciiLogo();

    //getting and using users name for personal interactoion
    Console.Write("Please enter your name: ");
    string userName = Console.ReadLine();
    Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot.\n");

    //chat loop
    while(true)
    {
      Console.Write("Ask me a question about cybersecurity: ");
      string userInput = Console.ReadLine().ToLower();

      if (string.IsNullOrWhiteSpace(userInput))
      {
        Console.WriteLine("Input cannot be empty, please ask a question.");
        continue;
      }

      ProcessUserInput(userInput);
    }
  }

  static void PlayVoiceGreeting()
  {
    try
    {
      using(var audioFile = new AudioFileReader("greeting.wav"))
      using(var outputDevice = new WaveOutEvent())
      {
        outputDevice.Init(audioFile);
        outputDevice.Play();
        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
          Thread.Sleep(500);
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("(Voice Greeting Error:" + ex.Message + ")");
    }
  }

  static void DisplayAsciiLogo()
  {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
     _   _            _        _           _ _       _
    | | | |          (_)      | |         | (_)     | |
    | |_| |__   __ _ _ _ __   _| |_ ___  __ _ _ _ __ _| |_ ___
    | __| '_ \ / _` | | '_ \ | | __/ _ \/ _` | | '__| | __/ _ \
    | |_| | | | (_| | | | | | | ||  __/ (_| | | |  | | ||  __/
    \__|_| |_|\__,_|_|_| |_|_|\__\___|\__,_|_|_|  |_|___\___|");
    Console.ResetColor();
    Console.WriteLine("\n=================================================");
  }

  static void ProcessUserInput(string input)
  {
    switch (input)
    {
      case "how are you?":
        TypeEffect("I'm just a bot, but I'm here to help you stay safe online!");
        break;
      case "what's your purpose?":
        TypeEffect("I help users learn about cybersecurity threats and how to avoid them.");
        break;
      case "what can I ask you about?":
        TypeEffect("You can ask me about password safety, phishing, and safe browsing tips.");
        break;
      case "how do I create a strong password?":
        TypeEffect("Use a mix of upper and lowercase letters, numbers, and special characters.");
        break;
      case "what is phishing?":
        TypeEffect("Phishing is a type of scam where attackers trick you into giving personal inforation via fake emails or websites.");
        break;
      case "how can I browse safely":
        TypeEffect("Use HTTPS websites, don't click suspicus links, and keep your browser updated.");
        break;
      case "exit":
        TypeEffect("Goodbye! Stay safe online!");
        break;
      default:
        TypeEffect("I'm sorry, I didn't understand that question. Please try again.");
        break;
    }
  }

  static void TypeEffect(string message)
  {
    foreach (char c in message)
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    Console.WriteLine();
  }
}
