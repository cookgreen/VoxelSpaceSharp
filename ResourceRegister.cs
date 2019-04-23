using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using VoxelSpaceSharp.Properties;

namespace VoxelSpaceSharp
{
    public class ResourceRegister
    {
        Dictionary<string, string> DiffuseHeightMapDic;
        Dictionary<string, Bitmap> DiffuseMapResourceDic;
        Dictionary<string, Bitmap> HeightMapResourceDic;
        private static ResourceRegister instance;
        public static ResourceRegister Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceRegister();
                }
                return instance;
            }
        }

        public ResourceRegister()
        {
            DiffuseHeightMapDic = new Dictionary<string, string>();
            DiffuseHeightMapDic.Add("C1W", "D1");
            DiffuseHeightMapDic.Add("C2W", "D2");
            DiffuseHeightMapDic.Add("C3", "D3");
            DiffuseHeightMapDic.Add("C4", "D4");
            DiffuseHeightMapDic.Add("C5W", "D5");
            DiffuseHeightMapDic.Add("C6W", "D6");
            DiffuseHeightMapDic.Add("C7W", "D7");
            DiffuseHeightMapDic.Add("C9W", "D9");
            DiffuseHeightMapDic.Add("C10W", "D10");
            DiffuseHeightMapDic.Add("C11W", "D11");
            DiffuseHeightMapDic.Add("C13", "D13");
            DiffuseHeightMapDic.Add("C14", "D14");
            DiffuseHeightMapDic.Add("C14W", "D14");
            DiffuseHeightMapDic.Add("C15", "D15");
            DiffuseHeightMapDic.Add("C16W", "D16");
            DiffuseHeightMapDic.Add("C17W", "D17");
            DiffuseHeightMapDic.Add("C18W", "D18");
            DiffuseHeightMapDic.Add("C19W", "D19");
            DiffuseHeightMapDic.Add("C20W", "D20");
            DiffuseHeightMapDic.Add("C21", "D21");
            DiffuseHeightMapDic.Add("C22W", "D22");
            DiffuseHeightMapDic.Add("C24W", "D24");
            DiffuseHeightMapDic.Add("C25W", "D25");

            DiffuseMapResourceDic = new Dictionary<string, Bitmap>();
            DiffuseMapResourceDic.Add("C1W", Resources.C1W);
            DiffuseMapResourceDic.Add("C2W", Resources.C2W);
            DiffuseMapResourceDic.Add("C3", Resources.C3);
            DiffuseMapResourceDic.Add("C4", Resources.C4);
            DiffuseMapResourceDic.Add("C5W", Resources.C5W);
            DiffuseMapResourceDic.Add("C6W", Resources.C6W);
            DiffuseMapResourceDic.Add("C7W", Resources.C7W);
            DiffuseMapResourceDic.Add("C9W", Resources.C9W);
            DiffuseMapResourceDic.Add("C10W", Resources.C10W);
            DiffuseMapResourceDic.Add("C11W", Resources.C11W);
            DiffuseMapResourceDic.Add("C13", Resources.C13);
            DiffuseMapResourceDic.Add("C14", Resources.C14);
            DiffuseMapResourceDic.Add("C14W", Resources.C14W);
            DiffuseMapResourceDic.Add("C15", Resources.C15);
            DiffuseMapResourceDic.Add("C16W", Resources.C16W);
            DiffuseMapResourceDic.Add("C17W", Resources.C17W);
            DiffuseMapResourceDic.Add("C18W", Resources.C18W);
            DiffuseMapResourceDic.Add("C19W", Resources.C19W);
            DiffuseMapResourceDic.Add("C20W", Resources.C20W);
            DiffuseMapResourceDic.Add("C21", Resources.C21);
            DiffuseMapResourceDic.Add("C22W", Resources.C22W);
            DiffuseMapResourceDic.Add("C24W", Resources.C24W);
            DiffuseMapResourceDic.Add("C25W", Resources.C25W);

            HeightMapResourceDic = new Dictionary<string, Bitmap>();
            HeightMapResourceDic.Add("D1", Resources.D1);
            HeightMapResourceDic.Add("D2", Resources.D2);
            HeightMapResourceDic.Add("D3", Resources.D3);
            HeightMapResourceDic.Add("D4", Resources.D4);
            HeightMapResourceDic.Add("D5", Resources.D5);
            HeightMapResourceDic.Add("D6", Resources.D6);
            HeightMapResourceDic.Add("D7", Resources.D7);
            HeightMapResourceDic.Add("D9", Resources.D9);
            HeightMapResourceDic.Add("D10", Resources.D10);
            HeightMapResourceDic.Add("D11", Resources.D11);
            HeightMapResourceDic.Add("D13", Resources.D13);
            HeightMapResourceDic.Add("D14", Resources.D14);
            HeightMapResourceDic.Add("D15", Resources.D15);
            HeightMapResourceDic.Add("D16", Resources.D16);
            HeightMapResourceDic.Add("D17", Resources.D17);
            HeightMapResourceDic.Add("D18", Resources.D18);
            HeightMapResourceDic.Add("D19", Resources.D19);
            HeightMapResourceDic.Add("D20", Resources.D20);
            HeightMapResourceDic.Add("D21", Resources.D21);
            HeightMapResourceDic.Add("D22", Resources.D22);
            HeightMapResourceDic.Add("D24", Resources.D24);
            HeightMapResourceDic.Add("D25", Resources.D25);
        }

        public List<string> GetDiffuseMaps()
        {
            return new List<string>(DiffuseHeightMapDic.Keys);
        }

        public Bitmap GetDiffuseMap(string selectedMap)
        {
            return DiffuseMapResourceDic[selectedMap];
        }

        public Bitmap GetHeightMap(string selectedMap)
        {
            return HeightMapResourceDic[DiffuseHeightMapDic[selectedMap]];
        }
    }
}
