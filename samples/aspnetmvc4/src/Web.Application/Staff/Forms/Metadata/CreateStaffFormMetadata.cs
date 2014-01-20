namespace Mvc4Sample.Web.Application.Staff.Forms.Metadata
{
    using MvcExtensions;

    public class CreateStaffFormMetadata : ModelMetadataConfiguration<CreateStaffForm>
    {
        public CreateStaffFormMetadata()
        {
            Configure(x => x.Name)
                .DisplayName("Имя")
                .Required("Обязательное поле");

            Configure(x => x.Quantity)
                .DisplayName("Количество")
                .Optional();
        }
    }
}