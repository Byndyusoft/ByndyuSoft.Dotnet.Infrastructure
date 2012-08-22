using System;
using System.Collections.Generic;

namespace ByndyuSoft.Infrastructure.Domain
{
	public abstract class TreeNode<T> where T : TreeNode<T>
	{
		private readonly ICollection<T> ancestors = new HashSet<T>();
		private readonly ICollection<T> children = new HashSet<T>();
		private readonly ICollection<T> descendants = new HashSet<T>();

		public virtual T Parent { get; private set; }

		public virtual IEnumerable<T> Children
		{
			get { return children; }
		}

		public virtual IEnumerable<T> Ancestors
		{
			get { return ancestors; }
		}

		public virtual IEnumerable<T> Descendants
		{
			get { return descendants; }
		}

		protected T This
		{
			get { return (T)this; }
		}

		public virtual void AddChild(T child)
		{
			children.Add(child);
			child.Parent = This;

			SetAncestorDescendantRelation(This, child);
		}

		public virtual void ClearParent()
		{
			if (Parent != null)
			{
				UnSetAncestorDescendantRelation(Parent, This);
				var collection = (ICollection<T>) Parent.Children;
				collection.Remove(This);
				Parent = null;				
			}
		}

		private static void UnSetAncestorDescendantRelation(T ancestor, T descendant)
		{
			ChangeAncestorDescendantRelation(ancestor, descendant, false);
		}

		private static void SetAncestorDescendantRelation(T ancestor, T descendant)
		{
			ChangeAncestorDescendantRelation(ancestor, descendant, true);
		}

		private static void ChangeAncestorDescendantRelation(T ancestor, T descendant, bool addRelation)
		{
			if (ancestor.Parent != null)
				ChangeAncestorDescendantRelation(ancestor.Parent, descendant, addRelation);
			foreach (T grandDescendant in descendant.children)
				ChangeAncestorDescendantRelation(ancestor, grandDescendant, addRelation);
			var ancestorDescendants = (ICollection<T>) ancestor.Descendants;
			var descendantAncestors = (ICollection<T>) descendant.Ancestors;
			if (addRelation)
			{
				ancestorDescendants.Add(descendant);
				descendantAncestors.Add(ancestor);
			}
			else
			{
				ancestorDescendants.Remove(descendant);
				descendantAncestors.Remove(ancestor);				
			}
		}
	}
}