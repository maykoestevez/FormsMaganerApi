using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicFormApi.Data
{
    public class DynamicFormControlConfiguration : IEntityTypeConfiguration<DynamicFormControl>
    {
        public void Configure(EntityTypeBuilder<DynamicFormControl> builder)
        {
            builder.HasData(new List<DynamicFormControl>()
            {
                new DynamicFormControl(){
                    Id = -1,
                    Key = "firstName",
                    Label = "First name",
                    Value = "Bombasto",
                    Required = true,
                    Order = 1,
                    Type="text",
                    ControlType = "textbox",
                    DynamicFormId=-1
                },
                new DynamicFormControl(){
                    Id = -2,
                    Label = "Email",
                    Key = "emailAddress",
                    Type="email",
                    Order = 2,
                    ControlType = "textbox",
                    DynamicFormId=-1
                },
                {
                  new DynamicFormControl(){
                    Id = -3,
                    Key = "brave",
                    Label="Bravery Rating",
                    Order = 3,
                    ControlType = "dropdown",
                    DynamicFormId=-1
                  }
                }
            });

        }
    }
}