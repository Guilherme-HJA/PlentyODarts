using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

using PlentyODarts.Content.Projectiles;

namespace PlentyODarts.Content.Weapons {
  public class FieryDart : ModItem {

    public override void SetStaticDefaults() {
      DisplayName.Format("Fiery Dart");
      Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(9, 5));
      ItemID.Sets.AnimatesAsSoul[Item.type] = true;
    }

    public override void SetDefaults() {
      Item i = Item;

      i.height = 62;
      i.width = 14;
      i.scale = .5f;

      i.damage = 15;
      i.crit = 5;
      i.knockBack = 5;
      i.DamageType = DartDamage.Instance;

      i.noMelee = true;
      i.noUseGraphic = true;
      i.useAnimation = 15;
      i.useTime = 15;
      i.useStyle = ItemUseStyleID.Swing;
      i.UseSound = SoundID.Item39;

      i.value = Item.sellPrice(0, 0, 0, 50);
      i.rare = ItemRarityID.Green;

      i.consumable = true;
      i.shoot = ModContent.ProjectileType<FieryDartProj>();
      i.shootSpeed = 15;
      i.maxStack = 999;
    }

    public override void PostUpdate() {
      Vector2 pos = new Vector2(Item.Center.X + 20, Item.Center.Y);
      Lighting.AddLight(pos, .9f, .3f, .7f);
    }
    
    public override void AddRecipes() {
      CreateRecipe(150)
        .AddIngredient(ModContent.ItemType<WoodenDart>(), 50)
        .AddIngredient(ItemID.Torch)
        .Register();
    }
  }
}
