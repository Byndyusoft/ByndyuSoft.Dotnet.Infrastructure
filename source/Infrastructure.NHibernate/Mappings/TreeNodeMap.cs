namespace ByndyuSoft.Infrastructure.NHibernate.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// 
    /// </summary>
    public static class TreeNodeMap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="hierarchyTableName"></param>
        /// <typeparam name="T"></typeparam>
        public static void TreeMap<T>(this ClasslikeMapBase<T> map, string hierarchyTableName) where T : TreeNode<T>
        {
            map.References(x => x.Parent)
                .Nullable()
                .Column("PARENT_ID");

            map.HasMany(x => x.Children)
                .Access.ReadOnlyPropertyThroughCamelCaseField()
                .Cascade.All()
                .Inverse()
                .AsSet()
                .LazyLoad()
                .BatchSize(250)
                .KeyColumn("PARENT_ID");

            map.HasManyToMany(x => x.Ancestors)
                .Access.ReadOnlyPropertyThroughCamelCaseField()
                .Cascade.None()
                .AsSet()
                .LazyLoad()
                .BatchSize(250)
                .Table(hierarchyTableName)
                .ParentKeyColumn("CHILD_ID")
                .ChildKeyColumn("PARENT_ID")
                .ForeignKeyConstraintNames(string.Format("FK_{0}_CHILD", hierarchyTableName), null);

            map.HasManyToMany(x => x.Descendants)
                .Access.ReadOnlyPropertyThroughCamelCaseField()
                .Cascade.All()
                .Inverse()
                .AsSet()
                .LazyLoad()
                .BatchSize(250)
                .Table(hierarchyTableName)
                .ParentKeyColumn("PARENT_ID")
                .ChildKeyColumn("CHILD_ID")
                .ForeignKeyConstraintNames(string.Format("FK_{0}_PARENT", hierarchyTableName), null);
        }
    }
}