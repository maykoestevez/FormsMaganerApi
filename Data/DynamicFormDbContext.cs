using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace DynamicFormApi.Data
{
    public class DynamicFormDbContext : DbContext
    {
        public DynamicFormDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DynamicFormControl> DynamicForm { get; set; }
        public DbSet<FormControlOption> FormOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormControlOptionConfiguration());
            modelBuilder.ApplyConfiguration(new DynamicFormControlConfiguration());
        }
    }

    [Table("form_options")]
    public class FormControlOption
    {
        [Column("form_option_id")]
        public int Id { get; set; }

        [Column("key")]
        public string Key { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("dynamic_form_control_id")]
        public int DynamicFormControlId { get; set; }
    }

    [Table("dynamic_form")]
    public class DynamicFormControl
    {
        [Column("dynamic_form_id")]
        public int Id { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("key")]
        public string Key { get; set; }

        [Column("label")]
        public string Label { get; set; }

        [Column("required")]
        public bool Required { get; set; }

        [Column("order")]
        public int Order { get; set; }

        [Column("control_type")]
        public string ControlType { get; set; }

        [Column("input_type")]
        public string Type { get; set; }

        public IEnumerable<FormControlOption> Options { get; set; }
    }

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
                    ControlType = "textbox"
                },
                new DynamicFormControl(){
                    Id = -2,
                    Label = "Email",
                    Key = "emailAddress",
                    Type="email",
                    Order = 2,
                    ControlType = "textbox"
                },
                {
                  new DynamicFormControl(){
                    Id = -3,
                    Key = "brave",
                    Label="Bravery Rating",
                    Order = 3,
                    ControlType = "dropdown"
                  }
                }
            });
            
        }
    }

    public enum ControlTypes
    {
        TextBox = 1,
        DropDown = 2,
        Options = 3
    }
    public enum InputTypes
    {
        Text = 1,
        Date = 2,
        Email = 3
    }
}