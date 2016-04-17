using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Shapeshift.Source.Models.Resources;

namespace Shapeshift.Source.Controllers {
	
	public class UIController : MonoBehaviour {

		void Update() {
			foreach (var resource in GameManager.Resources) {
				if (resource.ResourceType == ResourceType.Wood) {
					GameObject.Find("WoodLabel").GetComponent<Text>().text = string.Format("Wood: {0}", resource.Quantity);
				}
			}
		}

		public void ChopTreeOnClick() {
			if (GameManager.SelectedMode != SelectedMode.ChopTree)
				GameManager.SelectedMode = SelectedMode.ChopTree;
			else
				GameManager.SelectedMode = SelectedMode.None;
		}
	}
}