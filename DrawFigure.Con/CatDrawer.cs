﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//System.Drawing.Common をnuget
using System.Drawing;

namespace DrawFigure.Con
{
    internal class CatDrawer
    {
        Bitmap bmp;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public CatDrawer()
        {
            // キャンバスサイズは横500px、縦400px。
            this.bmp = new Bitmap(500, 400);
        }

        /// <summary>
        /// 猫のイラストを描画する。
        /// </summary>
        public void Draw(string filePath)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 顔の輪郭を描く。
                //楕円(長方形に外接)
                g.DrawEllipse(new Pen(GetFaceBorderColor(), 5), GetFacePosition());
                //多角形:Pen:色、幅、スタイル　Pointの配列 座標
                g.DrawPolygon(new Pen(GetFaceBorderColor(), 5), GetLeftEarPosition());
                g.DrawPolygon(new Pen(GetFaceBorderColor(), 5), GetRightEarPosition());

                // 顔の色を塗る。
                g.FillEllipse(new SolidBrush(GetFaceColor()), GetFacePosition());
                g.FillPolygon(new SolidBrush(GetFaceColor()), GetLeftEarPosition());
                g.FillPolygon(new SolidBrush(GetFaceColor()), GetRightEarPosition());

                // その他の顔のパーツを作る。
                g.FillEllipse(Brushes.Black, 190, 200, 15, 50);  // 右目
                g.FillEllipse(Brushes.Black, 295, 200, 15, 50);  // 左目
                //楕円の一部を表す円弧<サイズを一緒にしたら円>　
                g.DrawArc(new Pen(Color.Black, 5), new Rectangle(190, 270, 60, 60), 0, 180);    // 口（右側）
                g.DrawArc(new Pen(Color.Black, 5), new Rectangle(250, 270, 60, 60), 0, 180);    // 口（左側）
                //線:Pen 座標をつなぐ
                g.DrawLine(new Pen(Color.Black, 5), new Point(5, 210), new Point(120, 225));    // ひげ1（右側）
                g.DrawLine(new Pen(Color.Black, 5), new Point(0, 250), new Point(120, 250));    // ひげ2（右側）
                g.DrawLine(new Pen(Color.Black, 5), new Point(5, 290), new Point(120, 275));    // ひげ3（右側）


                g.DrawLine(new Pen(Color.Black, 5), new Point(380, 225), new Point(495, 210));    // ひげ1（左側）
                g.DrawLine(new Pen(Color.Black, 5), new Point(380, 250), new Point(500, 250));    // ひげ2（左側）
                g.DrawLine(new Pen(Color.Black, 5), new Point(380, 275), new Point(495, 290));    // ひげ3（左側）

            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// 猫の顔の色を返す。
        /// </summary>
        /// <returns></returns>
        private Color GetFaceColor()
        {
            return Color.FromArgb(255, 221, 209, 174);
        }

        /// <summary>
        /// 猫の顔の枠線の色を返す。
        /// </summary>
        /// <returns></returns>
        private Color GetFaceBorderColor()
        {
            return Color.FromArgb(255, 182, 156, 78);
        }

        /// <summary>
        /// 顔を描画する座標（外接する長方形）を返す。
        /// </summary>
        /// <returns></returns>
        private Rectangle GetFacePosition()
        {
            return new Rectangle(50, 100, 400, 280);
        }

        /// <summary>
        /// 左耳を描画する座標を返す。
        /// </summary>
        /// <returns></returns>
        private Point[] GetLeftEarPosition()
        {
            return new Point[] {
                new Point(430, 30),
                new Point(430, 210),
                new Point(300, 110)
            };
        }

        /// <summary>
        /// 右耳を描画する座標を返す。
        /// </summary>
        /// <returns></returns>
        private Point[] GetRightEarPosition()
        {
            return new Point[] {
                new Point(70, 30),
                new Point(70, 210),
                new Point(200, 110)
            };
        }

    }
}
