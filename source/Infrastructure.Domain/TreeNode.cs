namespace ByndyuSoft.Infrastructure.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TreeNode<T> 
        where T : TreeNode<T>
    {
        private readonly ICollection<T> ancestors = new HashSet<T>();
        private readonly ICollection<T> children = new HashSet<T>();
        private readonly ICollection<T> descendants = new HashSet<T>();

        /// <summary>
        ///     Parent node for current tree node
        /// </summary>
        public virtual T Parent { get; private set; }

        /// <summary>
        ///     List of children nodes for current tree node
        /// </summary>
        public virtual IEnumerable<T> Children
        {
            get { return children; }
        }

        /// <summary>
        ///     List of all nodes which lies above current tree node (parent, grandparents, etc.)
        /// </summary>
        public virtual IEnumerable<T> Ancestors
        {
            get { return ancestors; }
        }

        /// <summary>
        ///     List of all nodes which lies under current tree node (children, grandchildren, etc.)
        /// </summary>
        public virtual IEnumerable<T> Descendants
        {
            get { return descendants; }
        }

        protected T This
        {
            get { return (T) this; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public virtual void AddChild(T child)
        {
            children.Add(child);
            child.Parent = This;

            SetAncestorDescendantRelation(This, child);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ClearParent()
        {
            if (Parent == null) 
                return;

            UnSetAncestorDescendantRelation(Parent, This);
            var collection = (ICollection<T>) Parent.Children;
            collection.Remove(This);
            Parent = null;
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

            foreach (var grandDescendant in descendant.children)
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