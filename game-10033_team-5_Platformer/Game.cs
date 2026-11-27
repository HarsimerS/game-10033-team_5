// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Spawn position of the player once game starts
        Player player = new Player(new Vector2(320, 180));

        public void Setup()
        {
            Window.SetSize(640, 360);
            Window.SetTitle("Platformer");
            player.Setup();
        }

        public void Update()
        {
            Window.ClearBackground(Color.Black);
            player.Update(Time.DeltaTime);
        }
    }

}
