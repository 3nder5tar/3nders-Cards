using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace EC.MonoBehaviors
{
	// Token: 0x0200000C RID: 12
	public class HyperLeechRegenMono : ReversibleEffect
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002AE2 File Offset: 0x00000CE2
		public override void OnOnEnable()
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002AE4 File Offset: 0x00000CE4
		public override void OnStart()
		{
			this.player.data.healthHandler.regeneration += 10f;
			this.effect = this.player.GetComponent<HyperLeechRegenMono>();
			this.ResetTimer();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B20 File Offset: 0x00000D20
		public override void OnUpdate()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (this.player.data.health >= this.player.data.maxHealth)
				{
					base.Destroy();
				}
				if (base.GetComponent<Player>().data.dead || base.GetComponent<Player>().data.health <= 0f || !base.GetComponent<Player>().gameObject.activeInHierarchy)
				{
					this.ResetTimer();
					base.Destroy();
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002BB6 File Offset: 0x00000DB6
		public override void OnOnDisable()
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public override void OnOnDestroy()
		{
			this.effect.active = false;
			if (this.player.data.healthHandler.regeneration >= 5f)
			{
				this.player.data.healthHandler.regeneration -= 5f;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C0E File Offset: 0x00000E0E
		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		// Token: 0x04000021 RID: 33
		private readonly Color color = Color.blue;

		// Token: 0x04000022 RID: 34
		private ReversibleColorEffect colorEffect;

		// Token: 0x04000023 RID: 35
		private HyperLeechRegenMono effect;

		// Token: 0x04000024 RID: 36
		private readonly float updateDelay = 0.1f;

		// Token: 0x04000025 RID: 37
		private float startTime;

		// Token: 0x04000020 RID: 32
		public bool active;
	}
}
