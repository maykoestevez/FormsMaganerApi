using System.Collections.Generic;

namespace DynamicFormApi.Data
{
    public class DynamicForm
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DynamicFormControl> FormControls { get; set; }

    }
}