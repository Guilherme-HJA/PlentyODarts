using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PlentyODarts.Content.Projectiles;

namespace PlentyODarts.Content.Weapons {
  public class StarryDart : ModItem {
    public override void SetStaticDefaults() {
      DisplayName.Format("Starry Dart");
      Tooltip.Format("\"One with the stars\"");
    }

    public override void SetDefaults() {
      Item.width = 16;
      Item.height = 32;
      Item.scale = 1.1f;
      Item.rare = ItemRarityID.Green;
      Item.noMelee = true;
      Item.noUseGraphic = true;
      Item.UseSound = SoundID.Item39;
      Item.useStyle = ItemUseStyleID.Swing;
      Item.useTime = 15;
      Item.useAnimation = 15;
      Item.DamageType = DartDamage.Instance;
      Item.damage = 20;
      Item.knockBack = 1;
      Item.value = Item.buyPrice(0, 0, 0, 20);
      Item.crit = 5;
      Item.shoot = ModContent.ProjectileType<StarryDartProj>();
      Item.consumable = true;
      Item.maxStack = 999;
      Item.shootSpeed = 15;
    }

    public override void ModifyShootStats(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref Microsoft.Xna.Framework.Vector2 velocity, 
    ref int type, ref int damage, ref float knockback) {
      if(!Main.dayTime) velocity *= 1.1f;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage) {
      if(!Main.dayTime) damage += 0.5f;     
    }

    public override void AddRecipes() {
      CreateRecipe(75)
        .AddIngredient(ModContent.ItemType<WoodenDart>(), 50)
        .AddIngredient(ItemID.FallenStar, 1)
        .Register();
    }


    public override void PostUpdate() {
      Lighting.AddLight(Item.Center, 1f, 1f, 1f);
    }
  }
}
