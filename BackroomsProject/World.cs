using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BackroomsProject
{
    internal class World
    {
        private SpriteBatch spriteBatch;
        private Random random;
        private int[,] mazeGrid; // 0 = wall, 1 = hallway, 2 = room
        private int width, height;
        private int tileSize = 64; // size of each tile for rendering

        public World(SpriteBatch spriteBatch, int seed, int worldX, int worldY)
        {
            this.spriteBatch = spriteBatch;
            this.random = new Random(seed);
            this.width = worldX;
            this.height = worldY;

            GenerateMaze();
        }

        // Generates a maze-like structure with rooms and hallways
        private void GenerateMaze()
        {
            mazeGrid = new int[width, height];

            // Simple random walk algorithm for now, you can replace it with a more sophisticated one
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Randomly determine if this is a hallway (1) or a wall (0)
                    mazeGrid[x, y] = random.Next(0, 100) < 70 ? 1 : 0;

                    // Create rooms (larger open areas)
                    if (x % 10 == 0 && y % 10 == 0)
                    {
                        CreateRoom(x, y);
                    }
                }
            }
        }

        // Carve out a room at the specified location
        private void CreateRoom(int startX, int startY)
        {
            int roomWidth = random.Next(3, 6);
            int roomHeight = random.Next(3, 6);

            for (int y = startY; y < startY + roomHeight && y < height; y++)
            {
                for (int x = startX; x < startX + roomWidth && x < width; x++)
                {
                    mazeGrid[x, y] = 2; // 2 represents a room
                }
            }
        }

        // Draw the maze grid
        public void Draw(Texture2D wallTexture, Texture2D hallwayTexture, Texture2D roomTexture)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector2 position = new Vector2(x * tileSize, y * tileSize);

                    if (mazeGrid[x, y] == 0)
                    {
                        // Wall
                        spriteBatch.Draw(wallTexture, position, Color.White);
                    }
                    else if (mazeGrid[x, y] == 1)
                    {
                        // Hallway
                        spriteBatch.Draw(hallwayTexture, position, Color.White);
                    }
                    else if (mazeGrid[x, y] == 2)
                    {
                        // Room
                        spriteBatch.Draw(roomTexture, position, Color.White);
                    }
                }
            }
        }
    }
}
