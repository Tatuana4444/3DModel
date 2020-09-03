using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _3DModel
{
    public static class Parser
    {
        public static List<int[]> Parse(string input)
        {
            string[] parts = input.Split(new char[] { ' ' }).Where(word => word != "").ToArray();
            List<int[]> result = new List<int[]>();

            if (parts[1].Contains("//"))
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    string[] part = parts[i].Split("//");
                    result.Add(new int[] { int.Parse(part[0]), 0, int.Parse(part[1])});
                }

            }
            else
            {
                string[] part = parts[1].Split("/");
                switch (part.Length)
                {
                    case 1:
                        result.Add(new int[] { int.Parse(part[0]), int.Parse(part[1])});
                        for (int i = 1; i < parts.Length; i++)
                        {
                            result.Add(new int[] { int.Parse(parts[i]), 0, 0});
                        }

                        break;
                    case 2:
                        for (int i = 1; i < parts.Length; i++)
                        {
                            part = parts[i].Split("/");
                            result.Add(new int[] { int.Parse(part[0]), int.Parse(part[1]), 0 });
                        }
                        break;
                    case 3:
                        for (int i = 1; i < parts.Length; i++)
                        {
                            part = parts[i].Split("/");
                            result.Add(new int[] { int.Parse(part[0]), int.Parse(part[1]), int.Parse(part[2]) });
                        }
                        break;
                }
            }

            return result;
        }

        public static float[] Parse(string input, out string type)
        {
            string[] parts = input.Split(new char[] { ' ' }).Where(word => word != "").ToArray();
            type = parts[0];
            float[] result = Array.Empty<float>();
            switch (type)
            {
                case "v":
                    result = new float[4];
                    for (int i = 1; i < parts.Length; i++)
                    {
                        result[i - 1] = float.Parse(parts[i], CultureInfo.InvariantCulture);
                    }

                    if (parts.Length == 4)
                    {
                        result[3] = 1;
                    }

                    break;
                case "vt":
                    result = new float[3];
                    for (int i = 1; i < parts.Length; i++)
                    {
                        result[i - 1] = float.Parse(parts[i], CultureInfo.InvariantCulture);
                    }

                    if (parts.Length < 3)
                    {
                        result[1] = 0;
                    }

                    if (parts.Length < 4)
                    {
                        result[2] = 0;
                    }

                    break;
                case "vn":
                    result = new float[3];
                    for (int i = 1; i < parts.Length; i++)
                    {
                        result[i - 1] = float.Parse(parts[i], CultureInfo.InvariantCulture);
                    }
                    
                    break;
            }

            return result;
        }
    }
}
