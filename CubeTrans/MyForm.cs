using System;
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

        public MyForm()
        {
            InitializeComponent();
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
            //angle per sec
            a += 1;
            double angle = a / 360.0 * Math.PI;

            //Y =====
            /*绕Y轴旋转A度
             rotate A degree around Y
            cosA, 0, -sinA
            0,    1,   0
            sinA, 0, cosA
            */
            rotateY[0, 0] = Math.Cos(angle);
            rotateY[0, 2] = Math.Sin(angle);
            rotateY[1, 1] = 1;
            rotateY[2, 0] = -Math.Sin(angle);
            rotateY[2, 2] = Math.Cos(angle);
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
            rotateX[1, 1] = Math.Cos(angle);
            rotateX[1, 2] = Math.Sin(angle);
            rotateX[2, 1] = -Math.Sin(angle);
            rotateX[2, 2] = Math.Cos(angle);
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
            rotateZ[0, 0] = Math.Cos(angle);
            rotateZ[0, 1] = Math.Sin(angle);
            rotateZ[1, 0] = -Math.Sin(angle);
            rotateZ[1, 1] = Math.Cos(angle);
            rotateZ[2, 2] = 1;
            rotateZ[3, 3] = 1;
            //transpose
            if (this.checkBox3.Checked)
            {
                Matrix4x4 tx = rotateZ.Transpose();
                rotateZ = rotateZ.Mul(tx);
            }

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
            this.Invalidate();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            view[3, 2] = (sender as TrackBar).Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = mvp.ToString();
        }
    }
}