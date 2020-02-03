using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()

    {
      string Room2desc = "in thes room there is a flicker of light from a set of candles eminating from a table. There is a passage way east and a hallway to the west";



      Room Room1 = new Room("Room 1", "This room doesnt appear to have anything of relevence inside. There is a hallway to the east.", false);
      Room Room2 = new Room("Room 2", Room2desc, false);
      Room Room3 = new Room("Room 3", "this is room 3", true);
      Room Room4 = new Room("Room 4", "this is room 4", false);

      Room1.Exits.Add("east", Room2);
      Room2.Exits.Add("east", Room3);
      Room2.Exits.Add("west", Room1);
      Room3.Exits.Add("east", Room4);
      Room3.Exits.Add("west", Room2);
      Room4.Exits.Add("west", Room3);






      Player Player1 = new Player("player");

      Room2.Items.Add(new Candle("candle", "its a candle"));


      CurrentPlayer = Player1;

      CurrentRoom = Room1;




    }



    public Game()
    {
      Setup();
    }
  }
}