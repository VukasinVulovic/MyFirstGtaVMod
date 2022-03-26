using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using System.Windows.Forms;

namespace Mod2
{
    public class Mod2 : Script
    {
        private int gear = 1;
        private bool showed = false;
        public Mod2()
        {
            KeyDown += onKeyDown;
            GTA.UI.Screen.ShowHelpText($"Gear {gear}", -1, true);
        }

        private void onKeyDown(object sender, KeyEventArgs e) 
        {
            Vehicle curr = Game.Player.Character.CurrentVehicle;

            switch(e.KeyCode)
            {
                case Keys.Add:
                    if(gear < 6)
                        gear++;

                    showed = false;
                    break;

                case Keys.Subtract:
                    if (gear > 1)
                        gear--;

                    showed = false;
                    break;

                case Keys.NumPad0:
                    gear = 0;
                    break;

                case Keys.W:
                    if (gear == 0) //reverse
                    {
                        curr.ForwardSpeed = 0;
                    }
                    break;

                case Keys.S:
                    if (gear != 0) //not reverse
                    {
                        curr.Speed = 0;
                    }
                    break;
            }

            switch(gear)
            {
                case 0:
                    if (!showed)
                        GTA.UI.Screen.ShowHelpText($"Reverse", -1, true);
                    return;

                case 1:
                    curr.MaxSpeed = 20;
                    break;

                case 2:
                    curr.MaxSpeed = 30;
                    break;

                case 3:
                    curr.MaxSpeed = 40;
                    break;

                case 4:
                    curr.MaxSpeed = 60;
                    break;

                case 5:
                    curr.MaxSpeed = 80;
                    break;

                case 6:
                    curr.MaxSpeed = 250;
                    break;
            }

            if(!showed)
                GTA.UI.Screen.ShowHelpText($"Gear {gear}", -1, true);

            showed = true;
        }
    }
}