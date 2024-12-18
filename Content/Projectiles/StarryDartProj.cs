using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PlentyODarts.Content.Projectiles {
  public class StarryDartProj : ModProjectile {
    public override void SetStaticDefaults() {
      DisplayName.Format("Starry Dart Projectile");
    }

    public override void SetDefaults() {
      Projectile p = Projectile;

      p.width = 8;
      p.height = 16;
      p.scale = 1.2f;
      p.aiStyle = 1;
      p.friendly = true;
      p.hostile = false;
      p.DamageType = DartDamage.Instance;
      p.penetrate = 4;
      p.timeLeft = 300;
      p.ignoreWater = true;
      p.tileCollide = true;

      AIType = ProjectileID.WoodenArrowFriendly;    
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
      if(hit.Crit) {
        int star = Projectile.NewProjectile(target.GetSource_FromThis(), 
        new Vector2(target.position.X, Main.screenPosition.Y), 
        new Vector2(0, 25), 
        ProjectileID.Starfury, 
        10, 
        0,
        Main.myPlayer);
      }
    }

    
    public override bool OnTileCollide(Microsoft.Xna.Framework.Vector2 oldVelocity) {
    
      for(int i = 0; i <= 12; i++) {
        int dust = Dust.NewDust(
        new Vector2(Projectile.position.X + Main.rand.Next(0, 30), 
        Projectile.position.Y + Main.rand.Next(0, 30)), 
        Projectile.width, 
        Projectile.height,
        DustID.PurificationPowder,
        Projectile.velocity.X / 2,
        Projectile.velocity.Y / 2,
        0,
        Color.White,
        1);

        Main.dust[dust].noGravity = true;
      } 
      
      Projectile.Kill();
      
      return false;
    }

    public override void AI() {

      Color[] colors = { Color.White, Color.FloralWhite, Color.Pink, Color.Yellow };
      
      Lighting.AddLight(Projectile.Center, .6f, .6f, .6f);
      int dust = Dust.NewDust(Projectile.position + Projectile.velocity, 
      Projectile.width, 
      Projectile.height,
      DustID.PurificationPowder,
      Projectile.velocity.X * .8f,
      Projectile.velocity.Y * .8f,
      0,
      Main.rand.NextFromList(colors),
      0.8f);

      Main.dust[dust].noGravity = true;
    }  
  }
}

