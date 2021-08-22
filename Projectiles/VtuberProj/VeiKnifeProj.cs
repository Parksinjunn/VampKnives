using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Runtime.InteropServices;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.VtuberProj
{
    public class VeiKnifeProj : KnifeProjectile
    {
        int Delay;
        bool HasChanneled;
        float SpeedMult;
        int NPCsHIT;
        bool homing;
        public override void SafeSetDefaults()
        {
            projectile.width = 18;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //projectile is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = false;                 //projectile make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
            //projectile.scale = 1f;
            SpeedMult = Main.rand.NextFloat(1.1f, 1.6f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        int discreteUnits = 10;
        Color fadeTo = Color.Red;
        Color baseClr = Color.HotPink;
        float correctionFactor = 0.0f;
        float corFactorStep;
        Color curClr;
        int rotationNumber;
        public override void AI()
        {
            Vector2 usePos = projectile.position; // Position to use for dusts
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotVector * 16f;
            Delay++;
            //if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
            //{
            //    projectile.soundDelay = 10;
            //    Main.PlaySound(SoundID.Item9.WithVolume(0.5f), projectile.position);
            //}

            if (curClr == Color.Red)
            {
                correctionFactor = 0f;
            }
            corFactorStep = 1.0f / discreteUnits;

            //for (int i = 0; i < discreteUnits; i++)
            //{
                correctionFactor += corFactorStep;
                float red = (fadeTo.R - baseClr.R) * correctionFactor + baseClr.R;
                float green = (fadeTo.G - baseClr.G) * correctionFactor + baseClr.G;
                float blue = (fadeTo.B - baseClr.B) * correctionFactor + baseClr.B;
                curClr = new Color((int)red, (int)green, (int)blue);
                int num120 = Dust.NewDust(projectile.position + new Vector2(0, 5) + (Vector2.UnitY.RotatedBy(projectile.rotation) * projectile.height), 8, 8, ModContent.DustType<Dusts.HeartDust>(), 0f, 0f, 100, curClr, 0.3f) ;
                Dust dust = Main.dust[num120];
                
                double deg = (double)rotationNumber; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                double rad = deg * (Math.PI / 180); //Convert degrees to radians
                double dist = 64; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
                dust.position.X = (projectile.position.X) - (int)(Math.Cos(rad) * dist);
                dust.position.Y = (projectile.position.Y + 5)- (int)(Math.Sin(rad) * dist);
            rotationNumber += 24;
            //dust.velocity *= 0.3f;
                                                                                                                          //dust.position.X = projectile.position.X + (float)(projectile.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
                                                                                                                          //dust.position.Y = projectile.position.Y + (float)(projectile.height / 2) + (float)Main.rand.Next(-4, 5);
                                                                                                                          //dust.noGravity = true;
                                                                                                                          //}


            //int num4;
            //for (int num119 = 0; num119 < 1; num119 = num4 + 1)
            //{

            //    //Dust dust3 = Main.dust[num120];
            //    //dust3.velocity *= 0.1f;
            //    //dust3 = Main.dust[num120];
            //    //if (projectile.velocity.X * projectile.velocity.Y != 0)
            //    //{
            //    //    dust.velocity += projectile.velocity * -0.2f;
            //    //    dust.scale = 0.5f;
            //    //}
            //    //else
            //    //{
            //    //    dust.velocity *= projectile.direction;
            //    //    dust.scale = 0.3f;
            //    //}
            //    //dust.position = (dust.position + projectile.Center) / 2f;
            //    //dust.velocity += rotVector * 2f;
            //    //dust.velocity *= 0.5f;
            //    //dust.position.X = projectile.Center.X;
            //    //dust.position.Y = projectile.Center.Y;

            //    num4 = num119;
            //    //usePos -= rotVector * 8f;
            //}


            if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
            {
                HasChanneled = true;
            }

            if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f && Delay > 4)
            {
                //projectile.rotation += (float)projectile.direction * 0.8f;
                if (Main.player[projectile.owner].channel)
                {
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    float num146 = 12f;
                    Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    float num147 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    float num148 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num148 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector10.Y;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    float num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                    num149 = (float)Math.Sqrt((double)(num147 * num147 + num148 * num148));
                    if (num149 > num146)
                    {
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        num149 = num146 / num149;
                        num147 *= num149;
                        num148 *= num149;
                        int num150 = (int)(num147 * 1000f);
                        int num151 = (int)(projectile.velocity.X * 1000f);
                       // projectile.rotation += (float)projectile.direction * 0.8f;
                        int num152 = (int)(num148 * 1000f);
                        int num153 = (int)(projectile.velocity.Y * 1000f);
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        if (num150 != num151 || num152 != num153)
                        {
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                            projectile.netUpdate = true;
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        projectile.velocity.X = num147;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num148;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    else
                    {
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        int num154 = (int)(num147 * 1000f);
                        int num155 = (int)(projectile.velocity.X * 1000f);
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        int num156 = (int)(num148 * 1000f);
                        int num157 = (int)(projectile.velocity.Y * 1000f);
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        if (num154 != num155 || num156 != num157)
                        {
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                            projectile.netUpdate = true;
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        projectile.velocity.X = num147;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num148;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                    }
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    projectile.velocity *= SpeedMult;
                }
                else if (HasChanneled)
                {
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                    if (projectile.ai[0] == 0f)
                    {
                        projectile.ai[0] = 1f;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.netUpdate = true;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        float num158 = 12f;
                        Vector2 vector11 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                        float num159 = (float)Main.mouseX + Main.screenPosition.X - vector11.X;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        float num160 = (float)Main.mouseY + Main.screenPosition.Y - vector11.Y;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        if (Main.player[projectile.owner].gravDir == -1f)
                        {
                            num160 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector11.Y;
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                        }
                        float num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
                        if (num161 == 0f)
                        {
                            vector11 = new Vector2(Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2), Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2));
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                            num159 = projectile.position.X + (float)projectile.width * 0.5f - vector11.X;
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                            num160 = projectile.position.Y + (float)projectile.height * 0.5f - vector11.Y;
                            //projectile.rotation += (float)projectile.direction * 0.8f;
                            num161 = (float)Math.Sqrt((double)(num159 * num159 + num160 * num160));
                        }
                        num161 = num158 / num161;
                        num159 *= num161;
                        num160 *= num161;
                        projectile.velocity.X = num159;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        projectile.velocity.Y = num160;
                        //projectile.rotation += (float)projectile.direction * 0.8f;
                        if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                        {
                            projectile.Kill();
                        }
                    }
                    //projectile.rotation += (float)projectile.direction * 0.8f;
                }
                //projectile.rotation += (float)projectile.direction * 0.8f;
            }
            //projectile.rotation += (float)projectile.direction * 0.8f;
            //if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
            //{
            //    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
            //    projectile.rotation += (float)projectile.direction * 0.8f;
            //}
            //projectile.rotation += (float)projectile.direction * 0.8f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                //projectile.rotation += (float)projectile.direction * 0.8f;
            }
            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //projectile.rotation += MathHelper.ToRadians(180);
            projectile.rotation += 0.42f;
            projectile.netUpdate = true;
        }

        public override void Kill(int timeLeft)
        {
                //if (projectile.penetrate == 1)
                //{
                //    projectile.maxPenetrate = -1;
                //    projectile.penetrate = -1;
                //    int num590 = 60;
                //    projectile.position.X = projectile.position.X - (float)(num590 / 2);
                //    projectile.position.Y = projectile.position.Y - (float)(num590 / 2);
                //    projectile.width += num590;
                //    projectile.height += num590;
                //    projectile.tileCollide = false;
                //    projectile.velocity *= 0.01f;
                //    projectile.Damage();
                //    projectile.scale = 0.01f;
                //}
                //Main.PlaySound(SoundID.Item10.WithVolume(0.5f), projectile.position);
                int num4;
                for (int num588 = 0; num588 < 20; num588 = num4 + 1)
                {
                    int num589 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.HeartDust>(), 0f, 0f, 100, curClr, 2f);
                    Main.dust[num589].noGravity = true;
                    Dust dust = Main.dust[num589];
                    dust.velocity *= 4f;
                    num4 = num588;
                }
        }
        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            projectile.penetrate++;
            NPCsHIT++;
            if (NPCsHIT == 3)
            {
                projectile.Kill();
            }
            n.AddBuff(ModContent.BuffType<Buffs.VTuberBuffs.VeiLoveDebuff>(), 600);
            NPCs.MyGlobalNPC AllNPCs = Main.npc[n.whoAmI].GetGlobalNPC<NPCs.MyGlobalNPC>();
            AllNPCs.VeiLoveStack++;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = 69;
        }
    }
}

//FOR 1.4 UPDATE!!!
//namespace VampKnives.Projectiles
//{
//    [StructLayout(LayoutKind.Sequential, Size = 1)]
//    public struct RainbowRodDrawer
//    {
//        private static VertexStrip _vertexStrip = new VertexStrip();

//        public void Draw(Projectile proj)
//        {
//            MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
//            miscShaderData.UseSaturation(-2.8f);
//            miscShaderData.UseOpacity(4f);
//            miscShaderData.Apply(null);
//            _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f, false);
//            _vertexStrip.DrawTrail();
//            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
//        }

//        private Color StripColors(float progressOnStrip)
//        {
//            Color value = Main.hslToRgb((progressOnStrip * 1.6f - Main.GlobalTimeWrappedHourly) % 1f, 1f, 0.5f);
//            Color result = Color.Lerp(Color.White, value, Utils.GetLerpValue(-0.2f, 0.5f, progressOnStrip, true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip, false));
//            result.A = 0;
//            return result;
//        }

//        private float StripWidth(float progressOnStrip)
//        {
//            float num = 1f;
//            float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, true);
//            num *= 1f - (1f - lerpValue) * (1f - lerpValue);
//            return MathHelper.Lerp(0f, 32f, num);
//        }
//    }
//}


