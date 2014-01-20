namespace Mvc4Sample.Web.Application.Staff.Forms.Metadata
{
    using MvcExtensions;

    public class EditStaffFormMetadata : ModelMetadataConfiguration<EditStaffForm>
    {
        public EditStaffFormMetadata()
        {
            Configure(x => x.Id)
                .HideForEdit();

            Configure(x => x.Name)
                .DisplayName("Имя")
                .Required("Обязательное поле");
        }
    }
}