using System;
using System.Diagnostics;
using System.Windows.Forms;
using CubeTransform.MyCube;

namespace CubeTransform
{
    public partial class MyForm : Form
    {
        /// <summary>
        /// 方块的缩放
        /// scale
        /// </summary>
        private Matrix4x4 scale;

        /// <summary>
        /// Y 轴
        /// </summary>
        private Matrix4x4 rotateY;

        /// <summary>
        /// X 轴
        /// </summary>
        private Matrix4x4 rotateX;

        /// <summary>
        /// Z 轴
        /// </summary>
        private Matrix4x4 rotateZ;

        private Matrix4x4 view;
        private Matrix4x4 projection;

        /// <summary>
        /// Model*View*Projection matrix
        /// </summary>
        private Matrix4x4 mvp;

        private int a;
        private MyCube.MyCube cube;
        private int currentMouseX;
        private int currentMouseY;
        private double angle;
        private double angley;
        private bool fi;

        public MyForm()
        {
            InitializeComponent();
        }
private void SetMatrix()
        {
            textBox20.Text = mvp.GetNumber(0, 0).ToString();
            textBox19.Text = mvp.GetNumber(0, 1).ToString();
            textBox18.Text = mvp.GetNumber(0, 2).ToString();
            textBox17.Text = mvp.GetNumber(0, 3).ToString();
            
            textBox5.Text = mvp.GetNumber(1, 0).ToString();
            textBox6.Text = mvp.GetNumber(1, 1).ToString();
            textBox7.Text = mvp.GetNumber(1, 2).ToString();
            textBox8.Text = mvp.GetNumber(1, 3).ToString();
            
            textBox12.Text = mvp.GetNumber(2, 0).ToString();
            textBox11.Text = mvp.GetNumber(2, 1).ToString();
            textBox10.Text = mvp.GetNumber(2,2).ToString();
            textBox9.Text = mvp.GetNumber(2, 3).ToString();
            
            textBox16.Text = mvp.GetNumber(3, 0).ToString();
            textBox15.Text = mvp.GetNumber(3, 1).ToString();
            textBox14.Text = mvp.GetNumber(3, 2).ToString();
            textBox13.Text = mvp.GetNumber(3, 3).ToString();
        }

        private void PaintMatrix()
        {
            cube.transform(mvp);
            Console.WriteLine("123123123123123");
            textBox1.Text = mvp.ToString();
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.WriteLine("an le");
                double input00 = Double.Parse(textBox20.Text);
                double input01 = Double.Parse(textBox19.Text);
                double input02 = Double.Parse(textBox18.Text);
                double input03 = Double.Parse(textBox17.Text);
                
                double input10 = Double.Parse(textBox5.Text);
                double input11 = Double.Parse(textBox6.Text);
                double input12 = Double.Parse(textBox7.Text);
                double input13 = Double.Parse(textBox8.Text);
                
                double input20 = Double.Parse(textBox12.Text);
                double input21 = Double.Parse(textBox11.Text);
                double input22 = Double.Parse(textBox10.Text);
                double input23 = Double.Parse(textBox9.Text);
                
                double input30 = Double.Parse(textBox16.Text);
                double input31 = Double.Parse(textBox15.Text);
                double input32 = Double.Parse(textBox14.Text);
                double input33 = Double.Parse(textBox13.Text);
                //applu
                mvp.SetNumber(0,0,input00);
                mvp.SetNumber(0,1,input01);
                mvp.SetNumber(0,2,input02);
                mvp.SetNumber(0,3,input03);
                
                mvp.SetNumber(1,0,input10);
                mvp.SetNumber(1,1,input11);
                mvp.SetNumber(1,2,input12);
                mvp.SetNumber(1,3,input13);
                
                mvp.SetNumber(2,0,input20);
                mvp.SetNumber(2,1,input21);
                mvp.SetNumber(2,2,input22);
                mvp.SetNumber(2,3,input23);
                
                mvp.SetNumber(3,0,input30);
                mvp.SetNumber(3,1,input31);
                mvp.SetNumber(3,2,input32);
                mvp.SetNumber(3,3,input33);
                
                //....TODO
                PaintMatrix();
            }
        }

