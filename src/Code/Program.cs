using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTkSim
{
    public class Game : GameWindow
    {


        float[] vertices = {
            0.5f,  0.5f, 0.0f,  
            0.5f, -0.5f, 0.0f,  
            -0.5f, -0.5f, 0.0f,  
            -0.5f,  0.5f, 0.0f   
        };

        int[] indices = 
        {
            0, 1, 3,
            1, 2, 3
        };

        //important stuff for vertices and gpu and whatever the hell
        int vertexBufferObject;
        int vertexArrayObject;
        int elementBufferObject;

        Shader shader;


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

        protected override void OnLoad()
        {
            base.OnLoad();

            vertexBufferObject = GL.GenBuffer();
            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            shader = new Shader("src/Shaders/defshader.vert", "src/Shaders/defshader.frag");
            shader.UseShader();

            GL.ClearColor(0.4f, 0.8f, 0.9f, 1f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            
            GL.Clear(ClearBufferMask.ColorBufferBit);
            shader.UseShader();
            GL.BindVertexArray(vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);



            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}