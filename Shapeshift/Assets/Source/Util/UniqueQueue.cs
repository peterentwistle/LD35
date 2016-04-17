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

namespace Shapeshift.Source.Util {

	public class UniqueQueue<T> : IEnumerable<T>, IEnumerable {

		private Queue<T> _queue;

		public UniqueQueue() {
			_queue = new Queue<T>();
		}

		public int Count {
			get {
				return _queue.Count;
			}
		}

		/// <summary>
		/// Enqueue the specified item if it 
		/// isn't already contained in the Queue.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Enqueue(T item) {
			if (!_queue.Contains(item))
				_queue.Enqueue(item);
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void Clear() {
			_queue.Clear();
		}

		/// <summary>
		/// Contains the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public bool Contains(T item) {
			return _queue.Contains(item);
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void CopyTo(T[] array, int arrayIndex) {
			_queue.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// Dequeue this instance.
		/// </summary>
		public T Dequeue() {
			return _queue.Dequeue();
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<T> GetEnumerator() {
			return _queue.GetEnumerator();
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return _queue.GetEnumerator();
		}

		/// <summary>
		/// Peek this instance.
		/// </summary>
		public T Peek() {
			return _queue.Peek();
		}

		/// <summary>
		/// Tos the array.
		/// </summary>
		/// <returns>The array.</returns>
		public T[] ToArray() {
			return _queue.ToArray();
		}

		/// <summary>
		/// Trims the excess.
		/// </summary>
		public void TrimExcess() {
			_queue.TrimExcess();
		}
	}
}

