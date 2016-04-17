using UnityEngine;
using System.Collections;

namespace Shapeshift.Source.Controllers {
	
	public class UIController : MonoBehaviour {

		public void ChopTreeOnClick() {
			if (GameManager.SelectedMode != SelectedMode.ChopTree)
				GameManager.SelectedMode = SelectedMode.ChopTree;
			else
				GameManager.SelectedMode = SelectedMode.None;
		}
	}
}