using System;
using System.Collections;
using System.Collections.Generic;
using Shapeshift.Source.Util;
using Shapeshift.Source.Models.Jobs;

namespace Shapeshift.Source.Models {

	public class Player {

		public float HitPoints { get; private set; }
		public Gender Gender { get; private set;}
		public int Age { get; private set; }
		//public UniqueQueue<Job> JobQueue { get; private set; }
		public float MovementSpeed { get; private set; }
		public IJob CurrentJob { get; set; }
		public bool JobComplete { get; set; }

		public Player() {
			HitPoints = 100;
			Gender = randomGender();
			Age = new Random().Next(18, 75);
			//JobQueue = new UniqueQueue<Job>();
			MovementSpeed = 2f;
			CurrentJob = new IdleJob();
			JobComplete = true;
		}

		private Gender randomGender() {
			return new Random().Next(0, 2) == 0 ? Gender.Male : Gender.Female; 
		}

	}

	public enum Gender {
		Male,
		Female
	}
}
