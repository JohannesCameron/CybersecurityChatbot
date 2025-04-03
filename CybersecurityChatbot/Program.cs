using System;
using System.Media;
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
  }

  static void PlayVoiceGreeting()
  {
    try
    {
      SoundPlayer player = new SoundPlayer("greeting.wav");
      player.Play();
    }
    catch (Exception ex)
    {
      Console.WriteLine("(Voice Greeting Error:" + ex.Message + ")");
    }
  }

  static void DisplayAsciiLogo()
  {
    Console.WriteLine(@"
     _   _            _        _           _ _       _
    | | | |          (_)      | |         | (_)     | |
    | |_| |__   __ _ _ _ __   _| |_ ___  __ _ _ _ __ _| |_ ___
    | __| '_ \ / _` | | '_ \ | | __/ _ \/ _` | | '__| | __/ _ \
    | |_| | | | (_| | | | | | | ||  __/ (_| | | |  | | ||  __/
    \__|_| |_|\__,_|_|_| |_|_|\__\___|\__,_|_|_|  |_|___\___|");
    Console.WriteLine("\n=================================================");
  }
}
