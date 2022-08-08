namespace EC.MonoBehaviors
{
	// Token: 0x02000016 RID: 22
	public class PeeMono : RayHitEffect
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00004DB4 File Offset: 0x00002FB4
		public override HasToReturn DoHitEffect(HitInfo hit)
		{
			if (!hit.transform)
			{
				return HasToReturn.canContinue;
			}
			CharacterStatModifiers component = hit.transform.GetComponent<CharacterStatModifiers>();
			PeeMono component2 = hit.transform.GetComponent<PeeMono>();
			if (hit.transform.GetComponent<DamageOverTime>())
			{
				if (component)
				{
					component.RPCA_AddSlow(2.2f, true);
                }
			}
			return HasToReturn.canContinue;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004ED8 File Offset: 0x000030D8
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}