using System;
using UnityEngine;
using Verse;

namespace JinRohArmor
{
	// Token: 0x02000003 RID: 3
	public class JinRohSettings : ModSettings
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000021A1 File Offset: 0x000003A1
		public override void ExposeData()
		{
			Scribe_Values.Look<int>(ref this.versionNumber, "versionNumber", 0, false);
			base.ExposeData();
		}

		// Token: 0x04000005 RID: 5
		public int versionNumber = 0;

		// Token: 0x02000004 RID: 4
		public class JinRohMod : Mod
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000021CE File Offset: 0x000003CE
			public JinRohMod(ModContentPack content) : base(content)
			{
				this.settings1 = base.GetSettings<JinRohSettings>();
			}

			// Token: 0x06000008 RID: 8 RVA: 0x000021E8 File Offset: 0x000003E8
			public override void DoSettingsWindowContents(Rect inRect)
			{
				Listing_Standard listing_Standard = new Listing_Standard();
				listing_Standard.Begin(inRect);
				listing_Standard.Label(Translator.Translate("JRAUsePatchCEDesc"), -1f, null);
				bool flag = listing_Standard.RadioButton(Translator.Translate("JRAUsePatchVanilla"), this.settings1.versionNumber == 0, 8f, null);
				if (flag)
				{
					this.settings1.versionNumber = 0;
				}
				bool flag2 = listing_Standard.RadioButton(Translator.Translate("JRAUsePatchCE15"), this.settings1.versionNumber == 1, 8f, null);
				if (flag2)
				{
					this.settings1.versionNumber = 1;
					Log.Message("[JinRoh Armor] Settings: Patch 1.5 Selected", false);
				}
				bool flag3 = listing_Standard.RadioButton(Translator.Translate("JRAUsePatchCE16"), this.settings1.versionNumber == 2, 8f, null);
				if (flag3)
				{
					this.settings1.versionNumber = 2;
					Log.Message("[JinRoh Armor] Settings: Patch 1.6 Selected", false);
				}
				listing_Standard.End();
			}

			// Token: 0x06000009 RID: 9 RVA: 0x000022DC File Offset: 0x000004DC
			public override string SettingsCategory()
			{
				return Translator.Translate("JRASettingsModName");
			}

			// Token: 0x04000006 RID: 6
			private JinRohSettings settings1;
		}
	}
}
