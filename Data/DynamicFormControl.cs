using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFormApi.Data
{
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
}