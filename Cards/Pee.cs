using System;
using System.Collections.Generic;
using System.Linq;
using EC.MonoBehaviors;
using UnboundLib.Cards;
using UnityEngine;

namespace EndersCards.Cards
{
	// Token: 0x0200006D RID: 109
	public class Pee : CustomCard
	{
		// Token: 0x0600030E RID: 782 RVA: 0x00013DE9 File Offset: 0x00011FE9
		public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
		{
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00013DEC File Offset: 0x00011FEC
		public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
		{
			gun.projectileColor = new Color(0.8f, 1f, 0f, 1f);
			gun.attackSpeed *= 0.5f;
			gun.spread = 0f;
			gunAmmo.reloadTime *= 1.2f;
			List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList<ObjectsToSpawn>();
			list.Add(new ObjectsToSpawn
			{
				AddToProjectile = new GameObject("A_Golden", new Type[]
				{
					typeof(PeeMono)
				})
			});
			gun.objectsToSpawn = list.ToArray();
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00013E8F File Offset: 0x0001208F
		public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
		{
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00013E91 File Offset: 0x00012091
		protected override string GetTitle()
		{
			return "Pee";
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00013E98 File Offset: 0x00012098
		protected override string GetDescription()
		{
			return "Bullets slow targets and reduce current hp by 20% for 3 seconds.";
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00013E9F File Offset: 0x0001209F
		protected override GameObject GetCardArt()
		{
			return null;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00013EB0 File Offset: 0x000120B0
		protected override CardInfo.Rarity GetRarity()
		{
			return CardInfo.Rarity.Uncommon;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00013EB4 File Offset: 0x000120B4
		protected override CardInfoStat[] GetStats()
		{
			return new CardInfoStat[]
			{
				new CardInfoStat
				{
					positive = true,
					stat = "ATK SPD",
					amount = "+100%",
					simepleAmount = CardInfoStat.SimpleAmount.aLotOf
				},
				new CardInfoStat
				{
					positive = true,
					stat = "Spread",
					amount = "Reset",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				},
				new CardInfoStat
				{
					positive = false,
					stat = "Reload Time",
					amount = "+20%",
					simepleAmount = CardInfoStat.SimpleAmount.Some
				}
			};
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00013F4B File Offset: 0x0001214B
		protected override CardThemeColor.CardThemeColorType GetTheme()
		{
			return CardThemeColor.CardThemeColorType.FirepowerYellow;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00013F4E File Offset: 0x0001214E
		public override string GetModName()
		{
			return "EC";
		}
	}
}