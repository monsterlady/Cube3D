﻿using System;

 namespace CubeTransform
{
    public class Matrix4x4
    {
        public double[,] pts;

        public Matrix4x4()
        {
            pts = new double[4,4];
        }

        /*主要是配合我们的4维向量使用的矩阵
        4维矩阵的用途
    主要用于显示方面的，最后一个维度用于标明显像管的比例
    在图形图像编程中我们必须使用四维的向量，方便我们最后的显示
    4x4 矩阵形式
        m11, m12, m13, Nx
        m21, m22, m23, Ny
        m31, m32, m33, Nz
          0,   0,   0, 1
    m表示的是一个3x3的方阵，所以我们前面认识的所有方阵都可以放进去
    (Nx,Ny,Nz,1) 叫做增量变化，如果你没有增量那么你就传0就好了，但是最后一个维度一定是1
    说明
    齐次矩阵在和我们的向量发生关系后他并不会直接改变坐标，而是改变了4维向量的最后一个维度，这样的表现主要应用在我们的渲染当中，逻辑代码并不需要；*/
        public Matrix4x4(Vector4 vector4):this()
        {
            pts[0, 0] = vector4.x;
            pts[1, 0] = vector4.y;
            pts[2, 0] = vector4.z;
            pts[3, 0] = vector4.w;
        }
        
        public double this[int i, int j]
        {
            get { return pts[i, j]; }
            set { pts[i, j] = value; }
        }
        
        public Matrix4x4 Mul(Matrix4x4 m4)
        {
            Matrix4x4 newM = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        newM[i, j] += pts[i, k] * m4[k, j];
                    }
                }
            }

            return newM;
        }

        public Vector4 Mul(Vector4 v4)
        {
            //  Matrix4x4 ret = new Matrix4x4(v4);
            //  ret = Mul(ret);
            //  Vector4 tmp = new Vector4(ret[0, 0], ret[1, 0], ret[2, 0], ret[3, 0]);

            Vector4 retvVector4 = new Vector4();
            retvVector4.x = v4.x * pts[0, 0] + v4.y * pts[1, 0] + v4.z * pts[2, 0] + v4.w * pts[3, 0];
            retvVector4.y = v4.x * pts[0, 1] + v4.y * pts[1, 1] + v4.z * pts[2, 1] + v4.w * pts[3, 1];
            retvVector4.z = v4.x * pts[0, 2] + v4.y * pts[1, 2] + v4.z * pts[2, 2] + v4.w * pts[3, 2];
            retvVector4.w = v4.x * pts[0, 3] + v4.y * pts[1, 3] + v4.z * pts[2, 3] + v4.w * pts[3, 3];
            return retvVector4;
        }
        //得到转置矩阵
        public Matrix4x4 Transpose()
        {
            Matrix4x4 ret = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ret[i, j] = pts[j, i];
                }
            }

            return ret;
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    str += (int) pts[i, j] + ",";
                    str += (j == 3) ? "\n" : "";
                }
            }

            return str;
        }

        public double GetNumber(int x, int y)
        {
            return pts[x, y];
        }

        public void SetNumber(int x, int y,double target)
        {
            pts[x, y] = target;
        }
    }
}