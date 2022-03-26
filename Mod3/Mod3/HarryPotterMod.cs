using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.UI;
using GTA.Native;
using GTA.Math;

namespace Mod3
{
    public class HarryPotterMod : Script
    {
        public HarryPotterMod()
        {            
            Tick += GameTick;

            KeyDown += (object sender, KeyEventArgs e) =>
            {
                switch(e.KeyCode)
                {
                    case Keys.Delete:
                        Entity[] entities = World.GetAllEntities();
                        foreach (Entity entity in entities)
                        {
                            if (entity != Game.Player.Character)
                                entity.Delete();
                        }
                        break;

                    case Keys.NumPad0:
                        GameTick(sender, e);
                        break;
                }
            };
        }

        private void GameTick(object sender, EventArgs e)
        {
            CastSpell("Expecto Patronum");
        }

        private Entity PointingAtEntitiy()
        {
            if (Game.Player.Character.Weapons.Current.Hash != WeaponHash.Pistol)
                return null;

            Entity entity = Game.Player.TargetedEntity;

            if (entity == null || !entity.Exists() || !entity.IsInRange(Game.Player.Character.Position, 20))
                return null;

            return entity;
        }

        private void TurnIntoClown(Entity entity)
        {
            if (entity.EntityType != EntityType.Ped)
                return;

            Ped ped = (Ped)entity;

            if (ped.IsDead || ped.Model.Hash == (int)PedHash.Clown01SMY)
                return;

            Ped clown = World.CreatePed(PedHash.Clown01SMY, ped.Position);

            clown.Weapons.Give(ped.Weapons.Current.Hash, 120, true, true);
            clown.Health = entity.Health + 100;
            //clown.Task.FightAgainst(Game.Player.Character);

            entity.Delete();
            entity.Detach();

            entity.MarkAsNoLongerNeeded();
            clown.MarkAsNoLongerNeeded();
            clown.Detach();
        }

        private void CastSpell(string spell)
        {
            spell = spell.ToLower();
            
            switch(spell) 
            {
                case "lumos":
                    World.DrawSpotLight(Game.Player.Character.Weapons.CurrentWeaponObject.Position, Game.Player.Character.ForwardVector, System.Drawing.Color.White, 10, 10, 10, 10, 3); //create light from player
                    return;
            }

            Entity entity = PointingAtEntitiy();

            if (entity == null)
                return;

            switch (spell)
            {
                case "winguardium leviosa":
                    entity.ApplyForce(new Vector3(0, 0, 1));
                    break;

                case "petrificus totalus":
                    if (entity.EntityType == EntityType.Ped) {
                        Ped ped = (Ped)entity;
                        ped.Task.PlayAnimation("move_m@shocked@a", "idle_turn_l_-180", 100, 1000, AnimationFlags.StayInEndFrame);
                        ped.IsPositionFrozen = true;
                        ped.MaxSpeed = 0;
                        ped.AlwaysKeepTask = true;
                    }
                    break;

                case "confundus charm":
                    if (entity.EntityType == EntityType.Ped)
                    {
                        ((Ped)entity).AlwaysKeepTask = true;
                        ((Ped)entity).Task.GoStraightTo(Vector3.RandomXY());
                    }
                    break;

                case "reparo":
                    if (entity.EntityType == EntityType.Vehicle)
                        ((Vehicle)entity).Repair(); //repair vehicle player is pointing at
                    break;

                case "riddikulus":
                    TurnIntoClown(entity); //turn ped player is pointing at into a clown
                    break;

                case "alohomora":
                    if(entity.EntityType == EntityType.Vehicle)
                        ((Vehicle)entity).LockStatus = VehicleLockStatus.Unlocked; //unlock vehicle
                    break;

                case "crucio": //bad spell
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;

                        ped.Task.PlayAnimation("weapon@w_pi_stungun", "damage");
                        Function.Call(Hash.PLAY_PAIN, ped, 7, 0, 0);

                        if (ped.Health > 10f)
                            ped.Health--;
                    }
                   break;

                case "sectumsempra":
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;
                        ped.ApplyDamage(1);
                        //Function.Call(Hash.APPLY_PED_BLOOD_DAMAGE_BY_ZONE, ped, 7, 0, 0);

                        Function.Call(Hash.PLAY_PAIN, ped, 7, 0, 0);
                    }
                    break;

                case "obliviate":
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;
                        ped.Task.ClearAllImmediately();
                    }
                    break;

                case "avada kedavra": //bad spell
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;
                        ped.Kill();
                    }
                    break;

                case "expelliarmus":
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;
                        ped.Weapons.Drop();
                    }
                    break;

                case "expecto patronum":
                    if (entity.EntityType == EntityType.Ped)
                    {
                        Ped ped = (Ped)entity;

                        if (
                            ped.Model != PedHash.Cop01SFY &&
                            ped.Model != PedHash.Cop01SMY &&
                            ped.Model != PedHash.CopCutscene &&
                            ped.Model != PedHash.UndercoverCopCutscene &&
                            ped.Model != PedHash.Hwaycop01SMY &&
                            ped.Model != PedHash.Snowcop01SMM
                        )
                            return;

                        ped.ApplyForce(Game.Player.Character.ForwardVector * 10);
                    }
                    break;

                default:
                    GTA.UI.Screen.ShowSubtitle($"~w~Unknown spell ~r~{spell}~w~.");
                    return;
            }

            entity.MarkAsNoLongerNeeded();
            GTA.UI.Screen.ShowSubtitle($"~w~Succesfully casted spell ~g~{spell}~w~.");
        }
    }
}