        // protected override void OnMouseMove(MouseEventArgs e)
        // {
        //     if (e.Button == MouseButtons.Left)
        //     {
        //         int mouseXoffset = Cursor.Position.X - currentMouseX;
        //         int mouseyoffset = Cursor.Position.Y - currentMouseY;
        //
        //
        //         //angle per sec
        //         a = 5;
        //         //angle = a / 360.0 * Math.PI * mouseXoffset;
        //         angle = Math.PI * mouseXoffset / 180.0;
        //         angley = Math.PI * mouseyoffset / 180.0;
        //         //Y =====
        //         /*绕Y轴旋转A度
        //          rotate A degree around Y
        //         cosA, 0, -sinA
        //         0,    1,   0
        //         sinA, 0, cosA
        //         */
        //         rotateY[0, 0] = Math.Cos(angley);
        //         rotateY[0, 2] = Math.Sin(angley);
        //         rotateY[1, 1] = 1;
        //         rotateY[2, 0] = -Math.Sin(angley);
        //         rotateY[2, 2] = Math.Cos(angley);
        //         rotateY[3, 3] = 1;
        //         if (this.checkBox2.Checked)
        //         {
        //             Matrix4x4 tx = rotateY.Transpose();
        //             rotateY = rotateY.Mul(tx);
        //         }
        //
        //         // X ===
        //         /* 绕X轴旋转A度
        //          rotate A degree around X
        //         1,     0,    0
        //         0,  cosA, sinA
        //         0, -sinA, cosA
        //     */
        //         rotateX[0, 0] = 1;
        //         rotateX[1, 1] = Math.Cos(angle);
        //         rotateX[1, 2] = Math.Sin(angle);
        //         rotateX[2, 1] = -Math.Sin(angle);
        //         rotateX[2, 2] = Math.Cos(angle);
        //         rotateX[3, 3] = 1;
        //
        //         if (this.checkBox1.Checked)
        //         {
        //             Matrix4x4 tx = rotateX.Transpose();
        //             rotateX = rotateX.Mul(tx);
        //         }
        //         PaintCube();
        //         // //缩放 scale
        //         // Matrix4x4 model = scale.Mul(rotateX);
        //         // model = model.Mul(rotateY);
        //         // model = model.Mul(rotateZ);
        //         // //加上光源
        //         // //calculate lighting
        //         // cube.CalNormalLighting(model, new Vector4(-1, 1, -1, 0));
        //         // Matrix4x4 modelView = model.Mul(view);
        //         // mvp = modelView.Mul(projection);
        //         // cube.transform(mvp);
        //         // // show the matrix
        //         // textBox1.Text = mvp.ToString();
        //         // this.Invalidate();
        //     }
        // }
        //
        // protected override void OnMouseDown(MouseEventArgs e)
        // {
        //     if (e.Button == MouseButtons.Left)
        //     {
        //         //MessageBox.Show("左键");
        //         currentMouseX = Cursor.Position.X;
        //         currentMouseY = Cursor.Position.Y;
        //     }
        // }

        private void RotateX3D(double theta)
        {
            // X ===
            /* 绕X轴旋转A度
             rotate A degree around X
            1,     0,    0
            0,  cosA, sinA
            0, -sinA, cosA
        */
            rotateX[0, 0] = 1;
            rotateX[1, 1] = Math.Cos(theta);
            rotateX[1, 2] = Math.Sin(theta);
            rotateX[2, 1] = -Math.Sin(theta);
            rotateX[2, 2] = Math.Cos(theta);
            rotateX[3, 3] = 1;

            if (this.checkBox1.Checked)
            {
                Matrix4x4 tx = rotateX.Transpose();
                rotateX = rotateX.Mul(tx);
            }
        }

