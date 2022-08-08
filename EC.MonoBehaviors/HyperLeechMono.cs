using System;
using UnityEngine;

namespace EC.MonoBehaviors
{
	// Token: 0x0200000B RID: 11
	public class HyperLeechMono : MonoBehaviour
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000028DC File Offset: 0x00000ADC
		private void Start()
		{
			this.data = base.GetComponentInParent<CharacterData>();
			HealthHandler healthHandler = this.data.healthHandler;
			healthHandler.reviveAction = (Action)Delegate.Combine(healthHandler.reviveAction, new Action(this.ResetTimer));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002916 File Offset: 0x00000B16
		private void OnDestroy()
		{
			HealthHandler healthHandler = this.data.healthHandler;
			healthHandler.reviveAction = (Action)Delegate.Combine(healthHandler.reviveAction, new Action(this.ResetTimer));
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002944 File Offset: 0x00000B44
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000294C File Offset: 0x00000B4C
		public void Awake()
		{
			this.player = base.gameObject.GetComponent<Player>();
			this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
			this.data = this.player.GetComponent<CharacterData>();
			this.healthHandler = this.player.GetComponent<HealthHandler>();
			this.gravity = this.player.GetComponent<Gravity>();
			this.block = this.player.GetComponent<Block>();
			this.gunAmmo = this.gun.GetComponentInChildren<GunAmmo>();
			this.numcheck = 0;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000029E4 File Offset: 0x00000BE4
		private void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				for (int i = 0; i <= this.player.data.currentCards.Count - 1; i++)
				{
					if (this.player.data.currentCards[i].cardName == "Beetle")
					{
						this.numcheck++;
					}
				}
				if (this.numcheck > 0)
				{
					this.ResetTimer();
					if (this.player.data.health < this.player.data.maxHealth && !this.active)
					{
						this.active = true;
						this.player.transform.gameObject.AddComponent<HyperLeechRegenMono>();
					}
				}
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002ABB File Offset: 0x00000CBB
		private void ResetTimer()
		{
			this.startTime = Time.time;
			this.numcheck = 0;
		}

		// Token: 0x04000016 RID: 22
		internal Player player;

		// Token: 0x04000017 RID: 23
		internal Gun gun;

		// Token: 0x04000018 RID: 24
		internal GunAmmo gunAmmo;

		// Token: 0x04000019 RID: 25
		internal Gravity gravity;

		// Token: 0x0400001A RID: 26
		internal HealthHandler healthHandler;

		// Token: 0x0400001B RID: 27
		internal CharacterData data;

		// Token: 0x0400001C RID: 28
		internal Block block;

		// Token: 0x0400001D RID: 29
		private readonly float updateDelay = 0.1f;

		// Token: 0x0400001E RID: 30
		private float startTime;

		// Token: 0x0400001F RID: 31
		public int numcheck;

		// Token: 0x04000020 RID: 32
		public bool active;
	}
}