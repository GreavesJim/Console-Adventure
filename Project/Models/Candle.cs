using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Candle : Item, IItem
  {


    public Candle(string name, string description) : base(name, description)
    {

    }
  }
}