        private void RotateY3D(double theta)
        {
            //Y =====
            /*绕Y轴旋转A度
             rotate A degree around Y
            cosA, 0, -sinA
            0,    1,   0
            sinA, 0, cosA
            */
            rotateY[0, 0] = Math.Cos(theta);
            rotateY[0, 2] = Math.Sin(theta);
            rotateY[1, 1] = 1;
            rotateY[2, 0] = -Math.Sin(theta);
            rotateY[2, 2] = Math.Cos(theta);
            rotateY[3, 3] = 1;
            if (this.checkBox2.Checked)
            {
                Matrix4x4 tx = rotateY.Transpose();
                rotateY = rotateY.Mul(tx);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vector4 a = new Vector4(0, 0.5, 0, 1);
            Vector4 b = new Vector4(0.5, -0.5, 0, 1);
            Vector4 c = new Vector4(-0.5, -0.5, 0, 1);
//            Vector4 d = new Vector4(0,-0.5,0,1);
            scale = new Matrix4x4();
            rotateY = new Matrix4x4();
            rotateX = new Matrix4x4();
            rotateZ = new Matrix4x4();
            view = new Matrix4x4();
            projection = new Matrix4x4();
            cube = new MyCube.MyCube();

            /*
             * 缩放运算的方阵是一种特殊方阵：对角方阵
                缩放对角矩阵
                         Sx, 0, 0
                         0, Sy, 0
                         0,  0, Sz
                缩放轴需要你填写，如果哪个轴不缩放，那么请你填写1
                注意：缩放绝对不可以是0
             */
            scale[0, 0] = 150;
            scale[1, 1] = 150;
            scale[2, 2] = 150;
            scale[3, 3] = 1;

            view[0, 0] = 1;
            view[1, 1] = 1;
            view[2, 2] = 1;
            view[3, 3] = 1;
            view[3, 2] = 250;

            /*
             * 投影是需要在一个平面上完成的，所以我们的计算都是根据平面来进行投影的
    xy平面投影
        1，0，0
        0，1，0
        0，0，0
    xz平面投影
        1，0，0
        0，0，0
        0，0，1
    yz平面投影
        0，0，0
        0，1，0
        0，0，1
             */
            projection[0, 0] = 1;
            projection[1, 1] = 1;
            projection[2, 2] = 1;
            projection[2, 3] = 1.0 / 350;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //canvas
            e.Graphics.TranslateTransform(300, 300);
            cube.Draw(e.Graphics, false);
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!fi)
            {
                //Y =====
                /*绕Y轴旋转A度
                 rotate A degree around Y
                cosA, 0, -sinA
                0,    1,   0
                sinA, 0, cosA
                */
                rotateY[0, 0] = Math.Cos(0);
                rotateY[0, 2] = Math.Sin(0);
                rotateY[1, 1] = 1;
                rotateY[2, 0] = -Math.Sin(0);
                rotateY[2, 2] = Math.Cos(0);
                rotateY[3, 3] = 1;
                if (this.checkBox2.Checked)
                {
                    Matrix4x4 tx = rotateY.Transpose();
                    rotateY = rotateY.Mul(tx);
                }

                // X ===
                /* 绕X轴旋转A度
                 rotate A degree around X
                1,     0,    0
                0,  cosA, sinA
                0, -sinA, cosA
            */
                rotateX[0, 0] = 1;
                rotateX[1, 1] = Math.Cos(0);
                rotateX[1, 2] = Math.Sin(0);
                rotateX[2, 1] = -Math.Sin(0);
                rotateX[2, 2] = Math.Cos(0);
                rotateX[3, 3] = 1;

                if (this.checkBox1.Checked)
                {
                    Matrix4x4 tx = rotateX.Transpose();
                    rotateX = rotateX.Mul(tx);
                }

                // Z === 
                /*
                 * rotate A degree around Z
                cosA, sinA, 0
               -sinA, cosA, 0
                0,    0,    1
                 */
                rotateZ[0, 0] = Math.Cos(0);
                rotateZ[0, 1] = Math.Sin(0);
                rotateZ[1, 0] = -Math.Sin(0);
                rotateZ[1, 1] = Math.Cos(0);
                rotateZ[2, 2] = 1;
                rotateZ[3, 3] = 1;
                //transpose
                if (this.checkBox3.Checked)
                {
                    Matrix4x4 tx = rotateZ.Transpose();
                    rotateZ = rotateZ.Mul(tx);
                }
                PaintCube();
                fi = true;
            }

            // //缩放 scale
            // Matrix4x4 model = scale.Mul(rotateX);
            // model = model.Mul(rotateY);
            // model = model.Mul(rotateZ);
            // //加上光源
            // //calculate lighting
            // cube.CalNormalLighting(model, new Vector4(-1, 1, -1, 0));
            // Matrix4x4 modelView = model.Mul(view);
            // mvp = modelView.Mul(projection);
            // cube.transform(mvp);
            // // show the matrix
            // textBox1.Text = mvp.ToString();
            // this.Invalidate();
            //PaintCube();
        }

