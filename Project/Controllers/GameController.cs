using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool _running = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {

      _gameService.PrintStartup();
      while (_running)

      {
        PrintMessages();
        GetUserInput();
      }


    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      switch (command)
      {
        case "go":
          _gameService.Go(option);
          PrintMessages();

          break;

        case "inventory":
          _gameService.Inventory();
          PrintMessages();
          Console.ReadKey();
          Console.Clear();
          System.Console.WriteLine();

          break;
        case "quit":
          System.Console.WriteLine("are you sure you want to quit?");
          if (!Console.ReadLine().StartsWith("N", StringComparison.OrdinalIgnoreCase))
          {
            System.Console.WriteLine("Bye-Bye");


            Quit();
          }
          break;

        case "look":
          _gameService.Look();
          PrintMessages();
          break;


        case "take":
          _gameService.TakeItem(option);
          PrintMessages();

          break;
        case "use":
          _gameService.UseItem(option);
          PrintMessages();

          break;

        case "help":
          _gameService.Help();
          PrintMessages();
          Console.ReadKey();
          Console.Clear();
          break;


        default:
          System.Console.WriteLine("Invalid input please type something else");

          break;
      }

    }

    //NOTE this should print your messages for the game.
    private void PrintMessages()
    {
      foreach (string message in _gameService.Messages)
      {
        System.Console.WriteLine(message);

      }
      _gameService.Messages.Clear();
    }

    public void Quit()
    {
      _running = false;
    }

  }
}