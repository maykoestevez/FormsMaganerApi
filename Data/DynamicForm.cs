using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicFormApi.Data
{
    public class DynamicForm
    {
        [Column("dynamic_form_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DynamicFormControl> FormControls { get; set; }
    }

    public class DynamicFormEntityConfiguration : IEntityTypeConfiguration<DynamicForm>
    {
        public void Configure(EntityTypeBuilder<DynamicForm> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new DynamicForm()
                {
                    Id = -1,
                    Name = "Profile"
                });
        }
    }
}