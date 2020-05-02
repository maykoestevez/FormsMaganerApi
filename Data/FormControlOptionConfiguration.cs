using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicFormApi.Data
{
    public class FormControlOptionConfiguration : IEntityTypeConfiguration<FormControlOption>
    {
        public void Configure(EntityTypeBuilder<FormControlOption> builder)
        {

            builder.HasData(

               new List<FormControlOption>() {
                    new FormControlOption(){Id=-1, Key= "solid", Value= "Solid",DynamicFormControlId=-3 },
                    new FormControlOption(){Id=-2, Key= "great", Value= "Great",DynamicFormControlId=-3 },
                    new FormControlOption(){Id=-3, Key= "good", Value= "Good",DynamicFormControlId=-3 },
                    new FormControlOption(){Id=-4, Key= "unproven", Value= "Unproven",DynamicFormControlId=-3 }

                    });

        }
    }
}