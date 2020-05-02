using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFormApi.Data
{
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
}