using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Player (Vector2 _spawn_pos)
    {
        Vector2 spawn_pos = _spawn_pos;
        Vector2 position = new Vector2(0f, 0f); // The current position of player on the map
        const float MAX_Y_FORCE = 10f; // The max vertical speed
        const float MAX_X_FORCE = 10f; // The max horizontal speed
        public float x_accel = 0.3f; // How fast the player speeds up without input
        public float x_deccel = 0.4f; // How fast the player slows down without input
        public float grav_accel = 0.3f; // How fast the player falls in the air
        
        public float jump_force = 10f;
        public float move_input = 0f;
        public bool jump_input = false;


        public Vector2 vel = new Vector2(0f, 0f); // The current velocity of the player

        public void Setup()
        {
            position = spawn_pos;
            vel = Vector2.Zero;
        }

        public void Update(float deltaTime) // runs every frame
        {
            Draw.FillColor = Color.White;
            Draw.Rectangle(position.X, position.Y, 10f, 10f);
            FixedUpdate(deltaTime);
        }

        // Physics calculations
        void FixedUpdate(float deltaTime)
        {
            Apply_Grav(deltaTime);

            // Update player position
            position += vel * deltaTime;
        }

        void Apply_Grav(float deltaTime)
        {
            if (!Is_Grounded())
            {
                vel.Y += grav_accel * deltaTime;

                // Clamp falling speed
                vel.Y = Math.Min(vel.Y, MAX_Y_FORCE);
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
            return true; // To be finished later once collision is added
        }

    }
}
