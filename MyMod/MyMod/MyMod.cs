using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;

namespace MyMod
{
    public class MyMod : Script
    {
        public MyMod()
        {
            KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GTA.UI.Screen.ShowSubtitle("OwO", 2500);
            }
        }
    }
}
