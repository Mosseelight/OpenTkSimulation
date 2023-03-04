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
            GL.Clear(ClearBufferMask.ColorBufferBit);




            SwapBuffers();
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.4f, 0.8f, 0.9f, 1f);
        }




    
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}