        private void PaintCube()
        {
            //缩放 scale
            Matrix4x4 model = scale.Mul(rotateX);
            model = model.Mul(rotateY);
            model = model.Mul(rotateZ);
            //加上光源
            //calculate lighting
            cube.CalNormalLighting(model, new Vector4(-1, 1, -1, 0));
            Matrix4x4 modelView = model.Mul(view);
            mvp = modelView.Mul(projection);
            cube.transform(mvp);
            // show the matrix
            textBox1.Text = mvp.ToString();
            SetMatrix();
            this.Invalidate();
        }

        

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            view[3, 2] = (sender as TrackBar).Value;
            PaintCube();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = mvp.ToString();
        }

        ///Rotate x Axis
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double angleX = 0;
            double radians = 0;
            if (!textBox2.Text.ToString().Equals(""))
            {
                angleX = Double.Parse(textBox2.Text.ToString());
                radians = Math.PI * angleX / 180.0;
            }

            rotateX[0, 0] = 1;
            rotateX[1, 1] = Math.Cos(radians);
            rotateX[1, 2] = Math.Sin(radians);
            rotateX[2, 1] = -Math.Sin(radians);
            rotateX[2, 2] = Math.Cos(radians);
            rotateX[3, 3] = 1;
            PaintCube();
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void checkBox1_CheckedChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rotate Y Axis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double angleY = 0;
            double radians = 0;
            if (!textBox3.Text.ToString().Equals(""))
            {
                angleY = Double.Parse(textBox3.Text.ToString());
                radians = Math.PI * angleY / 180.0;
            }

            //Y =====
            /*绕Y轴旋转A度
             rotate A degree around Y
            cosA, 0, -sinA
            0,    1,   0
            sinA, 0, cosA
            */
            rotateY[0, 0] = Math.Cos(radians);
            rotateY[0, 2] = Math.Sin(radians);
            rotateY[1, 1] = 1;
            rotateY[2, 0] = -Math.Sin(radians);
            rotateY[2, 2] = Math.Cos(radians);
            rotateY[3, 3] = 1;
            PaintCube();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double angleZ = 0;
            double radians = 0;
            if (!textBox4.Text.ToString().Equals(""))
            {
                angleZ = Double.Parse(textBox4.Text.ToString());
                radians = Math.PI * angleZ / 180.0;
                Console.WriteLine(Math.Cos(radians));
                //MessageBox.Show(angleZ.ToString());
            }

            // Z === 
            /*
             * rotate A degree around Z
            cosA, sinA, 0
           -sinA, cosA, 0
            0,    0,    1
             */
            rotateZ[0, 0] = Math.Cos(radians);
            rotateZ[0, 1] = Math.Sin(radians);
            rotateZ[1, 0] = -Math.Sin(radians);
            rotateZ[1, 1] = Math.Cos(radians);
            rotateZ[2, 2] = 1;
            rotateZ[3, 3] = 1;
            PaintCube();
        }
        
        // protected override void OnKeyDown(KeyEventArgs e)
        // {
        //     if (e.KeyCode == Keys.Return)
        //     {
        //         double input = Double.Parse(textBox20.Text);
        //         mvp.SetNumber(0,0,input);
        //         Console.WriteLine(mvp.GetNumber(0,0).ToString());
        //     
        //         //
        //         PaintCube();
        //     }
        // }

        /// <summary>
        /// 0,0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 0,1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 0,2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 0,3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 1,0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 1,1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 1,2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }


        /// <summary>
        /// 1,3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 2,0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 2,1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 2,2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 2,3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 3,0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 3,1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 3,2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 3,3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            double tx = 0;
            if(!textBox21.Text.ToString().Equals(""))
            {
                tx = Double.Parse(textBox21.Text);
            }
            mvp.SetNumber(3,0,tx);
            PaintMatrix();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            double ty = 0;
            if(!textBox22.Text.ToString().Equals(""))
            {
                ty = Double.Parse(textBox22.Text);
            }
            mvp.SetNumber(3,1,ty);
            PaintMatrix();
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            double tz = 0;
            if(!textBox23.Text.ToString().Equals(""))
            {
                tz = Double.Parse(textBox23.Text);
            }
            mvp.SetNumber(3,2,tz);
            PaintMatrix();
        }
    }
}