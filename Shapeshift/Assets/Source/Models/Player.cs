//  Copyright (c) 2016 Peter Entwistle
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.

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
