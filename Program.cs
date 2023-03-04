using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTkSim
{
    public class Game : GameWindow
    {

        //settings for the game
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() 
        { Size = (width, height), Title = title }) { }

        static void Main(string[] args)
        {
            //create game instance
            using (Game game = new Game(1280, 720, "Simulation"))
            {
                game.Run();
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    }
}