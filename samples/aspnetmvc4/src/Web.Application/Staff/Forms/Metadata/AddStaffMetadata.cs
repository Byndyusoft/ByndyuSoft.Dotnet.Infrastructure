namespace Mvc4Sample.Web.Application.Staff.Forms.Metadata
{
    using MvcExtensions;

    public class AddStaffMetadata : ModelMetadataConfiguration<CreateStaffForm>
    {
        public AddStaffMetadata()
        {
            Configure(x => x.Name)
                .DisplayName("Имя")
                .Required("Обязательное поле");

            Configure(x => x.Quantity)
                .Optional();
        }
    }
}