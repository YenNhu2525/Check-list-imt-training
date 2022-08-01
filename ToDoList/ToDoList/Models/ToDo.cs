using ToDoList.Areas.Identity.Data;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        //public virtual ToDoListUser User { get; set; }

        //public ToDo(ToDoListUser user) => User = user;
    }
}
