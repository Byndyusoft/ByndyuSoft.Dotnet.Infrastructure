namespace Mvc4Sample.Web.Application.Account.Services.Impl
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Mvc4Sample.Domain.Entities;

    public class AccountEntry
    {
        [Obsolete("Only for serializations")]
        public AccountEntry()
        {
        }

        public AccountEntry(User account)
        {
            Name = account.Login;
            Id = account.Id;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public RoleType RoleType { get; set; }

        public string Serialize()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof (AccountEntry));
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static AccountEntry Deserialize(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof (AccountEntry));

                return (AccountEntry) formatter.Deserialize(stream);
            }
        }
    }
}