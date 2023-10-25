using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Threading;

namespace oda
{
    internal class Program : GameWindow
    {
            float angle;
            bool showCube = true;
            bool isRotating = false;
            KeyboardState lastKeyPress;
            Vector2 lastMousePosition;

            public Program() : base(800, 600)
            {
                VSync = VSyncMode.On;
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                GL.ClearColor(Color.BlueViolet);
                GL.Enable(EnableCap.DepthTest);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Alt + H");
                Console.ResetColor();
                Console.WriteLine(" pentru a ascunde/afisa cubul");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Left Mouse Button");
                Console.ResetColor();
                Console.WriteLine(" pentru a roti cubul");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nESC");
                Console.ResetColor();
                Console.WriteLine(" pentru a inchide programul");
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);

                GL.Viewport(0, 0, Width, Height);

                double aspect_ratio = Width / (double)Height;

                Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);

                KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
                MouseState mouse = OpenTK.Input.Mouse.GetState();

                if (keyboard[OpenTK.Input.Key.Escape])
                {
                    Exit();
                    return;
                }

                else if (keyboard.IsKeyDown(OpenTK.Input.Key.AltLeft) && keyboard.IsKeyDown(OpenTK.Input.Key.H) && !keyboard.Equals(lastKeyPress))
                {
                    if (showCube == true)
                    {
                        showCube = false;
                    }
                    else
                    {
                        showCube = true;
                    }
                }
                lastKeyPress = keyboard;

                if (mouse[OpenTK.Input.MouseButton.Left])
                {
                    if (!isRotating)
                    {
                        isRotating = true;
                        lastMousePosition = new Vector2(mouse.X, mouse.Y);
                    }
                    Vector2 currentMousePosition = new Vector2(mouse.X, mouse.Y);
                    Vector2 delta = currentMousePosition - lastMousePosition;
                    angle += delta.X;
                    lastMousePosition = currentMousePosition;
                }
                else
                {
                    isRotating = false;
                }
            }

            protected override void OnRenderFrame(FrameEventArgs e)
            {
                base.OnRenderFrame(e);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);

                GL.Rotate(angle, 1.0f, 1.0f, 1.0f);

                if (showCube == true)
                {
                    DrawCube();
                    DrawAxes();
                }

                SwapBuffers();
            }

            private void DrawAxes()
            {
                GL.Begin(PrimitiveType.Lines);

            // X
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(20, 0, 0);

                // Y
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 20, 0);

                // Z
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 20);


                GL.End();
            }

            private void DrawCube()
            {
                GL.Begin(PrimitiveType.Quads);

                GL.Color3(Color.ForestGreen);
                GL.Vertex3(-1.0f, -1.0f, -1.0f);
                GL.Vertex3(-1.0f, 1.0f, -1.0f);
                GL.Vertex3(1.0f, 1.0f, -1.0f);
                GL.Vertex3(1.0f, -1.0f, -1.0f);

                GL.Color3(Color.Yellow);
                GL.Vertex3(-1.0f, -1.0f, -1.0f);
                GL.Vertex3(1.0f, -1.0f, -1.0f);
                GL.Vertex3(1.0f, -1.0f, 1.0f);
                GL.Vertex3(-1.0f, -1.0f, 1.0f);

                GL.Color3(Color.Moccasin);

                GL.Vertex3(-1.0f, -1.0f, -1.0f);
                GL.Vertex3(-1.0f, -1.0f, 1.0f);
                GL.Vertex3(-1.0f, 1.0f, 1.0f);
                GL.Vertex3(-1.0f, 1.0f, -1.0f);

                GL.Color3(Color.Aqua);
                GL.Vertex3(-1.0f, -1.0f, 1.0f);
                GL.Vertex3(1.0f, -1.0f, 1.0f);
                GL.Vertex3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(-1.0f, 1.0f, 1.0f);

                GL.Color3(Color.Purple);
                GL.Vertex3(-1.0f, 1.0f, -1.0f);
                GL.Vertex3(-1.0f, 1.0f, 1.0f);
                GL.Vertex3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(1.0f, 1.0f, -1.0f);

                GL.Color3(Color.OrangeRed);
                GL.Vertex3(1.0f, -1.0f, -1.0f);
                GL.Vertex3(1.0f, 1.0f, -1.0f);
                GL.Vertex3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(1.0f, -1.0f, 1.0f);

                GL.End();
            }

            [STAThread]
            static void Main(string[] args)
            {
                using (Program example = new Program())
                {
                    example.Run(60.0, 0.0);
                }
            }
        }
    }

