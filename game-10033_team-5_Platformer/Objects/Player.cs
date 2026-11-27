using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player(Vector2 _spawn_pos)
    {
        Vector2 spawn_pos = _spawn_pos;
        Vector2 position = new Vector2(0f, 0f); // The current position of player on the map
        const float SIZE = 10f; // Size of player box
        const float MAX_Y_FORCE = 600f; // The max falling speed (pixels per second)
        const float MAX_X_FORCE = 200f; // The max horizontal speed (pixels per second)
        public float x_accel = 1200f; // How fast the player speeds up with input
        public float x_deccel = 1600f; // How fast the player slows down without input
        public float grav_accel = 900f; // How fast the player falls in the air
        public float jump_force = 350f;
        public float ground_y = 300f; // Temporary floor until collision is added
        public Vector2 vel = new Vector2(0f, 0f); // The current velocity of the player

        public void Setup()
        {
            position = spawn_pos;
            vel = Vector2.Zero;
        }
        public void Update(float deltaTime) // runs every frame
        {
            FixedUpdate(deltaTime);

            // Draw after moving so the rectangle matches the new position
            Draw.FillColor = Color.White;
            Draw.Rectangle(position.X, position.Y, SIZE, SIZE);

            // Temporary floor line
            Draw.LineColor = Color.White;
            Draw.Line(0, ground_y + SIZE, Window.Width, ground_y + SIZE);
        }
        // Physics calculations
        void FixedUpdate(float deltaTime)
        {
            Apply_Grav(deltaTime);

            // Update player position
            position += vel * deltaTime;

            // Stop at the floor
            if (position.Y > ground_y)
            {
                position.Y = ground_y;
                vel.Y = 0;
            }
        }
        void Apply_Grav(float deltaTime)
        {
            if (!Is_Grounded())
            {
                vel.Y += grav_accel * deltaTime;
                vel.Y = Math.Min(vel.Y, MAX_Y_FORCE); // Clamp falling speed
            }
            else if (vel.Y > 0)
            {
                vel.Y = 0;
            }
        }
        public void Jump()
        {
            if (Is_Grounded())
            {
                vel.Y = -jump_force;
            }
        }
        public bool Is_Grounded()
        {
            return position.Y >= ground_y; // Replace with real collision later
        }
    }
}