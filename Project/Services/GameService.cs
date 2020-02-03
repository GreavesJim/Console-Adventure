using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void PrintStartup()
    {
      Messages.Add("");
      Messages.Add("You wake in a seemingly plain room and you don't know who you are or why you're here. You see a piece of paper pinned to your shirt that reads Player 1");
      Messages.Add("");
      Help();
      Messages.Add("");
    }

    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction) && !_game.CurrentRoom.NeedCandle == true)
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        Messages.Add($"{_game.CurrentRoom.Description}");
      }
      if (_game.CurrentRoom.Exits.ContainsKey(direction) && _game.CurrentRoom.NeedCandle == true)
      {

      }
      else
      {
        Messages.Add("You stumble and feel like you are falling forever");
        Messages.Add("Would you like to play again?");

      }
    }
    public void Help()
    {
      Messages.Add("Type 'go' and 'east' or 'west' to move rooms");
      Messages.Add("Type 'inventory' to view your items");
      Messages.Add("Type 'look' to look around");
      Messages.Add("Type 'quit' to quit the game");
      Messages.Add("Type 'take' and the item to add an item to your inventory");
      Messages.Add("Type 'use' and the item to use an item");
      Messages.Add("press any to continue");

    }

    public void Inventory()
    {
      Messages.Add("------------YOUR INVENTORY------------");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name}");
      }
      Messages.Add("press any key to return");
    }

    public void Look()
    {
      Messages.Add($"{_game.CurrentRoom.Description}");
    }


    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        if (itemName == _game.CurrentRoom.Items[i].Name)
        {
          var removed = _game.CurrentRoom.Items[i];
          _game.CurrentRoom.Items.Remove(removed);
          _game.CurrentPlayer.Inventory.Add(removed);
          Messages.Add($"You've added {removed.Name} to your inventory");
        }
        else
        {
          Messages.Add("Looks like its not there");
        }


      }

    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        if (itemName == _game.CurrentPlayer.Inventory[i].Name)
        {
          if (_game.CurrentPlayer.Inventory[i].Name == "candle")
          {
            _game.CurrentPlayer.Inventory[i].Lit = true;
            Messages.Add("You have lit the candle");
          }


        }
        {

        }

      }
    }
  }
}