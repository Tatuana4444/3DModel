using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DModel
{
    public partial class Form1 : Form
    {
        private List<float[]> geometricCoordinate = new List<float[]>();
        private List<float[]> texturalCoordinate = new List<float[]>();
        private List<float[]> normalVector = new List<float[]>();
        private List<List<int[]>> indexOPpolygon = new List<List<int[]>>();

        public Form1()
        {
            InitializeComponent();
            StreamReader f = new StreamReader("Model.obj");
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                if (s.Length > 0)
                {
                    if (s.Length > 0 && s[0] == 'f')
                    {
                        indexOPpolygon.Add(Parser.Parse(s));
                    }
                    else
                    {
                        string type;
                        float[] res = Parser.Parse(s, out type);
                        switch (type)
                        {
                            case "v":
                                geometricCoordinate.Add(res);
                                break;
                            case "vt":
                                texturalCoordinate.Add(res);
                                break;
                            case "vn":
                                normalVector.Add(res);
                                break;
                        }
                    }
                }
            }

            f.Close();
        }

    }
}
